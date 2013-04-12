Module MIme

    ''' <summary>
    ''' 输入法UI窗口句柄
    ''' </summary>
    Private uiHwnd As Integer

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


End Module
