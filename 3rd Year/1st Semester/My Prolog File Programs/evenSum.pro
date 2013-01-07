domains
	iList = integer*.
predicates
	nondeterm evenSum(iList,integer).
clauses
	evenSum([],0).
	evenSum([H|T],Sum):-
		H mod 2 = 0,
		evenSum(T,NSum),
		Sum = H + NSum.
	evenSum([H|T],Sum):-
		H mod 2 = 1,
		evenSum(T,NSum),
		Sum = NSum.
goal
	evenSum([1,2,3,4,5,6,7,8],Sum).