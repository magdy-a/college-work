Domains
	iList = integer*.
Predicates
	nondeterm prime(integer,integer,symbol).
	nondeterm takeNumber(integer,symbol).
Clauses

	takeNumber(X,Res):-
		Num = abs(X) - 1,
		prime(X,Num,Res).
	
	prime(_,Num,prime):-
		abs(Num) <= 1,
		!.	
		
	prime(X,Num,notPrime):-
		X mod Num = 0,
		!.
		
	prime(X,Num,Res):-
		X mod Num <> 0,
		New = Num - 1,
		prime(X,New,Res).

Goal
	takeNumber(-11,What).