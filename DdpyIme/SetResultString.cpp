#include "stdafx.h"

#define GetLpResultStr(lpcs) (LPTSTR)((LPBYTE)(lpcs) + (lpcs)->dwResultStrOffset)

typedef struct _tagGENEMSG{
    UINT msg;
    WPARAM wParam;
    LPARAM lParam;
} GENEMSG, NEAR *PGENEMSG, FAR *LPGENEMSG;


LPDWORD        lpdwCurTransKey = NULL;
UINT           uNumTransKey;
BOOL           fOverTransKey = FALSE;

#define PARRAYSIZE(array) ((sizeof(array)/sizeof(array[0])))



BOOL GenerateMessageToTransKey(LPDWORD lpdwTransKey, LPGENEMSG lpGeneMsg)
{
	LPDWORD lpdwTemp;
	
	uNumTransKey = 0;
    uNumTransKey++;
    if (uNumTransKey >= (UINT)*lpdwTransKey)
    {
        fOverTransKey = TRUE;
        return FALSE;
    }
	
	lpdwTemp = (LPDWORD)lpdwTransKey + 1 + (uNumTransKey - 1)*3;
	*(lpdwTemp++) = lpGeneMsg->msg;
	*(lpdwTemp++) = lpGeneMsg->wParam;
	*(lpdwTemp++) = lpGeneMsg->lParam;
    return TRUE;
}


BOOL GenerateMessage(HIMC hImc, LPDWORD lpdwTransKey, LPGENEMSG lpGeneMsg)
{
    LPINPUTCONTEXT lpImc;

	if( (lpImc = ImmLockIMC(hImc)) == NULL ) return FALSE;
	
    if (lpdwTransKey){
		ImmUnlockIMC(hImc);
        return GenerateMessageToTransKey(lpdwTransKey,lpGeneMsg);
	}
    
    if (IsWindow(lpImc->hWnd))
    {
        LPDWORD lpdw;
        if (!(lpImc->hMsgBuf = ImmReSizeIMCC(lpImc->hMsgBuf, sizeof(DWORD) * (lpImc->dwNumMsgBuf +1) * 3)))
            return FALSE;
		
        if (!(lpdw = (LPDWORD)ImmLockIMCC(lpImc->hMsgBuf)))
            return FALSE;
		
        lpdw += (lpImc->dwNumMsgBuf) * 3;
        *((LPGENEMSG)lpdw) = *lpGeneMsg;
        ImmUnlockIMCC(lpImc->hMsgBuf);
        lpImc->dwNumMsgBuf++;
		
        ImmGenerateMessage(hImc);
    }
	ImmUnlockIMC(hImc);
    return TRUE;
}


// 字莫太长（22个...）
BOOL SetResult( HIMC hImc, LPCWSTR sResult )
{
    GENEMSG GnMsg;
    LPCOMPOSITIONSTRING lpCompStr;
    LPINPUTCONTEXT lpImc;

    lpImc = ImmLockIMC(hImc);
    lpCompStr = (LPCOMPOSITIONSTRING)ImmLockIMCC(lpImc->hCompStr);

	lstrcpy(GetLpResultStr(lpCompStr), sResult);
	lpCompStr->dwResultStrLen = _tcslen(sResult);

    lpCompStr->dwCompStrLen = 0;
	
	ImmUnlockIMCC(lpImc->hCompStr);
	
	GnMsg.msg = WM_IME_STARTCOMPOSITION;
	GnMsg.wParam = 0;
	GnMsg.lParam = 0;
	GenerateMessage(hImc, lpdwCurTransKey, (LPGENEMSG)&GnMsg);

	GnMsg.msg = WM_IME_COMPOSITION;
	GnMsg.wParam = 0;
	GnMsg.lParam = GCS_RESULTSTR;
	GenerateMessage(hImc, lpdwCurTransKey, (LPGENEMSG)&GnMsg);
	
	GnMsg.msg = WM_IME_ENDCOMPOSITION;
	GnMsg.wParam = 0;
	GnMsg.lParam = 0;
	GenerateMessage(hImc, lpdwCurTransKey, (LPGENEMSG)&GnMsg);
	
    ImmUnlockIMC(hImc);

	lpdwCurTransKey = NULL;

    return TRUE;
}


bool CopyResultString(HIMC hImc, LPCWSTR sResult)
{
    HIMCC               hMem;
    LPCOMPOSITIONSTRING lpCompStr;
    DWORD               dwSize;

    dwSize = sizeof(COMPOSITIONSTRING) +  (_tcslen(sResult) + 1) * sizeof(WORD);

    LPINPUTCONTEXT lpImc = ImmLockIMC(hImc);

    if (!lpImc->hCompStr) {
        lpImc->hCompStr = ImmCreateIMCC(dwSize);
		if (!lpImc->hCompStr) {
			return false;
		}

		lpCompStr = (LPCOMPOSITIONSTRING) ImmLockIMCC(lpImc->hCompStr);
		if (!lpCompStr) {
			return false;
		}
		lpCompStr->dwSize = dwSize;
		ImmUnlockIMCC(lpImc->hCompStr);
	}

	lpCompStr = (LPCOMPOSITIONSTRING) ImmLockIMCC(lpImc->hCompStr);
	if (!lpCompStr) {
		return false;
	}

	if (dwSize > lpCompStr->dwSize) {
		ImmUnlockIMCC(lpImc->hCompStr);
		hMem = ImmReSizeIMCC(lpImc->hCompStr, dwSize);
		if (!hMem) {
			return false;
		}
		if (lpImc->hCompStr != hMem) {
			ImmDestroyIMCC(lpImc->hCompStr);
			lpImc->hCompStr = hMem;
		}

		lpCompStr = (LPCOMPOSITIONSTRING) ImmLockIMCC(lpImc->hCompStr);
		if (!lpCompStr) {
			return false;
		}
		lpCompStr->dwSize = dwSize;
	}

    dwSize = lpCompStr->dwSize;

	memset(lpCompStr, 0, dwSize);
	lpCompStr->dwSize = dwSize;
	lpCompStr->dwResultStrLen = _tcslen(sResult);
	lpCompStr->dwResultStrOffset = sizeof(COMPOSITIONSTRING);
	memcpy((char *)lpCompStr+sizeof(COMPOSITIONSTRING), sResult, _tcslen(sResult) * sizeof(wchar_t));

	ImmUnlockIMCC(lpImc->hCompStr);	
    return true;
}


BOOL SetResultString( HIMC hImc, CComBSTR &sResult)
{
	CopyResultString(hImc, sResult);

	GENEMSG GnMsg;
    
    ImmLockIMC(hImc);
	
	GnMsg.msg = WM_IME_STARTCOMPOSITION;
	GnMsg.wParam = 0;
	GnMsg.lParam = 0;
	GenerateMessage(hImc, lpdwCurTransKey, (LPGENEMSG)&GnMsg);

	GnMsg.msg = WM_IME_COMPOSITION;
	GnMsg.wParam = 0;
	GnMsg.lParam = GCS_RESULT;
	GenerateMessage(hImc, lpdwCurTransKey, (LPGENEMSG)&GnMsg);
	
	GnMsg.msg = WM_IME_ENDCOMPOSITION;
	GnMsg.wParam = 0;
	GnMsg.lParam = 0;
	GenerateMessage(hImc, lpdwCurTransKey, (LPGENEMSG)&GnMsg);
	
    ImmUnlockIMC(hImc);

	lpdwCurTransKey = NULL;

	return TRUE;
}


BOOL SendStartEndMsg( HIMC hImc )
{
    GENEMSG GnMsg;

	GnMsg.msg = WM_IME_STARTCOMPOSITION;
	GnMsg.wParam = 0;
	GnMsg.lParam = 0;
	GenerateMessage(hImc, lpdwCurTransKey, (LPGENEMSG)&GnMsg);

	GnMsg.msg = WM_IME_ENDCOMPOSITION;
	GnMsg.wParam = 0;
	GnMsg.lParam = 0;
	GenerateMessage(hImc, lpdwCurTransKey, (LPGENEMSG)&GnMsg);
	

	lpdwCurTransKey = NULL;

    return TRUE;
}

