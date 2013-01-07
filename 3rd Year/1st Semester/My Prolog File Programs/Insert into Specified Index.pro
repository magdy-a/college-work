Domains
	iList = integer*.
Predicates
	nondeterm insert(integer,integer,iList,iList).
Clauses

	insert(Num,_,[],[Num]):-!.
	
	insert(Num,0,T,[Num|T]):-!.
	
	insert(Num,X,[H|T],[H|NT]):-
		NewX = X - 1,
		insert(Num,NewX,T,NT).
Goal
	insert(5,4,[1,2,3,4],What).