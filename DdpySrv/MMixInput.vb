Imports System.Text

Module MMixInput

    Private lstMix As List(Of String)


    Friend Sub InitMixInputFile()

        ' 网址邮件等用户混合输入文件

        lstMix = New List(Of String)
        Dim txt As String = My.Computer.FileSystem.ReadAllText(GetDdpyUserMixInputFile(), Encoding.UTF8)
        Dim lines As String() = txt.Split(vbNewLine)

        For i As Integer = 0 To lines.Length - 1

            Dim line As String = Trim(lines(i).Replace(vbLf, ""))
            If line = "" Then
                Continue For
            End If

            lstMix.Add(line)
        Next

        lstMix.Sort()

    End Sub

    Friend Function IsMixInput(ByVal leftPy As String, ByVal rightPy As String, Optional ByVal sChar As String = "") As Boolean

        Dim sInput As String = leftPy & sChar & rightPy
        Dim sTmp As String = leftPy & rightPy

        If "".Equals(sTmp) And IsNumeric(sChar) Then
            Return False
        End If

        If Not sInput.Equals(sInput.ToLower) Then
            Return True
        End If

        If sInput.StartsWith("www.") OrElse sInput.StartsWith("http:") OrElse sInput.StartsWith("https:") OrElse sInput.StartsWith("ftp:") Then
            Return True
        End If

        If sTmp.IndexOf("@") > 0 OrElse sTmp.IndexOf("/") > 0 OrElse sTmp.IndexOf("*") > 0 OrElse sTmp.IndexOf("-") > 0 _
             OrElse sTmp.IndexOf("+") > 0 OrElse sTmp.IndexOf(".") > 0 OrElse sTmp.IndexOf("0") > 0 _
            OrElse sTmp.IndexOf("1") > 0 OrElse sTmp.IndexOf("2") > 0 OrElse sTmp.IndexOf("3") > 0 _
            OrElse sTmp.IndexOf("4") > 0 OrElse sTmp.IndexOf("5") > 0 OrElse sTmp.IndexOf("6") > 0 _
            OrElse sTmp.IndexOf("7") > 0 OrElse sTmp.IndexOf("8") > 0 OrElse sTmp.IndexOf("9") > 0 Then
            Return True
        End If

        If sInput.IndexOf("@") > 0 Then
            Return True
        End If

        If sInput.IndexOf(".") > 0 OrElse sInput.IndexOf("0") > 0 _
             OrElse sInput.IndexOf("1") > 0 OrElse sInput.IndexOf("2") > 0 OrElse sInput.IndexOf("3") > 0 _
             OrElse sInput.IndexOf("4") > 0 OrElse sInput.IndexOf("5") > 0 OrElse sInput.IndexOf("6") > 0 _
             OrElse sInput.IndexOf("7") > 0 OrElse sInput.IndexOf("8") > 0 OrElse sInput.IndexOf("9") > 0 _
             Then

            For Each line As String In lstMix
                If line.Length > sInput.Length AndAlso line.StartsWith(sInput, StringComparison.OrdinalIgnoreCase) Then
                    Return True
                End If
            Next

        End If

        Return False
    End Function

    Friend Function SearchMixWords(ByVal codes As String) As List(Of CWord)

        Dim word As CWord
        Dim lst As New List(Of CWord)
        For Each line As String In lstMix
            If line.Length > codes.Length AndAlso line.StartsWith(codes, StringComparison.OrdinalIgnoreCase) Then
                word = New CWord()
                word.Text = line
                word.IsMixWord = True
                lst.Add(word)
            End If
        Next

        Return lst
    End Function

    Friend Sub SaveMixInputData()

        Dim bufTxt As New StringBuilder
        lstMix.Sort()
        For Each line As String In lstMix
            bufTxt.AppendLine(line)
        Next

        My.Computer.FileSystem.WriteAllText(GetDdpyUserMixInputFile(), bufTxt.ToString, False, Encoding.UTF8)
    End Sub


    Friend Sub AddMixInputData(ByVal sData As String)

        ' 太短的不处理，不是混合输入不处理
        If sData.Length < 5 OrElse Not IsMixInput(sData, "") Then
            Return
        End If

        For Each line As String In lstMix
            If line.Equals(sData, StringComparison.OrdinalIgnoreCase) Then
                Return
            End If
        Next

        lstMix.Add(sData)
        SaveMixInputData()

    End Sub


    Friend Sub DeleteMixInputData(ByVal sData As String)

        Dim bExist As Boolean = False
        For i As Integer = lstMix.Count - 1 To 0 Step -1
            If lstMix(i).Equals(sData, StringComparison.OrdinalIgnoreCase) Then
                lstMix.RemoveAt(i)
                bExist = True
            End If
        Next

        If bExist Then
            SaveMixInputData()
        End If

    End Sub

End Module
