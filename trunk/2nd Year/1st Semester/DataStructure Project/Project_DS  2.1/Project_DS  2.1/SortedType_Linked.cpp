#include <iostream>
#include "SortedType_Linked.h"

using namespace std;

SortedType_Linked::SortedType_Linked()
{
	length = 0;
	listData = NULL;
	currentPos = NULL;
}
int SortedType_Linked::LengthIs()
{
	return length;
}
bool SortedType_Linked::IsFull()
{
	NodeType* tempPtr;
	tempPtr = new NodeType;
	if(tempPtr != NULL)
	{
		delete tempPtr;
		return false;
	}
	else
		return true;
}
void SortedType_Linked::DeleteItem(ItemType item)
{
	NodeType* PreLocation = NULL;
	NodeType* Location = listData;
	if(Location->info.ComparedTo(item) == EQUAL)
	{
		listData = Location->next;
		delete Location;
		length --;
		return;
	}
	PreLocation->next = Location;
	Location = Location->next;
	while(Location->info.ComparedTo(item) != EQUAL)
	{
		PreLocation->next = Location;
		Location = Location->next;
	}
	if(Location->info.ComparedTo(item) == EQUAL)
	{
		PreLocation->next = Location->next;
		delete Location;
	}
}
void SortedType_Linked::MakeEmpty()
{
	NodeType* Location;
	while(listData != NULL)
	{
		Location = listData;
		listData = listData->next;
		delete Location;
		length --;
	}
	ResetList();
}
void SortedType_Linked::InsertItem(ItemType item)
{
	NodeType* newNode;
	NodeType* predLoc;
	NodeType* location;
	bool moreToSearch;

	location = listData;
	predLoc = NULL;
	moreToSearch = (location != NULL);

	while (moreToSearch)
	{
		if (item.ComparedTo(location->info) == GREATER)
	    {
			predLoc = location;
			location = location->next;
			moreToSearch = (location != NULL);
	    }
		else
		moreToSearch = false;
	}

	newNode = new NodeType;
	newNode->info = item;
	if (predLoc == NULL)
	{
		newNode->next = listData;
		listData = newNode;
	}
	else
	{
		newNode->next = location;
		predLoc->next = newNode;
	}
  length++;
}
void SortedType_Linked::RetrieveItem(ItemType& item,bool& found)
{
	NodeType* Location = listData;
	found = false;
	while(Location != NULL && ! found)
	{
		switch(Location->info.ComparedTo(item))
		{
		case LESS:
			Location = Location->next;
			found = false;
			break;
		case GREATER:
			found = false;
			return;
		case EQUAL:
			found = true;
		}
	}
}
void SortedType_Linked::GetNextItem(ItemType& item)
{
	if(currentPos != NULL)
		currentPos = currentPos->next;
	if(currentPos == NULL)
		currentPos = listData;
	item = currentPos->info;


	/*if(currentPos != NULL) // hena kanet el currentPos fe el 2awel = listData ! we el code sha3'al
	{
		if(currentPos == listData)
			cout<< "First element in the list is ....\n";
		item = currentPos->info;
		currentPos = currentPos->next;
	}
	if(currentPos == NULL)
	{
		currentPos = listData;
		cout<< "First element in the list is ....\n";
		if(currentPos != NULL)
		{
			item = currentPos->info;
			currentPos = currentPos->next;
		}
		else
			cout<< "NULL ... Cuz There is no data to display\n\n";
	}*/
}
void SortedType_Linked::ResetList()
{
	currentPos = NULL;
}