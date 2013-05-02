#pragma once

#include "StdAfx.h"


// -------------- Com --------------
#import "../Release/DdpyCom.tlb" no_namespace, raw_interfaces_only
#define ComClsName      OLESTR("DdpyCom.ComClass")

BOOL ComInit();
BOOL ComImeProcessKey(UINT iKey, ImeKeyResult * ikr, BSTR * sResult);
BOOL ComImeSelect(BOOL bSelect);
BOOL ComImeConfigure();
BOOL ComImeSetActiveContext(BOOL bSetActive);
BOOL ComDebug(LPCWSTR str);


extern VARIANT_BOOL isWuNaiApp;
// ----------------------------------



void TsfDebug(char * sFormat, ...);
void TsfInfo(char * sFormat, ...);
void TsfError(char * sFormat, ...);


