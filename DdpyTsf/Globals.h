#pragma once

#include "StdAfx.h"

//#ifndef GLOBALS_H
//#define GLOBALS_H


void DllAddRef();
void DllRelease();

#define ARRAY_SIZE(a) (sizeof(a)/sizeof(a[0]))

#define TEXTSERVICE_LANGID	MAKELANGID(LANG_CHINESE, SUBLANG_CHINESE_SIMPLIFIED) // 简体中文
#define TEXTSERVICE_DESC	L"淡定拼音输入法 TSF"
#define TEXTSERVICE_DESC_A  "淡定拼音输入法 TSF"
#define TEXTSERVICE_MODEL	TEXT("Apartment")
#define TEXTSERVICE_ICON_INDEX	0

extern HINSTANCE g_hInst;
extern LONG g_cRefDll;
extern CRITICAL_SECTION g_cs;

extern const CLSID c_clsidTextService;
extern const GUID c_guidProfile;

extern SYSTEMTIME timeStart;

//#endif // GLOBALS_H

