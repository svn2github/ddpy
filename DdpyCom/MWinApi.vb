Imports System.Text
Imports System.Runtime.InteropServices

''' <summary>
''' Window Api 大杂烩模块
''' </summary>
Module MWinApi

    Friend Const WM_IME_NOTIFY As Integer = &H282
    Friend Const IMN_CLOSECANDIDATE As Integer = &H4
    Friend Const IMN_OPENCANDIDATE As Integer = &H5
    Friend Const WM_CLOSE As Integer = &H8

    Friend Const SW_SHOWNOACTIVATE As Integer = 4   ' 窗口显示时不抢占焦点
    Friend Const CS_VREDRAW As Integer = &H1
    Friend Const CS_HREDRAW As Integer = &H2
    Friend Const CS_DBLCLKS As Integer = &H8
    Friend Const CS_IME As Integer = &H10000
    Friend Const WM_MOUSEACTIVATE As Integer = &H21
    Friend Const MA_NOACTIVATE As Integer = &H3
    Friend Const WS_EX_NOACTIVATE As Integer = &H8000000
    Friend Const WM_NCACTIVATE As Integer = &H86
    Friend Const WM_SETFOCUS As Integer = 7
    Friend Const WM_ACTIVATE As Integer = &H6
    Friend Const VK_CAPITAL As Integer = &H14
    Friend Const VK_SHIFT As Integer = &H80

    Friend Declare Function ShowWindow Lib "user32" Alias "ShowWindow" (ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
    Friend Declare Function GetKeyboardState Lib "user32" (ByVal pbKeyState As Byte) As Integer
    Friend Declare Function GetKeyState Lib "user32" (ByVal iKey As Integer) As Integer
    Friend Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Friend Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Friend Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As Integer
    Friend Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hWnd As Integer, ByRef lpdwProcessId As Integer) As Integer
    Friend Declare Function GetCurrentThreadId Lib "kernel32" Alias "GetCurrentThreadId" () As Integer
    Friend Declare Function GetFocus Lib "user32" Alias "GetFocus" () As Integer

    Friend Declare Function ImmInstallIME Lib "imm32.dll" Alias "ImmInstallIMEA" (ByVal lpszIMEFileName As String, ByVal lpszLayoutText As String) As Integer


    Friend Declare Function GetClassName Lib "user32" Alias "GetClassNameA" (ByVal hWnd As Integer, ByVal clsName As StringBuilder, ByVal nMaxCount As Integer) As Integer
    Friend Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Integer, ByVal lpString As String, ByVal cch As Integer) As Integer

    Friend Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer

    <DllImport("user32.dll", EntryPoint:="FindWindowEx")> _
    Friend Function FindWindowEx(ByVal hwndParent As IntPtr, ByVal hwndChildAfter As IntPtr, ByVal lpszClass As String, ByVal lpszWindow As String) As IntPtr
    End Function

    Friend Function GetClassNameByHwnd(ByVal hWnd As Integer) As String
        Dim buf As New StringBuilder
        GetClassName(hWnd, buf, 255)
        Return buf.ToString
    End Function

    Friend Function GetWindowText(ByVal hWnd As Integer) As String
        Dim strTitle As New String(Chr(0), 255)     '用来存储窗口的标题

        GetWindowText(hWnd, strTitle, Len(strTitle))

        Return Strings.Left(strTitle, InStr(1, strTitle, vbNullChar))

    End Function

End Module
