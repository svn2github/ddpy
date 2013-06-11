Imports System.Threading
Imports System.Drawing
Imports System.Windows.Forms

Module MShowInfo

    Private frmInfo As New FrmInformation
    Private bCrlShow As Boolean = False

    Friend Sub ShowInfoForm(Optional ByVal bCtrl As Boolean = False)

        'If bCtrl AndAlso frmInfo.Visible AndAlso frmInfo.LblExecText.Text.Length > 0 Then
        '    Try
        '        System.Diagnostics.Process.Start(frmInfo.LblExecText.Text)
        '        frmInput.Visible = False    ' 关闭候选窗口但不清除ddpy数据，以便激活时显示原有候选窗口
        '        frmInfo.Visible = False
        '    Catch ex As Exception
        '        ComDebug(ex)
        '    End Try
        '    Return
        'End If

        If Not frmInput.Visible Then
            Return
        End If

        If Not My.Computer.Keyboard.CtrlKeyDown AndAlso P_I_MODE AndAlso ddPy.InputPys.StartsWith("i") Then
            Return
        End If

        ShowForm()
    End Sub

    Private Sub ShowForm()

        Dim word As CWord = ddPy.GetFocusWord()
        If word IsNot Nothing Then

            Dim sTxt As String = JsScriptSearch(word.Text)
            If ddPy.InputPys.StartsWith("i") Then
                If Not My.Computer.Keyboard.CtrlKeyDown Then
                    HideInfoForm()
                    Return
                End If
            Else
                If Not My.Computer.Keyboard.CtrlKeyDown AndAlso Not P_SHOW_INFO_WITH_PY_TEXT AndAlso sTxt.Length = 0 Then
                    HideInfoForm()
                    Return
                End If
            End If

            If sTxt.Length > 0 Then

                Dim sInfo As String() = sTxt.Split(vbTab)
                frmInfo.LblText.Text = sInfo(0).Replace("<br>", vbNewLine)
                If sInfo.Length > 1 Then
                    frmInfo.LblExecText.Text = sInfo(1)
                Else
                    frmInfo.LblExecText.Text = ""
                End If

                frmInfo.LblText.Visible = frmInfo.LblText.Text.Length > 0
                frmInfo.LblExecText.Visible = frmInfo.LblExecText.Text.Length > 0

            Else
                If "".Equals(word.PinYin) OrElse ddPy.InputPys.StartsWith("i") Then
                    frmInfo.LblText.Text = word.Text
                Else
                    frmInfo.LblText.Text = word.PinYin.Replace("'", " ") & vbNewLine & word.Text
                End If

                frmInfo.LblExecText.Text = ""
            End If

            frmInfo.LblText.Visible = frmInfo.LblText.Text.Length > 0
            frmInfo.LblExecText.Visible = frmInfo.LblExecText.Text.Length > 0


            If Not frmInfo.Visible Then
                frmInfo.LblText.Font = fontCand
                frmInfo.LblExecText.Font = fontCand
                frmInfo.Show()
            End If


        Else

            If My.Computer.Keyboard.CtrlKeyDown Then
                frmInfo.LblText.Text = "空空如也"
                frmInfo.LblText.Visible = True
                frmInfo.LblExecText.Visible = False
                frmInfo.Show()

            Else
                HideInfoForm()
            End If
        End If
    End Sub


    Friend Sub ActiveInfoForm()

        If Not frmInput.Visible Then
            Return
        End If

        If Not frmInfo.Visible AndAlso frmInfo.HasData Then
            frmInfo.Show()
        End If
    End Sub


    Friend Sub HideInfoForm(Optional ByVal bActive As Boolean = False)

        If frmInfo.Visible Then
            frmInfo.Hide()

            If Not bActive Then
                frmInfo.Clear()
            End If
        End If
    End Sub


End Module
