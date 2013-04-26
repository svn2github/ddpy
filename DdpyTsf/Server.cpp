#undef UNICODE
#undef _UNICODE

#include "Globals.h"
#include "DdpyTsf.h"
#include "TextService.h"

class CClassFactory;
static CClassFactory *g_ObjectInfo[1] = { NULL };

static const TCHAR c_szInfoKeyPrefix[] = TEXT("CLSID\\");
static const TCHAR c_szInProcSvr32[] = TEXT("InProcServer32");
static const TCHAR c_szModelName[] = TEXT("ThreadingModel");



class CClassFactory : public IClassFactory
{
public:
	// IUnknown methods
	STDMETHODIMP QueryInterface(REFIID riid, void **ppvObj);
	STDMETHODIMP_(ULONG) AddRef(void);
	STDMETHODIMP_(ULONG) Release(void);

	// IClassFactory methods
	STDMETHODIMP CreateInstance(IUnknown *pUnkOuter, REFIID riid, void **ppvObj);
	STDMETHODIMP LockServer(BOOL fLock);

	// Constructor
	CClassFactory(REFCLSID rclsid, HRESULT (*pfnCreateInstance)(IUnknown *pUnkOuter, REFIID riid, void **ppvObj))
		: _rclsid(rclsid)
	{
		_pfnCreateInstance = pfnCreateInstance;
	}

public:
	REFCLSID _rclsid;
	HRESULT (*_pfnCreateInstance)(IUnknown *pUnkOuter, REFIID riid, void **ppvObj);
};

//	CClassFactory::QueryInterface
STDAPI CClassFactory::QueryInterface(REFIID riid, void **ppvObj)
{
	TsfDebug("CClassFactory::QueryInterface");

	if (IsEqualIID(riid, IID_IClassFactory) || IsEqualIID(riid, IID_IUnknown)) {
		*ppvObj = this;
		DllAddRef();
		return NOERROR;
	}

	*ppvObj = NULL;
	return E_NOINTERFACE;
}

//	CClassFactory::AddRef
STDAPI_(ULONG) CClassFactory::AddRef()
{
	TsfDebug("CClassFactory::AddRef");

	DllAddRef();
	return g_cRefDll+1; // -1 w/ no refs
}

//	CClassFactory::Release
STDAPI_(ULONG) CClassFactory::Release()
{
	TsfDebug("CClassFactory::Release");

	DllRelease();
	return g_cRefDll+1; // -1 w/ no refs
}

//	CClassFactory::CreateInstance
STDAPI CClassFactory::CreateInstance(IUnknown *pUnkOuter, REFIID riid, void **ppvObj)
{
	TsfDebug("CClassFactory::CreateInstance");

	return _pfnCreateInstance(pUnkOuter, riid, ppvObj);
}

//	CClassFactory::LockServer
STDAPI CClassFactory::LockServer(BOOL fLock)
{
	TsfDebug("CClassFactory::LockServer");

	if (fLock) {
		DllAddRef();
	} else {
		DllRelease();
	}

	return S_OK;
}




BOOL _CLSIDToStringA(REFGUID refGUID, char *pchA)
{
	static const BYTE GuidMap[] = {3, 2, 1, 0, '-', 5, 4, '-', 7, 6, '-', 8, 9, '-', 10, 11, 12, 13, 14, 15};
	static const char szDigits[] = "0123456789ABCDEF";

	int i;
	char *p = pchA;

	const BYTE * pBytes = (const BYTE *) &refGUID;

	*p++ = '{';
	for (i = 0; i < sizeof(GuidMap); i++) {
		if (GuidMap[i] == '-') {
			*p++ = '-';
		} else {
			*p++ = szDigits[ (pBytes[GuidMap[i]] & 0xF0) >> 4 ];
			*p++ = szDigits[ (pBytes[GuidMap[i]] & 0x0F) ];
		}
	}

	*p++ = '}';
	*p	 = '\0';

	return TRUE;
}

// _RecurseDeleteKey is necessary because on NT RegDeleteKey doesn't work if the specified key has subkeys
LONG _RecurseDeleteKey(HKEY hParentKey, LPCTSTR lpszKey)
{
	HKEY hKey;
	LONG lRes;
	FILETIME time;
	TCHAR szBuffer[256];
	DWORD dwSize = ARRAY_SIZE(szBuffer);

	if (RegOpenKey(hParentKey, lpszKey, &hKey) != ERROR_SUCCESS) {
		return ERROR_SUCCESS; // assume it couldn't be opened because it's not there
	}

	lRes = ERROR_SUCCESS;
	while (RegEnumKeyEx(hKey, 0, szBuffer, &dwSize, NULL, NULL, NULL, &time)==ERROR_SUCCESS) {
		szBuffer[ARRAY_SIZE(szBuffer)-1] = '\0';
		lRes = _RecurseDeleteKey(hKey, szBuffer);
		if (lRes != ERROR_SUCCESS)
			break;
		dwSize = ARRAY_SIZE(szBuffer);
	}
	RegCloseKey(hKey);
	return lRes == ERROR_SUCCESS ? RegDeleteKey(hParentKey, lpszKey) : lRes;
}

// 在TSF中注册 TextService
BOOL TsfRegisterProfiles()
{
	TsfDebug("Server:TsfRegisterProfiles");

	ITfInputProcessorProfiles *pInputProcessProfiles;
	WCHAR achIconFile[MAX_PATH];
	char achFileNameA[MAX_PATH];
	DWORD cchA;
	int cchIconFile;
	HRESULT hr;

	hr = CoCreateInstance(CLSID_TF_InputProcessorProfiles, NULL, CLSCTX_INPROC_SERVER,
						  IID_ITfInputProcessorProfiles, (void**)&pInputProcessProfiles);

	if (hr != S_OK){
		TsfDebug("Server:TsfRegisterProfiles - CoCreateInstance Failed");
		return E_FAIL;
	}

	// 让TSF认识我们的 TextService
    hr = pInputProcessProfiles->Register(c_clsidTextService);

	if (hr != S_OK){
		TsfDebug("Server:TsfRegisterProfiles - Register Failed");
		goto Exit;
	}

	cchA = GetModuleFileNameA(g_hInst, achFileNameA, ARRAY_SIZE(achFileNameA));

	cchIconFile = MultiByteToWideChar(CP_ACP, 0, achFileNameA, cchA, achIconFile, ARRAY_SIZE(achIconFile)-1);
	achIconFile[cchIconFile] = '\0';

	// 加上中文简体输入法
	hr = pInputProcessProfiles->AddLanguageProfile(c_clsidTextService,
								  TEXTSERVICE_LANGID, 
								  c_guidProfile, 
								  TEXTSERVICE_DESC, 
								  (ULONG)wcslen(TEXTSERVICE_DESC),
								  achIconFile,
								  cchIconFile,
								  TEXTSERVICE_ICON_INDEX);

Exit:
	pInputProcessProfiles->Release();
	return (hr == S_OK);
}

// 在TSF中注销 TextService
void TsfUnregisterProfiles()
{
	TsfDebug("Server:TsfUnregisterProfiles");

	HRESULT hr;

	ITfInputProcessorProfiles *pInputProcessProfiles;
	hr = CoCreateInstance(CLSID_TF_InputProcessorProfiles, NULL, CLSCTX_INPROC_SERVER,
						  IID_ITfInputProcessorProfiles, (void**)&pInputProcessProfiles);

	if (hr != S_OK){
		TsfDebug("Server:TsfUnregisterProfiles - CoCreateInstance Failed");
		return;
	}

	pInputProcessProfiles->Unregister(c_clsidTextService);
	pInputProcessProfiles->Release();
}

BOOL TsfRegisterCategories()
{
	TsfDebug("Server:TsfRegisterCategories");
	HRESULT hr;

	ITfCategoryMgr *pCategoryMgr;
	hr = CoCreateInstance(CLSID_TF_CategoryMgr, NULL, CLSCTX_INPROC_SERVER, IID_ITfCategoryMgr, (void**)&pCategoryMgr);

	if (hr != S_OK){
		TsfDebug("Server:TsfRegisterCategories - CoCreateInstance Failed");
		return FALSE;
	}

	// register this text service to GUID_TFCAT_TIP_KEYBOARD category.
	hr = pCategoryMgr->RegisterCategory(c_clsidTextService,	GUID_TFCAT_TIP_KEYBOARD, c_clsidTextService);

	// register this text service to GUID_TFCAT_DISPLAYATTRIBUTEPROVIDER category.
	hr = pCategoryMgr->RegisterCategory(c_clsidTextService,	GUID_TFCAT_DISPLAYATTRIBUTEPROVIDER, c_clsidTextService);

	pCategoryMgr->Release();

	return (hr == S_OK);
}

void TsfUnregisterCategories()
{
	TsfDebug("Server:TsfUnregisterCategories");
	HRESULT hr;

	ITfCategoryMgr *pCategoryMgr;
    hr = CoCreateInstance(CLSID_TF_CategoryMgr, NULL, CLSCTX_INPROC_SERVER, IID_ITfCategoryMgr, (void**)&pCategoryMgr);

	if (hr != S_OK){
		TsfDebug("Server:TsfUnregisterCategories - CoCreateInstance Failed");
		return;
	}

	// unregister this text service from GUID_TFCAT_TIP_KEYBOARD category.
	pCategoryMgr->UnregisterCategory(c_clsidTextService, GUID_TFCAT_TIP_KEYBOARD, c_clsidTextService);

	// unregister this text service from GUID_TFCAT_DISPLAYATTRIBUTEPROVIDER category.
	pCategoryMgr->UnregisterCategory(c_clsidTextService, GUID_TFCAT_DISPLAYATTRIBUTEPROVIDER, c_clsidTextService);

	pCategoryMgr->Release();
	return;
}

// 在注册表中注册 TextService 为 COM
BOOL TsfRegisterServer()
{
	TsfDebug("Server:TsfRegisterServer");

	DWORD dw;
	HKEY hKey;
	HKEY hSubKey;
	BOOL fRet;
	TCHAR achIMEKey[ARRAY_SIZE(c_szInfoKeyPrefix) + 38]; // 38 = strlen("{xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx}")
	TCHAR achFileName[MAX_PATH];


	if (!_CLSIDToStringA(c_clsidTextService,achIMEKey + ARRAY_SIZE(c_szInfoKeyPrefix) - 1)) {
		return FALSE;
	}

	memcpy(achIMEKey, c_szInfoKeyPrefix, sizeof(c_szInfoKeyPrefix)-sizeof(TCHAR));
	
	if (fRet = RegCreateKeyEx(HKEY_CLASSES_ROOT, achIMEKey, 0, NULL, REG_OPTION_NON_VOLATILE, KEY_WRITE, NULL, &hKey, &dw)
			== ERROR_SUCCESS)
	{
		fRet &= RegSetValueEx(hKey, NULL, 0, REG_SZ, (BYTE *)TEXTSERVICE_DESC_A, (lstrlen(TEXTSERVICE_DESC_A)+1)*sizeof(TCHAR))
			== ERROR_SUCCESS;

		if (fRet &= RegCreateKeyEx(hKey, c_szInProcSvr32, 0, NULL, REG_OPTION_NON_VOLATILE, KEY_WRITE, NULL, &hSubKey, &dw)
			== ERROR_SUCCESS)
		{
			dw = GetModuleFileNameA(g_hInst, achFileName, ARRAY_SIZE(achFileName));

			fRet &= RegSetValueEx(hSubKey, NULL, 0, REG_SZ, (BYTE *)achFileName, (lstrlen(achFileName)+1)*sizeof(TCHAR)) == ERROR_SUCCESS;
			fRet &= RegSetValueEx(hSubKey, c_szModelName, 0, REG_SZ, (BYTE *)TEXTSERVICE_MODEL, (lstrlen(TEXTSERVICE_MODEL)+1)*sizeof(TCHAR)) == ERROR_SUCCESS;
			RegCloseKey(hSubKey);
		}
		RegCloseKey(hKey);
	}

	return fRet;
}

// 在注册表中注销 TextService 的COM信息
void TsfUnregisterServer()
{
	TsfDebug("Server:TsfUnregisterServer");

	TCHAR achIMEKey[ARRAY_SIZE(c_szInfoKeyPrefix) + 38]; // 38 = strlen("{xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx}")

	if (!_CLSIDToStringA(c_clsidTextService,(char *) achIMEKey + ARRAY_SIZE(c_szInfoKeyPrefix) - 1)) {
		return;
	}

	memcpy(achIMEKey, c_szInfoKeyPrefix, sizeof(c_szInfoKeyPrefix)-sizeof(TCHAR));
	_RecurseDeleteKey(HKEY_CLASSES_ROOT, achIMEKey);
}




//	BuildGlobalObjects
void BuildGlobalObjects(void)
{
	// 生成CClassFactory对象
	g_ObjectInfo[0] = new CClassFactory(c_clsidTextService, CTextService::CreateInstance);
}

//	FreeGlobalObjects
void FreeGlobalObjects(void)
{
	// 释放CClassFactory对象
	for (int i = 0; i < ARRAY_SIZE(g_ObjectInfo); i++) {
		if (NULL != g_ObjectInfo[i]) {
			delete g_ObjectInfo[i];
			g_ObjectInfo[i] = NULL;
		}
	}
}

// 用于获得类工厂指针
STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, void **ppvObj)
{
	TsfDebug("DllGetClassObject");

	if (g_ObjectInfo[0] == NULL) {
		EnterCriticalSection(&g_cs);

		// need to check ref again after grabbing mutex
		if (g_ObjectInfo[0] == NULL) {
			BuildGlobalObjects();
		}

		LeaveCriticalSection(&g_cs);
	}

	if (IsEqualIID(riid, IID_IClassFactory) ||
		IsEqualIID(riid, IID_IUnknown))
	{
		for (int i = 0; i < ARRAY_SIZE(g_ObjectInfo); i++) {
			if (NULL != g_ObjectInfo[i] &&
				IsEqualGUID(rclsid, g_ObjectInfo[i]->_rclsid))
		   	{
				*ppvObj = (void *)g_ObjectInfo[i];
				DllAddRef();	// class factory holds DLL ref count
				return NOERROR;
			}
		}
	}

	*ppvObj = NULL;

	return CLASS_E_CLASSNOTAVAILABLE;
}

// 系统空闲时会调用这个函数，以确定是否可以卸载Dll
STDAPI DllCanUnloadNow(void)
{
	TsfDebug("DllCanUnloadNow");

	if (g_cRefDll >= 0) { // -1 with no refs
		return S_FALSE;
	}
	return S_OK;
}

// 删除注册表中COM组件的注册信息
STDAPI DllUnregisterServer(void)
{
	TsfDebug("DllUnregisterServer");

	// 注销输入法
	TsfUnregisterProfiles();
	TsfUnregisterCategories();
	TsfUnregisterServer();

	return S_OK;
}

// 将COM组件注册到注册表中
STDAPI DllRegisterServer(void)
{
	TsfDebug("DllRegisterServer");

	// 注册输入法
	if ( !TsfRegisterServer() || !TsfRegisterProfiles()	|| !TsfRegisterCategories()	) {

		DllUnregisterServer(); // 失败时注销
		return E_FAIL;
	}

	return S_OK;
}


void DllAddRef(void)
{
	TsfDebug("DllAddRef");

	InterlockedIncrement(&g_cRefDll);
}

void DllRelease(void)
{
	TsfDebug("DllRelease");

	if (InterlockedDecrement(&g_cRefDll) < 0) // g_cRefDll == -1 with zero refs
	{
		EnterCriticalSection(&g_cs);

		// need to check ref again after grabbing mutex
		if (g_ObjectInfo[0] != NULL) {
			FreeGlobalObjects();
		}

		LeaveCriticalSection(&g_cs);
	}
}

