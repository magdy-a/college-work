domains
	iList = integer*.
predicates
	nondeterm arrLength(iList,integer).
clauses
	arrLength([],0).
	arrLength([_|T],X):-
		arrLength(T,Y),
		X = Y + 1.
goal
	arrLength([1,2,3,4],What).