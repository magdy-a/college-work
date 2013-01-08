/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/



#include "stdafx.h"
#include "Array.h"
#include "PtrArray.h"
#include "HashElement.h"
#include "TranspositionTable.h"
#include "MemoryInfo.h"
#include "math.h"
#include <omp.h>

const int TranspositionTable::MEM_ALLOC_THRESHOLD = 50; // in MByte


TranspositionTable::TranspositionTable( int size ) : elements(NULL), buckets(NULL)
{	
	initHashtable( size );
}

//////////////////////////////////////////////////////////////////////////////////////////

TranspositionTable::TranspositionTable() : elements(NULL), 
										   buckets(NULL),
										   size(0),
										   maxIndex(0),
										   capacity(0),
										   currentIndex(-1)
{	
}

//////////////////////////////////////////////////////////////////////////////////////////

void TranspositionTable::initHashtable( int size )
{
	currentIndex = -1;
	buckets		 = NULL;
	this->size   = size;
	maxIndex	 = size - 1;
	capacity	 = (int)(size / 0.73); // efficient load factor	
	elements	 = new HashElement[size];	
	
	// search for next prime
	int i = capacity;
	while ( true )
	{
		// check against the first three prime numbers
		if ( i % 3 != 0 && i % 2 != 0 && i % 5 != 0 )
		{
			break;
		}
		i++;
	}
	capacity = i;	

	buckets = new BUCKET[capacity];	

	for ( i = 0; i < capacity; i++ )
	{
		BUCKET* bucket = &(buckets[i]);		
		bucket->PreAllocate(kFirstAllocation);				
	}		
	
}

//////////////////////////////////////////////////////////////////////////////////////////

bool TranspositionTable::isPhysicalMemAvailable()
{
	MemoryInfo memInfo;
	int availMem = (int)(memInfo.getAvailMemory() / (1024 * 1024)); // convert to MBytes	
	int factor = sizeof(void*) / 4;	
	return availMem >= (factor * MEM_ALLOC_THRESHOLD);
}

//////////////////////////////////////////////////////////////////////////////////////////

double TranspositionTable::calcMemoryDemand()
{
	MemoryInfo memInfo;
	int factor = sizeof(void*) / 4;
	double availMem = (double)memInfo.getAvailMemory() / (1024 * 1024); // convert to MBytes	
	double demand = ( factor * MEM_ALLOC_THRESHOLD ) - availMem; 
	if ( demand <= 0 )
	{
		return 0;
	}
	// round to two decimal places i.e. "0.00" notation
	demand = floor( demand * 100 + 0.5 ) / 100;
	return demand;
}

//////////////////////////////////////////////////////////////////////////////////////////

void TranspositionTable::resize( int numElements )
{	
	if ( numElements != this->size )
	{
		freeTable();
		if ( !numElements )
		{
			return;
		}
		initHashtable( numElements );
	}
	else if ( numElements )
	{
		clear();
	}
}

//////////////////////////////////////////////////////////////////////////////////////////

void TranspositionTable::freeTable()
{	
	size = 0;
	capacity = 0;
	delete[] buckets;
	delete[] elements;
	buckets = NULL;
	elements = NULL;
}

//////////////////////////////////////////////////////////////////////////////////////////

TranspositionTable::~TranspositionTable()
{
	freeTable();
}

//////////////////////////////////////////////////////////////////////////////////////////

void TranspositionTable::clear()
{
	currentIndex = -1;

	for ( int i = 0; i < capacity; i++ )
	{
		BUCKET* bucket = &(buckets[i]);
		bucket->ResetItemCount();		
	}		
}



//////////////////////////////////////////////////////////////////////////////////////////

int TranspositionTable::getSize()
{
	return currentIndex;
}

