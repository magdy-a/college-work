Domains

	sList = symbol*.
	player = min ; max.
	
/*

	-We here Implement the AlphaBeta Algorithm ( MinMax Updated ! ), Version 2.
	-Also it Uses DFS Algorithm, but the stop condition here is when the list is empty.
	-The Algorithm loops every child of the Node, but in a time we will need to break the loop
	-So, When breaking the loop of rest of the parent Children, i should develop a function 
		that delets a all children in a list for a certain parent
		the parent of the node i noticed the break action in it ( must be in the same condition, not the next move ) !!
		
		fun ( ..... max )
			do ur work
			if break
			delete the rest of children from the parent of mine
		fun ( ..... max )
			do ur work
			if not break


*/

Predicates

	nondeterm aB.

	nondeterm alphaBeta(sList,integer,integer,integer,player,integer,integer).
%	nondeterm alphaBeta(ListOfSymbols-LikeDFS,Depth,Alpha,Beta,MinOrMax,AuxValue,ReturnValue).


%	Helping Functions
		
	nondeterm getChildren(symbol,sList).
	nondeterm getChildrenAux(symbol,sList,sList).
	
	nondeterm member(symbol,sList).
	
	nondeterm concatenate(sList,sList,sList).
	
	nondeterm deleteChildrenFromList(sList,symbol,sList).
	
	nondeterm min(integer,integer,integer).
	nondeterm max(integer,integer,integer).
	
	
%	TataBaze !	

	root(symbol).
	
	nondeterm tree(symbol,symbol).
	
	heuristic(symbol,integer).
	
	depth(integer).
	
	minusInfinity(integer).
	plusInfinity(integer).

Clauses

/*
	(* Initial call *)
	alphabeta(origin, depth, -infinity, +infinity, MaxPlayer)
*/
	aB:-
		root(Root),
		depth(Depth),
		minusInfinity(MinusInfinity),
		minusInfinity(PlusInfinity),
		alphaBeta([Root],Depth,MinusInfinity,PlusInfinity,max,MinusInfinity,Return),
		write(Return).
/*		
	if  depth = 0 or node is a terminal node
        return the heuristic value of node
*/
	alphaBeta([Node|_],0,_,_,_,_,Heuristic):-
		heuristic(Node,Heuristic),
		!.
	
/*	
	if  Player = MaxPlayer
        for each child of node
            a := max(a, alphabeta(child, depth-1, a, ß, not(Player) ))     
            if ß = a
                break                             (* Beta cut-off *)
        return a
*/
	alphaBeta([Node|Tail],Depth,Alpha,Beta,max,Aux,Return):-
		
	
	
/*
	for each child of node
            ß := min(ß, alphabeta(child, depth-1, a, ß, not(Player) ))     
            if ß = a
                break                             (* Alpha cut-off *)
        return ß 
*/
	alphaBeta([Node|Tail],Depth,Alpha,Beta,min,Aux,Return).
	
	
	
%				Helping Functions


	getChildren(Node,List):-
		getChildrenAux(Node,[],List).
	
	getChildrenAux(Node,AuxList,List):-
		tree(Node,Child),
		addLast(Child,AuxList,NewAuxList),
		getChildrenAux(Node,NewAuxList,List).
	getChildrenAux(_,List,List).
		
		
	member(Node,[Node|_]).
	member(Node,[_|Tail]):-
		member(Node,Tail).
		
	concateList([],List,List).
	concateList([Head|Tail],OtherList,[Head|NewTail]):-
		concateList(Tail,OtherList,NewTail).
		
	deleteChildrenFromList([],_,[]).
	deleteChildrenFromList([Head|Tail],Parent,[Head|NewTail]):-
		not(tree(Parent,Head)),
		deleteChildrenFromList(Tail,Parent,NewTail).
	deleteChildrenFromList([Head|Tail],Parent,NewTail):-
		tree(Parent,Head),
		deleteChildrenFromList(Tail,Parent,NewTail).
	
	min(A,B,A):-
		A < B,
		!.
	min(_,B,B).
	
	max(A,B,A):-
		A > B,
		!.
	max(_,B,B).
		

%				TataBaze !

	root("A").

	tree("A","B").
	tree("A","C").
	
	tree("B","D").
	tree("B","E").
	
	tree("C","F").
	tree("C","G").
	
	tree("D","H").
	tree("D","I").
	
	tree("E","J").
	tree("E","K").
	
	tree("F","L").
	tree("F","M").
	
	tree("G","N").
	tree("G","O").
	

	heuristic("H",6).
	heuristic("I",5).
	
	heuristic("J",8).
	heuristic("K",2).
	
	heuristic("L",2).
	heuristic("M",1).
	
	heuristic("N",1).
	heuristic("O",3).
	
	
	depth(3).
	
	minusInfinity(-999999).
	plusInfinity(999999).
	
%	   A
%     B          C	
%   D    E    F    G	
%  H I  J K  L M  N O

Goal

	aB.
	
/*

http://en.wikipedia.org/wiki/Alpha-beta_pruning

function alphabeta(node, depth, a, ß, Player)         
    if  depth = 0 or node is a terminal node
        return the heuristic value of node
    if  Player = MaxPlayer
        for each child of node
            a := max(a, alphabeta(child, depth-1, a, ß, not(Player) ))     
            if ß = a
                break                             (* Beta cut-off *)
        return a
    else
        for each child of node
            ß := min(ß, alphabeta(child, depth-1, a, ß, not(Player) ))     
            if ß = a
                break                             (* Alpha cut-off *)
        return ß 
(* Initial call *)
alphabeta(origin, depth, -infinity, +infinity, MaxPlayer)
*/