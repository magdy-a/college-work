//------------------------------------------------------------------------------
// SysUtils.cpp
//    
//   This file contains SysUtils. Use this class just like a namespace 
//   for now. This class cannot be instantiated; it exists only to provide 
//   useful functions for other classes. 
// 
//   Copyright (c) 2001 Paul Wendt [p-wendt@home.com]

#include "stdinc.h"
#include "SysUtils.h"
#include <sstream>
using namespace std;

CString SysUtils::ByteToStr(const __int64& n64ByteCount /* = 0 */, const int& nPrecision /* = 2 */)
{
   const int NUMFORMATTERS = 5;
   char szFormatters[NUMFORMATTERS][10] = {" bytes", " KB", " MB", " GB", " TB" };
   double dblBase = n64ByteCount;
   int nNumConversions = 0;

   while (dblBase > 1000)
	{
		dblBase /= 1024;
      nNumConversions++;
	}

   CString strUnits;
   if ((0 <= nNumConversions) && (nNumConversions <= NUMFORMATTERS))
   {
      strUnits = szFormatters[nNumConversions];
   }
   
   CString os;   
   os.Format("%f %s", dblBase, strUnits);   
   return os;   
}