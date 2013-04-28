#pragma once

#include "stdafx.h"

#define UiClsName      _T("DdpyIme")


// -------------- Com --------------
#import "../Release/DdpyCom.tlb" no_namespace, raw_interfaces_only
#define ComClsName      OLESTR("DdpyCom.ComClass")

BOOL ComInit();
BOOL ComImeProcessKey(UINT iKey, ImeKeyResult * ikr, BSTR * sResult);
BOOL ComImeSelect(BOOL bSelect);
BOOL ComImeConfigure();
BOOL ComImeSetActiveContext(BOOL bSetActive);
BOOL ComDebug(LPCWSTR str);

BOOL ComShowStatusText(unsigned short idx, LPCWSTR str);
BOOL ComSetUiHwnd(long hwnd);

BOOL IsNeedSendStartEndMsg();
// ----------------------------------


// -------------- Ime --------------
BOOL SetResultString(HIMC hImc, CComBSTR &sResult);
BOOL SetResult(HIMC hImc, LPCWSTR sResult);
BOOL SendStartEndMsg( HIMC hImc );

void GetPositionInfo(HIMC hImc, ImeKeyResult &lkr);
void ResetMode();
BOOL IsOpenImeKey();

BOOL SetFieldValue(UINT fldIdex, BOOL bValue);
// ----------------------------------


// -------------- Key --------------
BOOL HandleKeys(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState);
BOOL FilterKeys(UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState);
BOOL HandleNotImeKeys(UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState);
BOOL HandleImeKeys(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState);
// ----------------------------------

void ImeDebug(char * text);
void ImeInfo(char * text);
void ImeError(char * text);
