Domains
	iList = integer*.
Predicates
	nondeterm sumList(iList,integer).
	nondeterm lenList(iList,integer).
	nondeterm avgList(iList,real).
Clauses
	sumList([],0).
	sumList([H|T],Res):-
		sumList(T,NewRes),
		Res = NewRes + H.

	lenList([],0).
	lenList([_|T],Res):-
		lenList(T,NewRes),
		Res = NewRes + 1.
		
	avgList([],0).
	avgList(List,Res):-
		sumList(List,Sum),
		lenList(List,Len),
		Res = Sum / Len.
Goal
	avgList([1,2,3,4,5],What).