Imports System.Text

''' <summary>
''' 开发调试用模块
''' </summary>
Module MSrvDebug

    Private oldTime As Integer = 0
    Private sLogPath As String = ""
    Private oFileLock As New Object

    Public Sub ComDebug(ByVal info As String)

        'SyncLock oFileLock
        '    Dim txt As String = Now.ToString("yyyy-MM-dd HH:mm:ss.fff ") & info & vbNewLine
        '    My.Computer.FileSystem.WriteAllText(GetDdpyLogFile(), txt, True, Encoding.UTF8)
        'End SyncLock

    End Sub

    Public Sub ComInfo(ByVal info As String, Optional ByVal ex As Exception = Nothing)
        ComError(info, ex)
    End Sub
    Public Sub ComError(ByVal info As String, Optional ByVal ex As Exception = Nothing)

        SyncLock oFileLock

            Dim txt As String = Now.ToString("yyyy-MM-dd HH:mm:ss.fff ") & info & vbNewLine
            If Not ex Is Nothing Then
                txt = txt & ex.Message & vbNewLine & ex.StackTrace & vbNewLine
            End If
            My.Computer.FileSystem.WriteAllText(GetDdpyLogFile(), txt, True, Encoding.UTF8)

        End SyncLock

    End Sub

    Private lTimeStart As Long
    ''' <summary>
    ''' 计时开始
    ''' </summary>
    Friend Sub DebugTimeStart()
        lTimeStart = Now.Ticks
    End Sub

    ''' <summary>
    ''' 计时结束
    ''' </summary>
    ''' <returns>毫秒</returns>
    Friend Function DebugTimeEnd() As String
        Return (Now.Ticks - lTimeStart) \ 10000
    End Function

End Module
