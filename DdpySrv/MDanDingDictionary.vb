﻿Imports System.Text

''' <summary>
''' 淡定拼音输入法字词管理模块
''' </summary>
Module MDanDingDictionary

    Private mDanDingDic As Hashtable = Nothing

    Private oCacheSyncLock As New Object
    Private mDicCache As New Hashtable  ' 拼音-List
    Private mDicCacheTick As New Hashtable  ' 拼音-Tick

    Private iOrder As Integer

    Friend bDataLoaded As Boolean

    ''' <summary>
    ''' 导入词库（"文字 简拼 全拼 注音 词频"  UTF-8）
    ''' </summary>
    Friend Sub ImportDanDingFile()

        If (Not mDanDingDic Is Nothing) Then
            Return
        End If

        ' 初始化字库
        If (mDanDingDic Is Nothing) Then
            mDanDingDic = New Hashtable ' [拼音 - CWord]
        End If

        iOrder = 2000 * 10000    ' (1千万 ～ 2千万)
        InitDanDingWordDic(GetDdpySingleWordFile()) ' 淡定字库

        iOrder = 5000 * 10000    ' (2千万 ～ 5千万)
        InitDanDingWordDic(GetDdpyMultWordFile()) ' 淡定词库

        ' 导入用户词库
        If My.Computer.FileSystem.FileExists(GetDdpyUserWordFile()) Then
            ImportWords(GetDdpyUserWordFile(), WordType.USR)
        End If

        ' 导入固顶词库
        iOrder = Integer.MaxValue
        ImportWords(GetDdpyTopWordFile(), WordType.TOP)

    End Sub

    ''' <summary>
    ''' 增加一个新文字
    ''' </summary>
    ''' <param name="word"></param>
    ''' <remarks></remarks>
    Friend Sub AddWordToDic(ByVal word As CWord)
        Dim lst As List(Of CWord) = InitWordList(Strings.Join(GetMutilShotPys(word.PinYin), "'"))

        For i As Integer = 0 To lst.Count - 1
            If word.PinYin.Equals(lst(i).PinYin) AndAlso word.Text.Equals(lst(i).Text) Then
                ' 存在全拼和文字都相同的文字时，不加
                Return
            End If
        Next
        lst.Add(word)

        AddWordToDic2(word)
    End Sub
    Private Sub AddWordToDic2(ByVal word As CWord)
        Dim lst As List(Of CWord) = InitWordList(Strings.Join(GetMutilShotPys2(word.PinYin), "'"))

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

                lst(i).WordType = lst(i).WordType And (WordType.TOP Or WordType.SYS Or WordType.IMP)
                If lst(i).WordType = WordType.UNKNOW Then
                    lst.RemoveAt(i)
                End If
            End If
        Next

        DeleteWordFromDic2(pinYin, text)
    End Sub
    Private Sub DeleteWordFromDic2(ByVal pinYin As String, ByVal text As String)

        Dim lst As List(Of CWord) = InitWordList(Strings.Join(GetMutilShotPys2(pinYin), "'"))
        Dim iSize As Integer = lst.Count
        For i As Integer = iSize - 1 To 0 Step -1
            If pinYin.Equals(lst(i).PinYin) AndAlso text.Equals(lst(i).Text) Then

                lst(i).WordType = lst(i).WordType And (WordType.TOP Or WordType.SYS Or WordType.IMP)
                If lst(i).WordType = WordType.UNKNOW Then
                    lst.RemoveAt(i)
                End If
            End If
        Next

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
    Friend Function GetWordList(ByVal codes As String) As String
        Dim ret As String = ""

        Dim okPys As String = BreakPys(codes).Split(" ")(0)  ' Get Right Py Only
        Dim aryPy As String() = okPys.Split("'")

        Dim stack As New Stack(Of List(Of CWord))
        Dim py As String = ""
        For i As Integer = 0 To aryPy.Length - 1
            If i = 0 Then
                py = aryPy(i)
            Else
                py = py & "'" & aryPy(i)
            End If

            Dim tmp As List(Of CWord) = SearchWords(py)
            If tmp.Count > 0 Then
                stack.Push(tmp)
            End If
        Next


        Dim lst As New List(Of CWord)
        Dim wordRecom As CWord = GetRecommendWord(aryPy)
        If Not wordRecom Is Nothing Then
            lst.Add(wordRecom)
        End If
        Do While stack.Count > 0
            lst.AddRange(stack.Pop())
        Loop


        ' 拼接成字符串作为结果返回给客户端
        Dim buf As New StringBuilder
        For i As Integer = 0 To lst.Count - 1
            If i = 0 Then
                buf.Append(lst(i).ToString)
            Else
                buf.Append(vbLf & lst(i).ToString)
            End If
        Next

        Return buf.ToString

    End Function


    ''' <summary>
    ''' 查找取得文字列表
    ''' </summary>
    ''' <param name="codes">拼音编码</param>
    ''' <returns>文字列表</returns>
    Friend Function SearchWords(ByVal codes As String, Optional ByVal bUseCache As Boolean = True) As List(Of CWord)

        SyncLock oCacheSyncLock

            Dim lstRet As New List(Of CWord)

            If codes = "" Then
                Return lstRet
            End If

            ' 查找缓存
            If bDataLoaded AndAlso bUseCache AndAlso mDicCache.ContainsKey(codes) Then
                Return mDicCache(codes)
            End If

            Dim shotCds As String() = GetMutilShotPys2(codes)     ' 简拼数组
            Dim cds As String() = codes.Split("'")          ' 输入的混拼数组

            ' 按简拼取词
            Dim lst As List(Of CWord) = mDanDingDic(Strings.Join(shotCds, "'").GetHashCode())

            If Not lst Is Nothing Then

                lst.Sort()
                Dim iCnt As Integer = 0

                For Each word As CWord In lst
                    ' 逐个比较
                    If MatchMutilPinYin(cds, shotCds, word.PinYin.Split("'"), word.Text) Then

                        lstRet.Add(word)    ' 满足输入的对象

                        If P_CAND_LIMIT AndAlso word.Text.Length > 1 Then
                            iCnt = iCnt + 1
                        End If

                        If P_CAND_LIMIT AndAlso iCnt >= P_CAND_LIMIT_NUM Then
                            Exit For
                        End If
                    End If
                Next

            End If

            '' 排序显示
            'lstRet.Sort()

            If bDataLoaded Then
                ' 缓存
                mDicCache(codes) = lstRet
                mDicCacheTick(codes) = Now.Ticks
            End If

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

        If mDanDingDic.Contains(scd.GetHashCode()) Then
            lst = mDanDingDic(scd.GetHashCode())
        Else
            lst = New List(Of CWord)
            mDanDingDic(scd.GetHashCode()) = lst
        End If

        Return lst
    End Function


    ''' <summary>
    ''' 从文件导入字库词库
    ''' </summary>
    ''' <param name="sPathFile">文件（"文字 全拼 词频"  UTF-8）</param>
    Private Sub ImportWords(ByVal sPathFile As String, ByVal wType As WordType)

        Dim txt As String = My.Computer.FileSystem.ReadAllText(sPathFile, Encoding.UTF8)
        Dim lines As String() = txt.Split(vbNewLine)
        Dim cols As String()
        Dim lstWord As List(Of CWord)
        Dim newWord As CWord = Nothing
        Dim existWord As CWord = Nothing

        Dim line As String
        Dim shotPys As String
        Dim shotPys2 As String

        For i As Integer = 0 To lines.Length - 1

            line = lines(i).Replace(vbLf, "")

            ' 忽略注释行、空行
            If line.StartsWith("//") OrElse line.Length = 0 Then
                Continue For
            End If

            ' "文字 全拼 词频" 
            cols = line.Split(vbTab)

            shotPys = Strings.Join(GetMutilShotPys(cols(1)), "'")
            existWord = GetWord(cols(0), shotPys, cols(1))  ' 查找"同字同拼音"字

            If existWord Is Nothing Then

                ' 不存在时追加
                newWord = New CWord()
                newWord.WordType = wType
                newWord.Text = cols(0)
                newWord.PinYin = cols(1)

                If wType And WordType.USR Then
                    newWord.UsrOrder = cols(2)
                Else
                    iOrder = iOrder - 1
                    newWord.Order = iOrder
                End If

                lstWord = InitWordList(shotPys)
                lstWord.Add(newWord)

                If newWord.WordType And WordType.USR Then
                    RegisterUserWord(newWord)
                End If
            Else
                ' 已存在时，更新类型
                existWord.WordType = existWord.WordType Or wType

                If wType And WordType.USR Then
                    existWord.UsrOrder = cols(2)
                Else
                    iOrder = iOrder - 1
                    existWord.Order = iOrder
                End If

                If existWord.WordType And WordType.USR Then
                    RegisterUserWord(existWord)
                End If
            End If


            ' ''''''''''''
            shotPys2 = Strings.Join(GetMutilShotPys2(cols(1)), "'")
            If Not P_ADD_FIRST_WORD_IDX OrElse shotPys.Equals(shotPys2) Then
                Continue For
            End If

            existWord = GetWord(cols(0), shotPys, cols(1))  ' 查找"同字同拼音"字

            If existWord Is Nothing Then

                ' 不存在时追加
                If newWord Is Nothing Then
                    newWord = New CWord()
                    newWord.WordType = wType
                    newWord.Text = cols(0)
                    newWord.PinYin = cols(1)

                    If wType And WordType.USR Then
                        newWord.UsrOrder = cols(2)
                    Else
                        iOrder = iOrder - 1
                        newWord.Order = iOrder
                    End If

                End If

                lstWord = InitWordList(shotPys)
                lstWord.Add(newWord)

                If newWord.WordType And WordType.USR Then
                    RegisterUserWord(newWord)
                End If
            Else
                ' 已存在时，仅更新类型
                existWord.WordType = existWord.WordType Or wType

                If wType And WordType.USR Then
                    existWord.UsrOrder = cols(2)
                Else
                    iOrder = iOrder - 1
                    existWord.Order = iOrder
                End If

                If existWord.WordType And WordType.USR Then
                    RegisterUserWord(existWord)
                End If
            End If


        Next

    End Sub


    ''' <summary>
    ''' 从文件导入系统字库词库
    ''' </summary>
    ''' <param name="sPathFile">文件（"文字 全拼"  UTF-8）</param>
    Private Sub InitDanDingWordDic(ByVal sPathFile As String)

        Dim txt As String = My.Computer.FileSystem.ReadAllText(sPathFile, Encoding.UTF8)
        Dim lines As String() = txt.Split(vbNewLine)    ' 实际效果是按VbCr分割
        Dim cols As String()
        Dim lstWord As List(Of CWord)
        Dim newWord As CWord = Nothing
        Dim existWord As CWord = Nothing

        Dim line As String
        Dim shotPys As String
        Dim shotPys2 As String

        For i As Integer = 0 To lines.Length - 1

            line = lines(i).Replace(vbLf, "")

            ' 忽略注释行、空行
            If line.StartsWith("//") OrElse line.Length = 0 Then
                Continue For
            End If

            ' "文字 全拼" 
            cols = line.Split(vbTab)

            shotPys = Strings.Join(GetMutilShotPys(cols(1)), "'")
            shotPys2 = Strings.Join(GetMutilShotPys2(cols(1)), "'")

            ' 直接追加
            newWord = New CWord()
            newWord.WordType = WordType.SYS
            newWord.Text = cols(0)
            newWord.PinYin = cols(1)

            iOrder = iOrder - 1
            newWord.Order = iOrder

            lstWord = InitWordList(shotPys)
            lstWord.Add(newWord)

            If P_ADD_FIRST_WORD_IDX AndAlso Not shotPys2.Equals(shotPys) Then
                lstWord = InitWordList(shotPys2)
                lstWord.Add(newWord)
            End If

            'If newWord.WordType And WordType.USR Then
            '    RegisterUserWord(newWord)
            'End If

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
