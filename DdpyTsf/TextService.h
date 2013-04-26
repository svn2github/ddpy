#pragma once


#include "Globals.h"

class CTextService : public ITfTextInputProcessor
					,public ITfThreadMgrEventSink
					,public ITfTextEditSink
					,public ITfKeyEventSink
					,public ITfCompositionSink
					,public ITfThreadFocusSink
					,public ITfFnConfigure
{
public:

	// ----------- 构造函数/析构函数 -----------
	CTextService()
	{
		DllAddRef();

		// COM
		_cRef = 1;

		// ITfThreadMgrEventSink
		_pThreadMgr = NULL;
		_dwThreadMgrEventSinkCookie = TF_INVALID_COOKIE;

		// ITfTextEditSink
		_pTextEditSinkContext = NULL;
		_dwTextEditSinkCookie = TF_INVALID_COOKIE;

		// ITfThreadFocusSink
		_dwThreadFocusSinkCookie = TF_INVALID_COOKIE;
	}

    ~CTextService()
	{
		DllRelease();
	}
	// -----------------------------------------


	// ------------------ COM ------------------
	// TSF实现的输入法要求必需是个COM
	static HRESULT CreateInstance(IUnknown *pUnkOuter, REFIID riid, void **ppvObj);

	// COM接口：IUnknown
	STDMETHODIMP QueryInterface(REFIID riid, void **ppvObj);
	STDMETHODIMP_(ULONG) AddRef(void);
	STDMETHODIMP_(ULONG) Release(void);
	// -----------------------------------------


	// --------- ITfTextInputProcessor ---------
	// 打开关闭输入法，必需实现的接口，TSF输入法注册后由系统触发调用
	STDMETHODIMP Activate(ITfThreadMgr *pThreadMgr, TfClientId tfClientId);	// 打开输入法
	STDMETHODIMP Deactivate();                                              // 关闭输入法
	// -----------------------------------------


	// --------- ITfThreadMgrEventSink ---------
	// 线程管理事件响应，打开输入法时注册，关闭输入法时注销
	STDMETHODIMP OnInitDocumentMgr(ITfDocumentMgr *pDocMgr);
	STDMETHODIMP OnUninitDocumentMgr(ITfDocumentMgr *pDocMgr);
	STDMETHODIMP OnSetFocus(ITfDocumentMgr *pFocus, ITfDocumentMgr *pPrevFocus); // 焦点变化事件
	STDMETHODIMP OnPushContext(ITfContext *pContext);
	STDMETHODIMP OnPopContext(ITfContext *pContext);
	// -----------------------------------------


	// ------------ ITfTextEditSink ------------
	// 文本变化事件响应，打开输入法时存在焦点或焦点发生变化时注册，关闭输入法时注销
	STDMETHODIMP OnEndEdit(ITfContext *pContext, TfEditCookie ecReadOnly, ITfEditRecord *pEditRecord);
	// -----------------------------------------


    // ------------ ITfKeyEventSink ------------
	// 键盘事件响应，打开输入法时注册，关闭输入法时注销
    STDMETHODIMP OnSetFocus(BOOL fForeground);
    STDMETHODIMP OnTestKeyDown(ITfContext *pContext, WPARAM wParam, LPARAM lParam, BOOL *pfEaten);
    STDMETHODIMP OnKeyDown(ITfContext *pContext, WPARAM wParam, LPARAM lParam, BOOL *pfEaten);
    STDMETHODIMP OnTestKeyUp(ITfContext *pContext, WPARAM wParam, LPARAM lParam, BOOL *pfEaten);
    STDMETHODIMP OnKeyUp(ITfContext *pContext, WPARAM wParam, LPARAM lParam, BOOL *pfEaten);
    STDMETHODIMP OnPreservedKey(ITfContext *pContext, REFGUID rguid, BOOL *pfEaten);
	// -----------------------------------------


    // ----------- ITfCompositionSink ----------
    // 编码事件响应（无奈），StartComposition时调用
    STDMETHODIMP OnCompositionTerminated(TfEditCookie ecWrite, ITfComposition *pComposition);
	// -----------------------------------------


    // ----------- ITfThreadFocusSink ----------
    // 焦点事件响应(对应ImeSetActiveContext但更烂)，打开输入法时注册，关闭输入法时注销
	STDMETHODIMP OnSetThreadFocus();                // 得到焦点
	STDMETHODIMP OnKillThreadFocus();               // 失去焦点
	// -----------------------------------------


    // ------------- ITfFnConfigure ------------
	// 系统语言配置窗口事件响应
	STDMETHODIMP GetDisplayName(BSTR *pbstrName);							  // 取得本输入法名称
	STDMETHODIMP Show(HWND hwndParent, LANGID langid, REFGUID rguidProfile);  // 选本输入法后点击“属性”按钮触发
	// -----------------------------------------



    // ---------------- 光标位置 ---------------
	void SetPosition(long x, long y,long h){
		_PosX = x;
		_PosY = y;
		_PosH = h;
	}
	long GetPositionX(){
		return _PosX;
	}
	long GetPositionY(){
		return _PosY;
	}
	long GetPositionH(){
		return _PosH;
	}
	// -----------------------------------------


private:

    // ---------------- 光标位置 ---------------
	long _PosX;
	long _PosY;
	long _PosH;
	// -----------------------------------------


	// ------------------ COM ------------------
	LONG _cRef;		// COM引用计数器
	// -----------------------------------------


	// --------- ITfTextInputProcessor ---------
	// TSF框架生成，打开输入法时参数传入手动保存，关闭输入法时销毁
	ITfThreadMgr *_pThreadMgr;
	TfClientId _tfClientId;
	// -----------------------------------------


	// --------- ITfThreadMgrEventSink ---------
	// 在打开输入法时调用初始化，关闭输入法时调用注销
	BOOL _InitThreadMgrEventSink();		// 初始化
	void _UninitThreadMgrEventSink();	// 注销

	DWORD _dwThreadMgrEventSinkCookie;
	// -----------------------------------------


	// ------------ ITfTextEditSink ------------
	// 在打开输入法时调用初始化，关闭输入法时调用注销
	BOOL _InitTextEditSink(ITfDocumentMgr *pDocMgr); // 初始化
	BOOL _UninitTextEditSink();	                     // 注销

	ITfContext *_pTextEditSinkContext;
	DWORD _dwTextEditSinkCookie;
	// -----------------------------------------


	// ------------ ITfKeyEventSink ------------
	// 在打开输入法时调用初始化，关闭输入法时调用注销
    BOOL _InitKeyEventSink();						// 初始化
    void _UninitKeyEventSink();						// 注销

    void HandleKeys(ITfContext *pContext, WPARAM iKey, LPARAM lParam, bool isKeyDown);
    BOOL _IsKeyEaten(WPARAM wParam);
	// -----------------------------------------


	// -------------- Compartment --------------
    BOOL    _IsKeyboardDisabled();
    BOOL    _IsKeyboardOpen();
    HRESULT _SetKeyboardOpen(BOOL fOpen);
	// -----------------------------------------


    // ----------- ITfThreadFocusSink ----------
	BOOL _InitThreadFocusSink();					// 初始化
    void _UninitThreadFocusSink();					// 注销
	DWORD _dwThreadFocusSinkCookie;
	// -----------------------------------------


};

