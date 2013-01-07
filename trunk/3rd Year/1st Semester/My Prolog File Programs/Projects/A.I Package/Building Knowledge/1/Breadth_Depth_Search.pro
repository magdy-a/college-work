Domains

	sList = symbol*.
	
Predicates

	dequeue(sList,symbol,sList).
	
	nondeterm enqueue(sList,symbol,sList).
	
	nondeterm concatenate(sList,sList,sList).
	
	nondeterm member(sList,symbol).
	
	nondeterm relate(symbol,symbol).
	
	rootNode(symbol).
	
	nondeterm breadthFirstSearch(symbol).
	
	nondeterm bfs(symbol,sList,sList).
	         %bfs(goal,open,closed).
	         
	nondeterm depthFirstSearch(symbol).
	
	nondeterm dfs(symbol,sList,sList).
	         
	nondeterm getChildren(symbol,sList).
	
	nondeterm getChildrenAux(symbol,sList,sList).
	         
	nondeterm printSymbolList(sList).	   
	
Clauses
	
	dequeue([H|T],H,T).
		
	enqueue([],X,[X]).
	enqueue([H|T],X,[H|NewT]):-
		enqueue(T,X,NewT).
		
	concatenate([],List,List).
	concatenate([H|T],List,[H|Return]):-
		concatenate(T,List,Return).
		
	member([X|_],X).
	member([_|T],X):-
		member(T,X).
		
	breadthFirstSearch(Symbol):-
		rootNode(RootNode),
		bfs(Symbol,[RootNode],[]).
		
	bfs(Symbol,[Symbol|_],ClosedList):-
		enqueue(ClosedList,Symbol,FullSearchList),
		printSymbolList(FullSearchList).
		
	bfs(Symbol,OpenList,ClosedList):-
	
		dequeue(OpenList,Head,Rest),%dequeue
		
		getChildren(Head,List),%get Children
		
		concatenate(Rest,List,NewOpenList),%concatenate children at end
		
		enqueue(ClosedList,Head,NewClosedList),
		
		bfs(Symbol,NewOpenList,NewClosedList).
		
	depthFirstSearch(Symbol):-
		rootNode(RootNode),
		dfs(Symbol,[RootNode],[]).
	
	dfs(Symbol,[Symbol|_],ClosedList):-
		enqueue(ClosedList,Symbol,FullSearchList),
		printSymbolList(FullSearchList).
		
	dfs(Symbol,OpenList,ClosedList):-
	
		dequeue(OpenList,Head,Rest),%dequeue
		
		getChildren(Head,List),%get Children
		
		concatenate(List,Rest,NewOpenList),%concatenate children at end
		
		enqueue(ClosedList,Head,NewClosedList),
		
		dfs(Symbol,NewOpenList,NewClosedList).
		
	getChildren(Symbol,List):-
		getChildrenAux(Symbol,List,[]),
		!.%why did i need the cut here ??!
		
	getChildrenAux(Symbol,List,ListAux):-
		relate(Symbol,Relation),
		not(member(ListAux,Relation)),%when is a member in the list, this means that it finished the first loop and all matches as well.
		enqueue(ListAux,Relation,NewListAux),
		getChildrenAux(Symbol,List,NewListAux).
	getChildrenAux(_,List,List):- !.
		
	printSymbolList([]).
	printSymbolList([H|T]):-
		write(H),nl,
		printSymbolList(T).
		
	rootNode("A").
		
	relate("A","B").
	relate("A","C").
	
	relate("B","D").
	relate("B","E").
	
	relate("C","F").
	relate("C","G").
		
Goal
	
	depthFirstSearch("F").
	
%	breadthFirstSearch("F").
	
%	concatenate(["A","B","C"],["D","E","F"],What).
	
%	getChildren("B",What).
	
%	dfs("A",["A"],["A","B","C","D"]).