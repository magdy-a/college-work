domains
ilist=integer*
predicates
nondeterm subsets_list(ilist,ilist).
clauses
subsets_list([],[]).
subsets_list([_|T],L):-subsets_list(T,L).
subsets_list([H|T],[H|L]):-subsets_list(T,L).

goal
subsets_list([1,2,3],L).