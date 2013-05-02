Module MIme

    Friend frmInput As New FrmImeInput              ' 编码候选窗口
    Friend frmStatus As New FrmImeStatus            ' 状态栏窗口

    Private listCtrlHwnd As New List(Of Integer)    ' 存放焦点控件句柄

    Friend initStartTime As Long

    ''' <summary>
    ''' 通过WM_IME_NOTIFY向焦点控件发送IMN_OPENCANDIDATE消息
    ''' </summary>
    Friend Sub NotifyImeOpenCandidate()
        Dim hwnd As Integer = GetFocus()
        If Not listCtrlHwnd.Contains(hwnd) Then
            listCtrlHwnd.Add(hwnd)
            SendMessage(hwnd, WM_IME_NOTIFY, IMN_OPENCANDIDATE, 1)
        End If
    End Sub

    ''' <summary>
    ''' 通过WM_IME_NOTIFY向焦点控件发送IMN_CLOSECANDIDATE消息
    ''' </summary>
    Friend Sub NotifyImeCloseCandidate()
        For Each hwnd As Integer In listCtrlHwnd
            SendMessage(hwnd, WM_IME_NOTIFY, IMN_CLOSECANDIDATE, 1)
        Next
        listCtrlHwnd.Clear()
    End Sub

    ''' <summary>
    ''' 通过WM_IME_NOTIFY向焦点控件发送自定义消息
    ''' </summary>
    ''' <param name="wp">区分</param>
    ''' <param name="lp">0或1</param>
    Friend Sub NotifyIme(ByVal wp As Integer, ByVal lp As Integer)
        SendMessage(GetFocus(), WM_IME_NOTIFY, wp, lp)
    End Sub

    ''' <summary>
    ''' 刷新输入法状态窗口
    ''' </summary>
    Friend Sub UpdateStatusWindow()
        If My.Computer.Keyboard.CapsLock Then
            frmStatus.PanLng.BackgroundImage = My.Resources.LngA
        ElseIf P_LNG_CN Then
            frmStatus.PanLng.BackgroundImage = My.Resources.LngCnF

            P_BD_FULL = False
            frmStatus.PanBd.BackgroundImage = My.Resources.BdFullF
        Else
            frmStatus.PanLng.BackgroundImage = My.Resources.LngEnF

            P_BD_FULL = False
            frmStatus.PanBd.BackgroundImage = My.Resources.BdHalfF
            frmInput.Hide()     ' 英文模式时隐藏候选窗口
        End If
    End Sub

End Module
