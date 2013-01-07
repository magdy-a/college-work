#include <iostream>
#include "ItemType.h"
using namespace std;




ItemType::ItemType()
{
	Value = 0;
}
RelationType ItemType::ComparedTo(ItemType OtherItem)
{
	if(Value > OtherItem.Value)
		return GREATER;
	else if(Value < OtherItem.Value)
		return LESS;
	else
		return EQUAL;
}
void ItemType::Print()
{
	cout<< "\n" << Value << "\n";
}
void ItemType::Initialize(int number)
{
	Value = number;
}
int ItemType::GetValue()
{
	return Value;
}
















































/*
ItemType::ItemType()
{
	Value = 0;
}
RelationType ItemType::ComparedTo(ItemType OtherItem) 
{
	if (Value < OtherItem.Value)
		return LESS;
	else if (Value > OtherItem.Value)
		return GREATER;
	else return EQUAL;
}
void ItemType::Print()
{
	cout<< endl << Value << endl;
}
void ItemType::Initialize(int number)
{
	Value = number;
}
*/