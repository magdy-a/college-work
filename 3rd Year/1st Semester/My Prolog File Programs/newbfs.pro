Domains

	slist=symbol*.
	
Predicates

	nondeterm parent(symbol,symbol).
	nondeterm getChild(symbol,slist,slist,slist).
	nondeterm conc(slist,slist,slist).
	nondeterm member(symbol,slist).
	nondeterm getc(symbol,slist,slist,slist,slist).
	nondeterm addlast(symbol,slist,slist).
	nondeterm bfs(symbol,symbol).
	nondeterm bfsaux(symbol,slist,slist).
	nondeterm printList(slist).

Clauses
%        ahmed
%   mona         ali
%magdy mhana  alaa ehab
%
	parent(ahmed,mona).
	parent(ahmed,ali).
	parent(mona,magdy).
	parent(mona,mhana).
	parent(ali,alaa).
	parent(ali,ehab).
	parent(mona,ali).


			%bfs(root,goal),bfsaux(goal,list betbda2 men el root).
	bfs(X,Y):-
		bfsaux(Y,[X],[]),!.
		
			%law la2a el goal awel element fel list eshta 
	bfsaux(X,[X|_],Closed):-
		!,
		printList(Closed).
			%law mala2ash el goal awel element fel list ha3mel delete x w ageeb el children betoo3 x w a3melhom append fel list
	bfsaux(G,[F|L],Closed):-
		getChild(F,ChildList,Closed,L),
		conc(L,ChildList,NewList),
		addlast(F,Closed,NewClosed),
		bfsaux(G,Newlist,NewClosed).
		
			% how to get all possible solution in a list ?!! should i loop it with fixed List and insert every solution ?!!			
	getChild(X,L1,Closed,Open):-
		getc(X,L1,[],Closed,Open),
		!. 
	
	getc(X,L,L1,Closed,Open):-
		parent(X,Y),
		not(member(Y,L1)),
		not(member(Y,Closed)),
		not(member(Y,Open)),
		addlast(Y,L1,L2),
		getc(X,L,L2,Closed,Open).
	getc(_,L,L,_,_):-!.
	
	
	addlast(X,[],[X]):-!.
	addlast(X,[H|T],[H|T2]):-addlast(X,T,T2).
	
	conc([],List2,List2).
	conc([H1|T1],List2,[H1|List]):-
		conc(T1,List2,List).
		
        member(X,[X|_]):-!.
        member(X,[_|L]):-
        	member(X,L).
        
        printList([]):-!.
        printList([H|T]):-
        	write(H),
        	nl,
        	printList(T).
        
Goal

	bfs(ahmed,ehab).