Predicates
	
	fib(integer,integer).
	
Clauses

	fib(0,1):-
		!.
	fib(1,1):-
		!.
	fib(N,Return):-
		N1 = N - 1,
		N2 = N - 2,
		fib(N1,R1),
		fib(N2,R2),
		Return = R1 + R2.
		
Goal

	fib(38,What).