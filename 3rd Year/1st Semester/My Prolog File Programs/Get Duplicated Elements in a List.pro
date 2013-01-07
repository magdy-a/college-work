Domains
	iList = integer*.
Predicates
	nondeterm member(integer,iList).
	nondeterm getDup(iList,iList).
Clauses
	%member
	member(X,[X|_]).
	member(X,[_|T]):-
		member(X,T).
		
	
	%get Duplicated Values
	getDup([],[]).
	getDup([H|T],[H|NT]):-
		member(H,T),
		getDup(T,NT).
	getDup([H|T],NT):-
		not(member(H,T)),
		getDup(T,NT).
Goal
	getDup([1,2,3,1,2,3,4],What).