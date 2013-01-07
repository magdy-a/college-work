domains
	iList = integer*.
predicates
	nondeterm del(integer,iList,iList).
clauses
	del(_,[],[]).
	del(H,[H|T],T):-!.
	del(X,[H|T],[H|NT]):-
		del(X,T,NT).
goal
	del(4,[1,2,3,4,5,6],What).