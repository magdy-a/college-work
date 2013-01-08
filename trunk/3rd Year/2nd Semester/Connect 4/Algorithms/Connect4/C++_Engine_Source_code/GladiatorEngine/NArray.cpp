/*
	File:			NArray.cc

	Function:		Provides methods for NBaseArray

	Author(s):		Andrew Willmott

	Copyright:		(c) 1995-2000, Andrew Willmott

	Notes:			

*/

/*!
	\class NBaseArray

	Note: We grow the array in size exponentially. That is, every time we
	need to increase the size of the array, we double its size rather than
	increasing it by a fixed amount. For appending n items to an empty list,
	this gives us O(n) copies, as opposed to the O(n^2) copies required if
	we increment by a fixed size each time. 
	
	It would be useful to have an array data structure that utilises a tree of
	fixed-size arrays, thus trading off access time (const vs. o(logbn)) and
	poor insert/delete performance against eliminating copies.
*/

#include "stdafx.h"

#include "NArray.h"
#include <string.h>
#include <ctype.h>


Int NBaseArray::NumItems() const
{
	return(items);
}


NBaseArray::NBaseArray(UInt32 es, Int size, Int alloc) : items(size),
					allocated(alloc), eltSize(es)
{
	Assert(size > 0, "(NBaseArray) Initial array size must be positive!");

	if (allocated < size)
		allocated = size;
	
	item = new Byte[eltSize * allocated];
}

NBaseArray::NBaseArray(const NBaseArray &array) : items(array.items), 
	allocated(array.allocated), eltSize(array.eltSize)
{
	// XXX should we be sizing to allocated or just items?
	if (!allocated)
		allocated = items;
	item = new Byte[eltSize * allocated];
	
	memcpy(item, array.item, items * eltSize);
}

NBaseArray::~NBaseArray()
{
	if (allocated) delete[] item;
}

NBaseArray &NBaseArray::operator = (const NBaseArray &array)
{

	if (allocated < array.items)
	{
		if (allocated) delete[] item;
		allocated = array.items;	
		item = new Byte[eltSize * allocated];	
	}
			
	items = array.items;
	memcpy(item, array.item, items * eltSize);
	
	return(SELF);
}

Void NBaseArray::PreAllocate(UInt32 newSize)
{
	UInt32	oldAllocated = allocated;
	Byte	*newArray;
	
	if (newSize > allocated)
	{
		if (allocated == 0)
			allocated = kFirstNAllocation;
		else
			allocated *= 2;	
		
		while (newSize > allocated)
			allocated *= 2;	
		
		newArray = new Byte[eltSize * allocated];
	
		memcpy(newArray, item, items * eltSize);
		
		if (oldAllocated) delete[] item;
		item = newArray;
	}
}

Void NBaseArray::SetSize(Int newSize)
{
	PreAllocate(newSize);
	items = newSize;
}

Void NBaseArray::Add(Int n)
{
	SetSize(items + n);
}

Void NBaseArray::Shrink(Int n)
//	take away n items.
{
	items -= n;
}

Void NBaseArray::Insert(Int i, Int n)
//	Make space at position i for n items.
{
	Assert(i >= 0 && i <= items, "(NBaseArray:Insert) Illegal index");
	Assert(n > 0, "(NBaseArray:Insert) Illegal insert amount");

	Byte *ip = item + (eltSize * i);
	
	Add(n);
	memmove(ip + eltSize * n, ip, (items - i - n) * eltSize);
}

Void NBaseArray::Delete(Int i, Int n)
//	Delete n items at position i.
{
	Assert(i >= 0 && i <= items, "(NBaseArray:Delete) Illegal index");
	Assert(n > 0, "(NBaseArray:Delete) Illegal insert amount");

	Byte *ip = item + (eltSize * i);

	items -= n;
	memmove(ip, ip + eltSize * n, (items - i) * eltSize);
}

Void NBaseArray::ShrinkWrap()
// Shrink allocated space to be only the current size of array
// There is no realloc version of new in C++, so this involves another copy.
{
	Int	oldAllocated = allocated;
	Byte	*newArray;
	
	allocated = items;
	
	newArray = new Byte[eltSize * allocated];

	memcpy(newArray, item, items * eltSize);
	
	if (oldAllocated) delete[] item;
	item = newArray;
}

Void NBaseArray::Grow()
//	Allocate more space for the array. Used internally prior to an items++.
{
	UInt32 oldAllocated = allocated;
	Byte	*newArray;
	
	if (allocated == 0)
		allocated = kFirstNAllocation;
	else
		allocated *= 2;	
	
	newArray = new Byte[eltSize * allocated];

	memcpy(newArray, item, items * eltSize);
	
	if (oldAllocated) delete[] item;
	item = newArray;
}

Void NBaseArray::Append(const NBaseArray &a)
{
	Int		i, j, newSize;
	
	newSize = items + a.items;
	PreAllocate(newSize);

	for (i = items, j = 0; j < a.items; i++, j++)
		item[i] = a.item[j];
	memcpy(item + (items * eltSize), a.item, a.items * eltSize);

	items = newSize;
}

Void NBaseArray::SwapWith(NBaseArray &a)
{
//	Int a1, b1;
//	
//	Swap(a1, b1);
	
	Swap(items, a.items);
	Swap(allocated, a.allocated);
	Swap(item, a.item);
}

Void NBaseArray::Replace(NBaseArray &a)
{
	if (allocated) delete[] item;
	item = a.item;
	items = a.items;
	allocated = a.allocated;

	a.item = 0;
	a.items = 0;
	a.allocated = 0;
}

#include <stdio.h>

Void NBaseArray::WriteFile(const Char *filename)
{
	FILE	*file;

	file = fopen(filename, "wb");
	if (file)
	{
		fwrite(item, eltSize, items, file);
		fclose(file);
	}
}

Void NBaseArray::ReadFile(const Char *filename)
{
	FILE	*file = fopen(filename, "rb");

	if (file)
	{
		Int		fsize;

		fseek(file, 0, SEEK_END);
		fsize = ftell(file);
		rewind(file);
		items = fsize / eltSize;
		Assert(items * eltSize == fsize, "(NBaseArray::ReadFile) bad file size");
		item = new Byte[eltSize * items];
		allocated = items;
		fread(item, eltSize, items, file);

		fclose(file);
	}
}

Int NBaseArray::FWrite(FILE *file)
{
	fwrite(&items, sizeof(UInt32), 1, file);
	fwrite(item, eltSize, items, file);

	return(ferror(file));
}

Int NBaseArray::FRead(FILE *file)
{
	if (fread(&items, sizeof(UInt32), 1, file) != 1)
		return(-1);
	item = new Byte[eltSize * items];
	allocated = items;

	return(fread(item, eltSize, items, file) != items);
}

Void NBaseArray::Attach(Void *ptr, Int numItems, Bool shared)
{
	Clear();

	item = (Byte*) ptr;
	items = numItems;

	if (!shared)
		allocated = numItems;
}
