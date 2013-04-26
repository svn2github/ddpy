
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

SYSTEMTIME timeStart;
bool isOpenImeKey = true;

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

	if ( isCtrlKeyDown || isShiftKeyDown ){
	    TsfDebug("isCtrlKeyDown || isShiftKeyDown");
		return FALSE;
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

    if (IsOpenImeKey()){
	    TsfDebug("IsOpenImeKey()");
        return FALSE;
    }

	if ( (iKey == VK_CONTROL) ){
		isCtrlKeyDown = true;			// Ctrl键按下
		return FALSE;
	}
    if ( (iKey == VK_SHIFT) ){
		isShiftKeyDown = true;			// Shift键按下
		return FALSE;
	}

    if (!isCnMode){
	    TsfDebug("!isCnMode _IsKeyEaten=false");
		return FALSE;
    }

    if (isShiftKeyDown){
        isInputKeyDown = true;
    }

    BOOL b = HandleNotImeKeys(iKey);

        if (b) {
            TsfDebug("_IsKeyEaten true");
        }else{
            TsfDebug("_IsKeyEaten false");
        }
    return b;
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
	}
    
    if ( (iKey == VK_SHIFT) ){
	    TsfDebug("SHIFT Key Up");

        if (!IsOpenImeKey()){
	        TsfDebug("!IsOpenImeKey()");

            if (!isInputKeyDown) {
                isCnMode = !isCnMode;
            }

            if (isCnMode) {
                TsfDebug("isCnMode true");
            }else{
                TsfDebug("isCnMode false");
            }

        }
		    isShiftKeyDown = false;
            isInputKeyDown = false;
	}


    *pfEaten = _IsKeyEaten(iKey);
    return S_OK;
}

STDAPI CTextService::OnKeyUp(ITfContext *pContext, WPARAM iKey, LPARAM lParam, BOOL *pfEaten)
{
	TsfDebug("CTextService::ITfKeyEventSink:OnKeyUp");

	if ( (iKey == VK_CONTROL) ){
		isCtrlKeyDown = false;
	}else if ( (iKey == VK_SHIFT) ){
		isShiftKeyDown = false;
        isInputKeyDown = false;
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

