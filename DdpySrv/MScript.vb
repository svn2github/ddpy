Imports System.Text

Module MScript

    Private sc As Object = Nothing
    Public Function GetScriptWordList(ByVal codes As String) As String

        Try
            If sc Is Nothing Then
                sc = CreateObject("ScriptControl")
                sc.Language = "JScript"
                sc.AddCode(My.Resources.脚本框架)

                Dim files = My.Computer.FileSystem.GetFiles(GetDdpyScriptPath() _
                                                            , FileIO.SearchOption.SearchAllSubDirectories, "i*.js")
                For Each f As String In files
                    sc.AddCode(My.Computer.FileSystem.ReadAllText(f, Encoding.UTF8))
                Next

            End If

            Return sc.Run("main", codes)
        Catch ex As Exception
            sc = Nothing
            ComError(ex.Message, ex)
            Return ""
        End Try

    End Function

End Module
