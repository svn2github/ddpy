﻿#include "DdpyIme.h"


//#define ARRAY_SIZE(a) (sizeof(a)/sizeof(a[0]))
//


// UI窗口处理程序
LRESULT WINAPI UiWndProc(HWND hWnd,	UINT msg, WPARAM wp, LPARAM lp)
{
    // 处理IME消息
    switch ( msg )
    {
	case WM_IME_NOTIFY:
        // 处理WM_IME_NOTIFY消息
        HnadleImeNotify(wp, lp);

	case WM_IME_STARTCOMPOSITION:
	case WM_IME_ENDCOMPOSITION:
	case WM_IME_COMPOSITION:
	case WM_IME_SETCONTEXT:
	case WM_IME_CONTROL:
	case WM_IME_COMPOSITIONFULL:
	case WM_IME_SELECT:
	case WM_IME_CHAR:
        // IME消息不传给DefWindowProc处理
		return 0;
	default:
	    break;
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
		if (dwFunction == DLL_PROCESS_ATTACH) {
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


// 处理WM_IME_NOTIFY消息
void HnadleImeNotify(WPARAM wp, LPARAM lp)
{

    switch ( wp )
    {
	case IMN_CLOSESTATUSWINDOW:         // 0x0001
	case IMN_OPENSTATUSWINDOW:          // 0x0002
	case IMN_CHANGECANDIDATE:           // 0x0003
	case IMN_CLOSECANDIDATE:            // 0x0004
	case IMN_OPENCANDIDATE:             // 0x0005
	case IMN_SETCONVERSIONMODE:         // 0x0006
	case IMN_SETSENTENCEMODE:           // 0x0007
	case IMN_SETOPENSTATUS:             // 0x0008
	case IMN_SETCANDIDATEPOS:           // 0x0009
	case IMN_SETCOMPOSITIONFONT:        // 0x000A
	case IMN_SETCOMPOSITIONWINDOW:      // 0x000B
	case IMN_SETSTATUSWINDOWPOS:        // 0x000C
	case IMN_GUIDELINE:                 // 0x000D
	case IMN_PRIVATE:                   // 0x000E
        return;


    // -------------- 处理自定义消息 --------------
	case 0x0100:
        break;
    // -------------------------------------------

	default:
        break;
    }

}
