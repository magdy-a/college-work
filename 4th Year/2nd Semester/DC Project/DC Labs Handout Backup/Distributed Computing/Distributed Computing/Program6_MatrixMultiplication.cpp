//#include "mpi.h"
//#include <iostream>
//
//using namespace std;
//
//void main(int argc, char **argv)
//	{
//	MPI::Init(argc,argv);
//
//	int cols = 4;
//	int *part;
//	int *x = new int[cols];
//	int i, j;
//	int comfirmation = 0;
//
//	// Set x's Data, Global, All have the x's Data
//	for(int i = 0 ; i < 4 ; i ++)
//		{
//		x[i] = i + 1;
//		}
//
//	// The main part
//	if(MPI::COMM_WORLD.Get_rank() == 0)
//		{
//		// Initialize the size by the size * cols
//		int* matrix = new int[MPI::COMM_WORLD.Get_size() * cols];
//
//		// Set Matrix Data
//		for(i = 0 ; i < MPI::COMM_WORLD.Get_size() * cols; i ++)
//			{
//			if(i == 0)
//				matrix[0] = 1;
//			else
//				matrix[i] = matrix[i-1] + 1;
//
//			cout<< matrix[i] << "\t";
//
//			if(matrix[i] % cols == 0)
//				cout<< endl;
//			}
//
//		// Send each part to a computer
//		for(i = 1 ; i < MPI::COMM_WORLD.Get_size() ; i ++)
//			{
//			cout<< "Initializing part for Loop " << i << endl;
//			part = new int[cols];
//
//			for(j = 0 ; j < cols ; j ++)
//				{
//				//cout<< "getting index " << ((i-1)*cols) + j << endl;
//				part[j] = matrix[((i-1)*cols) + j];
//				}
//
//			MPI::COMM_WORLD.Send((void*)part,cols,MPI::INT,i,0);
//			MPI::COMM_WORLD.Recv(&comfirmation,1,MPI::INT,i,1);
//			}
//		}
//	else
//		{
//		part = new int[cols];
//		MPI::COMM_WORLD.Recv((void*)part,cols,MPI::INT,0,0);
//
//		/*cout<< "From Computer " << MPI::COMM_WORLD.Get_rank() << endl;
//		cout<< "received array with length " << cols << endl;*/
//		for(i = 0; i < cols ; i ++)
//			{
//			cout<< part[i] << "\t";
//			}
//		cout<< endl;
//		cout<< endl;
//
//		// Send Confirmation
//		//MPI::COMM_WORLD.Send(&comfirmation,1,MPI::INT,0,1);
//		}
//
//	MPI::Finalize();
//	}