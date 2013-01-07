#ifndef SortedType_Linked_h
#define SortedType_Linked_h

#include "NodeType.h"

class SortedType_Linked
{
private:
	NodeType* listData;
	NodeType* currentPos;
	int length;
public:
	SortedType_Linked();
	void MakeEmpty();
	int LengthIs();
	bool IsFull();
	void InsertItem(ItemType item);
	void DeleteItem(ItemType item);
	void GetNextItem(ItemType& item);
	void ResetList();
	void RetrieveItem(ItemType& item,bool& found);
};


#endif