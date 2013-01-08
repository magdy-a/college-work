/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/


#ifndef _CONNECTFOURGAMEBOARD
#define _CONNECTFOURGAMEBOARD

#define THREATSTACKSIZE 43

class ConnectFourGameboard : public Gameboard
{
private:		

	static const int* WEIGHTS;
	static const int VALUES[];
	static const int SIDEVALUES[];
	static const int MINORSIDEVALUES[];
	static const int WEIGHTSPLAYER[2][72];
	static const int STATIC_MOVE_EVALUATION[7][6];
	static const int MAX_STATIC_KILLER_EVAL;
	static const int MAX_STATIC_PV_EVAL;
	static const int direction[];
	static const int order[];		
	static const __int64 BITBOARD[72];	

	int*   columns;
	Position** winningRow;		
	__int64 threatStack[2][THREATSTACKSIZE];
	
public:

	ConnectFourGameboard();
    virtual ~ConnectFourGameboard();

	virtual void doInitializeGameboard();
    int getNextFreeIndex( int index );
	virtual void makeMoveList( Position** moveList, Position* killerPos, Position* pv );
	virtual Byte sortMoveList( Position** moveList, Position** killerPos );
	virtual Position* preSortMoves(Move** moveList, Byte& size);
	Position* getPos( int index );
	Position* checkPos( Position* pos );
	virtual Position** checkFinalWin( Position* pos, Byte& length );
	virtual const Position* lookupBookMove( const wchar_t* path );
	virtual bool isUnstablePosition();	
	virtual void incrementFreePositions( Position* pos );
	virtual void decrementFreePositions( Position* pos );
	virtual void resetBoard();
#if defined _DEBUG
	virtual void dumpBoard(Byte idx);
#endif
	virtual int evaluatePosition( Byte idx, Byte player );
	virtual int getStaticEvaluation( int x, int y );
	inline bool isThreat( int pos, int player );
	inline bool isAcuteThreat( Position* pos );	
	
};
#endif    