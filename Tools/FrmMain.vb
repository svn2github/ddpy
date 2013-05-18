Public Class FrmMain

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
            Dim files As String() = ToPinyinFiles(TxtWordFile.Text)

            If files.Length > 0 Then
                TxtWordPinyin.Text = files(0)
            End If
            MsgBox("转换完成，请查看文件" & vbNewLine & vbNewLine & Strings.Join(files, vbNewLine), MsgBoxStyle.Information, "淡定")

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
End Class