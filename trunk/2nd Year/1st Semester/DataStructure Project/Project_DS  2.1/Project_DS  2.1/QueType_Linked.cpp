#include<iostream>
#include "QueType_Linked.h"

using namespace std;

QueType_Linked::QueType_Linked()
{
	front = NULL;
	rear = NULL;
}
void QueType_Linked::MakeEmpty()
{
	NodeType* tempPtr;
	while(front != NULL)
	{
		tempPtr = front;
		front = front->next;
		delete tempPtr;
	}
	rear = NULL;
}

bool QueType_Linked::IsFull()
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
bool QueType_Linked::IsEmpty()
{
	return (front == NULL);
}
void QueType_Linked::Enqueue(ItemType Item)
{
	NodeType* Location;
	Location = new NodeType;
	Location->info = Item;
	Location->next = NULL;
	if(rear == NULL)
		front = Location;
	else
		rear->next = Location;
	rear = Location;
}
void QueType_Linked::Dequeue(ItemType& Item)
{
	NodeType* tempPtr;
	tempPtr = front;
	Item = tempPtr->info;
	front = front->next;
	if(front == NULL)
		rear = NULL;
	delete tempPtr;
}