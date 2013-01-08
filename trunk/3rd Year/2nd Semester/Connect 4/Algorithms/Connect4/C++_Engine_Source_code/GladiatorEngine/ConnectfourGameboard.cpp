/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001
*    Application: Four wins
***************************************************/
#include "stdafx.h"
#include "SystemConstants.h"
#include "Position.h"
#include "Gameboard.h"
#include "Threats.h"
#include "ConnectfourGameboard.h"
#include "Move.h"
#include "GameStatus.h"
#include <stdio.h>
#include <crtdbg.h>


/*	The board:

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


const __int64 ConnectFourGameboard::BITBOARD[72] = 
{	
	//rows			1			2				3				4				  5					   6			
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



const int ConnectFourGameboard::STATIC_MOVE_EVALUATION[7][6] = 
{
	// lower half is prefered with 2 x number + 1
	{  7,   9,  11,  10,   8,  6 },
	{  9,  13,  17,  16,  12,  8 },
	{ 11,  17,  23,  22,  16, 10 },
	{ 15,  21,  27,  26,  20, 14 },
	{ 11,  17,  23,  22,  16, 10 },
	{  9,  13,  17,  16,  12,  8 },
	{  7,   9,  11,  10,   8,  6 }
};
 

// first subscript
// 0 = second player
// 1 = first player
const int ConnectFourGameboard::WEIGHTSPLAYER[][72] = {
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

const int* ConnectFourGameboard::WEIGHTS = WEIGHTSPLAYER[0];

const int ConnectFourGameboard::VALUES[] = { 0, 
										SystemConstants::ONE, 
										SystemConstants::TWO, 
										SystemConstants::THREE };

const int ConnectFourGameboard::SIDEVALUES[] = { SystemConstants::MAJOR_THREE - 100,
										   SystemConstants::MAJOR_THREE };

const int ConnectFourGameboard::MINORSIDEVALUES[] = { SystemConstants::THREE - 10,
												SystemConstants::THREE };


const int ConnectFourGameboard::direction[] = { -1, 8, 9, -7 };
const int ConnectFourGameboard::order[] = { 3, 2, 4, 1, 5, 6, 0 };

ConnectFourGameboard::ConnectFourGameboard() : Gameboard(), columns(NULL)
{	
	winningRow = new Position*[4];
}


ConnectFourGameboard::~ConnectFourGameboard()
{
	delete[] winningRow;
	delete[] columns;
}


int ConnectFourGameboard::getStaticEvaluation( int x, int y )
{
	return STATIC_MOVE_EVALUATION[x][y];
}


void ConnectFourGameboard::doInitializeGameboard()
{	
	columns = new int[ status->sizeXOfBoard ];
    
    for ( int i = 0; i < status->sizeXOfBoard; i++ )
        columns[i] = (i + 1) * ( status->sizeYOfBoard + 2 ) + 1;

	for ( Byte i = 0; i < THREATSTACKSIZE; i++ )
	{
		threatStack[0][i] = 0;
		threatStack[1][i] = 0;
	}	
}

int ConnectFourGameboard::getNextFreeIndex( int index )
{
    return columns[index];
}



void ConnectFourGameboard::resetBoard()
{
	for ( int i = 0; i < status->sizeXOfBoard; i++ )
		columns[i] = (i + 1) * ( status->sizeYOfBoard + 2 ) + 1;

	for ( Byte i = 0; i < THREATSTACKSIZE; i++ )
	{
		threatStack[0][i] = 0;
		threatStack[1][i] = 0;
	}	

	Gameboard::resetBoard();
}


void ConnectFourGameboard::makeMoveList( Position** moveList, Position* killerPos, Position* pv )
{                              
    Move* move;

    moveList[0] = NULL;
    moveList[1] = NULL;
    
    for ( int index = 0; index < status->sizeXOfBoard; ++index )
    {              
		moveList[index + 2] = NULL;
	        
		move = moves[columns[order[index]]];              
		if ( move->player == SystemConstants::DEFAULT )
		{
          	if ( move->pos == killerPos )
          	{
          		moveList[0] = killerPos;
          		continue;
          	}
          	if ( move->pos == pv )
          	{
          		moveList[1] = pv;
          		continue;
          	}
          	moveList[index + 2] = move->pos;
		}
    }
}


Position* ConnectFourGameboard::preSortMoves(Move** moveList, Byte& size)
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
			boardscore = -SystemConstants::WIN + (SystemConstants::THREE - count);					
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


Byte ConnectFourGameboard::sortMoveList( Position** moveList, Position** killerPos )
{                              
    Move* move;	
	Position* pos;
	Byte origKillerScore = killerPos[0]->staticEval; 
	Byte origKillerScore2 = killerPos[1]->staticEval;
	
	killerPos[0]->staticEval = SystemConstants::MAX_STATIC_KILLER_EVAL; // best move
	killerPos[1]->staticEval = SystemConstants::MAX_STATIC_PV_EVAL; // second best move    
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
			boardscore = -SystemConstants::WIN + (SystemConstants::THREE - count);	
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

		if ( size < 2 )
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
	killerPos[0]->staticEval = origKillerScore; // best move
	killerPos[1]->staticEval = origKillerScore2; // second best move

	if (!size && counterThreats)
	{
		// we have lost
		boardscore = SystemConstants::WIN - (SystemConstants::THREE - count);				
	}	
	return size;
}

Position* ConnectFourGameboard::getPos( int index )
{
    Move* move = moves[columns[order[index]]];
    if ( move->player == SystemConstants::DEFAULT )
    {
    	return move->pos;
    }
    return NULL;
}

Position* ConnectFourGameboard::checkPos( Position* pos )
{
    if ( pos != NULL && pos->linearPos == columns[pos->xCoordinate] && 
    		moves[pos->linearPos]->player == SystemConstants::DEFAULT )
    {
    	return pos;
    }
    return NULL;
}

Position** ConnectFourGameboard::checkFinalWin( Position* pos, Byte& length )
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



const Position* ConnectFourGameboard::lookupBookMove( const wchar_t* path )
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



void ConnectFourGameboard::incrementFreePositions( Position* pos )
{
	columns[pos->xCoordinate]--;	
}

void ConnectFourGameboard::decrementFreePositions( Position* pos )
{
    columns[pos->xCoordinate]++;
}

          

int ConnectFourGameboard::evaluatePosition( Byte idx, Byte player ) 
{												
	int value = 0;
	Byte start, gap = 0, countPlayer = 0, countOpponent = 0;
	Byte opponent = 3 - player;			
	refutedThreat[count] = false;
	threatStack[0][count] = threatStack[0][count - 1]; 
	threatStack[1][count] = threatStack[1][count - 1];		
		
	// check vertical column for threat
	start = idx + direction[0];		
	while ( moves[start]->player == player )
	{
		start += direction[0];
		++countPlayer;
	}
			
	if ( countPlayer >= 3 )
	{
		// found win
		return -SystemConstants::WIN + (SystemConstants::THREE - count);
	}
	if ( countPlayer == 2 && moves[idx + 1]->player == SystemConstants::DEFAULT )
	{
		// found vertical threat
		threatStack[side][count] |= BITBOARD[idx + 1];					
	}	
	// iterate over all remaining directions
	Byte k, cursor;	 

	for ( Byte i = 1; i < 4; i++ )
	{					
		// set position at start
		start = idx;

		for ( short n = 0; WEIGHTS[start] != BORDER && n < 4; ++n, start -= direction[i] )				   				  
		{				   
			cursor = start;
			countPlayer = 0;
			countOpponent = 0;	

			for ( k = 0; WEIGHTS[cursor] != BORDER && k < 4; ++k, cursor += direction[i] )
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
					gap = cursor;
				}
			} // end inner loop

			if ( k < 4 )
			{
				// didn't reach four pieces
				continue;
			}
			
			if ( countPlayer == 4 )
			{
				// found win
				return -SystemConstants::WIN + (SystemConstants::THREE - count);
			}
						
			// perform evaluation of counts for four consecutive pieces					  
			if ( countOpponent == 0 )
			{
				if ( countPlayer == 3 )
				{					  	 								
					if ( threatStack[side][count] & BITBOARD[gap] )
					{
						continue;
					}
					threatStack[side][count] |= BITBOARD[gap];					
					
					//if ( isThreat( gap - 1, opponent ) == true )
					if ( threatStack[side^1][count] & BITBOARD[gap - 1] )
					{
						// threat directly below for the opponent
						continue;
					} 
					// check for major threats of the current player
					if ( moves[gap - 1]->player == SystemConstants::DEFAULT )
					{						
						value += WEIGHTSPLAYER[side][gap];
					}
					
					//if ( isThreat( gap + 1, opponent ) )
					if ( threatStack[side^1][count] & BITBOARD[gap + 1] )
					{
						value += WEIGHTSPLAYER[side^1][gap + 1];
					}
					// check for double threats
					//if ( isThreat( gap - 1, player ) )
					if ( threatStack[side][count] & BITBOARD[gap - 1] || threatStack[side][count] & BITBOARD[gap + 1] )
					{
						value += SystemConstants::DOUBLETHREAT;					  	 		
					}						
				}
				else
				{
					value += VALUES[countPlayer];
				}
			}
			else if ( countPlayer == 1 )
			{						  						 																																			
				if ( countOpponent == 3 && 
					(moveStack[count - 1] == idx - 1) && 
					!refutedThreat[count] )
				{									
					threatStack[side^1][count] &= ~BITBOARD[idx];	
					refutedThreat[count] = true;

						if ( !refutedThreat[count - 1] )
						{
							// refute major threat of the opponent					
							value += WEIGHTSPLAYER[side^1][idx];
						}
					
				}
				else
				{
					value += VALUES[countOpponent];
				}
			}					  						  				  					 					  
		} // end inner for loop
	} // end outer for loop for three directions
	return value;
}

inline bool ConnectFourGameboard::isThreat( int pos, int player )
{
	int count = 0;
	int cursor = pos;
	
	// use only empty positions 
	if ( moves[cursor]->player != SystemConstants::DEFAULT )
	{
		return false;
	}
	
	for ( int i = 1; i < 4; ++i )
	{
		count = 0;
		cursor = pos;
		cursor -= direction[i];
		while ( moves[cursor]->player == player )
		{
			count++;
			cursor -= direction[i];
		}
		cursor = pos;
		cursor += direction[i];
		while ( moves[cursor]->player == player )
		{
			count++;
			cursor += direction[i];
		}
		
		if ( count == 3 )
			break;
	}
	return count >= 3;
}      
	


bool ConnectFourGameboard::isUnstablePosition()
{
	int delta = -boardscore - scoreStack[count - 1];
	return ( (delta <= -400 || delta >= 400) );
}


#if defined _DEBUG
void ConnectFourGameboard::dumpBoard( Byte idx )
{
	_RPTF3(_CRT_WARN, "Position: %d [X]: %d [Y]: %d\n", moves[idx]->player, moves[idx]->pos->xCoordinate, moves[idx]->pos->yCoordinate );
	_RPTF0(_CRT_WARN, "************************ BOARD ****************************\n");

	for ( int i = 0; i < 72; i++ )
	{
		if ( moves[i]->player != SystemConstants::DEFAULT && moves[i]->player != ConnectFourGameboard::BORDER )
		{
			_RPTF3(_CRT_WARN, "Player: %d [X]: %d [Y]: %d\n", moves[i]->player, moves[i]->pos->xCoordinate, moves[i]->pos->yCoordinate );
		}	
	}

	_RPTF0(_CRT_WARN, "************************ BOARD ****************************\n");
}
#endif