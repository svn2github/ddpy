Imports System.Security.Permissions
Imports System.Windows.Forms
Imports System.Drawing

Friend Class FrmInformation

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        <PermissionSetAttribute(SecurityAction.LinkDemand, Name:="FullTrust")>
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_NOACTIVATE Or CS_DBLCLKS Or CS_IME Or CS_VREDRAW Or CS_HREDRAW
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


    Public Overloads Sub Show()
        ShowWindow(Me.Handle, SW_SHOWNOACTIVATE)
        ChangeLocation()
    End Sub

    Public Sub ChangeLocation()
        Dim x As Integer = frmInput.Location.X
        Dim y As Integer = frmInput.Location.Y + frmInput.Height

        If Screen.PrimaryScreen.WorkingArea.Width - x - Me.Width < 0 Then
            If Screen.PrimaryScreen.WorkingArea.Width - Me.Width < 0 Then
                x = 0
            Else
                x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            End If
        End If
        If frmInput.Location.Y < PosY OrElse Screen.PrimaryScreen.WorkingArea.Height - y - Me.Height < 0 Then
            If frmInput.Location.Y < PosY Then
                y = frmInput.Location.Y - Me.Height
            Else
                y = frmInput.Location.Y - Me.Height - PosH - 3
            End If
        End If

        Me.Location = New Point(x, y)
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblClose.Click
        Me.Hide()
    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        Dim bgColor As Color = Color.FromArgb(245, 245, 245)
        Me.BackColor = bgColor
        Me.LblText.BackColor = bgColor
        Me.LblClose.BackColor = bgColor
        Me.LblExecText.BackColor = bgColor

        Clear()

    End Sub


    Private Sub LblClose_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblClose.MouseEnter
        LblClose.ForeColor = Color.Blue
    End Sub

    Private Sub LblClose_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblClose.MouseLeave
        LblClose.ForeColor = Color.CornflowerBlue
    End Sub

    Private Sub LblExecText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblExecText.Click
        Try
            System.Diagnostics.Process.Start(LblExecText.Text)
        Catch ex As Exception
            ComDebug(ex)
        End Try
    End Sub

    Public Sub Clear()
        LblText.Text = ""
        LblExecText.Text = ""
    End Sub

    Public Function HasData() As Boolean
        Return LblText.Text.Length > 0 OrElse LblExecText.Text.Length > 0
    End Function

End Class