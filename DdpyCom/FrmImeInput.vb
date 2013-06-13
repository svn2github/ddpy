Imports System.Security.Permissions
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Drawing
Imports System.Text

''' <summary>
''' 输入法编码候选框窗口
''' </summary>
Friend Class FrmImeInput

    Private defaultPosX As Integer

    ''' <summary>
    ''' 窗口初始化
    ''' </summary>
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 设定控件背景颜色
        Dim bgColor As Color = Color.FromArgb(245, 245, 245)
        Me.BackColor = bgColor
        PanelFill.BackColor = bgColor
        PanelPinyin.BackColor = bgColor
        PanelPosition.BackColor = bgColor
        LblPinyin.BackColor = bgColor
        LblPinyin2.BackColor = bgColor
        LblInfo.BackColor = bgColor
        txt1.BackColor = bgColor
        txt2.BackColor = bgColor
        txt3.BackColor = bgColor
        txt4.BackColor = bgColor
        txt5.BackColor = bgColor
        txt6.BackColor = bgColor
        txt7.BackColor = bgColor
        txt8.BackColor = bgColor
        txt9.BackColor = bgColor

        txt1.Font = fontCand
        txt2.Font = fontCand
        txt3.Font = fontCand
        txt4.Font = fontCand
        txt5.Font = fontCand
        txt6.Font = fontCand
        txt7.Font = fontCand
        txt8.Font = fontCand
        txt9.Font = fontCand

        Dim x As Integer = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Dim y As Integer = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) * 0.6
        defaultPosX = x
        Me.Location = New System.Drawing.Point(x, y)

    End Sub


    ''' <summary>
    ''' 指定候选文字显示窗口
    ''' </summary>
    Public Overloads Sub Show(ByVal data As CDandingPy)

        If ddPy.Text.Length = 0 AndAlso ddPy.InputPys.Length = 0 AndAlso ddPy.DispPyText2.Length = 0 Then
            Me.Hide()
            Return
        End If

        If ddPy.DefaultKeyChar.Length > 0 AndAlso ddPy.InputPys.Length = 1 AndAlso ddPy.DispPyText2.Length = 0 Then
            Me.Location = IIf(P_AUTO_POSITION, GetAutoPos(), GetDefaultPos())
        End If

        If P_I_MODE AndAlso ddPy.Text = "" Then
            LblPinyin.Text = ddPy.InputPys
        Else
            LblPinyin.Text = ddPy.Text
        End If
        LblPinyin2.Text = ddPy.DispPyText2

        If P_I_MODE AndAlso ddPy.Tip.Length > 0 Then
            txt1.Text = ddPy.Tip
            txt1.ForeColor = Color.White
            txt1.BackColor = Color.FromArgb(64, 130, 240)
            txt1.Visible = True

            LblInfo.Text = IIf(ddPy.ScriptModeTitle = "", "淡定" & ChrW(8220) & "i" & ChrW(8221) & "模式", ddPy.ScriptModeTitle)

            For i As Integer = 1 To 8
                GetCandidate(i).Visible = False
            Next

            ' 显示并调整窗口位置
            Me.Show()
            Return
        End If

        If ddPy.WordList Is Nothing OrElse ddPy.WordList.Count = 0 Then
            ClearCands()
            LblInfo.Text = IIf(P_TITLE = "", "   " & "0", P_TITLE)

            ' 显示并调整窗口位置
            Me.Show()
            Return
        End If

        If P_I_MODE AndAlso ddPy.InputPys.StartsWith("i") Then
            LblInfo.Text = IIf(ddPy.ScriptModeTitle = "", "淡定" & ChrW(8220) & "i" & ChrW(8221) & "模式", ddPy.ScriptModeTitle)
        Else
            LblInfo.Text = IIf(P_TITLE = "", "   " & ddPy.WordList.Count & "(" & ddPy.CurrentPage & "/" & ddPy.TotalPageCnt & ")", P_TITLE)
        End If

        ComDebug("共 " & ddPy.TotalPageCnt & " 页，当前显示第 " & ddPy.CurrentPage & " 页")


        Dim iStart As Integer = ddPy.CurrentPage * P_MAX_PAGE_CNT - P_MAX_PAGE_CNT
        For i As Integer = 0 To 8

            If i < P_MAX_PAGE_CNT AndAlso ddPy.WordList.Count >= iStart + i + 1 Then

                GetCandidate(i).Text = GetLableText(ddPy.WordList(iStart + i), i + 1)

                GetCandidate(i).Visible = True
            Else
                GetCandidate(i).Visible = False
            End If
            GetCandidate(i).ForeColor = Color.Black
            GetCandidate(i).BackColor = Me.BackColor

        Next

        GetCandidate(ddPy.FocusCand - 1).ForeColor = Color.White
        GetCandidate(ddPy.FocusCand - 1).BackColor = Color.FromArgb(64, 130, 240)


        ' 显示并调整窗口位置
        Me.Show()

    End Sub

    Private Function GetLableText(ByVal word As CWord, ByVal idx As Integer) As String

        word.Text = word.Text.Replace("<br>", vbNewLine)
        Dim sTxt As String = word.Text
        If word.DispText IsNot Nothing AndAlso word.DispText.Length > 0 Then
            sTxt = word.DispText.Replace("<br>", vbNewLine)
        End If

        If word.IsMixWord Then
            Return sTxt & " "
        End If

        If ddPy.InputPys.StartsWith("i") AndAlso word.PinYin.Length > 0 Then
            If word.ShowDigit Then
                Return idx & ".[" & word.PinYin & "]" & sTxt
            Else
                Return word.PinYin & "." & sTxt
            End If
        End If

        If word.ShowDigit Then
            Return idx & "." & sTxt
        Else
            Return sTxt
        End If

    End Function


    ''' <summary>
    ''' 显示并调整窗口位置
    ''' </summary>
    Public Overloads Sub Show()

        If Not Me.Visible Then
            txt1.Font = fontCand
            txt2.Font = fontCand
            txt3.Font = fontCand
            txt4.Font = fontCand
            txt5.Font = fontCand
            txt6.Font = fontCand
            txt7.Font = fontCand
            txt8.Font = fontCand
            txt9.Font = fontCand
        End If

        ShowWindow(Me.Handle, SW_SHOWNOACTIVATE)
        ChangeLocation()

        NotifyImeOpenCandidate()

        If Not My.Computer.Keyboard.CtrlKeyDown AndAlso _
            (Not P_SHOW_INFO OrElse (P_I_MODE AndAlso ddPy.InputPys.StartsWith("i"))) Then
            HideInfoForm()
        Else
            ShowInfoForm()
        End If
    End Sub

    ''' <summary>
    ''' 隐藏窗口
    ''' </summary>
    Public Overloads Sub Hide()

        ContextMenuStripCand.Hide()
        ddPy.Clear()
        NotifyImeCloseCandidate()

        LblPinyin.Text = ""
        LblPinyin2.Text = ""
        ClearCands()
        LblInfo.Text = IIf(P_TITLE = "", "   " & "0", P_TITLE)

        MyBase.Hide()

        If Not P_AUTO_POSITION Then
            Me.Location = New System.Drawing.Point(defaultPosX, Me.Location.Y)
        End If

        Me.Width = 420

        HideInfoForm()
    End Sub

    ''' <summary>
    ''' 调整候选文字及窗口位置
    ''' </summary>
    Private Sub ChangeLocation()

        Dim bTmpVShow As Boolean = False
        Dim iWidth As Integer = 0
        For i As Integer = 0 To 8
            If GetCandidate(i).Visible Then
                iWidth = iWidth + GetCandidate(i).Width
            End If
        Next
        If iWidth > Screen.PrimaryScreen.Bounds.Width * 0.8 Then
            bTmpVShow = True
        End If

        ' 调整候选文字位置
        If bTmpVShow OrElse P_V_SHOW Then

            ' 竖直显示
            If txt2.Visible Then
                txt2.Location = New Point(txt1.Location.X, txt1.Location.Y + txt1.Height)
            End If
            If txt3.Visible Then
                txt3.Location = New Point(txt1.Location.X, txt2.Location.Y + txt2.Height)
            End If
            If txt4.Visible Then
                txt4.Location = New Point(txt1.Location.X, txt3.Location.Y + txt3.Height)
            End If
            If txt5.Visible Then
                txt5.Location = New Point(txt1.Location.X, txt4.Location.Y + txt4.Height)
            End If
            If txt6.Visible Then
                txt6.Location = New Point(txt1.Location.X, txt5.Location.Y + txt5.Height)
            End If
            If txt7.Visible Then
                txt7.Location = New Point(txt1.Location.X, txt6.Location.Y + txt6.Height)
            End If
            If txt8.Visible Then
                txt8.Location = New Point(txt1.Location.X, txt7.Location.Y + txt7.Height)
            End If
            If txt9.Visible Then
                txt9.Location = New Point(txt1.Location.X, txt8.Location.Y + txt8.Height)
            End If

        Else

            ' 水平显示
            If txt2.Visible Then
                txt2.Location = New Point(txt1.Location.X + txt1.Size.Width, txt1.Location.Y)
            End If
            If txt3.Visible Then
                txt3.Location = New Point(txt2.Location.X + txt2.Size.Width, txt1.Location.Y)
            End If
            If txt4.Visible Then
                txt4.Location = New Point(txt3.Location.X + txt3.Size.Width, txt1.Location.Y)
            End If
            If txt5.Visible Then
                txt5.Location = New Point(txt4.Location.X + txt4.Size.Width, txt1.Location.Y)
            End If
            If txt6.Visible Then
                txt6.Location = New Point(txt5.Location.X + txt5.Size.Width, txt1.Location.Y)
            End If
            If txt7.Visible Then
                txt7.Location = New Point(txt6.Location.X + txt6.Size.Width, txt1.Location.Y)
            End If
            If txt8.Visible Then
                txt8.Location = New Point(txt7.Location.X + txt7.Size.Width, txt1.Location.Y)
            End If
            If txt9.Visible Then
                txt9.Location = New Point(txt8.Location.X + txt8.Size.Width, txt1.Location.Y)
            End If
        End If

        ' 调整光标位置
        If LblPinyin.Text.Length <= 3 Then
            PanCur.Location = New Point(LblPinyin.Width, PanCur.Location.Y)
        Else
            If ddPy.DispPyText.Length > 0 Then
                PanCur.Location = New Point(LblPinyin.Width - (ddPy.DispPyText.Length + 4) \ 5, PanCur.Location.Y)
            Else
                PanCur.Location = New Point(LblPinyin.Width - (ddPy.DispWordText.Length + 1) \ 2, PanCur.Location.Y)
            End If
        End If
        LblPinyin2.Location = New Point(PanCur.Location.X + 1, LblPinyin2.Location.Y)

        ' 调整窗口大小
        PanelPosition.Width = 10
        If Me.Width < LblPinyin.Width + LblInfo.Width Then
            PanelPosition.Width = LblPinyin.Width + LblInfo.Width - PanelPosition.Location.X
        End If


        ' 调整窗口位置
        Me.Location = IIf(P_AUTO_POSITION, GetAutoPos(), GetDefaultPos())

    End Sub

    Private Function GetAutoPos() As Point
        ' 光标跟随
        Dim x As Integer = PosX + 3
        Dim y As Integer = PosY + PosH + 3
        If Screen.PrimaryScreen.WorkingArea.Width - PosX - Me.Width < 0 Then
            If Screen.PrimaryScreen.WorkingArea.Width - Me.Width < 0 Then
                x = 0
            Else
                x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            End If
        End If
        If Screen.PrimaryScreen.WorkingArea.Height - PosY - PosH - 3 - Me.Height < 0 Then
            y = PosY - Me.Height - 3
        End If

        Return New Point(x, y)
    End Function

    Private Function GetDefaultPos() As Point
        Dim x As Integer
        Dim y As Integer = Me.Location.Y
        If Screen.PrimaryScreen.WorkingArea.Width - defaultPosX < Me.Width Then
            x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
        Else
            x = defaultPosX
        End If
        If Screen.PrimaryScreen.WorkingArea.Height - y - Me.Height < 0 Then
            y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        End If

        Return New Point(x, y)
    End Function

    ''' <summary>
    ''' 取得候选Label
    ''' </summary>
    ''' <param name="idx">下标（0～8）</param>
    ''' <returns>候选Label</returns>
    Private Function GetCandidate(ByVal idx As Integer) As Label

        Select Case idx
            Case 0
                Return txt1
            Case 1
                Return txt2
            Case 2
                Return txt3
            Case 3
                Return txt4
            Case 4
                Return txt5
            Case 5
                Return txt6
            Case 6
                Return txt7
            Case 7
                Return txt8
            Case 8
                Return txt9
        End Select

        Return Nothing
    End Function

    ''' <summary>
    ''' 隐藏全部候选Label
    ''' </summary>
    Private Sub ClearCands()
        txt1.Visible = False
        txt2.Visible = False
        txt3.Visible = False
        txt4.Visible = False
        txt5.Visible = False
        txt6.Visible = False
        txt7.Visible = False
        txt8.Visible = False
        txt9.Visible = False
    End Sub


#Region "设定成非活动输入法窗口"

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        <PermissionSetAttribute(SecurityAction.LinkDemand, Name:="FullTrust")>
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_NOACTIVATE Or CS_DBLCLKS Or CS_IME Or CS_VREDRAW Or CS_HREDRAW
            'cp.ExStyle = WS_EX_NOACTIVATE Or CS_VREDRAW Or CS_HREDRAW Or CS_DBLCLKS Or CS_IME Or MA_NOACTIVATE
            'cp.ExStyle = WS_EX_NOACTIVATE Or CS_DBLCLKS Or CS_IME Or CS_VREDRAW Or CS_HREDRAW
            Return cp
        End Get
    End Property

    <PermissionSetAttribute(SecurityAction.LinkDemand, Name:="FullTrust")>
    Protected Overrides Sub WndProc(ByRef m As Message)

        If m.Msg = WM_MOUSEACTIVATE Then
            m.Result = New IntPtr(MA_NOACTIVATE)
        ElseIf (m.Msg = WM_SETFOCUS OrElse m.Msg = WM_ACTIVATE) Then
            m.Result = New IntPtr(WM_NCACTIVATE)
        Else
            MyBase.WndProc(m)
        End If
    End Sub

#End Region

#Region "输入法窗口菜单"

    Private Sub CandTxt_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt1.MouseClick, txt2.MouseClick, txt3.MouseClick, txt4.MouseClick, txt5.MouseClick, txt6.MouseClick, txt7.MouseClick, txt8.MouseClick, txt9.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' 左击候选文字直接上屏
            SendKeys.SendWait(sender.Tag + 1)
        Else
            ' 右击候选文字弹出菜单
            Dim idx As Integer = (ddPy.CurrentPage - 1) * P_MAX_PAGE_CNT + sender.Tag
            Dim word As CWord = ddPy.WordList(idx)

            If (word.WordType And WordType.USR) OrElse word.IsMixWord Then
                menuItemDelCand.Enabled = True
            Else
                menuItemDelCand.Enabled = False
            End If

            ContextMenuStripCand.Location = e.Location
            ContextMenuStripCand.Show(Cursor.Position.X, Cursor.Position.Y)

            If word.IsMixWord Then
                menuItemDelCand.Text = "删除 " & word.Text
            Else
                menuItemDelCand.Text = "从用户词库中删除 " & Strings.Left(GetCandidate(sender.Tag).Text, 7) & IIf(GetCandidate(sender.Tag).Text.Length > 7, "～", "")
            End If
            menuItemDelCand.Tag = sender.Tag
        End If
    End Sub


    Private Sub menuItemDelCand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemDelCand.Click

        Dim idx As Integer = (ddPy.CurrentPage - 1) * P_MAX_PAGE_CNT + menuItemDelCand.Tag
        Dim word As CWord = ddPy.WordList(idx)

        If word.IsMixWord Then
            ' 删除混合输入
            SrvDeleteMixInputData(word.Text)
        Else
            ' 从用户词库删除文字
            SrvUnRegisterUserWord(word.PinYin, word.Text)
        End If

        ' 刷新显示
        ddPy.ExecuteSearch()
        Me.Show(ddPy)
    End Sub

#End Region

    Private Sub FrmImeInput_AutoSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AutoSizeChanged
        ChangeLocation()
    End Sub

#Region "窗口拖动处理"

    Private oPoint As Point
    Private oLoc As Point


    Private Sub FrmImeInput_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, PanelPinyin.MouseDown, PanelFill.MouseDown, LblPinyin.MouseDown, LblInfo.MouseDown  ' , txt1.MouseDown, txt2.MouseDown, txt3.MouseDown, txt4.MouseDown, txt5.MouseDown, txt6.MouseDown, txt7.MouseDown, txt8.MouseDown, txt9.MouseDown
        oPoint = e.Location
        oLoc = Me.Location
    End Sub

    Private Sub FrmImeInput_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, PanelPinyin.MouseUp, PanelFill.MouseUp, LblPinyin.MouseUp, LblInfo.MouseUp ', txt1.MouseUp, txt2.MouseUp, txt3.MouseUp, txt4.MouseUp, txt5.MouseUp, txt6.MouseUp, txt7.MouseUp, txt8.MouseUp, txt9.MouseUp
        Dim nPoint As Point = e.Location
        Dim p As New Point(oLoc.X + (nPoint.X - oPoint.X), oLoc.Y + (nPoint.Y - oPoint.Y))
        Me.Location = p
    End Sub

#End Region



End Class