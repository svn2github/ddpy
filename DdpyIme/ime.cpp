#include "stdafx.h"

static bool isWinlogon = false;


BOOL WINAPI ImeProcessKey(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState)
{
	if (isWinlogon) return FALSE;

	try{
		return HandleKeys(hImc, iKey, lpKeyData, lpbKeyState);
	}catch(...){
		ImeError("[ImeProcessKey] Exception");
		return FALSE;
	}
}


BOOL WINAPI ImeInquire(LPIMEINFO lpImeInfo, LPTSTR lpszUiCls, DWORD dwSystemInfoFlags)
{
	if ( !lpImeInfo || !lpszUiCls){
		ImeError("[ImeInquire] !lpImeInfo || !lpszUiCls");
		return FALSE;
	}

	isWinlogon	= ((dwSystemInfoFlags & IME_SYSINFO_WINLOGON) != 0) ;


	try{
		lstrcpy(lpszUiCls, UiClsName);

		lpImeInfo->dwPrivateDataSize = 0;
		lpImeInfo->fdwProperty = IME_PROP_UNICODE | IME_PROP_SPECIAL_UI | IME_PROP_END_UNLOAD;
		lpImeInfo->fdwConversionCaps = IME_CMODE_FULLSHAPE | IME_CMODE_NATIVE;
		lpImeInfo->fdwSentenceCaps = IME_SMODE_NONE;
		lpImeInfo->fdwUICaps = UI_CAP_2700;
		lpImeInfo->fdwSCSCaps = 0;
		lpImeInfo->fdwSelectCaps = SELECT_CAP_CONVERSION;

		return TRUE;
	}catch(...){
		ImeError("[ImeInquire] Exception");
		return FALSE;
	}
}

BOOL WINAPI ImeSelect(HIMC hImc, BOOL bSelect)
{
	if (isWinlogon) return TRUE;

	try{
		ResetMode();

		return ComImeSelect(bSelect);
	}catch(...){
		ImeError("[ImeSelect] Exception");
		return FALSE;
	}
}

BOOL WINAPI ImeSetActiveContext(HIMC hImc, BOOL bFlag)
{
	if (isWinlogon) return TRUE;

	try{
		return ComImeSetActiveContext(bFlag);
	}catch(...){
		ImeError("[ImeSetActiveContext] Exception");
		return FALSE;
	}
}

UINT WINAPI ImeToAsciiEx(UINT uVKey, UINT uScanCode, CONST LPBYTE lpbKeyState, LPDWORD lpdwTransKey, UINT fuState, HIMC hImc)
{
    return 0;
}

BOOL WINAPI ImeConfigure(HKL hKL,HWND hWnd, DWORD dwMode, LPVOID lpData)
{
	if (isWinlogon) return TRUE;

	return ComImeConfigure();
}

DWORD WINAPI ImeConversionList(HIMC hIMC,LPCTSTR lpSource,LPCANDIDATELIST lpCandList,DWORD dwBufLen,UINT uFlag)
{
    return FALSE;
}

BOOL WINAPI ImeDestroy(UINT uForce)
{
    return FALSE;
}

LRESULT WINAPI ImeEscape(HIMC hIMC,UINT uSubFunc,LPVOID lpData)
{
	return FALSE;
}

BOOL WINAPI NotifyIME(HIMC hImc, DWORD dwAction, DWORD dwIndex, DWORD dwValue)
{
	return FALSE;
}

BOOL WINAPI ImeRegisterWord(LPCTSTR lpRead, DWORD dw, LPCTSTR lpStr)
{
    return FALSE;
}

BOOL WINAPI ImeUnregisterWord(LPCTSTR lpRead, DWORD dw, LPCTSTR lpStr)
{
    return FALSE;
}

UINT WINAPI ImeGetRegisterWordStyle(UINT nItem, LPSTYLEBUF lp)
{
	return 0;
}

UINT WINAPI ImeEnumRegisterWord(REGISTERWORDENUMPROC lpfn, LPCTSTR lpRead, DWORD dw, LPCTSTR lpStr, LPVOID lpData)
{
	return 0;
}

BOOL WINAPI ImeSetCompositionString(HIMC hImc, DWORD dwIndex, LPCVOID lpComp, DWORD dwComp, LPCVOID lpRead, DWORD dwRead)
{
    return FALSE;
}

