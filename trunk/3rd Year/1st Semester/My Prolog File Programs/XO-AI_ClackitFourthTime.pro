Domains

	sList = symbol*.

	board = brd(sList).
	bList = board*.
	
	turn = maxX ; minO.
	
Predicates

	go.

	play(board,turn).
		
	getPlay(integer,symbol).
	
	getChoice(board,integer,symbol).
	
	getChildren(board,symbol,bList).
	getChildrenAux(board,symbol,integer,bList).
	
	countSpaces(sList,integer).
	
	getElement(sList,integer,symbol).
	
	writeElement(sList,integer,symbol,sList).
	
	printElement(symbol,integer).
	
	printBoard(board).
	printBoardAux(board,integer).
	
	printBoardList(bList).
	
	getLengthOfBoardList(bList,integer).
	
	isTerminal(board).
	
	didWin(board,symbol).


%			A.I
	
	aB(board,turn,board).
	alphaBeta(board,integer,integer,turn,integer,board).
	alphaBetaAux(bList,integer,integer,board,turn,integer,board).
%	alphaBetaAux(bList,Alpha,Beta,Value,Tmpborad,turn,ReturnValue,ReturnBoard).
	
	max(integer,integer,integer).
	min(integer,integer,integer).
	
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
%   				       AlphaBeta

%					WinState
%	alphaBeta(Board,_,_,maxX,Heuristic,Board):-	didWin(Board,"O"),	/*printBoard(Board),	write("Won O"),nl,nl,*/	Heuristic = -1,	!.
	alphaBeta(Board,_,_,_,Heuristic,Board):-	didWin(Board,"O"),	printBoard(Board),	write("Won O"),nl,nl,	Heuristic = -1,	!.
%	alphaBeta(Board,_,_,minO,Heuristic,Board):-	didWin(Board,"X"),	/*printBoard(Board),	write("Won X"),nl,nl,*/	Heuristic = 1,	!.
	alphaBeta(Board,_,_,_,Heuristic,Board):-	didWin(Board,"X"),	printBoard(Board),	write("Won X"),nl,nl,	Heuristic = 1,	!.
%					DrawState
%	alphaBeta(Board,_,_,_,Heuristic,Board):-	isTerminal(Board),	/*write("Draw"),nl,nl,*/	Heuristic = 0,	!.
	alphaBeta(Board,_,_,_,Heuristic,Board):-	isTerminal(Board),	printBoard(Board),	write("Draw"),nl,nl,	Heuristic = 0,	!.
%					maxX
	alphaBeta(Board,Alpha,Beta,maxX,Heuristic,NewBoard):-	getChildren(Board,"X",[Head|Tail]),write("Children"),nl,printBoardList([Head|Tail]),write("EndChildren"),nl,	alphaBetaAux([Head|Tail],Alpha,Beta,Head,maxX,Heuristic,NewBoard),!.
%					minO

	alphaBeta(Board,Alpha,Beta,minO,Heuristic,NewBoard):-	getChildren(Board,"O",[Head|Tail]),write("Children"),nl,printBoardList([Head|Tail]),write("EndChildren"),nl,	alphaBetaAux([Head|Tail],Alpha,Beta,Head,minO,Heuristic,NewBoard),!.
	
		 
%				   AlphaBetaAux

%					maxX
	alphaBetaAux([],Alpha,_,NewBoard,maxX,Alpha,NewBoard):-	!.
	alphaBetaAux([Board|Tail],Alpha,Beta,TmpBoard_1,maxX,NewAlpha,NewBoard):-
		Beta > Alpha,
		printBoard(Board),
		write(Alpha,"  ",Beta,"   Max"),nl,
		write("TmpBoard"),nl,printBoard(Board),write("EndTmpBoard"),nl,
		alphaBeta(Board,Alpha,Beta,minO,Heuristic,_),
		maxWithBoard(Alpha,TmpBoard_1,Heuristic,Board,NewAlphaAux,NewTmpBoard),
		write("Maximizing between ",Alpha," ",Heuristic," Result is : ",NewAlphaAux),nl,
		write("NewTmpBoard"),nl,printBoard(NewTmpBoard),write("EndNewTmpBoard"),nl,
		alphaBetaAux(Tail,NewAlphaAux,Beta,NewTmpBoard,maxX,NewAlpha,NewBoard),	!.
	alphaBetaAux(List,Alpha,Beta,NewBoard,maxX,Alpha,NewBoard):-	Beta <= Alpha,write(Alpha,"  ",Beta,"   Prunned Max"),nl, write("PrunnedList"),nl,printBoardList(List),write("EndPrunnedList"),nl,	!.
%					minO
	alphaBetaAux([],_,Beta,NewBoard,minO,Beta,NewBoard):-	!.
	alphaBetaAux([Board|Tail],Alpha,Beta,TmpBoard_1,minO,NewBeta,NewBoard):-
		Beta > Alpha,
		printBoard(Board),
		write(Alpha,"  ",Beta,"   Min"),nl,
		write("TmpBoard"),nl,printBoard(Board),write("EndTmpBoard"),nl,
		alphaBeta(Board,Alpha,Beta,maxX,Heuristic,_),
		minWithBoard(Beta,TmpBoard_1,Heuristic,Board,NewBetaAux,NewTmpBoard),
		write("Minimizing between ",Beta," ",Heuristic," Result is : ",NewBetaAux),nl,
		write("NewTmpBoard"),nl,printBoard(NewTmpBoard),write("EndNewTmpBoard"),nl,
		alphaBetaAux(Tail,Alpha,NewBetaAux,NewTmpBoard,minO,NewBeta,NewBoard),	!.
	alphaBetaAux(List,Alpha,Beta,NewBoard,minO,Beta,NewBoard):-	Beta <= Alpha,write(Alpha,"  ",Beta,"   min"),nl,write("PrunnedList"),nl,printBoardList(List),write("EndPrunnedList"),nl,	!.
		

	go:-
		write("Player_1 plays first as X"),nl,
		write("Players should enter their choices as Number from 0 to 9"),nl,
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
		
	getPlay(Return,Player):-
		write("It's ",Player,"'s turn ... enter Number between 1 and 9 ..."),nl,
		readint(Number),
		Number >= 1,
		Number <= 9,
		Return = Number - 1,
		!.
	getPlay(Number,Player):-
		write("invalidNumber !"),nl,
		getPlay(Number,Player),
		!.
		
	getChoice(brd(List),Number,Player):-
		printBoard(brd(List)),
		getPlay(Number,Player),
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
		write("---------------"),nl,
		printBoardAux(Board,1),
		write("---------------"),nl,nl,
		!.
	
	printElement(" ",Integer):-
		write(Integer),
		!.
	printElement(N,_):-
		write(N),
		!.
		
	printBoardAux(brd([Head|[]]),_):-
		printElement(Head,9),
		nl,
		!.
	printBoardAux(brd([Head|Tail]),N):-
		N mod 3 = 0,
		printElement(Head,N),
		NewN = N + 1,
		nl,
		write("---------------"),nl,
		printBoardAux(brd(Tail),NewN),
		!.
	printBoardAux(brd([Head|Tail]),N):-
		N mod 3 <> 0,
		NewN = N + 1,
		printElement(Head,N),
		write(" | "),
		printBoardAux(brd(Tail),NewN),
		!.
		
	printBoardList([]):-
		!.
	printBoardList([Head|Tail]):-
		printBoard(Head),
		printBoardList(Tail),
		!.
		
	getLengthOfBoardList([],0):-
		!.
	getLengthOfBoardList([_|Tail],NewN):-
		getLengthOfBoardList(Tail,N),
		NewN = N + 1,
		!.

/*		
	isTerminal(Board):-
		getChildren(Board,"O",BoardList),
		getLengthOfBoardList(BoardList,N),
		N = 0,
		!.
*/

	isTerminal(brd(List)):-
		countSpaces(List,N),
		N = 0,
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
		
	max(A,B,A):-
		A > B,
		!.
	max(_,B,B):-
		!.
	
	min(A,B,A):-
		A < B,
		!.
	min(_,B,B):-
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
		
Goal

%	aB(brd([" "," "," "," "," "," "," "," "," "]),maxX,What).
%	go.

%	printBoard(brd(["X","O","X"," ","O","X","X"," ","O"])),
%	alphaBeta(brd(["X","O","X"," ","O","X","X"," ","O"]),-999999,999999,maxX,Integer,Board).

/*
	printBoard(brd(["O","X","O"," ","X","O","O"," ","X"])),
	alphaBeta(brd(["O","X","O"," ","X","O","O"," ","X"]),-999999,999999,maxX,Integer,Board),
	printBoard(Board).
*/

%	printBoard(brd(["X","O","O"," ","X","O","O"," ","X"])).

%/*
	printBoard(brd(["X","O","X"," ","O"," ","X"," ","O"])),
	alphaBeta(brd(["X","O","X"," ","O"," ","X"," ","O"]),-999999,999999,maxX,Integer,Board),
	printBoard(Board).
%*/
	
	
	
	
	
	
	
	
	
	
	
	
	
	
/*
Strategy


1.	Win: If the player has two in a row, play the third to get three in a row.
2.	Block: If the opponent has two in a row, play the third to block them.
3.	Fork: Create an opportunity where you can win in two ways.
4.	Block opponent's fork:
		Option 1: Create two in a row to force the opponent into defending, as long as it doesn't result in them creating a fork or winning. For example, if "X" has a corner, "O" has the center, and "X" has the opposite corner as well, "O" must not play a corner in order to win. (Playing a corner in this scenario creates a fork for "X" to win.)
		Option 2: If there is a configuration where the opponent can fork, block that fork.
5.	Center: Play the center.
6.	Opposite corner: If the opponent is in the corner, play the opposite corner.
7.	Empty corner: Play in a corner square.
8.	Empty side: Play in a middle square on any of the 4 sides.

Optimal strategy for player X. In each grid, the shaded red X denotes the optimal move, and the location of O's next move gives the next subgrid to examine. Note that only two sequences of moves by O (both starting with center, top-right, left-mid) lead to a draw, with the remaining sequences leading to wins from X.[3]
A player can play perfect tic-tac-toe (win or draw) given they move according to the highest possible move from the following table.[4]
Win: If the player has two in a row, play the third to get three in a row.
Block: If the opponent has two in a row, play the third to block them.
Fork: Create an opportunity where you can win in two ways.
Block opponent's fork:
Option 1: Create two in a row to force the opponent into defending, as long as it doesn't result in them creating a fork or winning. For example, if "X" has a corner, "O" has the center, and "X" has the opposite corner as well, "O" must not play a corner in order to win. (Playing a corner in this scenario creates a fork for "X" to win.)
Option 2: If there is a configuration where the opponent can fork, block that fork.
Center: Play the center.
Opposite corner: If the opponent is in the corner, play the opposite corner.
Empty corner: Play in a corner square.
Empty side: Play in a middle square on any of the 4 sides.
The first player, whom we shall designate "X", has 3 possible positions to mark during the first turn. Superficially, it might seem that there are 9 possible positions, corresponding to the 9 squares in the grid. However, by rotating the board, we will find that in the first turn, every corner mark is strategically equivalent to every other corner mark. The same is true of every edge mark. For strategy purposes, there are therefore only three possible first marks: corner, edge, or center. Player X can win or force a draw from any of these starting marks; however, playing the corner gives the opponent the smallest choice of squares which must be played to avoid losing.[5]
The second player, whom we shall designate "O", must respond to X's opening mark in such a way as to avoid the forced win. Player O must always respond to a corner opening with a center mark, and to a center opening with a corner mark. An edge opening must be answered either with a center mark, a corner mark next to the X, or an edge mark opposite the X. Any other responses will allow X to force the win. Once the opening is completed, O's task is to follow the above list of priorities in order to force the draw, or else to gain a win if X makes a weak play.
*/	