Imports System.Drawing
Imports System.Windows.Forms

Module MPrintScreen

    Friend Sub CopyFromScreen(ByVal oForm As Form)

        If oForm Is Nothing OrElse Not oForm.Visible Then
            Return
        End If

        Dim oGraphics As Graphics = oForm.CreateGraphics()
        Dim oImg As Bitmap = New Bitmap(oForm.Width, oForm.Height, oGraphics)
        Dim oMemoryGraphics As Graphics = Graphics.FromImage(oImg)
        oMemoryGraphics.CopyFromScreen(oForm.Location, New Point(0, 0), oForm.Size)

        My.Computer.Clipboard.SetImage(oImg)

    End Sub

    Friend Sub CopyFromScreen(ByVal leftTopX As Integer, ByVal leftTopY As Integer, ByVal width As Integer, ByVal height As Integer)

        Dim oForm As New Form
        
        Dim oGraphics As Graphics = oForm.CreateGraphics()
        Dim oImg As Bitmap = New Bitmap(width, height, oGraphics)
        Dim oMemoryGraphics As Graphics = Graphics.FromImage(oImg)
        oMemoryGraphics.CopyFromScreen(New Point(leftTopX, leftTopY), New Point(0, 0), New Size(width, height))

        My.Computer.Clipboard.SetImage(oImg)

    End Sub

End Module
