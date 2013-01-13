//#include "mpi.h"
//#include <iostream>
//
//using namespace std;
//
//void main(int argc, char **argv)
//	{
//	MPI::Init(argc,argv);
//	int i = 0;
//
//	if(MPI::COMM_WORLD.Get_rank() == 0)
//		{
//		int x = 0;
//		cout<< "HelloWorld\t0"<<endl;
//		for(i = 1 ; i < MPI::COMM_WORLD.Get_size() ; i ++)
//			{
//			MPI::COMM_WORLD.Recv(&x,1,MPI::INT,i,0);
//			cout<< "HelloWorld\t"<< x <<endl;
//			}
//		}
//	else{
//		i = MPI::COMM_WORLD.Get_rank();
//		MPI::COMM_WORLD.Send(&i,1,MPI::INT,0,0);
//		}
//	MPI::Finalize();
//	}