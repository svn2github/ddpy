
#include "DdpyTsf.h"
#include "TextService.h"
#include "EditSession.h"

// 通过插入NULL串更新焦点位置，在最新焦点位置基础上取得编码框位置
STDAPI CEditSessionCaretPosition::DoEditSession(TfEditCookie ec)
{
	TsfDebug("CEditSessionCaretPosition::DoEditSession");

	ITfInsertAtSelection *pInsertAtSelection = NULL;
    ITfRange *pRangeInsert = NULL;
    ITfContextComposition *pContextComposition = NULL;
    HRESULT hr = E_FAIL;

    if (_pContext->QueryInterface(IID_ITfInsertAtSelection, (void **)&pInsertAtSelection) != S_OK) {
		TsfError("CEditSessionCaretPosition::DoEditSession:QueryInterface IID_ITfInsertAtSelection Failed");
        goto Exit;
    }
    if (pInsertAtSelection->InsertTextAtSelection(ec, TF_IAS_QUERYONLY, NULL, 0, &pRangeInsert) != S_OK) {
		TsfError("CEditSessionCaretPosition::DoEditSession:InsertTextAtSelection Failed");
        goto Exit;
    }
    if (_pContext->QueryInterface(IID_ITfContextComposition, (void **)&pContextComposition) != S_OK) {
		TsfError("CEditSessionCaretPosition::DoEditSession:QueryInterface IID_ITfContextComposition Failed");
        goto Exit;
    }


    // 开始编码
    ITfComposition *pComposition = NULL;
    if ((pContextComposition->StartComposition(ec, pRangeInsert, _pTextService, &pComposition) != S_OK) || (pComposition == NULL)) {
		TsfError("CEditSessionCaretPosition::DoEditSession:StartComposition Failed");
        goto Exit;
    }

    // 更新位置
	pRangeInsert->Collapse(ec, TF_ANCHOR_END);
    TF_SELECTION tfSelection;
    tfSelection.range = pRangeInsert;
    tfSelection.style.ase = TF_AE_NONE;
    tfSelection.style.fInterimChar = FALSE;
    _pContext->SetSelection(ec, 1, &tfSelection);

    // 取得编码位置
    ITfRange *pRangeComposition;
    if (pComposition->GetRange(&pRangeComposition) == S_OK){

   	    ITfContextView *pContextView = NULL;
	    _pContext->GetActiveView(&pContextView);
	    BOOL fClipped;

        // pCompositionRange->SetText(ec, TF_ST_CORRECTION, L"A", 1);
	    pContextView->GetTextExt(ec, pRangeComposition, &_rc, &fClipped);
	    // pCompositionRange->SetText(ec, 0, L"", 0);

        pContextView->Release();
	    pRangeComposition->Release();
    }else{
		TsfError("CEditSessionCaretPosition::DoEditSession:GetRange Failed");
    }

    // 结束编码
	pComposition->EndComposition(ec);
	pComposition->Release();


Exit:
    if (pContextComposition != NULL) {
        pContextComposition->Release();
    }

    if (pRangeInsert != NULL) {
        pRangeInsert->Release();
    }

    if (pInsertAtSelection != NULL) {
        pInsertAtSelection->Release();
    }

    return S_OK;
}