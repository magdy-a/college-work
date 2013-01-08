/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/


#ifndef _CONSTANTS
#define _CONSTANTS

#define MASTER_THREAD 0

class SystemConstants
{
public:

	enum 
	{
		DEFAULT 		 = 	      0,
		PERSON 			 =        1,
		COMPUTER 		 = 	      2,
		NEITHER			 =	      3,  // neither of the players has won the game
		MINIMAX 		 =        0,
		ALPHABETA 		 = 	      1,
		MINORTHREAT      =        2,
		MAJORTHREAT      =        3,
		COMPUTERWIN      =        3,
		PERSONWIN        =		  4,
		SMALL_HASH		 =   400000,
		MEDIUM_HASH		 =   900000,
		LARGE_HASH		 =  1800000,
		BOARD_SIZE		 =       72,	   
		ONE              =        1,
		TWO              =       10,
		THREE			 =       50,
		MAJOR_THREE      =	    500,
		DOUBLETHREAT     =	     50,
		WIN              =	  10000,
		INITIAL_SCORE    =   -15000,
		NEUTRAL          =        0,
		MAX_DEPTH		 =		 25,
		HASH_DEPTH_LEFT  =		  4,
		WINDOW			 =		200,
		INITIAL_WINDOW	 =		100,
		MAX_STATIC_KILLER_EVAL = 40,
		MAX_STATIC_PV_EVAL	   = 30,
		MAX_STATIC_EVAL		   = 50,
		ITER_DEEP_MARGIN	   = 20
	};
};


#endif