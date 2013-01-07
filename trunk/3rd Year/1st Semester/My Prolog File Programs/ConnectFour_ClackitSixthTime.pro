Domains
	
	sList = symbol*.
	board = brd(sList).
	bList = board*.
	square = sqr(symbol,integer).
	sqrList = square*.%need it to send to alphaBetaAux as the LastPlay along with the List of Children
	player = ex ; oh ; none.
	location = up ; down ; right ; left ; upperLeft ; upperRight ; lowerLeft ; lowerRight ; middle.
	winDir = horizontal ; vertical ; diagonalRight ; diagonalLeft.
	evaluationState = win ; draw ; check.
%	evaluationState = Xwins ; Owins ; Darw ; You Should Loop and Check the Value using your evaluation function.

Predicates

	go.
%	go.%starts the game, and asks the user if he want another one.

	play(board,player,square).
%	play(CurrentBoard,Player(ex,oh),LastPlay(to check winning).


	getChoice(board,square,player).
%	getChoice(CurrentBoard,return:square(on of the 7 upper most)(sqr("a",6) : sqr("g",6)),Player).

	getPlay(integer,player).
%	getPlay(return:Integer(1:7),Player).

	setChoice(board,square,player,square,board).
%	setChoice(CurrentBoard,Square(out from getChoice(one of the 7 upper most),Player(to write X or O),return:Square(the position square stayed in),return:NewBoard).

	
	didWin(board,player,square).
%	didWin(CurrentBoard,Player,LastPlay(only checking around last play).

	checkNodeWin(board,square,player,winDir).
%	checkNodeWin(CurrentBoard,LastPlay,Player,winDir(horizontal ; .... )).%yes Or no Question.

	countSymbols(board,square,player,location,integer).
%	countSymbols(CurrentBoard,CurrentSquare,Player,countingDirection,return:NumberOfSymbols).

	
	evaluationFunction(board,player,evaluationState,integer).
%	evaluationFunction(CurrentBoard,Player,EvaluationState,return:Value).%Player matters here !


	getChildren(board,player,sqrList,bList).
%	getChildren(CurrentBoard,Player,BoardList).

	getChildrenAux(board,player,integer,sqrList,bList).
%	getChildrenAux(CurrentBoard,Player,integerToLoopInputs(7),BoardList).

	
	countSpaces(board,integer).
%	countSpaces(CurrentBoard,return:#spaces).

	isTerminal(board).
%	isTerminal(CurrentBoard).%yes Or no Question.


	getSquareValue(board,square,player).
%	getSquareValue(CurrentBoard,Square,return:Symbol in this Square( X or O )).

	setSquareValue(board,square,player,board).
%	setSquareValue(CurrentBoard,Square,Player,NewBoard).

	
	toNumber(square,integer).
%	toNumber(Square,return:#SquareInList).

	
	getElement(board,integer,player).
%	getElement(CurrentBoard,#SquareInList,return:Symbol(X or O)).

	setElement(board,integer,player,board).
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


	printBoardList(bList).
%	printBoardList(BoardList).

	
	aB(board,player,square,board,square).
%	aB(CurrentBoard,Player,LastPlay,return:NewPlay(AI Chooses),return:NewBoard).

	alphaBeta(board,square,integer,integer,player,integer,board,square).
%	alphaBeta(CurrentBoard,LastPlay,Alpha,Beta,Player,return:Heuristic,return:NewPlay,return:NewBoard).

	alphaBetaAux(bList,sqrList,integer,integer,board,player,integer,board,square).
%	alphaBetaAux(BoardList,SquareList(LastPlay-List),Alpha,Beta,TmpBoard,Player,return:Heuristic,return:NewPlay,return:NewBoard).

	
	maxWithBoardAndPlay(integer,board,square,integer,board,square,integer,board,square).
%	maxWithBoard(Integer1,Board1,Play1,Integer2,Board2,Play2,return:MaxInteger,return:MaxBoard(alongWithMaxInteger),return:MaxPlay(alongWithMaxInteger)).

	minWithBoardAndPlay(integer,board,square,integer,board,square,integer,board,square).
%	maxWithBoard(Integer1,Board1,Play1,Integer2,Board2,Play2,return:MinInteger,return:MinBoard(alongWithMinInteger),return:MinPlay(alongWithMinInteger)).
	
	minusInfinity(integer).
%	minusInfinity(return:VerySmallInteger).

	plusInfinity(integer).
%	plusInfinity(return:VeryBigNumber).

	
Clauses

	aB(Board,Player,LastPlay,NewBoard):-
		minusInfinity(MinusInfinity),
		plusInfinity(PlusInfinity),
		alphaBeta(Board,LastPlay,MinusInfinity,PlusInfinity,Player,_,NewBoard).
	
	alphaBeta(Board,LastPlay,_,_,Player,Number,Board):-
		didWin(Board,Player,LastPlay),
		evaluationFunction(Board,Player,win,Number),
		write("Halaloya ", Player, " wins!"),	nl,	!.
	alphaBeta(Board,_,_,_,Player,Number,Board):-
		isTerminal(Board),
		evaluationFunction(Board,Player,draw,Number),	!.
	alphaBeta(Board,_,Alpha,Beta,Player,Heuristic,NewBoard):-
		getChildren(Board,Player,PlayList,[HeadBoard|RestBoard]),
		alphaBetaAux([HeadBoard|RestBoard],PlayList,Alpha,Beta,HeadBoard,Player,Heuristic,NewBoard).
	
	alphaBetaAux([],[],Alpha,_,TmpBoard,ex,Alpha,TmpBoard):-	!.
	alphaBetaAux([HeadB|RestB],[HeadP|RestP],Alpha,Beta,TmpBoard,ex,NewAlpha,NewBoard):-
		Beta > Alpha,
		alphaBeta(HeadB,HeadP,Alpha,Beta,oh,Heuristic,_),
		maxWithBoardAndPlay(Heuristic,HeadB,Alpha,TmpBoard,NewAlphaAux,NewTmpBoard),
		alphaBetaAux(RestB,RestP,NewAlphaAux,Beta,NewTmpBoard,ex,NewAlpha,NewBoard),	!.
	alphaBetaAux(_,_,Alpha,Beta,NewBoard,ex,Alpha,NewBoard):-
		Beta <= Alpha.
		
	alphaBetaAux([],[],_,Beta,TmpBoard,oh,Beta,TmpBoard):-	!.
	alphaBetaAux([HeadB|RestB],[HeadP|RestP],Alpha,Beta,TmpBoard,oh,NewBeta,NewBoard):-
		Beta > Alpha,
		alphaBeta(HeadB,HeadP,Alpha,Beta,ex,Heuristic,_),
		minWithBoardAndPlay(Heuristic,HeadB,Beta,TmpBoard,NewBetaAux,NewTmpBoard),
		alphaBetaAux(RestB,RestP,Alpha,NewBetaAux,NewTmpBoard,oh,NewBeta,NewBoard),	!.
	alphaBetaAux(_,_,Alpha,Beta,NewBoard,oh,Beta,NewBoard):-
		Beta <= Alpha.
	

	maxWithBoardAndPlay(A,ABoard,APlay,B,_,_,A,ABoard,APlay):-
		A >= B,	!.
	maxWithBoardAndPlay(_,_,_,B,BBoard,BPlay,B,BBoard,BPlay).
	
	minWithBoardAndPlay(A,ABoard,APlay,B,_,_,A,ABoard,APlay):-
		A <= B,	!.
	minWithBoardAndPlay(_,_,_,B,BBoard,BPlay,B,BBoard,BPlay).

	minusInfinity(-999999).
	plusInfinity(999999).

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
		
	play(Board,ex,LastPlay):-
		printBoard(Board),
/*
		getChoice(Board,Square,ex),
		setChoice(Board,Square,ex,NewSquare,NewBoard),
*/
		aB(Board,ex,LastPlay,NewPlay,NewBoard),
		play(NewBoard,oh,NewPlay),	!.
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
		getElement(Board,Number,ReturnPlayer),
		ReturnPlayer = none,
		charValue(Char,Number),	Square = sqr(Char,6),	!.
	getChoice(Board,Square,Player):-
		write("Can't play there dude !!"),	nl,
		getChoice(Board,Square,Player).	
		
	setChoice(Board,Square,Player,Square,NewBoard):-
		location(Square,down),
		setSquareValue(Board,Square,Player,NewBoard),	!.
	setChoice(Board,Square,Player,NewSquare,NewBoard):-
		adj(Square,down,SouthSquare),
		getSquareValue(Board,SouthSquare,ReturnPlayer),	ReturnPlayer = none,
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
		
	checkNodeWin(Board,Square,Player,horizontal):-
		countSymbols(Board,Square,Player,right,MeAndRight),
		countSymbols(Board,Square,Player,left,MeAndLeft),
		MeAndRight + MeAndLeft - 1 >= 4.
	checkNodeWin(Board,Square,Player,vertical):-
		countSymbols(Board,Square,Player,up,MeAndUp),
		countSymbols(Board,Square,Player,down,MeAndDown),
		MeAndUp + MeAndDown - 1 >= 4.
	checkNodeWin(Board,Square,Player,diagonalRight):-
		countSymbols(Board,Square,Player,upperRight,MeAndUpperRight),
		countSymbols(Board,Square,Player,lowerLeft,MeAndLowerLeft),
		MeAndUpperRight + MeAndLowerLeft - 1 >= 4.
	checkNodeWin(Board,Square,Player,diagonalLeft):-
		countSymbols(Board,Square,Player,upperLeft,MeAndUpperLeft),
		countSymbols(Board,Square,Player,lowerRight,MeAndLowerRight),
		MeAndUpperLeft + MeAndLowerRight - 1 >= 4.
		
	countSymbols(Board,Square,Player,Location,Number):-%Same Player but Next Square isn't
		getSquareValue(Board,Square,ReturnPlayer),
		Player = ReturnPlayer,
		adj(Square,Location,NextSquare),
		Square = NextSquare,
		Number = 1,	!.
	countSymbols(Board,Square,Player,Location,Number):-%Same Player and go check next Square
		getSquareValue(Board,Square,ReturnPlayer),
		Player = ReturnPlayer,
		adj(Square,Location,NextSquare),
		countSymbols(Board,NextSquare,Player,Location,ReturnNumber),
		Number = ReturnNumber + 1,	!.
	countSymbols(_,_,_,_,Number):-
		Number = 0.
		
	
	evaluationFunction(_,ex,win,1):-	!.
	evaluationFunction(_,oh,win,-1):-	!.
	evaluationFunction(_,_,draw,0):-	!.
%	evalutionFunction(Board,Player,check,Value):-	%Eih Ba2a ?
	
		
	getChildren(Board,Player,PlayList,BoardList):-
		getChildrenAux(Board,Player,1,PlayList,BoardList).
	getChildrenaux(_,_,Input,[],[]):-
		Input > 7,	!.
	getChildrenAux(Board,Player,Input,[PlayPosition|RestPlay],[NewBoard|RestBoard]):-
		charValue(Char,Input),	Square = sqr(Char,6),
		getSquareValue(Board,Square,ReturnPlayer),	ReturnPlayer = none,
		setChoice(Board,Square,Player,PlayPosition,NewBoard),
		NewInput = Input + 1,
		getChildrenAux(Board,Player,NewInput,RestPlay,RestBoard),	!.
	getChildrenAux(Board,Player,Input,RestPlay,RestBoard):-
		NewInput = Input + 1,
		getChildrenAux(Board,Player,NewInput,RestPlay,RestBoard).
	
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

	getSquareValue(Board,Square,Player):-
		toNumber(Square,Number),
		getElement(Board,Number,Player).
	setSquareValue(Board,Square,Player,NewBoard):-
		toNumber(Square,Number),
		setElement(Board,Number,Player,NewBoard).
		
	toNumber(sqr(Char,Integer),Number):-
		NewInteger = 6 - Integer,
		Row = NewInteger * 7,
		charValue(Char,CharValue),
		Number = Row + CharValue.	
		
	getElement(brd([Head|_]),1,ex):-
		Head = "X",	!.
	getElement(brd([Head|_]),1,oh):-
		Head = "O",	!.
	getElement(brd([Head|_]),1,none):-
		Head = " ",	!.
	getElement(brd([_|Tail]),Number,Player):-
		NewNumber = Number - 1,
		getElement(brd(Tail),NewNumber,Player).
	setElement(brd([_|Tail]),1,ex,brd(["X"|Tail])):-	!.
	setElement(brd([_|Tail]),1,oh,brd(["O"|Tail])):-	!.
	setElement(brd([_|Tail]),1,none,brd([" "|Tail])):-	!.
	setElement(brd([Head|Tail]),Number,Player,brd([Head|NewTail])):-
		NewNumber = Number - 1,
		setElement(brd(Tail),NewNumber,Player,brd(NewTail)).

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
		getSquareValue(brd([Head|Tail]),Square,Player),
		Player = none,
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
	
	printBoardList([]):-	!.
	printBoardList([Head|Tail]):-
		printBoard(Head),
		printBoardList(Tail).

Goal

	go.
	
/*
	getChildren(brd(["X"," "," "," "," ","X","O",
			  " ","O"," "," ","X","O","O",
			  " ","O"," "," ","O","O","O",
			  " "," "," "," "," "," ","O",
			  " ","X","O","O","O","O","O",
			  "X"," "," ","O"," "," ","X"]),ex,What),
	printBoardList(What).
*/

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