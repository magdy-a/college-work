Domains
	state = s(symbol,symbol,symbol,symbol).
Predicates
	nondeterm canget(state).
	nondeterm move(state,state).
Clauses
	canget(s(_,_,_,has)).
	canget(Step):-
		move(Step,NextStep),
		canget(NextStep).
	move(s(atdoor,onfloor,atwindow,hasnot),s(atmiddle,onfloor,atwindow,hasnot)):-
		write("Walk from atdoor to atmiddle \n").
	move(s(atmiddle,onfloor,atwindow,hasnot),s(atwindow,onfloor,atwindow,hasnot)):-
		write("Walk from atmiddle to atwindow \n").
	move(s(atwindow,onfloor,atwindow,hasnot),s(atmiddle,onfloor,atmiddle,hasnot)):-
		write("Push from atwindow to atmiddle \n").
	move(s(atmiddle,onfloor,atmiddle,hasnot),s(atmiddle,onbox,atmiddle,hasnot)):-
		write("Climb the box at middle \n").
	move(s(atmiddle,onbox,atmiddle,hasnot),s(atmiddle,onbox,atmiddle,has)):-
		write("Yuppy, you got it :) \n").
Goal
	canget(s(atdoor,onfloor,atwindow,hasnot)).
