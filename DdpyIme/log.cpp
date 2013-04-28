#include "stdafx.h"
#include <shlobj.h>  


//#define LOGFILE  "C:\\Documents and Settings\\All Users\\Application Data\\DanDing\\Log\\ImeLog.txt"
#define LOGFILE  "C:\\ProgramData\\DanDing\\Log\\ImeLog-%d-%02d-%02d.txt"


void WriteLog(char * sFormat)
{
#ifdef LOGFILE

    SYSTEMTIME st;  
    GetLocalTime(&st);  

    char filePath[1024];
    sprintf_s(filePath, LOGFILE, st.wYear, st.wMonth, st.wDay);

    FILE *fp;  
    fp = fopen(filePath, "at+");  
    fprintf(fp, "%d-%02d-%02d %02d:%02d:%02d.%03d ", st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond, st.wMilliseconds);  
    fprintf(fp, sFormat);
    fprintf(fp, "\n");
    fclose(fp);  

#endif
}


void ImeDebug(char * text)
{
#if defined (DEVELOP)
	WriteLog(text);
#endif
}

void ImeError(char * text)
{
	WriteLog(text);
}

void ImeInfo(char * text)
{
	WriteLog(text);
}
