Imports System.ComponentModel
Imports System.Configuration.Install
Imports Microsoft.Win32
Imports System.Reflection

Public Class InstallerService

    Private Declare Function ImmInstallIME Lib "imm32.dll" Alias "ImmInstallIMEA" (ByVal lpszIMEFileName As String, ByVal lpszLayoutText As String) As Integer
    Private Declare Function LoadKeyboardLayout Lib "user32" Alias "LoadKeyboardLayoutA" (ByVal pwszKLID As String, ByVal flags As Integer) As Integer
    Private Declare Function UnloadKeyboardLayout Lib "user32" Alias "UnloadKeyboardLayout" (ByVal HKL As Integer) As Integer


    Public Sub New()
        MyBase.New()

        '组件设计器需要此调用。
        InitializeComponent()

        '调用 InitializeComponent 后添加初始化代码

    End Sub



    Private Sub DdpyInstaller_AfterInstall(ByVal sender As Object, ByVal e As System.Configuration.Install.InstallEventArgs) Handles Me.AfterInstall

        Dim installPath As String = My.Computer.FileSystem.GetFileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName

        ' 安装IME
        ImmInstallIME("C:\\WINDOWS\\system32\\DdpyIme.dll", "淡定拼音输入法 Beta 0.1")

        ' 注册后台服务COM
        Dim info As New System.Diagnostics.ProcessStartInfo
        info.FileName = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\regasm.exe"
        info.Arguments = """" & installPath & "\\DdpySrv.exe"""
        info.WindowStyle = ProcessWindowStyle.Hidden
        System.Diagnostics.Process.Start(info)

    End Sub



    Private Sub DdpyInstaller_BeforeUninstall(ByVal sender As Object, ByVal e As System.Configuration.Install.InstallEventArgs) Handles Me.BeforeUninstall

        Dim installPath As String = My.Computer.FileSystem.GetFileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName

        ' 卸载后台服务COM
        Dim info As New System.Diagnostics.ProcessStartInfo
        info.FileName = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\regasm.exe"
        info.Arguments = "/u """ & installPath & "\\DdpySrv.exe"""
        info.WindowStyle = ProcessWindowStyle.Hidden
        System.Diagnostics.Process.Start(info)
    End Sub

    Private Sub DdpyInstaller_AfterUninstall(ByVal sender As Object, ByVal e As System.Configuration.Install.InstallEventArgs) Handles Me.AfterUninstall


        Try
            ' 卸载IME
            Dim result As String = GetDdpyRegKey()
            If result = "" Then
                Return
            End If

            Dim sValue As String = Strings.Split(result, "=")(0)
            Dim sKey As String = Strings.Split(result, "=")(1)

            Dim iRst As Integer = LoadKeyboardLayout(sKey, 1)
            If Not iRst = 0 Then
                UnloadKeyboardLayout(iRst)
            End If

            Dim sPreload As String = "Keyboard Layout\Preload"
            My.Computer.Registry.CurrentUser.OpenSubKey(sPreload, True).DeleteValue(sValue)

            Dim sLayouts As String = "SYSTEM\CurrentControlSet\Control\Keyboard Layouts"
            My.Computer.Registry.LocalMachine.OpenSubKey(sLayouts, True).DeleteSubKeyTree(sKey)

        Catch ex As Exception
            '  MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub


    Private Function GetDdpyRegKey() As String

        Dim sDdpyIme As String = "DdpyIme.dll"
        Dim sPreload As String = "Keyboard Layout\Preload"
        Dim sLayouts As String = "SYSTEM\CurrentControlSet\Control\Keyboard Layouts\\"
        Dim regPreload As RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey(sPreload)
        Dim regLayouts As RegistryKey
        Dim keys As String() = regPreload.GetValueNames

        For Each key As String In keys
            Dim name As String = regPreload.GetValue(key)
            regLayouts = My.Computer.Registry.LocalMachine.OpenSubKey(sLayouts & name)

            If sDdpyIme.Equals(CStr(regLayouts.GetValue("Ime File")), StringComparison.OrdinalIgnoreCase) Then
                Return key & "=" & name
            End If
        Next

        Return ""

    End Function


End Class
