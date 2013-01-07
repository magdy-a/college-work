#ifndef NodeType_h
#define NodeType_h

#include "ItemType.h"

struct NodeType
{
	ItemType info;
	NodeType* next;
};

#endif
