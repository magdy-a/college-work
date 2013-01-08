/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/


/*
	File:			Array.cc

	Function:		Template definitions for Array.h

	Author(s):		Andrew Willmott

	Copyright:		(c) 1995-2000, Andrew Willmott

	Notes:			

*/

#include "stdafx.h"

#define __Array
#include "Array.h"
#include <ctype.h>

//#ifdef _DEBUG
//#define new DEBUG_NEW
//#undef THIS_FILE
//static char THIS_FILE[] = __FILE__;
//#endif


/*! \class Array
	
	Note: We grow the array in size exponentially. That is, every time we
	need to increase the size of the array, we double its size rather than
	increasing it by a fixed amount. For appending n items to an empty list,
	this gives us O(n) copies, as opposed to the O(n^2) copies required if
	we increment by a fixed size each time. 
	
	It would be useful to have an array data structure that utilises a tree of
	fixed-size arrays, thus trading off access time (const vs. o(logbn))
	against eliminating copies. 
*/


TMPLArray TArray::Array(UInt32 size, Int alloc) : items(size),
					allocated(alloc)
{
	Assert(size > 0, "(Array) Initial array size must be positive!");
	if (allocated < size)
		allocated = size;
	
	itemArray = new T[allocated];
}

TMPLArray TArray::Array(const TArray &array) : items(array.items), 
	allocated(array.allocated)
{
	UInt32 i;
	
	if (!allocated)
		allocated = items;
	itemArray = new T[allocated];
	
	for (i = 0; i < array.items; i++)
		itemArray[i] = array.itemArray[i];
}

TMPLArray TArray::~Array()
{	   
   /*if (allocated)*/   
   delete[] (itemArray);//delete[] (T*)
   //delete itemArray;
}

TMPLArray TArray &TArray::operator = (const TArray &array)
{
	Int i;

	if (allocated < array.items)
	{
		if (allocated) delete[] itemArray;
		allocated = array.items;	
		itemArray = new T[allocated];	
	}
			
	for (i = 0; i < array.items; i++)
		itemArray[i] = array.itemArray[i];

	items = array.items;
	
	return(SELF);
}


TMPLArray Void TArray::PreAllocate(UInt32 newSize)
{
	UInt32	i, oldAllocated = allocated;
	T		*newArray;
	
	if (newSize > allocated)
	{
		if (allocated == 0)
			allocated = kFirstAllocation;
		else
			allocated *= 2;	
		
		while (newSize > allocated)
			allocated *= 2;	
		
		newArray = new T[allocated];		
	
		for (i = 0; i < items; i++)
			newArray[i] = itemArray[i];	
		
		if (oldAllocated) delete[] itemArray;
		itemArray = newArray;
	}
}

TMPLArray Void TArray::SetSize(Int newSize)
{
	PreAllocate(newSize);
	items = newSize;
}

TMPLArray Void TArray::Add(Int n)
{
	SetSize(items + n);
}

TMPLArray Void TArray::Shrink(Int n)
//	take away n items.
{
	items -= n;
}

TMPLArray Void TArray::Insert(Int i, Int n)
//	Make space at position i for n items.
{
	Assert(i >= 0 && i <= items, "(Array:Insert) Illegal index");
	Assert(n > 0, "(Array:Insert) Illegal insert amount");

	Int j;
	
	Add(n);
	
	for (j = items - 1; j >= i + n; j--)
		itemArray[j] = (itemArray - n)[j];
}

TMPLArray Void TArray::Delete(Int i, Int n)
//	Delete n items at position i.
{
	Assert(i >= 0 && i <= items, "(Array:Insert) Illegal index");
	Assert(n > 0, "(Array:Delete) Illegal insert amount");

	Int j;
	
	items -= n;
		
	for (j = i; j < items; j++)
		itemArray[j] = (itemArray + n)[j];
}

TMPLArray Void TArray::ShrinkWrap()
//	Shrink allocated space to be only the current size of array
// There is no realloc version of new in C++, so this involves another copy.
{
	Int	i, oldAllocated = allocated;
	T	*newArray;
	
	allocated = items;	
	
	newArray = new T[allocated];

	for (i = 0; i < items; i++)
		newArray[i] = item[i];	
	
	if (oldAllocated) delete[] item;
	item = newArray;
}

TMPLArray Void TArray::Grow()
//	Allocate more space for the array. Used internally prior to an items++.
{
	UInt32	i, oldAllocated = allocated;
	T		*newArray;
	
	if (allocated == 0)
		allocated = kFirstAllocation;
	else
		allocated *= 2;	
	
	newArray = new T[allocated];	

	for (i = 0; i < items; i++)
		newArray[i] = itemArray[i];	
	
	if (oldAllocated) delete[] itemArray;
	itemArray = newArray;
}






TMPLArray Void TArray::Append(const TArray &a)
{
	Int		i, j, newSize;
	
	newSize = items + a.items;
	PreAllocate(newSize);

	for (i = items, j = 0; j < a.items; i++, j++)
		itemArray[i] = a.itemArray[j];

	items = newSize;
}

TMPLArray Void TArray::SwapWith(TArray &a)
{
	Int a1, b1;
	
	Swap(a1, b1);
	
	Swap(items, a.items);
	Swap(allocated, a.allocated);
	Swap(itemArray, a.itemArray);
}

TMPLArray Void TArray::Replace(TArray &a)
{
	if (allocated) delete[] itemArray;
	itemArray = a.itemArray;
	items = a.items;
	allocated = a.allocated;

	a.itemArray = 0;
	a.items = 0;
	a.allocated = 0;
}



TMPLArray Void TArray::Attach(T *itemsPtr, Int numItems, Bool shared)
{
	Clear();

	itemArray = itemsPtr;
	items = numItems;

	if (!shared)
		allocated = numItems;
}
