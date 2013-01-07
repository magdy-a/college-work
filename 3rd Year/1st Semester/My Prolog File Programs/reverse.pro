Domains
	iList = integer*.
Predicates
	nondeterm reverse(iList,iList).
	nondeterm addToTail(integer,iList,iList).
Clauses

	addToTail(X,[],[X]).
	
	addToTail(X,[H|T],[H|NT]):-
		addToTail(X,T,NT).
		
		
	reverse([],[]):-
		!.
	reverse([H|T],List):-
		reverse(T,NewT),
		addToTail(H,NewT,List).

Goal
	reverse([1,2,3,4],What).