predicates
	nondeterm power(integer,integer,integer).
clauses
	power(_,0,1):-!.
	power(Num,Pow,Res):-
		NewPow = Pow - 1,
		power(Num,NewPow,NewResult),
		Res = NewResult * Num.
		
	
goal
	power(15,2,Result).
	