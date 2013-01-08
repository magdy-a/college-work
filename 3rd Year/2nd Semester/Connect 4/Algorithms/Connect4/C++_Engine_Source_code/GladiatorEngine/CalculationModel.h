/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/



#ifndef _CALCMODEL
#define _CALCMODEL

class CalculationModel
{
private:
	int window;
	int initialWindow;
	int maxDepth;
	int hashelements;
	int origHashelements;
	Byte hashDepthLeft;	
	int threadPriority;	
public:

	CalculationModel( int window,
		int initialWindow,
		int maxDepth,
		int hashelements,
		Byte hashDepthLeft,
		Byte margin)
	{

		this->window        = window;
		this->initialWindow = initialWindow;
		this->maxDepth      = maxDepth;
		this->hashelements  = origHashelements = hashelements;
		this->hashDepthLeft = hashDepthLeft;
		threadPriority      = THREAD_PRIORITY_NORMAL;		
	}

	int getWindow()
	{
		return window;
	}

	int getThreadPriority()
	{
		return threadPriority;
	}

	int getInitialWindow()
	{
		return initialWindow;
	}

	int getMaxDepth()
	{
		return maxDepth;
	}

	int getHashelements()
	{
		return hashelements;
	}

	int getOrigHashelements()
	{
		return origHashelements;
	}

	void setHashelements( int size )
	{
		hashelements = size;
	}

	Byte getHashDepthLeft()
	{
		return hashDepthLeft;
	}
};

#endif