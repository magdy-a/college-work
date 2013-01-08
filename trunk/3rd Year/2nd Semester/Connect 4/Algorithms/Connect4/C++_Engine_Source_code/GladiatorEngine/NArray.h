/*
	File:			NArray.h

	Function:		Defines an array type that manages its own storage space,
					and can be used as a stack or a list.
					This is the sister of the array class -- it, so
					it doesn't have to be instantiated for every new
					data type, at the cost of an extra word of storage.

					Array<> should be used just for standard data types
					(char, int, float, double) and NArray for everything else.
					
					
	Author(s):		Andrew Willmott

	Copyright:		(c) 1995-2000, Andrew Willmott
 */

#ifndef __NArray__
#define __NArray__

#include <iostream>
#include "Basics.h"
#include <stdio.h>

const Int kFirstNAllocation = 16; 	///< Default number of items to initially 
								 	///< allocate to the array


class NBaseArray
{
public:
	inline			NBaseArray(UInt32 eltSize);
					NBaseArray(UInt32 eltSize, Int size, Int alloc = kFirstNAllocation);		
					NBaseArray(const NBaseArray &array);
				   ~NBaseArray();
	
//	NBaseArray operators
	
	virtual Int		NumItems() const;	///< Number of items in the array
	
	NBaseArray		&operator = (const NBaseArray &array);	///< Assignment!
	
//	Useful for stack implementations

	inline Void		Pop();						///< Delete top of stack
	
// List Operations

	Void			Clear();					///< Delete all items

	Void			PreAllocate(UInt32 numItems);///< Preallocate space for array
	Void			SetSize(Int newSize);		///< Set array size directly.
	Void			Add(Int n = 1);				///< Add n items to the array
	Void			Shrink(Int n = 1);			///< shrink the array by n items
	Void 			Insert(Int i, Int n = 1);	///< Insert n items at i
	Void			Delete(Int i, Int n = 1);	///< Delete n items at i
	Void			ShrinkWrap();				/**< Ensure allocated space =
													 space being used */

	Void			Append(const NBaseArray &a);///< Append array to array
	Void			SwapWith(NBaseArray &a);	///< swaps this array with a
	Void			Replace(NBaseArray &a);		/**< Replace this array with a
													 & clear a. */
	
	Void			MemMap(const Char* filename);
	Void 			WriteFile(const Char *filename);
	Void 			ReadFile(const Char *filename);

	Int 			FWrite(FILE *file);
	Int 			FRead(FILE *file);

	Void			Attach(Void *ptr, Int numItems, Bool shared = false);
	
	UInt32			EltSize()
					{ return(eltSize); };

protected:
	Byte           *item;		///< pointer to array
	UInt32 			items;		///< items in the array
	UInt32			allocated;	///< number of items we have space allocated for. 
	UInt32			eltSize;

	Void 			Grow();
};	



#define TMPLArray	template<class T>
#define TNArray		NArray<T>

TMPLArray class NArray : public NBaseArray
/** Generic array class.

	WARNING: Constructors are not called automatically for new array members. Use
	the ClearTo() method if you need to initialise all members of the array after,
	say, a SetSize() call.
*/
{
public:
					NArray() : NBaseArray(sizeof(T)) {};
					NArray(Int size, Int alloc = kFirstNAllocation) :
						NBaseArray(sizeof(T), size, alloc) {};

	inline T		&operator [] (Int i);		///< Indexing operator
	inline const T	&operator [] (Int i) const; ///< Indexing operator

	inline Void		Append(const T &t);			///< Append single item to array
	inline T		&Last();					///< Return last item in array

	inline T		&Top();						///< Return top of stack
	inline Void		Push(const T &t);			///< Push item onto stack  

	const T			&Item(Int i) const
					{ return(SELF[i]); };
	T				&Item(Int i)
					{ return(SELF[i]); };

	Void			ClearTo(const T &t);		///< Clear the array using t
	Void			Append(const TNArray &a)	///< Append array to array
					{ ((NBaseArray*) this)->Append(a); };
					// C++: can't live with it, pass the beer nuts.

// Low level access

	inline T		*Ref() const;				///< Return pointer to array
	inline T		*Detach();					/**< As above, but the array 
													 no longer owns the data. */
};

//TMPLArray ostream &operator << (ostream &s, TNArray &array);
//TMPLArray istream &operator >> (istream &s, TNArray &array);


// --- Inlines ----------------------------------------------------------------


inline NBaseArray::NBaseArray(UInt32 es) 
	: items(0), item(0), allocated(0), eltSize(es)
{
}


inline Void NBaseArray::Pop()
{	
	items--;
}

inline Void NBaseArray::Clear()
{	
	items = 0;
	allocated = 0;
	delete[] item;
	item = 0;
}

TMPLArray inline T &TNArray::operator [] (Int i)
{
	CheckRange(i, 0, items, "(NArray::[]) index out of range");

	return(*((T*) (item + i * eltSize)));
}

TMPLArray inline const T &TNArray::operator [] (Int i) const
{
	CheckRange(i, 0, items, "(NArray::[]) index out of range");

	return(*((T*) (item + i * eltSize)));
}

TMPLArray inline T &TNArray::Top()
{
	return(*(((T*) item) + (items - 1)));
}

TMPLArray inline T &TNArray::Last()
{
	return(*(((T*) item) + (items - 1)));
}

TMPLArray inline Void TNArray::Push(const T &t)
{
	if (items >= allocated)
		Grow();
	
	*(((T*) item) + items++) = t;
}

TMPLArray inline Void TNArray::ClearTo(const T &t)
{
	for (Int i = 0; i < items; i++)
		*(((T*) item) + i) = t;
}

TMPLArray inline Void TNArray::Append(const T &t)
{
	if (items >= allocated)
		Grow();
	
	*(((T*) item) + items++) = t;
}

TMPLArray inline T *TNArray::Ref() const
{
	return((T*) item);
}

TMPLArray inline T *TNArray::Detach()
{
	T* result = (T*) item;

	items = 0;
	allocated = 0;
	item = 0;

	return(result);
}

// --- I/O --------------------------------------------------------------------

// XXX convert these to generic NBaseArray routine with the stream
// function handed in






#endif
