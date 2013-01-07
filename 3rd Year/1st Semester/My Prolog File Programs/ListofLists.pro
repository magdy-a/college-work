Domains

	iList = integer*.
	iIList = iList*.
	
	
Predicates
	
	nondeterm fun(iIList,iList,iList).
	nondeterm avg(iIList,iList,iList).
	nondeterm getLast(iList,integer).
	nondeterm addLast(iList,integer,iList).
	nondeterm getSum(iList,integer).
	nondeterm getLength(iList,integer).
	nondeterm getAvg(iList,real).
	nondeterm printList(iList).
	
Clauses

	fun([],Res,Res):-
		printList(Res).
		
	fun([H|T],Aux,Res):-
		getLast(H,Element),
		addLast(Aux,Element,NewAux),
		fun(T,NewAux,Res).
		
	avg([],Res,Res).
	avg([H|T],Aux,Res):-
		getAvg(H,Element),
		addLast(Aux,Element,NewAux),
		avg(T,NewAux,Res).
		
	getSum([],0).
	getSum([H|T],NewSum):-
		getSum(T,Sum),
		NewSum = Sum + H.
		
	getLength([],0).
	getLength([_|T],NewLength):-
		getLength(T,Length),
		NewLength = Length + 1.
		
	getAvg([],0.0):-
		!.
	getAvg(List,Res):-
		getSum(List,Sum),
		getLength(List,Length),
		Res = Sum / Length.
		
	getLast([],0).
	getLast([H],H):-
		!.
	getLast([_|T],Res):-
		getLast(T,Res).
		
	addLast([],X,[X]).
	addLast([H|T],X,[H|Rest]):-
		addLast(T,X,Rest).
		
	printList([]):-
		nl.
	printList([H|T]):-
		write(H),
		write(" "),
		printList(T).
		
Goal
		
	avg([[1,2,3],[4,5,6],[]],[],What).
	
%	getSum([1,2,3],What).
%	getLength([1,2,3],What).
%	getAvg([1,2,3],What).
	
%	fun([[1,2,3],[4,5,6],[7,8,9]],[],What).
%	addLast([1,2,3],4,What).
%	getLast([1,2,3],What).
	