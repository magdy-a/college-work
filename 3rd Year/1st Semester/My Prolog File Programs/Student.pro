DoMains
	name = n(symbol,symbol).
	gender = male;female.
	grade = good; vgood ; excellent.
PreDicates
	nondeterm student(integer,name,gender,grade).
Clauses
	student(1,n(ahmed,magdy),male,good).
	student(2,n(asmaa,magdy),female,vgood).
	student(3,n(noha,magdy),female,good).
	student(4,n(mohamed,magdy),male,vgood).
Goal
	student(Z,n(A,B),male,Y).