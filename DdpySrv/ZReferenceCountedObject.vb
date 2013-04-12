Imports System.Runtime.InteropServices

<ComVisible(False)> _
Public Class ZReferenceCountedObject

    Public Sub New()
        ' Increment the lock count of objects in the COM server.
        ZExeCOMServer.Instance.Lock()
    End Sub

    Protected Overrides Sub Finalize()
        Try
            ' Decrement the lock count of objects in the COM server.
            ZExeCOMServer.Instance.Unlock()
        Finally
            MyBase.Finalize()
        End Try
    End Sub

End Class
