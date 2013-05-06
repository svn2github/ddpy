Imports System.Security.Permissions
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Drawing
Imports System.Text

''' <summary>
''' 输入法编码候选框窗口
''' </summary>
Friend Class FrmImeInput

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

    End Sub

    ''' <summary>
    ''' 指定候选文字显示窗口
    ''' </summary>
    Public Overloads Sub Show(ByVal data As CDandingPy)

        If ddPy.Text = "" Then
            LblPinyin.Text = ddPy.InputPys
        Else
            LblPinyin.Text = ddPy.Text
        End If
        LblPinyin2.Text = ddPy.DispPyText2
        If ddPy.WordList Is Nothing OrElse ddPy.WordList.Count = 0 Then
            ClearCands()
            LblInfo.Text = IIf(P_TITLE = "", "   " & "0", P_TITLE)

            ' 显示并调整窗口位置
            Me.Show()
            Return
        End If
        LblInfo.Text = IIf(P_TITLE = "", "   " & ddPy.WordList.Count & "(" & ddPy.CurrentPage & "/" & ddPy.TotalPageCnt & ")", P_TITLE)
        ComDebug("共 " & ddPy.TotalPageCnt & " 页，当前显示第 " & ddPy.CurrentPage & " 页")


        Dim iStart As Integer = ddPy.CurrentPage * P_MAX_PAGE_CNT - P_MAX_PAGE_CNT
        For i As Integer = 0 To 8

            If i < P_MAX_PAGE_CNT AndAlso ddPy.WordList.Count >= iStart + i + 1 Then
                If ddPy.WordList(iStart + i).IsMixWord Then
                    GetCandidate(i).Text = ddPy.WordList(iStart + i).Text & " "
                Else
                    GetCandidate(i).Text = (i + 1) & "." & ddPy.WordList(iStart + i).Text
                End If
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

    ''' <summary>
    ''' 显示并调整窗口位置
    ''' </summary>
    Public Overloads Sub Show()
        ShowWindow(Me.Handle, SW_SHOWNOACTIVATE)
        ChangeLocation()
        NotifyImeOpenCandidate()
    End Sub

    ''' <summary>
    ''' 隐藏窗口
    ''' </summary>
    Public Overloads Sub Hide()
        ContextMenuStripCand.Hide()
        ddPy.Clear()
        NotifyImeCloseCandidate()
        MyBase.Hide()
    End Sub

    ''' <summary>
    ''' 调整候选文字及窗口位置
    ''' </summary>
    Private Sub ChangeLocation()

        Dim bTmpVShow As Boolean = False
        If Not ddPy.WordList Is Nothing AndAlso ddPy.WordList.Count > 5 AndAlso ddPy.WordList(0).IsMixWord Then
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
        Dim x As Integer = PosX
        Dim y As Integer = PosY + PosH + 2
        If Screen.PrimaryScreen.Bounds.Width - PosX - Me.Width < 0 Then
            If Screen.PrimaryScreen.Bounds.Width - Me.Width < 0 Then
                x = 0
            Else
                x = Screen.PrimaryScreen.Bounds.Width - Me.Width
            End If
        End If
        If Screen.PrimaryScreen.Bounds.Height - PosY - PosH - 2 - Me.Height < 0 Then
            y = PosY - Me.Height - 2
        End If

        Me.Location = New Point(x, y)

    End Sub

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

#Region "窗口拖动处理"

    Private oPoint As Point
    Private oLoc As Point

    Private Sub CandTxt_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt1.MouseClick, txt2.MouseClick, txt3.MouseClick, txt4.MouseClick, txt5.MouseClick, txt6.MouseClick, txt7.MouseClick, txt8.MouseClick, txt9.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' 左击候选文字直接上屏
            SendKeys.SendWait(sender.Tag + 1)
        Else
            ' 右击候选文字弹出菜单
            Dim idx As Integer = (ddPy.CurrentPage - 1) * P_MAX_PAGE_CNT + sender.Tag
            Dim word As CWord = ddPy.WordList(idx)

            If word.WordType = WordType.USR OrElse word.IsMixWord Then
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