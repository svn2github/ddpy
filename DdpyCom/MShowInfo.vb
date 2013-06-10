Imports System.Threading
Imports System.Drawing

Module MShowInfo

    Private frmInfo As New FrmInformation
    Private bCrlShow As Boolean = False

    Friend Sub ShowInfoForm(Optional ByVal bCtrl As Boolean = False)

        If Not frmInput.Visible Then
            Return
        End If

        bCrlShow = bCtrl

        Dim word As CWord = ddPy.GetFocusWord()
        If word IsNot Nothing Then

            If Not frmInfo.Visible Then
                frmInfo.Location = New Point(frmInput.Location.X, frmInput.Location.Y + frmInput.Height)
                frmInfo.Show()
            End If

            frmInfo.Label1.Text = word.PinYin.Replace("'", " ") & vbNewLine & word.Text


        End If
    End Sub

    Friend Sub ActiveInfoForm()

        If Not frmInput.Visible OrElse Not bCrlShow Then
            Return
        End If

        Dim word As CWord = ddPy.GetFocusWord()
        If word IsNot Nothing Then

            If Not frmInfo.Visible Then
                frmInfo.Location = New Point(frmInput.Location.X, frmInput.Location.Y + frmInput.Height)
                frmInfo.Show()
            End If

            frmInfo.Label1.Text = word.PinYin.Replace("'", " ") & vbNewLine & word.Text


        End If
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
