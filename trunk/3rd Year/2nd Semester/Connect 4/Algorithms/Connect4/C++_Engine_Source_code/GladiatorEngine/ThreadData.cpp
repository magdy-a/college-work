/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/

#include "stdafx.h"
#include "ThreadData.h"
#include "SystemConstants.h"
#include "Position.h"
#include "Move.h"
#include "GameStatus.h"
#include "StrategyGameAgent.h"

//////////////////////////////////////////////////////////////////////////////////////////

ThreadData::ThreadData(int maxDepthVal)
{	
	maxDepth = maxDepthVal;
	nodes = 0;	
	killerMoves = NULL;
	moveLists = NULL;       
	principalVar = NULL;
}

//////////////////////////////////////////////////////////////////////////////////////////

ThreadData::~ThreadData()
{	
	for ( int i = 0; i < maxDepth; i++ )
	{	
		delete[] moveLists[i];
		delete[] principalVar[i];			
	}

	delete[] moveLists;
	delete[] principalVar;
	delete[] killerMoves;	
}

//////////////////////////////////////////////////////////////////////////////////////////

void ThreadData::initializeLists(int listSize)
{		
	killerMoves    = new Byte[maxDepth];	
	moveLists      = new Position**[maxDepth];
	principalVar   = new Byte*[maxDepth]; 

	for ( int i = 0; i < maxDepth; i++ )
	{				
		moveLists[i]    = new Position*[listSize];
		moveLists[i][0] = &Position::maxPos;		
		principalVar[i] = new Byte[maxDepth]; 
	}	
}

//////////////////////////////////////////////////////////////////////////////////////////

void ThreadData::resetKillerAndPVMoves()
{
	for ( int i = 0; i < maxDepth; i++ )
	{          							
		killerMoves[i] = 0;
		
		for ( int j = 0; j < maxDepth; j++ )
		{
			principalVar[i][j] = 0;
		}
	}
}