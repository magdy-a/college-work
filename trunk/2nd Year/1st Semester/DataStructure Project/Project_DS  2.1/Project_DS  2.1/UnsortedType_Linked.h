#ifndef UnsortedType_Linked_h
#define UnsortedType_Linked_h

#include "NodeType.h"

class UnsortedType_Linked
{
private:
	NodeType* listData;
	int length;
	NodeType* currentPos;
public:
	UnsortedType_Linked();
	void MakeEmpty();
	int LengthIs();
	bool IsFull();
	void InsertItem(ItemType item);
	void DeleteItem(ItemType item);
	void GetNextItem(ItemType& item);
	void ResetList();
	void RetrieveItem(ItemType& item,bool& found);
	void PrintList();
};


#endif