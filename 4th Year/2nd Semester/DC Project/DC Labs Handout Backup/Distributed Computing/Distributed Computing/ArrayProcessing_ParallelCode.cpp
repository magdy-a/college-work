//#include "BigInt.h"
//#include "mpi.h"
//#include <time.h>
//
//#pragma region DefinedValues
//
//#define NBig 65536
//#define NSmall 500
//#define NTest 6
//
//#define Half_Mega_Integers 131072
//
//// (index_i, index_j, count)
//#define Part_Arr_Length 3
//
//#define Product 1
//
//#define Master 0
//
//#define Flag_Length 1
//#define Flag_Array 2
//#define Flag_String 3
//
//#pragma endregion
//
//using namespace std;
//
//int i,j, tmp, id, size, length_Array;
//
//// Indicies to the current Index to start calculating from
//int currentIndex_i, currentIndex_j;
//
//// Side Length of the Matrix
//int side_length = NSmall;
//
//// Temp String to send and receive results over MPI
//string tmpString;
//
//// Very Large DataType to hold the Result
//BigInt sum(0);
//
//#pragma region prototypes
//
//BigInt GetTotal(int);
//
//BigInt GetHalf_WithoutDiagonal(int);
//
//int Get_Chunck_ToBe_Calc_Moving_Indicies();
//
//int Calc_sending_parts(int **_part_arr, int _size);
//
//#pragma endregion
//
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
//		//============================================================================
//		// =================== receiving_result_members ==============================`
//		// Array of return values, from all other threads
//		char **return_arr;
//
//		// The length foreach value received from all other threads
//		int *return_length_arr;
//		// =================== sending_part_members ===================================
//		// Part to be calculated
//		int **part_arr;
//		// =================== helping_values =========================================
//		// number or worker have order to proceed
//		int workers;
//
//		// Get #Operations to do, but without the diagonal
//		BigInt myMatrixSize = GetHalf_WithoutDiagonal(side_length);
//		// ============================================================================
//
//		// Initialize Size of sending arrays
//		part_arr = new int*[size];
//
//		// Initialize Size of receiving arrays
//		return_arr = new char*[size];
//		return_length_arr = new int[size];
//
//		// Initializing current Indicies to Zero, i is the Row, j is the Column
//		currentIndex_i = 0, currentIndex_j = 1;
//
//		do
//		{
//			// Fill the array, (Parts to Send, Length of each part, #workers_Size of 2 past arrays, Size of Actual workers_max workers)
//			workers = Calc_sending_parts(part_arr, size);
//
//			// Send Chunks
//			for(i = 0 ; i < workers ; i ++)
//			{
//				// Send int_arr to i+1
//				MPI::COMM_WORLD.Send((void*)part_arr[i],Part_Arr_Length,MPI::INT,i+1,Flag_Array);
//			}
//
//			// Receive Chunks
//			for(i = 0 ; i < workers ; i ++)
//			{
//				// Recv length of char_arr to be received from i+1 || any
//				MPI::COMM_WORLD.Recv(&length_Array,1,MPI::INT,i+1,Flag_Length);
//
//				return_length_arr[i] = length_Array;
//				return_arr[i] = new char[length_Array];
//
//				// Recv char_arr from i+1 || any
//				MPI::COMM_WORLD.Recv((void*)return_arr[i],length_Array,MPI::CHAR,i+1,Flag_String);
//
//				tmpString = "";
//
//				for(j = 0 ; j < length_Array ;  j++)
//				{
//					tmpString += return_arr[i][j];
//				}
//
//				// convert to string then convert to the Bigint and add to the sum
//				sum += BigInt(tmpString);
//			}
//		}while (workers != 0);
//
//		// Closing Indicator, that is the part is all zeros
//		part_arr[0] = new int[Part_Arr_Length];
//		memset((void*)part_arr[0],0,sizeof(int) * Part_Arr_Length);
//
//		// Send Closing to all Workers
//		for(i = 1 ; i <= size ; i ++)
//		{
//			MPI::COMM_WORLD.Send((void*)part_arr[0], Part_Arr_Length, MPI::INT,i, Flag_Array);
//		}
//
//		// TODO Calulate the diagonal just once
//		for(i = 0 ; i < side_length ; i ++)
//		{
//			sum += i * i * Product;
//		}
//
//		tmpString = sum.ToString();
//
//		printf("Result of Scaler(%d)_Matrix(SideLength = %d) Multiplication is: ",Product,side_length);
//		cout<< tmpString << endl;
//	}
//	else
//	{
//		int *values = new int[Part_Arr_Length];
//		char* result_charArr;
//
//		while(1)
//		{
//			MPI::COMM_WORLD.Recv((void*)values,Part_Arr_Length,MPI::INT,Master,Flag_Array);
//
//			// Closing Indicator
//			if(values[2] == 0)
//			{
//				break;
//			}
//
//			i = values[0];
//			j = values[1];
//
//			// foreach value, Multiply it by 2, cause the matrix is symmetric, and I am sending just half of it
//			for(tmp = 0 ; tmp < values[2] ; tmp++)
//			{
//				sum += (i) * (j++) * (Product) * (2);
//
//				if(j == side_length)
//				{
//					i ++;
//					j = i + 1;
//				}
//			}
//
//			tmpString = sum.ToString();
//
//			length_Array = tmpString.length();
//			result_charArr = (char*) tmpString.c_str();
//
//			// Send back the results
//			MPI::COMM_WORLD.Send(&length_Array,1,MPI::INT,Master,Flag_Length);
//			MPI::COMM_WORLD.Send(result_charArr,length_Array,MPI::CHAR,Master,Flag_String);
//		}
//	}
//
//	MPI::Finalize();
//}
//
//// Sets values to the sending parts(index_i, index_j, count), finally setting the number of workers in the arrays
//int Calc_sending_parts(int **_part_arr, int _size)
//{
//	int _workers = 0;
//
//	// Set values to part_arr, and set the lengthes in the part_length_arr, and set the #workers in these arrays
//	while(_size-- > 0 && currentIndex_i < side_length - 1)
//	{
//		_part_arr[_workers] = new int[Part_Arr_Length];
//		_part_arr[_workers][0] = currentIndex_i;
//		_part_arr[_workers][1] = currentIndex_j;
//
//		tmp = Get_Chunck_ToBe_Calc_Moving_Indicies();
//
//		if(tmp == 0)
//		{
//			break;
//		}
//
//		_part_arr[_workers][2] = tmp;
//
//		_workers ++;
//	}
//
//	return _workers;
//}
//
//// Get Count of Elements to operate on,
//int Get_Chunck_ToBe_Calc_Moving_Indicies()
//{
//	int count = 0, Length_Available_in_Row;
//
//	while(count < Half_Mega_Integers && currentIndex_i < side_length - 1)
//	{
//		Length_Available_in_Row = side_length - currentIndex_j;
//
//		tmp = count + Length_Available_in_Row;
//
//		if(tmp <= Half_Mega_Integers)
//		{
//			count = tmp;
//			currentIndex_i ++;
//			currentIndex_j = currentIndex_i + 1;
//		}else
//		{
//			tmp = (tmp - Half_Mega_Integers);
//			count = tmp;
//			currentIndex_j += (Length_Available_in_Row - tmp);
//		}
//	}
//
//	return count;
//}
//
//// Calculates Half the Matrix without the Diagonal
//BigInt GetHalf_WithoutDiagonal(int sideLength)
//{
//	BigInt a = sideLength;
//
//	a *= sideLength;
//
//	a -= sideLength;
//
//	a /= 2;
//
//	return a;
//}