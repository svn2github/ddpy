
#include "DdpyTsf.h"
#include "TextService.h"
#include "EditSession.h"


bool isCtrlKeyDown = false;
bool isShiftKeyDown = false;
bool isInputKeyDown = false;

bool isFinish = false;
bool isInputStart = false;

bool isCnMode = true;
bool isFullMode = false;
bool isBdMode = true;

bool isLeftQte = true;
bool isDot = false;

bool isOpenImeKey = true;

void SetResult(TfClientId clientId, WCHAR * wc)
{

}

// 愚公移山
void HandleConverterChar(TfClientId clientId, UINT iKey){

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
					SetResult(clientId, (!isShiftKeyDown? L"｀" : L"～") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"`" : L"~") );
				}

			}else if (iKey == 48){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"０" : L"）") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"０" : L")") );
				}
			}else if (iKey == 49){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"１" : L"！") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"１" : L"!") );
				}
			}else if (iKey == 50){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"２" : L"＠") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"２" : L"@") );
				}
			}else if (iKey == 51){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"３" : L"＃") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"３" : L"#") );
				}
			}else if (iKey == 52){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"４" : L"￥") );  // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"４" : L"$") );  // ...
				}
			}else if (iKey == 53){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"５" : L"％") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"５" : L"%") );
				}
			}else if (iKey == 54){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"６" : L"……") );  // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"６" : L"^") );  // ...
				}
			}else if (iKey == 55){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"７" : L"＆") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"７" : L"&") );
				}
			}else if (iKey == 56){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"８" : L"×") );  // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"８" : L"*") );  // ...
				}
			}else if (iKey == 57){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"９" : L"（") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"９" : L"(") );
				}


			}else if (iKey == 189){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"－" : L"——") );  // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"－" : L"_") );  // ...
				}
			}else if (iKey == 187){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"＝" : L"＋") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"＝" : L"＋") );
				}
			}else if (iKey == 220){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"、" : L"｜") ); // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"＼" : L"｜") ); // ...
				}

			}else if (iKey == 219){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"【" : L"｛") ); // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"［" : L"｛") ); // ...
				}
			}else if (iKey == 221){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"】" : L"｝") ); // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"］" : L"｝") ); // ...
				}

			}else if (iKey == 186){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"；" : L"：") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"；" : L"：") );
				}
			}else if (iKey == 222){

				if (isBdMode){
					if (isLeftQte){
						SetResult(clientId, (!isShiftKeyDown? L"‘" : L"“") ); // .............
					}else{
						SetResult(clientId, (!isShiftKeyDown? L"’" : L"”") ); // .............
					}
					isLeftQte = !isLeftQte;
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"＇" : L"＂") ); // .............
				}


			}else if (iKey == 188){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"，" : L"《") ); // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"，" : L"＜") ); // ...
				}
			}else if (iKey == 190){

				if (isBdMode){
					if (isDot){
						SetResult(clientId, (!isShiftKeyDown? L"." : L"》") ); // ...
						isDot = false;
					}else{
						SetResult(clientId, (!isShiftKeyDown? L"。" : L"》") ); // ...
					}
				}else{
					if (isDot){
						SetResult(clientId, (!isShiftKeyDown? L"." : L"＞") ); // ...
						isDot = false;
					}else{
						SetResult(clientId, (!isShiftKeyDown? L"．" : L"＞") ); // ...
					}
				}


			}else if (iKey == 191){
				SetResult(clientId, (!isShiftKeyDown? L"／" : L"？") );

			}else if (iKey == 32){
				SetResult(clientId, L"　" );


			}else{
				ComDebug(L"不做全角转换的按键（包括小键盘）");
				return ;
			}

		}else{
			// CN !Full
			if (iKey == 192){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"·" : L"～") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"`" : L"~") );
				}

			}else if (iKey == 48){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"0" : L"）") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"0" : L")") );
				}
			}else if (iKey == 49){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"1" : L"！") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"1" : L"!") );
				}
			}else if (iKey == 50){
				SetResult(clientId, (!isShiftKeyDown? L"2" : L"@") );
			}else if (iKey == 51){
				SetResult(clientId, (!isShiftKeyDown? L"3" : L"#") );
			}else if (iKey == 52){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"4" : L"￥") );  // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"4" : L"$") );  // ...
				}
			}else if (iKey == 53){
				SetResult(clientId, (!isShiftKeyDown? L"5" : L"%") );
			}else if (iKey == 54){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"6" : L"……") );  // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"6" : L"^") );  // ...
				}
			}else if (iKey == 55){
				SetResult(clientId, (!isShiftKeyDown? L"7" : L"&") );
			}else if (iKey == 56){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"8" : L"×") );  // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"8" : L"*") );  // ...
				}
			}else if (iKey == 57){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"9" : L"（") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"9" : L"(") );
				}


			}else if (iKey == 189){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"-" : L"——") );  // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"-" : L"_") );  // ...
				}
			}else if (iKey == 187){
				SetResult(clientId, (!isShiftKeyDown? L"=" : L"+") );
			}else if (iKey == 220){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"、" : L"|") ); // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"\\" : L"|") ); // ...
				}

			}else if (iKey == 219){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"【" : L"『") ); // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"[" : L"{") ); // ...
				}
			}else if (iKey == 221){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"】" : L"』") ); // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"]" : L"}") ); // ...
				}

			}else if (iKey == 186){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"；" : L"：") );
				}else{
					SetResult(clientId, (!isShiftKeyDown? L";" : L":") );
				}
			}else if (iKey == 222){

				if (isBdMode){
					if (isLeftQte){
						SetResult(clientId, (!isShiftKeyDown? L"‘" : L"“") ); // .............
					}else{
						SetResult(clientId, (!isShiftKeyDown? L"’" : L"”") ); // .............
					}
					isLeftQte = !isLeftQte;
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"'" : L"\"") ); // .............
				}


			}else if (iKey == 188){
				if (isBdMode){
					SetResult(clientId, (!isShiftKeyDown? L"，" : L"《") ); // ...
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"," : L"<") ); // ...
				}
			}else if (iKey == 190){

				if (isBdMode){
					if (isDot){
						SetResult(clientId, (!isShiftKeyDown? L"." : L"》") ); // ...
						isDot = false;
					}else{
						SetResult(clientId, (!isShiftKeyDown? L"。" : L"》") ); // ...
					}
				}else{
					SetResult(clientId, (!isShiftKeyDown? L"." : L">") ); // ...
				}


			}else if (iKey == 191){
				SetResult(clientId, (!isShiftKeyDown? L"/" : L"？") );

			}else if (iKey == 32){
				SetResult(clientId, L" " );


			}else{
				ComDebug(L"不做转换的按键（包括小键盘）");
				return;
			}

		}



	}else{
		// EN

		if (!isFullMode){
			ComDebug(L"英文半角模式，不转换");
			return ;
		}

		if (iKey == 192){
			SetResult(clientId, (!isShiftKeyDown? L"｀" : L"～") );

		}else if (iKey == 48){
			SetResult(clientId, (!isShiftKeyDown? L"０" : L"）") );
		}else if (iKey == 49){
			SetResult(clientId, (!isShiftKeyDown? L"１" : L"！") );
		}else if (iKey == 50){
			SetResult(clientId, (!isShiftKeyDown? L"２" : L"＠") );
		}else if (iKey == 51){
			SetResult(clientId, (!isShiftKeyDown? L"３" : L"＃") );
		}else if (iKey == 52){
			SetResult(clientId, (!isShiftKeyDown? L"４" : L"＄") );
		}else if (iKey == 53){
			SetResult(clientId, (!isShiftKeyDown? L"５" : L"％") );
		}else if (iKey == 54){
			SetResult(clientId, (!isShiftKeyDown? L"６" : L"＾") );
		}else if (iKey == 55){
			SetResult(clientId, (!isShiftKeyDown? L"７" : L"＆") );
		}else if (iKey == 56){
			SetResult(clientId, (!isShiftKeyDown? L"８" : L"＊") );
		}else if (iKey == 57){
			SetResult(clientId, (!isShiftKeyDown? L"９" : L"（") );


		}else if (iKey == 189){
			SetResult(clientId, (!isShiftKeyDown? L"－" : L"＿") );
		}else if (iKey == 187){
			SetResult(clientId, (!isShiftKeyDown? L"＝" : L"＋") );
		}else if (iKey == 220){
			SetResult(clientId, (!isShiftKeyDown? L"＼" : L"｜") );

		}else if (iKey == 219){
			SetResult(clientId, (!isShiftKeyDown? L"［" : L"｛") );
		}else if (iKey == 221){
			SetResult(clientId, (!isShiftKeyDown? L"］" : L"｝") );

		}else if (iKey == 186){
			SetResult(clientId, (!isShiftKeyDown? L"；" : L"：") );
		}else if (iKey == 222){
			SetResult(clientId, (!isShiftKeyDown? L"＇" : L"＂") );

		}else if (iKey == 188){
			SetResult(clientId, (!isShiftKeyDown? L"，" : L"＜") );
		}else if (iKey == 190){
			if (isDot){
				SetResult(clientId, (!isShiftKeyDown? L"." : L"＞") );
				isDot = false;
			}else{
				SetResult(clientId, (!isShiftKeyDown? L"．" : L"＞") );
			}
		}else if (iKey == 191){
			SetResult(clientId, (!isShiftKeyDown? L"／" : L"？") );


		}else if (iKey == 65){
			SetResult(clientId, (isShiftKeyDown? L"Ａ" : L"ａ") );
		}else if (iKey == 66){
			SetResult(clientId, (isShiftKeyDown? L"Ｂ" : L"ｂ") );
		}else if (iKey == 67){
			SetResult(clientId, (isShiftKeyDown? L"Ｃ" : L"ｃ") );
		}else if (iKey == 68){
			SetResult(clientId, (isShiftKeyDown? L"Ｄ" : L"ｄ") );
		}else if (iKey == 69){
			SetResult(clientId, (isShiftKeyDown? L"Ｅ" : L"ｅ") );
		}else if (iKey == 70){
			SetResult(clientId, (isShiftKeyDown? L"Ｆ" : L"ｆ") );
		}else if (iKey == 71){
			SetResult(clientId, (isShiftKeyDown? L"Ｇ" : L"ｇ") );
		}else if (iKey == 72){
			SetResult(clientId, (isShiftKeyDown? L"Ｈ" : L"ｈ") );
		}else if (iKey == 73){
			SetResult(clientId, (isShiftKeyDown? L"Ｉ" : L"ｉ") );
		}else if (iKey == 74){
			SetResult(clientId, (isShiftKeyDown? L"Ｊ" : L"ｊ") );
		}else if (iKey == 75){
			SetResult(clientId, (isShiftKeyDown? L"Ｋ" : L"ｋ") );
		}else if (iKey == 76){
			SetResult(clientId, (isShiftKeyDown? L"Ｌ" : L"ｌ") );
		}else if (iKey == 77){
			SetResult(clientId, (isShiftKeyDown? L"Ｍ" : L"ｍ") );
		}else if (iKey == 78){
			SetResult(clientId, (isShiftKeyDown? L"Ｎ" : L"ｎ") );
		}else if (iKey == 79){
			SetResult(clientId, (isShiftKeyDown? L"Ｏ" : L"ｏ") );
		}else if (iKey == 80){
			SetResult(clientId, (isShiftKeyDown? L"Ｐ" : L"ｐ") );
		}else if (iKey == 81){
			SetResult(clientId, (isShiftKeyDown? L"Ｑ" : L"ｑ") );
		}else if (iKey == 82){
			SetResult(clientId, (isShiftKeyDown? L"Ｒ" : L"ｒ") );
		}else if (iKey == 83){
			SetResult(clientId, (isShiftKeyDown? L"Ｓ" : L"ｓ") );
		}else if (iKey == 84){
			SetResult(clientId, (isShiftKeyDown? L"Ｔ" : L"ｔ") );
		}else if (iKey == 85){
			SetResult(clientId, (isShiftKeyDown? L"Ｕ" : L"ｕ") );
		}else if (iKey == 86){
			SetResult(clientId, (isShiftKeyDown? L"Ｖ" : L"ｖ") );
		}else if (iKey == 87){
			SetResult(clientId, (isShiftKeyDown? L"Ｗ" : L"ｗ") );
		}else if (iKey == 88){
			SetResult(clientId, (isShiftKeyDown? L"Ｘ" : L"ｘ") );
		}else if (iKey == 89){
			SetResult(clientId, (isShiftKeyDown? L"Ｙ" : L"ｙ") );
		}else if (iKey == 90){
			SetResult(clientId, (isShiftKeyDown? L"Ｚ" : L"ｚ") );

		}else if (iKey == 32){
			SetResult(clientId, L"　" );

		}else{
			ComDebug(L"不做全角转换的按键（包括小键盘）");
			return;
		}


	}

	ComDebug(L" C++中立马转换");
	return;

}

// 老实做
void ConvertFullChar(TfClientId clientId, UINT iKey){


	if (GetKeyState(VK_CAPITAL) && !isFullMode && !isBdMode){
		ComDebug(L"大写半角非标点模式，按键不作处理");
		return;
	}
	if (!GetKeyState(VK_CAPITAL) && !isCnMode  && !isFullMode){
		ComDebug(L"小写英文Half模式，按键不作处理");
		return;
	}


	if (isFullMode){
		if (iKey == 192){
			SetResult(clientId, (!isShiftKeyDown? L"｀" : L"～") );

		}else if (iKey == 48){
			SetResult(clientId, (!isShiftKeyDown? L"０" : L"）") );
		}else if (iKey == 49){
			SetResult(clientId, (!isShiftKeyDown? L"１" : L"！") );
		}else if (iKey == 50){
			SetResult(clientId, (!isShiftKeyDown? L"２" : L"＠") );
		}else if (iKey == 51){
			SetResult(clientId, (!isShiftKeyDown? L"３" : L"＃") );
		}else if (iKey == 52){
			SetResult(clientId, (!isShiftKeyDown? L"４" : L"＄") );
		}else if (iKey == 53){
			SetResult(clientId, (!isShiftKeyDown? L"５" : L"％") );
		}else if (iKey == 54){
			SetResult(clientId, (!isShiftKeyDown? L"６" : L"＾") );
		}else if (iKey == 55){
			SetResult(clientId, (!isShiftKeyDown? L"７" : L"＆") );
		}else if (iKey == 56){
			SetResult(clientId, (!isShiftKeyDown? L"８" : L"＊") );
		}else if (iKey == 57){
			SetResult(clientId, (!isShiftKeyDown? L"９" : L"（") );


		}else if (iKey == 189){
			SetResult(clientId, (!isShiftKeyDown? L"－" : L"＿") );
		}else if (iKey == 187){
			SetResult(clientId, (!isShiftKeyDown? L"＝" : L"＋") );
		}else if (iKey == 220){
			SetResult(clientId, (!isShiftKeyDown? L"＼" : L"｜") );

		}else if (iKey == 219){
			SetResult(clientId, (!isShiftKeyDown? L"［" : L"｛") );
		}else if (iKey == 221){
			SetResult(clientId, (!isShiftKeyDown? L"］" : L"｝") );

		}else if (iKey == 186){
			SetResult(clientId, (!isShiftKeyDown? L"；" : L"：") );
		}else if (iKey == 222){
			SetResult(clientId, (!isShiftKeyDown? L"＇" : L"＂") );

		}else if (iKey == 188){
			SetResult(clientId, (!isShiftKeyDown? L"，" : L"＜") );
		}else if (iKey == 190){
			if (isDot){
				SetResult(clientId, (!isShiftKeyDown? L"." : L"＞") );
				isDot = false;
			}else{
				SetResult(clientId, (!isShiftKeyDown? L"．" : L"＞") );
			}
		}else if (iKey == 191){
			SetResult(clientId, (!isShiftKeyDown? L"／" : L"？") );


		}else if (iKey == 65){
			SetResult(clientId, (!isShiftKeyDown? L"Ａ" : L"ａ") );
		}else if (iKey == 66){
			SetResult(clientId, (!isShiftKeyDown? L"Ｂ" : L"ｂ") );
		}else if (iKey == 67){
			SetResult(clientId, (!isShiftKeyDown? L"Ｃ" : L"ｃ") );
		}else if (iKey == 68){
			SetResult(clientId, (!isShiftKeyDown? L"Ｄ" : L"ｄ") );
		}else if (iKey == 69){
			SetResult(clientId, (!isShiftKeyDown? L"Ｅ" : L"ｅ") );
		}else if (iKey == 70){
			SetResult(clientId, (!isShiftKeyDown? L"Ｆ" : L"ｆ") );
		}else if (iKey == 71){
			SetResult(clientId, (!isShiftKeyDown? L"Ｇ" : L"ｇ") );
		}else if (iKey == 72){
			SetResult(clientId, (!isShiftKeyDown? L"Ｈ" : L"ｈ") );
		}else if (iKey == 73){
			SetResult(clientId, (!isShiftKeyDown? L"Ｉ" : L"ｉ") );
		}else if (iKey == 74){
			SetResult(clientId, (!isShiftKeyDown? L"Ｊ" : L"ｊ") );
		}else if (iKey == 75){
			SetResult(clientId, (!isShiftKeyDown? L"Ｋ" : L"ｋ") );
		}else if (iKey == 76){
			SetResult(clientId, (!isShiftKeyDown? L"Ｌ" : L"ｌ") );
		}else if (iKey == 77){
			SetResult(clientId, (isShiftKeyDown? L"Ｍ" : L"ｍ") );
		}else if (iKey == 78){
			SetResult(clientId, (!isShiftKeyDown? L"Ｎ" : L"ｎ") );
		}else if (iKey == 79){
			SetResult(clientId, (!isShiftKeyDown? L"Ｏ" : L"ｏ") );
		}else if (iKey == 80){
			SetResult(clientId, (!isShiftKeyDown? L"Ｐ" : L"ｐ") );
		}else if (iKey == 81){
			SetResult(clientId, (!isShiftKeyDown? L"Ｑ" : L"ｑ") );
		}else if (iKey == 82){
			SetResult(clientId, (!isShiftKeyDown? L"Ｒ" : L"ｒ") );
		}else if (iKey == 83){
			SetResult(clientId, (!isShiftKeyDown? L"Ｓ" : L"ｓ") );
		}else if (iKey == 84){
			SetResult(clientId, (!isShiftKeyDown? L"Ｔ" : L"ｔ") );
		}else if (iKey == 85){
			SetResult(clientId, (!isShiftKeyDown? L"Ｕ" : L"ｕ") );
		}else if (iKey == 86){
			SetResult(clientId, (!isShiftKeyDown? L"Ｖ" : L"ｖ") );
		}else if (iKey == 87){
			SetResult(clientId, (!isShiftKeyDown? L"Ｗ" : L"ｗ") );
		}else if (iKey == 88){
			SetResult(clientId, (!isShiftKeyDown? L"Ｘ" : L"ｘ") );
		}else if (iKey == 89){
			SetResult(clientId, (!isShiftKeyDown? L"Ｙ" : L"ｙ") );
		}else if (iKey == 90){
			SetResult(clientId, (!isShiftKeyDown? L"Ｚ" : L"ｚ") );

		}else if (iKey == 32){
			SetResult(clientId, L"　" );

		}else{
			ComDebug(L"不做全角转换的按键（包括小键盘）");
			return;
		}

	}else{

		if (iKey == 192){
			SetResult(clientId, (!isShiftKeyDown? L"·" : L"～") );

		}else if (iKey == 48){
			SetResult(clientId, (!isShiftKeyDown? L"0" : L"）") );
		}else if (iKey == 49){
			SetResult(clientId, (!isShiftKeyDown? L"1" : L"！") );
		}else if (iKey == 50){
			SetResult(clientId, (!isShiftKeyDown? L"2" : L"@") );
		}else if (iKey == 51){
			SetResult(clientId, (!isShiftKeyDown? L"3" : L"#") );
		}else if (iKey == 52){
			SetResult(clientId, (!isShiftKeyDown? L"4" : L"￥") );
		}else if (iKey == 53){
			SetResult(clientId, (!isShiftKeyDown? L"5" : L"%") );
		}else if (iKey == 54){
			SetResult(clientId, (!isShiftKeyDown? L"6" : L"……") );
		}else if (iKey == 55){
			SetResult(clientId, (!isShiftKeyDown? L"7" : L"&") );
		}else if (iKey == 56){
			SetResult(clientId, (!isShiftKeyDown? L"8" : L"×") );
		}else if (iKey == 57){
			SetResult(clientId, (!isShiftKeyDown? L"9" : L"（") );


		}else if (iKey == 189){
			SetResult(clientId, (!isShiftKeyDown? L"-" : L"——") );
		}else if (iKey == 187){
			SetResult(clientId, (!isShiftKeyDown? L"=" : L"+") );
		}else if (iKey == 220){
			SetResult(clientId, (!isShiftKeyDown? L"、" : L"|") );

		}else if (iKey == 219){
			SetResult(clientId, (!isShiftKeyDown? L"【" : L"『") );
		}else if (iKey == 221){
			SetResult(clientId, (!isShiftKeyDown? L"】" : L"』") );

		}else if (iKey == 186){
			SetResult(clientId, (!isShiftKeyDown? L"；" : L"：") );
		}else if (iKey == 222){
			SetResult(clientId, (!isShiftKeyDown? L"‘" : L"“") );

		}else if (iKey == 188){
			SetResult(clientId, (!isShiftKeyDown? L"，" : L"《") );
		}else if (iKey == 190){
			if (isDot){
				SetResult(clientId, (!isShiftKeyDown? L"." : L"》") );
				isDot = false;
			}else{
				SetResult(clientId, (!isShiftKeyDown? L"。" : L"》") );
			}
		}else if (iKey == 191){
			SetResult(clientId, (!isShiftKeyDown? L"/" : L"？") );


		}else{
			ComDebug(L"大写状下态不做标点转换的按键");
			return;
		}

	}
	

}


bool IsOpenImeKey(){

	if (!isOpenImeKey){
		return false;
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

BOOL HandleNotImeKeys(WPARAM iKey){

	if ( isCtrlKeyDown ){
	    TsfDebug("HandleNotImeKeys isCtrlKeyDown ");
		return FALSE;
	}
	if ( isShiftKeyDown ){
	    TsfDebug("HandleNotImeKeys isShiftKeyDown");
		return TRUE;
	}

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

	case VK_INSERT:
	case VK_END:
	case VK_HOME:

	case VK_NUMLOCK:
		ComDebug(L" 不处理的按键（按各功能键）");
		return FALSE;
		
	default:
		break;
	}

	if (!isInputStart){

        switch (iKey)
		{
		case VK_BACK:
		case VK_RETURN:

		case VK_INSERT:
		case VK_DELETE:

		case VK_LEFT:
		case VK_RIGHT:
		case VK_UP:
		case VK_DOWN:

			ComDebug(L" 不处理的按键（按各功能键）");
			return FALSE;
		default:
			break;
		}

	}

	return TRUE;
}


BOOL CTextService::_IsKeyEaten(WPARAM iKey)
{
    if (_IsKeyboardDisabled()){
	    TsfDebug("_IsKeyboardDisabled");
        return FALSE;
    }

    //if (IsOpenImeKey()){
	   // TsfDebug("IsOpenImeKey()");
    //    return FALSE;
    //}

	if ( (iKey == VK_CONTROL) ){
		isCtrlKeyDown = true;			// Ctrl键按下
		return FALSE;
	}
    if ( (iKey == VK_SHIFT) ){
		isShiftKeyDown = true;			// Shift键按下
		return FALSE;
	}
	if (isCtrlKeyDown || isShiftKeyDown){
        isInputKeyDown = true;
    }

    if (!isCnMode){
	    TsfDebug("!isCnMode");
		return FALSE;
    }else{
	    TsfDebug("isCnMode");
	}


    if (!HandleNotImeKeys(iKey)){
        TsfDebug("!HandleNotImeKeys(iKey)");
		return FALSE;
	}



	

    return TRUE;
}


void CTextService::HandleKeys(ITfContext *pContext, WPARAM iKey, LPARAM lParam, bool isKeyDown)
{
	TsfDebug("CTextService::HandleKeys");

        BYTE keyStateArr[256];
      WORD word;
      UINT scanCode = lParam;
      char ch; 
      //把虚拟键代码转换成ascii码 
      GetKeyboardState(keyStateArr);
      ToAscii(iKey, scanCode, keyStateArr, &word, 0);
      ch = (char) word;

      if ((GetKeyState(VK_SHIFT) & 0x8000) && iKey >= 'a' && iKey <= 'z')
       ch += 'A'-'a';

	TsfDebug(&ch);


	/////////////////////
	//
	//if ( !isShiftKeyDown && ( (iKey >= 48 && iKey <= 57) || (iKey >= 96 && iKey <= 105 ) )  ){
	//	isDot = true; // 正输入数字，紧接着按点的话不转换成句号
	//}

	//if ( GetKeyState(VK_CAPITAL)){
	//TsfDebug("GetKeyState(VK_CAPITAL)");
	//	ConvertFullChar(_tfClientId, iKey);
	//	isDot = false;
	//	return;
	//}
	//
	//if ( (isCnMode && !isInputStart && ((iKey < '0') || (iKey > '9')) )
	//				 || (!isCnMode) ) {
	//TsfDebug("HandleConverterChar");

	//	// 节省时间，可立马转换的字符输入马上转换之
	//	HandleConverterChar(_tfClientId, iKey);
	//	isDot = false;
	//	return;
	//}

	//isDot = false;



	/////////////////////////////


    CEditSessionCaretPosition *pEditSessionCaretPosition;
	pEditSessionCaretPosition = new CEditSessionCaretPosition(pContext, this);
    pEditSessionCaretPosition->RequestEditSession(_tfClientId, TF_ES_SYNC | TF_ES_READWRITE);
    RECT rc = pEditSessionCaretPosition->GetCaretPosition();
	pEditSessionCaretPosition->Release();


    CComBSTR sResult = NULL;
	ImeKeyResult ikr = {};
	ikr.PosX = rc.left;
	ikr.PosY = rc.top;
	ikr.PosH = rc.bottom - rc.top;

	if ( !ComImeProcessKey(iKey, &ikr, &sResult) ){
		ComDebug(L" 调用失败：ComImeProcessKey");
	}

	if (!ikr.IsProcessKey){
		isInputStart = false;
	}else if(ikr.IsInputEnd){
		isInputStart = false;
	}else{
		isInputStart = ikr.IsInputStart;
	}

	if (ikr.IsInputEnd){
		isFinish = ikr.IsInputEnd;

        // 通过EditSession插入文本
		CEditSessionInsertText *pEditSessionInsertText;
		pEditSessionInsertText = new CEditSessionInsertText(pContext, sResult);
        pEditSessionInsertText->RequestEditSession(_tfClientId, TF_ES_SYNC | TF_ES_READWRITE);
		pEditSessionInsertText->Release();
        sResult.Empty();

	}

}


STDAPI CTextService::OnTestKeyDown(ITfContext *pContext, WPARAM wParam, LPARAM lParam, BOOL *pfEaten)
{
	TsfDebug("CTextService::ITfKeyEventSink:OnTestKeyDown");


    *pfEaten = _IsKeyEaten(wParam);

    return S_OK;
}

STDAPI CTextService::OnKeyDown(ITfContext *pContext, WPARAM wParam, LPARAM lParam, BOOL *pfEaten)
{
	TsfDebug("CTextService::ITfKeyEventSink:OnKeyDown");

    *pfEaten = _IsKeyEaten(wParam);
    if ( *pfEaten ){
    	HandleKeys(pContext, wParam, lParam, true);
    }

    return S_OK;
}

STDAPI CTextService::OnTestKeyUp(ITfContext *pContext, WPARAM iKey, LPARAM lParam, BOOL *pfEaten)
{
	TsfDebug("CTextService::ITfKeyEventSink:OnTestKeyUp");

	if ( (iKey == VK_CONTROL) ){
	    TsfDebug("Ctrl Key Up");
		isCtrlKeyDown = false;
		isInputKeyDown = false;
		*pfEaten = FALSE;
		return S_OK;
	}
    
    if ( (iKey == VK_SHIFT) ){
	    TsfDebug("SHIFT Key Up");

        if (!IsOpenImeKey()){
	        TsfDebug("!IsOpenImeKey()");

            if (!isInputKeyDown) {
	        TsfDebug("!isInputKeyDown");
                isCnMode = !isCnMode;
            }else{
	        TsfDebug("isInputKeyDown");
			}

            if (isCnMode) {
                TsfDebug("isCnMode true");
            }else{
                TsfDebug("isCnMode false");
            }

        }
		    isShiftKeyDown = false;
            isInputKeyDown = false;

		*pfEaten = FALSE;
		return S_OK;
	}


    *pfEaten = _IsKeyEaten(iKey);
    return S_OK;
}

STDAPI CTextService::OnKeyUp(ITfContext *pContext, WPARAM iKey, LPARAM lParam, BOOL *pfEaten)
{
	TsfDebug("CTextService::ITfKeyEventSink:OnKeyUp");

	if ( (iKey == VK_CONTROL) ){
	    TsfDebug("Ctrl Key Up");
		isCtrlKeyDown = false;
		isInputKeyDown = false;
		*pfEaten = FALSE;
		return S_OK;
	}
    
    if ( (iKey == VK_SHIFT) ){
	    TsfDebug("SHIFT Key Up");

        if (!IsOpenImeKey()){
	        TsfDebug("!IsOpenImeKey()");

            if (!isInputKeyDown) {
	        TsfDebug("!isInputKeyDown");
                isCnMode = !isCnMode;
            }else{
	        TsfDebug("isInputKeyDown");
			}

            if (isCnMode) {
                TsfDebug("isCnMode true");
            }else{
                TsfDebug("isCnMode false");
            }

        }
		    isShiftKeyDown = false;
            isInputKeyDown = false;

		*pfEaten = FALSE;
		return S_OK;
	}

    *pfEaten = _IsKeyEaten(iKey);
    return S_OK;
}


STDAPI CTextService::OnSetFocus(BOOL fForeground)
{
	TsfDebug("CTextService::ITfKeyEventSink:OnSetFocus");
	return S_OK;
}

STDAPI CTextService::OnPreservedKey(ITfContext *pContext, REFGUID rguid, BOOL *pfEaten)
{
	TsfDebug("CTextService::OnPreservedKey");
    return S_OK;
}


BOOL CTextService::_InitKeyEventSink()
{
	TsfDebug("CTextService::_InitKeyEventSink");

    ITfKeystrokeMgr *pKeystrokeMgr;
    HRESULT hr;

    if (_pThreadMgr->QueryInterface(IID_ITfKeystrokeMgr, (void **)&pKeystrokeMgr) != S_OK){
		TsfDebug("CTextService::_InitKeyEventSink - QueryInterface IID_ITfKeystrokeMgr Failed");
        return FALSE;
	}

    hr = pKeystrokeMgr->AdviseKeyEventSink(_tfClientId, (ITfKeyEventSink *)this, TRUE);

    pKeystrokeMgr->Release();

    return (hr == S_OK);
}

void CTextService::_UninitKeyEventSink()
{
	TsfDebug("CTextService::_UninitKeyEventSink");

    ITfKeystrokeMgr *pKeystrokeMgr;

    if (_pThreadMgr->QueryInterface(IID_ITfKeystrokeMgr, (void **)&pKeystrokeMgr) != S_OK){
        return;
	}

    pKeystrokeMgr->UnadviseKeyEventSink(_tfClientId);

    pKeystrokeMgr->Release();
}

