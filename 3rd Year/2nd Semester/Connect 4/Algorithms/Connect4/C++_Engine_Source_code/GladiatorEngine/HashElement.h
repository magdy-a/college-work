/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001
*    Application: Four wins
***************************************************/

#ifndef _HASHELEMENT
#define _HASHELEMENT

#include "Basics.h"

class HashElement  // acts as key and value at the same time
{
public:

	enum
	{
		FAIL_LOW    = 0,
		EXACT_SCORE = 1,
		FAIL_HIGH   = 2,
		UNKNOWN     = 20000
	};
	
	Byte			depth;
	Byte			basePos;
	unsigned int	hashKey;
	unsigned int	lockKey;
	short			score;
	Byte			scoreRange;

	HashElement()
	{
		score = 0;
		lockKey = 0;
		hashKey = 0;
		depth = 0;
		scoreRange = 0;
		basePos = 0;
	}

	unsigned int hashCode()
	{		
		return hashKey;
	}

	bool operator ==( const HashElement& elem )
	{
		return lockKey == elem.lockKey;
	}
};

#endif