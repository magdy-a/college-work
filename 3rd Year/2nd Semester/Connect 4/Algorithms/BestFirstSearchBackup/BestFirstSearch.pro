Domains

       %How should i care of the 2 direction Graph ... maybe later
       
       %Implement the Visited and Expanded.

       %here the integer is the "h", the g is in relate Func. 
	node = n(symbol,integer).
	
	nList = node*.

	searchNode = sn(symbol,integer,integer,integer,integer,integer).	%-1 for fringe state in the #Expan.
       %searchNode = sn("A"   ,-1     ,-1     ,0      ,5      ,5      ).
       %searchNode = sn(Name  ,#Ex.Ba.,#Expan.,g      ,h      ,Maths  ).        %Maths is the Generic Fn, UCS: g, Greedy: h,A*: f=g+h,PerfectInfo: Ftrue = Gture + Htrue
	
	snList = searchNode*.
	
	algorithm = uniform ; greedy ; aStar.
	

Predicates


%			MainFunctions	
	nondeterm uniformCostSearch(symbol).
	
	nondeterm ucs(symbol,snList).




%			Node	
	nondeterm enqueueNodeList(nList,node,nList).
	
	nondeterm concateNodeList(nList,nList,nList).
		
	nondeterm printNodeList(nList).
	
	nondeterm getChildrenNode(symbol,nList).
	
	nondeterm getChildrenNodeAux(symbol,nList,nList).
	
	nondeterm memberNode(symbol,nList).
	
	


%			SearchNode	
	nondeterm enqueueSearchList(snList,searchNode,snList).
	
	nondeterm concateSearchList(snList,snList,snList).
	
	nondeterm sortSearchList(snList,snList).
	
	nondeterm sortSearchListAux(snList,snList,snList).
	
	nondeterm insertionSortSearchNode(searchNode,snList,snList).
	
	nondeterm printSearchNodeList(snList).

	nondeterm memberSearchNode(searchNode,snList).	
	
	nondeterm createSearchNode(node,searchNode,algorithm,searchNode).

	
	
%			Database
	node(symbol,integer).
	
	relate(node,integer,node).
	
	rootNode(node).
	
	
Clauses

	uniformCostSearch(Symbol):-
		rootNode(n(Name,H)),
		ucs(Symbol,[sn(Name,-1,-1,0,H,H)]).
		
	ucs(Symbol,[sn(Name,B,Ex,G,H,M)|T]):-
%		node(Symbol,H),
		
		printNodeList(FullSearchTree).
		
%	ucs(Symbol,[Head|Tail],ClosedList):-


		

%			Node		
	enqueueNodeList([],Node,[Node]).
	enqueueNodeList([Head|Tail],Node,[Head|Return]):-
		enqueueNodeList(Tail,Node,Return).
		
	concateNodeList([],List,List).
	concateNodeList([Head|Tail],OtherList,[Head|NewTail]):-
		concateNodeList(Tail,OtherList,NewTail).
		
	printNodeList([]).
	printNodeList([n(Name,G)|Tail]):-
		write(Name,"	",G),nl,
		printNodeList(Tail).
		
	getChildrenNode(Symbol,List):-
		getChildrenNodeAux(Symbol,List,[]),
		!.
		
	getChildrenNodeAux(Symbol,List,ListAux):-
		relate(n(Symbol,_),_,n(Relation_Name,Relation_G)),
		not(memberNode(Relation_Name,ListAux)),%here will close the first and go to the second and return 
		enqueueNodeList(ListAux,n(Relation_Name,Relation_G),NewListAux),
		getChildrenNodeAux(Symbol,List,NewListAux).
		
	getChildrenNodeAux(_,List,List):-!.%here will return
		
	memberNode(Symbol,[n(Symbol,_)|_]).
	memberNode(Symbol,[_|Tail]):-
		memberNode(Symbol,Tail).
	
	node("A",5).
	node("B",7).
	node("C",8).
	node("D",9).
	node("E",6).
	node("F",5).
	node("G",4).
	
	rootNode(n("A",5)).
	
	relate(n("A",5),3,n("B",7)).
	relate(n("A",5),4,n("C",8)).
	
	
	relate(n("B",7),5,n("D",9)).
	relate(n("B",7),6,n("E",6)).
	
	relate(n("C",8),7,n("F",5)).
	relate(n("C",8),8,n("G",4)).
	


	
%			SearchNode
	enqueueSearchList([],SearchNode,[SearchNode]).
	enqueueSearchList([Head|Tail],SearchNode,[Head|NewTail]):-
		enqueueSearchList(Tail,SearchNode,NewTail).
		
	concateSearchList([],List,List).
	concateSearchList([Head|Tail],OtherList,[Head|NewTail]):-
		concateSearchList(Tail,OtherList,NewTail).
		
	sortSearchList(List,SortedList):-
		sortSearchListAux(List,SortedList,[]).
	
	sortSearchListAux([],SortedList,SortedList).
	sortSearchListAux([Head|Tail],SortedList,AuxList):-
		insertionSortSearchNode(Head,AuxList,NewAuxList),
		sortSearchListAux(Tail,SortedList,NewAuxList).
		
	insertionSortSearchNode(Node,[],[Node]).

	insertionSortSearchNode(sn(N1,B1,Ex1,G1,H1,M1),[sn(N2,B2,Ex2,G2,H2,M2)|Tail],[sn(N2,B2,Ex2,G2,H2,M2)|NewTail]):-
		Ex1 <> -1,
		insertionSortSearchNode(sn(N1,B1,Ex1,G1,H1,M1),Tail,NewTail).
		
	insertionSortSearchNode(sn(N1,B1,Ex1,G1,H1,M1),[sn(N2,B2,Ex2,G2,H2,M2)|Tail],[sn(N2,B2,Ex2,G2,H2,M2)|NewTail]):-
		Ex1 = -1,
		M1 > M2,
		insertionSortSearchNode(sn(N1,B1,Ex1,G1,H1,M1),Tail,NewTail).
	
	%Here u could U the Name ... if using Visited List, or Use #Expan. if using Expansion List
	%Take care ... i always search with the M : Maths ... and i should check the Maths in the main Function and set it's value by the right parameter I am using, for ex : UCS : M is the G
	insertionSortSearchNode(sn(N1,B1,Ex1,G1,H1,M1),[sn(N2,B2,Ex2,G2,H2,M2)|Tail],ConcatedList):-
		Ex1 = -1, % if not equal -1 means it is Expanded so i'll put it last ... in the first stopping condition.
		M1 <= M2, % here i the M1 = M2, if using Alphabetical Order i should check the Names Also !!
		concateSearchList([sn(N1,B1,Ex1,G1,H1,M1),sn(N2,B2,Ex2,G2,H2,M2)],Tail,ConcatedList).

	printSearchNodeList([]).
	printSearchNodeList([sn(Name,B,Ex,G,H,M)|Tail]):-
		Ex <> -1,
		write("Name : ", Name,", Backtrack Expansion : ",B,", Expansion Number : ",Ex,", G : ",G,", H : ",H," and M : ",M),nl,
		printSearchNodeList(Tail).
	printSearchNodeList([sn(Name,B,Ex,G,H,M)|Tail]):-
		Ex = -1,
		write("Name : ", Name,", Backtrack Expansion : ",B,", Expansion Number : Fringe",", G : ",G,", H : ",H," and M : ",M),nl,
		printSearchNodeList(Tail).
		
	memberSearchNode(SearchNode,[SearchNode|_]).
	memberSearchNode(SearchNode,[_|Tail]):-
		memberSearchNode(SearchNode,Tail).
		
	createSearchNode(n(CName,CH),sn(PName,PB,PEx,PG,PH,PM),uniform,sn(CName,PEx,-1,NewCost,CH,NewCost)):-
		relate(n(CName,CH),Cost,n(PName,PH)),
		NewCost = PG+Cost.
		
	createSearchNode(n(CName,CH),sn(PName,PB,PEx,PG,PH,PM),greedy,sn(CName,PEx,-1,NewCost,CH,CH)):-
		relate(n(CName,CH),Cost,n(PName,PH)),
		NewCost = PG+Cost.
		
	createSearchNode(n(CName,CH),sn(PName,PB,PEx,PG,PH,PM),aStar,sn(CName,PEx,-1,NewCost,CH,NewMaths)):-
		relate(n(CName,CH),Cost,n(PName,PH)),
		NewCost = PG+Cost,
		NewMaths = NewCost + CH.

Goal

%	sortSearchList([sn("A",0,-1,0,0,7),sn("B",0,-1,0,0,6),sn("C",0,-1,0,0,8)],What).

%	insertionSortSearchNode(sn("C",0,-1,3,2,6),[sn("A",-1,5,0,5),sn("B",0,1,4,2,6)],What).
	
	printSearchNodeList([sn("A",0,-1,5,0,5),sn("B",0,1,4,2,6),sn("C",0,2,3,4,7)]).
	
%	getChildrenNode("C",What).
	
%	uniformCostSearch("B").