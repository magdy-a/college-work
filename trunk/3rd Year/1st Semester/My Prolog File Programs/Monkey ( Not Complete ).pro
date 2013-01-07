Domains
	state = s(symbol,symbol,symbol,symbol).
Predicates
	nondeterm canget(state).
	nondeterm move(state,state).
	nondeterm walk(symbol,symbol).
	nondeterm push(symbol,symbol).
Clauses
	%grasp
	move(s(at_middle,on_box,at_middle,hasnot),s(on_middle,on_box,at_middle,has)):-
	write("grasp\n").
	
	
	%climb
	move(s(P1,on_floor,P1,hasnot),s(P1,on_box,P1,hasnot)):-
	write("climb\n").
	
	
	%move
	move(s(Pos1,on_floor,Pos1,hasnot),s(Pos2,on_floor,Pos2,hasnot)):-  % to be like the section, but the right implementation is (on_floor) not a variable ( OnOrNot ).
		push(Pos1,Pos2),
		write("Push from ",Pos1," to ",Pos2,"\n").
	move(s(Pos1,OnOrNot,Pos1,hasnot),s(Pos2,OnOrNot,Pos2,hasnot)):-  % to be like the section, but the right implementation is (on_floor) not a variable ( OnOrNot ).
		walk(Pos1,Pos2),
		write("Walk from ",Pos1, " to ",Pos2,"\n").
	
	
	%push
	push(at_door,at_middle):-
		write("Push from at_door to at_middle\n").
	push(at_window,at_middle):-
		write("Push from at_window to at_middle\n").
	
	%walk
	walk(at_door,at_middle):-
		write("Walk from at_door to at_middle\n").
	walk(at_middle,at_window):-
		write("Walk from at_middle to at_window\n").
		
		
	%canget
	canget(s(_,_,_,has)):-
		write("Got the Banana, Horraaaa\n").
	canget(State1):-
		move(State1,State2),
		canget(State2).
Goal
	canget(s(at_door,on_floor,at_middle,hasnot)).
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	