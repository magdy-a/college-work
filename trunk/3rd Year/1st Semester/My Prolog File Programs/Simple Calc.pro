predicates
	nondeterm operation(integer,integer,integer,integer).
	nondeterm check(integer).
	nondeterm run.
clauses
	run:-
		write("\n","*************Welcome To My Claculator***************","\n"),
		write("Enter 1st Number : ","\n"),readint(X),
		write("Enter 2nd Number : ","\n"),readint(Y),
		write("Press 1 to add, 2 to subtract, 3 to multiply","\n","Enter your choice : "),readint(C),
		check(C),
		operation(C,X,Y,Z),
		write("\n","The result is : ","\n",Z,"\n"),
		write("\n","Do you want to continue ( y / n ) ? : ", "\n"),
		readchar(CH),
		CH = 'y',
		run,
		!.
	run.
	
	check(1):-
	!.
	check(2):-
	!.
	check(3):-
	!.
	check(_):-
		write("Invalid choice !!", "\n"),
		run.
	
	operation(1,X,Y,Z):-
		Z = X + Y,
		!.
	operation(2,X,Y,Z):-
		Z = X - Y,
		!.
	operation(3,X,Y,Z):-
		Z = X * Y,
		!.
goal
	run.