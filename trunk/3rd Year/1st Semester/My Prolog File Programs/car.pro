predicates
	nondeterm car(symbol,symbol,integer).
	nondeterm color(symbol,symbol).
	nondeterm buy(symbol,integer).
clauses
	car(fiat,green,20000).
	car(opel,black,30000).
	car(mercedes,green,40000).
	car(honda,red,25000).
	
	color(red,nice).
	color(green,nice).
	color(black,wonderful).
	
	buy(M,P):-
		car(M,C,P),
		!,
		color(C,nice),
		P <= 25000.
	buy(M,P):-
		car(M,C,P),
		color(C,wonderful).
goal
	buy(What,Price).