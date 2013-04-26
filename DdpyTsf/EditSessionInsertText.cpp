
#include "StdAfx.h"
#include "EditSession.h"
#include "DdpyTsf.h"


// 通过ITfInsertAtSelection接口插入文本
void CEditSessionInsertText::_InsertTextAtSelection(TfEditCookie ec,  WCHAR *pwchText)
{
	ITfInsertAtSelection *pInsertAtSelection;
	ITfRange *pRange;
	TF_SELECTION tfSelection;

	// 从TSF框架中取得ITfInsertAtSelection实例
	if (_pContext->QueryInterface(IID_ITfInsertAtSelection, (void **)&pInsertAtSelection) != S_OK){
		TsfError("CEditSessionInsertText::_InsertTextAtSelection:QueryInterface IID_ITfInsertAtSelection Failed");
		return;
	}

	// 插入文本
	if (pInsertAtSelection->InsertTextAtSelection(ec, 0, pwchText, (ULONG)wcslen(pwchText), &pRange) != S_OK){
		TsfError("CEditSessionInsertText::_InsertTextAtSelection:Insert Text Failed");
		goto Exit;
	}

	// 更新光标位置
	pRange->Collapse(ec, TF_ANCHOR_END);
	tfSelection.range = pRange;
	tfSelection.style.ase = TF_AE_NONE;
	tfSelection.style.fInterimChar = FALSE;
	_pContext->SetSelection(ec, 1, &tfSelection);
	pRange->Release();

Exit:
	pInsertAtSelection->Release();
}


STDAPI CEditSessionInsertText::DoEditSession(TfEditCookie ec)
{
	if (_pContext) {
		_InsertTextAtSelection(ec, _pwchText);
	}

	return S_OK;
}

