Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Text

''' <summary>
''' 淡定拼音输入法后台服务COM类
''' </summary>
''' <remarks></remarks>
<ComClass(ComClass.ClassId, ComClass.InterfaceId, ComClass.EventsId), ComVisible(True)> _
Public Class ComClass
    Inherits ZReferenceCountedObject

#Region "COM GUID"
    ' 这些 GUID 提供此类的 COM 标识 
    ' 及其 COM 接口。若更改它们，则现有的
    ' 客户端将不再能访问此类。
    Public Const ClassId As String = "860008b0-899b-4543-96a1-27c3e724d3a7"
    Public Const InterfaceId As String = "46e9bb7a-fb2b-45e3-9f7f-a577384b7ec6"
    Public Const EventsId As String = "27324e45-5553-4d6e-b7a9-b18446b18f68"


    <ComRegisterFunction(), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shared Sub Register(ByVal t As Type)
        Try
            ZComHelper.RegasmRegisterLocalServer(t)
        Catch ex As Exception
            Console.WriteLine(ex.Message) ' Log the error
            Throw ex ' Re-throw the exception
        End Try
    End Sub

    <EditorBrowsable(EditorBrowsableState.Never), ComUnregisterFunction()> _
    Public Shared Sub Unregister(ByVal t As Type)
        Try
            ZComHelper.RegasmUnregisterLocalServer(t)
        Catch ex As Exception
            Console.WriteLine(ex.Message) ' Log the error
            Throw ex ' Re-throw the exception
        End Try
    End Sub

#End Region

    ''' <summary>
    ''' 初始化
    ''' </summary>
    Public Sub New()
        MyBase.New()

        bDataLoaded = False

        InitDdpyFiles()
        InitMixInputFile()

        Dim trd As New Threading.Thread(AddressOf LoadData)
        trd.Start()

    End Sub

    Private Sub LoadData()
        Try
            ' 初始化字库词库
            ImportDanDingFile()
        Catch ex As Exception
            ComError("LoadData()", ex)
        End Try

        bDataLoaded = True
    End Sub

    Public Function SrvGetHttpResponse(ByVal url As String, Optional ByVal charset As String = "gb2312") As String
        Return GetHttpResponse(url, charset)
    End Function

    ''' <summary>
    ''' 取得输入法配置信息
    ''' </summary>
    ''' <returns>输入法配置信息</returns>
    Public Function SrvGetSettingInfo() As String
        Return GetSettingInfo()
    End Function

    ''' <summary>
    ''' 设定输入法配置
    ''' </summary>
    ''' <param name="conf">输入法配置信息</param>
    Public Sub SrvSetSettingInfo(ByVal conf As String)
        Try
            SetSettingInfo(conf)

            ' 清除缓存以便设定马上生效
            CacheCollect(True)

        Catch ex As Exception
            ComError("SetSettingInfo(" & conf & ")", ex)
        End Try

    End Sub

    ''' <summary>
    ''' 登记用户输入的文字（vbTab分割的拼音 + vbLf + vbTab分割的文字）
    ''' </summary>
    ''' <param name="words">用户输入的文字（vbTab分割的拼音 + vbLf + vbTab分割的文字）</param>
    Public Sub SrvRegisterWords(ByVal words As String)
        Try
            RegisterWords(words)

            CacheCollect(True)   ' 清除缓存以便新词生效
        Catch ex As Exception
            ComError("SrvRegisterWord(" & words & ")", ex)
        End Try
    End Sub



    ''' <summary>
    ''' 从用户词库中删除指定字词
    ''' </summary>
    ''' <param name="pinYin">拼音全拼</param>
    ''' <param name="text">指定字词</param>
    Public Sub SrvUnRegisterUserWord(ByVal pinYin As String, ByVal text As String)
        UnRegisterUserWord(pinYin, text)
        DeleteWordFromDic(pinYin, text)

        ' 免分隔符的拼音处理（尽力删除相同词条）
        Dim difPinyin As String = BreakPys(pinYin.Replace("'", ""))
        If Not difPinyin.Equals(pinYin) AndAlso difPinyin.IndexOf(" ") < 0 Then
            UnRegisterUserWord(difPinyin, text)
            DeleteWordFromDic(difPinyin, text)
        End If

        CacheCollect(True)   ' 清除缓存以便旧词失效
    End Sub

    Public Function SrvSearchMixWords(ByVal codes As String) As String
        Dim lst As List(Of CWord) = SearchMixWords(codes)

        Dim buf As New StringBuilder
        For i As Integer = 0 To lst.Count - 1
            If i = 0 Then
                buf.Append(lst(i).ToString)
            Else
                buf.Append(vbLf & lst(i).ToString)
            End If
        Next

        Return buf.ToString

    End Function

    Public Function SrvAddMixInputData(ByVal codes As String) As Boolean
        Dim bMix As Boolean = IsMixInput(codes, "")

        If bMix Then
            AddMixInputData(codes)
        End If

        Return bMix
    End Function

    Public Sub SrvDeleteMixInputData(ByVal codes As String)
        DeleteMixInputData(codes)
    End Sub

    Public Function SrvIsMixInput(ByVal leftPy As String, ByVal rightPy As String, Optional ByVal sChar As String = "") As Boolean
        Return IsMixInput(leftPy, rightPy, sChar)
    End Function

    ''' <summary>
    ''' 指定拼音编码查找候选文字
    ''' </summary>
    ''' <param name="codes">拼音编码</param>
    ''' <param name="isScriptMode">是否脚本模式</param>
    ''' <returns>候选文字列表</returns>
    Public Function SrvSearchWords(ByVal codes As String, Optional ByVal isScriptMode As Boolean = False) As String
        Try
            If P_I_MODE AndAlso isScriptMode Then
                Return GetScriptWordList(codes)
            Else
                Return GetWordList(codes)
            End If
        Catch ex As Exception
            ComError("SrvSearchWords(" & codes & ")", ex)
            Return ""
        End Try
    End Function


    ''' <summary>
    ''' 关闭
    ''' </summary>
    Public Sub Close()

        CComSrvClassFactory.comSrv = Nothing
        While ZExeCOMServer.Instance().Unlock() > 0
            ZExeCOMServer.Instance().Unlock()
        End While

    End Sub

    ''' <summary>
    ''' 取得用户Log目录
    ''' </summary>
    ''' <returns>用户Log目录</returns>
    Public Function SrvGetAllUsersLogPath() As String
        Return GetDdpyLogPath()
    End Function


    Public Function SvrGetDdpyCfgExePath() As String
        Return GetDdpyConfigExeFile()
    End Function

    Public Function SvrGetCurrentUserDataPath() As String
        Return GetDdpyUserDataPath()
    End Function

    Public Function SvrMsgBox(ByVal msg As String) As Integer
        Return MsgBox(msg, MsgBoxStyle.Information, "")
    End Function

End Class

