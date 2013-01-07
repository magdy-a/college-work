Domains
	iList = integer*.
Predicates
	nondeterm add_to_tail(integer,iList,iList).
	nondeterm split(iList,integer,iList,iList).
Clauses
	%add to tail
	add_to_tail(X,[],[X]).
	add_to_tail(X,[H|T],[H|NT]):-
		add_to_tail(X,T,NT).
	
	%split
	split(X,0,[],X):-
		!.
	split([H|T],Num,[H|Y],NewT):-
		New = Num - 1,
		split(T,New,Y,NewT).
		%add_to_tail(H,Y,NewY).

Goal
	split([1,2,3,4,5,6],2,What,What2).