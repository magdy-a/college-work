
#include "HashElement.h"

#ifndef _THREADDATA
#define _THREADDATA

class Position;

class ThreadData
{
public:
	int				alpha;
	int				beta;
	int				score;
	int				nodes;
	int				maxDepth;
	HashElement     searchHash;
	Byte*			killerMoves;
	Position***		moveLists;       
	Byte**			principalVar;

	ThreadData(int maxDepthVal);		
	~ThreadData();
	void resetKillerAndPVMoves();
	void initializeLists(int listSize);
};

#endif