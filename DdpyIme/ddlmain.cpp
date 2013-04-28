#include "DdpyIme.h"


#define ARRAY_SIZE(a) (sizeof(a)/sizeof(a[0]))

long uiHwnd = 0;  // UI窗口句柄

// 判断是否为IME消息
BOOL IsImeMessage(UINT msg)
{
    switch ( msg )
    {
	case WM_IME_STARTCOMPOSITION:
	case WM_IME_ENDCOMPOSITION:
	case WM_IME_COMPOSITION:
	case WM_IME_NOTIFY:
	case WM_IME_SETCONTEXT:
	case WM_IME_CONTROL:
	case WM_IME_COMPOSITIONFULL:
	case WM_IME_SELECT:
	case WM_IME_CHAR:
		return TRUE;
	default:
		return FALSE;
    }
	return FALSE;
}

// UI窗口处理程序
LRESULT WINAPI UiWndProc(HWND hWnd,	UINT msg, WPARAM wp, LPARAM lp)
{
	if (uiHwnd == 0){
		uiHwnd = (long)hWnd;
		ComSetUiHwnd(uiHwnd);
	}

	if ( IsImeMessage(msg) ){
		return 0;
	}

	// 处理COM发来的消息
	if ( msg == 9999 ){

		UINT fldIdex;
		BOOL bValue = FALSE;

		if (wp <=4 ){
			if (wp == 0) fldIdex = 0;
			if (wp == 1) fldIdex = 1;
			if (wp == 2) fldIdex = 2;
			if (wp == 3) fldIdex = 3;
			if (wp == 4) fldIdex = 4;
			if (lp > 0) bValue = TRUE;

			SetFieldValue(fldIdex, bValue);
		}


	}
	
	return DefWindowProc(hWnd, msg, wp, lp);
}

// 注册 UI窗口类
BOOL ImeRegisterClass( HINSTANCE hInst )
{
    WNDCLASSEX wc;
	
    wc.cbSize         = sizeof(WNDCLASSEX);
    wc.style          = CS_IME;
    wc.lpfnWndProc    = UiWndProc;
    wc.cbClsExtra     = 0;
    wc.cbWndExtra     = 2 * sizeof(LONG);
    wc.hInstance      = hInst;
    wc.hCursor        = NULL;
    wc.hIcon          = NULL;
    wc.lpszMenuName   = (LPTSTR)NULL;
    wc.lpszClassName  = UiClsName;
    wc.hbrBackground  = NULL;
    wc.hIconSm        = NULL;
	
    if( !RegisterClassEx(&wc) ){
		ImeError("[ImeRegisterClass] RegisterClassEx Failed");
        return FALSE;
	}

    return TRUE;
}

// 入口函数
BOOL WINAPI DllMain (HINSTANCE hInst, DWORD dwFunction, LPVOID lpNot)
{
	try{
		if (dwFunction == DLL_PROCESS_ATTACH)
		{
			//TCHAR achFileName[MAX_PATH];
			//GetModuleFileNameA(hInst, (LPSTR)achFileName, ARRAY_SIZE(achFileName));
			//ImeInfo((char *)achFileName);

			if (!ComInit()){
				ImeError("[DllMain] ComInit Failed");
				return FALSE;
			}

			return ImeRegisterClass(hInst);		// 注册 UI窗口类

		}else if(dwFunction == DLL_PROCESS_DETACH){
			UnregisterClass(UiClsName, hInst);	// 注销 UI窗口类
		}

		return TRUE;
	}catch(...){
		ImeError("[DllMain] Exception");
		return FALSE;
	}
}

