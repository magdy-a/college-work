/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/


// stdafx.cpp : source file that includes just the standard includes
// GladiatorEngine.pch will be the pre-compiled header
// stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

const BAD_ALLOCATION badAllocException;

#if !defined ANALYZE_MEMORY_LEAKS
void* operator new(size_t size) 
{
	void *p = malloc(size);
    if (p == NULL)
	{		
		throw badAllocException;
	}
    return p;
}

void* operator new[](size_t size) 
{
	void *p = malloc(size);
    if (p == NULL)
	{		
		throw badAllocException;
	}
    return p;
}

void operator delete[](void* p) throw()
{
	free(p);
}

void operator delete(void* p) throw()
{
	free(p);
}

#endif