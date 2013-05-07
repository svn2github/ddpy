#include <windows.h>

typedef BOOL (WINAPI *LPFN_ISWOW64PROCESS) (HANDLE, PBOOL);
LPFN_ISWOW64PROCESS  fnIsWow64Process = (LPFN_ISWOW64PROCESS)GetProcAddress( GetModuleHandle( L"kernel32 "), "IsWow64Process");

BOOL IsWow64()
{
    BOOL   bIsWow64   =   FALSE; 
    if (NULL != fnIsWow64Process) {
	    if ( !fnIsWow64Process(GetCurrentProcess(),&bIsWow64) ) {
	        // error
	    }
    } 
    return   bIsWow64;
} 

int APIENTRY WinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPSTR     lpCmdLine,
                     int       nCmdShow)
{

    if (IsWow64()){
        WinExec("C:/WINDOWS/system32/msiexec.exe /i DdpyX64.msi_", SW_SHOW);
    }else{
        WinExec("C:/WINDOWS/system32/msiexec.exe /i DdpyX86.msi_", SW_SHOW);
    }

return 0;
}

