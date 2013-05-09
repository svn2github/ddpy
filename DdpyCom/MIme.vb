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
    ''' <param name="lp">值</param>
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

            P_BD_FULL = True
            frmStatus.PanBd.BackgroundImage = My.Resources.BdFullF
        Else
            frmStatus.PanLng.BackgroundImage = My.Resources.LngEnF

            P_BD_FULL = False
            frmStatus.PanBd.BackgroundImage = My.Resources.BdHalfF
            frmInput.Hide()     ' 英文模式时隐藏候选窗口
        End If

    End Sub

    Private iTipType As Integer
    Friend Sub ShowTipWindow(ByVal iType As Integer)
        If Not P_HIDE_STATUS Then
            Return
        End If

        iTipType = iType
        Dim thd As New Threading.Thread(AddressOf ShowImeTip)
        thd.Start()
    End Sub

    Private Sub ShowImeTip()
        Dim frm As New FrmImeTip

        If iTipType = 1 Then
            frm.BackgroundImage = IIf(P_LNG_CN, My.Resources.LngCnF, My.Resources.LngEnF)
        ElseIf iTipType = 2 Then
            frm.BackgroundImage = IIf(P_MODE_FULL, My.Resources.MdFullF, My.Resources.MdHalfF)
        Else
            frm.BackgroundImage = IIf(P_BD_FULL, My.Resources.BdFullF, My.Resources.BdHalfF)
        End If

        frm.Location = New System.Drawing.Point(PosX + 2, PosY + PosH + 5)

        ShowWindow(frm.Handle, SW_SHOWNOACTIVATE)
        Threading.Thread.Sleep(600)
        frm.Close()
    End Sub

End Module
