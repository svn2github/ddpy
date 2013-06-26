Imports System.Text

Module MPathFile

    Public Sub InitDdpyFiles()

        Dim sPrevUserPath As String
        Dim sSrcFile As String
        Dim sDstFile As String

        sPrevUserPath = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        sPrevUserPath = My.Computer.FileSystem.GetParentPath(sPrevUserPath) ' 前版本的用户目录（每次版本号变更时注意修改）

        ' 用户词库（复制使用前版本用户词库）
        sDstFile = GetDdpyUserWordFile()
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then

            sSrcFile = sPrevUserPath & "\\用户词库.txt"
            If My.Computer.FileSystem.FileExists(sSrcFile) Then
                My.Computer.FileSystem.CopyFile(sSrcFile, sDstFile)
            End If
        End If

        ' 用户混合输入（复制使用前版本用户混合输入）
        sDstFile = GetDdpyUserMixInputFile()
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then

            sSrcFile = sPrevUserPath & "\\用户混合输入.txt"
            If My.Computer.FileSystem.FileExists(sSrcFile) Then
                My.Computer.FileSystem.CopyFile(sSrcFile, sDstFile)
            Else
                My.Computer.FileSystem.WriteAllText(sDstFile, "http://code.google.com/p/ddpy/" & vbNewLine, False, Encoding.UTF8)
            End If
        End If


        If My.Computer.FileSystem.FileExists(GetDdpyUserWordFile()) Then
            My.Computer.FileSystem.CopyFile(GetDdpyUserWordFile(), GetDdpyUserBackupPath() & "\\" & Now.ToString("yyyy-MM-dd-HHmmss") & "用户词库.txt")
        End If
        If My.Computer.FileSystem.FileExists(GetDdpyUserMixInputFile()) Then
            My.Computer.FileSystem.CopyFile(GetDdpyUserMixInputFile(), GetDdpyUserBackupPath() & "\\" & Now.ToString("yyyy-MM-dd-HHmmss") & "用户混合输入.txt")
        End If

        Dim files = My.Computer.FileSystem.GetFiles(GetDdpyUserBackupPath() _
                                            , FileIO.SearchOption.SearchTopLevelOnly _
                                            , "????-??-??-??????用户词库.txt")
        Dim lstFile As New List(Of String)
        lstFile.AddRange(files)
        lstFile.Sort()
        lstFile.Reverse()
        For i As Integer = 30 To lstFile.Count - 1
            My.Computer.FileSystem.DeleteFile(lstFile(i))
        Next

        files = My.Computer.FileSystem.GetFiles(GetDdpyUserBackupPath() _
                                    , FileIO.SearchOption.SearchTopLevelOnly _
                                    , "????-??-??-??????用户混合输入.txt")
        lstFile = New List(Of String)
        lstFile.AddRange(files)
        lstFile.Sort()
        lstFile.Reverse()
        For i As Integer = 30 To lstFile.Count - 1
            My.Computer.FileSystem.DeleteFile(lstFile(i))
        Next


        ' 配置
        sDstFile = GetDdpyConfigFile()
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then
            My.Computer.FileSystem.WriteAllText(sDstFile, GetSettingInfo(), False, Encoding.UTF8)
        Else
            SetSettingInfo(My.Computer.FileSystem.ReadAllText(sDstFile, Encoding.UTF8))
        End If


        ' 淡定字库/淡定词库/淡定固顶
        sDstFile = GetDdpySingleWordFile()
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then
            My.Computer.FileSystem.WriteAllText(sDstFile, My.Resources.淡定字库, False, Encoding.UTF8)
        End If
        sDstFile = GetDdpyMultWordFile()
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then
            My.Computer.FileSystem.WriteAllText(sDstFile, My.Resources.淡定词库, False, Encoding.UTF8)
        End If
        sDstFile = GetDdpyTopWordFile()
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then
            My.Computer.FileSystem.WriteAllText(sDstFile, My.Resources.淡定固顶, False, Encoding.UTF8)
        End If

        ' 淡定脚本例子
        sDstFile = GetDdpyScriptPath() & "\\i神农本草.js"
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then
            My.Computer.FileSystem.WriteAllText(sDstFile, My.Resources.i神农本草, False, Encoding.UTF8)
        End If
        sDstFile = GetDdpyScriptPath() & "\\i日文汉字拼音输入.js"
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then
            My.Computer.FileSystem.WriteAllText(sDstFile, My.Resources.i日文汉字拼音输入, False, Encoding.UTF8)
        End If
        sDstFile = GetDdpyScriptPath() & "\\i符号.js"
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then
            My.Computer.FileSystem.WriteAllText(sDstFile, My.Resources.i符号, False, Encoding.UTF8)
        End If
        sDstFile = GetDdpyScriptPath() & "\\i伤寒金匮经方.js"
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then
            My.Computer.FileSystem.WriteAllText(sDstFile, My.Resources.i伤寒金匮经方, False, Encoding.UTF8)
        End If
        sDstFile = GetDdpyScriptPath() & "\\i伤寒论条文.js"
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then
            My.Computer.FileSystem.WriteAllText(sDstFile, My.Resources.i伤寒论条文, False, Encoding.UTF8)
        End If
        sDstFile = GetDdpyScriptPath() & "\\i淡定扩充信息脚本.js"
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then
            My.Computer.FileSystem.WriteAllText(sDstFile, My.Resources.i淡定扩充信息脚本, False, Encoding.UTF8)
        End If
        sDstFile = GetDdpyScriptPath() & "\\i淡定脚本.js"
        If Not My.Computer.FileSystem.FileExists(sDstFile) Then
            My.Computer.FileSystem.WriteAllText(sDstFile, My.Resources.i淡定脚本, False, Encoding.UTF8)
        End If

    End Sub

    Public Function GetDdpySingleWordFile() As String
        Return GetDdpyDataPath() & "\\淡定字库.txt"
    End Function

    Public Function GetDdpyMultWordFile() As String
        Return GetDdpyDataPath() & "\\淡定词库.txt"
    End Function

    Public Function GetDdpyTopWordFile() As String
        Return GetDdpyDataPath() & "\\淡定固顶.txt"
    End Function

    Public Function GetDdpyConfigFile() As String
        Return GetDdpyConfigPath() & "\\淡定配置.txt"
    End Function
    Public Function GetDdpyConfigExeFile() As String
        Return My.Computer.FileSystem.GetParentPath(Application.ExecutablePath) & "\DdpyCfg.exe"
    End Function

    Public Function GetDdpyUserWordFile() As String
        Return GetDdpyUserDataPath() & "\\用户词库.txt"
    End Function

    Public Function GetDdpyUserMixInputFile() As String
        Return GetDdpyUserDataPath() & "\\用户混合输入.txt"
    End Function
    Public Function GetDdpyLogFile() As String
        Return GetDdpyLogPath() & "\\DdpySrv-" & Now.ToString("yyyy-MM-dd") & ".log"
    End Function

    Public Function GetDdpyUserDataPath() As String
        Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Data"
        If Not My.Computer.FileSystem.DirectoryExists(sPath) Then
            My.Computer.FileSystem.CreateDirectory(sPath)
        End If

        Return sPath
    End Function

    Public Function GetDdpyUserBackupPath() As String
        Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Backup"
        If Not My.Computer.FileSystem.DirectoryExists(sPath) Then
            My.Computer.FileSystem.CreateDirectory(sPath)
        End If

        Return sPath
    End Function

    Public Function GetDdpyDataPath() As String
        Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\Data"
        If Not My.Computer.FileSystem.DirectoryExists(sPath) Then
            My.Computer.FileSystem.CreateDirectory(sPath)
        End If

        Return sPath
    End Function

    Public Function GetDdpyScriptPath() As String
        Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\DdpyScript"
        If Not My.Computer.FileSystem.DirectoryExists(sPath) Then
            My.Computer.FileSystem.CreateDirectory(sPath)
        End If

        Return sPath
    End Function

    Public Function GetDdpyConfigPath() As String
        Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\Config"
        If Not My.Computer.FileSystem.DirectoryExists(sPath) Then
            My.Computer.FileSystem.CreateDirectory(sPath)
        End If

        Return sPath
    End Function

    Public Function GetDdpyLogPath() As String
        Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\Log"
        If Not My.Computer.FileSystem.DirectoryExists(sPath) Then
            My.Computer.FileSystem.CreateDirectory(sPath)
        End If

        Return sPath
    End Function


End Module
