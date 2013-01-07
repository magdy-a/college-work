#ifndef ItemType_h
#define ItemType_h

enum RelationType {LESS,GREATER,EQUAL};

const int MAX_ITEMS = 50;

class ItemType
{

private:

	int Value;

public:

	ItemType();
	RelationType ComparedTo(ItemType OtherItem);
	void Print();
	void Initialize(int number);
	int GetValue();
};

#endif