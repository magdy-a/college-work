domains
	iList = integer*.
predicates
	nondeterm sum(iList,integer).
clauses
	sum([],0).
	sum([H|T],X):-
		sum(T,Y),
		X = H + Y.
goal
	sum([1,2,3],What).