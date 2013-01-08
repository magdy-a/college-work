/*
	File:			Timer.h

	Function:		Provides routines for timing under several different 
					architectures. You must define one of the following:
				
						UNIX_TIME		Use the time() and times() calls
						ANSI_TIME		Use the ansi clock() routine
						SGI_TIME		Use the SGI multimedia timing 
										routines (nano-second accuracy.)
						RUSAGE_TIME 	Use getrusage() system call 
		
	Author(s):		Andrew Willmott

	Copyright:		(c) 1995-2000, Andrew Willmott
 */

#ifndef __Timer__
#define __Timer__

#include "Basics.h"

// Account for the morons who coded X11
#ifdef CurrentTime
#undef CurrentTime
#endif

class Timer
// all times in seconds. 
{
public:
	Timer() : startTime(0), stopTime(0), lapTime(0)
	{};

	time_t	StartTimer();	// Starts timer
	Void	StopTimer();	// Stops timer
	Void	ContTimer();	// Continue timer
	time_t GetTimer();		// Returns time since timer was started

	time_t DeltaTime();	// returns time delta since DeltaTime
							// or StartTimer was last called

	virtual time_t	CurrentTime() = 0;

protected:
	time_t	startTime;
	time_t	stopTime;
	time_t	lapTime;
};

class ProgramTimer : public Timer
// measures elapsed program time.
{
public:
	ProgramTimer() : Timer(), addSystem(false)
	{};
	
	time_t CurrentTime();

	Bool	addSystem;
};

class WallClockTimer : public Timer
// measures wall clock time.
{
public:
	time_t CurrentTime();
};

#endif
