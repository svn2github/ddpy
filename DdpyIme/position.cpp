#include "stdafx.h"

void GetPositionInfo(HIMC hImc, ImeKeyResult &lkr)
{
	LPINPUTCONTEXT lpImc = (LPINPUTCONTEXT)ImmLockIMC(hImc);
	POINT pt = {0, 0};
	LONG height = 0;

	// 取得输入位置
	switch (lpImc->cfCompForm.dwStyle)
	{
		case CFS_POINT:
			if (lpImc->cfCompForm.rcArea.left == 0 && lpImc->cfCompForm.rcArea.top == 0){
				GetCaretPos(&pt);	// 位置为0时多数位置不正，改善使用GetCaretPos取得
			}else{
				pt = lpImc->cfCompForm.ptCurrentPos;
			}
			break;
		case CFS_FORCE_POSITION:
			pt = lpImc->cfCompForm.ptCurrentPos;
			break;
		case CFS_CANDIDATEPOS:
			pt = lpImc->cfCandForm[0].ptCurrentPos;
			break;
		case CFS_RECT:
			if (lpImc->cfCompForm.rcArea.left == 0 && lpImc->cfCompForm.rcArea.top == 0){
				GetCaretPos(&pt);	// 位置为0时多数位置不正，改善使用GetCaretPos取得
			}else{
				pt = lpImc->cfCompForm.ptCurrentPos;
			}
			break;
		case CFS_EXCLUDE:
			// 默认使用GetCaretPos取得
			GetCaretPos(&pt);
			break;
		default:
			// 默认使用GetCaretPos取得
			GetCaretPos(&pt);
			break;
	}

	// 调整屏幕相对坐标
	ClientToScreen(lpImc->hWnd, &pt);

	// 取得字体高度
	height = abs(lpImc->lfFont.W.lfHeight);
	if (height == 0)
	{
		HDC hDC = GetDC(lpImc->hWnd);
		SIZE sz = {0};
		GetTextExtentPoint(hDC, L"A", 1, &sz);
		height = sz.cy;
		ReleaseDC(lpImc->hWnd, hDC);
	}

	ImmUnlockIMC(hImc);

	// 返回坐标信息
	lkr.PosX = pt.x;			// 坐标 X
	lkr.PosY = pt.y;			// 坐标 Y
	lkr.PosH = height;	// 字体高

}
