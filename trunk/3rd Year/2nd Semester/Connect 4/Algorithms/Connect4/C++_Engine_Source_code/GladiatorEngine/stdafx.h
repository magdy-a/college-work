// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//
#pragma once
// Modify the following defines if you have to target a platform prior to the ones specified below.
// Refer to MSDN for the latest info on corresponding values for different platforms.
#ifndef WINVER				// Allow use of features specific to Windows 95 and Windows NT 4 or later.
#define WINVER 0x0400		// Change this to the appropriate value to target Windows 98 and Windows 2000 or later.
#endif

#ifndef _WIN32_WINNT		// Allow use of features specific to Windows NT 4 or later.
#define _WIN32_WINNT 0x0400		// Change this to the appropriate value to target Windows 98 and Windows 2000 or later.
#endif						

#ifndef _WIN32_WINDOWS		// Allow use of features specific to Windows 98 or later.
#define _WIN32_WINDOWS 0x0410 // Change this to the appropriate value to target Windows Me or later.
#endif

#ifndef _WIN32_IE			// Allow use of features specific to IE 4.0 or later.
#define _WIN32_IE 0x0400	// Change this to the appropriate value to target IE 5.0 or later.
#endif

#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers
#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS	// some CString constructors will be explicit

#ifndef VC_EXTRALEAN
#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers
#endif

#ifndef _AFX_NO_OLE_SUPPORT
//#include <afxdtctl.h>		// MFC support for Internet Explorer 4 Common Controls
#endif
#ifndef _AFX_NO_AFXCMN_SUPPORT
//#include <afxcmn.h>			// MFC support for Windows Common Controls
#endif // _AFX_NO_AFXCMN_SUPPORT


// Windows Header Files:
#include <windows.h>
#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>

#include <assert.h>
#include <new>
#include "basics.h"


// program specific macros
typedef std::bad_alloc BAD_ALLOCATION;

//#define _PARALLEL_WINDOW_SEARCH

#if defined _DEBUG	
	#define ANALYZE_MEMORY_LEAKS
	#define _OPENMP_MULTICORE_LOG_THREADS
	#define _DEBUG_HASH
#else	
	#undef ANALYZE_MEMORY_LEAKS
	#undef _OPENMP_MULTICORE_LOG_THREADS
	#undef _DEBUG_HASH
#endif 
#define _OPENMP_MULTICORE

#if !defined ANALYZE_MEMORY_LEAKS
	void* operator new(size_t size);
	void* operator new[](size_t size);
	void operator delete[](void* p) throw();
	void operator delete(void* p) throw();
#endif

#if defined ANALYZE_MEMORY_LEAKS
	#ifdef _DEBUG
	   #define DEBUG_CLIENTBLOCK   new( _CLIENT_BLOCK, __FILE__, __LINE__)
	#else
	   #define DEBUG_CLIENTBLOCK
	#endif // _DEBUG

	#ifdef _DEBUG
		#define new DEBUG_CLIENTBLOCK
	#endif
#endif

#pragma intrinsic(memcpy)

#pragma warning( disable : 4251 )


