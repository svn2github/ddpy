Module MIme

    ''' <summary>
    ''' 输入法UI窗口句柄
    ''' </summary>
    Private uiHwnd As Integer

    Private listCtrlHwnd As New List(Of Integer)

    ''' <summary>
    ''' 设定输入法UI窗口句柄
    ''' </summary>
    ''' <param name="hwnd">输入法UI窗口句柄</param>
    Friend Sub SetImeUiHwnd(ByVal hwnd As Integer)
        uiHwnd = hwnd
    End Sub

    ''' <summary>
    ''' 通过向IME的UI窗口发送消息实现IME变量设定
    ''' </summary>
    ''' <param name="id">编号</param>
    ''' <param name="val">值</param>
    Friend Sub SendUiMessage(ByVal id As Integer, ByVal val As Integer)
        SendMessage(uiHwnd, 9999, id, val)
    End Sub

    ''' <summary>
    ''' 向焦点控件发送IME消息IMN_OPENCANDIDATE
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub NotifyImeOpenCandidate()
        Dim hwnd As Integer = GetFocus()
        listCtrlHwnd.Add(hwnd)
        SendMessage(hwnd, WM_IME_NOTIFY, IMN_OPENCANDIDATE, 1)
    End Sub

    ''' <summary>
    ''' 向焦点控件发送IME消息IMN_CLOSECANDIDATE
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub NotifyImeCloseCandidate()
        For Each hwnd As Integer In listCtrlHwnd
            SendMessage(hwnd, WM_IME_NOTIFY, IMN_CLOSECANDIDATE, 1)
        Next
        listCtrlHwnd.Clear()
    End Sub


End Module
