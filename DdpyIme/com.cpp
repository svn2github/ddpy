#include "DdpyIme.h"


_ComClass * pComCls;
VARIANT_BOOL isWuNaiApp;

BOOL ComInit(){

	HRESULT hr;
    HRESULT rc;
	CLSID clsId;

	try{
	    if (pComCls){
		    return TRUE;
	    }

		hr = CoInitialize(NULL);
		if (FAILED(hr)){
			ImeError("[ComInit] 1 Call CoInitialize Failed");
			return FALSE;
		}
             
		rc = CLSIDFromProgID(ComClsName, &clsId);
		if (FAILED(rc)) {
			ImeError("[ComInit] 2 Call CLSIDFromProgID Failed");
			return FALSE;
		}

		rc = CoCreateInstance(clsId, NULL, CLSCTX_INPROC_SERVER, __uuidof(_ComClass), (LPVOID*) &pComCls);
		if (FAILED(rc)) {
			ImeError("[ComInit] 3 Call CoCreateInstance Failed");
			return FALSE;
		}

		hr = pComCls->Init(&isWuNaiApp);
		if (FAILED(hr)){
			ImeError("[ComInit] Call Init Failed");
			return FALSE;
		}

		return TRUE;
	}catch(...){
		ImeError("[ComInit] Exception");
		return FALSE;
	}
}

BOOL ComImeProcessKey(UINT iKey, ImeKeyResult * ikr, BSTR * sResult){
	if (!pComCls){
        if ( !ComInit() ){
		    ImeError("[ComImeProcessKey] ComInit Failed");
		    return FALSE;
        }
	}

	try{
		HRESULT hr = pComCls->ImeProcessKey(iKey, ikr, sResult);
		if (FAILED(hr)){
			ImeError("[ComImeProcessKey] Call COM Failed");
            pComCls = NULL;
		}
		return !FAILED(hr);
	}catch(...){
		ImeError("[ComImeProcessKey] Exception");
		return FALSE;
	}
}


BOOL ComImeSelect (BOOL bSel){

	if (!pComCls){
        if ( !ComInit() ){
		    ImeError("[ComImeSelect] ComInit Failed");
		    return FALSE;
        }
	}

	try{
		HRESULT hr = pComCls->ImeSelect( bSel);
		if (FAILED(hr)){
			ImeError("[ComImeSelect] Call COM Failed");
            pComCls = NULL;
		}
		return !FAILED(hr);
	}catch(...){
		ImeError("[ComImeSelect] Exception");
		return FALSE;
	}
}

BOOL ComImeConfigure(){

	if (!pComCls){
        if ( !ComInit() ){
		    ImeError("[ComImeConfigure] ComInit Failed");
		    return FALSE;
        }
	}

	try{
		HRESULT hr = pComCls->ImeConfigure();
		if (FAILED(hr)){
			ImeError("[ComImeConfigure] Call COM Failed");
            pComCls = NULL;
		}
		return !FAILED(hr);
	}catch(...){
		ImeError("[ComImeConfigure] Exception");
		return FALSE;
	}
}

BOOL ComImeSetActiveContext(BOOL bSetActive){

	if (!pComCls){
        if ( !ComInit() ){
		    ImeError("[ComImeSetActiveContext] ComInit Failed");
		    return FALSE;
        }
	}

	try{
		HRESULT hr = pComCls->ImeSetActiveContext(bSetActive);
		if (FAILED(hr)){
			ImeError("[ComImeSetActiveContext] Call COM Failed");
            pComCls = NULL;
		}
		return !FAILED(hr);
	}catch(...){
		ImeError("[ComImeSetActiveContext] Exception");
		return FALSE;
	}
}

BOOL ComDebug(LPCWSTR str){

#ifdef DEVELOP

	if (!pComCls){
        if ( !ComInit() ){
		    ImeError("[ComDebug] ComInit Failed");
		    return FALSE;
        }
	}

	try{
		HRESULT hr = pComCls->Debug((_bstr_t)str);
		if (FAILED(hr)){
			ImeError("[ComDebug] Call COM Failed");
            pComCls = NULL;
		}
		return !FAILED(hr);
	}catch(...){
		ImeError("[ComDebug] Exception");
		return FALSE;
	}

#endif

	return TRUE;
}
