
#include "DdpyTsf.h"
#include "TextService.h"


STDAPI CTextService::GetDisplayName(BSTR *pbstrName)
{
	TsfDebug("CTextService::ITfFnConfigure:GetDisplayName");

	if(pbstrName == NULL) {
		return E_INVALIDARG;
	}

	BSTR bstrName;
	*pbstrName = NULL;

	bstrName = SysAllocString(TEXTSERVICE_DESC);

	if(bstrName == NULL) {
		return E_OUTOFMEMORY;
	}

	*pbstrName = bstrName;

	return S_OK;
}


STDAPI CTextService::Show(HWND hwndParent, LANGID langid, REFGUID rguidProfile)
{
	TsfDebug("CTextService::ITfFnConfigure:Show");

	ComImeConfigure();

	return S_OK;
}
