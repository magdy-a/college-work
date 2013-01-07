Domains
	
	sList = symbol*.
	board = brd(sList).
	bList = board*.
	square = sqr(symbol,integer).
	player = white ; black.
	location = up ; down ; right ; left /*; upperLeft ; upperRight ; lowerLeft ; lowerRight*/ ; middle.
	
Predicates

	printBoard(board).
	printBoardAux(board,square).
%	printBoardAux(Board,sqr(a,1)).

	nextChar(symbol,symbol).
	charValue(symbol,integer).
	
	positionState(square,location,player).
	location(square,location).
	
	firstSquare(square).
	nextSquare(square,square).
	lastSquare(square).
	
	north(square,square).
	northEast(square,square).
	east(square,square).
	southEast(square,square).
	south(square,square).
	southWest(square,square).
	west(square,square).	
	northWest(square,square).
	
	color(square,player).

	queen(player,symbol).
	king(player,symbol).
	pawn(player,symbol).
%	.....

Clauses

	printBoard(Board):-
		firstSquare(FirstSquare),
		printBoardAux(Board,FirstSquare).
	
	printBoardAux(brd([]),_):-	!.
	printBoardAux(brd([Head|Tail]),sqr("h",Number)):-
		write(Head),	nl,
		nextSquare(sqr("h",Number),NextSquare),
		printBoardAux(brd(Tail),NextSquare),	!.
	printBoardAux(brd([Head|Tail]),Square):-
		write(Head),
		nextSquare(Square,NextSquare),
		printBoardAux(brd(Tail),NextSquare).
	
	nextChar("a","b").
	nextChar("b","c").
	nextChar("c","d").
	nextChar("d","e").
	nextChar("e","f").
	nextChar("f","g").
	nextChar("g","h").
	
	charValue("a",1).
	charValue("b",2).
	charValue("c",3).
	charValue("d",4).
	charValue("e",5).
	charValue("f",6).
	charValue("g",7).
	charValue("h",8).
	
	positionState(Square,Location,Player):-
		location(Square,Location),
		color(Square,Player).
		
%	location(sqr("a",8),upperLeft).
%	location(sqr("h",8),upperRight).
%	location(sqr("a",1),lowerLeft).
%	location(sqr("h",1),lowerLeft).
	location(sqr(_,8),up):-		!.
	location(sqr(_,1),down):-	!.
	location(sqr("a",_),left):-	!.
	location(sqr("h",_),right):-	!.
	location(_,middle).
	
	firstSquare(sqr("a",8)).
	lastSquare(sqr("h",1)).
	
	nextSquare(Square,Square):-
		lastSquare(Square),	!.
	nextSquare(sqr("h",Number),sqr("a",NewNumber)):-
		NewNumber = Number - 1,	!.
	nextSquare(sqr(Symbol,Number),sqr(NewSymbol,Number)):-
		nextChar(Symbol,NewSymbol).
		
	north(Square,Square):-
		location(Square,up),	!.
	north(sqr(Symbol,Integer),sqr(Symbol,NewInteger)):-
		NewInteger = Integer + 1.
		
	northEast(Square,Square):-
		location(Square,up),	!.
	northEast(Square,Square):-
		location(Square,right),	!.
	northEast(sqr(Symbol,Integer),sqr(NewSymbol,NewInteger)):-
		nextChar(Symbol,NewSymbol),
		NewInteger = Integer + 1.
	
	east(Square,Square):-
		location(Square,right),	!.
	east(sqr(Symbol,Integer),sqr(NewSymbol,Integer)):-
		nextChar(Symbol,NewSymbol).
		
	southEast(Square,Square):-
		location(Square,down),	!.
	southEast(Square,Square):-
		location(Square,right),	!.
	southEast(sqr(Symbol,Integer),sqr(NewSymbol,NewInteger)):-
		nextChar(Symbol,NewSymbol),
		NewInteger = Integer - 1.
		
	south(Square,Square):-
		location(Square,down),	!.
	south(sqr(Symbol,Integer),sqr(Symbol,NewInteger)):-
		NewInteger = Integer - 1.
		
	southWest(Square,Square):-
		location(Square,down),	!.
	southWest(Square,Square):-
		location(Square,left),	!.
	southWest(sqr(Symbol,Integer),sqr(NewSymbol,NewInteger)):-
		nextChar(NewSymbol,Symbol),
		NewInteger = Integer - 1.
	
	west(Square,Square):-
		location(Square,left),	!.
	west(sqr(Symbol,Integer),sqr(NewSymbol,Integer)):-
		nextChar(NewSymbol,Symbol).
		
	northWest(Square,Square):-
		location(Square,up),	!.
	northWest(Square,Square):-
		location(Square,left),	!.
	northWest(sqr(Symbol,Integer),sqr(NewSymbol,NewInteger)):-
		nextChar(NewSymbol,Symbol),
		NewInteger = Integer + 1.
		
	color(sqr(Symbol,Integer),black):-
		charValue(Symbol,Value),
		Sum = Value + Integer,
		Sum mod 2 = 0,	!.
	color(sqr(Symbol,Integer),white):-
		charValue(Symbol,Value),
		Sum = Value + Integer,
		Sum mod 2 = 1.
			
	queen(white,"q").
	queen(black,"Q").
	
	king(white,"k").
	king(black,"K").
	
	pawn(white,"p").
	pawn(black,"P").
	
Goal

%	color(sqr("h",8),What).
%	printBoard(brd([" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "])).
	printBoard(brd(["A","Q","G","p","I","F","k","o","p"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","g","k","k","l","f","p","h","s"])).
%	north(sqr("h",1),What).
%	northEast(sqr("c",3),What).
%	east(sqr("d",5),What).
%	southEast(sqr("c",3),What).
%	south(sqr("h",2),What).
%	southWest(sqr("c",3),What).
%	west(sqr("c",2),What).
%	northWest(sqr("c",3),What).


/*
	Chess Board Outline
		8
		7
		6
		5
		4
		3
		2
		1
	abcdefgh
*/