#ifndef SortedType_h
#define SortedType_h

#include "ItemType.h"

class SortedType
{

private:

	int length;
	int currentPos;
	ItemType info[MAX_ITEMS];
	
public:

	SortedType();
	void MakeEmpty();
	bool IsFull();
	int LengthIs();
	void RetrieveItem(ItemType& item,bool& found);
	void InsertItem(ItemType item);
	void DeleteItem(ItemType item);
	void GetNextItem(ItemType& item);
	void ResetList();

};

// Application !!

//void CreateList(SortedType& list);
//void PrintList(SortedType list);
//void GetData_SortedType(ItemType& item);


#endif