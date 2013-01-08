/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001
*    Application: Four wins
***************************************************/

#ifndef _TRANSTABLE
#define _TRANSTABLE

//class HashElement;
#include "HashElement.h"

typedef Array<Int> BUCKET;
typedef PtrArray<BUCKET> CONTAINER;

class TranspositionTable
{
private:	
	//CONTAINER buckets;
	BUCKET* buckets;
	HashElement*  elements;
	int size;
	int maxIndex;
	int capacity;  // number of buckets
	int currentIndex;	
	static const int MEM_ALLOC_THRESHOLD;

protected:
	void initHashtable( int size );	

public:
	static bool isPhysicalMemAvailable();
	static double calcMemoryDemand();
public:
	TranspositionTable( int size );
	TranspositionTable();
	void freeTable();
	~TranspositionTable();
	void clear();
	HashElement* nextElement();
	void put();
	int getSize();
	HashElement* get( HashElement* searchElement );
	void resize( int size );
	bool isFull()
	{ 
		return currentIndex >= maxIndex;
	}
	int getIndex()
	{
		return currentIndex;
	}
};


//////////////////////////////////////////////////////////////////////////////////////////

inline HashElement* TranspositionTable::nextElement()
{
	HashElement* elem;	
	if ( currentIndex == maxIndex )
	{
		elem = NULL;
	}
	else
	{			 
		elem = &(elements[++currentIndex]);		
	}		
	
	return elem;
}


//////////////////////////////////////////////////////////////////////////////////////////

inline void TranspositionTable::put()
{
	int entry = elements[currentIndex].hashKey % capacity;
	buckets[entry].Append( currentIndex );	
}	

//////////////////////////////////////////////////////////////////////////////////////////

inline HashElement* TranspositionTable::get( HashElement* searchElement )
{
	int entry = searchElement->hashKey % capacity;
	BUCKET& bucket = buckets[entry];
	HashElement* elem;

	for ( int i = 0; i < bucket.NumItems(); i++ )
	{		
		_ASSERT(i < 8);
		elem = &elements[bucket.Item(i)];
		if ( elem->lockKey == searchElement->lockKey )
		{
			return elem;
		}
	}
	return NULL;
}

#endif