Domains
	
	sList = symbol*.
	board = brd(sList).
	bList = board*.
	square = sqr(symbol,integer).
	player = ex ; oh.
	location = up ; down ; right ; left ; upperLeft ; upperRight ; lowerLeft ; lowerRight ; middle.
	winDir = horizontal ; vertical ; diagonalRight ; diagonalLeft.

Predicates

	go.
	play(board,player,square).
%	play(CurrentBoard,Player(ex,oh),LastPlay(to check winning).

	getPlay(integer,player).
%	getPlay(return:Integer(1:7),Player).
	getChoice(board,square,player).
%	getChoice(CurrentBoard,return:square(on of the 7 upper most)(sqr("a",6) : sqr("g",6)),Player).
	setChoice(board,square,player,square,board).
%	setChoice(CurrentBoard,Square(out from getChoice(one of the 7 upper most),Player(to write X or O),return:Square(the position square stayed in),return:NewBoard).
	
	didWin(board,player,square).
%	didWin(CurrentBoard,Player,LastPlay(only checking around last play).
	checkNodeWin(board,square,player,winDir).
%	checkNodeWin(CurrentBoard,LastPlay,Player,winDir(horizontal ; .... )).%yes Or no Question.
	countSymbols(board,square,symbol,location,integer).
%	countSymbols(CurrentBoard,CurrentSquare,Symbol(X or O),countingDirection,return:NumberOfSymbols).
	
	countSpaces(board,integer).
%	countSpaces(CurrentBoard,return:#spaces).
	isTerminal(board).
%	isTerminal(CurrentBoard).%yes Or no Question.

	getSquareValue(board,square,symbol).
%	getSquareValue(CurrentBoard,Square,return:Symbol in this Square( X or O )).
	setSquareValue(board,square,player,board).
%	setSquareValue(CurrentBoard,Square,Player,NewBoard).
	
	toNumber(square,integer).
%	toNumber(Square,return:#SquareInList).
	
	getElement(board,integer,symbol).
%	getElement(CurrentBoard,#SquareInList,return:Symbol(X or O)).
	setElement(board,integer,symbol,board).
%	setElement(CurrentBoard,#SquareInList,Symbol(X or O),NewBoard).

	nextChar(symbol,symbol).
%	nextChar(EnglishChar,return:NextEnglishChar).
	charValue(symbol,integer).
%	charValue(EnlishChar,return:#CharInEnglish).
	
	location(square,location).
%	location(Square,return:abstractLocation(up,down,left,right,middle).
	
	firstSquare(square).
%	firstSquare(return:upperLeftSquare).
	nextSquare(square,square).
%	nextSquare(Square,return:NextSquareInList).
	lastSquare(square).
%	lastSquare(return:LowerRightSquare).
	
	adj(square,location,square).
%	adj(Square,AdjecentFrom,return:AdjecentSquare).
	
	printElement(symbol).
%	printElement(Symbol(matters when space)).
	printBoardAux(board,square).
%	printBoardAux(CurrentBoard,CurrentSquareToPrint).
	printBoard(board).
%	printBoard(CurrentBoard).
	
Clauses

	go:-
		write("Player_1 plays first as X"),	nl,
		firstSquare(FirstSquare),
		play(brd([" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "]),ex,FirstSquare),
		nl,	write("Play again ? ( y / n ) : "),	readln(X), X = "y",	nl,	go.

	play(Board,ex,LastPlay):-
		didWin(Board,oh,LastPlay),
		printBoard(Board),
		write("Halaloya oh Wins"),	nl,	!.
	play(Board,oh,LastPlay):-
		didWin(Board,ex,LastPlay),
		printBoard(Board),
		write("Halaloya ex Wins"),	nl,	!.
	play(Board,_,_):-
		isTerminal(Board),
		write("Draw !!"),	nl,	!.
		
	play(Board,ex,_):-
		printBoard(Board),
		getChoice(Board,Square,ex),
		setChoice(Board,Square,ex,NewSquare,NewBoard),
		play(NewBoard,oh,NewSquare),	!.
	play(Board,oh,_):-
		printBoard(Board),
		getChoice(Board,Square,oh),
		setChoice(Board,Square,oh,NewSquare,NewBoard),
		play(NewBoard,ex,NewSquare),	!.	
		
	getPlay(Return,Player):-
		write(Player),	write(" Turn (1 to 7) ... "),	nl,
		readint(Return),	Return >= 1,	Return <= 7,	!.
	getPlay(Return,Player):-
		write("Invalid Input ... !!"),	nl,
		getPlay(Return,Player).
		
	getChoice(Board,Square,Player):-
		getPlay(Number,Player),
		getElement(Board,Number,Symbol),	Symbol = " ",
		charValue(Char,Number),	Square = sqr(Char,6),	!.
	getChoice(Board,Square,Player):-
		write("Can't play there dude !!"),	nl,
		getChoice(Board,Square,Player).	
		
	setChoice(Board,Square,Player,Square,NewBoard):-
		location(Square,down),
		setSquareValue(Board,Square,Player,NewBoard),	!.
	setChoice(Board,Square,Player,NewSquare,NewBoard):-
		adj(Square,down,SouthSquare),
		getSquareValue(Board,SouthSquare,Symbol),	Symbol = " ",
		setChoice(Board,SouthSquare,Player,NewSquare,NewBoard),	!.
	setChoice(Board,Square,Player,Square,NewBoard):-
		setSquareValue(Board,Square,Player,NewBoard).	
		
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,horizontal),	!.
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,vertical),	!.
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,diagonalRight),	!.
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,diagonalLeft),	!.
		
%	I want to change ( Sending Symbol as a parameter : like "X" or "O", I want to just send the Player and the code handle it.
%	First i sould change the function of the getSquareValue to return:Player instead of symbol ----> should be in the next clackit !!
	checkNodeWin(Board,Player
	
/*
	countSymbols(Board,Square,Symbol,upperRight,Number):-
		getSquareValue(Board,Square,ReturnSymbol),
		Symbol <> ReturnSymbol,	Number = 0,	!.
	countSymbols(_,Square,_,upperRight,Number):-
		adj(Square,upperRight,NextSquare),
		Square = NextSquare,%Next is Null(Look at the Implementation of the adj(_,_,_).
		Number = 1,	!.
	countSymbols(Board,Square,Symbol,upperRight,Number):-
		adj(Square,upperRight,NextSquare),
		countSymbols(Board,NextSquare,Symbol,upperRight,ReturnNumber),
		Number = ReturnNumber + 1.
*/
	
	countSymbols(Board,Square,Symbol,_,Number):-
		getSquareValue(Board,Square,ReturnSymbol),
		Symbol <> ReturnSymbol,	Number = 0,	!.
	countSymbols(_,Square,_,Location,Number):-
		adj(Square,Location,NextSquare),
		Square = NextSquare,%Next is Null(Look at the Implementation of the adj(_,_,_).
		Number = 1,	!.
	countSymbols(Board,Square,Symbol,Location,Number):-
		adj(Square,Location,NextSquare),
		countSymbols(Board,NextSquare,Symbol,Location,ReturnNumber),
		Number = ReturnNumber + 1.
	
	countSpaces(brd([]),0):-	!.
	countSpaces(brd([Head|Tail]),NewNumber):-
		Head = " ",
		countSpaces(brd(Tail),Number),
		NewNumber = Number + 1,	!.
	countSpaces(brd([Head|Tail]),Number):-
		Head <> " ",
		countSpaces(brd(Tail),Number).
	isTerminal(Board):-
		countSpaces(Board,Number),
		Number = 0.

	getSquareValue(Board,Square,Symbol):-
		toNumber(Square,Number),
		getElement(Board,Number,Symbol).
	setSquareValue(Board,Square,ex,NewBoard):-
		toNumber(Square,Number),
		setElement(Board,Number,"X",NewBoard).
	setSquareValue(Board,Square,oh,NewBoard):-
		toNumber(Square,Number),
		setElement(Board,Number,"O",NewBoard).
		
	toNumber(sqr(Char,Integer),Number):-
		NewInteger = 6 - Integer,
		Row = NewInteger * 7,
		charValue(Char,CharValue),
		Number = Row + CharValue.	
		
	getElement(brd([Head|_]),1,Head):-	!.
	getElement(brd([_|Tail]),Number,Symbol):-
		NewNumber = Number - 1,
		getElement(brd(Tail),NewNumber,Symbol).
	setElement(brd([_|Tail]),1,Symbol,brd([Symbol|Tail])):-	!.
	setElement(brd([Head|Tail]),Number,Symbol,brd([Head|NewTail])):-
		NewNumber = Number - 1,
		setElement(brd(Tail),NewNumber,Symbol,brd(NewTail)).

	nextChar("a","b").	nextChar("b","c").	nextChar("c","d").	nextChar("d","e").	nextChar("e","f").	nextChar("f","g").
	charValue("a",1).	charValue("b",2).	charValue("c",3).	charValue("d",4).	charValue("e",5).	charValue("f",6).	charValue("g",7).
	location(sqr(_,6),up):-		!.	location(sqr(_,1),down):-	!.	location(sqr("a",_),left):-	!.	location(sqr("g",_),right):-	!.	location(_,middle).
	
	firstSquare(sqr("a",6)).
	nextSquare(Square,Square):-
		lastSquare(Square),	!.
	nextSquare(sqr("g",Number),sqr("a",NewNumber)):-
		NewNumber = Number - 1,	!.
	nextSquare(sqr(Symbol,Number),sqr(NewSymbol,Number)):-
		nextChar(Symbol,NewSymbol).
	lastSquare(sqr("g",1)).
	
	adj(Square,up,Square):-
		location(Square,up),	!.
	adj(sqr(Symbol,Integer),up,sqr(Symbol,NewInteger)):-
		NewInteger = Integer + 1,	!.
		
	adj(Square,upperRight,Square):-
		location(Square,up),	!.
	adj(Square,upperRight,Square):-
		location(Square,right),	!.
	adj(sqr(Symbol,Integer),upperRight,sqr(NewSymbol,NewInteger)):-
		nextChar(Symbol,NewSymbol),
		NewInteger = Integer + 1,	!.
		
	adj(Square,right,Square):-
		location(Square,right),	!.
	adj(sqr(Symbol,Integer),right,sqr(NewSymbol,Integer)):-
		nextChar(Symbol,NewSymbol),	!.
		
	adj(Square,lowerRight,Square):-
		location(Square,down),	!.
	adj(Square,lowerRight,Square):-
		location(Square,right),	!.
	adj(sqr(Symbol,Integer),lowerRight,sqr(NewSymbol,NewInteger)):-
		nextChar(Symbol,NewSymbol),
		NewInteger = Integer - 1,	!.
		
	adj(Square,down,Square):-
		location(Square,down),	!.
	adj(sqr(Symbol,Integer),down,sqr(Symbol,NewInteger)):-
		NewInteger = Integer - 1,	!.
		
	adj(Square,lowerLeft,Square):-
		location(Square,down),	!.
	adj(Square,lowerLeft,Square):-
		location(Square,left),	!.
	adj(sqr(Symbol,Integer),lowerLeft,sqr(NewSymbol,NewInteger)):-
		nextChar(NewSymbol,Symbol),
		NewInteger = Integer - 1,	!.
		
	adj(Square,left,Square):-
		location(Square,left),	!.
	adj(sqr(Symbol,Integer),left,sqr(NewSymbol,Integer)):-
		nextChar(NewSymbol,Symbol),	!.
		
	adj(Square,upperLeft,Square):-
		location(Square,up),	!.
	adj(Square,upperLeft,Square):-
		location(Square,left),	!.
	adj(sqr(Symbol,Integer),upperLeft,sqr(NewSymbol,NewInteger)):-
		nextChar(NewSymbol,Symbol),
		NewInteger = Integer + 1,	!.
		
	printElement(" "):-
		write("K |"),	!.
	printElement(Symbol):-
		write(Symbol," |").
		printBoardAux(brd([]),_):-	!.
	printBoardAux(brd([Head|Tail]),sqr("g",Number)):-
		printElement(Head),	write("|"),	nl,
		write("||------------------------------------||"),	nl,
		write("|| "),
		nextSquare(sqr("g",Number),NextSquare),
		printBoardAux(brd(Tail),NextSquare),	!.
	printBoardAux(brd([Head|Tail]),Square):-
		getSquareValue(brd([Head|Tail]),Square,Symbol),
		Symbol = " ",
		printElement(Head),	write(" "),
		nextSquare(Square,NextSquare),
		printBoardAux(brd(Tail),NextSquare),	!.
	printBoardAux(brd([Head|Tail]),Square):-
		printElement(Head),	write(" "),
		nextSquare(Square,NextSquare),
		printBoardAux(brd(Tail),NextSquare).
	printBoard(Board):-
		firstSquare(FirstSquare),
		write("||------------------------------------||"),	nl,
		write("||------------------------------------||"),	nl,
		write("|| "),
		printBoardAux(Board,FirstSquare),
		write("-----------------------------------||"),	nl.	

Goal

	go.

/*	
	countSymbols(brd(["X"," "," "," "," ","X","O",
			  " ","O"," "," ","X","O","O",
			  " ","O"," "," ","O","O","O",
			  " "," "," "," "," "," ","O",
			  " ","X","O","O","O","O","O",
			  "X"," "," ","O"," "," ","X"]),sqr("e",5),"X",upperRight,What).

*/

/*
	countSymbols(brd(["X"," "," "," "," ","X","O",
			  " ","O"," "," ","X","O","O",
			  " ","O"," "," ","O","O","O",
			  " "," "," "," "," "," ","O",
			  " ","X","O","O","O","O","O",
			  "X"," "," ","O"," "," ","X"]),sqr("b",4),"O",up,What).
*/

/*
	countSymbols(brd(["X"," "," "," "," ","X","O",
			  " ","O"," "," ","X","O","O",
			  " ","O"," "," ","O","O","O",
			  " "," "," "," "," "," ","O",
			  " ","X","O","O","O","O","O",
			  "X"," "," ","O"," "," ","X"]),sqr("b",1),"X",up,What).
*/