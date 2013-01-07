Domains
	iList = integer*.
Predicates
	nondeterm drop(iList,iList,integer,integer).
	nondeterm d(iList,integer,iList).
Clauses

	d(X,Num,Y):-
		drop(X,Y,Num,1).%assign the Index by 1
		
	
	drop([],[],_,_).
	
	drop([_|T],NT,Num,Index):-
		Index mod Num = 0,
		NewIndex = Index + 1,
		drop(T,NT,Num,NewIndex).
		
	drop([H|T],[H|NT],Num,Index):-
		Index mod Num <> 0,
		NewIndex = Index + 1,
		drop(T,NT,Num,NewIndex).
		
Goal
	d([1,2,3,4,5,6,7,8,9,10,11,12,13],3,What).