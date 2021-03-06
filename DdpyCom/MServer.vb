﻿''' <summary>
''' 输入法后台服务交互模块
''' </summary>
Module MServer

    Private server As Object = Nothing

    Friend Function JsScriptSearch(ByVal codes As String) As String
        Return GetDdpyServer().SrvSearchWords("淡定" & codes, True)
    End Function

    ''' <summary>
    ''' 指定拼音编码查找候选文字
    ''' </summary>
    ''' <param name="codes">拼音编码</param>
    ''' <param name="isScriptMode">是否脚本模式</param>
    ''' <returns>候选文字列表</returns>
    Friend Function SrvSearchWords(ByVal codes As String, Optional ByVal isScriptMode As Boolean = False) As List(Of CWord)

        DebugTimeStart()

        Dim lst As New List(Of CWord)
        Dim txt As String = GetDdpyServer().SrvSearchWords(codes, isScriptMode)
        If txt = "" Then
            Return lst
        End If

        Dim lines As String() = txt.Split(vbLf)
        If P_I_MODE AndAlso isScriptMode Then
            If lines(0).IndexOf(vbTab) < 0 Then
                ' Tip Only
                ddPy.Tip = lines(0)

                ddPy.ScriptModeTitle = lines(lines.Length - 2)
                ddPy.HasDigitComp = CBool(lines(lines.Length - 1))
                Return lst
            End If
        Else
            ddPy.HasDigitComp = False
        End If

        ddPy.Tip = ""

        For i As Integer = 0 To lines.Length - 1

            If P_I_MODE AndAlso isScriptMode Then
                If lines(i).IndexOf(vbTab) < 0 Then

                    If i = lines.Length - 2 Then
                        ddPy.ScriptModeTitle = lines(i)
                    ElseIf i = lines.Length - 1 Then
                        ddPy.HasDigitComp = CBool(lines(i))
                    End If
                Else
                    lst.Add(New CWord(lines(i)))
                End If
            Else
                lst.Add(New CWord(lines(i)))
            End If

        Next

        ComDebug("SrvGetWordList( " & codes & ", " & isScriptMode & " ) : " & lst.Count)
        ComDebug("SrvGetWordList time: " & DebugTimeEnd())
        Return lst
    End Function

    Friend Function SrvSearchMixWords(ByVal codes As String) As List(Of CWord)
        Dim lst As New List(Of CWord)
        Dim txt As String = GetDdpyServer().SrvSearchMixWords(codes)
        If txt = "" Then
            Return lst
        End If

        Dim lines As String() = txt.Split(vbLf)
        For i As Integer = 0 To lines.Length - 1
            lst.Add(New CWord(lines(i)))
        Next

        Return lst
    End Function

    Friend Function SrvAddMixInputData(ByVal codes As String) As Boolean
        Return GetDdpyServer().SrvAddMixInputData(codes)
    End Function

    Friend Sub SrvDeleteMixInputData(ByVal codes As String)
        GetDdpyServer().SrvDeleteMixInputData(codes)
    End Sub

    Friend Function SrvIsMixInput(ByVal leftPy As String, ByVal rightPy As String, Optional ByVal sChar As String = "") As Boolean
        Return GetDdpyServer().SrvIsMixInput(leftPy, rightPy, sChar)
    End Function

    ''' <summary>
    ''' 登记用户输入的文字（vbTab分割的拼音 + vbLf + vbTab分割的文字）
    ''' </summary>
    ''' <param name="words">用户输入的文字（vbTab分割的拼音 + vbLf + vbTab分割的文字）</param>
    Friend Sub SrvRegisterWords(ByVal words As String)
        GetDdpyServer().SrvRegisterWords(words)
    End Sub

    ''' <summary>
    ''' 从用户词库中删除指定字词
    ''' </summary>
    ''' <param name="pinYin">拼音全拼</param>
    ''' <param name="text">指定字词</param>
    Friend Sub SrvUnRegisterUserWord(ByVal pinYin As String, ByVal text As String)
        GetDdpyServer().SrvUnRegisterUserWord(pinYin, text)
    End Sub

    ''' <summary>
    ''' 从后台服务取得配置信息：可输入的拼音编码最大长度
    ''' </summary>
    ''' <returns>可输入的拼音编码最大长度</returns>
    Friend Function SrvGetMaxPyLen() As Integer
        Return GetDdpyServer().SrvGetMaxPyLen()
    End Function

    ''' <summary>
    ''' 从后台服务取得配置信息：候选文字最大个数
    ''' </summary>
    ''' <returns>候选文字最大个数</returns>
    Friend Function SrvGetMaxPageCnt() As Integer
        Return GetDdpyServer().SrvGetMaxPageCnt()
    End Function

    ''' <summary>
    ''' 从后台服务取得配置信息：是否垂直显示
    ''' </summary>
    ''' <returns>是否垂直显示</returns>
    Friend Function SrvGetVshow() As Boolean
        Return GetDdpyServer().SrvGetVshow()
    End Function

    ''' <summary>
    ''' 取得用户Log目录
    ''' </summary>
    ''' <returns>用户Log目录</returns>
    Friend Function GetAllUsersLogPath() As String
            Return GetDdpyServer().SrvGetAllUsersLogPath()
    End Function

    Friend Function SvrGetDdpyCfgExePath() As String
        Return GetDdpyServer().SvrGetDdpyCfgExePath()
    End Function

    Friend Function SvrGetCurrentUserDataPath() As String
        Return GetDdpyServer().SvrGetCurrentUserDataPath()
    End Function


    ''' <summary>
    ''' 取得后台服务对象
    ''' </summary>
    ''' <returns>后台服务对象</returns>
    Private Function GetDdpyServer() As Object

        If True Then
            ' 看看慢不慢
            Return CreateObject("DdpySrv.ComClass")
        End If

        Try
            If server Is Nothing Then
                server = CreateObject("DdpySrv.ComClass")
            End If
        Catch ex As Exception
            ComDebug(ex)
        End Try

        Return server
    End Function

End Module
