Domains
	point = p(integer,integer).
	shape = rec(point,point); cir(point,integer); p(integer,integer).
Predicates
	nondeterm area(shape,real).
Clauses
	area(p(_,_),0).
	area(rec(p(X,Y),p(X1,Y1)),Res):-
		Width = abs(X-X1),
		Height = abs(Y-Y1),
		Res = Width * Height.
	area(cir(p(_,_),X),Res):-
		Res = 22 / 7 * X * X.
Goal
	area(cir(p(5,6),10),Res).