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

        Try
            ' 读写配置文件
            Dim sFileCfg As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\\DanDingConfig.txt"
            If Not My.Computer.FileSystem.FileExists(sFileCfg) Then
                My.Computer.FileSystem.WriteAllText(sFileCfg, GetSettingInfo(), False, Encoding.UTF8)
            Else
                SetSettingInfo(My.Computer.FileSystem.ReadAllText(sFileCfg, Encoding.UTF8))
            End If


            ' 初始化字库词库
            ImportDanDingFile()
            InitMixInputFile()

        Catch ex As Exception
            ComError("New()", ex)
        End Try

    End Sub

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
            ' 清除缓存以便新词生效
            CacheCollect(True)

            Dim lines As String() = words.Split(vbLf)
            Dim pys As String() = lines(0).Split(vbTab)
            Dim txts As String() = lines(1).Split(vbTab)
            For i As Integer = 0 To pys.Length - 1

                Dim sFstChar As String = Strings.Left(txts(i), 1)
                If txts(i).Replace("啊", "").Length = 0 Then
                    ' 无视 啊啊啊啊啊啊啊啊啊
                    Continue For
                End If
                If txts(i).Length > 2 AndAlso txts(i).Replace(sFstChar, "").Length = 0 Then
                    ' 无视2个以上的重复字
                    Continue For
                End If
                If txts(i).Length > 20 Then
                    ' 无视过长文字
                    Continue For
                End If
                Dim shotPy As String = Strings.Join(GetMutilShotPys(pys(i)), "")
                If shotPy.Length > 4 AndAlso shotPy.Replace(Strings.Left(shotPy, 1), "").Length = 0 Then
                    ' 无视4个以上的重复拼音字
                    Continue For
                End If


                Dim newWord As New CWord()
                newWord.Text = txts(i)
                newWord.ShortPinYin = Strings.Join(GetMutilShotPys(pys(i)), "'")
                newWord.PinYin = pys(i)
                newWord.Order = 1
                newWord.WordType = WordType.USR

                Dim lst As List(Of CWord) = SearchWords(newWord.PinYin)

                Dim isExist As Boolean = False
                For Each word As CWord In lst
                    If newWord.Text.Equals(word.Text) Then
                        If word.WordType < WordType.USR Then
                            word.WordType = WordType.USR
                            word.Order = 0
                        End If

                        word.Order = word.Order + 1
                        isExist = True

                        RegisterUserWord(word)
                    End If
                Next

                If Not isExist Then
                    AddWordToDic(newWord)
                    RegisterUserWord(newWord)
                End If

            Next

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
        CacheCollect(True)
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

    Public Sub SrvAddMixInputData(ByVal codes As String)
        AddMixInputData(codes)
    End Sub

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
    ''' <returns>候选文字列表</returns>
    Public Function SrvSearchWords(ByVal codes As String) As String
        Try
            Dim ret As String = ""

            Dim okPys As String = BreakPys(codes).Split(" ")(0)  ' Get Right Py Only
            Dim aryPy As String() = okPys.Split("'")
            Dim arySpy As String() = GetMutilShotPys(okPys)

            Dim stack As New Stack(Of List(Of CWord))
            Dim py As String = ""
            For i As Integer = 0 To aryPy.Length - 1
                If i = 0 Then
                    py = aryPy(i)
                Else
                    py = py & "'" & aryPy(i)
                End If

                Dim tmp As List(Of CWord) = SearchWords(py)
                If tmp.Count > 0 Then
                    stack.Push(tmp)
                End If
            Next


            Dim lst As New List(Of CWord)
            Dim wordRecom As CWord = GetRecommendWord(aryPy)
            If Not wordRecom Is Nothing Then
                lst.Add(wordRecom)
            End If
            Do While stack.Count > 0
                lst.AddRange(stack.Pop())
            Loop

            Dim buf As New StringBuilder
            For i As Integer = 0 To lst.Count - 1
                If i = 0 Then
                    buf.Append(lst(i).ToString)
                Else
                    buf.Append(vbLf & lst(i).ToString)
                End If
            Next

            Return buf.ToString

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
        Return GetAllUsersLogPath()
    End Function


    Public Function SvrGetDdpyCfgExePath() As String
        Dim sPath As String = My.Computer.FileSystem.GetParentPath(Application.ExecutablePath)
        Return sPath & "\DdpyCfg.exe"
    End Function

    Public Function SvrGetCurrentUserDataPath() As String
        Return My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
    End Function

End Class

