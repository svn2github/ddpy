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

        If args Is Nothing OrElse args.Length = 0 Then
            System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData)
            Return
        End If

        If args(0) = "User" Then
            System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData)
            Return
        End If

        If args(0) = "Data" Then
            System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData)
            Return
        End If

        If args(0) = "Log" Then
            Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData
            sPath = My.Computer.FileSystem.GetParentPath(sPath)
            sPath = My.Computer.FileSystem.GetParentPath(sPath) & "\Log"
            System.Diagnostics.Process.Start(sPath)
            Return
        End If

        ' Run the out-of-process COM server
        ZExeCOMServer.Instance.Run()

    End Sub

End Module
