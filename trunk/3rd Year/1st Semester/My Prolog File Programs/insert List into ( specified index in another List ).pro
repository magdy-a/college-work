Domains
	iList = integer*.
Predicates
	nondeterm iLIL(iList,integer,iList,iList).
	nondeterm append(iList,iList,iList).
Clauses
	%append
	append([],X,X).
	append([H|T],X,[H|NT]):-
		append(T,X,NT).
	
	%insert List Into List ----- the integer represents the last index you will start from 
	%				like i want to insert 3 after [1,2] .. after 2 i'll insert 3
	%				it will be in index ( 2 ) 
	%				iLIL([3],2,[1,2],What).
	iLIL(X,0,Y,Res):-
		append(X,Y,Res).
	iLIL(X,Num,[H|T],[H|Res]):-
		New = Num - 1,
		iLIL(X,New,T,Res).
	
Goal
	%iLIL([3],2,[1,2],What).
	iLIL([8,9,10],7,[1,2,3,4,5,6,7,11,12,13],What).