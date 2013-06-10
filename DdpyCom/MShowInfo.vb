Imports System.Threading
Imports System.Drawing
Imports System.Windows.Forms

Module MShowInfo

    Private frmInfo As New FrmInformation
    Private bCrlShow As Boolean = False

    Friend Sub ShowInfoForm(Optional ByVal bCtrl As Boolean = False)

        If Not frmInput.Visible Then
            Return
        End If

        bCrlShow = bCtrl

        If Not bCrlShow AndAlso P_I_MODE AndAlso ddPy.InputPys.StartsWith("i") Then
            Return
        End If

        ShowForm()
    End Sub

    Private Sub ShowForm()

        Dim word As CWord = ddPy.GetFocusWord()
        If word IsNot Nothing Then

            If "".Equals(word.PinYin) Then
                frmInfo.Label1.Text = word.Text
            Else
                frmInfo.Label1.Text = word.PinYin.Replace("'", " ") & vbNewLine & word.Text
            End If

            If Not frmInfo.Visible Then
                frmInfo.Label1.Font = fontCand
                frmInfo.Show()
            End If

            Dim x As Integer = frmInput.Location.X
            Dim y As Integer = frmInput.Location.Y + frmInput.Height

            If Screen.PrimaryScreen.WorkingArea.Width - x - frmInfo.Width < 0 Then
                If Screen.PrimaryScreen.WorkingArea.Width - frmInfo.Width < 0 Then
                    x = 0
                Else
                    x = Screen.PrimaryScreen.WorkingArea.Width - frmInfo.Width
                End If
            End If
            If frmInput.Location.Y < PosY OrElse Screen.PrimaryScreen.WorkingArea.Height - y - frmInfo.Height < 0 Then
                If frmInput.Location.Y < PosY Then
                    y = frmInput.Location.Y - frmInfo.Height
                Else
                    y = frmInput.Location.Y - frmInfo.Height - PosH - 3
                End If
            End If

            frmInfo.Location = New Point(x, y)

        Else
            HideInfoForm()
        End If
    End Sub

    Friend Sub ActiveInfoForm()

        If Not frmInput.Visible OrElse Not bCrlShow Then
            Return
        End If

        ShowForm()
    End Sub


    Friend Sub HideInfoForm(Optional ByVal bActive As Boolean = False)

        If Not bActive Then
            bCrlShow = False
        End If

        If frmInfo.Visible Then
            frmInfo.Hide()
        End If
    End Sub


End Module
