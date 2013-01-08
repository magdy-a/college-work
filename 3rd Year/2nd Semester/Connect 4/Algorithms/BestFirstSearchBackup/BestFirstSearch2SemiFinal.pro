

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

	nondeterm bestFirstSearch(symbol,algorithm).
	
	nondeterm ucs(symbol,snList,algorithm).


%			SymbolList

	nondeterm enqueueList(sList,symbol,sList).
	nondeterm concateList(sList,sList,sList).
	
	nondeterm getChildren(symbol,sList).
	nondeterm getChildrenAux(symbol,sList,sList).	
	
	nondeterm member(symbol,sList).
		
	nondeterm printList(sList).
	

%			SearchNodeList

%				   (List  ,Element   ,Result).
	nondeterm enqueueSearchList(snList,searchNode,snList).
%                                  (List  ,Other ,Result).
	nondeterm concateSearchList(snList,snList,snList).
	
%				(List  ,Result).
	nondeterm sortSearchList(snList,snList).
%                                  (List  ,Result,[]    ).	
	nondeterm sortSearchListAux(snList,snList,snList).
%					 (Element   ,List  ,Result).
	nondeterm insertSortedSearchList(searchNode,snList,snList).
	
%				  (Element   ,List  ).What Question.
	nondeterm memberSearchList(searchNode,snList).
	
%			          (Name  ,Parent    ,Algo     ,Result    ).
	nondeterm createSearchNode(symbol,searchNode,algorithm,searchNode).
%                                     (Names,Parent    ,Algo     ,Result).
	nondeterm createSearchNodeList(sList,searchNode,algorithm,snList).
	nondeterm createSearchNodeListAux(sList,searchNode,algorithm,snList,snList).
%				     (SearchList,ret Largest ExpansionNum )	
	nondeterm getLastExpansionNum(snList,integer).
	nondeterm getLastExpansionNumAux(snList,integer,integer).
	
	nondeterm printSearchList(snList).
	
%	I should create a function that prints the List in an Order that representes the Expansion number of each of them.

	
%			Database

	rootNode(symbol).
	
	nondeterm node(symbol,integer).
	
	nondeterm relation(symbol,integer,symbol).

	
Clauses

%			MainFunctions

	bestFirstSearch(Symbol,uniform):-
		rootNode(Name),
		node(Name,H),
		ucs(Symbol,[sn(Name,0,0,0,H,H)],uniform).
	bestFirstSearch(Symbol,greedy):-
		rootNode(Name),
		node(Name,H),
		ucs(Symbol,[sn(Name,0,0,0,H,H)],greedy).
	bestFirstSearch(Symbol,aStar):-
		rootNode(Name),
		node(Name,H),
		ucs(Symbol,[sn(Name,0,0,0,H,H)],aStar).

	ucs(_Goal,[sn(_Goal,B,Ex,G,H,M)|Tail],_):-
		Ex = 0,
		getLastExpansionNum([sn(_Goal,B,Ex,G,H,M)|Tail],LastEx),
		NewEx = LastEx + 1,
		printSearchList([sn(_Goal,B,NewEx,G,H,M)|Tail]).
		
	ucs(_Goal,[sn(Name,B,Ex,G,H,M)|Tail],uniform):-
		Ex = 0,
		getLastExpansionNum([sn(Name,B,Ex,G,H,M)|Tail],LastEx),
		NewEx = LastEx + 1,
		
		getChildren(Name,ChildrenList),
		createSearchNodeList(ChildrenList,sn(Name,B,Ex,G,H,M),uniform,SearchList),
		
		concateSearchList([sn(Name,B,NewEx,G,H,M)|Tail],SearchList,UnsortedList),
		
		sortSearchList(UnsortedList,SortedList),
		
		ucs(_Goal,SortedList,uniform).
		
	ucs(_Goal,[sn(Name,B,Ex,G,H,M)|Tail],greedy):-
		Ex = 0,
		getLastExpansionNum([sn(Name,B,Ex,G,H,M)|Tail],LastEx),
		NewEx = LastEx + 1,
		
		getChildren(Name,ChildrenList),
		createSearchNodeList(ChildrenList,sn(Name,B,Ex,G,H,M),greedy,SearchList),
		
		concateSearchList([sn(Name,B,NewEx,G,H,M)|Tail],SearchList,UnsortedList),
		
		sortSearchList(UnsortedList,SortedList),
		
		ucs(_Goal,SortedList,greedy).

	ucs(_Goal,[sn(Name,B,Ex,G,H,M)|Tail],aStar):-
		Ex = 0,
		getLastExpansionNum([sn(Name,B,Ex,G,H,M)|Tail],LastEx),
		NewEx = LastEx + 1,
		
		getChildren(Name,ChildrenList),
		createSearchNodeList(ChildrenList,sn(Name,B,Ex,G,H,M),aStar,SearchList),
		
		concateSearchList([sn(Name,B,NewEx,G,H,M)|Tail],SearchList,UnsortedList),
		
		sortSearchList(UnsortedList,SortedList),
		
		ucs(_Goal,SortedList,aStar).
		

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
		write("in sortList"),nl,
		printSearchList([Head|Tail]),nl,
		insertSortedSearchList(Head,AuxList,NewAuxList),!,
		write("after"),nl,
		printSearchList(NewAuxList),nl,
		write("------------------------"),nl,
		sortSearchListAux(Tail,SortedList,NewAuxList),!.
		
	insertSortedSearchList(Node,[],[Node]).
	insertSortedSearchList(sn(N1,B1,Ex1,G1,H1,M1),[sn(N2,B2,Ex2,G2,H2,M2)|Tail],[sn(N2,B2,Ex2,G2,H2,M2)|NewTail]):-
		Ex1 <> 0,
		write("Sry Dude in InsertionSort : ",N1," Expansion : ",Ex1," is > 0"),nl,
		printSearchList([sn(N2,B2,Ex2,G2,H2,M2)|Tail]),nl,
		insertSortedSearchList(sn(N1,B1,Ex1,G1,H1,M1),Tail,NewTail).
	insertSortedSearchList(sn(N1,B1,Ex1,G1,H1,M1),[sn(N2,B2,Ex2,G2,H2,M2)|Tail],[sn(N2,B2,Ex2,G2,H2,M2)|NewTail]):-
		Ex1 = 0,
		Ex2 = 0,
		M1 > M2,
		insertSortedSearchList(sn(N1,B1,Ex1,G1,H1,M1),Tail,NewTail).
	%Here u could U the Name ... if using Visited List, or Use #Expan. if using Expansion List
	%Take care ... i always search with the M : Maths ... and i should check the Maths in the main Function and set it's value by the right parameter I am using, for ex : UCS : M is the G
	insertSortedSearchList(sn(N1,B1,Ex1,G1,H1,M1),[sn(N2,B2,Ex2,G2,H2,M2)|Tail],ConcatedList):-
		Ex1 = 0,  % if not equal 0 means it is Expanded so i'll put it last ... in the first stopping condition.
		Ex2 = 0,
		M1 <= M2, % here i the M1 = M2, if using Alphabetical Order i should check the Names Also !!
		concateSearchList([sn(N1,B1,Ex1,G1,H1,M1),sn(N2,B2,Ex2,G2,H2,M2)],Tail,ConcatedList).
	insertSortedSearchList(sn(N1,B1,Ex1,G1,H1,M1),[sn(N2,B2,Ex2,G2,H2,M2)|Tail],ConcatedList):-
		Ex1 = 0,  % if not equal 0 means it is Expanded so i'll put it last ... in the first stopping condition.
		Ex2 <>0,
		M1 > M2, % here i the M1 = M2, if using Alphabetical Order i should check the Names Also !!
		concateSearchList([sn(N1,B1,Ex1,G1,H1,M1),sn(N2,B2,Ex2,G2,H2,M2)],Tail,ConcatedList).
	insertSortedSearchList(sn(N1,B1,Ex1,G1,H1,M1),[sn(N2,B2,Ex2,G2,H2,M2)|Tail],ConcatedList):-
		Ex1 = 0,  % if not equal 0 means it is Expanded so i'll put it last ... in the first stopping condition.
		Ex2 <>0,
		M1 <= M2, % here i the M1 = M2, if using Alphabetical Order i should check the Names Also !!
		concateSearchList([sn(N1,B1,Ex1,G1,H1,M1),sn(N2,B2,Ex2,G2,H2,M2)],Tail,ConcatedList).
		
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
		
	createSearchNodeList(Names,Parent,uniform,List):-
		createSearchNodeListAux(Names,Parent,uniform,List,[]).
	createSearchNodeList(Names,Parent,greedy,List):-
		createSearchNodeListAux(Names,Parent,greedy,List,[]).
	createSearchNodeList(Names,Parent,aStar,List):-
		createSearchNodeListAux(Names,Parent,aStar,List,[]).
		
	createSearchNodeListAux([],_,_,List,List).
	createSearchNodeListAux([Child|Tail],Parent,uniform,List,AuxList):-
		createSearchNode(Child,Parent,uniform,ChildSearchNode),
		createSearchNodeListAux(Tail,Parent,uniform,List,[ChildSearchNode|AuxList]).
	createSearchNodeListAux([Child|Tail],Parent,greedy,List,AuxList):-
		createSearchNode(Child,Parent,greedy,ChildSearchNode),
		createSearchNodeListAux(Tail,Parent,greedy,List,[ChildSearchNode|AuxList]).
	createSearchNodeListAux([Child|Tail],Parent,aStar,List,AuxList):-
		createSearchNode(Child,Parent,aStar,ChildSearchNode),
		createSearchNodeListAux(Tail,Parent,aStar,List,[ChildSearchNode|AuxList]).
		
	getLastExpansionNum(SearchList,LastExpansion):-
		getLastExpansionNumAux(SearchList,LastExpansion,0).
		
	getLastExpansionNumAux([],Last,Last).
	getLastExpansionNumAux([sn(_,_,Ex,_,_,_)|Tail],Last,Tmp):-
		Ex >= Tmp,
		getLastExpansionNumAux(Tail,Last,Ex).
	getLastExpansionNumAux([sn(_,_,Ex,_,_,_)|Tail],Last,Tmp):-
		Ex < Tmp,
		getLastExpansionNumAux(Tail,Last,Tmp).
		
	printSearchList([]).
	printSearchList([sn(Name,B,Ex,G,H,M)|Tail]):-
		Ex <> 0,
		write("Name : ", Name,", Backtrack Expansion : ",B,", Expansion Number : ",Ex,", G : ",G,", H : ",H," and M : ",M),nl,
		printSearchList(Tail).
	printSearchList([sn(Name,B,Ex,G,H,M)|Tail]):-
		Ex = 0,
		write("Name : ", Name,", Backtrack Expansion : ",B,", Expansion Number : Fringe",", G : ",G,", H : ",H," and M : ",M),nl,
		printSearchList(Tail).
		
		
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

%	insertSortedSearchList(sn("A",2,1,0,5,5),[sn("C",1,0,4,8,12),sn("B",1,3,3,7,10)],What).

%	sortSearchList([sn("A",2,1,0,5,5),sn("C",1,0,4,8,12),sn("B",1,3,3,7,10)],What).

%	getLastExpansionNum([sn("A",0,1,0,5,5),sn("C",1,2,4,8,12),sn("B",1,3,3,7,10)],What).

%	createSearchNodeList(["B","C"],sn("A",0,1,0,5,5),aStar,What).	

	bestFirstSearch("B",aStar).

%	createSearchNode("C",sn("A",0,0,10,5,15),aStar,What).

%	sortSearchList([sn("A",0,0,0,0,7),sn("B",0,0,0,0,6),sn("C",0,0,0,0,8)],What).

%	insertSortedSearchList(sn("C",0,0,3,2,6),[sn("A",0,0,5,0,5),sn("B",0,1,4,2,6)],What).
	
%	printSearchList([sn("A",0,0,5,0,5),sn("B",0,1,4,2,6),sn("C",0,2,3,4,7)]).
	
%	getChildren("A",What).
	
%	uniformCostSearch("B").