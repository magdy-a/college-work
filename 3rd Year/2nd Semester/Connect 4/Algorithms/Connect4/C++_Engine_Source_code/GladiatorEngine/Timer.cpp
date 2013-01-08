/*
	File:			Timer.cc

	Function:		See header file

	Author(s):		Andrew Willmott

	Copyright:		(c) 1995-2000, Andrew Willmott

	Notes:			Any other useful timing calls?
*/

#include "stdafx.h"

#include "Timer.h"


time_t Timer::StartTimer()
{
    startTime = CurrentTime();
	lapTime = startTime;
	return startTime;
}

time_t Timer::GetTimer()
{
    return(CurrentTime() - startTime);
}

//Float Timer::DeltaTime()
//{     
//	Float oldLapTime = lapTime;
//	
//    lapTime = CurrentTime();
//	
//    return(lapTime - oldLapTime);
//}

time_t Timer::DeltaTime()
{     
    return (stopTime - startTime);
}


Void Timer::StopTimer()	/* Stops timer */
{
	stopTime = CurrentTime();
}

Void Timer::ContTimer()	/* Restarts timer */
{
	Float temp;

	temp = CurrentTime();
	temp -= stopTime;
	startTime += temp;
	lapTime += temp;
}

/* --- Unix Time ----------------------------------------------------- */

 




/* --- Ansi Time ------------------------------------------------------ */




/* --- Sgi Time ------------------------------------------------------ */




// --- Use rusage call ---------------------------------------------------------




// --- Windows uses CTime (MFC) ------------------------------------------------

#ifdef WIN32

time_t WallClockTimer::CurrentTime()
{
   CTime t = CTime::GetCurrentTime();
   return t.GetTime();
}

time_t ProgramTimer::CurrentTime()
{
   CTime t = CTime::GetCurrentTime();
   return t.GetTime();
}

#endif // ifdef WIN32