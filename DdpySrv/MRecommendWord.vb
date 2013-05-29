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
        Dim tmpWord As CWord = Nothing

        ' 有完全匹配的文字存在时，不做自动组合
        Dim firstWord As CWord = GetFirstWord(Strings.Join(pyAry, "'"))
        If Not firstWord Is Nothing Then
            Return Nothing
        End If

        Dim iStart As Integer = 0
        For i As Integer = pyAry.Length - 2 To iStart Step -1

            cd = JoinPinyin(pyAry, iStart, i)
            tmpWord = GetFirstWord(cd)

            If tmpWord IsNot Nothing Then
                lst.Add(tmpWord)

                iStart = i + 1
                i = pyAry.Length
            End If
        Next

        ' 新文字
        Dim newWord As CWord = Nothing
        If lst.Count > 1 Then

            newWord = New CWord
            Dim txt As String = ""
            Dim pinYin As String = ""

            For i As Integer = lst.Count - 1 To 0 Step -1
                tmpWord = lst(i)

                If pinYin = "" Then
                    pinYin = tmpWord.PinYin & pinYin
                Else
                    pinYin = tmpWord.PinYin & "'" & pinYin
                End If
                txt = tmpWord.Text & txt
            Next

            newWord.Text = txt
            newWord.PinYin = pinYin
            newWord.WordType = WordType.UNKNOW
        End If

        Return newWord
    End Function


    ''' <summary>
    ''' 用分隔符拼接指定范围的拼音
    ''' </summary>
    ''' <param name="pyAry">拼音数组</param>
    ''' <param name="iStart">开始位置</param>
    ''' <param name="iEnd">结束位置</param>
    ''' <returns>拼接好的拼音</returns>
    Private Function JoinPinyin(ByVal pyAry As String(), ByVal iStart As Integer, ByVal iEnd As Integer) As String
        Dim cd As String = ""

        For i As Integer = iStart To iEnd
            If cd = "" Then
                cd = cd & pyAry(i)
            Else
                cd = cd & "'" & pyAry(i)
            End If
        Next

        Return cd
    End Function

End Module
