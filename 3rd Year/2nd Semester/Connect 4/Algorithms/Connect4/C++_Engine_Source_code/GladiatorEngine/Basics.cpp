/*
	File:			Basics.cc

	Function:		Implements Basics.h

	Author(s):		Andrew Willmott

	Copyright:		(c) 1995-2000, Andrew Willmott

	Notes:			

*/
#include "stdafx.h"
#include "Basics.h"
#include <stdio.h>
#include <stdlib.h>
#include <iostream>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif
// --- Error functions for range and routine checking -------------------------


#ifndef RELUX

static Void DebuggerBreak()
{
	abort();
}

Void _Assert(Int condition, const Char *errorMessage, const Char *file, Int line)
{
	if (!condition)
	{
		Char reply;
		
		cerr << "\n*** Assert failed (line " << line << " in " << 
			file << "): " << errorMessage << endl;
		cerr << "    Continue? [y/n] ";
		cin >> reply;
		
		if (reply != 'y')
		{
			DebuggerBreak();
			exit(1);
		}
	}
}

Void _Expect(Int condition, const Char *warningMessage, const Char *file, Int line)
{
	if (!condition)
		cerr << "\n*** Warning (line " << line << " in " << file << "): " <<
			warningMessage << endl;
}

Void _CheckRange(Int i, Int lowerBound, Int upperBound, 
				 const Char *rangeMessage, const Char *file, Int line)
{
	if (i < lowerBound || i >= upperBound)
	{
		Char reply;
		
		cerr << "\n*** Range Error (line " << line << " in " << file <<
			"): " << rangeMessage << endl;	
		cerr << "    Continue? [y/n] ";
		cin >> reply;
		
		if (reply != 'y')
		{
			DebuggerBreak();
			exit(1);
		}
	}
}

#else // RELUX

Void _Assert(Int condition, const Char *errorMessage, const Char *file, Int line)
{
   if (!condition)
   {
      TRACE("\n*** Assert failed (line %d in %s): %s\n",
            line, file, errorMessage); 
      ASSERT(false);
   }
}

Void _Expect(Int condition, const Char *warningMessage, const Char *file, Int line)
{
   if (!condition)
      TRACE("\n*** Warning (line %d in %s): %s", file, line, warningMessage);
}

Void _CheckRange(Int i, Int lowerBound, Int upperBound, 
                 const Char *rangeMessage, const Char *file, Int line)
{
   if (i < lowerBound || i >= upperBound)
   {
      TRACE("\n*** Range Error (line %d in %s): %s", line, file, rangeMessage);  
      ASSERT(false);
   }
}

#endif // RELUX
