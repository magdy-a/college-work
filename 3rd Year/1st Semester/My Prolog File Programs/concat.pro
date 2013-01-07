domains
	iList = integer*.
predicates
	nondeterm con(iList,iList,iList).
clauses
	con([],Rest,Rest).
	con([H|T],Rest,[H|NT]):-
		con(T,Rest,NT).
goal
	con([1,2,3],[4,5,6],What).