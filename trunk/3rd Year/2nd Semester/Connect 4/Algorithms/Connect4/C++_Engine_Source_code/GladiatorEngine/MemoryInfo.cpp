/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/

#include "stdafx.h"
#include "MemoryInfo.h"


MemoryInfo::MemoryInfo()
{
	determineMemoryInfo();
}

MemoryInfo::~MemoryInfo()
{
	// nothing to do yet
}

void MemoryInfo::determineMemoryInfo()
{
	m_stMemStatus.dwLength = sizeof (m_stMemStatus);
	BOOL res = GlobalMemoryStatusEx(&m_stMemStatus);
}


