Imports System.Text

''' <summary>
''' 用户词库管理模块
''' </summary>
''' <remarks></remarks>
Module MUserWord

    Friend userWordFile As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\\用户词库.txt"

    Private mapUserWords As New Hashtable
    Private hasNewRegisterWord As Boolean = False

    ''' <summary>
    ''' 登记文字
    ''' </summary>
    ''' <param name="word">文字对象</param>
    Public Sub RegisterUserWord(ByVal word As CWord)
        Dim wordKey As String = word.PinYin & vbTab & word.Text
        If Not mapUserWords.ContainsKey(wordKey) Then
            mapUserWords(wordKey) = word
            hasNewRegisterWord = True
        End If
    End Sub

    ''' <summary>
    ''' 注销文字
    ''' </summary>
    ''' <param name="pinYin">拼音全拼</param>
    ''' <param name="text">指定字词</param>
    Public Sub UnRegisterUserWord(ByVal pinYin As String, ByVal text As String)

        Dim wordKey As String = pinYin & vbTab & text
        
        If mapUserWords.ContainsKey(wordKey) Then
            Dim word As CWord = mapUserWords(wordKey)
            word.UsrOrder = 0
            mapUserWords.Remove(wordKey)
            hasNewRegisterWord = True
        End If

    End Sub

    ''' <summary>
    ''' 保存用户词库
    ''' </summary>
    ''' <param name="bConditionSave">有条件保存</param>
    Public Sub SaveUserWords(Optional ByVal bConditionSave As Boolean = True)

        ' 减少写文件操作
        If bConditionSave AndAlso Not hasNewRegisterWord Then
            Return
        End If
        hasNewRegisterWord = False

        ' 保存用户词库
        Dim txt As New StringBuilder
        Dim lst As New List(Of CWord)
        For Each key As String In mapUserWords.Keys
            lst.Add(mapUserWords(key))
        Next

        lst.Sort(Function(w1 As CWord, w2 As CWord)
                     If w1.PinYin.CompareTo(w2.PinYin) = 0 Then
                         Return w1.UsrOrder.CompareTo(w2.UsrOrder)
                     End If
                     Return w1.PinYin.CompareTo(w2.PinYin)
                 End Function)

        For i As Integer = 0 To lst.Count - 1
            txt.AppendLine(lst(i).Text & vbTab & lst(i).PinYin & vbTab & lst(i).UsrOrder)
        Next
        My.Computer.FileSystem.WriteAllText(userWordFile, txt.ToString, False, Encoding.UTF8)

    End Sub


    Public Sub RegisterWords(ByVal words As String)

        Dim lines As String() = words.Split(vbLf)
        Dim pys As String() = lines(0).Split(vbTab)
        Dim txts As String() = lines(1).Split(vbTab)
        For i As Integer = 0 To pys.Length - 1

            ' 拼音或文字为空时忽略
            If "".Equals(Trim(pys(i))) OrElse "".Equals(Trim(txts(i))) Then
                Continue For
            End If

            Dim sFstChar As String = Strings.Left(txts(i), 1)
            If txts(i).Replace("啊", "").Length = 0 Then
                ' 无视 啊啊啊啊啊啊啊啊啊
                Continue For
            End If
            If txts(i).Length > 3 AndAlso txts(i).Replace(sFstChar, "").Length = 0 Then
                ' 无视3个以上的重复字
                Continue For
            End If
            If txts(i).Length > 20 Then
                ' 无视过长文字
                Continue For
            End If
            Dim shotPy As String = Strings.Join(GetMutilShotPys(pys(i)), "")
            If shotPy.Length > 4 AndAlso shotPy.Replace(Strings.Left(shotPy, 1), "").Length = 0 Then
                ' 无视4个以上的重复简拼字
                Continue For
            End If


            Dim newWord As New CWord()
            newWord.Text = txts(i)
            newWord.PinYin = pys(i)
            newWord.UsrOrder = 1
            newWord.WordType = WordType.USR

            RegisterWordByPinyin(newWord, True)

            Dim difPinyin As String = BreakPys(newWord.PinYin.Replace("'", ""))
            If Not newWord.PinYin.Equals(difPinyin) AndAlso difPinyin.IndexOf(" ") < 0 Then

                Dim newWord2 = New CWord()
                newWord2.Text = newWord.Text
                newWord2.PinYin = difPinyin
                newWord2.UsrOrder = 1
                newWord2.WordType = WordType.USR

                RegisterWordByPinyin(newWord2, False)
            End If

        Next

    End Sub


    Private Sub RegisterWordByPinyin(ByVal newWord As CWord, ByVal bUserWord As Boolean)

        ' 为确保正确，查询不使用缓存
        Dim lst As List(Of CWord) = SearchWords(newWord.PinYin, False)

        Dim isExist As Boolean = False
        For Each word As CWord In lst
            If newWord.Equals(word) Then

                If Not bUserWord Then
                    Return
                End If

                ' 存在则更新文字类型和频率
                If word.WordType And WordType.USR Then
                    word.UsrOrder = word.UsrOrder + 1
                Else
                    word.UsrOrder = 1
                End If

                word.WordType = word.WordType Or WordType.USR

                isExist = True
                RegisterUserWord(word)

                Exit For
            End If
        Next

        If Not isExist Then
            ' 不存在则追加到检索用词库和用户词库
            AddWordToDic(newWord)

            ' 为了以后能用，保存在用户词库中
            RegisterUserWord(newWord)

            ' 非用户词词频设定为0便于区分
            If Not bUserWord Then
                newWord.UsrOrder = 0
            End If
        End If

    End Sub


End Module
