/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/


#ifndef _GAMESTATUS
#define _GAMESTATUS

#include "SystemConstants.h"
#include "Position.h"

class GameStatus 
{
public:
	 int 		hashelements;
	 bool		calculate;
	 bool 		book;
	 int  	    hash;
	 int  	    hashSize;
	 int  	    nodes;
	 int        score;
	 long       time;
	 int        depth;
	 int		quiescenceDepth;
	 int        type;
	 int        timeout;
	 int  	    sizeXOfBoard;
	 int        sizeYOfBoard;
	 int		count;
	 int        firstPlayer;
	 int        player;
	 int	    winner; // no eventual winner available yet
	 Position*  pos;
	 Position** winPos;
	 Byte*		pvLine;	

	GameStatus()
	{		
		score = 0;
		count = 0;
		hashelements   = 0;
		calculate      = false;
		book		   = false;
		hash           = 0;
		hashSize       = 0;
		nodes          = 0;
		score          = 0;
		time           = 0;
		depth          = 0;		
		type           = 0;
		timeout        = 0;
		sizeXOfBoard   = 0;
		sizeYOfBoard   = 0;
		count		   = 0;
		quiescenceDepth = 0;
		firstPlayer    = SystemConstants::DEFAULT;
		player         = SystemConstants::DEFAULT;
		winner 	       = SystemConstants::DEFAULT; // no eventual winner available yet
		pos	           = new Position();
		pos->xCoordinate = 0;
		pos->yCoordinate = 0;
		winPos         = NULL;
		pvLine 		   = NULL;	
	}

	~GameStatus()
	{
		delete pos;
	}

	void resetStatus()
	{
		pos->xCoordinate = 0;
		pos->yCoordinate = 0;
		score = 0;
		count = 0;
	}	

	bool isNotDecided()
	{
		return winner == SystemConstants::NEITHER;
	}

	bool isContinued()
	{
		return winner == SystemConstants::DEFAULT;
	}

	bool isWinner( int player )
	{
		return winner == player;
	}

	void setWinner( int winner )
	{ this->winner = winner; }


};

#endif
