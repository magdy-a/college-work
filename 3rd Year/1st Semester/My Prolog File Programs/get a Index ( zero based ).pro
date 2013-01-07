domains
	iList = integer*.
predicates
	nondeterm get(integer,iList,integer).
clauses
	get(X,[H|_],H):-
		X = 0.
	get(X,[_|T],Y):-
		NewX = X - 1,
		get(NewX,T,Y).
goal
	get(3,[1,2,3,4,5],What).
		