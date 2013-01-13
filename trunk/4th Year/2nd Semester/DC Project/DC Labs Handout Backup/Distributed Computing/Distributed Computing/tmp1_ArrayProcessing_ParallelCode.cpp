//#include "BigInt.h"
//#include "mpi.h"
//#include <time.h>
//
//#define NBig 65536
//#define NSmall 500
//#define Half_Mega 131072
//#define Product 2
//#define Master 0
//
//using namespace std;
//
//int i,j, id, size;
//
//#pragma region prototypes
//
//BigInt GetTotal(int);
//
//double GetDiagonalLength(int);
//
//BigInt GetHalf_WithoutDiagonal(int);
//
//#pragma endregion
//
//// ==================== Main =======================================
//void main(int argv, char **argc)
//{
//	MPI::Init(argv,argc);
//
//	// Get ID
//	id = MPI::COMM_WORLD.Get_rank();
//
//	// Get size and dec it once, cause the Master won't calculate
//	size = MPI::COMM_WORLD.Get_size() - 1;
//
//	if(id == Master)
//	{
//#pragma region receiving_result_members
//
//		// Array of return values, from all other threads
//		char **single_return_arr;
//
//		// The length foreach value received from all other threads
//		int *single_return_length_arr;
//
//#pragma endregion
//
//#pragma region sending_part_members
//
//		// Part to be calculated
//		int *part;
//
//		// Part to be calculated length
//		int partLength;
//
//#pragma endregion
//
//		// Side Length of the Matrix
//		int side_length = NBig;
//
//		// Initialize sum
//		BigInt sum(0);
//
//		BigInt myMatrixSize = GetHalf_WithoutDiagonal(side_length) + GetDiagonalLength(side_length);
//
//		// Initialize Size of receiving arrays
//		//single_return_arr = new char[size];
//		//single_return_length_arr = new int[size];
//	}
//
//	MPI::Finalize();
//}
//// ==================== Main =======================================
//
//// Calculates the double of the side Length in BitInt type
//BigInt GetTotal(int sideLength)
//{
//	BigInt total = sideLength;
//	return total * total;
//}
//
//// Calculates the Diagonal Length
//double GetDiagonalLength(int sideLength)
//{
//	return ((double)sideLength) * sqrt((double)2);
//}
//
//// Calculates Half the Matrix with the Diagonal
//BigInt GetHalf_WithoutDiagonal(int sideLength)
//{
//	BigInt a = sideLength;
//
//	a *= sideLength;
//
//	a -= (int)GetDiagonalLength(sideLength);
//
//	a /= 2;
//
//	return a;
//}
//
//#pragma region Comments
//
////=================================================================================================================
//
//// Hmmm, Let's say we have N = 65,536, we want a N*N operation,
//// but it can be reduced to a calculating the (upper trianlge without the diagonal) * 2 + diagonal
//// diagonal = Root(N^2+N^2) = Root(2N^2) = Root(2)*N ... Operation
//// upper triangle = (N*N - Root(2)*N) / 2 = N(N-Root(2))/2 ~= 2,147,450,880 operation
//// add to them the diagonal = 92,681.900023683157118267472229807 operation
//
//// net : 2,147,390,966.0999763168428817325278
//
//// We should make Chunk Size fit into the Cash, we we can say 1/2 Mega, foreach Thread, will be good, 2 Mega for all !
//
////=================================================================================================================
//
////int x = GetTotal(NBig).ToInt();
////	cout<< x << endl << endl;
////
////	BigInt a = NBig, b = a;
////
////	b *= sqrt(2.0);
////
////	cout<< b << endl;
////
////	a = ((a*a)-b)/ 2;
////
////	cout<< a << endl;
//
////=================================================================================================================
//
//#pragma endregion