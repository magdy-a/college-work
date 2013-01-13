//#include "mpi.h"
//#include <iostream>
//
//using namespace std;
//
//void main(int argc, char **argv)
//	{
//	MPI::Init(argc,argv);
//
//	int x = 0;
//
//	if(MPI::COMM_WORLD.Get_rank() == 0)
//		{
//		MPI::COMM_WORLD.Send(&x,1,MPI::INT,1,0);
//		cout<< "from " << MPI::COMM_WORLD.Get_rank() << "\t" << "sent " << x << " to 1" << endl;
//		MPI::COMM_WORLD.Recv(&x,1,MPI::INT,MPI::COMM_WORLD.Get_size()-1,0);
//		cout<< "from " << MPI::COMM_WORLD.Get_rank() << "\t" <<  "received " << x << " from " << MPI::COMM_WORLD.Get_size()-1 << endl;
//		cout<< endl;
//		}
//	else
//		{
//		MPI::COMM_WORLD.Recv(&x,1,MPI::INT,MPI::COMM_WORLD.Get_rank()-1,0);
//		cout<< "from " << MPI::COMM_WORLD.Get_rank() << "\t" << "received " << x << " from " << MPI::COMM_WORLD.Get_rank()-1 << endl;
//		cout<< endl;
//
//		cout<< "from " << MPI::COMM_WORLD.Get_rank() << "\t" << "Summing " << x << " + " << MPI::COMM_WORLD.Get_rank() << " = " << x + MPI::COMM_WORLD.Get_rank() << endl;
//		x += MPI::COMM_WORLD.Get_rank();
//
//		MPI::COMM_WORLD.Send(&x,1,MPI::INT,( MPI::COMM_WORLD.Get_rank()+1) % MPI::COMM_WORLD.Get_size(),0);
//		cout<< "from " << MPI::COMM_WORLD.Get_rank() << "\t" << "sent " << x << " to " << ( MPI::COMM_WORLD.Get_rank()+1) % MPI::COMM_WORLD.Get_size() << endl;
//		}
//
//	MPI::Finalize();
//	}