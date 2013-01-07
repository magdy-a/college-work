Domains
	iList = integer*.
Predicates
	nondeterm del(integer,iList,iList).
	nondeterm insertall(integer,iList,iList).
	nondeterm perm(iList,iList).
Clauses
	del(X,[X|T],T).
	del(X,[H|T],[H|NT]):-
		del(X,T,NT).
		
	insertall(X,List,NewList):-
		del(X,NewList,List).
	
	perm([],[]):-
		!.
	perm([H|T],NewT):-
		perm(T,T1),
		insertall(H,T1,NewT).
	
Goal
	perm([1,2,3],What).