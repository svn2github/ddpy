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
    End Sub

#Region "窗口拖动处理"

    Private oPoint As System.Drawing.Point
    Private oLoc As System.Drawing.Point

    Private Sub FrmImeInput_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        oPoint = e.Location
        oLoc = Me.Location
    End Sub

    Private Sub FrmImeInput_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Dim nPoint As System.Drawing.Point = e.Location
        Dim p As New System.Drawing.Point(oLoc.X + (nPoint.X - oPoint.X), oLoc.Y + (nPoint.Y - oPoint.Y))
        Me.Location = p
    End Sub

#End Region



    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.Hide()
    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        Dim bgColor As Color = Color.FromArgb(245, 245, 245)
        Me.BackColor = bgColor
        Me.Label1.BackColor = bgColor
        Me.Label2.BackColor = bgColor

    End Sub


End Class