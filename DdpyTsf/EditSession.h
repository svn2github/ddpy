#pragma once

#include "DdpyTsf.h"
#include "TextService.h"


// EditSession基类
class CEditSessionBase : public ITfEditSession
{
public:
    CEditSessionBase()
    {
		TsfDebug("CEditSessionBase()");
        _cRef = 1;
    }

    CEditSessionBase(ITfContext *pContext)
    {
		TsfDebug("CEditSessionBase(ITfContext *pContext)");
        _cRef = 1;
        _pContext = pContext;
        _pContext->AddRef();
    }

    virtual ~CEditSessionBase()
    {
		TsfDebug("~CEditSessionBase()");
        _pContext->Release();
    }

    // 自定义方法，简化调用
    HRESULT RequestEditSession(TfClientId clientId, DWORD dwFlags)
    {
        HRESULT hr;
        _pContext->RequestEditSession(clientId, this, dwFlags, &hr);
        return hr;
    }


    // IUnknown
    STDMETHODIMP QueryInterface(REFIID riid, void **ppvObj)
    {
        if (ppvObj == NULL){
            return E_INVALIDARG;
		}

        *ppvObj = NULL;

        if (IsEqualIID(riid, IID_IUnknown) || IsEqualIID(riid, IID_ITfEditSession)) {
            *ppvObj = (ITfLangBarItemButton *)this;
        }

        if (*ppvObj) {
            AddRef();
            return S_OK;
        }

        return E_NOINTERFACE;
    }

    STDMETHODIMP_(ULONG) AddRef(void)
    {
        return ++_cRef;
    }

    STDMETHODIMP_(ULONG) Release(void)
    {
        LONG cr = --_cRef;

        if (_cRef == 0) {
            delete this;
        }

        return cr;
    }

    // ITfEditSession
    virtual STDMETHODIMP DoEditSession(TfEditCookie ec) = 0;

protected:
    ITfContext *_pContext;

private:
    LONG _cRef;     // COM ref count
};


// 插入文本用EditSession类
class CEditSessionInsertText : public CEditSessionBase
{
public:
    CEditSessionInsertText(ITfContext *pContext, WCHAR *pwchText) : CEditSessionBase(pContext)
    {
		TsfDebug("CEditSessionInsertText(ITfContext *pContext, WCHAR *pwchText)");
        //_pContext = pContext;
        //_pContext->AddRef();
		_pwchText = pwchText;
    }

	// ITfEditSession
    STDMETHODIMP DoEditSession(TfEditCookie ec);


private:
    WCHAR *_pwchText;

	// 通过ITfInsertAtSelection接口插入文本
	void _InsertTextAtSelection(TfEditCookie ec,  WCHAR *pwchText);

};


// 取得编码位置用EditSession类
class CEditSessionCaretPosition : public CEditSessionBase
{
public:
    CEditSessionCaretPosition(ITfContext *pContext, CTextService *pTextService) : CEditSessionBase(pContext)
    {
		TsfDebug("CEditSessionCaretPosition(ITfContext *pContext, CTextService *pTextService)");
        _pTextService = pTextService;
    }
    virtual ~CEditSessionCaretPosition()
    {
		TsfDebug("~CEditSessionCaretPosition()");
        _pTextService = NULL;
    }

	// ITfEditSession
    STDMETHODIMP DoEditSession(TfEditCookie ec);

    // 取得输入点位置
    RECT GetCaretPosition()
    {
        return _rc;
    }

private:
    CTextService *_pTextService;
    RECT _rc;

};
