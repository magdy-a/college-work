/*
    File:       PtrArray.h

    Function:	

    Author:     Andrew Willmott

    Copyright:  (c) 1998-2000, Andrew Willmott
*/

#ifndef __PtrArray__
#define __PtrArray__

//#include "cl/src/Array.h"

typedef Array<Void*> VoidPtrArray;

template<class T> class PtrArray : public VoidPtrArray
{
public:
	inline T*&		operator [] (Int i)
					{ return((T*&) itemArray[i]); };		// indexing operator
	inline T*		operator [] (Int i) const
					{ return((T*) itemArray[i]); }; 		// indexing operator

	T*				&Item(Int i)
					 { return((T*&) itemArray[i]); };
	T*				Item(Int i) const
					{ return((T*) itemArray[i]); };
	T*				&Last()
					{ return((T*&) VoidPtrArray::Last()); };

	Void			Append(T* t)
					{ VoidPtrArray::Append((Void*) t); };

	inline Void		FreeAll();
};

template<class T> inline Void PtrArray<T>::FreeAll()
{
	UInt32		i;

   for (i = 0; i < items; i++)
   {   
	  if ( itemArray[i] != NULL )
      {      
        T* elem = (T*) itemArray[i];
        delete ((T*) itemArray[i]);       
      }
   }
}

#endif
