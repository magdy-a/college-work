Domains
	
	sList = symbol*.
	board = brd(sList).
	bList = board*.
	square = sqr(symbol,integer).
	player = ex ; oh.
	location = up ; down ; right ; left ; upperLeft ; upperRight ; lowerLeft ; lowerRight ; middle.

Predicates


	go.
	play(board,player,square).
	getPlay(integer,player).
	
	getChoice(board,square,player).
	setChoice(board,square,player,square,board).
	
	didWin(board,player,square).
	checkNodeWin(board,square,player,location).
	
	isTerminal(board).

	getSquareValue(board,square,symbol).
	setSquareValue(board,square,player,board).
	
	countSpaces(board,integer).
	
	toNumber(square,integer).
	
	getElement(board,integer,symbol).
	setElement(board,integer,symbol,board).

	nextChar(symbol,symbol).
	charValue(symbol,integer).
	
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
	
	printElement(symbol).
	printBoard(board).
	printBoardAux(board,square).
	
Clauses

	go:-
		write("Player_1 plays first as X"),	nl,
		firstSquare(FirstSquare),
		play(brd([" "," "," "," "," "," "," ",
		          " "," "," "," "," "," "," ",
     		          " "," "," "," "," "," "," ",
		          " "," "," "," "," "," "," ",
		          " "," "," "," "," "," "," ",
		          " "," "," "," "," "," "," "]),ex,FirstSquare),
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
		south(Square,SouthSquare),
		getSquareValue(Board,SouthSquare,Symbol),	Symbol = " ",
		setChoice(Board,SouthSquare,Player,NewSquare,NewBoard),	!.
	setChoice(Board,Square,Player,Square,NewBoard):-
		setSquareValue(Board,Square,Player,NewBoard).	
		
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,up),	!.
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,left),	!.
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,right),	!.
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,down),	!.
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,upperLeft),	!.
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,upperRight),	!.
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,lowerLeft),	!.
	didWin(Board,Player,Square):-
		checkNodeWin(Board,Square,Player,lowerRight).
		
	checkNodeWin(Board,Square,ex,up):-
		north(Square,Square_1),	north(Square_1,sqr(Char_2,Integer_2)),	north(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "X",	Symbol_1 = "X",	Symbol_2 = "X",	Symbol_3 = "X",
		Integer_2 <> Integer_3,	!.
		
	checkNodeWin(Board,Square,ex,left):-
		west(Square,Square_1),	west(Square_1,sqr(Char_2,Integer_2)),	west(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "X",	Symbol_1 = "X",	Symbol_2 = "X",	Symbol_3 = "X",
		Char_2 <> Char_3,	!.
		
	checkNodeWin(Board,Square,ex,right):-
		east(Square,Square_1),	east(Square_1,sqr(Char_2,Integer_2)),	east(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "X",	Symbol_1 = "X",	Symbol_2 = "X",	Symbol_3 = "X",
		Char_2 <> Char_3,	!.
		
	checkNodeWin(Board,Square,ex,down):-
		south(Square,Square_1),	south(Square_1,sqr(Char_2,Integer_2)),	south(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "X",	Symbol_1 = "X",	Symbol_2 = "X",	Symbol_3 = "X",
		Integer_2 <> Integer_3,	!.
		
	checkNodeWin(Board,Square,ex,upperLeft):-
		northWest(Square,Square_1),	northWest(Square_1,sqr(Char_2,Integer_2)),	northWest(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "X",	Symbol_1 = "X",	Symbol_2 = "X",	Symbol_3 = "X",
		Integer_2 <> Integer_3,	!.
		
	checkNodeWin(Board,Square,ex,upperRight):-
		northEast(Square,Square_1),	northEast(Square_1,sqr(Char_2,Integer_2)),	northEast(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "X",	Symbol_1 = "X",	Symbol_2 = "X",	Symbol_3 = "X",
		Integer_2 <> Integer_3,	!.
		
	checkNodeWin(Board,Square,ex,lowerLeft):-
		southWest(Square,Square_1),	southWest(Square_1,sqr(Char_2,Integer_2)),	southWest(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "X",	Symbol_1 = "X",	Symbol_2 = "X",	Symbol_3 = "X",
		Integer_2 <> Integer_3,	!.

	checkNodeWin(Board,Square,ex,lowerRight):-
		southEast(Square,Square_1),	southEast(Square_1,sqr(Char_2,Integer_2)),	southEast(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "X",	Symbol_1 = "X",	Symbol_2 = "X",	Symbol_3 = "X",
		Integer_2 <> Integer_3,	!.

	checkNodeWin(Board,Square,oh,up):-
		north(Square,Square_1),	north(Square_1,sqr(Char_2,Integer_2)),	north(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "O",	Symbol_1 = "O",	Symbol_2 = "O",	Symbol_3 = "O",
		Integer_2 <> Integer_3,	!.
		
	checkNodeWin(Board,Square,oh,left):-
		west(Square,Square_1),	west(Square_1,sqr(Char_2,Integer_2)),	west(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "O",	Symbol_1 = "O",	Symbol_2 = "O",	Symbol_3 = "O",
		Char_2 <> Char_3,	!.
		
	checkNodeWin(Board,Square,oh,right):-
		east(Square,Square_1),	east(Square_1,sqr(Char_2,Integer_2)),	east(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "O",	Symbol_1 = "O",	Symbol_2 = "O",	Symbol_3 = "O",
		Char_2 <> Char_3,	!.
		
	checkNodeWin(Board,Square,oh,down):-
		south(Square,Square_1),	south(Square_1,sqr(Char_2,Integer_2)),	south(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "O",	Symbol_1 = "O",	Symbol_2 = "O",	Symbol_3 = "O",
		Integer_2 <> Integer_3,	!.
		
	checkNodeWin(Board,Square,oh,upperLeft):-
		northWest(Square,Square_1),	northWest(Square_1,sqr(Char_2,Integer_2)),	northWest(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "O",	Symbol_1 = "O",	Symbol_2 = "O",	Symbol_3 = "O",
		Integer_2 <> Integer_3,	!.
		
	checkNodeWin(Board,Square,oh,upperRight):-
		northEast(Square,Square_1),	northEast(Square_1,sqr(Char_2,Integer_2)),	northEast(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "O",	Symbol_1 = "O",	Symbol_2 = "O",	Symbol_3 = "O",
		Integer_2 <> Integer_3,	!.
		
	checkNodeWin(Board,Square,oh,lowerLeft):-
		southWest(Square,Square_1),	southWest(Square_1,sqr(Char_2,Integer_2)),	southWest(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "O",	Symbol_1 = "O",	Symbol_2 = "O",	Symbol_3 = "O",
		Integer_2 <> Integer_3,	!.

	checkNodeWin(Board,Square,oh,lowerRight):-
		southEast(Square,Square_1),	southEast(Square_1,sqr(Char_2,Integer_2)),	southEast(sqr(Char_2,Integer_2),sqr(Char_3,Integer_3)),
		getSquareValue(Board,Square,Symbol),	getSquareValue(Board,Square_1,Symbol_1),	getSquareValue(Board,sqr(Char_2,Integer_2),Symbol_2),	getSquareValue(Board,sqr(Char_3,Integer_3),Symbol_3),
		Symbol = "O",	Symbol_1 = "O",	Symbol_2 = "O",	Symbol_3 = "O",
		Integer_2 <> Integer_3.
		
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
		
	countSpaces(brd([]),0):-	!.
	countSpaces(brd([Head|Tail]),NewNumber):-
		Head = " ",
		countSpaces(brd(Tail),Number),
		NewNumber = Number + 1,	!.
	countSpaces(brd([Head|Tail]),Number):-
		Head <> " ",
		countSpaces(brd(Tail),Number).
		
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

	nextChar("a","b").
	nextChar("b","c").
	nextChar("c","d").
	nextChar("d","e").
	nextChar("e","f").
	nextChar("f","g").
	
	charValue("a",1).
	charValue("b",2).
	charValue("c",3).
	charValue("d",4).
	charValue("e",5).
	charValue("f",6).
	charValue("g",7).
	
	location(sqr(_,6),up):-		!.
	location(sqr(_,1),down):-	!.
	location(sqr("a",_),left):-	!.
	location(sqr("g",_),right):-	!.
	location(_,middle).
	
	firstSquare(sqr("a",6)).
	lastSquare(sqr("g",1)).
	
	nextSquare(Square,Square):-
		lastSquare(Square),	!.
	nextSquare(sqr("g",Number),sqr("a",NewNumber)):-
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
		
	printBoard(Board):-
		firstSquare(FirstSquare),
		write("||------------------------------------||"),	nl,
		write("||------------------------------------||"),	nl,
		write("|| "),
		printBoardAux(Board,FirstSquare),
		write("-----------------------------------||"),	nl.
	
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
		
	printElement(" "):-
		write("K |"),	!.
	printElement(Symbol):-
		write(Symbol," |").

Goal

	go.