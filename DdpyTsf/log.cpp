#include "DdpyTsf.h"


#define LOGFILE  "C:\\Documents and Settings\\All Users\\Application Data\\DanDing\\Log\\TsfLog-%d-%02d-%02d.txt"


void WriteLog(char * sFormat, char * args)
{
#ifdef LOGFILE

    SYSTEMTIME st;  
    GetLocalTime(&st);  

    char filePath[1024];
    sprintf_s(filePath, LOGFILE, st.wYear, st.wMonth, st.wDay);

    FILE *fp;  
    fp = fopen(filePath, "at+");  
    fprintf(fp, "%d-%02d-%02d %02d:%02d:%02d.%03d ", st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond, st.wMilliseconds);  
    fprintf(fp, sFormat, args);
    fprintf(fp, "\n");
    fclose(fp);  

#endif
}

void TsfDebug(char * sFormat, ...)
{
#if defined (DEVELOP)
	va_list args; 
	va_start( args, sFormat );
	WriteLog(sFormat, args);
#endif
}

void TsfError(char * sFormat, ...)
{
	va_list args; 
	va_start( args, sFormat );
	WriteLog(sFormat, args);
}

void TsfInfo(char * sFormat, ...)
{
	va_list args; 
	va_start( args, sFormat );
	WriteLog(sFormat, args);
}
