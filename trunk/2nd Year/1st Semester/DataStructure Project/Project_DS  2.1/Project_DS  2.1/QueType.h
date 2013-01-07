#ifndef QueType_h
#define QueType_h

#include "ItemType.h"

class QueType
{
private:
	int front;
	int rear;
	int maxQue;
	ItemType items[MAX_ITEMS + 1];
public:
	QueType();
	void MakeEmpty();
	bool IsFull();
	bool IsEmpty();
	void Enqueue(ItemType newItem);
	void Dequeue(ItemType& item);
};


#endif