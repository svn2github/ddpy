#include "DdpyTsf.h"


_ComClass * pComCls;

VARIANT_BOOL isNeedStartEndMsg;

BOOL IsNeedSendStartEndMsg(){
	return (BOOL)isNeedStartEndMsg;
}


BOOL ComInit(){
	HRESULT hr;
    HRESULT rc;
	CLSID clsId;

	try{
		hr = CoInitialize(NULL);
		if (FAILED(hr)){
			TsfError("[ComInit] 1 Call CoInitialize Failed");
			return FALSE;
		}
             
		rc = CLSIDFromProgID(ComClsName, &clsId);
		if (FAILED(rc)) {
			TsfError("[ComInit] 2 Call CLSIDFromProgID Failed");
			return FALSE;
		}

		rc = CoCreateInstance(clsId, NULL, CLSCTX_INPROC_SERVER, __uuidof(_ComClass), (LPVOID*) &pComCls);
		if (FAILED(rc)) {
			TsfError("[ComInit] 3 Call CoCreateInstance Failed");
			return FALSE;
		}

		return TRUE;
	}catch(...){
		TsfError("[ComInit] Exception");
		return FALSE;
	}
}

BOOL ComImeProcessKey(UINT iKey, ImeKeyResult * ikr, BSTR * sResult){
	if (!pComCls){
		TsfError("[ComImeProcessKey] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeProcessKey(iKey, ikr, sResult);
		if (FAILED(hr)){
			TsfError("[ComImeProcessKey] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		TsfError("[ComImeProcessKey] Exception");
		return FALSE;
	}
}


BOOL ComImeSelect (BOOL bSel){

	if (!pComCls){
		TsfError("[ComImeSelect] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeSelect( bSel, &isNeedStartEndMsg);
		if (FAILED(hr)){
			TsfError("[ComImeSelect] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		TsfError("[ComImeSelect] Exception");
		return FALSE;
	}
}

BOOL ComImeConfigure(){

	if (!pComCls){
		TsfError("[ComImeConfigure] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeConfigure();
		if (FAILED(hr)){
			TsfError("[ComImeConfigure] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		TsfError("[ComImeConfigure] Exception");
		return FALSE;
	}
}

BOOL ComImeSetActiveContext(BOOL bSetActive){

	if (!pComCls){
		TsfError("[ComImeSetActiveContext] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeSetActiveContext(bSetActive);
		if (FAILED(hr)){
			TsfError("[ComImeSetActiveContext] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		TsfError("[ComImeSetActiveContext] Exception");
		return FALSE;
	}
}

BOOL ComDebug(LPCWSTR str){

#ifdef DEVELOP

	if (!pComCls){
		TsfError("[ComDebug] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->Debug((_bstr_t)str);
		if (FAILED(hr)){
			TsfError("[ComDebug] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		TsfError("[ComDebug] Exception");
		return FALSE;
	}

#endif

	return true;
}


BOOL ComShowStatusText(unsigned short idx, LPCWSTR str){

	if (!pComCls){
		TsfError("[ComShowStatusText] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ShowStatusText(idx, (_bstr_t)str);
		if (FAILED(hr)){
			TsfError("[ComShowStatusText] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		TsfError("[ComShowStatusText] Exception");
		return FALSE;
	}
}

