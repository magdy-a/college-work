//#include "mpi.h"
//#include <iostream>
//
//using namespace std;
//
//void main(int argc, char **argv)
//	{
//	MPI::Init(argc,argv);
//	int x = 5;
//
//	if(MPI::COMM_WORLD.Get_rank() == 0)
//		{
//		cout<< x << endl;
//
//		MPI::COMM_WORLD.Send(&x,1,MPI::INT,1,0);
//		MPI::COMM_WORLD.Recv(&x,1,MPI::INT,1,0);
//
//		cout<< x << endl;
//		}
//	else{
//		MPI::COMM_WORLD.Recv(&x,1,MPI::INT,0,0);
//		x *= 3;
//		MPI::COMM_WORLD.Send(&x,1,MPI::INT,0,0);
//		}
//	MPI::Finalize();
//	}