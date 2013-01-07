Domains
	iList=integer*
 
Predicates
	nondeterm del(integer,iList,iList)
	nondeterm delDup(iList,iList)

Clauses	delDup([],[]):-!.
	
	delDup([H|T],[H|L1]):-
		del(H,T,NL1),
		delDup(NL1,L1).

	del(_,[],[]):-!.

	del(X,[X|T],T1):-
		del(X,T,T1),!.
		
	del(X,[H|T],[H|T1]):-
		del(X,T,T1).

Goal
	delDup([1,2,3,2,3,4,5,7,4],List).