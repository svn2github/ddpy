'****************************** Module Header ******************************'
' Module Name:  MainModule.vb
' Project:      VBExeCOMServer
' Copyright (c) Microsoft Corporation.
' 
' The main entry point for the application. It is responsible for starting  
' the out-of-proc COM server registered in the executable.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************'

Module ZMainModule

    Public Sub Main(ByVal args As String())

        ' 无参数
        If args Is Nothing OrElse args.Length = 0 Then
            'System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData)
            Return
        End If

        ' 打开用户数据目录
        If args(0) = "User" Then
            System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData)
            Return
        End If

        ' 打开输入法数据目录
        If args(0) = "Data" Then
            System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData)
            Return
        End If

        ' 打开日志目录
        If args(0) = "Log" Then
            Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData
            sPath = My.Computer.FileSystem.GetParentPath(sPath)
            sPath = My.Computer.FileSystem.GetParentPath(sPath) & "\Log"
            System.Diagnostics.Process.Start(sPath)
            Return
        End If

        ' 卸载
        If args(0) = "/x" Then
            Dim server As Object = CreateObject("DdpySrv.ComClass")
            server.Close()
            Shell("C:\WINDOWS\system32\msiexec.exe /x {C2095991-AADE-4845-B3DD-9EEB3DD1298E}", AppWinStyle.NormalFocus, False)
            Return
        End If

        ' 启动COM服务
        ZExeCOMServer.Instance.Run()

    End Sub

End Module
