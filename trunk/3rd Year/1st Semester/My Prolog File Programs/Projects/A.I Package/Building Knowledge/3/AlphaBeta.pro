Domains

	sList = symbol*.
	player = min ; max.

Predicates

	aB.

	nondeterm alphaBeta(symbol,integer,integer,integer,player,integer).
%	nondeterm alphaBeta(Node,Depth,alpha,beta,minOrmax,returnHeuristic).
	nondeterm alphaBetaAux(sList,integer,integer,integer,player,integer).
%	nondeterm getchildrenAux(ChildrenList,Depth,Alpha,Beta,minOrmax,NewAlphaOrNewBetaAux,NewAlphaOrNewBeta-->Return).
	
	nondeterm getChildren(symbol,sList).
	nondeterm getChildrenAux(symbol,sList,sList).
	
	nondeterm member(symbol,sList).
	
	nondeterm addLast(symbol,sList,sList).
	
	min(integer,integer,integer).
	max(integer,integer,integer).
	
	
%	TataBaze !	

	root(symbol).
	
	nondeterm tree(symbol,symbol).
	
	heuristic(symbol,integer).
	
	depth(integer).
	
	minusInfinity(integer).
	plusInfinity(integer).
	
Clauses

	aB:-
		root(Root),
		write(Root),nl,
		depth(Depth),
		minusInfinity(MinusInfinity),
		plusInfinity(PlusInfinity),
		alphaBeta(Root,Depth,MinusInfinity,PlusInfinity,max,Return),
		write("Result ",Return),nl,
		!.
		
	alphaBeta(Node,0,_,_,_,Heuristic):-
		heuristic(Node,Heuristic),
		!.
		
	alphaBeta(Node,Depth,Alpha,Beta,max,NewAlpha):-		
		getChildren(Node,Children),
		NewDepth = Depth - 1,
		alphaBetaAux(Children,NewDepth,Alpha,Beta,max,NewAlpha).
		
	alphaBeta(Node,Depth,Alpha,Beta,min,NewBeta):-
		getChildren(Node,Children),
		NewDepth = Depth - 1,
		alphaBetaAux(Children,NewDepth,Alpha,Beta,min,NewBeta).
		
	alphaBetaAux([],_,Alpha,_,max,Alpha):-!.
	alphaBetaAux([Node|Tail],Depth,Alpha,Beta,max,NewAlpha):-
		
		Beta > Alpha,

		write(Node),nl,
		
		alphaBeta(Node,Depth,Alpha,Beta,min,Heuristic),
		max(Alpha,Heuristic,NewAlphaAux),
		alphaBetaAux(Tail,Depth,NewAlphaAux,Beta,max,NewAlpha).
	alphaBetaAux(List,_,Alpha,Beta,max,Alpha):-
		Beta <= Alpha,
		write(List," Pruned"),nl.
%		!.
		
	alphaBetaAux([],_,_,Beta,min,Beta):-!.
	alphaBetaAux([Node|Tail],Depth,Alpha,Beta,min,NewBeta):-	
	
		Beta > Alpha,

		write(Node),nl,
		
		alphaBeta(Node,Depth,Alpha,Beta,max,Heuristic),
		min(Beta,Heuristic,NewBetaAux),
		alphaBetaAux(Tail,Depth,Alpha,NewBetaAux,min,NewBeta).
	alphaBetaAux(List,_,Alpha,Beta,min,Beta):-
		Beta <= Alpha,
		write(List," Pruned"),nl.
%		!.
	
	getChildren(Node,List):-
		getChildrenAux(Node,[],List).
	
	getChildrenAux(Node,AuxList,List):-
		tree(Node,Child),
		not(member(Child,AuxList)),
		addLast(Child,AuxList,NewAuxList),
		getChildrenAux(Node,NewAuxList,List).
	getChildrenAux(_,List,List).
		
	member(Node,[Node|_]).
	member(Node,[_|Tail]):-
		member(Node,Tail).
		
	addLast(Node,[],[Node]).
	addLast(Node,[Head|Tail],[Head|NewTail]):-
		addLast(Node,Tail,NewTail).
	
	
	min(A,B,A):-
		A < B,
		!.
	min(_,B,B):-
		!.
	
	max(A,B,A):-
		A > B,
		!.
	max(_,B,B):-
		!.
		
	
%	TataBaze !

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

%   6 5  8 3  2 1  1 3

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
            if ß <= a
                break                             (* Beta cut-off *)
        return a
        
    else
        for each child of node
            ß := min(ß, alphabeta(child, depth-1, a, ß, not(Player) ))     
            if ß <= a
                break                             (* Alpha cut-off *)
        return ß 
(* Initial call *)
alphabeta(origin, depth, -infinity, +infinity, MaxPlayer)
*/


