Module MWeb

    Private objXML As Object = Nothing
    Public Function GetHttpResponse(ByVal url As String, Optional ByVal charset As String = "gb2312")
        If objXML Is Nothing Then
            objXML = CreateObject("Microsoft.XMLHTTP")
        End If

        objXML.Open("Get", url, False, "", "")
        objXML.sEnd()

        Return BytesToBstr(objXML.ResponseBody, charset)

    End Function

    Private Function BytesToBstr(ByVal strBody, ByVal charset) As String
        Dim objStream
        objStream = CreateObject("Adodb.Stream")

        With objStream
            .Type = 1
            .Mode = 3
            .Open()
            .Write(strBody)
            .Position = 0
            .Type = 2
            .Charset = charset
            BytesToBstr = .ReadText
        End With
        objStream.Close()
        objStream = Nothing
    End Function

End Module
