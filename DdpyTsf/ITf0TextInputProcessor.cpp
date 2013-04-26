#include "Globals.h"
#include "DdpyTsf.h"
#include "TextService.h"
//#include "EditSession.h"


// 打开输入法
STDAPI CTextService::Activate(ITfThreadMgr *pThreadMgr, TfClientId tfClientId)
{
	TsfDebug("CTextService:ITfTextInputProcessor::Activate");

	ComImeSelect(true); // 打开淡定输入法状态栏

	// 保存为全局变量备用
	_pThreadMgr = pThreadMgr;
	_tfClientId = tfClientId;
	_pThreadMgr->AddRef(); // 增加一个引用


	ITfDocumentMgr *pDocMgrFocus;


	//// 初始化 ITfThreadMgrEventSink
	//if (!_InitThreadMgrEventSink()){
	//	TsfError("CTextService:ITfTextInputProcessor::Activate - _InitThreadMgrEventSink Failed");
	//	goto ExitError;
	//}

	// 初始化 ITfTextEditSink
	if ((_pThreadMgr->GetFocus(&pDocMgrFocus) == S_OK) && (pDocMgrFocus != NULL)) {
		_InitTextEditSink(pDocMgrFocus);
		pDocMgrFocus->Release();
	}

	// 初始化 ITfKeyEventSink
	if (!_InitKeyEventSink()) {
		TsfDebug("CTextService:ITfTextInputProcessor::Activate - _InitKeyEventSink Failed");
		goto ExitError;
	}

	// 初始化 ITfThreadFocusSink
	if(!_InitThreadFocusSink()) {
		TsfDebug("CTextService:ITfTextInputProcessor::Activate - _InitThreadFocusSink Failed");
		goto ExitError;
	}


	// 打开输入法
	_SetKeyboardOpen(TRUE);

	return S_OK;

ExitError:

	TsfDebug("CTextService:ITfTextInputProcessor::Activate - Error");
	Deactivate(); // 保险起见调用注销
	return E_FAIL;
}

// 关闭输入法
STDAPI CTextService::Deactivate()
{
	TsfDebug("CTextService:ITfTextInputProcessor::Deactivate");

	ComImeSelect(false); // 关闭淡定输入法状态栏


	// 注销 ITfThreadFocusSink
	_UninitThreadFocusSink();

	// 注销 ITfKeyEventSink
	_UninitKeyEventSink();

	// 注销 ITfTextEditSink
	_UninitTextEditSink();

	//// 注销 ITfThreadMgrEventSink
	//_UninitThreadMgrEventSink();

	// 销毁打开输入法时保存的全局变量（TSF框架生成，经参数传入）
	if (_pThreadMgr != NULL) {
		_pThreadMgr->Release();
		_pThreadMgr = NULL;
	}
	_tfClientId = TF_CLIENTID_NULL;

	return S_OK;
}


