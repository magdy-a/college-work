//#include "mpi.h"
//#include <iostream>
//
//using namespace std;
//
//void main(int argc, char **argv)
//	{
//	MPI::Init(argc,argv);
//	int x = 0;
//	int sum = 0;
//	if(MPI::COMM_WORLD.Get_rank() == 0)
//		{
//		for(int i = 1 ; i < MPI::COMM_WORLD.Get_size() ; i ++)
//			{
//			MPI::COMM_WORLD.Recv(&x,1,MPI::INT,i,0);
//			sum += x;
//			cout<< x;
//			if(i == MPI::COMM_WORLD.Get_size()-1)
//				{
//				cout<< endl;
//				}
//			else{
//				cout<< "+";
//				}
//			}
//
//		cout<< sum << endl;
//		}
//	else{
//		x = MPI::COMM_WORLD.Get_rank();
//		MPI::COMM_WORLD.Send(&x,1,MPI::INT,0,0);
//		}
//	MPI::Finalize();
//	}