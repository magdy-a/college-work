Domains
 
sList = symbol*.
board = brd(sList).
bList = board*.
 
square = sqr(symbol,integer).
 
cBoard = cbrd(board,square).
%	cBoard = cbrd(Board,LastPlay).
cBList = cBoard*.
 
player = ex ; oh ; none.
 
location = up ; down ; right ; left ; upperLeft ; upperRight ; lowerLeft ; lowerRight ; middle.
 
winDir = horizontal ; vertical ; diagonalRight ; diagonalLeft.
 
evaluationState = win ; draw ; check.
%	evaluationState = WinAccordingToPlayer ; Darw ; You Should Loop and Check the Value using your evaluation function.
 
 
Predicates
 
 
 
aB(cBoard,player,cBoard).
%	aB(cbrd(CurrentBoard,LastPlay),Player,return:cbrd(NewBoard,NewPlay(AI Chooses))).
 
 
alphaBeta(cBoard,integer,integer,player,integer,cBoard).
%	alphaBeta(cbrd(CurrentBoard,LastPlay),Alpha,Beta,Player,return:Heuristic,return:cbrd(NewBoard,NewPlay)).
 
 
alphaBetaHeuristic(cBList,integer,cBoard,player,integer,cBoard).
%	alphaBetaHeuristic(CBoardList(Board,LastPlay),TmpHeuristic,cbrd(TmpBoard,TmpLastPlay),Player,return:Heuristic,return:cbrd(NewBoard,NewPlay)).
 
 
 
winningLines(cBoard,player,integer).
%	winningLines(CBoard,Player,return:NumberOfWinningLines).
 
 
winningLinesAux(cBoard,player,winDir,integer).
%	winningLines(CBoard,Player,WinDir,return:NumberOfWinningLinesInWinDir).
 
countPossibilities(cBoard,player,location,integer,integer).
%	countPossibilities(CBoard,Player,Location,Depth,return:Number).
 
 
winChances(integer,integer).
%	winChances(NumberOfPossiblePlays,return:howManyWayYouCanWin).
 
 
piecesInLine(cBoard,player,integer).
%	piecesInLine(CBoard,Player,return:NumberOfPiecesInLine).
 
 
piecesInLineAux(cBoard,player,winDir,integer).
%	piecesInLine(CBoard,Player,WinDir,return:NumberOfPiecesInLine).
 
 
countPiecesInLine(cBoard,player,location,integer,integer,integer).
%	countPiecesInLine(CBoard,Player,Location,Depth,SpacesCount,return:Number).
 
 
countSymbols(cBoard,player,location,integer,integer).
%	countSymbols(cbrd(CurrentBoard,CurrentSquare),Player,countingDirection,Depth,return:NumberOfSymbols).
 
evaluationFunction(cBoard,player,evaluationState,integer).
%	evaluationFunction(CurrentCBoard,Player,EvaluationState,return:Value).%Player matters here !
 
 
go.
%	go.%starts the game, and asks the user if he want another one.
 
 
play(cBoard,player).
%	play(cbrd(CurrentBoard,LastPlay(to check winning)),Player(ex,oh)).
 
 
 
getChoice(board,player,square).
%	getChoice(CurrentBoard,Player,return:square(on of the 7 upper most)(sqr("a",6) : sqr("g",6))).
 
 
getPlay(player,integer).
%	getPlay(Player,return:Integer(1:7)).
 
 
setChoice(cBoard,player,cBoard).
%	setChoice(cbrd(CurrentBoard,Square(out from getChoice(one of the 7 upper most)),Player(to write X or O),return:cbrd(NewBoard,Square(the position square stayed in))).
 
 
didWin(cBoard,player).
%	didWin(cbrd(CurrentBoard,LastPlay(only checking around last play)),Player).
 
 
checkNodeWin(cBoard,player,winDir).
%	checkNodeWin(cbrd(CurrentBoard,LastPlay),Player,winDir(horizontal ; .... )).%yes Or no Question.
 
 
 
getChildren(board,player,cBList).
%	getChildren(CurrentBoard,Player,return:cBoardList).
 
 
getChildrenAux(board,player,integer,cBList).
%	getChildrenAux(CurrentBoard,Player,integerToLoopInputs(7),return:cBoardList).
 
 
countSpaces(board,integer).
%	countSpaces(CurrentBoard,return:#spaces).
 
 
isTerminal(board).
%	isTerminal(CurrentBoard).%yes Or no Question.
 
 
 
getSquareValue(cBoard,player).
%	getSquareValue(CurrentBoard,Square,return:Symbol in this Square( X or O )).
 
 
setSquareValue(cBoard,player,board).
%	setSquareValue(cbrd(CurrentBoard,Square),Player,NewBoard).
 
 
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
 
 
maxWithCBoard(integer,cBoard,integer,cBoard,integer,cBoard).
%	maxWithBoard(Integer1,cbrd(Board1,Play1),Integer2,cbrd(Board2,Play2),return:MaxInteger,return:cbrd(MaxBoard(alongWithMaxInteger),MaxPlay(alongWithMaxInteger))).
 
 
minWithCBoard(integer,cBoard,integer,cBoard,integer,cBoard).
%	maxWithBoard(Integer1,cbrd(Board1,Play1),Integer2,cbrd(Board2,Play2),return:MinInteger,return:cbrd(MinBoard(alongWithMinInteger),MinPlay(alongWithMinInteger))).
 
minusInfinity(integer).
%	minusInfinity(return:VerySmallInteger).
 
 
plusInfinity(integer).
%	plusInfinity(return:VeryBigNumber).
 
 
Clauses
 
 
aB(CBoard,Player,NewCBoard):-
minusInfinity(MinusInfinity),
plusInfinity(PlusInfinity),
alphaBeta(CBoard,MinusInfinity,PlusInfinity,Player,_,NewCBoard).
 
alphaBeta(cbrd(Board,LastPlay),_,_,Player,Number,cbrd(Board,LastPlay)):-
didWin(cbrd(Board,LastPlay),Player),
evaluationFunction(cbrd(Board,LastPlay),Player,win,Number),
write("Halaloya ", Player, " wins!"),	nl,	!.
alphaBeta(cbrd(Board,LastPlay),_,_,Player,Number,cbrd(Board,LastPlay)):-
isTerminal(Board),
evaluationFunction(cbrd(Board,LastPlay),Player,draw,Number),	!.
alphaBeta(cbrd(Board,_),_,_,Player,Heuristic,NewCBoard):-
getChildren(Board,Player,[Head|Tail]),
evaluationFunction(Head,Player,check,Number),
%	 write("Head : ", Head , " ", Number),nl,
alphaBetaHeuristic(Tail,Number,Head,Player,Heuristic,NewCBoard).
 
alphaBetaHeuristic([],I,CB,_,I,CB).
alphaBetaHeuristic([Head|Tail],TmpI,TmpCB,ex,I,CB):-
evaluationFunction(Head,ex,check,Sum),
maxWithCBoard(Sum,Head,TmpI,TmpCB,NewTmpI,NewTmpCB),
alphaBetaHeuristic(Tail,NewTmpI,NewTmpCB,ex,I,CB).
 
evaluationFunction(_,ex,win,1000):-	!.
evaluationFunction(_,oh,win,1000):-	!.
evaluationFunction(_,_,draw,0):-	!.
evaluationFunction(CBoard,Player,check,1000):-
didWin(CBoard,Player),	!.
evaluationFunction(cbrd(Board,Square),ex,check,900):-
setSquareValue(cbrd(Board,Square),oh,NewBoard),
didWin(cbrd(NewBoard,Square),oh),	!.
evaluationFunction(cbrd(Board,Square),ex,check,-900):-
adj(Square,up,SquareAbove),
setSquareValue(cbrd(Board,SquareAbove),oh,NewBoard),
didWin(cbrd(NewBoard,SquareAbove),oh),	!.
evaluationFunction(CBoard,Player,check,Sum):-
winningLines(CBoard,Player,WinningLines),
piecesInLine(CBoard,Player,PiecesInLine),
Sum = WinningLines + PiecesInLine.
%	 write(CBoard),	nl,
%	 write("WinningLines : ", WinningLines, ", PiecesInLines : ", PiecesInLine),	nl,
%	 write("Sum : ", Sum),nl	.
 
 
countPossibilities(_,_,_,0,0):-	!.%Depth is 0
%	 ex
countPossibilities(CBoard,ex,_,_,0):-%Square is Diff Player
getSquareValue(CBoard,oh),	!.
countPossibilities(cbrd(Board,Square),ex,Location,Depth,Number):-%Same Player and go check next Square
adj(Square,Location,NextSquare),	not(Square = NextSquare),
NewDepth = Depth - 1,
countPossibilities(cbrd(Board,NextSquare),ex,Location,NewDepth,ReturnNumber),
Number = ReturnNumber + 1,	!.
countPossibilities(_,ex,_,_,1).%Same Player but next Square isn't
%	 oh
countPossibilities(CBoard,oh,_,_,0):-%Square is Diff Player
getSquareValue(CBoard,ex),	!.
countPossibilities(cbrd(Board,Square),oh,Location,Depth,Number):-%Same Player and go check next Square
adj(Square,Location,NextSquare),	not(Square = NextSquare),
NewDepth = Depth - 1,
countPossibilities(cbrd(Board,NextSquare),oh,Location,NewDepth,ReturnNumber),
Number = ReturnNumber + 1,	!.
countPossibilities(_,oh,_,_,1).%Same Player but next Square isn't
 
winChances(Number,0):-
Number < 4,	!.
winChances(Number,Return):-%ex : for a 5 consecutive nodes you can win in 2 ways.
Return = Number - 4  + 1.
 
winningLines(CBoard,Player,Number):-
winningLinesAux(CBoard,Player,vertical,Vertical),
winningLinesAux(CBoard,Player,horizontal,Horizontal),
winningLinesAux(CBoard,Player,diagonalRight,DiagonalRight),
winningLinesAux(CBoard,Player,diagonalLeft,DiagonalLeft),
Number = Vertical + Horizontal + DiagonalRight + DiagonalLeft.
 
winningLinesAux(CBoard,Player,vertical,Number):-
countPossibilities(CBoard,Player,up,4,MeAndUp),
countPossibilities(CBoard,Player,down,4,MeAndDown),
Count = MeAndUp + MeAndDown - 1,
winChances(Count,Number),	!.
winningLinesAux(CBoard,Player,horizontal,Number):-
countPossibilities(CBoard,Player,right,4,MeAndRight),
countPossibilities(CBoard,Player,left,4,MeAndLeft),
Count = MeAndRight + MeAndLeft - 1,
winChances(Count,Number),	!.
winningLinesAux(CBoard,Player,diagonalRight,Number):-
countPossibilities(CBoard,Player,upperRight,4,MeAndUpperRight),
countPossibilities(CBoard,Player,lowerLeft,4,MeAndLowerLeft),
Count = MeAndUpperRight + MeAndLowerLeft - 1,
winChances(Count,Number),	!.
winningLinesAux(CBoard,Player,diagonalLeft,Number):-
countPossibilities(CBoard,Player,upperLeft,4,MeAndUpperLeft),
countPossibilities(CBoard,Player,lowerRight,4,MeAndLowerRight),
Count = MeAndUpperLeft + MeAndLowerRight - 1,
winChances(Count,Number).
 
 
countPiecesInLine(_,_,_,0,_,0):-	!.%Depth is 0
countPiecesInLine(cbrd(Board,Square),Player,Location,Depth,Spaces,Number):-%Space
getSquareValue(cbrd(Board,Square),none),
adj(Square,Location,NextSquare),
NewSpaces = Spaces + 1,
NewDepth = Depth - 1,
countPiecesInLine(cbrd(Board,NextSquare),Player,Location,NewDepth,NewSpaces,Number),	!.
countPiecesInLine(CBoard,Player,_,_,_,0):-%Not Space & Not Me !
getSquareValue(CBoard,ReturnPlayer),
not(Player = ReturnPlayer),	!.
%	 ex
countPiecesInLine(cbrd(Board,Square),ex,Location,Depth,Spaces,Number):-%Same Player and go check next Square
adj(Square,Location,NextSquare),	not(Square = NextSquare),
NewDepth = Depth - 1,
countPiecesInLine(cbrd(Board,NextSquare),ex,Location,NewDepth,0,ReturnNumber),
Number = ReturnNumber + Spaces + 1,	!.
countPiecesInLine(_,ex,_,_,Spaces,Number):-
Number = Spaces + 1.%Same Player but next Square isn't
%	 oh
countPiecesInLine(cbrd(Board,Square),oh,Location,Depth,Spaces,Number):-%Same Player and go check next Square
adj(Square,Location,NextSquare),	not(Square = NextSquare),
NewDepth = Depth - 1,
countPiecesInLine(cbrd(Board,NextSquare),oh,Location,NewDepth,0,ReturnNumber),
Number = ReturnNumber + Spaces + 1,	!.
countPiecesInLine(_,oh,_,_,Spaces,Number):-
Number = Spaces + 1.%Same Player but next Square isn't
 
piecesInLineAux(CBoard,Player,vertical,Number):-
countPiecesInLine(CBoard,Player,up,4,0,Up),
countPiecesInLine(CBoard,Player,down,4,0,Down),
Number = Up + Down - 1,	!.
piecesInLineAux(CBoard,Player,horizontal,Number):-
countPiecesInLine(CBoard,Player,right,4,0,Right),
countPiecesInLine(CBoard,Player,left,4,0,Left),
Number = Right + Left - 1,	!.
piecesInLineAux(CBoard,Player,diagonalRight,Number):-
countPiecesInLine(CBoard,Player,upperRight,4,0,UpperRight),
countPiecesInLine(CBoard,Player,lowerLeft,4,0,LowerLeft),
Number = UpperRight + LowerLeft - 1,	!.
piecesInLineAux(CBoard,Player,diagonalLeft,Number):-
countPiecesInLine(CBoard,Player,upperLeft,4,0,UpperLeft),
countPiecesInLine(CBoard,Player,lowerRight,4,0,LowerRight),
Number = UpperLeft + LowerRight - 1.
 
piecesInLine(CBoard,Player,Number):-
piecesInLineAux(CBoard,Player,vertical,Vertical),
piecesInLineAux(CBoard,Player,horizontal,Horizontal),
piecesInLineAux(CBoard,Player,diagonalRight,DiagonalRight),
piecesInLineAux(CBoard,Player,diagonalLeft,DiagonalLeft),
Number = Vertical + Horizontal + DiagonalRight + DiagonalLeft - 3.
 
didWin(CBoard,Player):-
checkNodeWin(CBoard,Player,vertical),	!.
didWin(CBoard,Player):-
checkNodeWin(CBoard,Player,horizontal),	!.
didWin(CBoard,Player):-
checkNodeWin(CBoard,Player,diagonalRight),	!.
didWin(CBoard,Player):-
checkNodeWin(CBoard,Player,diagonalLeft),	!.
 
checkNodeWin(CBoard,Player,vertical):-
countSymbols(CBoard,Player,up,4,MeAndUp),
countSymbols(CBoard,Player,down,4,MeAndDown),
MeAndUp + MeAndDown - 1 >= 4.
checkNodeWin(CBoard,Player,horizontal):-
countSymbols(CBoard,Player,right,4,MeAndRight),
countSymbols(CBoard,Player,left,4,MeAndLeft),
MeAndRight + MeAndLeft - 1 >= 4.
checkNodeWin(CBoard,Player,diagonalRight):-
countSymbols(CBoard,Player,upperRight,4,MeAndUpperRight),
countSymbols(CBoard,Player,lowerLeft,4,MeAndLowerLeft),
MeAndUpperRight + MeAndLowerLeft - 1 >= 4.
checkNodeWin(CBoard,Player,diagonalLeft):-
countSymbols(CBoard,Player,upperLeft,4,MeAndUpperLeft),
countSymbols(CBoard,Player,lowerRight,4,MeAndLowerRight),
MeAndUpperLeft + MeAndLowerRight - 1 >= 4.
 
countSymbols(_,_,_,0,0):-	!.%Depth is 0
countSymbols(cbrd(Board,Square),Player,_,_,0):-%Square is Diff Player
getSquareValue(cbrd(Board,Square),ReturnPlayer),
not(ReturnPlayer = Player),	!.
countSymbols(cbrd(Board,Square),Player,Location,Depth,Number):-%Same Player and go check next Square
adj(Square,Location,NextSquare),	not(Square = NextSquare),
NewDepth = Depth - 1,
countSymbols(cbrd(Board,NextSquare),Player,Location,NewDepth,ReturnNumber),
Number = ReturnNumber + 1,	!.
countSymbols(_,_,_,_,1).%Same Player but Next Square isn't
 
 
 
go:-
write("Human Plays as O, Computer Plays as X"),	nl,	fail.
go:-
write("Do you want to play first ... Human ? "),	nl,
readln(Ans),	Ans = "y",
write("Human Starts .. "),	nl,
firstSquare(FirstSquare),
play(cbrd(brd([" "," "," "," "," "," "," ",
              " "," "," "," "," "," "," ",
     	               " "," "," "," "," "," "," ",
              " "," "," "," "," "," "," ",
              " "," "," "," "," "," "," ",
              " "," "," "," "," "," "," "]),FirstSquare),oh),
nl,	write("Play again ? ( y / n ) : "),	!,	readln(X), X = "y",	nl,	go.
go:-
write("Computer Starts .. "),	nl,
firstSquare(FirstSquare),
play(cbrd(brd([" "," "," "," "," "," "," ",
              " "," "," "," "," "," "," ",
     	               " "," "," "," "," "," "," ",
              " "," "," "," "," "," "," ",
              " "," "," "," "," "," "," ",
              " "," "," "," "," "," "," "]),FirstSquare),ex),
nl,	write("Play again ? ( y / n ) : "),	readln(X), X = "y",	nl,	go.
 
 
play(cbrd(Board,LastPlay),ex):-
didWin(cbrd(Board,LastPlay),oh),
printBoard(Board),
write("Halaloya oh Wins"),	nl,	!.
play(cbrd(Board,LastPlay),oh):-
didWin(cbrd(Board,LastPlay),ex),
printBoard(Board),
write("Halaloya ex Wins"),	nl,	!.
play(cbrd(Board,_),_):-
isTerminal(Board),
write("Draw !!"),	nl,	!.
 
play(cbrd(Board,LastPlay),ex):-
printBoard(Board),
aB(cbrd(Board,LastPlay),ex,NewCBoard),
play(NewCBoard,oh),	!.
play(cbrd(Board,_),oh):-
printBoard(Board),
getChoice(Board,oh,Square),
setChoice(cbrd(Board,Square),oh,NewCBoard),
play(NewCBoard,ex),	!.
 
getPlay(Player,Return):-
write(Player),	write(" Turn (1 to 7) ... "),	nl,
readint(Return),	Return >= 1,	Return <= 7,	!.
getPlay(Player,Return):-
write("Invalid Input ... !!"),	nl,
getPlay(Player,Return).
 
getChoice(Board,Player,Square):-
getPlay(Player,Number),
getElement(Board,Number,ReturnPlayer),
ReturnPlayer = none,
charValue(Char,Number),	Square = sqr(Char,6),	!.
getChoice(Board,Player,Square):-
write("Can't play there dude !!"),	nl,
getChoice(Board,Player,Square).
 
setChoice(cbrd(Board,Square),Player,cbrd(NewBoard,Square)):-
location(Square,down),
setSquareValue(cbrd(Board,Square),Player,NewBoard),	!.
setChoice(cbrd(Board,Square),Player,NewCBoard):-
adj(Square,down,SouthSquare),
getSquareValue(cbrd(Board,SouthSquare),ReturnPlayer),	ReturnPlayer = none,
setChoice(cbrd(Board,SouthSquare),Player,NewCBoard),	!.
setChoice(cbrd(Board,Square),Player,cbrd(NewBoard,Square)):-
setSquareValue(cbrd(Board,Square),Player,NewBoard).
 
 
getChildren(Board,Player,CBList):-
getChildrenAux(Board,Player,1,CBList).
getChildrenaux(_,_,Input,[]):-
Input > 7,	!.
getChildrenAux(Board,Player,Input,[NewHead|Tail]):-
charValue(Char,Input),	Square = sqr(Char,6),
getSquareValue(cbrd(Board,Square),ReturnPlayer),	ReturnPlayer = none,
setChoice(cbrd(Board,Square),Player,NewHead),
NewInput = Input + 1,
getChildrenAux(Board,Player,NewInput,Tail),	!.
getChildrenAux(Board,Player,Input,CBoard):-
NewInput = Input + 1,
getChildrenAux(Board,Player,NewInput,CBoard).
 
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
 
 
getSquareValue(cbrd(Board,Square),Player):-
toNumber(Square,Number),
getElement(Board,Number,Player).
setSquareValue(cbrd(Board,Square),Player,NewBoard):-
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
 
 
nextChar("a","b").	nextChar("b","c").	nextChar("c","d").	nextChar("d","e"). nextChar("e","f").	nextChar("f","g").
charValue("a",1).	charValue("b",2).	charValue("c",3).	charValue("d",4). charValue("e",5).	charValue("f",6).	charValue("g",7).
location(sqr(_,6),up):-	 !.	location(sqr(_,1),down):-	!.	location(sqr("a",_),left):-	!. location(sqr("g",_),right):-	!.	location(_,middle).
 
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
write("L |"),	!.
printElement(Symbol):-
write(Symbol," |").
printBoardAux(brd([]),_):-	!.
printBoardAux(brd([Head|Tail]),sqr("g",Number)):-
printElement(Head),	write("|"),	nl,
%	 write("||------------------------------------||"),	nl,
write("||    |     |    |    |    |     |    ||"),	nl,
write("|| "),
nextSquare(sqr("g",Number),NextSquare),
printBoardAux(brd(Tail),NextSquare),	!.
printBoardAux(brd([Head|Tail]),Square):-
getSquareValue(cbrd(brd([Head|Tail]),Square),Player),
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
write("|| 1 | 2  | 3 | 4 | 5 | 6 | 7  ||"),	nl,
write("||    |     |    |    |    |    |     ||"),	nl,
write("|| "),
printBoardAux(Board,FirstSquare).
 
printBoardList([]):-	!.
printBoardList([Head|Tail]):-
printBoard(Head),
printBoardList(Tail).
 
 
maxWithCBoard(A,ACBoard,B,_,A,ACBoard):-
A > B,	!.
maxWithCBoard(_,_,B,BCBoard,B,BCBoard).
 
minWithCBoard(A,ACBoard,B,_,A,ACBoard):-
A < B,	!.
minWithCBoard(_,_,B,BCBoard,B,BCBoard).
 
 
minusInfinity(-9999999).
plusInfinity(9999999).
 
 
Goal
 
 
 
go.