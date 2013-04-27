#pragma once

#include "Globals.h"
#include "DdpyTsf.h"

SYSTEMTIME timeStart;


BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID pvReserved) {

	if (dwReason == DLL_PROCESS_ATTACH) {
TsfDebug("******************** DllMain DLL_PROCESS_ATTACH *********************");
		g_hInst = hInstance;

	GetLocalTime( &timeStart );

		if (!InitializeCriticalSectionAndSpinCount(&g_cs, 0)){
			TsfError("[DllMain] InitializeCriticalSectionAndSpinCount Failed");
			return FALSE;
		}

		//if (!ComInit()){
		//	TsfError("[DllMain] ComInit Failed");
		//	return FALSE;
		//}

	}else if (dwReason == DLL_PROCESS_DETACH) {
TsfDebug("DllMain DLL_PROCESS_DETACH");
		DeleteCriticalSection(&g_cs);
	}

	return TRUE;
}
