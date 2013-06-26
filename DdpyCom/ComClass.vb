Imports System.Windows.Forms
Imports System.Text

''' <summary>
''' IME按键处理结果信息的结构体，方便IME-COM交互
''' </summary>
Public Structure ImeKeyResult
    Dim IsProcessKey As Boolean     ' 是否处理按键
    Dim IsInputStart As Boolean     ' 输入是否已开始
    Dim IsInputEnd As Boolean       ' 输入是否已结束
    Dim PosX As Integer             ' 输入焦点的X坐标
    Dim PosY As Integer             ' 输入焦点的Y坐标
    Dim PosH As Integer             ' 输入焦点的字体高
End Structure


''' <summary>
''' 淡定拼音输入法的COM类
''' </summary>
<ComClass(ComClass.ClassId, ComClass.InterfaceId, ComClass.EventsId)> _
Public Class ComClass

#Region "COM GUID"
    ' 这些 GUID 提供此类的 COM 标识 
    ' 及其 COM 接口。若更改它们，则现有的
    ' 客户端将不再能访问此类。
    Public Const ClassId As String = "816f190b-c86b-4dc3-b03a-8477e8020116"
    Public Const InterfaceId As String = "26d086b1-9454-484e-9ed0-7c95e98f236c"
    Public Const EventsId As String = "4ac737ff-8a77-4df2-be9d-260854582044"
#End Region

    ' 可创建的 COM 类必须具有一个不带参数的 Public Sub New() 
    ' 否则， 将不会在 
    ' COM 注册表中注册此类，且无法通过
    ' CreateObject 创建此类。
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub Init(ByRef isWuNaiApp As Boolean)
        ' DebugTimeStart()

        initStartTime = Now.Ticks
        isWuNaiApp = IsNeedSendStartEndMsg(Process.GetCurrentProcess().ProcessName)
        UpdateSettingInfo()

        ' ComInfo("初始化时间：" & DebugTimeEnd())
    End Sub

    Public Sub Debug(ByVal str As String)
        ComDebug(str)
    End Sub

    ''' <summary>
    ''' 处理输入法打开状态时的按键输入
    ''' </summary>
    ''' <param name="iKey">按键</param>
    ''' <param name="ikr">IME按键处理结果</param>
    ''' <param name="sResult">转换结果文字</param>
    Public Sub ImeProcessKey(ByVal iKey As UInteger, ByRef ikr As ImeKeyResult, ByRef sResult As String)
        Try
            DebugTimeStart()

            If ddPy.InputPys.Length = 0 AndAlso ddPy.DispPyText2.Length = 0 Then
                UpdateSettingInfo()
            End If

            PosX = ikr.PosX
            PosY = ikr.PosY
            PosH = ikr.PosH

            ComProcessKey(iKey, ikr)

            If ikr.IsProcessKey Then

                If ikr.IsInputStart Then

                    If ikr.IsInputEnd Then

                        If P_MODE_FULL Then
                            sResult = ddPy.DispWordText & StrConv(ddPy.DispPyText & ddPy.DispPyText2, VbStrConv.Wide) & ddPy.TextEndChar
                        Else
                            sResult = ddPy.Text & ddPy.DispPyText2 & ddPy.TextEndChar
                        End If

                        If Not SrvAddMixInputData(ddPy.InputPys.Replace(" ", "") & ddPy.DispPyText2) Then

                            If P_AUTO_CREATE_WORD Then
                                SrvRegisterWords(ddPy.InputWord)
                            End If

                        End If


                        frmInput.Hide()
                    Else
                        If ddPy.HasChange Then
                            frmInput.Show(ddPy)
                        End If

                        ComDebug("处理中 bProcessKey=" & ikr.IsProcessKey)
                    End If
                Else
                    ' Back the only char
                    If ddPy.InputPys.Length = 0 AndAlso ddPy.DispPyText2.Length = 0 Then
                        frmInput.Hide()
                    End If
                End If

            Else
                ComDebug("不处理的按键：" & iKey)
            End If



        Catch ex As Exception
            ComDebug(ex)
            frmInput.Hide()
        Finally
            '  sResult = "一二三四五六七八九十壹贰叁肆伍六柒捌玖拾①②③④⑤⑥⑦⑧⑨⑩ⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩ"
            ComDebug("COM执行时间：" & DebugTimeEnd() & " 毫秒")
        End Try

    End Sub


    Public Sub ImeSetActiveContext(ByVal bSetActive As Boolean)

        Try
            ComDebug("[COM]ImeSetActiveContext(" & bSetActive & ")")

            If bSetActive Then

                UpdateSettingInfo()

                ' 显示状态栏窗口
                If Not P_HIDE_STATUS Then
                    If My.Computer.Keyboard.CapsLock Then
                        frmStatus.PanLng.BackgroundImage = My.Resources.LngA
                    End If
                    frmStatus.Show()
                End If

                ' 焦点控件不是按钮的话才显示候选窗口
                If Not frmInput.Visible AndAlso ddPy.HasInput() Then
                    If Not "Button".Equals(GetClassNameByHwnd(GetFocus()), StringComparison.OrdinalIgnoreCase) Then
                        frmInput.Show()
                    End If
                End If

            Else
                If "devenv".Equals(Process.GetCurrentProcess().ProcessName) Then
                    frmInput.Hide()             ' XP下Vs2010刚得到焦点时调用GetClassNameByHwnd会异常退出，这里清除数据个别应付
                Else
                    frmInput.Visible = False    ' 关闭候选窗口但不清除ddpy数据，以便激活时显示原有候选窗口
                    HideInfoForm(True)
                End If
                frmStatus.Hide()
            End If

        Catch ex As Exception
            ComDebug(ex)
        End Try
    End Sub

    Public Sub ImeSelect(ByVal bSelect As Boolean)

        ComDebug("[COM]ImeSelect(" & bSelect & ")")

        If bSelect Then

            initStartTime = Now.Ticks

            P_LNG_CN = True
            P_MODE_FULL = False
            P_BD_FULL = True

            ' 显示状态栏窗口
            If Not P_HIDE_STATUS Then

                frmStatus.PanLng.BackgroundImage = My.Resources.LngCnN
                frmStatus.PanMode.BackgroundImage = My.Resources.MdHalfN
                frmStatus.PanBd.BackgroundImage = My.Resources.BdFullN

                If My.Computer.Keyboard.CapsLock Then
                    frmStatus.PanLng.BackgroundImage = My.Resources.LngA
                End If
                frmStatus.Show()
            End If

            '  ComInfo("此应用程序打开输入法：" & Process.GetCurrentProcess().ProcessName)
        Else
            'frmInput.Hide()
            frmInput.Close()
            frmInput = New FrmImeInput

            If Not frmDebug Is Nothing Then
                frmDebug.Hide()
            End If

            'frmStatus.Hide()
            frmStatus.Close()
            frmStatus = New FrmImeStatus

            GC.Collect()
        End If

        isLeftQte = True
        ReduceMemory()
    End Sub


    Public Sub ImeConfigure()
        OpenSettingDlg()
    End Sub


End Class


