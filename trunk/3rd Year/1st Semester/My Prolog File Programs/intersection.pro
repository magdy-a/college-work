Domains
	iList = integer*.
Predicates
	nondeterm member(integer,iList).
	nondeterm x(iList,iList,iList).
Clauses
	
	member(X,[X|_]).
	member(X,[_|T]):-
		member(X,T).
	
	x([],_,[]):-!.
	x(_,[],[]):-!.
	x([],[],[]):-!.
	
	x([H|T],List,[H|NewList]):-
		member(H,List),
		not(member(H,T)),
		x(T,List,NewList),
		!.
	x([_|T],List,NewList):-
		x(T,List,NewList).

Goal
	x([1,2,3,4,5,6,7,8,9,10],[1,10,20],What).