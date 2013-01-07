predicates
	nondeterm fact(integer,integer).
clauses
	fact(0,1):-!.
	fact(X,Y):-
		NewX = X-1,
		fact(NewX,Y1),Y = X * Y1.
goal
	fact(4,What).