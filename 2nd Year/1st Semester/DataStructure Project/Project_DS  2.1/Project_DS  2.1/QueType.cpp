#include "QueType.h"
#include <iostream>
using namespace std;

QueType::QueType()
{
	maxQue = MAX_ITEMS + 1;
	front = maxQue - 1;
	rear  = maxQue - 1;
}
void QueType::MakeEmpty()
{
	front = rear = maxQue - 1;
}
bool QueType::IsEmpty()
{
	return (rear == front);
}
bool QueType::IsFull()
{
	return ((rear+1)%maxQue == front);
}
void QueType::Enqueue(ItemType newItem)
{
	rear = (rear + 1)  % maxQue;
	items[rear] = newItem;
}
void QueType::Dequeue(ItemType& item)
{
	front = (front + 1) % maxQue;
	item = items[front];
}