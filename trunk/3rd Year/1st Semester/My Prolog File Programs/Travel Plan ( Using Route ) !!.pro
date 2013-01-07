Domains
	iList = symbol*.
Predicates
	nondeterm flight(symbol,symbol).
	nondeterm route(symbol,symbol,iList).
	nondeterm route(symbol,symbol,iList,iList).
	nondeterm member(symbol,iList).
Clauses
	%member
	member(X,[X|_]).
	member(X,[_|T]):-
		member(X,T).
	
	%flight
	flight(omaha, chicago).
	flight(omaha, denver).
	flight(chicago, denver).
	flight(chicago, los_angeles).
	flight(chicago, omaha).
	flight(denver, los_angeles).
	flight(denve, omaha).
	flight(los_angeles, chicago).
	flight(los_angeles, denver).
	
	%route
	route(City1,City2,List):-
		route(City1,City2,List,[]).
	route(City1,City2,[City1,City2],List):-
		flight(City1,City2),
		not(member(City2,List)).
	route(City1,City2,[City1|Rest],List):-
		NList = [City1|List],
		flight(City1,City3),
		not(member(City3,List)),
		route(City3,City2,Rest,NList).
Goal
	route(chicago, denver, List).