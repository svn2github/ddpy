Imports System.Text

Module MScript

    Friend ddpyScriptFile As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\\淡定脚本.js"
    Private sc As Object = Nothing
    Public Function GetScriptWordList(ByVal codes As String) As String

        Try
            If True Then
                sc = CreateObject("ScriptControl")
                sc.Language = "JScript"
                sc.AddCode(My.Resources.脚本框架)
                sc.AddCode(My.Computer.FileSystem.ReadAllText(ddpyScriptFile, Encoding.UTF8))
            End If

            Return sc.Run("main", codes)
        Catch ex As Exception
            sc = Nothing
            ComError(ex.Message, ex)
            Return ""
        End Try

    End Function

End Module
