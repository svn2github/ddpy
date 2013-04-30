Imports System.Text
Imports System.IO

''' <summary>
''' 开发调试用模块
''' </summary>
Module MDebug

    Friend frmDebug As FrmImeDebug
    Private oldTime As Integer = 0

    Friend Sub ComDebug(ByVal ex As Exception)

        Dim sLogFile As String = GetAllUsersLogPath() & "\\DdpyCom-" & Now.ToString("yyyy-MM-dd") & ".log"
        Dim txt As String = Now.ToString("yyyy-MM-dd HH:mm:ss.fff  ") & ex.Message & vbNewLine & ex.StackTrace & vbNewLine
        My.Computer.FileSystem.WriteAllText(sLogFile, txt, True, Encoding.UTF8)

        ComDebug(ex.Message & vbNewLine & ex.StackTrace)
    End Sub

    Friend Sub ComInfo(ByVal info As String)

        Dim sLogFile As String = GetAllUsersLogPath() & "\\DdpyCom-" & Now.ToString("yyyy-MM-dd") & ".log"
        Dim txt As String = Now.ToString("yyyy-MM-dd HH:mm:ss.fff  ") & info & vbNewLine
        My.Computer.FileSystem.WriteAllText(sLogFile, txt, True, Encoding.UTF8)

    End Sub

    Friend Sub ComDebug(ByVal info As String, Optional ByVal newLine As Boolean = True)

        'Dim sLogFile As String = GetAllUsersLogPath() & "\\DdpyCom-" & Now.ToString("yyyy-MM-dd") & ".log"
        'Dim txts As String = Now.ToString("yyyy-MM-dd HH:mm:ss.fff  ") & info & vbNewLine
        'My.Computer.FileSystem.WriteAllText(sLogFile, txts, True, Encoding.UTF8)
        If True Then
            Return
        End If


        If frmDebug Is Nothing Then
            frmDebug = New FrmImeDebug
        End If

        Dim newTime As Integer = Now.ToString("1HHmmss")
        If newTime - oldTime > 1 Then
            frmDebug.Debug("")  ' 打印空行方便阅读
            oldTime = newTime
        End If

        Dim txt As String = ""
        If newLine Then
            txt = Now.ToString("HH:mm:ss.fff  ") & info
        Else
            txt = info
        End If

        frmDebug.Debug(txt)

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
