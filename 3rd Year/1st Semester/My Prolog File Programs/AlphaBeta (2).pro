Domains

	node = n(symbol,real,real,player).
	player=min;max.
	nlist=node*.

Predicates

	nondeterm alphabeta(node,real,real).
	nondeterm foreach(real,real,real,nlist,player).
	nondeterm alphavalue(real,real,real,node).
	nondeterm betavalue(real,real,real,node).
	nondeterm getchildern(symbol,nlist).
	arc(node,node).
	nondeterm run.
	nondeterm extend(node,nlist).

Clauses
	
	getchildren(Parent,[H|T]):- 
		arc(Parent,NewChild),
		Parent = [NewChild,H|T].
		
	extend(Parent,Childrenlist):- 
		findall(Parent,getchildren(Parent,Childrenlist),Childrenlist).
	
	alphabeta(n(Name,0,HH,min),_,Beta):- 
		Beta = HH.
	alphabeta(n(Name,0,HH,max),Alpha,_):- 
		Alpha = HH.
	
	alphabeta(node(Name,_,_,Player),Alpha,Beta):-
		getchildern(Name,List),
		foreach(Alpha,Beta,Bool,List,Player).

	alphavalue(Alpha,Beta,Myboll,Child):-
		Alpha = max(Alpha,alphabeta(Child,Depth-1,Alpha,Beta,min)),
		Beta <= Alpha,
		Myboll = 1.
		
	betavalue(Alpha,Beta,Myboll,Child):-
		Beta = min(Beta,alphabeta(Child,Depth-1,Alpha,Beta,max)),
		Beta <= Alpha,
		Myboll = 1.


	foreach(_,_,1,_,_).
	foreach(_,_,_,[],_).
	foreach(Alpha,Beta,0,[H|T],max):-
		alphavalue(Alpha,Beta,0,H),
		foreach(Alpha,Beta,0,[H|T],min).
	foreach(Alpha,Beta,0,[H|T],min):-
		alphavalue(Alpha,Beta,0,H),
		foreach(Alpha,Beta,0,[H|T],max).
		
	arc(b,d).
	arc(b,e).
	arc(e,f).
	arc(e,g).

Goal
	
	run.