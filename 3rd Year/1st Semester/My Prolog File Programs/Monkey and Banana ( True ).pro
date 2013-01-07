domains
state=s(symbol,symbol,symbol,symbol).
predicates
nondeterm canget(state).
nondeterm move(state,state).
nondeterm walk(symbol,symbol).
nondeterm push(symbol,symbol).
clauses


%grasp 

%climb
 move(s(P1,onfloor,P1,hasnot),s(P1,onbox,P1,has)):-P1=onmiddle,write("climb, Ohhhh ... found it\n"),nl.

%push
move(s(P1,onfloor,P1,H),s(P2,onfloor,P2,H)):-push(P1,P2),nl.

%walk
move(s(P1,onfloor,B,H),s(P2,onfloor, B,H)):-walk(P1,P2),nl.


push(ondoor,onmiddle):-write("push from ondoor to onmiddle \n"),nl.
push(onwindow,onmiddle):-write("push from onwindow to onmiddle \n"),nl.



walk(ondoor,onmiddle):-write("walk from ondoor to onmiddle\n"),nl.
walk(onmiddle,onwindow):-write("walk from onmiddle to onwindow\n"),nl.
walk(onwindow,onmiddle):-write("walk from onwindow to onmiddle\n"),nl.
walk(onmiddle,ondoor):-write("walk from onmiddle to ondoor\n"),nl.



canget(s(_,_,_,has)).
canget(S1):-move(S1,S2),canget(S2).
goal
canget(s(ondoor,onfloor,onwindow,hasnot)).


