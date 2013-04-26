
#include "DdpyTsf.h"
#include "TextService.h"


STDAPI CTextService::OnSetThreadFocus()
{
	TsfDebug("CTextService::ITfThreadFocusSink:OnSetThreadFocus");

	ComImeSetActiveContext(TRUE);
	return S_OK;
}

STDAPI CTextService::OnKillThreadFocus()
{
	TsfDebug("CTextService::ITfThreadFocusSink:OnKillThreadFocus");

	ComImeSetActiveContext(FALSE);
	return S_OK;
}

BOOL CTextService::_InitThreadFocusSink()
{
	TsfDebug("CTextService::ITfThreadFocusSink:_InitThreadFocusSink");

	ITfSource *pSource;
	BOOL fRet = FALSE;

	if(_pThreadMgr->QueryInterface(IID_ITfSource, (void **)&pSource) == S_OK) {
		if(pSource->AdviseSink(IID_ITfThreadFocusSink, (ITfThreadFocusSink *)this, &_dwThreadFocusSinkCookie) == S_OK) {
			fRet = TRUE;
		} else {
			_dwThreadFocusSinkCookie = TF_INVALID_COOKIE;
		}
		pSource->Release();
	}
	
	return fRet;
}

void CTextService::_UninitThreadFocusSink()
{
	TsfDebug("CTextService::ITfThreadFocusSink:_UninitThreadFocusSink");

	ITfSource *pSource;

	if(_pThreadMgr->QueryInterface(IID_ITfSource, (void **)&pSource) == S_OK) {
		pSource->UnadviseSink(_dwThreadFocusSinkCookie);
		pSource->Release();
		_dwThreadFocusSinkCookie = TF_INVALID_COOKIE;
	}
}
