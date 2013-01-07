domains
	iList = integer*.
predicates
	nondeterm addToHead(integer,iList,iList).
	nondeterm addToTail(integer,iList,iList).
clauses
	addToHead(X,T,[X|T]).
	addToTail(X,[],[X]).
	addToTail(X,[H|T],[H|NT]):-
		addToTail(X,T,NT).
goal
	addToTail(5,[1,2,3,4],What).