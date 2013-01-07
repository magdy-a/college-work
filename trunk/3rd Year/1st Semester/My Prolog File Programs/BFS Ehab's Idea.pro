Domains

	slist=symbol*.
	
Predicates

	nondeterm parent(symbol,symbol).
	nondeterm getChild(symbol,slist).
	nondeterm conc(slist,slist,slist).
	nondeterm member(symbol,slist).
	nondeterm getc(symbol,slist,slist).
	nondeterm addlast(symbol,slist,slist).
	nondeterm bfs(symbol,symbol).
	nondeterm bfsaux(symbol,slist).

Clauses
%        ahmed
%   mona         ali
%magdy mhana  3alaa ehab
%
	parent(ahmed,mona).
	parent(ahmed,ali).
	parent(mona,magdy).
	parent(mona,mhana).
	parent(ali,alaa).
	parent(ali,ehab).


			%bfs(root,goal),bfsaux(goal,list betbda2 men el root).
	bfs(X,Y):-
		bfsaux(Y,[X]),!.
			%law la2a el goal awel element fel list eshta 
	bfsaux(X,[X|_]):-
		!.
			%law mala2ash el goal awel element fel list ha3mel delete x w ageeb el children betoo3 x w a3melhom append fel list
	bfsaux(G,[F|L]):-
		getChild(F,ChildList),
		conc(L,ChildList,NewList),write(F),
		nl,
		bfsaux(G,Newlist).
		
	getChild(X,L):-getc(X,L,[]),!. % how to get all possible solution in a list ?!! should i loop it with fixed List and insert every solution ?!!	
	
	
	getc(X,L,L1):-parent(X,Y),not(member(Y,L1)),addlast(Y,L1,L2),getc(X,L,L2).
	getc(_,L,L):-!.
	
	
	addlast(X,[],[X]):-!.
	addlast(X,[H|T],[H|T2]):-addlast(X,T,T2).
	
	conc([],List2,List2).
	conc([H1|T1],List2,[H1|List]):-
		conc(T1,List2,List).
		
        member(X,[X|_]):-!.
        member(X,[_|L]):-member(X,L).
        
        
        
Goal
bfs(ahmed,abbas).