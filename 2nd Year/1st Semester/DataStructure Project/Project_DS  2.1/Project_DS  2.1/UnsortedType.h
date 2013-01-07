#ifndef UnsortedType_h
#define UnsortedType_h

#include "ItemType.h"

class UnsortedType
{

private:

	int length;
	int currentPos;
	ItemType info[MAX_ITEMS];

public:

	UnsortedType();
	void MakeEmpty();
	bool IsFull();
	int  LengthIs();
	bool RetrieveItem(ItemType item);
	void InsertItem(ItemType item);
	void DeleteItem(ItemType item);
	void GetNextItem(ItemType& item);
	void ResetList();

};

// Application !!

//void CreateList(UnsortedType& list);
//void PrintList(UnsortedType list);
//void GetData_UnsortedType(ItemType& item);


#endif