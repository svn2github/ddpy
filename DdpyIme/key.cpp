#include "stdafx.h"

BOOL isCtrlKeyDown = FALSE;
BOOL isShiftKeyDown = FALSE;
BOOL isInputKeyDown = FALSE;

BOOL isInputStart = FALSE;

bool isCnMode = true;
//BOOL isFullMode = FALSE;
//BOOL isBdMode = TRUE;
//
//bool isLeftQte = true;
//bool isDot = false;
//

SYSTEMTIME timeStart;
bool isOpenImeKey = true;


BOOL HandleImeKeys(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState){
	try{
		ComDebug(L" [HandleImeKeys] 调用 COM 处理开始");

		
		if (!isInputStart && IsNeedSendStartEndMsg()){
			ImeDebug(" IsNeedSendStartEndMsg");
			SendStartEndMsg(hImc); // 无奈的无奈
		}


		ImeKeyResult ikr = {};
		GetPositionInfo(hImc, ikr);
		CComBSTR sResult = NULL;
		if ( !ComImeProcessKey(iKey, &ikr, &sResult) ){
			ComDebug(L" 调用失败：ComImeProcessKey");
			return FALSE;
		}

		if (!ikr.IsProcessKey){
			isInputStart = false;
		}else if(ikr.IsInputEnd){
			isInputStart = false;
		}else{
			isInputStart = ikr.IsInputStart;
		}

		if (!ikr.IsProcessKey){		// 不响应的按键
			ComDebug(L" 由 COM 交还系统处理的按键");
			return FALSE;
		}

		if (ikr.IsInputEnd){			// 编码输入结束
			ComDebug(L" 上屏字符串:");
			ComDebug(sResult);

			SetResultString(hImc, sResult);
		}
		sResult.Empty();

		ComDebug(L" 调用 COM 处理结束");
		return TRUE;
	}catch(...){
		ImeError("[HandleImeKeys] Exception");
		return FALSE;
	}
}

BOOL HandleNotImeKeys(UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState){

	switch (iKey)
	{
	case VK_F1:
	case VK_F2:
	case VK_F3:
	case VK_F4:
	case VK_F5:
	case VK_F6:
	case VK_F7:
	case VK_F8:
	case VK_F9:
	case VK_F10:
	case VK_F11:
	case VK_F12:
	case VK_PRINT:
	case VK_SCROLL:
	case VK_PAUSE:
	case VK_CAPITAL:
	case VK_INSERT:
	case VK_NUMLOCK:
		ComDebug(L" 不处理的按键（按各功能键）");
		return FALSE;
	default:
		break;
	}


	return TRUE;
}

BOOL HandleCtrlShiftKey(UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState){

	ComDebug(L"HandleCtrlShiftKey");

	if ( lpKeyData & 0x80000000 ) {
		if ( (iKey == VK_SHIFT) ){
			ComDebug(L" Shift键松开");
			isShiftKeyDown = FALSE;			// Shift键松开

			// 单按Shift键进行中英切换
			if ( !IsOpenImeKey() && !isInputKeyDown ){
				if (isCnMode){
					isCnMode = FALSE;
					ComShowStatusText(1, L"英");
				}else{
					isCnMode = TRUE;
					ComShowStatusText(1, L"中");
				}

				isInputStart = FALSE;
				isInputKeyDown = FALSE;
				return TRUE;
			}

			isInputKeyDown = FALSE;
		}

		if (iKey == VK_CONTROL){
			ComDebug(L" Ctrl键松开");
			isCtrlKeyDown = FALSE;		// Ctrl键松开
		}

		ComDebug(L" 按键松开不作处理");
		return FALSE;
	}


	if ( (iKey == VK_CONTROL) ){
		ComDebug(L" Ctrl键按下, 不作处理");
		isCtrlKeyDown = TRUE;			// Ctrl键按下
		return FALSE;
	}
	if ( isCtrlKeyDown ){
		ComDebug(L" 带Ctrl的组合键，不作处理");
		return FALSE;
	}
	if (lpbKeyState[VK_MENU] & 0x80 ){
		ComDebug(L"ALT键？不作处理");
		return FALSE;
	}

	if ( (iKey == VK_SHIFT) ){
		ComDebug(L" Shift键按下不作处理");
		isShiftKeyDown = TRUE;			// Shift键按下
		return FALSE;
	}

	return TRUE;
}


BOOL HandleCaptialKey(UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState){

	isInputStart = FALSE;

	if (isCnMode){
		ComShowStatusText(1, L"中");
	}else{
		ComShowStatusText(1, L"英");
	}

	return FALSE;	// CAPITAL按下时不处理
}


BOOL HandleKeys(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState){

	ComDebug(L"[IME] HandleKeys -----------");

	if (!HandleCtrlShiftKey(iKey, lpKeyData, lpbKeyState)){
		return FALSE;
	}


	if (isShiftKeyDown){
		isInputKeyDown = TRUE;
	}

	if ( iKey==VK_CAPITAL){
		if (!HandleCaptialKey(iKey, lpKeyData, lpbKeyState)){
			return FALSE;
		}
	}

	if (!HandleNotImeKeys(iKey, lpKeyData, lpbKeyState)){
		return FALSE;
	}
	
	return HandleImeKeys(hImc, iKey, lpKeyData, lpbKeyState);
}



BOOL IsOpenImeKey(){

	if (!isOpenImeKey){
		return FALSE;
	}

	SYSTEMTIME timeNow; 
	GetLocalTime( &timeNow );

	// 计时，麻烦的C++
	long lStart = timeStart.wDay * 24 * 60 * 60 * 1000 + timeStart.wHour * 60 * 60 * 1000 + timeStart.wMinute * 60 * 1000 + timeStart.wSecond * 1000 + timeStart.wMilliseconds;
	long lNow = timeNow.wDay * 24 * 60 * 60 * 1000 + timeNow.wHour * 60 * 60 * 1000 + timeNow.wMinute * 60 * 1000 + timeNow.wSecond * 1000 + timeNow.wMilliseconds;
	
	if ( (lNow - lStart)<1000 ){
		isOpenImeKey = true;
	}else{
		isOpenImeKey = false;
	}

	return isOpenImeKey;
}



BOOL SetFieldValue(UINT fldIdex, BOOL bValue)
{
	ComDebug(L" -------- SetFieldValue --------- ");
	try{

		if (fldIdex == 0){
			// 全部初始化
			isCtrlKeyDown = FALSE;
			isShiftKeyDown = FALSE;
			isInputKeyDown = FALSE;

			isInputStart = FALSE;

			isCnMode = true;
			//isFullMode = FALSE;
			//isBdMode = TRUE;

			//isLeftQte = true;
			//isDot = false;
			ComDebug(L" SetFieldValue 全部初始化");
		}else if (fldIdex == 1){
			isCnMode = bValue;
			if (isCnMode){
				ComDebug(L" isCnMode");
			}else{
				ComDebug(L" ! isCnMode");
			}

		}else if (fldIdex == 2){
			//isFullMode = bValue;
			//if (isFullMode){
			//	ComDebug(L" isFullMode");
			//}else{
			//	ComDebug(L" ! isFullMode");
			//}

		}else if (fldIdex == 3){
			//isBdMode = bValue;
			//if (isBdMode){
			//	ComDebug(L" isBdMode");
			//}else{
			//	ComDebug(L" ! isBdMode");
			//}

		}else if (fldIdex == 4){
			isInputStart = bValue;
			if (isInputStart){
				ComDebug(L" isInputStart");
			}else{
				ComDebug(L" ! isInputStart");
			}

		}else{
			return FALSE;
			ComDebug(L" SetFieldValue Do Nothing");
		}


		return TRUE;

	}catch(...){
		ImeError("[SetFieldValue] Exception");
		return FALSE;
	}
}


void ResetMode(){

	ComDebug(L" ResetMode()");
	SetFieldValue(0, false);

	isOpenImeKey = true;
	GetLocalTime( &timeStart );
}

