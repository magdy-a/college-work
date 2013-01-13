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
//		// TODO Cout
//		//cout<< "Size: " << size + 1 << endl;
//
//		// TODO Cout
//		//cout << "Half Matrix without diagonal: " << myMatrixSize << endl;
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
//				// TODO Cout
//				//cout<< "Sending to Worker: " << i+1 << endl;
//				// Send int_arr to i+1
//				MPI::COMM_WORLD.Send((void*)part_arr[i],Part_Arr_Length,MPI::INT,i+1,Flag_Array);
//			}
//
//			// Receive Chunks
//			for(i = 0 ; i < workers ; i ++)
//			{
//				//cout<< "Receiving from Worker: " << i + 1 << endl;
//
//				// Recv length of char_arr to be received from i+1 || any
//				MPI::COMM_WORLD.Recv(&length_Array,1,MPI::INT,i+1,Flag_Length);
//
//				//cout<< "Received Length: " << length_Array << endl;
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
//					//cout<< return_arr[i][j] << endl;
//					tmpString += return_arr[i][j];
//				}
//
//				//cout<< "Testing Tx " << return_arr[i] << "\t " << x << "\t " << length_Array << endl;
//
//				//cout<< "Sum !!! " << string(return_arr[i]) << "\t" << x << endl;
//
//				// convert to string then convert to the Bigint and add to the sum
//				sum += BigInt(tmpString);
//
//				//cout<< "Sum: " << sum << endl;
//			}
//		}while (workers != 0);
//
//		// Send Closing Indicator, that is length = 0
//		part_arr[0] = new int[Part_Arr_Length];
//		memset((void*)part_arr[0],0,sizeof(int) * Part_Arr_Length);
//
//		//printf("memset (%d,%d,%d)",part_arr[0][0],part_arr[0][1],part_arr[0][2]);
//
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
//		cout<< tmpString;
//		cout<< endl;
//	}
//	else
//	{
//		int *values = new int[Part_Arr_Length];
//		char* result_charArr;
//
//		//cout<< "Welcome to Worker (" << id << ")\n\n" << endl;
//
//		while(1)
//		{
//			//cout<< "Waiting for values" << endl;
//
//			MPI::COMM_WORLD.Recv((void*)values,Part_Arr_Length,MPI::INT,Master,Flag_Array);
//
//			if(values[2] == 0)
//			{
//				//cout<< "Closing " << id << endl;
//				break;
//			}
//
//			//printf("memset from Rx(%d) (%d,%d,%d)\n\n",id,values[0],values[1],values[2]);
//
//			// Closing Indicator
//			// TODO with every value, Multiply it by 2, cause the matrix is symmetric, and I am sending just half of it
//
//			i = values[0];
//			j = values[1];
//
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
//			//cout<< "Testing from Rx(" << id << ") " << sum << "\t" << result << "\t" << result_charArr << "\t" << length_Array << endl;
//
//			//cout<< "Chunk Sum is: " << result << endl;
//
//			//TODO Send back the results
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
//	// TODO Set values to part_arr, and set the lengthes in the part_length_arr, and set the #workers in these arrays
//	while(_size-- > 0 && currentIndex_i < side_length - 1)
//	{
//		//printf("Size %d, currentIndex %d, side_length %d\n\n",_size,currentIndex_i,side_length);
//
//		// TODO Cout
//		//cout<< "Workers: " << _workers << endl;
//
//		_part_arr[_workers] = new int[Part_Arr_Length];
//		_part_arr[_workers][0] = currentIndex_i;
//		_part_arr[_workers][1] = currentIndex_j;
//
//		tmp = Get_Chunck_ToBe_Calc_Moving_Indicies();
//
//		// TODO Cout
//		//cout<< "Tmp = : " << tmp << endl;
//
//		if(tmp == 0)
//		{
//			//cout<< "Break @Calc_Sending_Parts\n\n";
//			break;
//		}
//
//		_part_arr[_workers][2] = tmp;
//
//		//printf("Arr %d, %d, %d\n\n", _part_arr[_workers][0], _part_arr[_workers][1], _part_arr[_workers][2]);
//		//printf("Arr %d, %d, %d\n\n", _part_arr[0][0], _part_arr[0][1], _part_arr[0][2]);
//
//		_workers ++;
//
//		//printf("Size %d, currentIndex %d, side_length %d\n\n",_size,currentIndex_i,side_length);
//		//cout<< "Workers: " << _workers << endl;
//	}
//
//	//cout<< "*****************************************************" << endl << endl;
//
//	return _workers;
//}
//
//// Get Count of Elements to operate on,
//int Get_Chunck_ToBe_Calc_Moving_Indicies()
//{
//	int count = 0, Length_Available_in_Row;
//
//	//cout<< endl << endl;
//
//	while(count < Half_Mega_Integers && currentIndex_i < side_length - 1)
//	{
//		//cout<< "Iteration =========================================\n\n";
//
//		Length_Available_in_Row = side_length - currentIndex_j;
//		//cout<< "length Avail: " << Length_Available_in_Row << endl;
//
//		//cout<< "Count: " << count << endl;
//
//		//cout<< "i, j: " << currentIndex_i << ", " << currentIndex_j << endl;
//
//		tmp = count + Length_Available_in_Row;
//
//		//cout<< "tmp: " << tmp << endl;
//
//		if(tmp <= Half_Mega_Integers)
//		{
//			count = tmp;
//			currentIndex_i ++;
//			currentIndex_j = currentIndex_i + 1;
//			//currentIndex_j = ++currentIndex_i;
//			//cout<< "i, j (tmp <=): " << currentIndex_i << ", " << currentIndex_j << endl;
//		}else
//		{
//			tmp = (tmp - Half_Mega_Integers);
//			count = tmp;
//			currentIndex_j += (Length_Available_in_Row - tmp);
//			//cout<< "i, j (tmp >): " << currentIndex_i << ", " << currentIndex_j << endl;
//		}
//
//		//cout<< "Count: " << count << endl;
//	}
//
//	//cout<< "=====================================================\n\n";
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