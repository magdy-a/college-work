/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/



#ifndef _GAMEBOARD
#define _GAMEBOARD

class GameStatus;
class Position;
class Move;
class ThreadData;

#define THREATSTACKSIZE 43
#define BOARDSIZE 72

class Gameboard
{
protected:
        
	GameStatus* status;
	ThreadData* threadData;
	Byte* masterPVL;	
	Byte count;
	Byte side;
	Byte start; 
	Byte countGaps; 
	Byte countPlayer; 
	Byte countOpponent;
	Byte number;
	Byte opponent;
	Byte countArr[3];
	Byte gap;
	Byte idx;
	Byte player;
	Byte killerMoveIdx; 
	Byte pvMoveIdx;
	
	unsigned int revKey;	
	unsigned int hashKey;
	unsigned int lockKey;
	unsigned __int64 origHistoryScore;		
	Position* currentPvPos;
	Position* currentKillerPos;		
	
	int maxCount;
	int value;
	int  numberMoves;
	int	 boardscore;
	int	 sizeX;
	int	 sizeY;
	int* scoreStack;
	Byte* moveStack;
	Byte  gaps[4];
	bool* refutedThreat;
	Move** moves;  	
	bool init;
	bool win;

	static const unsigned int randomStartValues[];
	static const unsigned int randomKeys[][7][6];
	static const unsigned int lockKeys[][7][6];
	static const int* WEIGHTS;
	static const int VALUES[];
	static const int SIDEVALUES[];
	static const int MINORSIDEVALUES[];
	static const int START_EVALUATION[3][72];
	static const int NUMBER_EVALUATIONS[3][72];
	static const int WEIGHTSPLAYER[2][72];
	static const int WEIGHTSPLAYER_MINOR[2][72];
	static const int STATIC_MOVE_EVALUATION[7][6];
	static const int MAX_STATIC_KILLER_EVAL;
	static const int MAX_STATIC_PV_EVAL;
	static const int direction[];
	static const int order[];		
	static const __int64 BITBOARD[72];	

	int*   columns;
	Position** winningRow;		
	__int64 threatStack[2][THREATSTACKSIZE];
	unsigned __int64 historyTable[2][72];

protected:

	inline int evaluatePosition();
	inline int evaluatePositionOrig();
	inline int evaluatePositionOrig( Byte idx, Byte player );
	inline int getStaticEvaluation( int x, int y );
	__forceinline void evaluate();	
	void incrementFreePositions( Position* pos );
	void decrementFreePositions( Position* pos );

public:

	static const int  UNKNOWN;
	static const int  BORDER;	
	static const unsigned __int64 BEST_HISTORY_SCORE;
		
	Gameboard(ThreadData* data);
	~Gameboard();
	Position** checkFinalWin( Position* pos, Byte& length );
	const Position* lookupBookMove( const wchar_t* path );
	void makeMoveList( Position** list, Position* killerpos, Position* pv );
	Byte sortMoveList( Position** moveList, Byte currentDepth );
	Byte sortMoveListHistory( Position** moveList, Position* killerPos );
	Position* preSortMoves(Move** moveList, Byte& size); 	
	Position* getPos( int index );
	void doInitializeGameboard();
	Position* checkPos( Position* pos );		
	void resetBoard();
	bool isUnstablePosition();	
	void setSide( int player );		
	GameStatus* getStatus();
	void setStatus( GameStatus* status );
	int getScore();
	void setTimeOut( int timeout );
	void updateStatus( GameStatus* status );
	inline unsigned int getHashKey() { return hashKey; }
	inline unsigned int getLockKey() { return lockKey; }
	inline unsigned int getRevKey()  { return revKey; }
	void resetHashKeys();
	bool noFreePosition();
	bool isInitialized() { return init; }	
	int getLinearPosIndex( int x, int y );
	void initializeBoard( GameStatus* status );
	int getSizeX();
	int getSizeY();
	Move** getMoves();
	Move* getMove( int idx ) { return moves[idx]; }
	Position* getPosition( int idx );
	void doMove( Position* pos, Byte player );
	void doMove( Gameboard* board, Position* pos, Byte player );
	void undoMove( Position* pos );	
	void undoMove( Gameboard* board, Position* pos );
	int getCount() { return count; }
	int freePositions() { return maxCount - count; }
	void addToHistory(Byte idx, Byte subDepth);
	void resetHistoryValues();
	bool checkWin();
	void setMasterPVL(Byte* pvl)
	{
		masterPVL = pvl;
	}


#if defined _DEBUG
	void dumpBoard(Byte idx);
#endif
};

#endif