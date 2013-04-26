#include "Globals.h"
#include "DdpyTsf.h"
#include "TextService.h"


STDAPI CTextService::OnInitDocumentMgr(ITfDocumentMgr *pDocMgr)
{
	TsfDebug("CTextService::ITfThreadMgrEventSink:OnInitDocumentMgr");
	return S_OK;
}

STDAPI CTextService::OnUninitDocumentMgr(ITfDocumentMgr *pDocMgr)
{
	TsfDebug("CTextService::ITfThreadMgrEventSink:OnUninitDocumentMgr");
	return S_OK;
}

STDAPI CTextService::OnSetFocus(ITfDocumentMgr *pDocMgrFocus, ITfDocumentMgr *pDocMgrPrevFocus)
{
	TsfDebug("CTextService::ITfThreadMgrEventSink:OnSetFocus");

	//// Whenever focus is changed, initialize the TextEditSink.
	//_InitTextEditSink(pDocMgrFocus);  // 这个竟会导致WORD关闭时崩溃？！（XP）

	return S_OK;
}

STDAPI CTextService::OnPushContext(ITfContext *pContext)
{
	TsfDebug("CTextService::ITfThreadMgrEventSink:OnPushContext");
	return S_OK;
}

STDAPI CTextService::OnPopContext(ITfContext *pContext)
{
	TsfDebug("CTextService::ITfThreadMgrEventSink:OnPopContext");
	return S_OK;
}


// 初始化 ITfThreadMgrEventSink
BOOL CTextService::_InitThreadMgrEventSink()
{
	TsfDebug("CTextService::_InitThreadMgrEventSink");

	BOOL fRet = FALSE;

	ITfSource *pSource;
	if (_pThreadMgr->QueryInterface(IID_ITfSource, (void **)&pSource) != S_OK){
		return FALSE;
	}

	if (pSource->AdviseSink(IID_ITfThreadMgrEventSink, (ITfThreadMgrEventSink *)this, &_dwThreadMgrEventSinkCookie) != S_OK) {
		// don't try to Unadvise _dwThreadMgrEventSinkCookie later
		_dwThreadMgrEventSinkCookie = TF_INVALID_COOKIE;
		goto Exit;
	}

	fRet = TRUE;

Exit:
	pSource->Release();
	return fRet;
}

// 注销 ITfThreadMgrEventSink
void CTextService::_UninitThreadMgrEventSink()
{
	TsfDebug("CTextService::_UninitThreadMgrEventSink");

	ITfSource *pSource;

	if (_dwThreadMgrEventSinkCookie == TF_INVALID_COOKIE){
		return; // never Advised
	}

	if (_pThreadMgr->QueryInterface(IID_ITfSource, (void **)&pSource) == S_OK){
		// 注销 ITfThreadMgrEventSink
		pSource->UnadviseSink(_dwThreadMgrEventSinkCookie);
		pSource->Release();
	}

	_dwThreadMgrEventSinkCookie = TF_INVALID_COOKIE;
}
