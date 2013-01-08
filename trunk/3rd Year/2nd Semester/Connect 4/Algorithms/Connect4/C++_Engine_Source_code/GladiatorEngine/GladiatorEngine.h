/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/


// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the GLADIATORENGINE_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// GLADIATORENGINE_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef GLADIATORENGINE_EXPORTS
#define GLADIATORENGINE_API __declspec(dllexport)
#else
#define GLADIATORENGINE_API __declspec(dllimport)
#endif

class StrategyGameAgent;
class Gameboard;
class CalculationModel;
class TranspositionTable;

#include "GameStatus.h"
#include "Position.h"

// This class is exported from the GladiatorEngine.dll
class GLADIATORENGINE_API GladiatorEngine 
{
private:
	// proxy objects for JNI GameEngineAdapter
	GameStatus status;
	Position pos;
	StrategyGameAgent* agent;
	Gameboard** gameboard;	
	ThreadData** threadData;
	CalculationModel* model;
	TranspositionTable* hashtable;
	static bool	init;
public:
	static const int MAX_THREADS;
	bool isInitialized() { return init; }
	GladiatorEngine();
	~GladiatorEngine();
	void setPos( int linearPos, int xCoordinate, int yCoordinate );	
	void setStatus( int score, int count, int sizeXOfBoard, int sizeYOfBoard, int hashElems,
					int firstPlayer );
	void fillSearchResults( JNIEnv* env, jclass clsStatus, jobject status );
	void getVersion( JNIEnv* env, jclass clsVersion, jobject objVersion );
	void setSide( int player );
	void setTimeOut( int timeOut );
	void doMove( int player );
	void undoMove();
	int  getBoardscore();
	long getHashKey();
	long getRevKey();
	int  getCount();
	double getHashtableMemoryDemand();
	int  freePositions();
	const Position* lookupBookMove( const wchar_t* path );
	void iterativeDeepening() { agent->iterativeDeepening(); }
	void initializeBoard();
	void updateStatus( int xCoord, int yCoord, int player, int timeout );
	void initializeLists();
	Position** checkFinalWin(Byte& length);
	static int omp_get_thread_num();
};

extern GLADIATORENGINE_API int nGladiatorEngine;
extern GladiatorEngine engine;

GLADIATORENGINE_API int fnGladiatorEngine(void);
