#include "DdpyIme.h"

BOOL isInputStart = FALSE;

BOOL HandleImeKeys(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState){
	try{
		ComDebug(L" [HandleImeKeys] 调用 COM 处理开始");

        // 无奈的无奈
        if (!isInputStart && isWuNaiApp){
			SendStartEndMsg(hImc);
		}


        // 调用COM处理
		ImeKeyResult ikr = {};
		GetPositionInfo(hImc, ikr);
		CComBSTR sResult = NULL;

		if ( !ComImeProcessKey(iKey, &ikr, &sResult) ){
    		//return FALSE;    // 失败时交还系统处理
    		return TRUE;    // 失败时不处理
		}

		if (!ikr.IsProcessKey || ikr.IsInputEnd){
			isInputStart = FALSE;
		}else{
			isInputStart = ikr.IsInputStart;
		}


        // COM中不响应的按键
		if (!ikr.IsProcessKey){
			return FALSE;
		}

        // 编码输入结束时，上屏
		if (ikr.IsInputEnd){
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


BOOL HandleKeys(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState){

    if ( lpKeyData & 0x80000000 ) {
        // 处理Ctrl、Shift松开，其他按键松开不处理
        if ( (iKey != VK_CONTROL) && (iKey != VK_SHIFT) ) {
            return FALSE; 
        }
    }else{
        // 不处理Ctrl、Shift按下，其他按键按下调用COM处理
        if ( (iKey == VK_CONTROL) || (iKey == VK_SHIFT) ) {
            return FALSE; 
        }
    }


	return HandleImeKeys(hImc, iKey, lpKeyData, lpbKeyState);
}

