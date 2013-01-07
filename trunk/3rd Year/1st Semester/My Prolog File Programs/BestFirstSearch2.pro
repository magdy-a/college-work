Domains

	%here the integer is the "h"
	node = n(symbol,integer).
	
	nList = node*.
	
	expansionNumber = ex(integer) ; null.

	%here first integer is the expansion number ( -1 is the default ), the second integer is the "Maths" for UCS (g), for Greedy (h), for A*(f == g+h)
	searchNode = sn(symbol,integer,integer).

Predicates
	
	nondeterm uniformCostSearch(symbol).
	
	nondeterm ucs(symbol,nList,nList).
	
	nondeterm enqueue(nList,node,nList).
	
	nondeterm printNodeList(nList).
	
	nondeterm getChildren(symbol,nList).
	
	nondeterm getChildrenAux(symbol,nList,nList).
	
	nondeterm member(symbol,nList).
	
%	nondeterm insertSorted(node,nList
	
	nondeterm relate(node,integer,node).
	
	rootNode(node).
	
Clauses

	uniformCostSearch(Symbol):-
		rootNode(RootNode),
		ucs(Symbol,[RootNode],[]).
		
	ucs(Symbol,[n(Symbol,Symbol_H)|_],ClosedList):-
		enqueue(ClosedList,n(Symbol,Symbol_H),FullSearchTree),
		printNodeList(FullSearchTree).
		
%	ucs(Symbol,[Head|Tail],ClosedList):-
		
		
	enqueue([],Node,[Node]).
	enqueue([Head|Tail],Node,[Head|Return]):-
		enqueue(Tail,Node,Return).
		
	printNodeList([]).
	printNodeList([n(Name,G)|Tail]):-
		write(Name,"	",G),nl,
		printNodeList(Tail).
		
	getChildren(Symbol,List):-
		getChildrenAux(Symbol,List,[]),
		!.
		
	getChildrenAux(Symbol,List,ListAux):-
		relate(n(Symbol,_),_,n(Relation_Name,Relation_G)),
		not(member(Relation_Name,ListAux)),%here will close the first and go to the second and return 
		enqueue(ListAux,n(Relation_Name,Relation_G),NewListAux),
		getChildrenAux(Symbol,List,NewListAux).
		
	getChildrenAux(_,List,List):-!.%here will return
		
	member(Symbol,[n(Symbol,_)|_]).
	member(Symbol,[_|Tail]):-
		member(Symbol,Tail).
	
	rootNode(n("A",5)).
	
	relate(n("A",5),3,n("B",7)).
	relate(n("A",5),4,n("C",8)).
	
	
	relate(n("B",7),5,n("D",9)).
	relate(n("B",7),6,n("E",6)).
	
	relate(n("C",8),7,n("F",5)).
	relate(n("C",8),8,n("G",4)).
	
Goal
	
	getChildren("C",What).
	
%	uniformCostSearch("B").