#include "DdpyIme.h"


_ComClass * pComCls;

VARIANT_BOOL isNeedStartEndMsg;

BOOL IsNeedSendStartEndMsg(){
	return (BOOL)isNeedStartEndMsg;
}


BOOL ComInit(){

	if (pComCls){
		return TRUE;
	}

	HRESULT hr;
    HRESULT rc;
	CLSID clsId;

	try{
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

		return TRUE;
	}catch(...){
		ImeError("[ComInit] Exception");
		return FALSE;
	}
}

BOOL ComImeProcessKey(UINT iKey, ImeKeyResult * ikr, BSTR * sResult){
	if (!pComCls){
		ImeError("[ComImeProcessKey] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeProcessKey(iKey, ikr, sResult);
		if (FAILED(hr)){
			ImeError("[ComImeProcessKey] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeError("[ComImeProcessKey] Exception");
		return FALSE;
	}
}


BOOL ComImeSelect (BOOL bSel){

	if (!pComCls){
		ImeError("[ComImeSelect] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeSelect( bSel, &isNeedStartEndMsg);
		if (FAILED(hr)){
			ImeError("[ComImeSelect] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeError("[ComImeSelect] Exception");
		return FALSE;
	}
}

BOOL ComImeConfigure(){

	if (!pComCls){
		ImeError("[ComImeConfigure] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeConfigure();
		if (FAILED(hr)){
			ImeError("[ComImeConfigure] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeError("[ComImeConfigure] Exception");
		return FALSE;
	}
}

BOOL ComImeSetActiveContext(BOOL bSetActive){

	if (!pComCls){
		ImeError("[ComImeSetActiveContext] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeSetActiveContext(bSetActive);
		if (FAILED(hr)){
			ImeError("[ComImeSetActiveContext] Call COM Failed");
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
		ImeError("[ComDebug] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->Debug((_bstr_t)str);
		if (FAILED(hr)){
			ImeError("[ComDebug] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeError("[ComDebug] Exception");
		return FALSE;
	}

#endif

	return TRUE;
}


BOOL ComShowStatusText(unsigned short idx, LPCWSTR str){

	if (!pComCls){
		ImeError("[ComShowStatusText] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ShowStatusText(idx, (_bstr_t)str);
		if (FAILED(hr)){
			ImeError("[ComShowStatusText] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeError("[ComShowStatusText] Exception");
		return FALSE;
	}
}
