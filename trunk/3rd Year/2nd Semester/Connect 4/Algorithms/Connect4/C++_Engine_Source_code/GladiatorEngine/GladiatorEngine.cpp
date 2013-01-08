// GladiatorEngine.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include <jni.h>
#include "Gameboard.h"
#include "HashElement.h"
#include "SystemConstants.h"
#include "Array.h"
#include "PtrArray.h"
#include <new>
#include "TranspositionTable.h"
#include "StrategyGameAgent.h"
#include "GladiatorEngine.h"
#include "Threats.h"
#include "ConnectFourGameboard.h"
#include "CalculationModel.h"
#include "ThreadData.h"
#include "Version.h"
#include <omp.h>


bool GladiatorEngine::init = false;

#if defined _OPENMP_MULTICORE
const int GladiatorEngine::MAX_THREADS = (omp_get_max_threads() > 6 ? 6 : omp_get_max_threads());
#else
const int GladiatorEngine::MAX_THREADS = 1;
#endif

// The one and only application object
GladiatorEngine engine;

//////////////////////////////////////////////////////////////////////////////////////////

GladiatorEngine::GladiatorEngine()
{		
	_CrtSetDbgFlag( _CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF );

	threadData	= new ThreadData*[GladiatorEngine::MAX_THREADS];	
	gameboard	= new Gameboard*[MAX_THREADS];
	model		= new CalculationModel( SystemConstants::WINDOW, 
									    SystemConstants::INITIAL_WINDOW, 
									    SystemConstants::MAX_DEPTH, 
									    SystemConstants::SMALL_HASH, 
									    SystemConstants::HASH_DEPTH_LEFT,
									    SystemConstants::ITER_DEEP_MARGIN );

	for ( int i = 0; i < MAX_THREADS; i++ )
	{
		threadData[i] = new ThreadData(model->getMaxDepth());	
		gameboard[i]  = new Gameboard( threadData[i] );	
	}
	
	hashtable = new TranspositionTable();
	agent	  = new StrategyGameAgent( gameboard, model, hashtable, threadData );
}

//////////////////////////////////////////////////////////////////////////////////////////

GladiatorEngine::~GladiatorEngine()
{	
	for ( int i = 0; i < MAX_THREADS; i++ )
	{
		if ( init )
		{
			delete threadData[i];
		}
		delete gameboard[i];	
	}
	delete[] gameboard;		
	delete[] threadData;
	delete model;	
	delete agent;
	delete hashtable;
}

//////////////////////////////////////////////////////////////////////////////////////////


int GladiatorEngine::omp_get_thread_num()
{
#if defined _OPENMP_MULTICORE
	return ::omp_get_thread_num();
#else
	return 0;
#endif
}

//////////////////////////////////////////////////////////////////////////////////////////


void GladiatorEngine::setPos( int linearPos, int xCoordinate, int yCoordinate )
{
	pos.linearPos = linearPos;
	pos.xCoordinate = xCoordinate;
	pos.yCoordinate = yCoordinate;
}

//////////////////////////////////////////////////////////////////////////////////////////


void GladiatorEngine::setStatus( int score, int count, int sizeXOfBoard, int sizeYOfBoard, int hashElems,
								 int firstPlayer )
{
	status.score = score;
	status.count = count;
	status.sizeXOfBoard = sizeXOfBoard;
	status.sizeYOfBoard = sizeYOfBoard;
	status.hashelements = hashElems;
	status.firstPlayer	= firstPlayer;
}

//////////////////////////////////////////////////////////////////////////////////////////


Position** GladiatorEngine::checkFinalWin( Byte& length )
{
	return gameboard[MASTER_THREAD]->checkFinalWin(&pos, length);
}

//////////////////////////////////////////////////////////////////////////////////////////

const Position* GladiatorEngine::lookupBookMove( const wchar_t* path )
{
	return gameboard[MASTER_THREAD]->lookupBookMove(path);
}

//////////////////////////////////////////////////////////////////////////////////////////

void GladiatorEngine::initializeBoard()
{
	for ( int i = 0; i < MAX_THREADS; i++ )
	{
		if ( gameboard[i]->isInitialized() )
		{
			gameboard[i]->resetBoard();
		}
		else
		{
			gameboard[i]->initializeBoard( &status );
		}
	}
}

//////////////////////////////////////////////////////////////////////////////////////////

void GladiatorEngine::setSide( int player )
{ 
	for ( int i = 0; i < MAX_THREADS; i++ )
		gameboard[i]->setSide( player ); 
}

//////////////////////////////////////////////////////////////////////////////////////////

void GladiatorEngine::setTimeOut( int timeOut )
{ 
	gameboard[MASTER_THREAD]->setTimeOut( timeOut ); 
}

//////////////////////////////////////////////////////////////////////////////////////////

void GladiatorEngine::doMove( int player )
{ 	
	gameboard[MASTER_THREAD]->doMove( &pos, player );
	for ( int i = 1; i < GladiatorEngine::MAX_THREADS; i++ )
	{
		gameboard[i]->doMove( gameboard[MASTER_THREAD], &pos, player );
	}
	gameboard[MASTER_THREAD]->checkWin();
}

//////////////////////////////////////////////////////////////////////////////////////////

void GladiatorEngine::undoMove()
{ 
	for ( int i = 0; i < MAX_THREADS; i++ )
		gameboard[i]->undoMove( &pos ); 
}

//////////////////////////////////////////////////////////////////////////////////////////


int GladiatorEngine::getBoardscore()
{ 
	return gameboard[MASTER_THREAD]->getScore(); 
}

//////////////////////////////////////////////////////////////////////////////////////////

long GladiatorEngine::getHashKey()
{ 
	return gameboard[MASTER_THREAD]->getHashKey(); 
}

//////////////////////////////////////////////////////////////////////////////////////////


long GladiatorEngine::getRevKey()
{ 
	return gameboard[MASTER_THREAD]->getRevKey(); 
}

//////////////////////////////////////////////////////////////////////////////////////////


int  GladiatorEngine::getCount()
{ 
	return gameboard[MASTER_THREAD]->getCount(); 
}	


//////////////////////////////////////////////////////////////////////////////////////////


int  GladiatorEngine::freePositions()
{ 
	return gameboard[MASTER_THREAD]->freePositions(); 
}

//////////////////////////////////////////////////////////////////////////////////////////


void GladiatorEngine::updateStatus( int xCoord, int yCoord, int player, int timeout )
{
	status.pos->xCoordinate = xCoord;
	status.pos->yCoordinate = yCoord;
	status.player  = player;	
	status.timeout = timeout / 1000;

	agent->setMove( &status );
}


//////////////////////////////////////////////////////////////////////////////////////////


void GladiatorEngine::fillSearchResults( JNIEnv* env, jclass clsStatus, jobject objStatus )
{
	jfieldID hashID		= env->GetFieldID( clsStatus, "hash", "I" );
	jfieldID nodesID	= env->GetFieldID( clsStatus, "nodes", "I" );
	jfieldID scoreID	= env->GetFieldID( clsStatus, "score", "I" );
	jfieldID timeID		= env->GetFieldID( clsStatus, "time", "J" );
	jfieldID depthID    = env->GetFieldID( clsStatus, "depth", "I" );
	jfieldID playerID	= env->GetFieldID( clsStatus, "player", "B" );
	jfieldID hashSizeID	= env->GetFieldID( clsStatus, "hashSize", "I" );
	jfieldID quiescenceDepthID	= env->GetFieldID( clsStatus, "quiescenceDepth", "I" );

	jfieldID pvLineID	= env->GetFieldID( clsStatus, "pvLine", "[Lproject_alphabeta/alphabeta_common/Position;" );
	jobjectArray objPVLine = (jobjectArray)env->GetObjectField( objStatus, pvLineID );

	env->SetIntField( objStatus, hashID, status.hash );
	env->SetIntField( objStatus, nodesID, status.nodes );
	env->SetIntField( objStatus, scoreID, status.score );
	env->SetIntField( objStatus, timeID, status.time );
	env->SetIntField( objStatus, depthID, status.depth );
	env->SetByteField( objStatus, playerID, status.player );
	env->SetIntField( objStatus, hashSizeID, status.hashSize );
	env->SetIntField( objStatus, quiescenceDepthID, status.quiescenceDepth );

	jsize size = env->GetArrayLength( objPVLine );

	if ( size < status.depth )
	{
		return;
	}

	jobject pos			 = env->GetObjectArrayElement( objPVLine, 0 );
	jclass clsPos		 = env->GetObjectClass( pos );
	jfieldID xCoordID	 = env->GetFieldID( clsPos, "xCoordinate", "B" );
	jfieldID yCoordID    = env->GetFieldID( clsPos, "yCoordinate", "B" );
	jfieldID linearPosID = env->GetFieldID( clsPos, "linearPos", "B" );
	jfieldID seenID		 = env->GetFieldID( clsPos, "seen", "Z" );


	int i = 0;
	while ( status.pvLine[i] != 0 )
	{
		jobject posNext = env->GetObjectArrayElement( objPVLine, i );
		Position* pos = gameboard[MASTER_THREAD]->getPosition(status.pvLine[i]);
		env->SetByteField( posNext, xCoordID, pos->xCoordinate );
		env->SetByteField( posNext, yCoordID, pos->yCoordinate );
		env->SetByteField( posNext, linearPosID, status.pvLine[i] );
		env->SetBooleanField( posNext, seenID, true );
		i++;
	}
}

//////////////////////////////////////////////////////////////////////////////////////////


void GladiatorEngine::getVersion( JNIEnv* env, jclass clsVersion, jobject objVersion )
{
	jfieldID majorID	= env->GetFieldID( clsVersion, "majorVersion", "I" );
	jfieldID minorID	= env->GetFieldID( clsVersion, "minorVersion", "I" );
	jfieldID buildID	= env->GetFieldID( clsVersion, "buildVersion", "I" );
	env->SetIntField( objVersion, majorID, VERSION_MAJOR );
	env->SetIntField( objVersion, minorID, VERSION_MINOR );
	env->SetIntField( objVersion, buildID, VERSION_BUILD );
}

//////////////////////////////////////////////////////////////////////////////////////////


double GladiatorEngine::getHashtableMemoryDemand()
{
	if (!agent->isHashActivated())
	{
		return TranspositionTable::calcMemoryDemand();	
	}
	return 0;
}

//////////////////////////////////////////////////////////////////////////////////////////


void GladiatorEngine::initializeLists()
{
	if ( init )
	{
		agent->resetAgent();		
	}
	else
	{		
		init = true;
		int listSize = gameboard[MASTER_THREAD]->getStatus()->sizeXOfBoard + 1;
		agent->initializeLists( listSize );

		// initialize thread data  
		for ( int k = 0; k < GladiatorEngine::MAX_THREADS; k++ )
		{
			threadData[k]->initializeLists( listSize );
			gameboard[k]->setMasterPVL( threadData[MASTER_THREAD]->principalVar[0] );
		}	
	}
}


