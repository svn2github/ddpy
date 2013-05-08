#include <windows.h>

typedef BOOL (WINAPI *LPFN_ISWOW64PROCESS) (HANDLE, PBOOL); 
LPFN_ISWOW64PROCESS fnIsWow64Process = NULL; 

BOOL WINAPI SafeIsWow64Process(HANDLE hProcess, PBOOL Wow64Process) 
{ 
    if (fnIsWow64Process == NULL) { 
        // IsWow64Process is not available on all supported versions of  
        // Windows. Use GetModuleHandle to get a handle to the DLL that  
        // contains the function, and GetProcAddress to get a pointer to the  
        // function if available. 
        HMODULE hModule = GetModuleHandle(L"kernel32.dll"); 
        if (hModule == NULL) { 
            return FALSE; 
        } 
 
        fnIsWow64Process = reinterpret_cast<LPFN_ISWOW64PROCESS>( GetProcAddress(hModule, "IsWow64Process") ); 
        if (fnIsWow64Process == NULL) { 
            return FALSE; 
        } 
    } 
    return fnIsWow64Process(hProcess, Wow64Process); 
} 


// 
//   FUNCTION: Is64BitOS() 
// 
//   PURPOSE: The function determines whether the current operating system is  
//   a 64-bit operating system. 
// 
//   RETURN VALUE: The function returns TRUE if the operating system is  
//   64-bit; otherwise, it returns FALSE. 
// 
BOOL Is64BitOS() 
{ 
#if defined(_WIN64) 
    return TRUE;   // 64-bit programs run only on Win64 
#elif defined(_WIN32) 
    // 32-bit programs run on both 32-bit and 64-bit Windows 
    BOOL f64bitOS = FALSE; 
    return (SafeIsWow64Process(GetCurrentProcess(), &f64bitOS) && f64bitOS); 
#else 
    return FALSE;  // 64-bit Windows does not support Win16 
#endif 
} 


int APIENTRY WinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPSTR     lpCmdLine,
                     int       nCmdShow)
{
    if (Is64BitOS()){
        WinExec("cmd /c msiexec.exe /i DdpyX64.msi_", SW_HIDE);
    }else{
        WinExec("cmd /c msiexec.exe /i DdpyX86.msi_", SW_HIDE);
    }

return 0;
}

