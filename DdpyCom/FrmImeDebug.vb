Imports System.Security.Permissions
Imports System.Windows.Forms
Imports System.Drawing

Friend Class FrmImeDebug

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        <PermissionSetAttribute(SecurityAction.LinkDemand, Name:="FullTrust")>
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_NOACTIVATE Or CS_DBLCLKS Or CS_IME
            Return cp
        End Get
    End Property

    <PermissionSetAttribute(SecurityAction.LinkDemand, Name:="FullTrust")>
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = 33 Then              ' 33:WM_MOUSEACTIVATE
            m.Result = New IntPtr(3)    ' 3:MA_NOACTIVATE
        ElseIf (m.Msg = 6 OrElse m.Msg = 7) Then    ' 6:WM_ACTIVATE Or 7:WM_SETFOCUS
            m.Result = New IntPtr(134)              ' 134:WM_NCACTIVATE
        Else
            MyBase.WndProc(m)
        End If
    End Sub



    Private oPoint As Point
    Private oLoc As Point
    Private Sub FrmImeInput_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        oPoint = e.Location
        oLoc = Me.Location
    End Sub

    Private Sub FrmImeStatus_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Dim p As New Point(oLoc.X + (e.Location.X - oPoint.X), oLoc.Y + (e.Location.Y - oPoint.Y))
        Me.Location = p

    End Sub

    Public Overloads Sub Show()
        ShowWindow(Me.Handle, SW_SHOWNOACTIVATE)
    End Sub


    Public Sub Debug(ByVal info As String)

        If TxtInfo.Text.Length > 5000 Then
            My.Computer.FileSystem.WriteAllText("d:\\ime.txt", vbNewLine & vbNewLine & TxtInfo.Text.Substring(2000), True)
            TxtInfo.Text = TxtInfo.Text.Substring(0, 2000)
        End If

        TxtInfo.Text = info & vbNewLine & TxtInfo.Text
        If Me.Visible = False Then
            Show()
        End If
    End Sub

End Class