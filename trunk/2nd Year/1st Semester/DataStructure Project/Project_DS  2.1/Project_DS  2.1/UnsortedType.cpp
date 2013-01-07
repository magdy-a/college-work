#include <iostream>
#include "UnsortedType.h"
using namespace std;


UnsortedType::UnsortedType()
{
	length = 0;
	currentPos = -1;
}

void UnsortedType::MakeEmpty()
{
	length = 0;
}

bool UnsortedType::IsFull() 
{
	return (length == MAX_ITEMS);
}

int UnsortedType::LengthIs() 
{
	return length;
}

bool UnsortedType::RetrieveItem(ItemType item)
{
	int i;
	for(i=0;i<length;i++)
	{
		if(info[i].ComparedTo(item) == EQUAL)
			return true;
	}
	return false;


	/*bool moreTosearch;
	int location = 0;
	found = false;
	moreTosearch = (location<length);
	while(moreTosearch && !found)
	{
		switch(item.ComparedTo(info[location]))
		{
		case LESS:
		case GREATER:
			location ++;
			moreTosearch = (location<length);
			break; 
		case EQUAL:
			found = true;
			item = info[location];
		}
	}*/
}

void UnsortedType::InsertItem(ItemType item)
{
	info[length] = item;
	length ++;
	
}

void UnsortedType::DeleteItem(ItemType item)
{
	int location = 0;
	while(item.ComparedTo(info[location]) != EQUAL && location<MAX_ITEMS)
	{
		location ++;
	}
	if(item.ComparedTo(info[location]) == EQUAL)
	{
		info[location] = info[length-1];
		length--;
	}
}

void UnsortedType::ResetList()
{
	currentPos = -1;
}

void UnsortedType::GetNextItem(ItemType& item)
{
	if(currentPos < MAX_ITEMS)
		currentPos ++;
	else
		currentPos = 0;
	item = info[currentPos];
}

//////////////////////////////////////////////////////////////////////////////////////////////////
// Application !!

//void CreateList(UnsortedType& list)
//{
//	ItemType item;
//	char MoreData = 'Y';
//	list.MakeEmpty();
//	while(MoreData == 'Y' || MoreData == 'y')
//	{
//		GetData_UnsortedType(item);
//		if(!list.IsFull())
//			list.InsertItem(item);
//		cout<< endl << "MoreData ? (y/n) : ";
//		cin >> MoreData;
//	}
//}
//
//void PrintList(UnsortedType list)
//{
//	int length;
//	ItemType item;
//	list.ResetList();
//	length = list.LengthIs();
//	for(int counter = 1; counter <= length; counter ++)
//	{
//		list.GetNextItem(item);
//		item.Print();
//	}
//	cout<< endl;
//}
//
//void GetData_UnsortedType(ItemType& item)
//{
//	int data;
//	cin >> data;
//	item.Initialize(data);
//}