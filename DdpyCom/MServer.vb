''' <summary>
''' 输入法后台服务交互模块
''' </summary>
Module MServer

    Private server As Object = Nothing

    ''' <summary>
    ''' 指定拼音编码查找候选文字
    ''' </summary>
    ''' <param name="codes">拼音编码</param>
    ''' <returns>候选文字列表</returns>
    Public Function SrvSearchWords(ByVal codes As String) As List(Of CWord)

        DebugTimeStart()

        Dim lst As New List(Of CWord)
        Dim txt As String = GetDdpyServer().SrvSearchWords(codes)
        If txt = "" Then
            Return lst
        End If

        Dim lines As String() = txt.Split(vbLf)
        For i As Integer = 0 To lines.Length - 1
            lst.Add(New CWord(lines(i)))
        Next


        ComDebug("SrvGetWordList( " & codes & " ) : " & lst.Count)
        ComDebug("SrvGetWordList time: " & DebugTimeEnd())
        Return lst
    End Function

    ''' <summary>
    ''' 登记用户输入的文字（vbTab分割的拼音 + vbLf + vbTab分割的文字）
    ''' </summary>
    ''' <param name="words">用户输入的文字（vbTab分割的拼音 + vbLf + vbTab分割的文字）</param>
    Public Sub SrvRegisterWords(ByVal words As String)
        GetDdpyServer().SrvRegisterWords(words)
    End Sub

    ''' <summary>
    ''' 从用户词库中删除指定字词
    ''' </summary>
    ''' <param name="pinYin">拼音全拼</param>
    ''' <param name="text">指定字词</param>
    Public Sub SrvUnRegisterUserWord(ByVal pinYin As String, ByVal text As String)
        GetDdpyServer().SrvUnRegisterUserWord(pinYin, text)
    End Sub

    ''' <summary>
    ''' 从后台服务取得配置信息：可输入的拼音编码最大长度
    ''' </summary>
    ''' <returns>可输入的拼音编码最大长度</returns>
    Public Function SrvGetMaxPyLen() As Integer
        Return GetDdpyServer().SrvGetMaxPyLen()
    End Function

    ''' <summary>
    ''' 从后台服务取得配置信息：候选文字最大个数
    ''' </summary>
    ''' <returns>候选文字最大个数</returns>
    Public Function SrvGetMaxPageCnt() As Integer
        Return GetDdpyServer().SrvGetMaxPageCnt()
    End Function

    ''' <summary>
    ''' 从后台服务取得配置信息：是否垂直显示
    ''' </summary>
    ''' <returns>是否垂直显示</returns>
    Public Function SrvGetVshow() As Boolean
        Return GetDdpyServer().SrvGetVshow()
    End Function

    ''' <summary>
    ''' 取得用户Log目录
    ''' </summary>
    ''' <returns>用户Log目录</returns>
    Public Function GetAllUsersLogPath() As String
        Try
            Return GetDdpyServer().SrvGetAllUsersLogPath()
        Catch ex As Exception
            Dim sPath As String = "C:\\Documents and Settings\\All Users\\Application Data\\DanDing\\Log"
            If Not My.Computer.FileSystem.DirectoryExists(sPath) Then
                My.Computer.FileSystem.CreateDirectory(sPath)
            End If
            Return sPath
        End Try
    End Function

    Public Function SvrGetDdpyCfgExePath() As String
        Return GetDdpyServer().SvrGetDdpyCfgExePath()
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
