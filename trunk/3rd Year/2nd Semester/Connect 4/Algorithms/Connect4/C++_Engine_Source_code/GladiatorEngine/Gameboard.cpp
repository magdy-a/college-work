/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/


#include "stdafx.h"
#include "Gameboard.h"
#include "GameStatus.h"
#include "Move.h"
#include "ThreadData.h"
#include <math.h>
#include <stdio.h>
#include <crtdbg.h>

const int  Gameboard::UNKNOWN = -1;
const int  Gameboard::BORDER  = 3;
const unsigned __int64 Gameboard::BEST_HISTORY_SCORE = 0xFFFFFFFFFFFFFFFF;

const unsigned int Gameboard::randomStartValues[] = {1666732013, 461707969};

//////////////////////////////////////////////////////////////////////////////////////////
const unsigned int Gameboard::randomKeys[][7][6]=
// 32-bit-random numbers for fields
{
	{
		{830986829,345812841,1429358928,203655916,1868455899,1627410223},
		{875888394,806509854,1716587656,764094853,133834541,775783443},
		{1547932685,1704952218,1032862554,566218206,6132897,142106730},
		{914251682,1991319465,1450373442,14790819,1423500240,614669710},
		{212962234,1559403649,510140410,540567873,641557754,1389734010},
		{1101928822,1634348470,1407057412,2102189011,1738037813,1229983220},
		{257804331,1816020975,642440392,652508885,1145130119,1321096344}
	},{
		{2272057000,1973222515,1122964650,2232774925,2000462975,975180673},
		{1010335389,2326874957,3755410742,2879093158,3079664910,823386195},
		{1947947858,2247532017,1991780058,3482286068,3094446270,2316982948},
		{2048325253,3335244496,2224207828,2554045279,1504324673,2397124593},
		{1014370397,3551634835,1773182387,2259197977,3231158006,271164678},
		{3825628612,2565410569,1458612008,1383045755,2809536420,1877260260},
		{637453741,2241198506,1907632702,3472514104,3347294939,2550682030}
	}
};
//////////////////////////////////////////////////////////////////////////////////////////

const unsigned int Gameboard::lockKeys[][7][6]=   
{
	{
		{133732394,1873355990,1208538677,1481639693,698850632,1873262188},
		{1203963427,1192865459,993622918,1611204002,1345415729,1833491193},
		{1596551396,1764575352,1997344863,313709024,616160098,2144883950},
		{780215981,635926886,391264512,705143045,1968765723,1696028555},
		{587016126,1835549370,1464728489,395940434,1275487644,1567420432},
		{192263767,1578233783,1471729818,1594097414,516938021,1060558270},
		{607938232,1475175836,955527699,926370404,227821046,531675603}
	},{
		{685813537,801174442,1572645972,674443689,132603471,1722161039},
		{1709766610,1944953630,1622961565,1763941397,2128717424,264406069},
		{1755589387,1774651195,1317164590,1718872810,2025915545,1458863873},
		{1347929356,1673104704,360810567,940362088,1063112970,2096546102},
		{1915642901,1999850605,517830696,1435532492,2123916803,1572081171},
		{1080744038,1424184834,753302545,688501850,1157836740,601457369},
		{1032041535,1048806720,927652930,673241423,2133671053,596338374}
	}
};

//////////////////////////////////////////////////////////////////////////////////////////
/*	The board representation:

	 7!15 23 31 39 47 55 63!71
   ---+--------------------+---
	 6!14 22 30 38 46 54 62!70
	 5!13 21 29 37 45 53 61!69
	 4!12 20 28 36 44 52 60!68
	 3!11 19 27 35 43 51 59!67
	 2!10 18 26 34 42 50 58!66
	 1! 9 17 25 33 41 49 57!65
   ---+--------------------+---
	 0! 8 16 24 32 40 48 56!64
*/

//const int Gameboard::direction[] = { -8, -9, 7, -1 };
// outer -
// inner +
const int Gameboard::START_EVALUATION[][72] = {
	{	
		//rows		1		2		3		4		5		6		
		// - left to right
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER,
		BORDER,		33,	   34,		35,	   36,		37,	   38,	BORDER,
		BORDER,		33,	   34,		35,	   36,		37,	   38,	BORDER,
		BORDER,		33,	   34,		35,	   36,		37,	   38,	BORDER,
		BORDER,		33,	   34,		35,	   36,		37,	   38,	BORDER,
		BORDER,		41,	   42,		43,	   44,		45,	   46,	BORDER,
		BORDER,		49,	   50,		51,	   52,		53,	   54,	BORDER,
		BORDER,		57,	   58,		59,	   60,		61,	   62,	BORDER,
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER
	},
	{	// / bottom to top
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER,
		BORDER,		36,		37,	   38,		-1,		-1,		-1,	BORDER,
		BORDER,		44,		36,	   37,		38,		-1,		-1,	BORDER,
		BORDER,		52,		44,	   36,		37,		38,		-1,	BORDER,
		BORDER,		60,		52,	   44,		36,		37,		38,	BORDER,
		BORDER,		-1,		60,	   52,		44,		45,		46,	BORDER,
		BORDER,		-1,		-1,	   60,		52,		53,		54,	BORDER,
		BORDER,		-1,		-1,	   -1,		60,		61,		62,	BORDER,
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER
	},
	{	// \ bottom to top
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER,
		BORDER,		-1,		-1,	   -1,		12,		13,		14,	BORDER,
		BORDER,		-1,		-1,	   12,		20,		21,		22,	BORDER,
		BORDER,		-1,		12,	   20,		28,		29,		30,	BORDER,
		BORDER,		12,		20,	   28,		36,		37,		38,	BORDER,
		BORDER,		20,		28,	   36,		37,		38,		-1,	BORDER,
		BORDER,		28,		36,	   37,		38,		-1,		-1,	BORDER,
		BORDER,		36,		37,	   38,		-1,		-1,		-1,	BORDER,
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER
	}
};


const int Gameboard::NUMBER_EVALUATIONS[][72] = {
	{	
		//rows		1		2		3		4		5		6		
		// - left to right
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER,
		BORDER,		1,	   1,		1,	   1,		1,	   1,	BORDER,
		BORDER,		2,	   2,		2,	   2,		2,	   2,	BORDER,
		BORDER,		3,	   3,		3,	   3,		3,	   3,	BORDER,
		BORDER,		4,	   4,		4,	   4,		4,	   4,	BORDER,
		BORDER,		3,	   3,		3,	   3,		3,	   3,	BORDER,
		BORDER,		2,	   2,		2,	   2,		2,	   2,	BORDER,
		BORDER,		1,	   1,		1,	   1,		1,	   1,	BORDER,
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER
	},
	{	// / bottom to top
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER,
		BORDER,		1,		1,	   1,		0,		0,		0,	BORDER,
		BORDER,		1,		2,	   2,		1,		0,		0,	BORDER,
		BORDER,		1,		2,	   3,		2,		1,		0,	BORDER,
		BORDER,		1,		2,	   3,		3,		2,		1,	BORDER,
		BORDER,		0,		1,	   2,		3,		2,		1,	BORDER,
		BORDER,		0,		0,	   1,		2,		2,		1,	BORDER,
		BORDER,		0,		0,	   0,		1,		1,		1,	BORDER,
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER
	},
	{	// \ bottom to top
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER,
		BORDER,		0,		0,	   0,		1,		1,		1,	BORDER,
		BORDER,		0,		0,	   1,		2,		2,		1,	BORDER,
		BORDER,		0,		1,	   2,		3,		2,		1,	BORDER,
		BORDER,		1,		2,	   3,		3,		2,		1,	BORDER,
		BORDER,		1,		2,	   3,		2,		1,		0,	BORDER,
		BORDER,		1,		2,	   2,		1,		0,		0,	BORDER,
		BORDER,		1,		1,	   1,		0,		0,		0,	BORDER,
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER
	}
};


const __int64 Gameboard::BITBOARD[72] = 
{	
	//rows		1			2				3				4				  5					   6			
	0,         0,           0,             0,              0,                 0,                   0,   0,
	0,		 0x1,		 0x80,		  0x4000,	    0x200000,		 0x10000000,	     0x800000000,	0,
	0,		 0x2,	    0x100,		  0x8000,	    0x400000,		 0x20000000,	    0x1000000000,	0,
	0,		 0x4,	    0x200,		 0x10000,       0x800000,		 0x40000000,	    0x2000000000,	0,
	0,		 0x8,	    0x400,		 0x20000,	   0x1000000,	     0x80000000,	    0x4000000000,	0,
	0,		0x10,	    0x800,		 0x40000,	   0x2000000,		0x100000000,	    0x8000000000,	0,
	0,		0x20,	   0x1000,		 0x80000,	   0x4000000,		0x200000000,	   0x10000000000,	0,
	0,		0x40,	   0x2000,		0x100000,	   0x8000000,		0x400000000,	   0x20000000000,	0,
	0,		   0,			0,			   0,			   0,                 0,                   0,   0

};

//////////////////////////////////////////////////////////////////////////////////////////


const int Gameboard::STATIC_MOVE_EVALUATION[7][6] = 
{
	// lower half is prefered with number + 1
	{  2,   4,   6,   5,   3,  1 },
	{  4,   8,  13,  11,   7,  3 },
	{  6,  12,  17,  16,  11,  5 },
	{ 10,  15,  19,  18,  14,  9 },
	{  6,  12,  17,  16,  11,  5 },
	{  4,   8,  13,  11,   7,  3 },
	{  2,   4,   6,   5,   3,  1 }
};
 
//////////////////////////////////////////////////////////////////////////////////////////
// first subscript
// 0 = second player
// 1 = first player
const int Gameboard::WEIGHTSPLAYER[][72] = {
	{	
		//rows		1		2		3		4		5		6		
		// considers even threats
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER,
		BORDER,		50,	   500,		40,	   300,		30,	   100,	BORDER,
		BORDER,		50,	   500,		40,	   300,		30,	   100,	BORDER,
		BORDER,		50,	   500,		40,	   300,		30,	   100,	BORDER,
		BORDER,		50,	   500,		40,	   300,		30,	   100,	BORDER,
		BORDER,		50,	   500,		40,	   300,		30,	   100,	BORDER,
		BORDER,		50,	   500,		40,	   300,		30,	   100,	BORDER,
		BORDER,		50,	   500,		40,	   300,		30,	   100,	BORDER,
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER
	},
	{	// considers odd threats
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER,
		BORDER,		50,		40,	   550,		30,    350,		20,	BORDER,
		BORDER,		50,		40,	   550,		30,	   350,		20,	BORDER,
		BORDER,		50,		40,	   550,		30,	   350,		20,	BORDER,
		BORDER,		50,		40,	   550,		30,	   350,		20,	BORDER,
		BORDER,		50,		40,	   550,		30,	   350,		20,	BORDER,
		BORDER,		50,		40,	   550,		30,	   350,		20,	BORDER,
		BORDER,		50,		40,	   550,		30,	   350,		20,	BORDER,
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER
	}

};


const int Gameboard::WEIGHTSPLAYER_MINOR[][72] = {
	{	
		//rows		1		2		3		4		5		6		
		// considers even threats
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER,
		BORDER,		2,	   10,		3,	    6,		2,	    4,	BORDER,
		BORDER,		2,	   10,		3,	    6,		2,	    4,	BORDER,
		BORDER,		2,	   10,		3,	    6,		2,	    4,	BORDER,
		BORDER,		2,	   10,		3,	    6,		2,	    4,	BORDER,
		BORDER,		2,	   10,		3,	    6,		2,	    4,	BORDER,
		BORDER,		2,	   10,		3,	    6,		2,	    4,	BORDER,
		BORDER,		2,	   10,		3,	    6,		2,	    4,	BORDER,
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER
	},
	{	// considers odd threats
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER,
		BORDER,		2,		3,	   12,		2,      7,		1,	BORDER,
		BORDER,		2,		3,	   12,		2,	    7,		1,	BORDER,
		BORDER,		2,		3,	   12,		2,	    7,		1,	BORDER,
		BORDER,		2,		3,	   12,		2,	    7,		1,	BORDER,
		BORDER,		2,		3,	   12,		2,	    7,		1,	BORDER,
		BORDER,		2,		3,	   12,		2,	    7,		1,	BORDER,
		BORDER,		2,		3,	   12,		2,	    7,		1,	BORDER,
		BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER, BORDER
	}

};

//////////////////////////////////////////////////////////////////////////////////////////
const int* Gameboard::WEIGHTS = WEIGHTSPLAYER[0];

const int Gameboard::VALUES[] = { 0, 
										SystemConstants::ONE, 
										SystemConstants::TWO, 
										SystemConstants::THREE };

const int Gameboard::SIDEVALUES[] = { SystemConstants::MAJOR_THREE - 100,
										   SystemConstants::MAJOR_THREE };

const int Gameboard::MINORSIDEVALUES[] = { SystemConstants::THREE - 10,
												SystemConstants::THREE };


const int Gameboard::direction[] = { -8, -9, 7, -1 };
const int Gameboard::order[] = { 3, 2, 4, 1, 5, 6, 0 };


//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::setSide( int player )
{
	if ( player == status->firstPlayer )			
	{				
		side = 0; // use negated values		
	}	
	else
	{			
		side = 1;	
	}
}

//////////////////////////////////////////////////////////////////////////////////////////

Gameboard::~Gameboard()
{
	for ( int i = 0; i < numberMoves; i++ )
	{
		delete moves[i];
	}

	delete[] moves;
	delete[] scoreStack;
	delete[] moveStack;
	delete[] refutedThreat;
	delete[] winningRow;
	delete[] columns;
}

//////////////////////////////////////////////////////////////////////////////////////////

Gameboard::Gameboard(ThreadData* data) : columns(NULL)
{	
	lockKey = randomStartValues[0]; // unique address of position
	revKey  = randomStartValues[1]; // helper hash keys
	hashKey = randomStartValues[1]; // ditto	
	threadData = data;
	masterPVL  = NULL;	
	winningRow = new Position*[4];

	init = false;
	value = 0;
	sizeX = 0;
	sizeY = 0;
	side = 0;
	number = 0;
	value = 0;
	moves = NULL;
	scoreStack = NULL;
	moveStack = NULL;
	status = NULL;	
	currentPvPos = NULL;
	currentKillerPos = NULL;
}

//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::doInitializeGameboard()
{		    
    for ( int i = 0; i < status->sizeXOfBoard; i++ )
        columns[i] = (i + 1) * ( status->sizeYOfBoard + 2 ) + 1;

	for ( Byte i = 0; i < THREATSTACKSIZE; i++ )
	{
		threatStack[0][i] = 0;
		threatStack[1][i] = 0;
	}	
	for ( Byte j = 0; j < BOARDSIZE; j++ )
	{
		historyTable[0][j] = 0;
		historyTable[1][j] = 0;
		if (moves[j]->pos)
		{
			historyTable[0][j] = moves[j]->pos->staticEval;
			historyTable[1][j] = moves[j]->pos->staticEval;
		}
	}	
	// set default max value	
	boardscore = 0;
	count = 0;
	side  = 0;
	currentPvPos = NULL;
	currentKillerPos = NULL;
}

//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::addToHistory(Byte idx, Byte subDepth)
{		
	historyTable[side][idx] += 1i64 << subDepth;	
}

//////////////////////////////////////////////////////////////////////////////////////////

int Gameboard::getStaticEvaluation( int x, int y )
{
	return STATIC_MOVE_EVALUATION[x][y];
}

//////////////////////////////////////////////////////////////////////////////////////////

GameStatus* Gameboard::getStatus()
{
	return status;
}

//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::setStatus( GameStatus* status )
{
	this->status = status;
}

//////////////////////////////////////////////////////////////////////////////////////////

int Gameboard::getScore()
{
	return boardscore;
}

//////////////////////////////////////////////////////////////////////////////////////////
void Gameboard::setTimeOut( int timeout )
{
	if ( status != NULL )
	{
		status->timeout = timeout;
	}
}

//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::updateStatus( GameStatus* status )
{
	this->status->timeout = status->timeout;
	this->status->winner = status->winner;
}

//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::resetHashKeys()
{
	//hashKey = 0;
	//lockKey = 0;
}

//////////////////////////////////////////////////////////////////////////////////////////

bool Gameboard::noFreePosition()
{
	return count == maxCount;
}

//////////////////////////////////////////////////////////////////////////////////////////

int Gameboard::getLinearPosIndex( int x, int y )
{
	int idx = (( x + 1 ) * ( status->sizeYOfBoard + 2 )) + y + 1;
	return idx;
}

//////////////////////////////////////////////////////////////////////////////////////////
/*in order to initialize the board call these functions:
1. constructor
2. initializeBoard()
3. doMove() for all saved moves */

void Gameboard::initializeBoard( GameStatus* status )
{
	init = true;	
	this->status = status;	
	
	sizeX			= status->sizeXOfBoard;
	sizeY			= status->sizeYOfBoard;
	maxCount		= sizeX * sizeY;     
	numberMoves		= ( sizeX * sizeY ) + 2 * sizeX + 2 * sizeY + 4;
	moves			= new Move*[numberMoves];
	scoreStack		= new int[maxCount];
	moveStack		= new Byte[maxCount + 1];
	refutedThreat	= new bool[maxCount + 1];
	
	moveStack[0]	= 0;
	refutedThreat[0] = false;

	for ( int i = 0; i < numberMoves; i++ )
	{
		moves[i] = new Move( &Position::defaultPos, Gameboard::BORDER );
	}				

	for ( int x = 1; x <= sizeX; x++ )
	{
		int cursorX = x * ( sizeY + 2 ) + 1;

		for ( int y = 0; y < sizeY; y++ )
		{
			int staticEval = getStaticEvaluation( x - 1, y );
			moves[cursorX + y]->setPosition( new Position( x - 1, y, cursorX + y, staticEval ) );	                  	
			moves[cursorX + y]->setPlayer( SystemConstants::DEFAULT );
		}
	}
	sizeX--;
	sizeY--;
	
	columns = new int[ status->sizeXOfBoard ];
	doInitializeGameboard();
}

//////////////////////////////////////////////////////////////////////////////////////////
// if board is already created use this function
void Gameboard::resetBoard()
{	
	doInitializeGameboard();

	for ( int x = 1; x <= status->sizeXOfBoard; x++ )
	{
		int cursorX = x * ( status->sizeYOfBoard + 2 ) + 1;

		for ( int y = 0; y < status->sizeYOfBoard; y++ )
		{
			moves[cursorX + y]->setPlayer( SystemConstants::DEFAULT );
		}
	}

	lockKey = randomStartValues[0]; // unique address of position
	revKey  = randomStartValues[1]; // helper hash keys
	hashKey = randomStartValues[1]; // ditto				
}

//////////////////////////////////////////////////////////////////////////////////////////

Position* Gameboard::preSortMoves(Move** moveList, Byte& size)
{
	Byte i;	
	size = 0;	
	Move* move;
	Byte counterThreats = 0;
	Position* pos = NULL, *acuteThreatPos = NULL;

	for ( i = 0; i < status->sizeXOfBoard; ++i )
	{
		move = moves[columns[order[i]]];              
		if ( move->player != SystemConstants::DEFAULT )
		{
			continue;
		}
		if ( threatStack[side^1][count] & BITBOARD[move->pos->linearPos] )
		{
			// win
			boardscore = SystemConstants::WIN + (SystemConstants::THREE - count);					
			return move->pos;
		}
		if ( threatStack[side][count] & BITBOARD[move->pos->linearPos] )
		{
			// acute threat								
			acuteThreatPos = move->pos;
		}
		if ( threatStack[side][count] & BITBOARD[move->pos->linearPos + 1] )
		{
			// counter threat	
			counterThreats++;
			pos = move->pos;
			continue;
		}
		move->score = move->pos->staticEval;
		moveList[++size] = move;
	}

	if ( acuteThreatPos )
	{
		return acuteThreatPos;
	}
	else if (counterThreats && !size)
	{							
		// we have lost		
		return pos;
	}
	return NULL;
}

//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::resetHistoryValues()
{
	unsigned __int64 maxValue[2];
	unsigned __int64 divisor[2];

	maxValue[0] = 0;	
	maxValue[1] = 0;	

	historyTable[0][0] = 0;
	historyTable[1][0] = 0;
	// determine max value	
	for ( int i = 0; i < 2; i++ )
	{
		for ( int j = 0; j < BOARDSIZE; j++ )
		{			
			if ( historyTable[i][j] > maxValue[i] )
			{
				maxValue[i] = historyTable[i][j];
			}
		}
	}

	divisor[0] = maxValue[0] >> 10; 
	divisor[1] = maxValue[1] >> 10; 
	
	if ( divisor[0] <= 1 )
	{
		divisor[0] = 1;
	}
	if ( divisor[1] <= 1 )
	{
		divisor[1] = 1;
	}

	// reduce values to a certain level	
	for ( Byte j = 0; j < BOARDSIZE; j++ )
	{
		historyTable[0][j] /= divisor[0];	
		historyTable[1][j] /= divisor[1];	
		if (moves[j]->pos)
		{
			historyTable[0][j] += moves[j]->pos->staticEval;
			historyTable[1][j] += moves[j]->pos->staticEval;
		}
	}	
	// set default max value
	historyTable[0][0] = BEST_HISTORY_SCORE;
	historyTable[1][0] = BEST_HISTORY_SCORE;
}


//////////////////////////////////////////////////////////////////////////////////////////

Byte Gameboard::sortMoveList( Position** moveList, Byte currentDepth )
{                              
	if ( count == maxCount )
	{
		// there is no move left
		return 0;
	}	
	
	Byte size = 0;    
	Byte counterThreats = 0;			
	Move* move;	
	Position* pos;
	killerMoveIdx = threadData->killerMoves[currentDepth]; 
	pvMoveIdx = masterPVL[currentDepth];
	currentPvPos = moves[pvMoveIdx]->pos;
	currentKillerPos = moves[killerMoveIdx]->pos;
	Byte origKillerScore = currentKillerPos->staticEval; 		
	Byte origPVMoveScore = currentPvPos->staticEval;
	
	currentKillerPos->staticEval = SystemConstants::MAX_STATIC_KILLER_EVAL; // best move
	currentPvPos->staticEval = SystemConstants::MAX_STATIC_PV_EVAL; 
	
	Byte i;	    	
	// sort positions according to score
	
	for ( i = 0; i < status->sizeXOfBoard; ++i )
	{
		move = moves[columns[order[i]]];    		
		if ( move->player != SystemConstants::DEFAULT )
		{			
			// no free position
			continue;
		}		
		if ( threatStack[side^1][count] & BITBOARD[move->pos->linearPos] )
		{
			// win
			boardscore = SystemConstants::WIN + (SystemConstants::THREE - count);	
			size = 0;
			counterThreats = 0;
			break;
		}
		if ( threatStack[side][count] & BITBOARD[move->pos->linearPos + 1] )
		{
			// counter threat	
			counterThreats++;			
			continue;
		}

		moveList[++size] = move->pos;		 	

		if ( size == 1 )
		{
			continue;
		}
		pos = move->pos;
		Byte j = size;		
		// sort moves
		while ( moveList[j - 1]->staticEval < pos->staticEval )
		{
			moveList[j] = moveList[j - 1];
			j--;
		}
		//_ASSERT(pos != &Position::maxPos);
		moveList[j] = pos;			
	} // end for
	
	// reset scores	
	currentKillerPos->staticEval = origKillerScore; // best move	
	currentPvPos->staticEval = origPVMoveScore;
	
	if (!size && counterThreats)
	{
		// we have lost
		boardscore = -SystemConstants::WIN - (SystemConstants::THREE - count);				
	}
	
	return size;
	
}

//////////////////////////////////////////////////////////////////////////////////////////

Byte Gameboard::sortMoveListHistory( Position** moveList, Position* killerPos )
{                              
    Move* move;	
	Position* pos;
	origHistoryScore = historyTable[side][killerPos->linearPos]; 	
	historyTable[side][killerPos->linearPos] = BEST_HISTORY_SCORE; // best move	

	Byte i;	
    Byte size = 0;
	Byte counterThreats = 0;
	// sort positions according to the score
	for ( i = 0; i < status->sizeXOfBoard; ++i )
	{
		move = moves[columns[order[i]]];    		
		if ( move->player != SystemConstants::DEFAULT )
		{			
			// no free position
			continue;
		}		
		if ( threatStack[side^1][count] & BITBOARD[move->pos->linearPos] )
		{
			// win
			boardscore = SystemConstants::WIN + (SystemConstants::THREE - count);	
			size = 0;
			counterThreats = 0;
			break;
		}
		if ( threatStack[side][count] & BITBOARD[move->pos->linearPos + 1] )
		{
			// counter threat	
			counterThreats++;			
			continue;
		}

		moveList[++size] = move->pos;		 	

		if ( size == 1 )
		{
			continue;
		}
		pos = move->pos;
		Byte j = size;		
		// sort moves
		while ( historyTable[side][moveList[j - 1]->linearPos] < historyTable[side][pos->linearPos] )
		{
			moveList[j] = moveList[j - 1];
			j--;
		}
		//_ASSERT(pos != &Position::maxPos);
		moveList[j] = pos;			
	} // end for

	// reset scores		
	historyTable[side][killerPos->linearPos] = origHistoryScore; 

	if (!size && counterThreats)
	{
		// we have lost
		boardscore = -SystemConstants::WIN - (SystemConstants::THREE - count);				
	}	
	return size;
}


//////////////////////////////////////////////////////////////////////////////////////////

Position* Gameboard::getPos( int index )
{
    Move* move = moves[columns[order[index]]];
    if ( move->player == SystemConstants::DEFAULT )
    {
    	return move->pos;
    }
    return NULL;
}

//////////////////////////////////////////////////////////////////////////////////////////

Position* Gameboard::checkPos( Position* pos )
{
    if ( pos != NULL && pos->linearPos == columns[pos->xCoordinate] && 
    		moves[pos->linearPos]->player == SystemConstants::DEFAULT )
    {
    	return pos;
    }
    return NULL;
}

//////////////////////////////////////////////////////////////////////////////////////////

Position** Gameboard::checkFinalWin( Position* pos, Byte& length )
{
	int cursor, count, player = moves[pos->linearPos]->player;
	winningRow[0] = pos;
	length = 4;

	for ( int i = 0; i < 4; ++i )
	{
		count = 0;
		cursor = pos->linearPos;
		cursor -= direction[i];
		while ( moves[cursor]->player == player && count < 3 )
		{			   
			winningRow[++count] = moves[cursor]->pos;
			cursor -= direction[i];
		}
		cursor = pos->linearPos;
		cursor += direction[i];
		while ( moves[cursor]->player == player && count < 3 )
		{
			winningRow[++count] = moves[cursor]->pos;
			cursor += direction[i];
		}
		  	
		if ( count == 3 )
			return winningRow;
	}
		
	return NULL;
}

//////////////////////////////////////////////////////////////////////////////////////////

const Position* Gameboard::lookupBookMove( const wchar_t* path )
{
	int column = -1;
	int depth = count + 1;
	FILE* file = NULL;
	
	int res = _wfopen_s(&file, path, L"rb+" );	
	if( res != 0 )
	{
		return false;
	}
	
	fpos_t position = NULL;
	fpos_t posEnd = NULL;
	fseek(file, 0, SEEK_END);
	fgetpos(file, &posEnd);
	fseek(file, 0, SEEK_SET);
	fgetpos(file, &position);

	__int32 hash;
	Byte mark = 0;

	while (position < posEnd)
	{	     	     
		int read1 = fread( &hash, sizeof(__int32), 1, file );		
		int read2 = fread( &mark, sizeof(Byte), 1, file );
		if ( ( mark >> 3 ) == ( count + 1 ) )
		{
			if ( hash == hashKey )
			{
				column = (mark & 7) - 1;
				break;
			}
			else if ( hash == revKey )
			{
				column = 7 - (mark & 7);
				break;
			}    				
		}    				
		fgetpos(file, &position);
	}
	fclose(file);
	if ( column != -1 )
	{
		int y = columns[column];
		return moves[y]->pos;						
	}
	return NULL;    
}

//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::incrementFreePositions( Position* pos )
{
	columns[pos->xCoordinate]--;	
}

//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::decrementFreePositions( Position* pos )
{
    columns[pos->xCoordinate]++;
}

//////////////////////////////////////////////////////////////////////////////////////////

int Gameboard::getSizeX()
{
	return status->sizeXOfBoard;
}

//////////////////////////////////////////////////////////////////////////////////////////

int Gameboard::getSizeY()
{
	return status->sizeYOfBoard;
}

//////////////////////////////////////////////////////////////////////////////////////////

Move** Gameboard::getMoves()
{
	return moves;
}

//////////////////////////////////////////////////////////////////////////////////////////

Position* Gameboard::getPosition( int idx )
{
	return moves[idx]->pos;
}

//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::doMove( Gameboard* board, Position* pos, Byte player )
{
	lockKey = board->lockKey;
	revKey  = board->revKey;
	hashKey = board->hashKey;
	moves[pos->linearPos]->player = player;
	scoreStack[count++] = boardscore;
	boardscore = board->boardscore;	
	moveStack[count] = pos->linearPos;	
	side ^= 1;			
	columns[pos->xCoordinate]++; 
	threatStack[0][count] = board->threatStack[0][count]; 
	threatStack[1][count] = board->threatStack[1][count];	
	refutedThreat[count] = board->refutedThreat[count];
}


//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::undoMove( Gameboard* board, Position* pos )
{
	lockKey = board->lockKey;
	revKey  = board->revKey;
	hashKey = board->hashKey;
	columns[pos->xCoordinate]--;
	side ^= 1;	
	boardscore = scoreStack[--count];
	moves[pos->linearPos]->player = SystemConstants::DEFAULT;
}

//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::doMove( Position* pos, Byte playerParam )
{
	player = playerParam;
	lockKey ^= Gameboard::lockKeys[player - 1][pos->xCoordinate][pos->yCoordinate];
	revKey  ^= Gameboard::randomKeys[player - 1][sizeX - pos->xCoordinate][sizeY - pos->yCoordinate];
	hashKey ^= Gameboard::randomKeys[player - 1][pos->xCoordinate][sizeY - pos->yCoordinate];        
	moves[pos->linearPos]->player = player;		
	scoreStack[count++] = boardscore;
	idx = pos->linearPos;
	moveStack[count] = idx;
	side ^= 1;			
	value = evaluatePosition();		
	boardscore = -( boardscore + value );
	columns[pos->xCoordinate]++;        
}

//////////////////////////////////////////////////////////////////////////////////////////

void Gameboard::undoMove( Position* pos )
{
	Byte player = moves[pos->linearPos]->player - 1;       	
	lockKey ^= Gameboard::lockKeys[player][pos->xCoordinate][pos->yCoordinate];
	revKey  ^= Gameboard::randomKeys[player][sizeX - pos->xCoordinate][sizeY - pos->yCoordinate];
	hashKey ^= Gameboard::randomKeys[player][pos->xCoordinate][sizeY - pos->yCoordinate];        	
	boardscore = scoreStack[--count];
	columns[pos->xCoordinate]--;
	side ^= 1;	
	moves[pos->linearPos]->player = SystemConstants::DEFAULT;
}


//////////////////////////////////////////////////////////////////////////////////////////

bool Gameboard::checkWin()
{
	if ( threatStack[side][count] & BITBOARD[idx] )
	{
		// found a win
		boardscore = -SystemConstants::WIN - (SystemConstants::THREE - count);
		return true;
	}
	return false;
}


//////////////////////////////////////////////////////////////////////////////////////////

inline int Gameboard::evaluatePosition() 
{												
	int value = 0;
	Byte start, countGaps = 0, countPlayer = 0, countOpponent = 0, number = 0;
	Byte opponent = player^3;			
	refutedThreat[count] = false;
	threatStack[0][count] = threatStack[0][count - 1]; 
	threatStack[1][count] = threatStack[1][count - 1];	
		
	// check vertical column for threat
	start = idx + direction[3];		
	while ( moves[start]->player == player )
	{
		start += direction[3];
		++countPlayer;
	}
			
	if ( countPlayer == 2 && moves[idx + 1]->player == SystemConstants::DEFAULT )
	{
		// found vertical threat
		threatStack[side][count] |= BITBOARD[idx + 1];					
	}	
	
	// iterate over all remaining directions
	Byte k, cursor;	 

	for ( Byte i = 0; i < 3; i++ )
	{					
		// set position at start
		//start = idx;
		start = START_EVALUATION[i][idx];
		number = NUMBER_EVALUATIONS[i][idx];

		if ( !number )
		{
			// didn't reach four pieces
			continue;
		}

		for ( short n = 0; n < number; ++n, start -= direction[i] )				   				  
		{				   
			cursor = start;
			countPlayer = 0;
			countOpponent = 0;	
			countGaps = 0;

			for ( k = 0; k < 4; ++k, cursor += direction[i] )
			{
				if ( moves[cursor]->player == player )
				{
					countPlayer++;
				}
				else if ( moves[cursor]->player == opponent )
				{
					countOpponent++;
				}
				else
				{
					//gap = cursor;
					gaps[countGaps++] = cursor;
				}
			} // end inner loop			
									
			// perform evaluation of counts for four consecutive pieces					  
			if ( countOpponent == 0 )
			{								
				if ( countPlayer == 2 )
				{										
					value += WEIGHTSPLAYER_MINOR[side][gaps[0]];						
					value += WEIGHTSPLAYER_MINOR[side][gaps[1]];
					continue;
				}				

				if ( countPlayer == 3 )
				{					  	 								
					if ( threatStack[side][count] & BITBOARD[gaps[0]] )
					{
						// threat has already been seen thus ignore it
						continue;
					}	

					// update threats
					threatStack[side][count] |= BITBOARD[gaps[0]];

					if ( threatStack[side^1][count] & BITBOARD[gaps[0] + 1] )
					{
						// we have refuted a threat for the opponent directly above
						value += WEIGHTSPLAYER[side^1][gaps[0] + 1];
					}

					if ( threatStack[side^1][count] & BITBOARD[gaps[0] - 1] )
					{
						// threat directly below for the opponent, 
						// so the current threat is refuted
						continue;
					} 
					
					// check for major threats of the current player
					if ( moves[gaps[0] - 1]->player == SystemConstants::DEFAULT )
					{						
						value += WEIGHTSPLAYER[side][gaps[0]];
					}
				}								
			}
			else if ( countPlayer == 1 )
			{						  						 																																			
				//check whether we can refute threats of the opponent
				if ( countOpponent == 2 )
				{					
					value += WEIGHTSPLAYER_MINOR[side^1][idx];
					value += WEIGHTSPLAYER_MINOR[side^1][gaps[0]];					
					continue;
				}	

				if ( countOpponent == 3 && 					 
					!refutedThreat[count] )
				{									
					threatStack[side^1][count] ^= BITBOARD[idx];	
					refutedThreat[count] = true;

					if ( (moveStack[count - 1] == idx - 1) && !refutedThreat[count - 1] )
					{
						// we have come from directly below and there is no threat there,
						// so we refute the major threat for the opponent					
						value += WEIGHTSPLAYER[side^1][idx];
					}					
				}				
			}					  						  				  					 					  
		} // end inner for loop
	} // end outer for loop for three directions
	return value;
}



//////////////////////////////////////////////////////////////////////////////////////////

#if defined _DEBUG
void Gameboard::dumpBoard( Byte idx )
{
	//_RPTF3(_CRT_WARN, "Position: %d [X]: %d [Y]: %d\n", moves[idx]->player, moves[idx]->pos->xCoordinate, moves[idx]->pos->yCoordinate );
	//_RPTF0(_CRT_WARN, "************************ BOARD ****************************\n");

	for ( int i = 0; i < 72; i++ )
	{
		if ( moves[i]->player != SystemConstants::DEFAULT && moves[i]->player != Gameboard::BORDER )
		{
			_RPTF3(_CRT_WARN, "Player: %d [X]: %d [Y]: %d\n", moves[i]->player, moves[i]->pos->xCoordinate, moves[i]->pos->yCoordinate );
		}	
	}

	_RPTF0(_CRT_WARN, "************************ BOARD ****************************\n");
}
#endif


