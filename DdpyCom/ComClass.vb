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

    Private isWuNaiApp As Boolean
    Private frmInput As FrmImeInput
    Private frmStatus As FrmImeStatus

    ' 可创建的 COM 类必须具有一个不带参数的 Public Sub New() 
    ' 否则， 将不会在 
    ' COM 注册表中注册此类，且无法通过
    ' CreateObject 创建此类。
    Public Sub New()
        MyBase.New()

        isWuNaiApp = IsNeedSendStartEndMsg(Process.GetCurrentProcess().ProcessName)

        frmInput = New FrmImeInput
        frmStatus = New FrmImeStatus

    End Sub

    ''' <summary>
    ''' 设定输入法UI窗口句柄
    ''' </summary>
    ''' <param name="hwnd">输入法UI窗口句柄</param>
    Public Sub SetUiHwnd(ByVal hwnd As Integer)
        SetImeUiHwnd(hwnd)
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

            ComProcessKey(iKey, ikr)

            If ikr.IsProcessKey Then

                If ikr.IsInputStart Then

                    If ikr.IsInputEnd Then
                        If P_MODE_FULL Then
                            sResult = ddPy.DispWordText & StrConv(ddPy.DispPyText & ddPy.DispPyText2, VbStrConv.Wide) & ddPy.TextEndChar
                        Else
                            sResult = ddPy.Text & ddPy.DispPyText2 & ddPy.TextEndChar
                        End If

                        SrvRegisterWords(ddPy.InputWord)

                        frmInput.Hide()
                        ddPy.Clear()
                    Else

                        PosX = ikr.PosX
                        PosY = ikr.PosY
                        PosH = ikr.PosH

                        If ddPy.InputPys.Length = 1 Then
                            UpdateSettingInfo()
                            frmInput.Location = New System.Drawing.Point(PosX, PosY + PosH + 2)
                        End If
                        frmInput.Show(ddPy.CreateCCand())

                        ComDebug("处理中 bProcessKey=" & ikr.IsProcessKey)
                    End If
                Else
                    ' Back the only char
                    If ddPy.InputPys.Length = 0 AndAlso ddPy.DispPyText2.Length = 0 Then
                        frmInput.Hide()
                        ddPy.Clear()
                    End If
                End If

            Else
                ' Key: 0 \ [ ] ; ' , . / `
                ComDebug("不处理的按键：" & iKey)
            End If


            '  sResult = "一二三四五六七八九十壹贰叁肆伍六柒捌玖拾①②③④⑤⑥⑦⑧⑨⑩ⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩ"
            ComDebug("COM执行时间：" & DebugTimeEnd() & " 毫秒")

        Catch ex As Exception
            ComDebug(ex)
            frmInput.Hide()
            ddPy.Clear()
        End Try

    End Sub


    Public Sub ImeSetActiveContext(ByVal bSetActive As Boolean)

        Try
            ComDebug("[COM]ImeSetActiveContext(" & bSetActive & ")")

            If Not bSetActive Then
                frmInput.Hide()
                ddPy.Clear()
            End If


            If bSetActive Then
                If My.Computer.Keyboard.CapsLock Then
                    frmStatus.PanLng.BackgroundImage = My.Resources.LngA
                End If
                ShowWindow(frmStatus.Handle, SW_SHOWNOACTIVATE)
            Else
                frmStatus.Hide()
            End If

        Catch ex As Exception
            ComDebug(ex)
        End Try
    End Sub

    Public Sub ImeSelect(ByVal bSelect As Boolean, ByRef isNeedStartEndMsg As Boolean)

        ComDebug("[COM]ImeSelect(" & bSelect & ")")

        If Not bSelect Then
            frmInput.Hide()
            ddPy.Clear()
            If Not frmDebug Is Nothing Then
                frmDebug.Hide()
            End If
        End If

        If bSelect Then
            If My.Computer.Keyboard.CapsLock Then
                frmStatus.PanLng.BackgroundImage = My.Resources.LngA
            End If
            frmStatus.Show()

            ComInfo("此应用程序打开输入法：" & Process.GetCurrentProcess().ProcessName)
        Else
            P_LNG_CN = True
            P_MODE_FULL = False
            P_BD_FULL = True
            frmStatus.PanLng.BackgroundImage = My.Resources.LngCnN
            frmStatus.PanMode.BackgroundImage = My.Resources.MdHalfN
            frmStatus.PanBd.BackgroundImage = My.Resources.BdFullN

            frmStatus.Hide()
        End If


        isNeedStartEndMsg = isWuNaiApp

    End Sub


    Public Sub ImeConfigure()
        OpenSettingDlg()
    End Sub

    ''' <summary>
    ''' 设定输入法状态栏显示
    ''' </summary>
    ''' <param name="idx">下标（1：中/英，2：全角/半角，3：标点）</param>
    ''' <param name="sText">文字</param>
    Public Sub ShowStatusText(ByVal idx As UInt16, ByVal sText As String)

        frmInput.Hide()
        ddPy.Clear()

        If idx = 1 Then

            If My.Computer.Keyboard.CapsLock Then
                frmStatus.PanLng.BackgroundImage = My.Resources.LngA
                Return
            End If

            If "中".Equals(sText) Then
                P_LNG_CN = True
                frmStatus.PanLng.BackgroundImage = My.Resources.LngCnF

                P_BD_FULL = True
                frmStatus.PanBd.BackgroundImage = My.Resources.BdFullF
            Else
                P_LNG_CN = False
                frmStatus.PanLng.BackgroundImage = My.Resources.LngEnF

                P_BD_FULL = False
                frmStatus.PanBd.BackgroundImage = My.Resources.BdHalfF

                frmInput.Hide()
                ddPy.Clear()

            End If

        ElseIf idx = 2 Then
            If "Y".Equals(sText) Then
                P_MODE_FULL = True
                frmStatus.PanMode.BackgroundImage = My.Resources.MdFullF
            Else
                P_MODE_FULL = False
                frmStatus.PanMode.BackgroundImage = My.Resources.MdHalfF
            End If

        ElseIf idx = 3 Then
            If "Y".Equals(sText) Then
                P_BD_FULL = True
                frmStatus.PanBd.BackgroundImage = My.Resources.BdFullF
            Else
                P_BD_FULL = False
                frmStatus.PanBd.BackgroundImage = My.Resources.BdHalfF
            End If
        End If
    End Sub


End Class


