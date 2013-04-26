#include "Globals.h"
#include "DdpyTsf.h"
#include "TextService.h"


STDAPI CTextService::OnEndEdit(ITfContext *pContext, TfEditCookie ec, ITfEditRecord *pEditRecord)
{
	TsfDebug("CTextService::ITfTextEditSink:OnEndEdit");


  //  BOOL fSelectionChanged;
  //  IEnumTfRanges *pEnumTextChanges;
  //  ITfRange *pRange;

  //  //
  //  // did the selection change?
  //  // The selection change includes the movement of caret as well. 
  //  // The caret position is represent as the empty selection range when
  //  // there is no selection.
  //  //
  //  if (pEditRecord->GetSelectionStatus(&fSelectionChanged) == S_OK && fSelectionChanged) {
		//// 
  //  }

  //  if (pEditRecord->GetTextAndPropertyUpdates(TF_GTP_INCL_TEXT, NULL, 0, &pEnumTextChanges) == S_OK) {

		//// 文本已变化
  //      if (pEnumTextChanges->Next(1, &pRange, NULL) == S_OK) {

		//	// 更新Selection
		//	TsfDebug("CTextService::ITfTextEditSink:OnEndEdit - Update Selection");
		//	TF_SELECTION tfSelection;
		//	pRange->Collapse(ec, TF_ANCHOR_END);

		//	tfSelection.range = pRange;
		//	tfSelection.style.ase = TF_AE_NONE;
		//	tfSelection.style.fInterimChar = FALSE;
		//	pContext->SetSelection(ec, 1, &tfSelection);

		//	pRange->Release();
  //      }

  //      pEnumTextChanges->Release();
  //  }


	return S_OK;
}

// 初始化 ITfTextEditSink
BOOL CTextService::_InitTextEditSink(ITfDocumentMgr *pDocMgr)
{
	TsfDebug("CTextService::_InitTextEditSink");

	ITfSource *pSource;

	// 先全部注销
	if (_dwTextEditSinkCookie != TF_INVALID_COOKIE) {
		if (_pTextEditSinkContext->QueryInterface(IID_ITfSource, (void **)&pSource) == S_OK) {
			pSource->UnadviseSink(_dwTextEditSinkCookie);
			pSource->Release();
		}

		_pTextEditSinkContext->Release();
		_pTextEditSinkContext = NULL;
		_dwTextEditSinkCookie = TF_INVALID_COOKIE;
	}

	// setup a new sink advised to the topmost context of the document
	if (pDocMgr->GetTop(&_pTextEditSinkContext) != S_OK){
		_pTextEditSinkContext = NULL;
		_dwTextEditSinkCookie = TF_INVALID_COOKIE;
		return FALSE;
	}

	if (_pTextEditSinkContext == NULL){
		_pTextEditSinkContext = NULL;
		_dwTextEditSinkCookie = TF_INVALID_COOKIE;
		return TRUE; // empty document, no sink possible
	}


	BOOL fRet = FALSE;

	if (_pTextEditSinkContext->QueryInterface(IID_ITfSource, (void **)&pSource) == S_OK) {
		// 初始化
		if (pSource->AdviseSink(IID_ITfTextEditSink, (ITfTextEditSink *)this, &_dwTextEditSinkCookie) == S_OK) {
			fRet = TRUE;
		}
		pSource->Release();
	}

	if (fRet == FALSE) {
		_pTextEditSinkContext->Release();
		_pTextEditSinkContext = NULL;
		_dwTextEditSinkCookie = TF_INVALID_COOKIE;
		return FALSE;
	}

	return TRUE;
}

// 注销 ITfTextEditSink
BOOL CTextService::_UninitTextEditSink()
{
	TsfDebug("CTextService::_UninitTextEditSink");

	ITfSource *pSource;
	
	// 全部注销
	if (_dwTextEditSinkCookie != TF_INVALID_COOKIE) {
		if (_pTextEditSinkContext != NULL && _pTextEditSinkContext->QueryInterface(IID_ITfSource, (void **)&pSource) == S_OK) {
			pSource->UnadviseSink(_dwTextEditSinkCookie);
			pSource->Release();
		}

		_pTextEditSinkContext->Release();
		_pTextEditSinkContext = NULL;
		_dwTextEditSinkCookie = TF_INVALID_COOKIE;
	}

	return TRUE;
}
