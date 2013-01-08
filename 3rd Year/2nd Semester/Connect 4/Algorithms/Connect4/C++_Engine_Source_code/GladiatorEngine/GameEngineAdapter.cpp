/**************************************************
*    Author: Frank Dockhorn
*    Copyright 2001 - 2006
*    Application: Four wins
***************************************************/


#include "stdafx.h"
#include "GameEngineAdapter.h"
#include "Position.h"
#include "Gameboard.h"
#include "HashElement.h"
#include "SystemConstants.h"
#include "Array.h"
#include "PtrArray.h"
#include "TranspositionTable.h"
#include "StrategyGameAgent.h"
#include "GladiatorEngine.h"


JNIEXPORT void JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_doMoveJNI
(JNIEnv* env, jclass cls, jobject position, jbyte player)
{
	jclass clsPos = env->GetObjectClass( position );
	jfieldID posID = env->GetFieldID( clsPos, "linearPos", "B" );
	jfieldID xCoordinateID = env->GetFieldID( clsPos, "xCoordinate", "B" );
	jfieldID yCoordinateID = env->GetFieldID( clsPos, "yCoordinate", "B" );

	engine.setPos( env->GetByteField( position, posID ), 
				   env->GetByteField( position, xCoordinateID ), 
				   env->GetByteField( position, yCoordinateID ));

	engine.doMove( player );
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT void JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_undoMoveJNI
(JNIEnv* env, jclass cls, jobject position)
{
	jclass clsPos = env->GetObjectClass( position );
	jfieldID posID = env->GetFieldID( clsPos, "linearPos", "B" );
	jfieldID xCoordinateID = env->GetFieldID( clsPos, "xCoordinate", "B" );
	jfieldID yCoordinateID = env->GetFieldID( clsPos, "yCoordinate", "B" );

	engine.setPos( env->GetByteField( position, posID ), 
				   env->GetByteField( position, xCoordinateID ), 
				   env->GetByteField( position, yCoordinateID ));

	engine.undoMove();

}


//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT jobjectArray JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_checkFinalWinJNI
(JNIEnv* env, jclass cls, jobject position)
{
	jobjectArray res = NULL;
	jclass clsPos = env->GetObjectClass( position );
	jfieldID posID = env->GetFieldID( clsPos, "linearPos", "B" );
	jfieldID xCoordinateID = env->GetFieldID( clsPos, "xCoordinate", "B" );
	jfieldID yCoordinateID = env->GetFieldID( clsPos, "yCoordinate", "B" );
	jmethodID constructorID = env->GetMethodID( clsPos, "<init>", "()V" );

	engine.setPos( env->GetByteField( position, posID ), 
				   env->GetByteField( position, xCoordinateID ), 
				   env->GetByteField( position, yCoordinateID ));
	Byte length;
	Position** winPos = engine.checkFinalWin(length);

	if (winPos != NULL)
	{
		res = (jobjectArray)env->NewObjectArray(length, env->FindClass("project_alphabeta/alphabeta_common/Position"), NULL);	
		for(int i = 0; i < length; i++)
		{
			jobject obj = env->NewObject(clsPos, constructorID);
			env->SetByteField(obj, posID, winPos[i]->linearPos);
			env->SetByteField(obj, xCoordinateID, winPos[i]->xCoordinate);
			env->SetByteField(obj, yCoordinateID, winPos[i]->yCoordinate);
			env->SetObjectArrayElement(res, i, obj);
		}
	}	
	return res;
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT int JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_freePositionsJNI
(JNIEnv* env, jclass cls)
{
	int res = engine.freePositions();
	return res;
}


JNIEXPORT jboolean JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_lookupBookMoveJNI
(JNIEnv* env, jclass cls, jstring path, jobject position)
{
	jclass clsPos = env->GetObjectClass( position );
	jfieldID posID = env->GetFieldID( clsPos, "linearPos", "B" );
	jfieldID xCoordinateID = env->GetFieldID( clsPos, "xCoordinate", "B" );
	jfieldID yCoordinateID = env->GetFieldID( clsPos, "yCoordinate", "B" );
	jboolean iscopy;
	const jchar* pathConv = env->GetStringChars(path, &iscopy);
	const Position* pos = engine.lookupBookMove((wchar_t*)pathConv);
	if (pos != NULL)
	{
		env->SetByteField(position, posID, pos->linearPos);
		env->SetByteField(position, xCoordinateID, pos->xCoordinate);
		env->SetByteField(position, yCoordinateID, pos->yCoordinate);
		return true;
	}
	return false;
}


//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT void JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_initializeGameboardJNI
(JNIEnv* env, jclass cls, jobject status)
{
	jclass clsStatus = env->GetObjectClass( status );

	jfieldID scoreID = env->GetFieldID( clsStatus, "score", "I" );
	jfieldID countID = env->GetFieldID( clsStatus, "numberOfPieces", "I" );
	jfieldID sizeXOfBoardID = env->GetFieldID( clsStatus, "sizeXOfBoard", "I" );
	jfieldID sizeYOfBoardID = env->GetFieldID( clsStatus, "sizeYOfBoard", "I" );
	jfieldID hashElementsID = env->GetFieldID( clsStatus, "hashelements", "I" );
	jfieldID firstPlayerID  = env->GetFieldID( clsStatus, "firstPlayer", "B" );
	
	engine.setStatus( env->GetIntField( status, scoreID ), 
					  env->GetIntField( status, countID ),
					  env->GetIntField( status, sizeXOfBoardID ),
					  env->GetIntField( status, sizeYOfBoardID ),
					  env->GetIntField( status, hashElementsID ),
					  env->GetByteField( status, firstPlayerID ) );

	engine.initializeBoard();


}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT void JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_setTimeOutJNI
(JNIEnv* env, jclass cls, jint timeout)
{
	engine.setTimeOut( timeout );
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT jint JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_getBoardscoreJNI
(JNIEnv* env, jclass cls)
{
	return engine.getBoardscore();
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT jint JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_getCountJNI
(JNIEnv* env, jclass cls)
{
	return engine.getCount();
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT jdouble JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameAgent_getHashtableMemoryDemandJNI
(JNIEnv* env, jclass cls)
{	
	return engine.getHashtableMemoryDemand();	
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT jlong JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_getHashKeyJNI
(JNIEnv* env, jclass cls)
{
	return engine.getHashKey();
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT jlong JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_getRevKeyJNI
(JNIEnv* env, jclass cls)
{
	return engine.getRevKey();
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT void JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_setSideJNI
(JNIEnv* env, jclass cls, jbyte player)
{
	engine.setSide( player );
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT void JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameboard_updateStatusJNI
(JNIEnv* env, jclass cls, jobject status)
{
	jclass clsStatus = env->GetObjectClass( status );
	jfieldID playerID	   = env->GetFieldID( clsStatus, "player", "B" );
	jfieldID timeoutID	   = env->GetFieldID( clsStatus, "timeout", "I" );

	jfieldID posID	 = env->GetFieldID( clsStatus, "pos", "Lproject_alphabeta/alphabeta_common/Position;" );
	jobject objPos	 = env->GetObjectField( status, posID );
	jclass clsPos	 = env->GetObjectClass( objPos );

	jfieldID xCoordinateID = env->GetFieldID( clsPos, "xCoordinate", "B" );
	jfieldID yCoordinateID = env->GetFieldID( clsPos, "yCoordinate", "B" );

	engine.updateStatus( env->GetByteField( objPos, xCoordinateID ), 
					env->GetByteField( objPos, yCoordinateID ),
					env->GetByteField( status, playerID ),					
					env->GetIntField( status, timeoutID ) );
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT void JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameAgent_initializeListsJNI
(JNIEnv* env, jclass cls)
{
	engine.initializeLists();
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT void JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameAgent_iterativeDeepeningJNI
(JNIEnv* env, jclass cls)
{
	engine.iterativeDeepening();
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT void JNICALL Java_project_1alphabeta_alphabeta_1backend_WinGameAgent_fillSearchResultsJNI
(JNIEnv* env, jclass cls, jobject status)
{
	jclass clsStatus = env->GetObjectClass( status );
	engine.fillSearchResults( env, clsStatus, status );	
}

//////////////////////////////////////////////////////////////////////////////////////////

JNIEXPORT void JNICALL Java_project_1alphabeta_alphabeta_1backend_GameEngineAdapter_getVersionJNI
(JNIEnv* env, jclass cls, jobject version)
{
	jclass clsVersion = env->GetObjectClass( version );
	engine.getVersion( env, clsVersion, version );	
}