/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/


#ifndef _GAMEAGENT
#define _GAMEAGENT

#include <time.h>

class Gameboard;
class Position;
class CalculationModel;
class HashElement;
class TranspositionTable;
class ThreadData;

class StrategyGameAgent
{
private:
	Gameboard**         gameboard;
	Position*           initialPos;
	CalculationModel*   model;		
	TranspositionTable* hashtable;
	
	char				markedThread;
	Byte                basePos;
	Byte				hashDepthLeft;
	int                 visitedNodes;
	Byte                depth;
	Byte                finalDepth;
	Byte				numberMoves;	
	Byte				lastThread;
	int                 score;
	int                 finalScore;
	int                 hashScore;
	time_t              elapsedTime;
	time_t              startTime;
	int                 nodes;
	int                 hashCount;
	int                 nearestWin;
	int                 finalHash;
	int                 finalNodes;
	int 				listSize;	
	int					sizePosByte;
	Position*           currentPos;
	Position*			finalPos;
	bool				lookupHash;
	bool				foundBookMove;	
	bool				hashActivated;
	bool				timeout;
	bool				lockTimeout;
	int*				cursors;			
	Move**				scoreList;

	const static int MARGIN;
	const static int MAX_SELECTION_DEPTH;	
	
protected:	

	inline void setHashElementState();
	inline void sortMoves();
	inline void doMove(Position* pos, Byte player);
	inline void undoMove(Position* pos);
	ThreadData** threadData;
public:
	const static int DEFAULT_THREAD_ID;		
	StrategyGameAgent( Gameboard** board, CalculationModel* model, 
					   TranspositionTable* hashTable, ThreadData** threadData );
	~StrategyGameAgent();
	void doPreIterativeDeepening();
	void doPostIterativeDeepening();
	void attachCalculationModel( CalculationModel* model );	
	void initializeHashTable();
	void freeHashTable();
	void initializeLists(int listSize);
	void resetKillerAndPVMoves();
	void setMove( GameStatus* status );
#if defined _QSEARCH_DEBUG
	int alphabeta( Byte depth, Position* pos, int alpha, int beta, Byte size );
#elif defined _QSEARCH
	int alphabeta( Byte depth, int alpha, int beta, Byte size );
#else
	int alphabeta( Byte depth, int alpha, int beta, Byte currentThreadID );
#endif
	int alphabetaBase( Position* pos, int alpha, int beta );
	int alphabetaBaseWindowSearch( Position* pos, int alpha, int beta );
	void alphabetaAux(Position* pos, int alpha, int beta, Byte currentThreadID);
	int pvSplit( Byte currentDepth, int alpha, int beta );
	void checkTimeOut();
	inline int lookupTranspositionScore( int alpha, int beta, Byte currentThreadID );
	inline void addTranspositionScore( int score, Byte scoreRange, Byte currentThreadID );
	void resetDepth();
	void initThreads();
	void notifyClient();
	void resetAgent();
	void setSearchStatistics();
	void iterativeDeepening();	
	bool isHashActivated() { return hashActivated; }	
};


#endif