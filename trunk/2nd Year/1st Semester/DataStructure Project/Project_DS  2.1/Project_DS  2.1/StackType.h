#ifndef StackType_h
#define StackType_h

#include "ItemType.h"

class StackType
{
private:
	int top;
	ItemType items[MAX_ITEMS];
public:
	StackType();
	void MakeEmpty();
	bool IsEmpty();
	bool IsFull();
	void Push(ItemType item);
	void Pop();
	ItemType Top();
};


#endif