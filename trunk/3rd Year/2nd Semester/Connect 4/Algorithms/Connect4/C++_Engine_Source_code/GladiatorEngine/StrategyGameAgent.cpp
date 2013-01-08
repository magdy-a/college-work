/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/


#include "stdafx.h"
#include "SystemConstants.h"
#include "Array.h"
#include "PtrArray.h"
#include <new>
#include "TranspositionTable.h"
#include "Gameboard.h"
#include "Threats.h"
#include "ConnectfourGameboard.h"
#include "CalculationModel.h"
#include "HashElement.h"
#include "ThreadData.h"
#include "StrategyGameAgent.h"
#include "GameStatus.h"
#include "Position.h"
#include "Move.h"
#include <jni.h>
#include "GladiatorEngine.h"
#include <new>
#include <stdio.h>
#include <omp.h>

const int StrategyGameAgent::MARGIN = 20;
const int StrategyGameAgent::MAX_SELECTION_DEPTH = 6;
static Byte threadID = MASTER_THREAD;
#pragma omp threadprivate(threadID)



//////////////////////////////////////////////////////////////////////////////////////////

StrategyGameAgent::StrategyGameAgent( Gameboard** board, CalculationModel* model, 
									 TranspositionTable* hashTable, ThreadData** threadData )
{
	this->model		 = model;
	this->gameboard  = board;
	this->hashtable  = hashTable;
	this->threadData = threadData;
	hashDepthLeft   = model->getHashDepthLeft();	
	visitedNodes    = 0;
	depth           = 0;
	finalDepth      = 0;
	score			= 0;
	finalScore		= 0;
	hashScore		= 0;
	elapsedTime		= 0;
	startTime		= 0;
	nodes			= 0;
	hashCount		= 0;
	nearestWin		= 0;
	finalHash		= 0;
	finalNodes		= 0;
	listSize		= 0;
	sizePosByte		= 0;
	numberMoves		= 0;		
	currentPos		= NULL;
	finalPos		= NULL;	
	scoreList		= NULL;	
	hashActivated	= false;
	timeout			= false;	
	lockTimeout		= false;
	lastThread		= GladiatorEngine::MAX_THREADS - 1;		
}

//////////////////////////////////////////////////////////////////////////////////////////

StrategyGameAgent::~StrategyGameAgent()
{			
	delete[] scoreList;
}

//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::initThreads()
{
	omp_set_num_threads(GladiatorEngine::MAX_THREADS);
	omp_set_dynamic(0);
	#pragma omp parallel default(shared)
	{
		threadID = GladiatorEngine::omp_get_thread_num();
		_RPTF1(_CRT_WARN, "ThreadNumber = %d\n", threadID);
	}
}

//////////////////////////////////////////////////////////////////////////////////////////


void StrategyGameAgent::doPreIterativeDeepening()
{
    timeout			= false;
	lockTimeout		= false;
	elapsedTime		= 0;
	hashCount		= 0;
    nodes			= 0;
    nearestWin		= 0;
	finalDepth      = 0;
	finalScore		= 0;
	finalHash		= 0;
	finalNodes		= 1;	
	finalPos		= NULL;
	gameboard[MASTER_THREAD]->getStatus()->hashSize = 0;
	basePos = gameboard[MASTER_THREAD]->getCount();	
	resetKillerAndPVMoves();
	initThreads();
	startTime = time( NULL );  	
}

//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::doPostIterativeDeepening()
{		
	if ( hashActivated )
	{
		float ratio = ( (float)( finalHash ) ) / ( finalHash + finalNodes );
		gameboard[MASTER_THREAD]->getStatus()->hashSize = (int)( 100 * ratio );
	    
		if ( ( ratio < 0.01 ) )
		{			
			hashtable->clear();			
		}		
	}	
}


//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::attachCalculationModel( CalculationModel* model )
{
    this->model = model;
	hashDepthLeft = model->getHashDepthLeft();
}

//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::initializeHashTable()
{	
	setHashElementState();
    try 
    {						
		hashtable->resize( model->getHashelements() );								
	}
	catch ( std::bad_alloc a )
    {															
		// we failed to allocate enough memory for hashtable
		hashActivated = false;	
		model->setHashelements( 0 );
		freeHashTable();					
	}	
}

//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::resetAgent()
{	
	visitedNodes    = 0;
	depth           = 0;
	finalDepth      = 0;
	score			= 0;
	finalScore		= 0;
	hashScore		= 0;
	elapsedTime		= 0;
	startTime		= 0;
	nodes			= 0;
	hashCount		= 0;
	nearestWin		= 0;
	finalHash		= 0;
	finalNodes		= 0;
	
	initializeHashTable();
}

//////////////////////////////////////////////////////////////////////////////////////////

inline void StrategyGameAgent::setHashElementState()
{
	int numElements = gameboard[MASTER_THREAD]->getStatus()->hashelements;
	
	if ( numElements == 0 )
	{
		hashActivated = false;
		model->setHashelements( 0 );
	}
	else
	{
		hashActivated = true;
		model->setHashelements( model->getOrigHashelements() );
	}
}

//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::freeHashTable()
{	
	if ( hashtable != NULL )
		hashtable->freeTable();		
}

//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::initializeLists(int listSize)
{	
	this->listSize = listSize;
    initializeHashTable();
    int maxDepth   = model->getMaxDepth();     
	scoreList	   = new Move*[listSize];
	sizePosByte	   = sizeof(Byte);		
	scoreList[0]   = &Move::maxScore;		
}
    
//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::resetKillerAndPVMoves()
{    	
	finalPos = &Position::defaultPos;

	for (int k = 0; k < GladiatorEngine::MAX_THREADS; k++)
	{
		threadData[k]->resetKillerAndPVMoves();	
		threadData[k]->nodes = 0;
	}
}

//////////////////////////////////////////////////////////////////////////////////////////


void StrategyGameAgent::setMove( GameStatus* status )
{                
    if ( status->pos == NULL )
        return;
    
    int idx = gameboard[MASTER_THREAD]->getLinearPosIndex( status->pos->xCoordinate, status->pos->yCoordinate );        		
    initialPos = gameboard[MASTER_THREAD]->getPosition( idx );

	for (int k = 0; k < GladiatorEngine::MAX_THREADS; k++)
	{
		gameboard[k]->setSide( status->player );	
	}
}

//////////////////////////////////////////////////////////////////////////////////////////

inline void StrategyGameAgent::doMove(Position* pos, Byte player)
{
	gameboard[MASTER_THREAD]->doMove( pos, player );
	for ( int i = 1; i < GladiatorEngine::MAX_THREADS; i++ )
	{
		gameboard[i]->doMove(gameboard[MASTER_THREAD], pos, player);
	}
}

//////////////////////////////////////////////////////////////////////////////////////////

inline void StrategyGameAgent::undoMove(Position* pos)
{
	gameboard[MASTER_THREAD]->undoMove( pos );
	for ( int i = 1; i < GladiatorEngine::MAX_THREADS; i++ )
	{
		gameboard[i]->undoMove(gameboard[MASTER_THREAD], pos);
	}
}


//////////////////////////////////////////////////////////////////////////////////////////

int StrategyGameAgent::pvSplit( Byte currentDepth, int alpha, int beta ) 
{	
	if ( currentDepth == depth )
	{		
		return gameboard[MASTER_THREAD]->getScore();
	}	

	int bestValue = -100000;
	char index;
	Position* cursor = NULL;	    	
	int score;
	bool foundPV = false;		
	Byte size;
	threadData[MASTER_THREAD]->nodes++;
	
	Byte player = 2 >> ( currentDepth & 1 );
	Position** moveList = threadData[MASTER_THREAD]->moveLists[currentDepth];
	size = gameboard[MASTER_THREAD]->sortMoveList( moveList, currentDepth );

	if ( !size )
	{
		return gameboard[MASTER_THREAD]->getScore();		
	}
	
	/////////////////////////////////// pv split search ////////////////////////////////////////
	cursor = moveList[1];  	
	doMove( cursor, player );                       					
	score = -pvSplit( currentDepth + 1, -beta, -alpha );               				
	undoMove( cursor );	

	if ( score > bestValue )
		bestValue = score;
	if ( score >= beta )
	{												
		threadData[MASTER_THREAD]->killerMoves[currentDepth] = cursor->linearPos;
		return bestValue;					
	}
	if ( score > alpha )
	{
		alpha = score;	
		foundPV = true;
		threadData[MASTER_THREAD]->principalVar[currentDepth][0] = cursor->linearPos;
		// update principal variation line
		Byte idx = currentDepth + 1;
		memcpy( threadData[MASTER_THREAD]->principalVar[currentDepth] + 1, threadData[MASTER_THREAD]->principalVar[idx], 
				(depth - idx) * sizePosByte );
	}
	
	char start = 1;
	///////////////////////////////////////normal alpha beta search ////////////////////////////
	#pragma omp parallel for schedule( dynamic, 1 ) firstprivate( cursor, score, currentDepth )
	for ( index = 2; index <= size; ++index )
	{	
		if ( timeout )
		{			
			continue;
		}
		               					    			
		#if defined _OPENMP_MULTICORE_LOG_THREADS
		if (currentDepth == 1)
			_RPTF1(_CRT_WARN, "MoveNumber = %d\n", start);	
		#endif
		#pragma omp critical
		{
			cursor = moveList[++start];
		}
		gameboard[threadID]->doMove( cursor, player );                       
			
		if ( foundPV == true )
		{
			score = -alphabeta( currentDepth + 1, -alpha - 1, -alpha, threadID );
			if ( score > alpha && score < beta )
			{
				score = -alphabeta( currentDepth + 1, -beta, -alpha, threadID );
			}
		}
		else
		{
			score = -alphabeta( currentDepth + 1, -beta, -alpha, threadID );               	
		}
		       
		gameboard[threadID]->undoMove( cursor );		
		
		#pragma omp critical
		{
			if (!timeout)
			{
				if (score > bestValue )
					bestValue = score;

				if ( score >= beta )
				{												
					threadData[threadID]->killerMoves[currentDepth] = cursor->linearPos;
					timeout = true;								
				}
				else if ( score > alpha )
				{
					alpha = score;									
					foundPV = true;
					threadData[MASTER_THREAD]->principalVar[currentDepth][0] = cursor->linearPos;
					// update principal variation line
					Byte idx = currentDepth + 1;
					memcpy( threadData[MASTER_THREAD]->principalVar[currentDepth] + 1, threadData[threadID]->principalVar[idx], 
							(depth - idx) * sizePosByte );
				}
			}
		} // end of critical section
	}
	timeout = false;
	checkTimeOut();
	return bestValue;
}




//////////////////////////////////////////////////////////////////////////////////////////

int StrategyGameAgent::alphabeta( Byte currentDepth, int alpha, int beta, Byte currentThreadID ) 
{	
	if ( currentDepth == depth )
	{		
		return gameboard[currentThreadID]->getScore();
	}				

	if ( hashActivated && 
	   ( depth - currentDepth ) > hashDepthLeft && 
	   ( score = lookupTranspositionScore( alpha, beta, currentThreadID ) ) != HashElement::UNKNOWN )
	{
		hashCount++;
		return score;
	}
	int bestValue = -100000;
	Byte scoreRange, index;
	Position* cursor = NULL;	    	
	int score;
	bool foundPV = false;
	Gameboard* gameboardRef = gameboard[currentThreadID];
	ThreadData* threadDataRef = threadData[currentThreadID]; 

#if defined _OPENMP_MULTICORE_LOG_THREADS
	threadDataRef->nodes++;
#endif
	nodes++;	
	Byte player = 2 >> ( currentDepth & 1 );
	Position** moveList = threadDataRef->moveLists[currentDepth];
	Byte size;
	size = gameboardRef->sortMoveList( moveList, currentDepth );

	if ( !size )
	{
		return gameboardRef->getScore();		
	}	

	scoreRange = HashElement::FAIL_LOW;
	
	for ( index = 1; index <= size; ++index )
	{            
		cursor = moveList[index];  		
		currentDepth++;
		gameboardRef->doMove( cursor, player );                       
			
		if ( foundPV == true )
		{
			score = -alphabeta( currentDepth, -alpha - 1, -alpha, currentThreadID );
			if ( score > alpha && score < beta )
			{
				score = -alphabeta( currentDepth, -beta, -alpha, currentThreadID );
			}
		}
		else
		{
			score = -alphabeta( currentDepth, -beta, -alpha, currentThreadID );               	
		}
		if ( timeout )
		{
			gameboardRef->undoMove( cursor );    			
			return -1;
		}  
		       
		gameboardRef->undoMove( cursor );
		currentDepth--;
		
		if (score > bestValue )
		{
			bestValue = score;			
		}

		if ( score >= beta )
		{						
			threadDataRef->killerMoves[currentDepth] = cursor->linearPos;
			scoreRange = HashElement::FAIL_HIGH;			
			break;
		}
		if ( score > alpha )
		{			
			alpha = score;			
			scoreRange = HashElement::EXACT_SCORE;
			foundPV = true;
			threadDataRef->principalVar[currentDepth][0] = cursor->linearPos;
			// update principal variation line
			Byte idx = currentDepth + 1;
			memcpy( threadDataRef->principalVar[currentDepth] + 1, threadDataRef->principalVar[idx], 
					(depth - idx) * sizePosByte );			
		}		
	}// end of for

	if ( hashActivated && ( depth - currentDepth ) > hashDepthLeft )
	{
		addTranspositionScore( bestValue, scoreRange, currentThreadID );
	}
	checkTimeOut();
	return bestValue;
}


int StrategyGameAgent::alphabetaBaseWindowSearch( Position* pos, int alpha, int beta ) 
{
	int bestValue = -100000;	
	Move* cursor = NULL;	    								
	char index = 1, j = 0;	
	nodes = 0;		
	int score = 0; 		
	int diff;	
	timeout = false;	
	sortMoves();
			
	for ( index = 1; index <= numberMoves; ++index )
	{            					
		markedThread = -1;
		diff = (beta - alpha) / GladiatorEngine::MAX_THREADS;
		cursor = scoreList[index];
		if ( diff < 2 )
		{
			alphabetaAux( cursor->pos, alpha, beta, MASTER_THREAD );
			markedThread = MASTER_THREAD;
		}				
		else
		{		  		
			#pragma omp parallel default(shared) firstprivate( j ) num_threads(GladiatorEngine::MAX_THREADS)
			{							
				#pragma omp for schedule( dynamic, 1 )
				for ( j = 0; j < GladiatorEngine::MAX_THREADS; j++ )
				{								
					#pragma omp critical
					{
						if (j)
						{
							// copy pv-line to remaining threads			
							memcpy( threadData[j]->principalVar[0], threadData[MASTER_THREAD]->principalVar[0], 
							(depth - 1) * sizePosByte );
						}
						threadData[j]->alpha = alpha + diff * j; 
						if ( j == lastThread )
						{
							// due to rounding errors in diff value
							threadData[j]->beta = beta;
						}
						else
						{
							threadData[j]->beta  = threadData[j]->alpha + diff + 1;  						
						}
					}
					_RPTF2( _CRT_WARN, "Move: %d | MoveIndex: %d\n", index, cursor->pos->linearPos );				
					alphabetaAux( cursor->pos, alpha, beta, j );  						
				} // end for loop
			}// end #pragma omp parallel
		} // end else
		if ( !lockTimeout )
		{
			timeout = false;
		}
		else
		{			
			lockTimeout = false;
			return -1;
		}		
		if ( markedThread == -1 )
		{
			// accounts for search instability
			alphabetaAux( cursor->pos, alpha, beta, MASTER_THREAD );
			markedThread = MASTER_THREAD;
		}
		cursor->score = threadData[markedThread]->score;
		score = cursor->score;
		// determine score from split searches		
		// update global values												
		if (score > bestValue )
			bestValue = score;

		if ( score >= beta )
		{									
			break;			
		}
		else if ( score > alpha )
		{			
			alpha = score;				
			currentPos = cursor->pos;
			threadData[MASTER_THREAD]->principalVar[0][0] = currentPos->linearPos;
			// update principal variation line
			memcpy( threadData[MASTER_THREAD]->principalVar[0] + 1, 
					threadData[markedThread]->principalVar[1], (depth - 1) * sizePosByte );			
		}
	
	}// end of for
	
	return bestValue;
}


//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::alphabetaAux(Position* pos, int alpha, int beta, Byte currentThreadID)
{		
	threadData[currentThreadID]->nodes = 0;
	gameboard[currentThreadID]->doMove( pos, SystemConstants::COMPUTER );
	threadData[currentThreadID]->score = -alphabeta( 1, -threadData[currentThreadID]->beta, -threadData[currentThreadID]->alpha, currentThreadID );
	gameboard[currentThreadID]->undoMove( pos );
	if ( !timeout )
	{			
		_RPTF4(_CRT_WARN, "Alpha = %d  | Beta = %d | Nodes = %d | Depth = %d\n", 
		threadData[currentThreadID]->alpha, threadData[currentThreadID]->beta, threadData[currentThreadID]->nodes, depth);

		if ( threadData[currentThreadID]->score <= alpha || threadData[currentThreadID]->score >= beta )
		{				
			//encountered global fail-low or fail-high 					
			markedThread = currentThreadID;
			timeout = true;
			_RPTF1(_CRT_WARN, "Global fail low or high score = %d\n", threadData[currentThreadID]->score);
		}
		else if ( threadData[currentThreadID]->alpha < threadData[currentThreadID]->score && threadData[currentThreadID]->score < threadData[currentThreadID]->beta )
		{
			//encountered exact value within local window	
			markedThread = currentThreadID;			
			timeout = true;
			_RPTF1(_CRT_WARN, "Inside window score = %d \n", threadData[currentThreadID]->score);
		}
		else
		{
			_RPTF1(_CRT_WARN, "local fail high low = %d \n", threadData[currentThreadID]->score);
		}
	}	
}

//////////////////////////////////////////////////////////////////////////////////////////


int StrategyGameAgent::alphabetaBase( Position* pos, int alpha, int beta ) 
{
	int bestValue = -100000;	
	Move* cursor = NULL;	    						
	Byte player = SystemConstants::COMPUTER;	
	char index = 1;	
	nodes = 0;		
	int score = 0;
	bool foundPV = false;
	bool breakLoop = false;
	
	sortMoves();
	////*************** normal alpha beta search *************************	
	for ( index = 1; index <= numberMoves; ++index )
	{            					
		cursor = scoreList[index];               					    			
		doMove( cursor->pos, player ); 
		
		if ( foundPV == true )
		{
			score = -pvSplit( 1, -alpha - 1, -alpha );
			if ( score > alpha && score < beta )
			{
				score = -pvSplit( 1, -beta, -alpha );
			}
		}
		else
		{
			score = -pvSplit( 1, -beta, -alpha );               	
		}
		
		if ( timeout )
		{
			undoMove( cursor->pos );    
			return -1;
		}  
		cursor->score = score;	
		undoMove( cursor->pos );	
		
		if ( score > bestValue )
			bestValue = score;

		if ( score >= beta )
		{												
			return bestValue;					
		}
		if ( score > alpha )
		{
			alpha = score;		
			foundPV = true;
			currentPos = cursor->pos;
			threadData[MASTER_THREAD]->principalVar[0][0] = currentPos->linearPos;
			// update principal variation line
			memcpy( threadData[MASTER_THREAD]->principalVar[0] + 1, 
					threadData[MASTER_THREAD]->principalVar[1], (depth - 1) * sizePosByte );			
		}

#if defined _OPENMP_MULTICORE_LOG_THREADS
	_RPTF4(_CRT_WARN, "MoveNumber = %d | Alpha = %d  | Beta = %d | Depth = %d\n", 
	index, alpha, beta, depth);	
	for (int k = 0; k < GladiatorEngine::MAX_THREADS; k++)
	{
		_RPTF2(_CRT_WARN, "Nodes = %d | ThreadId = %d\n", threadData[k]->nodes, k);
		threadData[k]->nodes = 0;
	}
#endif
	}// end of for
	return bestValue;
}

//////////////////////////////////////////////////////////////////////////////////////////

inline void StrategyGameAgent::sortMoves()
{
	Byte j, i;	
	Move* move;

	for ( i = 2; i <= numberMoves; i++ )
	{
		j = i; 
		move = scoreList[i];
		while ( scoreList[j - 1]->score < move->score )
		{
			scoreList[j] = scoreList[j - 1];
			j--;
		}
		scoreList[j] = move;
	}
}

//////////////////////////////////////////////////////////////////////////////////////////

inline void StrategyGameAgent::checkTimeOut() 
{
	if ( gameboard[MASTER_THREAD]->getStatus()->timeout <= ( time(NULL) - startTime) )
	{
		lockTimeout = true;
		timeout = true;
	}			
}

//////////////////////////////////////////////////////////////////////////////////////////

int StrategyGameAgent::lookupTranspositionScore( int alpha, int beta, Byte currentThreadID )
{
	threadData[currentThreadID]->searchHash.hashKey   = gameboard[currentThreadID]->getHashKey();
	threadData[currentThreadID]->searchHash.lockKey   = gameboard[currentThreadID]->getLockKey();

	HashElement* resultHash = hashtable->get( &threadData[currentThreadID]->searchHash );

	// variable basePos accounts for the starting position of the search and allows to determine
	// whether a hash entry has come from a deep enough search to be used in the current search.
	// Thus to use the hash, the expression (hashDepth + hashBase >= Depth + Base) must be true 
	if ( resultHash != NULL && ( resultHash->depth >= ( depth + basePos - resultHash->basePos ) ) )
	{
		#if defined _DEBUG_HASH
		if (basePos > resultHash->basePos)
		{
			_RPTF4(_CRT_WARN, "Lookup: Hash depth = %d | Hash basePos = %d  | Depth = %d | BasePos = %d\n", 
						resultHash->depth, resultHash->basePos, depth, basePos);	
		}
		#endif
		switch ( resultHash->scoreRange )
		{
			case HashElement::FAIL_LOW:
				if ( resultHash->score <= alpha )
				{
					return alpha;
				}
			break;
			case HashElement::FAIL_HIGH:
				if ( resultHash->score >= beta )
				{
					return beta;
				}
			break;
			case HashElement::EXACT_SCORE:
					return resultHash->score;
		}
	}

	return HashElement::UNKNOWN;
}

//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::addTranspositionScore( int score, Byte scoreRange, Byte currentThreadID )
{
	threadData[currentThreadID]->searchHash.hashKey   = gameboard[currentThreadID]->getHashKey();
	threadData[currentThreadID]->searchHash.lockKey   = gameboard[currentThreadID]->getLockKey();

	HashElement* currentElement = hashtable->get( &threadData[currentThreadID]->searchHash );

	if ( currentElement == NULL ) 
	{	                        
		// no entry yet
		#pragma omp critical
		{
			currentElement = hashtable->nextElement();
			// check whether map is full		
			if ( currentElement != NULL )
			{				
				currentElement->basePos		= basePos;
				currentElement->score       = score;
				currentElement->depth	    = depth;
				currentElement->scoreRange  = scoreRange;
				currentElement->hashKey     = gameboard[currentThreadID]->getHashKey();
				currentElement->lockKey     = gameboard[currentThreadID]->getLockKey();

				hashtable->put();		  		 
			}
		} // end of critical section
	}  
	else if ( currentElement->depth < ( depth + basePos - currentElement->basePos ) )
	{
		// entry does exist but with smaller distance		
		#if defined _DEBUG_HASH
		if (basePos > currentElement->basePos)
		{
			_RPTF4(_CRT_WARN, "Add: Hash depth = %d | Hash basePos = %d  | Depth = %d | BasePos = %d\n", 
						currentElement->depth, currentElement->basePos, depth, basePos);	
		}
		#endif		
		// update current element
		currentElement->basePos		= basePos;
		currentElement->score       = score;
		currentElement->depth	    = depth;
		currentElement->scoreRange  = scoreRange;
	}
}
	

//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::setSearchStatistics()
{
	elapsedTime = time(NULL) - startTime;	
	threadData[MASTER_THREAD]->principalVar[0][0] = finalPos->linearPos;
	gameboard[MASTER_THREAD]->getStatus()->hash	 = finalHash;
	gameboard[MASTER_THREAD]->getStatus()->nodes = finalNodes;
	gameboard[MASTER_THREAD]->getStatus()->score = finalScore;
	gameboard[MASTER_THREAD]->getStatus()->time	 = elapsedTime;
	gameboard[MASTER_THREAD]->getStatus()->depth = finalDepth;	
	gameboard[MASTER_THREAD]->getStatus()->pvLine = threadData[MASTER_THREAD]->principalVar[0];
	gameboard[MASTER_THREAD]->getStatus()->player = SystemConstants::COMPUTER;
}

//////////////////////////////////////////////////////////////////////////////////////////

void StrategyGameAgent::iterativeDeepening()
{
	doPreIterativeDeepening();	
	Position* winPos = NULL;	
	int initialWindow = model->getInitialWindow();
	int window        = model->getWindow();
	int maxDepth      = model->getMaxDepth();	
	int boardScore	  = gameboard[MASTER_THREAD]->getScore();
	int lastScore	  = 0;		
	int diff		  = 0;	
	bool failHigh	  = false;
	bool failLow	  = false;
	Byte limitDepth   = maxDepth - 2;
	Byte selDepth     = 0;

	int alpha   = boardScore - initialWindow;
	int beta    = boardScore + initialWindow;
	score       = SystemConstants::NEUTRAL;						
	
	if ( boardScore <= -SystemConstants::WIN )
	{
		// we lost
		maxDepth = 0;
		finalScore = boardScore;
	}	
	else if ((winPos = gameboard[MASTER_THREAD]->preSortMoves(scoreList, numberMoves)) != NULL)
	{		
		boardScore = gameboard[MASTER_THREAD]->getScore();
		if ( boardScore >= SystemConstants::WIN )
		{
			// we won			
			finalScore = boardScore;			
		}
		maxDepth = 0;
		finalPos = winPos;
	}
	else if ( gameboard[MASTER_THREAD]->noFreePosition() )
	{
		maxDepth = 0;
		finalScore = SystemConstants::NEUTRAL;
	}
	
	// iterative deepening scaffolding
	_RPTF0(_CRT_WARN, "---------------------------- New iterative deepening ---------------------------\n\n");
	for ( depth = 1; depth < maxDepth; )
	{	              														
		score = alphabetaBase( initialPos, alpha, beta );
		if ( timeout )
		{
			break;
		}		
		
		diff = score - lastScore;
		if (diff < 0)
		{
			diff = -diff;
		}
		diff += MARGIN;

		if ( score <= alpha ) // if fail-low
		{                   						
			failLow = true;
			if ( !failHigh )
			{
				beta = score + 1;
			}
			alpha = score - 3 * diff; 								
			_RPTF5(_CRT_WARN, "FAIL LOW:      | alpha = %d | beta = %d | score = %d | depth = %d | diff = %d\n", 
					alpha, beta, score, depth, diff);
			continue;
		}
		else if ( score >= beta ) // if fail-high
		{									
			failHigh = true;
			if ( !failLow )
			{
				alpha = score - 1;
			}			
			beta = score + 3 * diff; 				
			_RPTF5(_CRT_WARN, "FAIL HIGH:     | alpha = %d | beta = %d | score = %d | depth = %d | diff = %d\n", 
					alpha, beta, score, depth, diff);
			continue;
		}		
		else // within window
		{			
			beta = score + 2 * diff;
			alpha = score - 2 * diff;
			_RPTF5(_CRT_WARN, "WITHIN WINDOW: | alpha = %d | beta = %d | score = %d | depth = %d | diff = %d\n", 
					alpha, beta, score, depth, diff);
		}
			
		lastScore = score;
		// if within window
		// update values
		finalPos   = currentPos;
		finalNodes = nodes;
		finalHash  = hashCount;
		finalScore = score;
		finalDepth = depth;	
		failHigh   = false;
		failLow    = false;

		// increment by one
		depth++;							
	} // end for loop
	setSearchStatistics();
	doPostIterativeDeepening();
}
