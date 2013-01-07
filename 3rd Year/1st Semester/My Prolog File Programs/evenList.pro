domains
	iList = integer*.
predicates
	nondeterm evenList(iList,iList).
clauses
	evenList([],[]).
	evenList([H|T],[H|ET]):-
		H mod 2 = 0,
		evenList(T,ET).
	evenList([H|T],ET):-
		H mod 2 = 1,
		evenList(T,ET).
goal
	evenList([1,2,3,4,5,6,7,8],What).