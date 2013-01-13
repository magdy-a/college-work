/*****************************************************************************

		Copyright (c) My Company

 Project:  CONNECT1
 FileName: NEWGAME.PRO
 Purpose: No description
 Written by: Visual Prolog
 Comments:
******************************************************************************/

include "connect1.inc"
include "connect1.con"
include "hlptopic.con"

%BEGIN_WIN NewGame
/**************************************************************************
        Creation and event handling for window: NewGame
**************************************************************************/


constants
%BEGIN NewGame, CreateParms, 20:29:37-29.5.2011, Code automatically updated!
  win_newgame_WinType = w_TopLevel
  win_newgame_Flags = [wsf_SizeBorder,wsf_TitleBar,wsf_Maximize,wsf_Minimize,wsf_Close,wsf_ClipSiblings,wsf_ClipChildren]
  win_newgame_RCT = rct(100,80,648,503)
  win_newgame_Menu = no_menu
  win_newgame_Title = "NewGame"
  win_newgame_Help = idh_contents
%END NewGame, CreateParms

predicates

	doDraw(integer,integer,integer,integer).

  win_newgame_eh : EHANDLER
 drawImage(Window)
 p2XY(pnt,integer,integer)
clauses
p2XY(pnt(X,Y),X,Y).

	doDraw(A,_,X,_):-
		abs(X - A) > 20,	!.
	doDraw(_,B,_,Y):-
		abs(Y - B) > 20.
	
drawImage(Win):-
	cursor(A,_),
        A>350,/*Y>180,Y<280,*/!,
	Pict1=pict_load("GameOn.bmp"),
	SourceRct1=rct(0,0,640,480),
	DestRct1=rct(0,0,640,480),
	pict_Draw(Win,Pict1,DestRct1,SourceRct1,rop_SrcCopy).
	
drawImage(Win):-
	Pict1=pict_load("GameOff.bmp"),
	SourceRct1=rct(0,0,640,480),
	DestRct1=rct(0,0,640,480),
	pict_Draw(Win,Pict1,DestRct1,SourceRct1,rop_SrcCopy).
	
  win_newgame_Create(_Parent):-
	win_Create(win_newgame_WinType,win_newgame_RCT,win_newgame_Title,
		   win_newgame_Menu,_Parent,win_newgame_Flags,win_newgame_eh,0).

%BEGIN NewGame, e_Create
  win_newgame_eh(_Win,e_Create(_),0):-!,
  	asserta(cursor(0,0)),
%BEGIN NewGame, InitControls, 20:29:37-29.5.2011, Code automatically updated!
%END NewGame, InitControls
%BEGIN NewGame, ToolbarCreate, 20:29:37-29.5.2011, Code automatically updated!
%END NewGame, ToolbarCreate
	drawImage(_Win),win_Invalidate(_Win),!.
%END NewGame, e_Create
%MARK NewGame, new events

%BEGIN NewGame, e_MouseMove
  win_newgame_eh(_Win,e_MouseMove(pnt(X,Y),_ShiftCtlAlt,_Button),0):-!,
  
  		cursor(A,B),
  		
  		doDraw(A,B,X,Y),
  		
		retract(cursor(_,_)),
  		
  		asserta(cursor(X,Y)),
  		
  		win_Invalidate(_Win),
	!.
%END NewGame, e_MouseMove

%BEGIN NewGame, e_MouseUp
  win_newgame_eh(_Win,e_MouseUp(_PNT,_ShiftCtlAlt,_Button),0):-!,
	!.
%END NewGame, e_MouseUp

%BEGIN NewGame, e_MouseDown
  win_newgame_eh(_Win,e_MouseDown(_PNT,_ShiftCtlAlt,_Button),0):-!
  	,p2XY(_PNT,X,Y),X>350,Y>180,Y<280,
	win_Destroy(_Win),!.
	
win_newgame_eh(_Win,e_MouseDown(_PNT,_ShiftCtlAlt,_Button),0):-!,
		!.
%END NewGame, e_MouseDown



%BEGIN NewGame, e_Update
  win_newgame_eh(_Win,e_Update(_UpdateRct),0):-
	cursor(A,B),
        A>350,B>180,B<280,!,
	Pict1=pict_load("GameOn.bmp"),
	SourceRct1=rct(0,0,640,480),
	DestRct1=rct(0,0,640,480),
	pict_Draw(_Win,Pict1,DestRct1,SourceRct1,rop_SrcCopy),
	!.
   win_newgame_eh(_Win,e_Update(_UpdateRct),0):-!,
	Pict1=pict_load("GameOff.bmp"),
	SourceRct1=rct(0,0,640,480),
	DestRct1=rct(0,0,640,480),
	pict_Draw(_Win,Pict1,DestRct1,SourceRct1,rop_SrcCopy),
	!.
%END NewGame, e_Update

%BEGIN NewGame, e_Size
  win_newgame_eh(_Win,e_Size(_Width,_Height),0):-!,
ifdef use_tbar
	toolbar_Resize(_Win),
enddef
	!.
%END NewGame, e_Size

%BEGIN NewGame, e_Menu, Parent window 
  win_newgame_eh(Win,e_Menu(ID,CAS),0):-!,
	PARENT = win_GetParent(Win),
	win_SendEvent(PARENT,e_Menu(ID,CAS)),
	!.
%END NewGame, e_Menu, Parent window

%END_WIN NewGame

