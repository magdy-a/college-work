Domains

	sList = symbol*.

	board = brd(sList).
	bList = board*.
	
	turn = maxX ; minO.
	
Predicates

	go.

	play(board,turn).
	
	getCoordinates(integer,symbol).
	
	getChoice(board,integer,symbol).
	
	getChildren(board,symbol,bList).
	getChildrenAux(board,symbol,integer,bList).
	
	countSpaces(sList,integer).
	
	getElement(sList,integer,symbol).
	
	writeElement(sList,integer,symbol,sList).
	
	printElement(symbol).
	
	printBoard(board).
	printBoardAux(board,integer).
	
	getLengthOfBoardList(bList,integer).
	
	isTerminal(board).
	
	didWin(board,symbol).
	
Clauses

	go:-
		write("Player_1 plays first as X"),nl,
		write("Players should enter their choices as coordinates like ( a,b ) :- as 'a' is integer from 0-2 on y, and 'b' integer from 0-2 on xG"),nl,
		play(brd([" "," "," "," "," "," "," "," "," "]),maxX).
		
	play(brd(List),maxX):-
		didWin(brd(List),"O"),
		printBoard(brd(List)),
		write("Halaloya, O Wins"),nl,
		!.
	play(brd(List),minO):-
		didWin(brd(List),"X"),
		printBoard(brd(List)),
		write("Halaloya, X Wins"),nl,
		!.
		
	play(brd(List),_):-
		countSpaces(List,Number),
		Number = 0,
		write("Draw !!, None wins"),nl,
		!.
		
	play(brd(List),maxX):-
		getChoice(brd(List),Number,"X"),
		writeElement(List,Number,"X",NewList),
		play(brd(NewList),minO),
		!.	
	play(brd(List),minO):-
		getChoice(brd(List),Number,"O"),
		writeElement(List,Number,"O",NewList),
		play(brd(NewList),maxX),
		!.
		
	getCoordinates(Number,Player):-
		write("It's ",Player,"'s turn ... enter y, then x ..."),nl,
		readint(X),readint(Y),
		X >= 0,
		X <= 2,
		Y >= 0,
		Y <= 2,
		Number = X * 3 + Y,
		!.
	getCoordinates(Number,Player):-
		write("Coordinates out of borders !"),nl,
		getCoordinates(Number,Player),
		!.
		
	getChoice(brd(List),Number,Player):-
		printBoard(brd(List)),
		getCoordinates(Number,Player),
		getElement(List,Number,Symbol),
		Symbol = " ",
		!.
	getChoice(brd(List),Number,Player):-
		write("Invalid input, Element already There"),nl,
		getChoice(brd(List),Number,Player),
		!.

	getChildren(Board,_,[]):-
		didWin(Board,"X"),
		!.
	getChildren(Board,_,[]):-
		didWin(Board,"O"),
		!.
	getChildren(Board,Symbol,BoardList):-
		getChildrenAux(Board,Symbol,0,BoardList),
		!.
	
	getChildrenAux(brd(List),V,N,[brd(NewList)|Tail]):-
		N < 9,
		getElement(List,N," "),
		writeElement(List,N,V,NewList),
		NewN = N + 1,
		getChildrenAux(brd(List),V,NewN,Tail),
		!.
	getChildrenAux(brd(List),V,N,Tail):-
		N < 9,
		NewN = N + 1,
		getChildrenAux(brd(List),V,NewN,Tail),
		!.
	getChildrenAux(_,_,9,[]):-
		!.
		
	countSpaces([],0):-
		!.
	countSpaces([Head|Tail],NewNumber):-
		Head = " ",
		countSpaces(Tail,Number),
		NewNumber = Number + 1,
		!.
	countSpaces([Head|Tail],Number):-
		Head <> " ",
		countSpaces(Tail,Number),
		!.
		
	getElement([Head|_],0,Head):-
		!.
	getElement([_|Tail],N,Element):-
		NewN = N - 1,
		getElement(Tail,NewN,Element),
		!.
		
	writeElement([_|Tail],0,Symbol,[Symbol|Tail]):-
		!.
	writeElement([Head|Tail],N,Symbol,[Head|NewTail]):-
		NewN = N - 1,
		writeElement(Tail,NewN,Symbol,NewTail),
		!.
		
	printBoard(Board):-
		printBoardAux(Board,0),
		!.
	
	printElement(" "):-
		write("_"),
		!.
	printElement(N):-
		write(N),
		!.
		
	printBoardAux(brd([Head|[]]),_):-
		printElement(Head),
		nl,nl,
		!.
	printBoardAux(brd([Head|Tail]),N):-
		N mod 3 = 0,
		nl,
		printElement(Head),
		NewN = N + 1,
		printBoardAux(brd(Tail),NewN),
		!.
	printBoardAux(brd([Head|Tail]),N):-
		N mod 3 <> 0,
		printElement(Head),
		NewN = N + 1,
		printBoardAux(brd(Tail),NewN),
		!.
		
	getLengthOfBoardList([],0):-
		!.
	getLengthOfBoardList([_|Tail],NewN):-
		getLengthOfBoardList(Tail,N),
		NewN = N + 1,
		!.
		
	isTerminal(Board):-
		getChildren(Board,"O",BoardList),
		getLengthOfBoardList(BoardList,0),
		!.
		
	didWin(brd([V,V,V,_,_,_,_,_,_]),V):-
		!.
	didWin(brd([_,_,_,V,V,V,_,_,_]),V):-
		!.
	didWin(brd([_,_,_,_,_,_,V,V,V]),V):-
		!.
	didWin(brd([V,_,_,V,_,_,V,_,_]),V):-
		!.
	didWin(brd([_,V,_,_,V,_,_,V,_]),V):-
		!.
	didWin(brd([_,_,V,_,_,V,_,_,V]),V):-
		!.
	didWin(brd([V,_,_,_,V,_,_,_,V]),V):-
		!.
	didWin(brd([_,_,V,_,V,_,V,_,_]),V):-
		!.
		
Goal

	go.