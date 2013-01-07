#ifndef StackType_Linked_h
#define StackType_Linked_h

#include "Nodetype.h"

class StackType_Linked
{
private :
	NodeType* topPtr;
public:
	StackType_Linked();
	void MakeEmpty();
	bool IsFull();
	bool IsEmpty();
	void Push(ItemType NewItem);
	void Pop ();
	ItemType Top();
};

#endif