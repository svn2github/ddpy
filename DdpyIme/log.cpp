#include "stdafx.h"

#define LOG
#define LogFileXp  "C:\\Documents and Settings\\All Users\\Application Data\\DanDing\\Log\\ImeLog-%d-%02d-%02d.txt"
#define LogFileWin7  "C:\\ProgramData\\DanDing\\Log\\ImeLog-%d-%02d-%02d.txt"


void WriteLog(char * sFormat)
{
#ifdef LOG

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

