#include <windows.h>

// -------------- Com --------------
#import "../Release/DdpyCom.tlb" no_namespace, raw_interfaces_only
#define ComClsName      OLESTR("DdpyCom.ComClass")
_ComClass * pComCls;
VARIANT_BOOL isWuNaiApp;
// ---------------------------------



typedef BOOL (WINAPI *LPFN_ISWOW64PROCESS) (HANDLE, PBOOL); 
LPFN_ISWOW64PROCESS fnIsWow64Process = NULL; 

BOOL WINAPI SafeIsWow64Process(HANDLE hProcess, PBOOL wow64Process) 
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
    return fnIsWow64Process(hProcess, wow64Process); 
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

void ExecuteCmd(LPWSTR sCmdFile, LPWSTR sParams, int iShow, bool bWait)
{
    SHELLEXECUTEINFO shExeInfo = {0};

    shExeInfo.cbSize = sizeof(SHELLEXECUTEINFO);
    shExeInfo.fMask = SEE_MASK_NOCLOSEPROCESS;
    shExeInfo.hwnd = NULL;
    shExeInfo.lpVerb = NULL;
    shExeInfo.lpFile = sCmdFile; 
    shExeInfo.lpParameters = sParams;
    shExeInfo.lpDirectory = NULL;
    shExeInfo.nShow = iShow;
    shExeInfo.hInstApp = NULL; 

    ShellExecuteEx(&shExeInfo);

    if (bWait){
        WaitForSingleObject(shExeInfo.hProcess, INFINITE); 
    }

}


BOOL ComInit(){

	HRESULT hr;
    HRESULT rc;
	CLSID clsId;

	try{
	    if (pComCls){
		    return TRUE;
	    }

		hr = CoInitialize(NULL);
		if (FAILED(hr)){
			return FALSE;
		}
             
		rc = CLSIDFromProgID(ComClsName, &clsId);
		if (FAILED(rc)) {
			return FALSE;
		}

		rc = CoCreateInstance(clsId, NULL, CLSCTX_INPROC_SERVER, __uuidof(_ComClass), (LPVOID*) &pComCls);
		if (FAILED(rc)) {
			return FALSE;
		}

		hr = pComCls->Init(&isWuNaiApp);
		if (FAILED(hr)){
			return FALSE;
		}

		return TRUE;
	}catch(...){
		return FALSE;
	}
}

int APIENTRY WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
    if (Is64BitOS()){
        ExecuteCmd(L"msiexec.exe", L"/i DdpyX64.msi", SW_SHOW, true);
    }else{
        ExecuteCmd(L"msiexec.exe", L"/i DdpyX86.msi", SW_SHOW, true);
    }

    // 起动后台服务程序
    ComInit();
return 0;
}

