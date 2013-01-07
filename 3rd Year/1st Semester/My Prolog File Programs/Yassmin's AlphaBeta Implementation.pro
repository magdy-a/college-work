Domains

	ilist = node*.
	lofls = ilist*.
	Player = min;max.
	
Predicates


	nondeterm dfs(lofls,symbol,ilist).
	nondeterm extend(ilist,lofls).
	nondeterm append(lofls,lofls,lofls).
	nondeterm sort(lofls,lofls).
	nondeterm swap(lofls,lofls).

	nondeterm arc(symbol,symbol,integer).
	nondeterm foreachild(lofls,integer,integer,integer,integer).

	nondeterm alphabeta(node,integer,integer,integer,Player).
	nondeterm alphavalue(ilist,lofls,integer,integer,integer).
	nondeterm betavalue(ilist,lofls,integer,integer,integer).

	nondeterm g(ilist,integer).
	nondeterm getchildren(ilist,symbol,ilist).

	nondeterm run.

Clauses

	node(h,3).
	node(i,3).
	node(j,3).
	
	arc(a,b,1).
	
	arc(b,d,1).
	arc(b,e,2).
	
	arc(d,h,1).
	arc(d,i,1).
	arc(e,j,1).
	arc(e,k,1).
	

	getchildren(J,NNode,Npath):- 
		arc(NNode,Newnode,_),
		J = [Newnode,NNode|Npath].

	extend([H|Npath],Newpaths):- 
		findall(J,getchildren(J,H,Npath),Newpaths).


	foreachild([X|XL],Alphaprnt,Betaprnt,Depth,1):-
		Depth = Depth - 1,
		alphavalue(X,XL,Alphaprnt,Betaprnt,Depth).
	foreachild([X|XL],Alphaprnt,Betaprnt,Depth,0):-
		Depth = Depth - 1,
		alphavalue(X,XL,Alphaprnt,Betaprnt,Depth).
	betavalue([M|_],XL,Alphaprnt,Betaprnt,Depth):- 
		Betaprnt = min(Betaprnt,alphabeta([[M]],Depth,Alpha,Betach,!Player),
		Betaprnt > Alphaprnt,
		betavalue(TM,Betaprnt)).
	alphavalue([M|_],XL,Alphaprnt,Betaprnt,Depth):-
		Alphaprnt = max(Alphaprnt,alphabeta([[M]],Depth,Alpha,Beta,!Player),
		Beta > Alphaprnt,
		alphavalue(XL,Alphaprnt)).

	alphabeta([[H|_]],0,_,Betach,_):-
		node(H,HH),
		Betach=HH.
	alphabeta([[H|_]],Depth,Alphaprnt,Betaprnt,max):-
		extend([H|_],EXL),
		foreachild(EXL,Alphaprnt,Betaprnt,Depth,1).
	alphabeta([[H|_]],Depth,Alphaprnt,Betaprnt,min):-
		extend([H|_],EXL),
		foreachild(EXL,Alphaprnt,Betaprnt,Depth,0).

	run :-
		alphabeta([[a]],3,Alpha,Betaprnt,max),
		write("Alpha=\n",Alpha,"Beta=\n",Betaprnt).


Goal

	run.