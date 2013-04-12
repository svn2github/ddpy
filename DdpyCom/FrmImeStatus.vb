Imports System.Security.Permissions
Imports System.Windows.Forms
Imports System.Drawing

''' <summary>
''' 输入法状态栏窗口类
''' </summary>
Friend Class FrmImeStatus

    ''' <summary>
    ''' 显示输入法状态栏窗口
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub Show()
        Dim p As New Point(My.Computer.Screen.WorkingArea.Width - Me.Width - 18, My.Computer.Screen.WorkingArea.Height - Me.Height - 3)
        Me.Location = p
        ShowWindow(Me.Handle, SW_SHOWNOACTIVATE)
    End Sub

    ''' <summary>
    ''' 中英切换
    ''' </summary>
    Private Sub PanLng_MouseClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanLng.MouseClick
        Try
            If My.Computer.Keyboard.CapsLock Then
                Return
            End If

            P_LNG_CN = Not P_LNG_CN
            If P_LNG_CN Then
                PanLng.BackgroundImage = My.Resources.LngCnF

                P_BD_FULL = True
                PanBd.BackgroundImage = My.Resources.BdFullF
            Else
                PanLng.BackgroundImage = My.Resources.LngEnF

                P_BD_FULL = False
                PanBd.BackgroundImage = My.Resources.BdHalfF
            End If

            SendUiMessage(1, IIf(P_LNG_CN, 1, 0))

        Catch ex As Exception
            P_LNG_CN = Not P_LNG_CN

            ComDebug(ex)
        End Try

    End Sub

    ''' <summary>
    ''' 全角半角切换
    ''' </summary>
    Private Sub PanMode_MouseClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanMode.MouseClick

        Try
            P_MODE_FULL = Not P_MODE_FULL
            If P_MODE_FULL Then
                PanMode.BackgroundImage = My.Resources.MdFullF
            Else
                PanMode.BackgroundImage = My.Resources.MdHalfF
            End If

            SendUiMessage(2, IIf(P_MODE_FULL, 1, 0))

        Catch ex As Exception
            P_MODE_FULL = Not P_MODE_FULL

            ComDebug(ex)
        End Try

    End Sub

    ''' <summary>
    ''' 标点符号切换
    ''' </summary>
    Private Sub PanBd_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanBd.MouseClick
        Try

            If Not P_LNG_CN Then
                Return
            End If


            P_BD_FULL = Not P_BD_FULL

            If P_BD_FULL Then
                PanBd.BackgroundImage = My.Resources.BdFullF
            Else
                PanBd.BackgroundImage = My.Resources.BdHalfF
            End If

            SendUiMessage(3, IIf(P_BD_FULL, 1, 0))

        Catch ex As Exception
            P_BD_FULL = Not P_BD_FULL

            ComDebug(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 打开设定窗口
    ''' </summary>
    Private Sub PanSetting_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanSetting.MouseClick
        OpenSettingDlg()
    End Sub


#Region "响应鼠标飘过"

    Private Sub PanLng_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanLng.MouseEnter

        If My.Computer.Keyboard.CapsLock Then
            Return
        ElseIf P_LNG_CN Then
            PanLng.BackgroundImage = My.Resources.LngCnN
        Else
            PanLng.BackgroundImage = My.Resources.LngEnN
        End If

    End Sub

    Private Sub PanLng_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanLng.MouseLeave

        If My.Computer.Keyboard.CapsLock Then
            Return
        ElseIf P_LNG_CN Then
            PanLng.BackgroundImage = My.Resources.LngCnF
        Else
            PanLng.BackgroundImage = My.Resources.LngEnF
        End If

    End Sub

    Private Sub PanMode_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanMode.MouseEnter
        If P_MODE_FULL Then
            PanMode.BackgroundImage = My.Resources.MdFullN
        Else
            PanMode.BackgroundImage = My.Resources.MdHalfN
        End If
    End Sub

    Private Sub PanMode_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanMode.MouseLeave
        If P_MODE_FULL Then
            PanMode.BackgroundImage = My.Resources.MdFullF
        Else
            PanMode.BackgroundImage = My.Resources.MdHalfF
        End If
    End Sub

    Private Sub PanBd_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanBd.MouseEnter
        If P_BD_FULL Then
            PanBd.BackgroundImage = My.Resources.BdFullN
        Else
            PanBd.BackgroundImage = My.Resources.BdHalfN
        End If
    End Sub

    Private Sub PanBd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanBd.MouseLeave
        If P_BD_FULL Then
            PanBd.BackgroundImage = My.Resources.BdFullF
        Else
            PanBd.BackgroundImage = My.Resources.BdHalfF
        End If
    End Sub

    Private Sub PanSetting_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanSetting.MouseEnter
        PanSetting.BackgroundImage = My.Resources.SetN
    End Sub

    Private Sub PanSetting_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanSetting.MouseLeave
        PanSetting.BackgroundImage = My.Resources.SetF
    End Sub

#End Region

#Region "设定成非活动输入法窗口"

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

#End Region

#Region "窗口拖动处理"
    Private oPoint As Point
    Private oLoc As Point

    Private Sub PanLogo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanLogo.MouseDown
        oPoint = e.Location
        oLoc = Me.Location
    End Sub

    Private Sub PanLogo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanLogo.MouseUp

        Dim x As Integer = oLoc.X + e.Location.X - oPoint.X
        If x > My.Computer.Screen.WorkingArea.Width - Me.Width - 3 Then
            x = My.Computer.Screen.WorkingArea.Width - Me.Width - 3
        End If

        Dim y As Integer = oLoc.Y + e.Location.Y - oPoint.Y
        If y > My.Computer.Screen.WorkingArea.Height - Me.Height Then
            y = My.Computer.Screen.WorkingArea.Height - Me.Height
        End If

        Me.Location = New Point(x, y)
    End Sub

#End Region

End Class