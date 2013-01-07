%In a Binary Tree Implemented in Array .. 
%a node has an Index (i), its children would be at indeces ( from left to right ) : ( 2i + 1  && 2i + 2 )
%and for any child with index (i) its parent would be at index ( (i - 1) / 2 )
%all Assuming root has index Zero.


%I will need a method that gets the Tree from the user and 
Domains

	tree = t(tree, integer , tree) ; null

Predicates
	
	nondeterm bfs(tree,integer,intger).
	nondeterm bf(tree, integer).

Clauses
	bf(t(_,_,_), X) :- bfs(t(_,_,_), X, 1)
	bfs(t(_,X,_),X,_):-!.
	bfs(t(L,Root,R), L, _) :- !.
	bfs(t(L,Root,R), R, _) :- !.
	bfs(t(L,Root,R), X, 1) :- bfs(t(NL, L, NR), X, 2).
	bfs(t(L, Root, R), X, 2) :- bfs(t(NL, R, NR), X, 1).
	
	
	
	
	
	%bfs(t(L,_,R),X,0):-
		%!,
		%bfs(L,X,1).
%	bfs(t(L,_,R),X,1):-
	%	bfs(R,X,0).
		goal
		