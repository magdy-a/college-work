
       %How should i care of the 2 direction Graph ... maybe later

       %Implement the Visited and Expanded.
       

Domains

	sList = symbol*.

	searchNode = sn(symbol,integer,integer,integer,integer,integer).	%0 for fringe state in the #Expan.
       %searchNode = sn("A"   ,0      ,0      ,0      ,5      ,5      ).
       %searchNode = sn(Name  ,#Ex.Ba.,#Expan.,g      ,h      ,Maths  ).        %Maths is the Generic Fn, UCS: g, Greedy: h,A*: f=g+h,PerfectInfo: Ftrue = Gture + Htrue
	
	snList = searchNode*.
	
	algorithm = uniform ; greedy ; aStar.	
	

Predicates

%			MainFunctions	

	nondeterm uniformCostSearch(symbol).
	
	nondeterm ucs(symbol,snList).


%			SymbolList

	nondeterm enqueueList(sList,symbol,sList).
	nondeterm concateList(sList,sList,sList).
	
	nondeterm getChildren(symbol,sList).
	nondeterm getChildrenAux(symbol,sList,sList).	
	
	nondeterm member(symbol,sList).
		
	nondeterm printList(sList).
	

%			SearchNodeList

	nondeterm enqueueSearchList(snList,searchNode,snList).
	nondeterm concateSearchList(snList,snList,snList).
	
	nondeterm sortSearchList(snList,snList).
	nondeterm sortSearchListAux(snList,snList,snList).
	nondeterm insertionSortSearchList(searchNode,snList,snList).
	
	nondeterm memberSearchList(searchNode,snList).
	
	nondeterm createSearchNode(symbol,searchNode,algorithm,searchNode).
		
	nondeterm getLastExpansionNum(snList,integer).
	nondeterm getLastExpansionNumAux(snList,integer,integer).
	
	nondeterm printSearchList(snList).

	
%			Database

	rootNode(symbol).
	
	nondeterm node(symbol,integer).
	
	nondeterm relation(symbol,integer,symbol).

	
Clauses

%			MainFunctions

	uniformCostSearch(Symbol):-
		rootNode(Name),
		ucs(Symbol,[sn(Name,0,0,0,H,H)]).
		
	ucs(_Goal,[sn(_Goal,B,Ex,G,H,M)|Tail]):-
		Ex = 0,
		getLastExpansionNum([sn(_Goal,B,Ex,G,H,M)|Tail],LastEx),
		NewEx = LastEx + 1,
		printSearchList([sn(_Goal,B,NewEx,G,H,M)|Tail]).
%	ucs(_Goal,[sn(Name,B,Ex,G,H,M)|Tail]):-
%		Ex = 0,
%		getChildren(Name,ChildrenList),
		

%			SymbolList
	enqueueList([],Node,[Node]).
	enqueueList([Head|Tail],Node,[Head|Return]):-
		enqueueList(Tail,Node,Return).
		
	concateList([],List,List).
	concateList([Head|Tail],OtherList,[Head|NewTail]):-
		concateList(Tail,OtherList,NewTail).
		
	getChildren(Symbol,List):-
		getChildrenAux(Symbol,List,[]),
		!.
		
	getChildrenAux(Symbol,List,ListAux):-
		relation(Symbol,_,Relation_Name),
		not(member(Relation_Name,ListAux)),%here will close the first and go to the second and return 
		enqueueList(ListAux,Relation_Name,NewListAux),
		getChildrenAux(Symbol,List,NewListAux).
	getChildrenAux(_,List,List):-
		!.%here will return
		
	member(Symbol,[Symbol|_]).
	member(Symbol,[_|Tail]):-
		member(Symbol,Tail).
		
	printList([]).
	printList([Name|Tail]):-
		node(Name,G),
		write(Name,"	",G),nl,
		printList(Tail).
	
	
%			SearchNodeList
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
		insertionSortSearchList(Head,AuxList,NewAuxList),
		sortSearchListAux(Tail,SortedList,NewAuxList).
		
	insertionSortSearchList(Node,[],[Node]).
	insertionSortSearchList(sn(N1,B1,Ex1,G1,H1,M1),[sn(N2,B2,Ex2,G2,H2,M2)|Tail],[sn(N2,B2,Ex2,G2,H2,M2)|NewTail]):-
		Ex1 <> 0,
		insertionSortSearchList(sn(N1,B1,Ex1,G1,H1,M1),Tail,NewTail).
	insertionSortSearchList(sn(N1,B1,Ex1,G1,H1,M1),[sn(N2,B2,Ex2,G2,H2,M2)|Tail],[sn(N2,B2,Ex2,G2,H2,M2)|NewTail]):-
		Ex1 = 0,
		M1 > M2,
		insertionSortSearchList(sn(N1,B1,Ex1,G1,H1,M1),Tail,NewTail).
	%Here u could U the Name ... if using Visited List, or Use #Expan. if using Expansion List
	%Take care ... i always search with the M : Maths ... and i should check the Maths in the main Function and set it's value by the right parameter I am using, for ex : UCS : M is the G
	insertionSortSearchList(sn(N1,B1,Ex1,G1,H1,M1),[sn(N2,B2,Ex2,G2,H2,M2)|Tail],ConcatedList):-
		Ex1 = 0,  % if not equal 0 means it is Expanded so i'll put it last ... in the first stopping condition.
		M1 <= M2, % here i the M1 = M2, if using Alphabetical Order i should check the Names Also !!
		concateSearchList([sn(N1,B1,Ex1,G1,H1,M1),sn(N2,B2,Ex2,G2,H2,M2)],Tail,ConcatedList).

	printSearchList([]).
	printSearchList([sn(Name,B,Ex,G,H,M)|Tail]):-
		Ex <> 0,
		write("Name : ", Name,", Backtrack Expansion : ",B,", Expansion Number : ",Ex,", G : ",G,", H : ",H," and M : ",M),nl,
		printSearchList(Tail).
	printSearchList([sn(Name,B,Ex,G,H,M)|Tail]):-
		Ex = 0,
		write("Name : ", Name,", Backtrack Expansion : ",B,", Expansion Number : Fringe",", G : ",G,", H : ",H," and M : ",M),nl,
		printSearchList(Tail).
		
	memberSearchList(SearchNode,[SearchNode|_]).
	memberSearchList(SearchNode,[_|Tail]):-
		memberSearchList(SearchNode,Tail).
		
	createSearchNode(CName,sn(PName,_,PEx,PG,_,_),uniform,sn(CName,PEx,0,NewCost,CH,NewCost)):-
		node(CName,CH),
		relation(CName,Cost,PName),
		NewCost = PG+Cost.
	createSearchNode(CName,sn(PName,_,PEx,PG,_,_),greedy,sn(CName,PEx,0,NewCost,CH,CH)):-
		node(CName,CH),
		relation(CName,Cost,PName),	
		NewCost = PG+Cost.
	createSearchNode(CName,sn(PName,_,PEx,PG,_,_),aStar,sn(CName,PEx,0,NewCost,CH,NewMaths)):-
		node(CName,CH),
		relation(PName,Cost,CName),
		NewCost = PG+Cost,
		NewMaths = NewCost + CH.
		
	getLastExpansionNum(SearchList,LastExpansion):-
		getLastExpansionNumAux(SearchList,LastExpansion,0).
		
	getLastExpansionNumAux([],Last,Last).
	getLastExpansionNumAux([sn(_,_,Ex,_,_,_)|Tail],Last,Tmp):-
		Ex >= Tmp,
		getLastExpansionNumAux(Tail,Last,Ex).
	getLastExpansionNumAux([sn(_,_,Ex,_,_,_)|Tail],Last,Tmp):-
		Ex < Tmp,
		getLastExpansionNumAux(Tail,Last,Tmp).
		
		
%			Database

	rootNode("A").

	node("A",5).
	node("B",7).
	node("C",8).
	node("D",9).
	node("E",6).
	node("F",5).
	node("G",4).
	
	relation("A",3,"B").
	relation("A",4,"C").
	
	
	relation("B",5,"D").
	relation("B",6,"E").
	
	relation("C",7,"F").
	relation("C",8,"G").		
	

Goal

	createSearchNode("C",sn("A",0,0,10,5,15),aStar,What).

%	sortSearchList([sn("A",0,0,0,0,7),sn("B",0,0,0,0,6),sn("C",0,0,0,0,8)],What).

%	insertionSortSearchList(sn("C",0,0,3,2,6),[sn("A",0,0,5,0,5),sn("B",0,1,4,2,6)],What).
	
%	printSearchList([sn("A",0,0,5,0,5),sn("B",0,1,4,2,6),sn("C",0,2,3,4,7)]).
	
%	getChildren("C",What).
	
%	uniformCostSearch("B").