
#ifndef _MOVE
#define _MOVE

class Move
{
public:

    Position*		pos;
	Byte  			player;
	short			score;
	static Move		maxScore;	

    Move( Position* pos, int player )
    {
        this->pos = pos;
        this->player = player;		
    }

	~Move()
	{
		if ( pos != &Position::defaultPos )
		{
			delete pos;
		}
	}

    int getPlayer()
    {
        return player;
    }

    Position* getPosition()
    {
        return pos;
    }

    void setPlayer( int player )
    {
        this->player = player;
    }

    void setPosition( Position* pos )
    {
        this->pos = pos;
    }

	Move()
    {
		pos = NULL;
		player = SystemConstants::DEFAULT;
		score = 0;		
    }

    Move(short score)
    {
		pos = NULL;
		player = SystemConstants::DEFAULT;
		this->score = score;	
    }

    Move( Position* pos )
    {
        this->pos = pos;
		this->player = SystemConstants::DEFAULT;
		score = 0;	
    }
};

#endif