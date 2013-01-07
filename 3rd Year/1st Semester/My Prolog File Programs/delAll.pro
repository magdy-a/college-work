domains
	iList = integer*.
predicates
	nondeterm delAll(integer,iList,iList).
clauses
	delAll(_,[],[]).
	delAll(H,[H|T],NT):-!,
		delAll(H,T,NT).
	delAll(X,[H|T],[H|NT]):-
		delAll(X,T,NT).
goal
	delAll(4,[1,2,3,4,5,4,6,4,7],What).