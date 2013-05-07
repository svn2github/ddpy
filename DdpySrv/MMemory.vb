Imports System.Runtime.InteropServices

Module MMemory

    <DllImport("kernel32.dll")> _
    Private Function SetProcessWorkingSetSize(ByVal hPrc As Integer, ByVal minSize As Integer, ByVal maxSize As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> _
    Private Function GetCurrentProcess() As Integer
    End Function

    Friend Sub ReduceMemory()
        If P_MEMORY Then
            SetProcessWorkingSetSize(GetCurrentProcess, -1, -1)
        End If
    End Sub

End Module
