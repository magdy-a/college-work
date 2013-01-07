#ifndef QueType_Linked_h
#define QueType_Linked_h

#include "NodeType.h"

class QueType_Linked
{
private:
	NodeType* front;
	NodeType* rear;
public:
	QueType_Linked();
	void MakeEmpty();
	bool IsFull();
	bool IsEmpty();
	void Enqueue(ItemType Item);
	void Dequeue(ItemType& Item);
};


#endif
