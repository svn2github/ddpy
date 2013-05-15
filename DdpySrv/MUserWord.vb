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
            mapUserWords.Remove(wordKey)
            hasNewRegisterWord = True
        End If

    End Sub

    ''' <summary>
    ''' 保存用户词库
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveUserWords()

        ' 减少写文件操作
        If Not hasNewRegisterWord Then
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
                     If w1.ShortPinYin.CompareTo(w2.ShortPinYin) = 0 Then
                         Return w1.Order.CompareTo(w1.Order)
                     End If
                     Return w1.ShortPinYin.CompareTo(w2.ShortPinYin)
                 End Function)

        For i As Integer = 0 To lst.Count - 1
            txt.AppendLine(lst(i).Text & vbTab & lst(i).PinYin & vbTab & lst(i).Order)
        Next
        My.Computer.FileSystem.WriteAllText(userWordFile, txt.ToString, False, Encoding.UTF8)

    End Sub

End Module
