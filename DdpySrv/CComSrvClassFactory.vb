Imports System.Runtime.InteropServices

''' <summary>
''' 淡定拼音输入法后台服务COM工厂类
''' </summary>
Public Class CComSrvClassFactory
    Implements IClassFactory

    Public Shared comSrv As ComClass


    Public Function CreateInstance(ByVal pUnkOuter As IntPtr, ByRef riid As Guid, _
                                   <Out()> ByRef ppvObject As IntPtr) As Integer _
                                   Implements IClassFactory.CreateInstance
        ppvObject = IntPtr.Zero

        If (pUnkOuter <> IntPtr.Zero) Then
            ' The pUnkOuter parameter was non-NULL and the object does 
            ' not support aggregation.
            Marshal.ThrowExceptionForHR(COMNative.CLASS_E_NOAGGREGATION)
        End If

        If ((riid = New Guid(ComClass.ClassId)) OrElse _
            (riid = New Guid(COMNative.IID_IDispatch)) OrElse _
            (riid = New Guid(COMNative.IID_IUnknown))) Then


            ' Create the instance of the .NET object

            ' 实际运行用
            'If comSrv Is Nothing Then
            '    comSrv = New ComClass
            'End If
            'ppvObject = Marshal.GetComInterfaceForObject(comSrv, GetType(ComClass).GetInterface("_ComClass"))

            ' 开发用
            ppvObject = Marshal.GetComInterfaceForObject(New ComClass, GetType(ComClass).GetInterface("_ComClass"))

        Else
            ' The object that ppvObject points to does not support the 
            ' interface identified by riid.
            Marshal.ThrowExceptionForHR(COMNative.E_NOINTERFACE)
        End If


        Return 0  ' S_OK
    End Function


    Public Function LockServer(ByVal fLock As Boolean) As Integer _
    Implements IClassFactory.LockServer
        Return 0  ' S_OK
    End Function

End Class
