Imports System.Text

''' <summary>
''' 淡定拼音输入法字词管理模块
''' </summary>
Module MDanDingDictionary

    Private mDanDingDic As Hashtable = Nothing

    Private oCacheSyncLock As New Object
    Private mDicCache As New Hashtable  ' 拼音-List
    Private mDicCacheTick As New Hashtable  ' 拼音-Tick

    ''' <summary>
    ''' 增加一个新文字
    ''' </summary>
    ''' <param name="word"></param>
    ''' <remarks></remarks>
    Friend Sub AddWordToDic(ByVal word As CWord)
        Dim lst As List(Of CWord) = InitWordList(word.ShortPinYin)

        For i As Integer = 0 To lst.Count - 1
            If word.PinYin.Equals(lst(i).PinYin) AndAlso word.Text.Equals(lst(i).Text) Then
                ' 存在全拼和文字都相同的文字时，不加
                Return
            End If
        Next
        lst.Add(word)
    End Sub


    ''' <summary>
    ''' 删除指定字词
    ''' </summary>
    ''' <param name="pinYin">拼音全拼</param>
    ''' <param name="text">指定字词</param>
    Friend Sub DeleteWordFromDic(ByVal pinYin As String, ByVal text As String)

        Dim lst As List(Of CWord) = InitWordList(Strings.Join(GetMutilShotPys(pinYin), "'"))
        Dim iSize As Integer = lst.Count
        For i As Integer = iSize - 1 To 0 Step -1
            If pinYin.Equals(lst(i).PinYin) AndAlso text.Equals(lst(i).Text) Then
                lst.RemoveAt(i)
            End If
        Next

    End Sub

    ''' <summary>
    ''' 导入词库（"文字 简拼 全拼 注音 词频"  UTF-8）
    ''' </summary>
    Friend Sub ImportDanDingFile()

        If (Not mDanDingDic Is Nothing) Then
            Return
        End If

        Dim sFileDic As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\\淡定字库.txt"
        If Not My.Computer.FileSystem.FileExists(sFileDic) Then
            My.Computer.FileSystem.WriteAllText(sFileDic, My.Resources.淡定字库, False, Encoding.UTF8)
        End If
        Dim sFileWrd As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\\淡定词库.txt"
        If Not My.Computer.FileSystem.FileExists(sFileWrd) Then
            My.Computer.FileSystem.WriteAllText(sFileWrd, My.Resources.淡定词库, False, Encoding.UTF8)
        End If

        ' 初始化字库
        If (mDanDingDic Is Nothing) Then
            mDanDingDic = New Hashtable ' "拼音 - CWord
            InitDanDingWordDic(sFileDic, WordType.SYS) ' 淡定字库
            InitDanDingWordDic(sFileWrd, WordType.SYS) ' 淡定词库
        End If

        ' 导入用户词库
        If My.Computer.FileSystem.FileExists(userWordFile) Then
            InitDanDingWordDic(userWordFile, WordType.USR)
        End If

        '' 排序
        'Dim lst As List(Of CWord) = Nothing
        'For Each key As String In mDanDingDic.Keys
        '    lst = mDanDingDic(key)
        '    lst.Sort()
        'Next

    End Sub


    ''' <summary>
    ''' 清除缓存
    ''' </summary>
    Friend Sub CacheCollect(Optional ByVal clear As Boolean = False)
        SyncLock oCacheSyncLock

            If clear Then
                mDicCache.Clear()
                mDicCacheTick.Clear()
                Return
            End If

            Dim nowTick As Long = Now.Ticks
            Dim lstKey As New List(Of String)
            For Each key As String In mDicCacheTick.Keys

                ' 缓存保留10秒
                If (nowTick - mDicCacheTick(key)) > 100000000 Then
                    lstKey.Add(key)
                Else
                    Dim lst As List(Of CWord) = mDicCache(key)
                    lst.Sort()
                End If

            Next

            For Each key As String In lstKey
                mDicCache.Remove(key)
                mDicCacheTick.Remove(key)
            Next

        End SyncLock

    End Sub

    ''' <summary>
    ''' 查找满足条件的第一个最优先文字
    ''' </summary>
    ''' <param name="codes">拼音编码</param>
    ''' <returns>第一个最优先文字</returns>
    Friend Function GetFirstWord(ByVal codes As String) As CWord

        Dim lst As List(Of CWord) = SearchWords(codes)

        If lst.Count > 0 Then
            Return lst.First
        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' 查找取得文字列表
    ''' </summary>
    ''' <param name="codes">拼音编码</param>
    ''' <returns>文字列表</returns>
    Friend Function SearchWords(ByVal codes As String) As List(Of CWord)

        SyncLock oCacheSyncLock

            Dim lstRet As New List(Of CWord)

            If codes = "" Then
                Return lstRet
            End If

            ' 查找缓存
            If mDicCache.ContainsKey(codes) Then
                Return mDicCache(codes)
            End If

            Dim shotCds As String() = GetMutilShotPys(codes)     ' 简拼数组
            Dim cds As String() = codes.Split("'")          ' 输入的混拼数组

            ' 按简拼取词
            Dim lst As List(Of CWord) = mDanDingDic(Strings.Join(shotCds, "'"))

            If Not lst Is Nothing Then

                For Each word As CWord In lst
                    ' 逐个比较
                    If MatchMutilPinYin(cds, shotCds, word.PinYin.Split("'")) Then
                        lstRet.Add(word)    ' 满足输入的对象
                    End If
                Next

            End If

            ' 排序显示
            lstRet.Sort()

            ' 缓存
            mDicCache(codes) = lstRet
            mDicCacheTick(codes) = Now.Ticks

            Return lstRet

        End SyncLock
    End Function


    ''' <summary>
    ''' 取得Map中的文字列表（不存在时自动创建）
    ''' </summary>
    ''' <param name="scd">简拼</param>
    ''' <returns>文字列表</returns>
    Private Function InitWordList(ByVal scd As String) As List(Of CWord)

        Dim lst As List(Of CWord)

        If mDanDingDic.Contains(scd) Then
            lst = mDanDingDic(scd)
        Else
            lst = New List(Of CWord)
            mDanDingDic(scd) = lst
        End If

        Return lst
    End Function


    ''' <summary>
    ''' 从文件导入字库词库
    ''' </summary>
    ''' <param name="sPathFile">文件（"文字 简拼 全拼 注音 词频"  UTF-8）</param>
    Private Sub InitDanDingWordDic(ByVal sPathFile As String, ByVal wType As WordType)

        Dim txt As String = My.Computer.FileSystem.ReadAllText(sPathFile, Encoding.UTF8)
        Dim lines As String() = txt.Split(vbNewLine)
        Dim cols As String()
        Dim lstWord As List(Of CWord)
        Dim newWord As CWord = Nothing
        Dim existWord As CWord = Nothing

        For i As Integer = 0 To lines.Length - 1

            Dim line As String = Trim(lines(i).Replace(vbLf, ""))

            ' 忽略注释行、空行
            If line.StartsWith("//") OrElse "".Equals(line) Then
                Continue For
            End If

            ' "文字 全拼 词频" 
            cols = line.Split(vbTab)

            Dim shotPys As String = Strings.Join(GetMutilShotPys(cols(1)), "'")
            existWord = GetWord(cols(0), shotPys, cols(1))  ' 查找"同字同拼音"字

            If existWord Is Nothing Then

                ' 不存在时追加
                newWord = New CWord()
                newWord.WordType = wType
                newWord.Text = cols(0)
                newWord.ShortPinYin = shotPys
                newWord.PinYin = cols(1)
                newWord.Order = cols(2)

                lstWord = InitWordList(newWord.ShortPinYin)
                lstWord.Add(newWord)

                If newWord.WordType And WordType.USR Then
                    RegisterUserWord(newWord)
                End If
            Else
                ' 已存在时，仅更新类型
                existWord.WordType = existWord.WordType Or wType

                If existWord.WordType And WordType.USR Then
                    RegisterUserWord(existWord)
                End If
            End If

        Next

    End Sub

    ''' <summary>
    ''' 文字查找
    ''' </summary>
    ''' <param name="txt">文字</param>
    ''' <param name="spy">简拼</param>
    ''' <param name="py">全拼</param>
    ''' <returns>文字对象（找不到为Nothing）</returns>
    Private Function GetWord(ByVal txt As String, ByVal spy As String, ByVal py As String) As CWord
        Dim word As CWord = Nothing
        Dim lstWord As List(Of CWord) = InitWordList(spy)

        For Each word In lstWord
            If word.Text.Equals(txt) AndAlso word.PinYin.Equals(py) Then
                Return word
            End If
        Next

        Return Nothing
    End Function

End Module
