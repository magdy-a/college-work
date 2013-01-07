/*
	Adding next versions:
		1.Reduce first 3 levels using symetry.
		2.When there are more than one good play, randomize between them. use : random(MaxNumber, 0 >= Return < MaxNumber).
		3.continues playing.
		4.let User chooses how is first and decide who will play with player1 ( comp. Or human ), also player2 ( comp. Or human ).
		5.Graphical User Interface.
*/

Domains

	sList = symbol*.

	board = brd(sList).
	bList = board*.
	
	turn = maxX ; minO.
	
Predicates

	go.

	play(board,turn).
		
	getChoice(board,integer,symbol).
	getPlay(integer,symbol).
	
	getChildren(board,symbol,bList).
	getChildrenAux(board,symbol,integer,bList).
	
	getElement(sList,integer,symbol).
	
	writeElement(sList,integer,symbol,sList).
	
	printElement(symbol,integer).
	printBoard(board).
	printBoardAux(board,integer).
	
	printBoardList(bList).
	
	getLengthOfBoardList(bList,integer).
	
	isTerminal(board).
	countSpaces(sList,integer).
	
	didWin(board,symbol).

%			A.I
	
	aB(board,turn,board).
	alphaBeta(board,integer,integer,turn,integer,board).
	alphaBetaAux(bList,integer,integer,board,turn,integer,board).
%	alphaBetaAux(bList,Alpha,Beta,Value,Tmpborad,turn,ReturnValue,ReturnBoard).
	
%	max(integer,integer,integer).
%	min(integer,integer,integer).
	
	maxWithBoard(integer,board,integer,board,integer,board).
	minWithBoard(integer,board,integer,board,integer,board).

	minusInfinity(integer).
	plusInfinity(integer).
	
Clauses
		

	go:-
		write("Computer plays first as X"),nl,
		write("Player should enter their choices as Number from 1 to 9"),nl,
		play(brd([" "," "," "," "," "," "," "," "," "]),maxX),
		nl,write("Do you want to play again ? ( y / n ) : "),	readln(X),	X = "y",	nl,	go.
		
%		Win State	
	play(brd(List),maxX):-
		didWin(brd(List),"O"),
		printBoard(brd(List)),
		write("Halaloya, O Wins"),nl,	!.
	play(brd(List),minO):-
		didWin(brd(List),"X"),
		printBoard(brd(List)),
		write("Halaloya, X Wins"),nl,	!.
%		End of Win State
		
%		Draw
	play(brd(List),_):-
		isTerminal(brd(List)),
		write("Draw !!, None wins"),nl,	!.
%		End of Draw
		
	play(Board,maxX):-
		aB(Board,maxX,NewBoard),
		play(NewBoard,minO),	!.
	play(brd(List),minO):-
		getChoice(brd(List),Number,"O"),
		writeElement(List,Number,"O",NewList),
		play(brd(NewList),maxX),	!.
		
	aB(Board,Turn,NewBoard):-
		minusInfinity(MinusInfinity),
		plusInfinity(PlusInfinity),
		alphaBeta(Board,MinusInfinity,PlusInfinity,Turn,_,NewBoard),	!.
/*		
	aB(Board,minO,NewBoard):-
		minusInfinity(MinusInfinity),
		plusInfinity(PlusInfinity),
		alphaBeta(Board,MinusInfinity,PlusInfinity,minO,_,NewBoard),	!.
*/
		
%   				       AlphaBeta

%					WinState
	alphaBeta(Board,_,_,maxX,-1,Board):-	
		didWin(Board,"O"),	!.
	alphaBeta(Board,_,_,minO,1,Board):-	
		didWin(Board,"X"),	!.
%					DrawState
	alphaBeta(Board,_,_,_,0,Board):-	
		isTerminal(Board),	!.
%					maxX
	alphaBeta(Board,Alpha,Beta,maxX,Heuristic,NewBoard):-	
		getChildren(Board,"X",[Head|Tail]),	
		alphaBetaAux([Head|Tail],Alpha,Beta,Head,maxX,Heuristic,NewBoard),	!.
%					minO
	alphaBeta(Board,Alpha,Beta,minO,Heuristic,NewBoard):-	
		getChildren(Board,"O",[Head|Tail]),	
		alphaBetaAux([Head|Tail],Alpha,Beta,Head,minO,Heuristic,NewBoard),	!.
%				        Aux

%					maxX
	alphaBetaAux([],Alpha,_,NewBoard,maxX,Alpha,NewBoard):-	!.
	alphaBetaAux([Board|_],Alpha,Beta,_,maxX,Heuristic,Board):-
		Beta > Alpha,
		didWin(Board,"X"),
		alphaBeta(Board,Alpha,Beta,minO,Heuristic,_),	!.
	alphaBetaAux([Board|Tail],Alpha,Beta,TmpBoard_1,maxX,NewAlpha,NewBoard):-
		Beta > Alpha,
		alphaBeta(Board,Alpha,Beta,minO,Heuristic,_),	
		maxWithBoard(Alpha,TmpBoard_1,Heuristic,Board,NewAlphaAux,NewTmpBoard),
		alphaBetaAux(Tail,NewAlphaAux,Beta,NewTmpBoard,maxX,NewAlpha,NewBoard),	!.
	alphaBetaAux(_,Alpha,Beta,NewBoard,maxX,Alpha,NewBoard):-	Beta <= Alpha,	!.

%					minO
	alphaBetaAux([],_,Beta,NewBoard,minO,Beta,NewBoard):-	!.
	alphaBetaAux([Board|_],Alpha,Beta,_,minO,Heuristic,Board):-
		Beta > Alpha,
		didWin(Board,"O"),
		alphaBeta(Board,Alpha,Beta,maxX,Heuristic,_),	!.
	alphaBetaAux([Board|Tail],Alpha,Beta,TmpBoard_1,minO,NewBeta,NewBoard):-
		Beta > Alpha,
		alphaBeta(Board,Alpha,Beta,maxX,Heuristic,_),
		minWithBoard(Beta,TmpBoard_1,Heuristic,Board,NewBetaAux,NewTmpBoard),
		alphaBetaAux(Tail,Alpha,NewBetaAux,NewTmpBoard,minO,NewBeta,NewBoard),	!.
	alphaBetaAux(_,Alpha,Beta,NewBoard,minO,Beta,NewBoard):-	Beta <= Alpha,	!.
	
%					EndOfAlphaBeta
		
	getChoice(brd(List),Number,Player):-
		printBoard(brd(List)),
		getPlay(Number,Player),
		getElement(List,Number,Symbol),
		Symbol = " ",	!.
	getChoice(brd(List),Number,Player):-
		write("Invalid input, Element already There"),nl,
		getChoice(brd(List),Number,Player),	!.
	getPlay(Return,Player):-
		write("It's ",Player,"'s turn ... enter Number between 1 and 9 ..."),nl,
		readint(Number),	Number >= 1,	Number <= 9,	Return = Number - 1,	!.
	getPlay(Number,Player):-
		write("invalidNumber !"),nl,
		getPlay(Number,Player),	!.
/*
	getChildren(Board,_,[]):-	
		didWin(Board,"X"),	!.
	getChildren(Board,_,[]):-	
		didWin(Board,"O"),	!.
	getChildren(brd(List),_,[]):-
		countSpaces(List,Number),
		Number = 0,	!.
*/

%		reduce first 3 level using symetry
%			1.first level(empty board)
/*
	getChildren(brd(List),Symbol,[A,B,C]):-
		countSpaces(List,9),
		A = brd([Symbol," "," "," "," "," "," "," "," "]),
		B = brd([" "," "," ",Symbol," "," "," "," "," "]),
		C = brd([" "," "," "," ",Symbol," "," "," "," "]),
		!.
*/
%			2.second level(board with element
%	getChildren
		
	getChildren(Board,Symbol,BoardList):-
		getChildrenAux(Board,Symbol,0,BoardList),	!.
	
	getChildrenAux(brd(List),V,N,[brd(NewList)|Tail]):-
		N < 9,
		getElement(List,N," "),
		writeElement(List,N,V,NewList),
		NewN = N + 1,
		getChildrenAux(brd(List),V,NewN,Tail),	!.
	getChildrenAux(brd(List),V,N,Tail):-
		N < 9,
		NewN = N + 1,
		getChildrenAux(brd(List),V,NewN,Tail),	!.
	getChildrenAux(_,_,9,[]):-	!.
		
	countSpaces([],0):-	!.
	countSpaces([Head|Tail],NewNumber):-
		Head = " ",
		countSpaces(Tail,Number),
		NewNumber = Number + 1,	!.
	countSpaces([Head|Tail],Number):-
		Head <> " ",
		countSpaces(Tail,Number),	!.
		
	getElement([Head|_],0,Head):-	!.
	getElement([_|Tail],N,Element):-
		NewN = N - 1,
		getElement(Tail,NewN,Element),	!.
		
	writeElement([_|Tail],0,Symbol,[Symbol|Tail]):-	!.
	writeElement([Head|Tail],N,Symbol,[Head|NewTail]):-
		NewN = N - 1,
		writeElement(Tail,NewN,Symbol,NewTail),	!.
		
	printBoard(Board):-
		write("---------------"),nl,
		printBoardAux(Board,1),
		write("---------------"),nl,nl,	!.
	
	printElement(" ",Integer):-	write(Integer),	!.
	printElement(N,_):-	write(N),	!.
		
	printBoardAux(brd([Head|[]]),_):-	
		printElement(Head,9),	nl,!.
	printBoardAux(brd([Head|Tail]),N):-
		N mod 3 = 0,
		printElement(Head,N),	nl,	write("---------------"),	nl,
		NewN = N + 1,
		printBoardAux(brd(Tail),NewN),	!.
	printBoardAux(brd([Head|Tail]),N):-
		N mod 3 <> 0,
		printElement(Head,N),	write(" | "),
		NewN = N + 1,
		printBoardAux(brd(Tail),NewN),	!.
		
	printBoardList([]):-	!.
	printBoardList([Head|Tail]):-	
		printBoard(Head),	
		printBoardList(Tail),	!.
		
	getLengthOfBoardList([],0):-	!.
	getLengthOfBoardList([_|Tail],NewN):-	
		getLengthOfBoardList(Tail,N),	
		NewN = N + 1,	!.

	isTerminal(brd(List)):-	
		countSpaces(List,N),	
		N = 0,	!.
		
	didWin(brd([V,V,V,_,_,_,_,_,_]),V):-	!.
	didWin(brd([_,_,_,V,V,V,_,_,_]),V):-	!.
	didWin(brd([_,_,_,_,_,_,V,V,V]),V):-	!.
	didWin(brd([V,_,_,V,_,_,V,_,_]),V):-	!.
	didWin(brd([_,V,_,_,V,_,_,V,_]),V):-	!.
	didWin(brd([_,_,V,_,_,V,_,_,V]),V):-	!.
	didWin(brd([V,_,_,_,V,_,_,_,V]),V):-	!.
	didWin(brd([_,_,V,_,V,_,V,_,_]),V):-	!.
	
	maxWithBoard(A,ABoard,B,_,A,ABoard):-	A >= B,	!.
	maxWithBoard(_,_,B,BBoard,B,BBoard):-	!.
		
	minWithBoard(A,ABoard,B,_,A,ABoard):-	A <= B,	!.
	minWithBoard(_,_,B,BBoard,B,BBoard):-	!.

/*		
	max(A,B,A):-	A > B,	!.
	max(A,B,A):-	A = B,	random(2,What),	What = 0,	!.
	max(_,B,B):-	!.
	
	min(A,B,A):-	A < B,	!.
	min(A,B,A):-	A = B,	random(2,What),	What = 0,	!.
	min(_,B,B):-	!.
		
	maxWithBoard(A,ABoard,B,_,A,ABoard):-	A > B,	!.
	maxWithBoard(A,ABoard,B,_,A,ABoard):-	A = B,	random(2,What),	What = 1,	!.
	maxWithBoard(_,_,B,BBoard,B,BBoard):-	!.
		
	minWithBoard(A,ABoard,B,_,A,ABoard):-	A < B,	!.
	minWithBoard(A,ABoard,B,_,A,ABoard):-	A = B,	random(2,What),	What = 0,	!.
	minWithBoard(_,_,B,BBoard,B,BBoard):-	!.
*/

	minusInfinity(-999999).
	plusInfinity(999999).
		
Goal

	go.

/*
	getChildren(brd([" "," "," "," "," "," "," "," "," "]),"X",What),
	getLengthOfBoardList(What,What2),
	write(What2),nl,
	printBoardList(What).
*/