#include "stdafx.h"

BOOL isCtrlKeyDown = FALSE;
BOOL isShiftKeyDown = FALSE;
BOOL isInputKeyDown = FALSE;

BOOL isInputStart = FALSE;

BOOL isCnMode = TRUE;
BOOL isFullMode = FALSE;
BOOL isBdMode = TRUE;

bool isLeftQte = true;
bool isDot = false;


SYSTEMTIME timeStart;
bool isOpenImeKey = true;


BOOL HandleImeKeys(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState){
	try{
		ComDebug(L" [HandleImeKeys] 调用 COM 处理开始");

		
		if (!isInputStart && IsNeedSendStartEndMsg()){
			ComDebug(L" 无奈的无奈");
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

	if (isInputStart){
		ComDebug(L" isInputStart....");

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

		case VK_TAB:
			//return TRUE;
		case VK_CAPITAL:

		case VK_INSERT:
		case VK_END:
		case VK_HOME:

		case VK_NUMLOCK:
			ComDebug(L" 不处理的按键（按各功能键）");
			return FALSE;
		
		default:
			break;
		}

	}else{

		ComDebug(L" NOT isInputStart....");
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

		case VK_TAB:
		case VK_CAPITAL:

		case VK_BACK:
		case VK_RETURN:

		case VK_INSERT:
		case VK_DELETE:
		case VK_END:
		case VK_HOME:

		case VK_LEFT:
		case VK_RIGHT:
		case VK_UP:
		case VK_DOWN:

		case VK_NUMLOCK:
		//case VK_NUMPAD0:
		//case VK_NUMPAD1:
		//case VK_NUMPAD2:
		//case VK_NUMPAD3:
		//case VK_NUMPAD4:
		//case VK_NUMPAD5:
		//case VK_NUMPAD6:
		//case VK_NUMPAD7:
		//case VK_NUMPAD8:
		//case VK_NUMPAD9:
		//case VK_MULTIPLY:
		//case VK_ADD:
		//case VK_SEPARATOR:
		//case VK_SUBTRACT:
		//case VK_DECIMAL:
			ComDebug(L" 不处理的按键（按各功能键）");
			return FALSE;
		default:
			break;
		}

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

// 愚公移山
BOOL HandleConverterChar(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState){

	if (isCnMode){
		ComDebug(L" isCnMode");
	}else{
		ComDebug(L" ! isCnMode");
	}
	if (isFullMode){
		ComDebug(L" isFullMode");
	}else{
		ComDebug(L" ! isFullMode");
	}
	if (isBdMode){
		ComDebug(L" isBdMode");
	}else{
		ComDebug(L" ! isBdMode");
	}




	if (isCnMode){
		// CN

		if (isFullMode){
			// CN Full

			if (iKey == 192){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"｀" : L"～") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"`" : L"~") );
				}

			}else if (iKey == 48){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"０" : L"）") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"０" : L")") );
				}
			}else if (iKey == 49){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"１" : L"！") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"１" : L"!") );
				}
			}else if (iKey == 50){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"２" : L"＠") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"２" : L"@") );
				}
			}else if (iKey == 51){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"３" : L"＃") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"３" : L"#") );
				}
			}else if (iKey == 52){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"４" : L"￥") );  // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"４" : L"$") );  // ...
				}
			}else if (iKey == 53){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"５" : L"％") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"５" : L"%") );
				}
			}else if (iKey == 54){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"６" : L"……") );  // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"６" : L"^") );  // ...
				}
			}else if (iKey == 55){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"７" : L"＆") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"７" : L"&") );
				}
			}else if (iKey == 56){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"８" : L"×") );  // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"８" : L"*") );  // ...
				}
			}else if (iKey == 57){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"９" : L"（") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"９" : L"(") );
				}


			}else if (iKey == 189){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"－" : L"——") );  // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"－" : L"_") );  // ...
				}
			}else if (iKey == 187){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"＝" : L"＋") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"＝" : L"＋") );
				}
			}else if (iKey == 220){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"、" : L"｜") ); // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"＼" : L"｜") ); // ...
				}

			}else if (iKey == 219){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"【" : L"｛") ); // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"［" : L"｛") ); // ...
				}
			}else if (iKey == 221){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"】" : L"｝") ); // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"］" : L"｝") ); // ...
				}

			}else if (iKey == 186){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"；" : L"：") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"；" : L"：") );
				}
			}else if (iKey == 222){

				if (isBdMode){
					if (isLeftQte){
						SetResult(hImc, (!isShiftKeyDown? L"‘" : L"“") ); // .............
					}else{
						SetResult(hImc, (!isShiftKeyDown? L"’" : L"”") ); // .............
					}
					isLeftQte = !isLeftQte;
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"＇" : L"＂") ); // .............
				}


			}else if (iKey == 188){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"，" : L"《") ); // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"，" : L"＜") ); // ...
				}
			}else if (iKey == 190){

				if (isBdMode){
					if (isDot){
						SetResult(hImc, (!isShiftKeyDown? L"." : L"》") ); // ...
						isDot = false;
					}else{
						SetResult(hImc, (!isShiftKeyDown? L"。" : L"》") ); // ...
					}
				}else{
					if (isDot){
						SetResult(hImc, (!isShiftKeyDown? L"." : L"＞") ); // ...
						isDot = false;
					}else{
						SetResult(hImc, (!isShiftKeyDown? L"．" : L"＞") ); // ...
					}
				}


			}else if (iKey == 191){
				SetResult(hImc, (!isShiftKeyDown? L"／" : L"？") );

			}else if (iKey == 32){
				SetResult(hImc, L"　" );


			}else{
				ComDebug(L"不做全角转换的按键（包括小键盘）");
				return FALSE;
			}

		}else{
			// CN !Full
			if (iKey == 192){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"·" : L"～") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"`" : L"~") );
				}

			}else if (iKey == 48){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"0" : L"）") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"0" : L")") );
				}
			}else if (iKey == 49){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"1" : L"！") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"1" : L"!") );
				}
			}else if (iKey == 50){
				SetResult(hImc, (!isShiftKeyDown? L"2" : L"@") );
			}else if (iKey == 51){
				SetResult(hImc, (!isShiftKeyDown? L"3" : L"#") );
			}else if (iKey == 52){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"4" : L"￥") );  // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"4" : L"$") );  // ...
				}
			}else if (iKey == 53){
				SetResult(hImc, (!isShiftKeyDown? L"5" : L"%") );
			}else if (iKey == 54){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"6" : L"……") );  // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"6" : L"^") );  // ...
				}
			}else if (iKey == 55){
				SetResult(hImc, (!isShiftKeyDown? L"7" : L"&") );
			}else if (iKey == 56){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"8" : L"×") );  // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"8" : L"*") );  // ...
				}
			}else if (iKey == 57){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"9" : L"（") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"9" : L"(") );
				}


			}else if (iKey == 189){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"-" : L"——") );  // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"-" : L"_") );  // ...
				}
			}else if (iKey == 187){
				SetResult(hImc, (!isShiftKeyDown? L"=" : L"+") );
			}else if (iKey == 220){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"、" : L"|") ); // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"\\" : L"|") ); // ...
				}

			}else if (iKey == 219){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"【" : L"『") ); // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"[" : L"{") ); // ...
				}
			}else if (iKey == 221){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"】" : L"』") ); // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"]" : L"}") ); // ...
				}

			}else if (iKey == 186){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"；" : L"：") );
				}else{
					SetResult(hImc, (!isShiftKeyDown? L";" : L":") );
				}
			}else if (iKey == 222){

				if (isBdMode){
					if (isLeftQte){
						SetResult(hImc, (!isShiftKeyDown? L"‘" : L"“") ); // .............
					}else{
						SetResult(hImc, (!isShiftKeyDown? L"’" : L"”") ); // .............
					}
					isLeftQte = !isLeftQte;
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"'" : L"\"") ); // .............
				}


			}else if (iKey == 188){
				if (isBdMode){
					SetResult(hImc, (!isShiftKeyDown? L"，" : L"《") ); // ...
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"," : L"<") ); // ...
				}
			}else if (iKey == 190){

				if (isBdMode){
					if (isDot){
						SetResult(hImc, (!isShiftKeyDown? L"." : L"》") ); // ...
						isDot = false;
					}else{
						SetResult(hImc, (!isShiftKeyDown? L"。" : L"》") ); // ...
					}
				}else{
					SetResult(hImc, (!isShiftKeyDown? L"." : L">") ); // ...
				}


			}else if (iKey == 191){
				SetResult(hImc, (!isShiftKeyDown? L"/" : L"?") );

			}else if (iKey == 32){
				SetResult(hImc, L" " );


			}else{
				ComDebug(L"不做转换的按键（包括小键盘）");
				return FALSE;
			}

		}



	}else{
		// EN

		if (!isFullMode){
			ComDebug(L"英文半角模式，不转换");
			return FALSE;
		}

		if (iKey == 192){
			SetResult(hImc, (!isShiftKeyDown? L"｀" : L"～") );

		}else if (iKey == 48){
			SetResult(hImc, (!isShiftKeyDown? L"０" : L"）") );
		}else if (iKey == 49){
			SetResult(hImc, (!isShiftKeyDown? L"１" : L"！") );
		}else if (iKey == 50){
			SetResult(hImc, (!isShiftKeyDown? L"２" : L"＠") );
		}else if (iKey == 51){
			SetResult(hImc, (!isShiftKeyDown? L"３" : L"＃") );
		}else if (iKey == 52){
			SetResult(hImc, (!isShiftKeyDown? L"４" : L"＄") );
		}else if (iKey == 53){
			SetResult(hImc, (!isShiftKeyDown? L"５" : L"％") );
		}else if (iKey == 54){
			SetResult(hImc, (!isShiftKeyDown? L"６" : L"＾") );
		}else if (iKey == 55){
			SetResult(hImc, (!isShiftKeyDown? L"７" : L"＆") );
		}else if (iKey == 56){
			SetResult(hImc, (!isShiftKeyDown? L"８" : L"＊") );
		}else if (iKey == 57){
			SetResult(hImc, (!isShiftKeyDown? L"９" : L"（") );


		}else if (iKey == 189){
			SetResult(hImc, (!isShiftKeyDown? L"－" : L"＿") );
		}else if (iKey == 187){
			SetResult(hImc, (!isShiftKeyDown? L"＝" : L"＋") );
		}else if (iKey == 220){
			SetResult(hImc, (!isShiftKeyDown? L"＼" : L"｜") );

		}else if (iKey == 219){
			SetResult(hImc, (!isShiftKeyDown? L"［" : L"｛") );
		}else if (iKey == 221){
			SetResult(hImc, (!isShiftKeyDown? L"］" : L"｝") );

		}else if (iKey == 186){
			SetResult(hImc, (!isShiftKeyDown? L"；" : L"：") );
		}else if (iKey == 222){
			SetResult(hImc, (!isShiftKeyDown? L"＇" : L"＂") );

		}else if (iKey == 188){
			SetResult(hImc, (!isShiftKeyDown? L"，" : L"＜") );
		}else if (iKey == 190){
			SetResult(hImc, (!isShiftKeyDown? L"．" : L"＞") );
		}else if (iKey == 191){
			SetResult(hImc, (!isShiftKeyDown? L"／" : L"？") );


		}else if (iKey == 65){
			SetResult(hImc, (isShiftKeyDown? L"Ａ" : L"ａ") );
		}else if (iKey == 66){
			SetResult(hImc, (isShiftKeyDown? L"Ｂ" : L"ｂ") );
		}else if (iKey == 67){
			SetResult(hImc, (isShiftKeyDown? L"Ｃ" : L"ｃ") );
		}else if (iKey == 68){
			SetResult(hImc, (isShiftKeyDown? L"Ｄ" : L"ｄ") );
		}else if (iKey == 69){
			SetResult(hImc, (isShiftKeyDown? L"Ｅ" : L"ｅ") );
		}else if (iKey == 70){
			SetResult(hImc, (isShiftKeyDown? L"Ｆ" : L"ｆ") );
		}else if (iKey == 71){
			SetResult(hImc, (isShiftKeyDown? L"Ｇ" : L"ｇ") );
		}else if (iKey == 72){
			SetResult(hImc, (isShiftKeyDown? L"Ｈ" : L"ｈ") );
		}else if (iKey == 73){
			SetResult(hImc, (isShiftKeyDown? L"Ｉ" : L"ｉ") );
		}else if (iKey == 74){
			SetResult(hImc, (isShiftKeyDown? L"Ｊ" : L"ｊ") );
		}else if (iKey == 75){
			SetResult(hImc, (isShiftKeyDown? L"Ｋ" : L"ｋ") );
		}else if (iKey == 76){
			SetResult(hImc, (isShiftKeyDown? L"Ｌ" : L"ｌ") );
		}else if (iKey == 77){
			SetResult(hImc, (isShiftKeyDown? L"Ｍ" : L"ｍ") );
		}else if (iKey == 78){
			SetResult(hImc, (isShiftKeyDown? L"Ｎ" : L"ｎ") );
		}else if (iKey == 79){
			SetResult(hImc, (isShiftKeyDown? L"Ｏ" : L"ｏ") );
		}else if (iKey == 80){
			SetResult(hImc, (isShiftKeyDown? L"Ｐ" : L"ｐ") );
		}else if (iKey == 81){
			SetResult(hImc, (isShiftKeyDown? L"Ｑ" : L"ｑ") );
		}else if (iKey == 82){
			SetResult(hImc, (isShiftKeyDown? L"Ｒ" : L"ｒ") );
		}else if (iKey == 83){
			SetResult(hImc, (isShiftKeyDown? L"Ｓ" : L"ｓ") );
		}else if (iKey == 84){
			SetResult(hImc, (isShiftKeyDown? L"Ｔ" : L"ｔ") );
		}else if (iKey == 85){
			SetResult(hImc, (isShiftKeyDown? L"Ｕ" : L"ｕ") );
		}else if (iKey == 86){
			SetResult(hImc, (isShiftKeyDown? L"Ｖ" : L"ｖ") );
		}else if (iKey == 87){
			SetResult(hImc, (isShiftKeyDown? L"Ｗ" : L"ｗ") );
		}else if (iKey == 88){
			SetResult(hImc, (isShiftKeyDown? L"Ｘ" : L"ｘ") );
		}else if (iKey == 89){
			SetResult(hImc, (isShiftKeyDown? L"Ｙ" : L"ｙ") );
		}else if (iKey == 90){
			SetResult(hImc, (isShiftKeyDown? L"Ｚ" : L"ｚ") );

		}else if (iKey == 32){
			SetResult(hImc, L"　" );

		}else{
			ComDebug(L"不做全角转换的按键（包括小键盘）");
			return FALSE;
		}


	}

	ComDebug(L" C++中立马转换");
	return TRUE;

}

// 老实做也会有收获
BOOL ConvertFullChar(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState){


	if (GetKeyState(VK_CAPITAL) && !isFullMode && !isBdMode){
		ComDebug(L"大写半角非标点模式，按键不作处理");
		return FALSE;
	}
	if (!GetKeyState(VK_CAPITAL) && !isCnMode  && !isFullMode){
		ComDebug(L"小写英文Half模式，按键不作处理");
		return FALSE;
	}


	if (isFullMode){
		if (iKey == 192){
			SetResult(hImc, (!isShiftKeyDown? L"｀" : L"～") );

		}else if (iKey == 48){
			SetResult(hImc, (!isShiftKeyDown? L"０" : L"）") );
		}else if (iKey == 49){
			SetResult(hImc, (!isShiftKeyDown? L"１" : L"！") );
		}else if (iKey == 50){
			SetResult(hImc, (!isShiftKeyDown? L"２" : L"＠") );
		}else if (iKey == 51){
			SetResult(hImc, (!isShiftKeyDown? L"３" : L"＃") );
		}else if (iKey == 52){
			SetResult(hImc, (!isShiftKeyDown? L"４" : L"＄") );
		}else if (iKey == 53){
			SetResult(hImc, (!isShiftKeyDown? L"５" : L"％") );
		}else if (iKey == 54){
			SetResult(hImc, (!isShiftKeyDown? L"６" : L"＾") );
		}else if (iKey == 55){
			SetResult(hImc, (!isShiftKeyDown? L"７" : L"＆") );
		}else if (iKey == 56){
			SetResult(hImc, (!isShiftKeyDown? L"８" : L"＊") );
		}else if (iKey == 57){
			SetResult(hImc, (!isShiftKeyDown? L"９" : L"（") );


		}else if (iKey == 189){
			SetResult(hImc, (!isShiftKeyDown? L"－" : L"＿") );
		}else if (iKey == 187){
			SetResult(hImc, (!isShiftKeyDown? L"＝" : L"＋") );
		}else if (iKey == 220){
			SetResult(hImc, (!isShiftKeyDown? L"＼" : L"｜") );

		}else if (iKey == 219){
			SetResult(hImc, (!isShiftKeyDown? L"［" : L"｛") );
		}else if (iKey == 221){
			SetResult(hImc, (!isShiftKeyDown? L"］" : L"｝") );

		}else if (iKey == 186){
			SetResult(hImc, (!isShiftKeyDown? L"；" : L"：") );
		}else if (iKey == 222){
			SetResult(hImc, (!isShiftKeyDown? L"＇" : L"＂") );

		}else if (iKey == 188){
			SetResult(hImc, (!isShiftKeyDown? L"，" : L"＜") );
		}else if (iKey == 190){
			SetResult(hImc, (!isShiftKeyDown? L"．" : L"＞") );
		}else if (iKey == 191){
			SetResult(hImc, (!isShiftKeyDown? L"／" : L"？") );


		}else if (iKey == 65){
			SetResult(hImc, (!isShiftKeyDown? L"Ａ" : L"ａ") );
		}else if (iKey == 66){
			SetResult(hImc, (!isShiftKeyDown? L"Ｂ" : L"ｂ") );
		}else if (iKey == 67){
			SetResult(hImc, (!isShiftKeyDown? L"Ｃ" : L"ｃ") );
		}else if (iKey == 68){
			SetResult(hImc, (!isShiftKeyDown? L"Ｄ" : L"ｄ") );
		}else if (iKey == 69){
			SetResult(hImc, (!isShiftKeyDown? L"Ｅ" : L"ｅ") );
		}else if (iKey == 70){
			SetResult(hImc, (!isShiftKeyDown? L"Ｆ" : L"ｆ") );
		}else if (iKey == 71){
			SetResult(hImc, (!isShiftKeyDown? L"Ｇ" : L"ｇ") );
		}else if (iKey == 72){
			SetResult(hImc, (!isShiftKeyDown? L"Ｈ" : L"ｈ") );
		}else if (iKey == 73){
			SetResult(hImc, (!isShiftKeyDown? L"Ｉ" : L"ｉ") );
		}else if (iKey == 74){
			SetResult(hImc, (!isShiftKeyDown? L"Ｊ" : L"ｊ") );
		}else if (iKey == 75){
			SetResult(hImc, (!isShiftKeyDown? L"Ｋ" : L"ｋ") );
		}else if (iKey == 76){
			SetResult(hImc, (!isShiftKeyDown? L"Ｌ" : L"ｌ") );
		}else if (iKey == 77){
			SetResult(hImc, (isShiftKeyDown? L"Ｍ" : L"ｍ") );
		}else if (iKey == 78){
			SetResult(hImc, (!isShiftKeyDown? L"Ｎ" : L"ｎ") );
		}else if (iKey == 79){
			SetResult(hImc, (!isShiftKeyDown? L"Ｏ" : L"ｏ") );
		}else if (iKey == 80){
			SetResult(hImc, (!isShiftKeyDown? L"Ｐ" : L"ｐ") );
		}else if (iKey == 81){
			SetResult(hImc, (!isShiftKeyDown? L"Ｑ" : L"ｑ") );
		}else if (iKey == 82){
			SetResult(hImc, (!isShiftKeyDown? L"Ｒ" : L"ｒ") );
		}else if (iKey == 83){
			SetResult(hImc, (!isShiftKeyDown? L"Ｓ" : L"ｓ") );
		}else if (iKey == 84){
			SetResult(hImc, (!isShiftKeyDown? L"Ｔ" : L"ｔ") );
		}else if (iKey == 85){
			SetResult(hImc, (!isShiftKeyDown? L"Ｕ" : L"ｕ") );
		}else if (iKey == 86){
			SetResult(hImc, (!isShiftKeyDown? L"Ｖ" : L"ｖ") );
		}else if (iKey == 87){
			SetResult(hImc, (!isShiftKeyDown? L"Ｗ" : L"ｗ") );
		}else if (iKey == 88){
			SetResult(hImc, (!isShiftKeyDown? L"Ｘ" : L"ｘ") );
		}else if (iKey == 89){
			SetResult(hImc, (!isShiftKeyDown? L"Ｙ" : L"ｙ") );
		}else if (iKey == 90){
			SetResult(hImc, (!isShiftKeyDown? L"Ｚ" : L"ｚ") );

		}else if (iKey == 32){
			SetResult(hImc, L"　" );

		}else{
			ComDebug(L"不做全角转换的按键（包括小键盘）");
			return FALSE;
		}

	}else{

		if (iKey == 192){
			SetResult(hImc, (!isShiftKeyDown? L"·" : L"～") );

		}else if (iKey == 48){
			SetResult(hImc, (!isShiftKeyDown? L"0" : L"）") );
		}else if (iKey == 49){
			SetResult(hImc, (!isShiftKeyDown? L"1" : L"！") );
		}else if (iKey == 50){
			SetResult(hImc, (!isShiftKeyDown? L"2" : L"@") );
		}else if (iKey == 51){
			SetResult(hImc, (!isShiftKeyDown? L"3" : L"#") );
		}else if (iKey == 52){
			SetResult(hImc, (!isShiftKeyDown? L"4" : L"￥") );
		}else if (iKey == 53){
			SetResult(hImc, (!isShiftKeyDown? L"5" : L"%") );
		}else if (iKey == 54){
			SetResult(hImc, (!isShiftKeyDown? L"6" : L"……") );
		}else if (iKey == 55){
			SetResult(hImc, (!isShiftKeyDown? L"7" : L"&") );
		}else if (iKey == 56){
			SetResult(hImc, (!isShiftKeyDown? L"8" : L"×") );
		}else if (iKey == 57){
			SetResult(hImc, (!isShiftKeyDown? L"9" : L"（") );


		}else if (iKey == 189){
			SetResult(hImc, (!isShiftKeyDown? L"-" : L"——") );
		}else if (iKey == 187){
			SetResult(hImc, (!isShiftKeyDown? L"=" : L"+") );
		}else if (iKey == 220){
			SetResult(hImc, (!isShiftKeyDown? L"、" : L"|") );

		}else if (iKey == 219){
			SetResult(hImc, (!isShiftKeyDown? L"【" : L"『") );
		}else if (iKey == 221){
			SetResult(hImc, (!isShiftKeyDown? L"】" : L"』") );

		}else if (iKey == 186){
			SetResult(hImc, (!isShiftKeyDown? L"；" : L"：") );
		}else if (iKey == 222){
			SetResult(hImc, (!isShiftKeyDown? L"‘" : L"“") );

		}else if (iKey == 188){
			SetResult(hImc, (!isShiftKeyDown? L"，" : L"《") );
		}else if (iKey == 190){
			SetResult(hImc, (!isShiftKeyDown? L"。" : L"》") );
		}else if (iKey == 191){
			SetResult(hImc, (!isShiftKeyDown? L"/" : L"？") );


		}else{
			ComDebug(L"大写状下态不做标点转换的按键");
			return FALSE;
		}

	}
	
	return TRUE;

}


BOOL HandleKeys(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState){

	ComDebug(L"[IME] HandleKeys -----------");
	if (isCnMode){
		ComDebug(L" isCnMode");
	}else{
		ComDebug(L" ! isCnMode");
	}
	if (isFullMode){
		ComDebug(L" isFullMode");
	}else{
		ComDebug(L" ! isFullMode");
	}
	if (isBdMode){
		ComDebug(L" isBdMode");
	}else{
		ComDebug(L" ! isBdMode");
	}
	ComDebug(L"  --- HandleKeys --");


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

	if ( GetKeyState(VK_CAPITAL)){
		return ConvertFullChar(hImc, iKey, lpKeyData, lpbKeyState);
	}


	if ( !isShiftKeyDown && ( (iKey >= 48 && iKey <= 57) || (iKey >= 96 && iKey <= 105 ) )  ){
		isDot = true; // 正输入数字，紧接着按点的话不转换成句号
	}

	if (!HandleNotImeKeys(iKey, lpKeyData, lpbKeyState)){
		return FALSE;
	}
	

	if ( (isCnMode && !isInputStart && ((iKey < 0x41) || (iKey > 0x5A)) )
					 || (!isCnMode) ) {

		// 节省时间，可立马转换的字符输入马上转换之
		return HandleConverterChar(hImc, iKey, lpKeyData, lpbKeyState);
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

			isCnMode = TRUE;
			isFullMode = FALSE;
			isBdMode = TRUE;

			isLeftQte = true;
			isDot = false;
			ComDebug(L" SetFieldValue 全部初始化");
		}else if (fldIdex == 1){
			isCnMode = bValue;
			if (isCnMode){
				ComDebug(L" isCnMode");
			}else{
				ComDebug(L" ! isCnMode");
			}

		}else if (fldIdex == 2){
			isFullMode = bValue;
			if (isFullMode){
				ComDebug(L" isFullMode");
			}else{
				ComDebug(L" ! isFullMode");
			}

		}else if (fldIdex == 3){
			isBdMode = bValue;
			if (isBdMode){
				ComDebug(L" isBdMode");
			}else{
				ComDebug(L" ! isBdMode");
			}

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

