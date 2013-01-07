predicates
	nondeterm max(integer,integer,integer).
clauses
	max(X,Y,X):-
		X >= Y,!.
	max(_,Y,Y).
goal
	max(0,1,What).