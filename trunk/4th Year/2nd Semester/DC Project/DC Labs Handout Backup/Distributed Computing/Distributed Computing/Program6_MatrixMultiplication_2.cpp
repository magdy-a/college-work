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
//	int sum = 0;
//
//	// Set x's Data, Global, All have the x's Data
//	for(int i = 0 ; i < cols ; i ++)
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
//			}
//
//		// Send each part to a computer
//		for(i = 1 ; i < MPI::COMM_WORLD.Get_size() ; i ++)
//			{
//			part = new int[cols];
//
//			for(j = 0 ; j < cols ; j ++)
//				{
//				part[j] = matrix[((i-1)*cols) + j];
//				}
//
//			// Send part
//			MPI::COMM_WORLD.Send((void*)part,cols,MPI::INT,i,0);
//
//			// Recieve Result
//			MPI::COMM_WORLD.Recv(&j,1,MPI::INT,i,0);
//			sum += j;
//			}
//
//		// Recieve Values
//		/*for(i = 1 ; i < MPI::COMM_WORLD.Get_size() ; i++)
//			{
//			MPI::COMM_WORLD.Recv(&j,1,MPI::INT,i,0);
//			cout<< j << endl;
//			sum += j;
//			}*/
//
//		cout<< sum << endl;
//		}
//	else
//		{
//		part = new int[cols];
//		MPI::COMM_WORLD.Recv((void*)part,cols,MPI::INT,0,0);
//		cout<< "I am in Computer " << MPI::COMM_WORLD.Get_rank() << endl;
//		for(i = 0 ; i < cols ; i ++)
//			{
//			cout<< "part[i] " << part[i] << ", x[i] " << x[i] << endl;
//			sum += part[i] * x[i];
//			}
//		cout<< sum << endl;
//		cout<< "Going out computer " << MPI::COMM_WORLD.Get_rank() << endl;
//		MPI::COMM_WORLD.Send(&sum,1,MPI::INT,0,0);
//		}
//
//	MPI::Finalize();
//	}