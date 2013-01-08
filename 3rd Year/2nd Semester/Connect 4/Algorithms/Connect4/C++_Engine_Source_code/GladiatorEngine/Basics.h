/*
	File:			Basics.h

	Function:		Basic definitions for all files. Contains type definitions,
					assertion and debugging facilities, and miscellaneous
					useful template functions.
					
	Author(s):		Andrew Willmott

	Copyright:		(c) 1995-2000, Andrew Willmott
	
	Notes:			This header is affected by the following defines:

					CL_CHECKING		- Include code for assertions,
									  range errors and warnings.
					CL_DEBUG		- Enables misc. debugging statements.
					CL_FLOAT		- Use floats for real numbers. (Doubles
									  are the default.)
					CL_NO_BOOL		- There is no bool type.
					CL_NO_TF		- true and false are not predefined.
*/

#ifndef __Basics__
#define __Basics__  



// --- Basic types -------------------------------------------------------------

typedef void			Void;
typedef float			Float;
typedef double			Double;

typedef __int32			Int;
typedef long			Long;

typedef signed int		SInt;
typedef signed long		SLong;
typedef signed short	SInt16;
typedef signed long		SInt32;

typedef unsigned int	UInt;
typedef unsigned long	ULong;
typedef unsigned short	UInt16;
typedef unsigned int	UInt32;
#ifdef CL_64_BIT
typedef signed long 	SInt64;
typedef unsigned long 	UInt64;
#endif

#ifndef CL_64_BIT
typedef signed long		SAddrInt;
typedef unsigned long	UAddrInt;
#else
#ifdef WIN32
typedef signed long		SAddrInt;
typedef unsigned long	UAddrInt;
#else
typedef signed long long	SAddrInt;
typedef unsigned long long	UAddrInt;
#endif
#endif
// Integral type that is the same size as a pointer.

typedef unsigned char	Byte;
//typedef BYTE	Byte;
typedef unsigned char	SByte;
typedef char			Char;

#ifndef CL_FLOAT
typedef Double			Real;
#else
typedef Float			Real;
#endif

#define SELF (*this)	// A syntactic convenience.	


// --- Boolean type ------------------------------------------------------------

// X11 #defines 'Bool' -- typical.

#ifdef Bool	
#undef Bool
#endif

#ifndef CL_NO_BOOL
// if the compiler implements the bool type...
typedef bool Bool;
#else
// if not, make up our own.
class Bool 
{
public:
	
	Bool() : val(0) {};
	Bool(Int b) : val(b) {};

	operator Int() { return val; };
	
private:
	Int val;
};
#ifdef CL_NO_TF
enum {false, true};
#endif
#endif




#endif
