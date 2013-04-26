
#include "DdpyTsf.h"
#include "TextService.h"
#include "EditSession.h"


STDAPI CTextService::OnCompositionTerminated(TfEditCookie ecWrite, ITfComposition *pComposition)
{
	TsfDebug("CTextService::OnCompositionTerminated");


    return S_OK;
}


