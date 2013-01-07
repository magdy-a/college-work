#include <iostream>
#include "SortedType.h"
using namespace std;

SortedType::SortedType()
{
	length = 0;
	currentPos = -1;
}

void SortedType::MakeEmpty()
{
	length = 0;
}

bool SortedType::IsFull()
{
	return(length == MAX_ITEMS);
}

int SortedType::LengthIs()
{
	return length;
}

void SortedType::InsertItem(ItemType item)
{
	if( ! IsFull() )
	{
		bool moreTosearch;
		int location = 0;
		moreTosearch = (location < length);
		while(moreTosearch)
		{
			switch(item.ComparedTo(info[location]))
			{
			case EQUAL:
				cout<< "This number already exist" << endl;
				return;
			case LESS:
				moreTosearch = false;
				break;
			case GREATER:
				location ++;
				moreTosearch = (location < length);
			}
		}
		for(int index = length;index>location;index--)
			info[index] = info[index - 1];
		info[location] = item;
		length ++;
	}
	else
		cout<< "Sry the List is full !! " << endl;
}

void SortedType::DeleteItem(ItemType item)
{
	int location = 0;
	while(item.ComparedTo(info[location]) != EQUAL)
		location ++;
	for(int index = location + 1;index<length;index++)
		info[index - 1] = info[index];
	length --;
}

void SortedType::ResetList()
{
	currentPos = -1;
}

void SortedType::GetNextItem(ItemType &item)
{
	if(currentPos < MAX_ITEMS)
	{
		currentPos ++;
		item = info[currentPos];
	}
	else
	{
		cout<< "First item of the list is ..." << endl;
		item = info[currentPos];
	}
}

void SortedType::RetrieveItem(ItemType &item, bool &found)
{
	int midPoint;
	int first = 0;
	int last  = length - 1;
	bool moreTosearch = (first <= last);
	found = false;
	while(moreTosearch && !found)
	{
		midPoint = (first + last) / 2;
		switch(item.ComparedTo(info[midPoint]))
		{
		case LESS:
			last = midPoint - 1;
			moreTosearch = first <= last;
			break;

		case GREATER:
			first = midPoint + 1;
			moreTosearch = (first <= last);
			break;

		case EQUAL:
			found = true;
			item = info[midPoint];
		}
	}
}

////////////////////////////////////////////////////////////////////////////////////////////
// Application !!

//void CreateList(SortedType& list)
//{
//	ItemType item;
//	char MoreData = 'Y';
//	list.MakeEmpty();
//	while(MoreData == 'Y' || MoreData == 'y')
//	{
//		GetData_SortedType(item);
//		if(!list.IsFull())
//			list.InsertItem(item);
//		cout<< "\n" << "More data ? (y/n) : ";
//		cin >> MoreData;
//	}
//}
//
//void PrintList(SortedType list)
//{
//	int length;
//	ItemType item;
//	list.ResetList();
//	length = list.LengthIs();
//	for(int counter = 1;counter <= length;counter ++)
//	{
//		list.GetNextItem(item);
//		item.Print();
//	}
//	cout<< "\n";
//}
//
//void GetData_SortedType(ItemType& item)
//{
//	int data;
//	cin >> data;
//	item.Initialize(data);
//}