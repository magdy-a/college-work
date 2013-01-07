Domains

	state = state(symbol, symbol, symbol, symbol).

Predicates

	nondeterm walk(symbol, symbol).
	nondeterm push(symbol, symbol).
	nondeterm move(state, state).
	nondeterm canget(state).
	nondeterm pos(symbol).

Clauses

	pos(atmiddle).
	pos(atwindow).
	pos(atdoor).

	walk(X,Y):-
		pos(X),
		pos(Y),
		X<>Y.
	
	push(X,Y):-
		pos(X),
		pos(Y),
		X<>Y.	

	move(state(atmiddle,onbox,atmiddle,hasnot),  state(atmiddle,onbox,atmiddle,has)):-
		write( "Grasp " ),nl.
	
	move(state(P,onfloor,P,H),  state(P,onbox,P,H)):-
		write( "Climb " ),nl.

	move(state(P1,onfloor,P1,H),  state(P2,onfloor,P2,H)):-
	  	push(P1,P2),
		write(P1, " PUSH " ,P2),nl.

	move(state(P1,onfloor,B,H),  state(P2,onfloor,B,H)):-
		walk(P1,P2),
		write(P1, " MOVE " ,P2),nl.
	  
	canget(state(_, _, _, has)).

	canget(S1):-
		move(S1, S2),
		canget(S2).
	  
 
Goal

	canget(state(atmiddle, onfloor, atdoor, hasnot)).  
  