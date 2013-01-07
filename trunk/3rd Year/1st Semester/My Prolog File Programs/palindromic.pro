Domains
	iList = integer*.
Predicates
	nondeterm palindromic(iList).
	nondeterm reverse(iList,iList).
	nondeterm addToTail(integer,iList,iList).
Clauses

	addToTail(X,[],[X]).
	
	addToTail(X,[H|T],[H|NT]):-
		addToTail(X,T,NT).
		
		
	reverse([],[]):-
		!.
	reverse([H|T],List):-
		reverse(T,NewT),
		addToTail(H,NewT,List).
		
	palindromic(List):-
		reverse(List,List).

Goal
	palindromic([1,2,3,2,1]).