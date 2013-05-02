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
// ----------------------------------


// -------------- Ime --------------
BOOL SetResultString(HIMC hImc, CComBSTR &sResult);
BOOL SetResult(HIMC hImc, LPCWSTR sResult);
BOOL SendStartEndMsg( HIMC hImc );
void GetPositionInfo(HIMC hImc, ImeKeyResult &lkr);
void HnadleImeNotify(WPARAM wp, LPARAM lp);

extern VARIANT_BOOL isWuNaiApp;
// ----------------------------------


// -------------- Key --------------
BOOL HandleKeys(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState);
BOOL FilterKeys(UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState);
BOOL HandleNotImeKeys(UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState);
BOOL HandleImeKeys(HIMC hImc, UINT iKey, LPARAM lpKeyData, CONST LPBYTE lpbKeyState);
// ----------------------------------


// -------------- Log --------------
void ImeDebug(char * text);
void ImeError(char * text);
// ----------------------------------
