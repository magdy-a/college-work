Database
	xPositive(symbol).
	xNegative(symbol).
Predicates
	nondeterm run.
	nondeterm animal(symbol).
	nondeterm has_it(symbol).
	nondeterm is_it(symbol).
	nondeterm positive(symbol).
	nondeterm ask(symbol,char).
	nondeterm push(symbol,char).
Clauses
	%============================ Run ============================================
	run:-
		animal(Animal),
		write("Animal might be : ", Animal, "\n").
	run:-
		write("Hurrraaa, you have just crashed the program!\n").
	%============================ Animal ============================================
	animal(stupid):-
		has_it(sha3r),
		has_it(tail),
		is_it(tall).
	animal(myKitty):-
		has_it(kersh),
		has_it(myrope),
		is_it(naughty).
	%============================ Has_it ============================================
	has_it(Something):-
		positive(Something).
	%============================ Is_it ============================================
	is_it(Thing):-
		positive(Thing).
	%============================ Ask ============================================
	ask(The_Thing,Answer):-
		write("Has it : ", The_Thing,"\n"),
		readln(BlaBla),
		frontchar(BlaBla,B,_),
		push(The_Thing,B),
		Answer = B.
	%============================ Save ============================================
	push(Thing,'y'):-
		assert(xPositive(Thing)).
	push(Thing,'n'):-
		assert(xNegative(Thing)).
	%============================ Positive ============================================
	positive(Something):-
		xPositive(Something),
		!.
	positive(Something):-
		not(xNegative(Something)),
		ask(Something,'y').
Goal
	run.