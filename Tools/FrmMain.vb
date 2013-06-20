Imports System.Text
Imports System.IO
Imports System.IO.Compression
Imports System.Security.Permissions

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
 <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
Public Class FrmMain

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.F12 Then
            CopyFromScreen(Me)
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub BtnSearchPy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearchPy.Click

        Try
            TxtPinYin.Text = GetPinyin(Trim(TxtWord.Text))

            If TxtPinYin.Text.IndexOf(",") > 0 Then
                TxtPinYin.ForeColor = Color.Red
            Else
                TxtPinYin.ForeColor = Color.Black
            End If

        Catch ex As Exception
            MsgBox("怎么回事，不该发生的错误： " & ex.Message, MsgBoxStyle.Exclamation, "淡定")
        End Try

    End Sub

    Private Sub BtnSelectWordFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectWordFile.Click

        FileDlgWord.Multiselect = False
        FileDlgWord.Filter = "文本文件 *.txt（UTF8编码）|*.txt|所有文件|*.*"
        FileDlgWord.FileName = ""

        If FileDlgWord.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtWordFile.Text = FileDlgWord.FileName
        End If
    End Sub

    Private Sub BtnAddPinyin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddPinyin.Click

        Try

            If "".Equals(Trim(TxtWordFile.Text)) Then
                MsgBox("请选择待转换文件", MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If

            If Not My.Computer.FileSystem.FileExists(TxtWordFile.Text) Then
                MsgBox("文件 " & TxtWordFile.Text & " 不存在，请重新输入", MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If
            If My.Computer.FileSystem.GetFileInfo(TxtWordFile.Text).Length = 0 Then
                MsgBox("这是一个空文件：" & TxtWordFile.Text, MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If

            Cursor = Cursors.WaitCursor
            Dim sPath As String = ToPinyinFiles(TxtWordFile.Text)

            System.Diagnostics.Process.Start(sPath)

            Dim sFileName As String = sPath & "\\" & My.Computer.FileSystem.GetFileInfo(TxtWordFile.Text).Name & ".转换正确.txt"
            TxtWordPinyin.Text = sFileName

        Catch ex As Exception
            MsgBox("怎么回事，不该发生的错误： " & ex.Message, MsgBoxStyle.Exclamation, "淡定")
        Finally
            Cursor = Cursors.Arrow
        End Try

    End Sub

    Private Sub BtnAddPinyinPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            If "".Equals(Trim(TxtWordFile.Text)) Then
                MsgBox("请选择待转换文件", MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If

            If Not My.Computer.FileSystem.FileExists(TxtWordFile.Text) Then
                MsgBox("文件 " & TxtWordFile.Text & " 不存在，请重新输入", MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If
            If My.Computer.FileSystem.GetFileInfo(TxtWordFile.Text).Length = 0 Then
                MsgBox("这是一个空文件：" & TxtWordFile.Text, MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If

            Cursor = Cursors.WaitCursor
            Dim sPath As String = ToPinyinPlusFiles(TxtWordFile.Text)

            System.Diagnostics.Process.Start(sPath)

        Catch ex As Exception
            MsgBox("怎么回事，不该发生的错误： " & ex.Message, MsgBoxStyle.Exclamation, "淡定")
        Finally
            Cursor = Cursors.Arrow
        End Try

    End Sub

    Private Sub BtnWordPinyin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWordPinyin.Click

        FileDlgWord.Multiselect = False
        FileDlgWord.Filter = "文本文件 *.txt（UTF8编码）|*.txt|所有文件|*.*"
        FileDlgWord.FileName = ""

        If FileDlgWord.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtWordPinyin.Text = FileDlgWord.FileName
        End If
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click

        Try
            If "".Equals(Trim(TxtWordPinyin.Text)) Then
                MsgBox("请选择待转换文件", MsgBoxStyle.Information, "淡定")
                TxtWordPinyin.Focus()
                TxtWordPinyin.SelectAll()
                Return
            End If

            If Not My.Computer.FileSystem.FileExists(TxtWordPinyin.Text) Then
                MsgBox("文件 " & TxtWordPinyin.Text & " 不存在，请重新输入", MsgBoxStyle.Information, "淡定")
                TxtWordPinyin.Focus()
                TxtWordPinyin.SelectAll()
                Return
            End If
            If My.Computer.FileSystem.GetFileInfo(TxtWordPinyin.Text).Length = 0 Then
                MsgBox("这是一个空文件：" & TxtWordPinyin.Text, MsgBoxStyle.Information, "淡定")
                TxtWordPinyin.Focus()
                TxtWordPinyin.SelectAll()
                Return
            End If

            Cursor = Cursors.WaitCursor
            Dim sFile As String = ToSortedPinyinFile(TxtWordPinyin.Text, False)

            System.Diagnostics.Process.Start(My.Computer.FileSystem.GetFileInfo(sFile).DirectoryName)

        Catch ex As Exception
            MsgBox("怎么回事，不该发生的错误： " & ex.Message, MsgBoxStyle.Exclamation, "淡定")
        Finally
            Cursor = Cursors.Arrow
        End Try

    End Sub

    Private Sub BtnCreateWithDdpy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreateWithDdpy.Click

        Try
            If "".Equals(Trim(TxtWordPinyin.Text)) Then
                MsgBox("请选择待转换文件", MsgBoxStyle.Information, "淡定")
                TxtWordPinyin.Focus()
                TxtWordPinyin.SelectAll()
                Return
            End If

            If Not My.Computer.FileSystem.FileExists(TxtWordPinyin.Text) Then
                MsgBox("文件 " & TxtWordPinyin.Text & " 不存在，请重新输入", MsgBoxStyle.Information, "淡定")
                TxtWordPinyin.Focus()
                TxtWordPinyin.SelectAll()
                Return
            End If
            If My.Computer.FileSystem.GetFileInfo(TxtWordPinyin.Text).Length = 0 Then
                MsgBox("这是一个空文件：" & TxtWordPinyin.Text, MsgBoxStyle.Information, "淡定")
                TxtWordPinyin.Focus()
                TxtWordPinyin.SelectAll()
                Return
            End If

            Cursor = Cursors.WaitCursor
            Dim sFile As String = ToSortedPinyinFile(TxtWordPinyin.Text, True)

            System.Diagnostics.Process.Start(My.Computer.FileSystem.GetFileInfo(sFile).DirectoryName)

        Catch ex As Exception
            MsgBox("怎么回事，不该发生的错误： " & ex.Message, MsgBoxStyle.Exclamation, "淡定")
        Finally
            Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnExpDuoyinzi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExpDuoyinzi.Click
        Try

            If "".Equals(Trim(TxtWordFile.Text)) Then
                MsgBox("请选择待处理文件", MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If

            If Not My.Computer.FileSystem.FileExists(TxtWordFile.Text) Then
                MsgBox("文件 " & TxtWordFile.Text & " 不存在，请重新输入", MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If
            If My.Computer.FileSystem.GetFileInfo(TxtWordFile.Text).Length = 0 Then
                MsgBox("这是一个空文件：" & TxtWordFile.Text, MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If

            Cursor = Cursors.WaitCursor
            Dim sPath As String = ExpDuoyinFile(TxtWordFile.Text)

            System.Diagnostics.Process.Start(sPath)

        Catch ex As Exception
            MsgBox("怎么回事，不该发生的错误： " & ex.Message, MsgBoxStyle.Exclamation, "淡定")
        Finally
            Cursor = Cursors.Arrow
        End Try

    End Sub

    Private Sub BtnExpWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExpWord.Click

        Try

            If "".Equals(Trim(TxtWordFile.Text)) Then
                MsgBox("请选择待处理文件", MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If

            If Not My.Computer.FileSystem.FileExists(TxtWordFile.Text) Then
                MsgBox("文件 " & TxtWordFile.Text & " 不存在，请重新输入", MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If
            If My.Computer.FileSystem.GetFileInfo(TxtWordFile.Text).Length = 0 Then
                MsgBox("这是一个空文件：" & TxtWordFile.Text, MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If

            Cursor = Cursors.WaitCursor
            Dim sPath As String = ToWordFile(TxtWordFile.Text)

            System.Diagnostics.Process.Start(sPath)

        Catch ex As Exception
            MsgBox("怎么回事，不该发生的错误： " & ex.Message, MsgBoxStyle.Exclamation, "淡定")
        Finally
            Cursor = Cursors.Arrow
        End Try

    End Sub



    Private Sub BtnUpdatePinyin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdatePinyin.Click

        Try

            If "".Equals(Trim(TxtWordFile.Text)) Then
                MsgBox("请选择待处理文件", MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If

            If Not My.Computer.FileSystem.FileExists(TxtWordFile.Text) Then
                MsgBox("文件 " & TxtWordFile.Text & " 不存在，请重新输入", MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If
            If My.Computer.FileSystem.GetFileInfo(TxtWordFile.Text).Length = 0 Then
                MsgBox("这是一个空文件：" & TxtWordFile.Text, MsgBoxStyle.Information, "淡定")
                TxtWordFile.Focus()
                TxtWordFile.SelectAll()
                Return
            End If

            Cursor = Cursors.WaitCursor
            Dim sPath As String = UpdatePinyin(TxtWordFile.Text)

            System.Diagnostics.Process.Start(sPath)

        Catch ex As Exception
            MsgBox("怎么回事，不该发生的错误： " & ex.Message, MsgBoxStyle.Exclamation, "淡定")
        Finally
            Cursor = Cursors.Arrow
        End Try

    End Sub

End Class