#include "DdpyTsf.h"


#define LogFileXp  "C:\\Documents and Settings\\All Users\\Application Data\\DanDing\\Log\\TsfLog-%d-%02d-%02d.txt"
#define LogFileWin7  "C:\\ProgramData\\DanDing\\Log\\TsfLog-%d-%02d-%02d.txt"

#define LOGFILE  "C:\\Documents and Settings\\All Users\\Application Data\\DanDing\\Log\\TsfLog-%d-%02d-%02d.txt"


void WriteLog(char * sFormat, char * args)
{
#ifdef LOGFILE

    char filePath[1024];
    SYSTEMTIME st;  
    GetLocalTime(&st);  

    OSVERSIONINFO   osver;    
    osver.dwOSVersionInfoSize   =   sizeof(OSVERSIONINFO);    
    GetVersionEx(&osver);   

	if(osver.dwMajorVersion == 5 && osver.dwMinorVersion == 1) {
        // XP
		sprintf_s(filePath, LogFileXp, st.wYear, st.wMonth, st.wDay);
	}else if(osver.dwMajorVersion ==  6 && osver.dwMinorVersion == 1) {
        // Win7
		sprintf_s(filePath, LogFileWin7, st.wYear, st.wMonth, st.wDay);
	}

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
