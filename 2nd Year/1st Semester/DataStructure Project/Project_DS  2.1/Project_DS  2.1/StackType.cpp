#include <iostream>
#include "StackType.h"
using namespace std;

StackType::StackType()
{
	top = -1;
}

void StackType::MakeEmpty()
{
	top = -1;
}

bool StackType::IsEmpty()
{
	return (top == -1);
}

bool StackType::IsFull()
{
	return (top == (MAX_ITEMS - 1));
}

void StackType::Push(ItemType NewItem)
{
	if( ! IsFull() )
	{
		top ++;
		items[top] = NewItem;
	}
	else
	{
		for(int i=0;i< MAX_ITEMS - 1;i++)
			items[i] = items[i+1];
		items[MAX_ITEMS - 1] = NewItem;
	}
}

void StackType::Pop()
{
	if(top != -1)
		top --;
}

ItemType StackType::Top()
{
	return items[top];
}