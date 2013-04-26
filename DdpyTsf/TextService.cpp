#include "Globals.h"
#include "DdpyTsf.h"
#include "TextService.h"


// 大杂烩，一个CTextService实现多个接口
STDAPI CTextService::QueryInterface(REFIID riid, void **ppvObj)
{
	TsfDebug("CTextService::COM:QueryInterface");

	if (ppvObj == NULL){
		return E_INVALIDARG;
	}

	*ppvObj = NULL;

	if (IsEqualIID(riid, IID_IUnknown)) {
		TsfDebug("CTextService::COM:QueryInterface - IID_IUnknown");
		// IID_ITfTextInputProcessor 打开关闭输入法用
		*ppvObj = (ITfTextInputProcessor *)this;

	} else if (IsEqualIID(riid, IID_ITfTextInputProcessor)) {
		TsfDebug("CTextService::COM:QueryInterface - IID_ITfTextInputProcessor");
		// IID_ITfTextInputProcessor 打开关闭输入法用
		*ppvObj = (ITfTextInputProcessor *)this;

	} else if (IsEqualIID(riid, IID_ITfThreadMgrEventSink)) {
		TsfDebug("CTextService::COM:QueryInterface - IID_ITfThreadMgrEventSink");
		// IID_ITfThreadMgrEventSink 线程管理事件响应
		*ppvObj = (ITfThreadMgrEventSink *)this;

	} else if (IsEqualIID(riid, IID_ITfTextEditSink)) {
		TsfDebug("CTextService::COM:QueryInterface - IID_ITfTextEditSink");
		// IID_ITfTextEditSink 文本变化事件响应
		*ppvObj = (ITfTextEditSink *)this;

	} else if (IsEqualIID(riid, IID_ITfKeyEventSink)) {
		TsfDebug("CTextService::COM:QueryInterface - IID_ITfKeyEventSink");
		// IID_ITfKeyEventSink 键盘事件响应
		*ppvObj = (ITfKeyEventSink *)this;

	} else if (IsEqualIID(riid, IID_ITfCompositionSink)) {
		TsfDebug("CTextService::COM:QueryInterface - IID_ITfCompositionSink");
		// IID_ITfCompositionSink 编码事件响应
		*ppvObj = (ITfCompositionSink *)this;

	} else if (IsEqualIID(riid, IID_ITfThreadFocusSink)) {
		TsfDebug("CTextService::COM:QueryInterface - IID_ITfThreadFocusSink");
		// IID_ITfThreadFocusSink 焦点事件响应
		*ppvObj = (ITfThreadFocusSink *)this;

	} else if (IsEqualIID(riid, IID_ITfFnConfigure)) {
		TsfDebug("CTextService::COM:QueryInterface - IID_ITfFnConfigure");
		// IID_ITfFnConfigure 配置事件响应
		*ppvObj = (ITfFnConfigure *)this;

	}else{
		TsfDebug("CTextService::COM:QueryInterface - Unknow");
	}

	if (*ppvObj) {
		AddRef();		// 又是一个COM引用
		return S_OK;
	}

	return E_NOINTERFACE;
}


HRESULT CTextService::CreateInstance(IUnknown *pUnkOuter, REFIID riid, void **ppvObj)
{
	TsfDebug("CTextService::COM:CreateInstance");

	CTextService *pCase;
	HRESULT hr;

	if (ppvObj == NULL){
		return E_INVALIDARG;
	}

	*ppvObj = NULL;

	if (NULL != pUnkOuter){
		return CLASS_E_NOAGGREGATION;
	}

	if ((pCase = new CTextService) == NULL){
		return E_OUTOFMEMORY;
	}

	hr = pCase->QueryInterface(riid, ppvObj);

	pCase->Release(); // caller still holds ref if hr == S_OK

	return hr;
}


STDAPI_(ULONG) CTextService::AddRef()
{
	TsfDebug("CTextService::COM:AddRef");

	return ++_cRef;
}

STDAPI_(ULONG) CTextService::Release()
{
	TsfDebug("CTextService::COM:Release");

	LONG cr = --_cRef;

	if (_cRef == 0) {
		delete this;
	}

	return cr;
}




//+---------------------------------------------------------------------------
//
// _IsKeyboardDisabled
//
// GUID_COMPARTMENT_KEYBOARD_DISABLED is the compartment in the context
// object.
//
//----------------------------------------------------------------------------

BOOL CTextService::_IsKeyboardDisabled()
{
    ITfCompartmentMgr *pCompMgr = NULL;
    ITfDocumentMgr *pDocMgrFocus = NULL;
    ITfContext *pContext = NULL;
    BOOL fDisabled = FALSE;

    if ((_pThreadMgr->GetFocus(&pDocMgrFocus) != S_OK) || (pDocMgrFocus == NULL)) {

        // if there is no focus document manager object, the keyboard is disabled
        fDisabled = TRUE;
        goto Exit;
    }

    if ((pDocMgrFocus->GetTop(&pContext) != S_OK) || (pContext == NULL)) {

        // if there is no context object, the keyboard is disabled
        fDisabled = TRUE;
        goto Exit;
    }

    if (pContext->QueryInterface(IID_ITfCompartmentMgr, (void **)&pCompMgr) == S_OK) {

        ITfCompartment *pCompartmentDisabled;
        ITfCompartment *pCompartmentEmptyContext;

        // Check GUID_COMPARTMENT_KEYBOARD_DISABLED.
        if (pCompMgr->GetCompartment(GUID_COMPARTMENT_KEYBOARD_DISABLED, &pCompartmentDisabled) == S_OK) {

            VARIANT var;
            if (S_OK == pCompartmentDisabled->GetValue(&var)) {
                if (var.vt == VT_I4) { // Even VT_EMPTY, GetValue() can succeed
                    fDisabled = (BOOL)var.lVal;
                }
            }
            pCompartmentDisabled->Release();
        }

        // Check GUID_COMPARTMENT_EMPTYCONTEXT.
        if (pCompMgr->GetCompartment(GUID_COMPARTMENT_EMPTYCONTEXT, &pCompartmentEmptyContext) == S_OK) {

            VARIANT var;
            if (S_OK == pCompartmentEmptyContext->GetValue(&var)) {
                if (var.vt == VT_I4) { // Even VT_EMPTY, GetValue() can succeed
                    fDisabled = (BOOL)var.lVal;
                }
            }
            pCompartmentEmptyContext->Release();
        }

        pCompMgr->Release();
    }

Exit:
    if (pContext){
        pContext->Release();
	}

    if (pDocMgrFocus){
        pDocMgrFocus->Release();
	}

    return fDisabled;
}

//+---------------------------------------------------------------------------
//
// _IsKeyboardOpen
//
// GUID_COMPARTMENT_KEYBOARD_OPENCLOSE is the compartment in the thread manager
// object.
//
//----------------------------------------------------------------------------

BOOL CTextService::_IsKeyboardOpen()
{
    ITfCompartmentMgr *pCompMgr = NULL;
    BOOL fOpen = FALSE;

    if (_pThreadMgr->QueryInterface(IID_ITfCompartmentMgr, (void **)&pCompMgr) == S_OK) {

        ITfCompartment *pCompartment;
        if (pCompMgr->GetCompartment(GUID_COMPARTMENT_KEYBOARD_OPENCLOSE, &pCompartment) == S_OK) {

            VARIANT var;
            if (S_OK == pCompartment->GetValue(&var)) {
                if (var.vt == VT_I4) { // Even VT_EMPTY, GetValue() can succeed
                    fOpen = (BOOL)var.lVal;
                }
            }
        }
        pCompMgr->Release();
    }

    return fOpen;
}

//+---------------------------------------------------------------------------
//
// _SetKeyboardOpen
//
// GUID_COMPARTMENT_KEYBOARD_OPENCLOSE is the compartment in the thread manager
// object.
//
//----------------------------------------------------------------------------

HRESULT CTextService::_SetKeyboardOpen(BOOL fOpen)
{
    HRESULT hr = E_FAIL;
    ITfCompartmentMgr *pCompMgr = NULL;

    if (_pThreadMgr->QueryInterface(IID_ITfCompartmentMgr, (void **)&pCompMgr) == S_OK) {

        ITfCompartment *pCompartment;
        if (pCompMgr->GetCompartment(GUID_COMPARTMENT_KEYBOARD_OPENCLOSE, &pCompartment) == S_OK) {
            VARIANT var;
            var.vt = VT_I4;
            var.lVal = fOpen;

            hr = pCompartment->SetValue(_tfClientId, &var);
        }
        pCompMgr->Release();
    }

    return hr;
}

