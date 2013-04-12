#include "stdafx.h"


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
			ImeLog("[ComInit] 1 Call CoInitialize Failed");
			return FALSE;
		}
             
		rc = CLSIDFromProgID(ComClsName, &clsId);
		if (FAILED(rc)) {
			ImeLog("[ComInit] 2 Call CLSIDFromProgID Failed");
			return FALSE;
		}

		rc = CoCreateInstance(clsId, NULL, CLSCTX_INPROC_SERVER, __uuidof(_ComClass), (LPVOID*) &pComCls);
		if (FAILED(rc)) {
			ImeLog("[ComInit] 3 Call CoCreateInstance Failed");
			return FALSE;
		}

		return TRUE;
	}catch(...){
		ImeLog("[ComInit] Exception");
		return FALSE;
	}
}

BOOL ComImeProcessKey(UINT iKey, ImeKeyResult * ikr, BSTR * sResult){
	if (!pComCls){
		ImeLog("[ComImeProcessKey] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeProcessKey(iKey, ikr, sResult);
		if (FAILED(hr)){
			ImeLog("[ComImeProcessKey] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeLog("[ComImeProcessKey] Exception");
		return FALSE;
	}
}


BOOL ComImeSelect (BOOL bSel){

	if (!pComCls){
		ImeLog("[ComImeSelect] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeSelect( bSel, &isNeedStartEndMsg);
		if (FAILED(hr)){
			ImeLog("[ComImeSelect] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeLog("[ComImeSelect] Exception");
		return FALSE;
	}
}

BOOL ComImeConfigure(){

	if (!pComCls){
		ImeLog("[ComImeConfigure] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeConfigure();
		if (FAILED(hr)){
			ImeLog("[ComImeConfigure] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeLog("[ComImeConfigure] Exception");
		return FALSE;
	}
}

BOOL ComImeSetActiveContext(BOOL bSetActive){

	if (!pComCls){
		ImeLog("[ComImeSetActiveContext] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ImeSetActiveContext(bSetActive);
		if (FAILED(hr)){
			ImeLog("[ComImeSetActiveContext] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeLog("[ComImeSetActiveContext] Exception");
		return FALSE;
	}
}

BOOL ComDebug(LPCWSTR str){

#ifdef DEVELOP

	if (!pComCls){
		ImeLog("[ComDebug] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->Debug((_bstr_t)str);
		if (FAILED(hr)){
			ImeLog("[ComDebug] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeLog("[ComDebug] Exception");
		return FALSE;
	}

#endif

	return true;
}


BOOL ComShowStatusText(unsigned short idx, LPCWSTR str){

	if (!pComCls){
		ImeLog("[ComShowStatusText] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->ShowStatusText(idx, (_bstr_t)str);
		if (FAILED(hr)){
			ImeLog("[ComShowStatusText] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeLog("[ComShowStatusText] Exception");
		return FALSE;
	}
}

BOOL ComSetUiHwnd(long hwnd){

	if (!pComCls){
		ImeLog("[ComSetUiHwnd] ComObject Null");
		return FALSE;
	}

	try{
		HRESULT hr = pComCls->SetUiHwnd(hwnd);
		if (FAILED(hr)){
			ImeLog("[ComSetUiHwnd] Call COM Failed");
		}
		return !FAILED(hr);
	}catch(...){
		ImeLog("[ComSetUiHwnd] Exception");
		return FALSE;
	}
}

