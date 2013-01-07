%			ThnQ u Aymna :)
Domains
	sList = symbol*.
Predicates
	nondeterm member(symbol,sList).
	nondeterm reverse(sList,sList,sList).
	nondeterm flight(symbol,symbol).
	nondeterm find(symbol,symbol,sList).
	nondeterm findAux(symbol,symbol,sList,sList).
Clauses
	member(X,[X|_]):-!.
	member(X,[_|T]):-
		member(X,T).
		
	reverse([],Acc,Acc).
	reverse([X|Y],Z,Acc):-
		reverse(Y,Z,[X|Acc]).
		
	flight(omaha,chicago).
	flight(omaha, denven). 
	flight(denven,eLzhra).
	flight(eLzhra,abas).
	
	find(A,B,List):-
		findAux(A,B,[A],New),reverse(New,List,[]).
		
	findAux(A,B,Visited,[B|Visited]):-
		flight(A,B). %direct
	findAux(A,B,Visited,New):-
		flight(A,C),
		not(member(C,Visited)), %go search
		findAux(C,B,[C|Visited],New).
Goal
	find(omaha,abas,List).