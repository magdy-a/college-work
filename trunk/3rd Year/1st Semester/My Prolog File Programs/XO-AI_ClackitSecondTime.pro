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


%			A.I
	
	aB(board,turn,board).
	alphaBeta(board,integer,integer,turn,integer,board).
	alphaBetaAux(bList,integer,integer,board,turn,integer,board).
	
	maxWithBoard(integer,board,integer,board,integer,board).
	minWithBoard(integer,board,integer,board,integer,board).

	minusInfinity(integer).
	plusInfinity(integer).
	
Clauses

	aB(Board,maxX,NewBoard):-
		minusInfinity(MinusInfinity),
		plusInfinity(PlusInfinity),
		alphaBeta(Board,MinusInfinity,PlusInfinity,maxX,_,NewBoard),
		!.
	aB(Board,minO,NewBoard):-
		minusInfinity(MinusInfinity),
		plusInfinity(PlusInfinity),
		alphaBeta(Board,MinusInfinity,PlusInfinity,minO,_,NewBoard),
		!.
	
	alphaBeta(Board,_,_,maxX,Heuristic,Board):-
		didWin(Board,"O"),
		Heuristic = -1,
		!.
	alphaBeta(Board,_,_,minO,Heuristic,Board):-
		didWin(Board,"X"),
		Heuristic = 1,
		!.
	alphaBeta(Board,_,_,_,Heuristic,Board):-
		isTerminal(Board),
		Heuristic = 0,
		!.
		
	alphaBeta(Board,Alpha,Beta,maxX,Heuristic,NewBoard):-
		getChildren(Board,"X",[Head|Tail]),
		alphaBetaAux([Head|Tail],Alpha,Beta,Head,maxX,Heuristic,NewBoard),
		!.
	alphaBeta(Board,Alpha,Beta,minO,Heuristic,NewBoard):-
		getChildren(Board,"O",[Head|Tail]),
		alphaBetaAux([Head|Tail],Alpha,Beta,Head,minO,Heuristic,NewBoard),
		!.
		
	alphaBetaAux([],Alpha,_,NewBoard,maxX,Alpha,NewBoard):-
		!.
	alphaBetaAux([Board|Tail],Alpha,Beta,TmpBoard_1,maxX,NewAlpha,NewBoard):-
		Beta > Alpha,
		alphaBeta(Board,Alpha,Beta,minO,Heuristic,_),
		maxWithBoard(Alpha,TmpBoard_1,Heuristic,Board,NewAlphaAux,NewTmpBoard),
		write("maxX ... "),nl,write(TmpBoard_1),nl,write(NewTmpBoard),nl,write("End of maxX"),nl,
%		maxWithBoard(Heuristic,TmpBoard_1,Alpha,Board,NewAlphaAux,NewTmpBoard),
		alphaBetaAux(Tail,NewAlphaAux,Beta,NewTmpBoard,maxX,NewAlpha,NewBoard),
		!.
	alphaBetaAux(_,Alpha,Beta,TmpBoard,maxX,Alpha,TmpBoard):-
		Beta <= Alpha,
		write("maxX ... Beta <= Alpha ... return Board"),nl,
		!.
	
	alphaBetaAux([],_,Beta,NewBoard,minO,Beta,NewBoard):-
		!.
	alphaBetaAux([Board|Tail],Alpha,Beta,TmpBoard_1,minO,NewBeta,NewBoard):-
		Beta > Alpha,
		alphaBeta(Board,Alpha,Beta,maxX,Heuristic,_),
		minWithBoard(Beta,TmpBoard_1,Heuristic,Board,NewBetaAux,NewTmpBoard),
		write("minO ... "),nl,write(TmpBoard_1),nl,write(NewTmpBoard),nl,write("End of minO"),nl,
%		minWithBoard(Heuristic,TmpBoard_1,Beta,Board,NewBetaAux,NewTmpBoard),
		alphaBetaAux(Tail,Alpha,NewBetaAux,NewTmpBoard,minO,NewBeta,NewBoard),
		!.
	alphaBetaAux(_,Alpha,Beta,TmpBoard,minO,Beta,TmpBoard):-
		Beta <= Alpha,
		write("minO ... Beta <= Alpha ... returnBoard"),nl,
		!.
		
	maxWithBoard(A,ABoard,B,_,A,ABoard):-
		A > B,
		!.
	maxWithBoard(_,_,B,BBoard,B,BBoard):-
		!.
		
	minWithBoard(A,ABoard,B,_,A,ABoard):-
		A < B,
		!.
	minWithBoard(_,_,B,BBoard,B,BBoard):-
		!.

	minusInfinity(-999999).
	plusInfinity(999999).
	
%		End of A.I

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
		
	play(Board,maxX):-
		aB(Board,maxX,NewBoard),
		play(NewBoard,minO),
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

	aB(brd([" "," "," "," "," "," "," "," "," "]),maxX,What).
%	go.