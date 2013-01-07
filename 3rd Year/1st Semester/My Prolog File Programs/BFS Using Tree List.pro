Domains

	tree = t(tree,integer,tree);null
	tList = tree*.
	
Predicates

	nondeterm bfs(tList,integer).
	nondeterm getChildren(tree,tList).
	nondeterm getLength(tList,integer).
	nondeterm addLast(tList,tree,tList).
	nondeterm conc(tList,tList,tList).
	nondeterm delFirstItem(tList,tList).
	nondeterm getRootValue(tree,integer).
	
Clauses
	
	getChildren(t(L,_,R),[L,R]).
	
	getLength([],0).
	getLength([_|T],NewLen):-
		getLength(T,Len),
		NewLen = Len + 1.
		
	addLast([H],X,[H,X]).
	addLast([H|T],X,[H|NewT]):-
		addLast(T,X,NewT).
		
	conc([],Tree2,Tree2).
	conc([H1|T1],Tree2,[H1|TmpTree]):-
		conc(T1,Tree2,TmpTree).
		
	delFirstItem([_|T1],T1).
	
	getRootValue(t(_,X,_),X).
	
	bfs( [ t(_,X,_) | _] , X ):- write("Goal ", X),nl.
	bfs( [ H | T ] , X ):-
		getRootValue(H,Int),
		write("Item ", Int),nl,
		getChildren(H,FirstChildInList),
		conc(T,FirstChildInList,List),
		bfs(List,X).
		
goal

	bfs([t(t(t(null, 1, null), 3, t(null, 4, null)), 5, t(t(null, 7, null), 8, t(t(null, 9, null), 11, null)))],11).