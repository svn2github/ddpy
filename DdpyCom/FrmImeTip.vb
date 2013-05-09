Imports System.Security.Permissions
Imports System.Windows.Forms

Public Class FrmImeTip

#Region "设定成非活动输入法窗口"

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        <PermissionSetAttribute(SecurityAction.LinkDemand, Name:="FullTrust")>
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            'cp.ExStyle = cp.ExStyle Or WS_EX_NOACTIVATE Or CS_IME
            cp.ExStyle = WS_EX_NOACTIVATE Or CS_IME
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

#End Region


End Class