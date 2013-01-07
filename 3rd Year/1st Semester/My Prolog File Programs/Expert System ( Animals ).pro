database - animalsBD
	xPositive(symbol,symbol).
	xNegative(symbol,symbol).
	
predicates
	nondeterm animal(symbol).
	nondeterm it_is(symbol).
	nondeterm positive(symbol,symbol).
	nondeterm ask(symbol,symbol,char).
	nondeterm remember(symbol,symbol,char).
	nondeterm run.
clauses
	
	animal(tiger):-
		it_is(mammal),
		positive(has,tawny_Color),
		positive(has,dark_Strips).
	animal(cheetah):-
		it_is(mammal),
		positive(has,tawny_Color),
		positive(has,dark_Spots).
	
	it_is(mammal):-
		positive(has,hair).
	it_is(ugulate):-
		positive(has,hooves).

	positive(X,Y):-
		xPositive(X,Y),!.
	positive(X,Y):-
		not(xNegative(X,Y)),
		ask(X,Y,'y').
		
	ask(X,Y,R):-
		write(X," it ",Y , " ? "),
		readln(Reply),
		frontchar(Reply,Z,_),
		remember(X,Y,Z), % here i assert ( Z ) that i take from the user
		R = Z. % then check ( R ) is same as Z that user Entered .. then return yes, else return false
		
	remember(X,Y,'y'):-
		assert(xPositive(X,Y)).
	remember(X,Y,'n'):-
		assert(xNegative(X,Y)).
		
	run:-
		animal(X),write(X),nl.
	run:-
		write("Unknown Animal !!"),nl.
goal	
	run.	