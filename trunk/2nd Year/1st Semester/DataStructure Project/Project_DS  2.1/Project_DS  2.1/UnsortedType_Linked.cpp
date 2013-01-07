#include<iostream>
#include"UnsortedType_Linked.h"

using namespace std;

void Print_Unsorted_Linked(NodeType* Ptr);

UnsortedType_Linked::UnsortedType_Linked()
{
	listData = NULL;
	currentPos = NULL;
	length = 0;
}
void UnsortedType_Linked::MakeEmpty()
{
	NodeType* tempPtr;
	while(listData != NULL)
	{
		tempPtr = listData;
		listData = listData->next;
		delete tempPtr;
		length --;
	}
	ResetList();
}
int UnsortedType_Linked::LengthIs()
{
	return length;
}
bool UnsortedType_Linked::IsFull()
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
void UnsortedType_Linked::InsertItem(ItemType item)
{
	NodeType* Location;
	Location = new NodeType;
	Location->info = item;
	Location->next = listData;
	listData = Location;
	length ++;
}
void UnsortedType_Linked::DeleteItem(ItemType item)
{
	if(length == 1)
	{
		MakeEmpty();
		return;
	}
	NodeType* preLocation = NULL;
	NodeType*  location = listData;
	if(item.ComparedTo(location->info) == EQUAL)
		listData = location->next;
	else
	{
		preLocation = location;
		location = location->next;
		while( ! (item.ComparedTo(location->info) == EQUAL) )
		{
			preLocation = location;
			location=location->next;
		}
		preLocation->next = location->next;
	}
	delete location;
	length--;
}

void UnsortedType_Linked::GetNextItem(ItemType& item)
{

	if(currentPos != NULL)
		currentPos = currentPos->next;
	if(currentPos == NULL)
		currentPos = listData;
	item = currentPos->info;



	//if(currentPos != NULL) // hena kanet el currentPos initialized = listData we el code sha3'al
	//{
	//	if(currentPos == listData)
	//		cout<< "First element in the list is ....\n";
	//	item = currentPos->info;
	//	currentPos = currentPos->next;
	//}
	//if(currentPos == NULL)
	//{
	//	currentPos = listData;
	//	cout<< "First element in the list is ....\n";
	//	if(currentPos != NULL)
	//	{
	//		item = currentPos->info;
	//		currentPos = currentPos->next;
	//	}
	//	else
	//		cout<< "NULL ... Cuz There is no data to display\n\n";
	//}
}
void UnsortedType_Linked::ResetList()
{
	currentPos = NULL;
}
void UnsortedType_Linked::RetrieveItem(ItemType& item,bool& found)
{
	NodeType* tempPtr;
	tempPtr = listData;
	found = false;
	while(tempPtr != NULL && ! found)
	{
		switch(tempPtr->info.ComparedTo(item))
		{
		case LESS:
		case GREATER:
			tempPtr = tempPtr->next;
			found = false;
			break;
		case EQUAL:
			found = true;
		}
	}
}
void UnsortedType_Linked::PrintList()
{
	Print_Unsorted_Linked(listData);
}
void Print_Unsorted_Linked(NodeType* Ptr)
{
	if(Ptr != NULL)
	{
		Print_Unsorted_Linked(Ptr->next);
		Ptr->info.Print();
	}
}