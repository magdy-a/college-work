//#include "mpi.h"
//#include <iostream>
//
//using namespace std;
//
//// Calculates first index you should send to
//int GetFirstIndex_SendTo(int index)
//	{
//	return index * 2;
//	}
//
//// Claculates the index you should recv from
//int GetRecvFromIndex(int index)
//	{
//	return floor((float)index/2);
//	}
//
//void main(int argc, char ** argv)
//	{
//	MPI::Init(argc,argv);
//
//	// Get your rank
//	int rank = MPI::COMM_WORLD.Get_rank();
//	// The size should be the ArrayCount+1 (if arrayCount is 5, Size should be 6)
//	int size = MPI::COMM_WORLD.Get_size();
//	// 5 elements + the target element
//	int* arr = new int[size];
//	// Initialize target Value
//	int target = 0;
//	// Set an Iterator once
//	int i;
//
//	// If I am the Master, Initialize the array, and send to to 1, also receive from all
//	if(MPI::COMM_WORLD.Get_rank() == 0)
//		{
//		for(i = 0 ; i < size - 1 ; i ++)
//			{
//			arr[i] = i + 1;
//			}
//
//		// If taking input from user
//
//		/*cout<< "Plz enter the target number : ";
//		cin >> target;*/
//
//		// Set target in code for testing
//		target = 5;
//
//		// Add it as the last value in the array
//		arr[size-1] = target;
//
//		// Send it to Computer 1
//		MPI::COMM_WORLD.Send((void*)arr,size,MPI::INT,1,0);
//
//		// Receive the results from all Computers
//		for(i = 1 ; i < size ; i ++)
//			{
//			MPI::COMM_WORLD.Recv(&target,1,MPI::INT,i,1);
//
//			// if the value received not equal 0, you've found a result
//			if(target == 1)
//				{
//				cout<< "\nValue is found @Computer: " << i;
//				}
//			}
//		}
//	else{
//		// Receive the data from your parent
//		MPI::COMM_WORLD.Recv((void*)arr,size,MPI::INT,GetRecvFromIndex(rank),0);
//		//printf("@Computer{%d}, Time is{%f}\n",MPI::COMM_WORLD.Get_rank(),MPI::Wtime());
//		//cout<< "Time MPI::Wtime();
//
//		// Set first child index in a tmp value
//		target = GetFirstIndex_SendTo(rank);
//
//		// Send to first target
//		if(target < size)// Max target is 5, size should be 6
//			{
//			MPI::COMM_WORLD.Send((void*)arr,size,MPI::INT,target,0);
//			}
//
//		// Send to second target
//		target ++;
//		if(target < size)
//			{
//			MPI::COMM_WORLD.Send((void*)arr,size,MPI::INT,target,0);
//			}
//
//		// Search for the target in your index-1
//		target = arr[size-1];
//		if(arr[rank-1] == target)
//			{
//			target = 1;
//			}
//		else
//			{
//			target = 0;
//			}
//
//		MPI::COMM_WORLD.Send(&target,1,MPI::INT,0,1);
//		}
//
//	MPI::Finalize();
//	}