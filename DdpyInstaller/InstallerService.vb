﻿Imports System.ComponentModel
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
        Dim windir As String = Environment.GetEnvironmentVariable("windir")   ' C:\Windows
        Dim imeName As String = "淡定拼音输入法"

        ' 注册后台服务COM
        Dim info As New System.Diagnostics.ProcessStartInfo
        'If Environment.Is64BitOperatingSystem Then
        '    info.FileName = windir & "\\Microsoft.NET\\Framework64\\v4.0.30319\\regasm.exe"
        'Else
        '    info.FileName = windir & "\\Microsoft.NET\\Framework\\v4.0.30319\\regasm.exe"
        'End If
        info.FileName = windir & "\\Microsoft.NET\\Framework\\v4.0.30319\\regasm.exe"
        info.Arguments = """" & installPath & "\\DdpySrv.exe"""
        info.WindowStyle = ProcessWindowStyle.Hidden
        System.Diagnostics.Process.Start(info)

        ' 注册COM
        info.FileName = windir & "\\Microsoft.NET\\Framework\\v4.0.30319\\regasm.exe"
        info.Arguments = "/codebase """ & installPath & "\\DdpyCom.dll"""
        info.WindowStyle = ProcessWindowStyle.Hidden
        System.Diagnostics.Process.Start(info)

        If Environment.Is64BitOperatingSystem Then
            info.FileName = windir & "\\Microsoft.NET\\Framework64\\v4.0.30319\\regasm.exe"
            System.Diagnostics.Process.Start(info)
        End If

        ' 安装IME
        ImmInstallIME(windir & "\\system32\\DdpyIme.dll", imeName)

    End Sub


    Private Sub DdpyInstaller_BeforeUninstall(ByVal sender As Object, ByVal e As System.Configuration.Install.InstallEventArgs) Handles Me.BeforeUninstall

        ' 关闭后台服务
        Dim srvProcess As Process() = System.Diagnostics.Process.GetProcessesByName("DdpySrv")
        For Each prc As Process In srvProcess
            prc.Kill()
        Next

        Dim installPath As String = My.Computer.FileSystem.GetFileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName
        Dim windir As String = Environment.GetEnvironmentVariable("windir")   ' C:\Windows

        ' 卸载后台服务COM
        Dim info As New System.Diagnostics.ProcessStartInfo
        'If Environment.Is64BitOperatingSystem Then
        '    info.FileName = windir & "\\Microsoft.NET\\Framework64\\v4.0.30319\\regasm.exe"
        'Else
        '    info.FileName = windir & "\\Microsoft.NET\\Framework\\v4.0.30319\\regasm.exe"
        'End If
        info.FileName = windir & "\\Microsoft.NET\\Framework\\v4.0.30319\\regasm.exe"
        info.Arguments = "/u """ & installPath & "\\DdpySrv.exe"""
        info.WindowStyle = ProcessWindowStyle.Hidden
        System.Diagnostics.Process.Start(info)

        ' 卸载COM
        info.FileName = windir & "\\Microsoft.NET\\Framework\\v4.0.30319\\regasm.exe"
        info.Arguments = "/u """ & installPath & "\\DdpyCom.dll"""
        info.WindowStyle = ProcessWindowStyle.Hidden
        System.Diagnostics.Process.Start(info)

        If Environment.Is64BitOperatingSystem Then
            info.FileName = windir & "\\Microsoft.NET\\Framework64\\v4.0.30319\\regasm.exe"
            System.Diagnostics.Process.Start(info)
        End If


    End Sub

    Private Sub DdpyInstaller_AfterUninstall(ByVal sender As Object, ByVal e As System.Configuration.Install.InstallEventArgs) Handles Me.AfterUninstall

        Dim windir As String = Environment.GetEnvironmentVariable("windir")   ' C:\Windows

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


        ' 尝试删除IME文件
        Dim imeFile32 As String = windir & "\\system32\\DdpyIme.dll"
        Dim imeFile64 As String = windir & "\\SysWOW64\\DdpyIme.dll"

        Try
            If Environment.Is64BitOperatingSystem AndAlso My.Computer.FileSystem.FileExists(imeFile64) Then
                My.Computer.FileSystem.DeleteFile(imeFile64)
            End If
        Catch ex As Exception
        End Try

        Try
            If My.Computer.FileSystem.FileExists(imeFile32) Then
                My.Computer.FileSystem.DeleteFile(imeFile32)
            End If
        Catch ex As Exception
        End Try

        Try
            If My.Computer.FileSystem.FileExists(imeFile32) Then
                Dim info As New System.Diagnostics.ProcessStartInfo
                info.FileName = "cmd.exe"
                info.Arguments = "/k takeown /f " & imeFile32 & " && icacls " & imeFile32 & "/grant " & My.User.Name & ":F"
                info.WindowStyle = ProcessWindowStyle.Hidden
                System.Diagnostics.Process.Start(info)

                My.Computer.FileSystem.DeleteFile(imeFile32)
            End If
        Catch ex As Exception
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
            Dim name As String = CStr(regPreload.GetValue(key))
            regLayouts = My.Computer.Registry.LocalMachine.OpenSubKey(sLayouts & name)

            If sDdpyIme.Equals(CStr(regLayouts.GetValue("Ime File")), StringComparison.OrdinalIgnoreCase) Then
                Return key & "=" & name
            End If
        Next

        Return ""

    End Function

End Class
