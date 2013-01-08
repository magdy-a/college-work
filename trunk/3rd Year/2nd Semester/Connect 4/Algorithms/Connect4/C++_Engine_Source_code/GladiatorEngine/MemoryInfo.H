/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/

#ifndef MEMORYINFO_H_
#define MEMORYINFO_H_


class MemoryInfo
{
public:        
	MemoryInfo();
	~MemoryInfo();

	// operations
	void determineMemoryInfo();
	// attribute modification
	inline __int64 getTotalMemory() const;
	inline __int64 getAvailMemory() const;
	int calcNeededMemory() const;

private:       // attributes
	MEMORYSTATUSEX m_stMemStatus;
};

inline __int64 MemoryInfo::getTotalMemory() const 
{ return m_stMemStatus.ullTotalPhys; }
inline __int64 MemoryInfo::getAvailMemory() const 
{ return m_stMemStatus.ullAvailPhys; }

#endif