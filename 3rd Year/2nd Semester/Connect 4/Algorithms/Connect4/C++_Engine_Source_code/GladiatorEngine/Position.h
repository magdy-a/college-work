
#ifndef _POSITION
#define _POSITION

class Position
{
public:
	Byte xCoordinate;
	Byte yCoordinate;	
    // linearPos 0 .. 72
    Byte linearPos;
	Byte staticEval;		
    static Position defaultPos;
	static Position maxPos;

	Position( const Position& pos )
	{
		xCoordinate = pos.xCoordinate;
		yCoordinate = pos.yCoordinate;
		linearPos   = pos.linearPos;
		staticEval  = pos.staticEval;		
	}

    Position( int coordX, int coordY, int idx, int staticScore )
	{
		xCoordinate = coordX;
		yCoordinate = coordY;
		linearPos   = idx;
		staticEval  = staticScore;				
	}

	Position( int coordX, int coordY )
	{
		xCoordinate = coordX;
		yCoordinate = coordY;
		linearPos = -1;		
		staticEval = 0;
	}

    Position::Position()
	{
		xCoordinate = 0;
		yCoordinate = 0;		
		linearPos = 0;
		staticEval = 0;
	}

	~Position()
	{

	}

};

#endif