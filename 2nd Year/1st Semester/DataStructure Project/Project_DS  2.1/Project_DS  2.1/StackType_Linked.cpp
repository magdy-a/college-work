#include "StackType_Linked.h"
#include <iostream>

using namespace std;

StackType_Linked::StackType_Linked()
{
	topPtr = NULL;
}
void StackType_Linked::MakeEmpty()
{
	NodeType* tempPtr;
	while(topPtr != NULL)
	{
		tempPtr = topPtr;
		topPtr = topPtr->next;
		delete tempPtr;
	}
}
bool StackType_Linked::IsEmpty()
{
	return topPtr == NULL;
}
void StackType_Linked::Push(ItemType NewItem)
{
	NodeType* Location;
	Location = new NodeType;
	Location->info = NewItem;
	Location->next = topPtr;
	topPtr = Location;
}
void StackType_Linked::Pop()
{
	NodeType* tempPtr;
	tempPtr = topPtr;
	topPtr = topPtr->next;
	delete tempPtr;
}
ItemType StackType_Linked::Top()
{
	return (topPtr->info);
}

bool StackType_Linked::IsFull()
{
	NodeType* Location;
	Location = new NodeType;
	if(Location != NULL)
	{
		delete Location;
		return false;
	}
	else
		return true;
}