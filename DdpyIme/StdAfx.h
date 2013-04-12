#pragma once

#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers


#define NOIME					// 不使用系统默认Imm.h

#include <windows.h>

#include <tchar.h>
#include <atlbase.h> 
#include "Imm.h"				// 使用工程目录中的Imm.h
#include "DdpyIme.h"

// #define DEVELOP
