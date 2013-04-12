''' <summary>
''' 首选文字查询模块
''' </summary>
Module MRecommendWord

    ''' <summary>
    ''' 无误拼时检索“自动组合词”作为首选项
    ''' </summary>
    Friend Function GetRecommendWord(ByVal pyAry As String()) As CWord

        If pyAry Is Nothing OrElse pyAry.Length = 0 Then
            Return Nothing
        End If

        Dim lst As New List(Of CWord)
        Dim cd As String = ""
        Dim lstStack As New List(Of CWord)
        Dim tmpWord As CWord = Nothing
        Dim i As Integer = 0

        If Not GetFirstWord(Strings.Join(pyAry, "'")) Is Nothing Then
            Return Nothing
        End If

        For i = 0 To pyAry.Count - 1

            If cd = "" Then
                cd = cd & pyAry(i)
            Else
                cd = cd & "'" & pyAry(i)
            End If

            Dim word As CWord = GetFirstWord(cd)
            If (Not word Is Nothing) Then
                tmpWord = word
            Else
                If Not tmpWord Is Nothing Then
                    lstStack.Add(tmpWord)
                End If

                cd = pyAry(i)
                word = GetFirstWord(cd)
                If (Not word Is Nothing) Then
                    tmpWord = word
                End If

            End If

        Next

        If Not tmpWord Is Nothing Then
            lstStack.Add(tmpWord)
        End If


        ' 新文字
        Dim newWord As CWord = Nothing
        If lstStack.Count > 1 Then

            newWord = New CWord
            Dim txt As String = ""
            Dim shortPinYin As String = ""
            Dim pinYin As String = ""
            Dim zhuYin As String = ""

            lstStack.Reverse()
            For i = 0 To lstStack.Count - 1
                tmpWord = lstStack(i)

                If txt = "" Then
                    '文字,简拼,全拼,词频
                    shortPinYin = tmpWord.ShortPinYin & shortPinYin
                    pinYin = tmpWord.PinYin & pinYin
                Else
                    shortPinYin = tmpWord.ShortPinYin & "'" & shortPinYin
                    pinYin = tmpWord.PinYin & "'" & pinYin
                End If
                txt = tmpWord.Text & txt
            Next

            newWord.Text = txt
            newWord.ShortPinYin = shortPinYin
            newWord.PinYin = pinYin
            newWord.Order = 1
            newWord.WordType = WordType.USR
        End If

        Return newWord
    End Function

End Module
