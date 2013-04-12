#include "stdafx.h"
#include <shlobj.h>  
//#pragma comment(lib, "shell32.lib")  


#define LOGFILE  "d:/ImeLog.txt"


void WriteLog(char * pszFormat,...)
{
	va_list args; 
	char buf[1024];
	va_start( args, pszFormat );
	_vsnprintf(buf,sizeof(buf)-1, pszFormat,args);
	va_end (args);
	buf[sizeof(buf)-1]=0;
	OutputDebugString((LPCWSTR)buf);
#ifdef LOGFILE
	{

	FILE *f=fopen(buf, "a+"); 

	if(f)
	{
		fprintf(f,buf);
		fclose(f);
	}
	}
#endif
}

void ImeLog(char * text)
{

	WriteLog(text);
	WriteLog("\n");
}

