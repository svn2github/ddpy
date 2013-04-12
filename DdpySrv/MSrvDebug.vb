Imports System.Text

''' <summary>
''' 开发调试用模块
''' </summary>
Module MSrvDebug

    Private oldTime As Integer = 0
    Private sLogPath As String = ""

    Public Function GetUserLogPath() As String

        If Not sLogPath = "" Then
            Return sLogPath
        End If

        Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        sPath = My.Computer.FileSystem.GetParentPath(sPath)
        sPath = My.Computer.FileSystem.GetParentPath(sPath) & "\\Log"

        If Not My.Computer.FileSystem.DirectoryExists(sPath) Then
            My.Computer.FileSystem.CreateDirectory(sPath)
        End If

        sLogPath = sPath

        Return sLogPath
    End Function


    Public Sub ComDebug(ByVal info As String)

        'Dim sLogFile As String = GetUserLogPath() & "\\DdpySrv-" & Now.ToString("yyyy-MM-dd") & ".log"
        'Dim txt As String = Now.ToString("yyyy-MM-dd HH:mm:ss.fff ") & info & vbNewLine
        'My.Computer.FileSystem.WriteAllText(sLogFile, txt, True, Encoding.UTF8)

    End Sub

    Public Sub ComError(ByVal info As String, Optional ByVal ex As Exception = Nothing)

        Dim sLogFile As String = GetUserLogPath() & "\\DdpySrv-" & Now.ToString("yyyy-MM-dd") & ".log"
        Dim txt As String = Now.ToString("yyyy-MM-dd HH:mm:ss.fff ") & info & vbNewLine
        If Not ex Is Nothing Then
            txt = txt & ex.Message & vbNewLine & ex.StackTrace & vbNewLine
        End If
        My.Computer.FileSystem.WriteAllText(sLogFile, txt, True, Encoding.UTF8)

    End Sub

End Module
