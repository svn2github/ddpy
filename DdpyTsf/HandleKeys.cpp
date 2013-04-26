
//
//#include "DdpyTsf.h"
//#include "TextService.h"
//#include "EditSession.h"
//
//bool isCtrlKeyDown = false;
//bool isShiftKeyDown = false;
//bool isInputKeyDown = false;
//
//bool isFinish = false;
//bool isInputStart = false;
//
//
//BOOL HandleNotImeKeys(WPARAM iKey){
//
//	if ( isCtrlKeyDown || isShiftKeyDown ){
//		return FALSE;
//	}
//
//   	switch (iKey)
//	{
//	case VK_F1:
//	case VK_F2:
//	case VK_F3:
//	case VK_F4:
//	case VK_F5:
//	case VK_F6:
//	case VK_F7:
//	case VK_F8:
//	case VK_F9:
//	case VK_F10:
//	case VK_F11:
//	case VK_F12:
//	case VK_PRINT:
//	case VK_SCROLL:
//	case VK_PAUSE:
//
//	case VK_TAB:
//	case VK_CAPITAL:
//
//	case VK_INSERT:
//	case VK_END:
//	case VK_HOME:
//
//	case VK_NUMLOCK:
//		ComDebug(L" 不处理的按键（按各功能键）");
//		return FALSE;
//		
//	default:
//		break;
//	}
//
//	if (!isInputStart){
//
//        switch (iKey)
//		{
//		case VK_BACK:
//		case VK_RETURN:
//
//		case VK_INSERT:
//		case VK_DELETE:
//
//		case VK_LEFT:
//		case VK_RIGHT:
//		case VK_UP:
//		case VK_DOWN:
//
//			ComDebug(L" 不处理的按键（按各功能键）");
//			return FALSE;
//		default:
//			break;
//		}
//
//	}
//
//	return TRUE;
//}
//
//
//BOOL CTextService::_IsKeyEaten(WPARAM iKey)
//{
//    if (_IsKeyboardDisabled()){
//        return FALSE;
//    }
//
//	if ( (iKey == VK_CONTROL) ){
//		isCtrlKeyDown = true;			// Ctrl键按下
//		return FALSE;
//	}else if ( (iKey == VK_SHIFT) ){
//		isShiftKeyDown = true;			// Shift键按下
//		return FALSE;
//	}
//
//    return HandleNotImeKeys(iKey);
//
//
// //   //// if the keyboard is closed, don't eat keys.
// //   //if (!_IsKeyboardOpen())
// //   //    return FALSE;
//
// //   // VK_A - VK_Z is interesting only when this is open.
// //   // is on
//	//if (iKey >= 'A' && iKey <= 'Z')
//	//	return TRUE;
//	//else if (iKey >= '0' && iKey <= '9')
//	//	return isInputStart? TRUE : FALSE;
//	//else if (iKey == '\'')
//	//	return isInputStart? TRUE : FALSE;
//	//else if (iKey == ' ')
//	//	return isInputStart? TRUE : FALSE;
//
//
//	//switch (iKey)
//	//{
//	//case VK_LEFT:
//	//case VK_RIGHT:
//	//case VK_UP:
//	//case VK_DOWN:
//	//case VK_RETURN:
//	//case VK_BACK:
//	//case VK_DELETE:
//	//case VK_ESCAPE:
//	//	return isInputStart? TRUE : FALSE;	
//	//default:
//	//	break;
//	//}
//
// //   return FALSE;
//}
//
//
//void CTextService::HandleKeys(ITfContext *pContext, WPARAM iKey, LPARAM lParam, bool isKeyDown)
//{
//	TsfDebug("CTextService::HandleKeys");
//
//        BYTE keyStateArr[256];
//      WORD word;
//      UINT scanCode = lParam;
//      char ch; 
//      //把虚拟键代码转换成ascii码 
//      GetKeyboardState(keyStateArr);
//      ToAscii(iKey, scanCode, keyStateArr, &word, 0);
//      ch = (char) word;
//
//      if ((GetKeyState(VK_SHIFT) & 0x8000) && iKey >= 'a' && iKey <= 'z')
//       ch += 'A'-'a';
//
//	TsfDebug(&ch);
//
//
//
//
//
//
//    if (!isKeyDown){
//        return;
//    }
//
//
//    CEditSessionCaretPosition *pEditSessionCaretPosition;
//	pEditSessionCaretPosition = new CEditSessionCaretPosition(pContext, this);
//    pEditSessionCaretPosition->RequestEditSession(_tfClientId, TF_ES_SYNC | TF_ES_READWRITE);
//    RECT rc = pEditSessionCaretPosition->GetCaretPosition();
//	pEditSessionCaretPosition->Release();
//
//    CComBSTR sResult = NULL;
//	ImeKeyResult ikr = {};
//	ikr.PosX = rc.left;
//	ikr.PosY = rc.top;
//	ikr.PosH = rc.bottom - rc.top;
//
//	if ( !ComImeProcessKey(iKey, &ikr, &sResult) ){
//		ComDebug(L" 调用失败：ComImeProcessKey");
//	}
//
//	if (!ikr.IsProcessKey){
//		isInputStart = false;
//	}else if(ikr.IsInputEnd){
//		isInputStart = false;
//	}else{
//		isInputStart = ikr.IsInputStart;
//	}
//
//	if (ikr.IsInputEnd){
//		isFinish = ikr.IsInputEnd;
//
//        // 通过EditSession插入文本
//		CEditSessionInsertText *pEditSessionInsertText;
//		pEditSessionInsertText = new CEditSessionInsertText(pContext, sResult);
//        pEditSessionInsertText->RequestEditSession(_tfClientId, TF_ES_SYNC | TF_ES_READWRITE);
//		pEditSessionInsertText->Release();
//        sResult.Empty();
//
//	}
//
//}
//
