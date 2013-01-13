//#include "BigInt.h"
//#include <time.h>
//
////#define N 65536
//#define N 500
////#define N 23,170
//
//using namespace std;
//
//BigInt sum, diagonal, tmp;
//// I am considering P = 1
//
//// Vars for start & stop times
//time_t start, stop;
//
//int i,j;
//
//void BruteForce()
//	{
//	// Initialize values
//	sum = diagonal = 0;
//
//	// Get Start Time
//	time(&start);
//
//	for(i = 0 ; i < N ; i ++)
//		for(j = 0 ; j < N ; j ++)
//			{
//			tmp = i;
//			tmp *= j;
//			sum += tmp;
//			}
//
//		// Get Stop Time
//		time(&stop);
//
//		//printf("For BruteForce Way result was {%s}, in time{%.0f}\n",sum.ToString(),difftime(stop,start));
//		cout<< "BruteForce: " << sum.ToString() << endl;
//	}
//
//void HalfWork()
//	{
//	// Initialize values
//	sum = diagonal = 0;
//
//	// Get Start Time
//	time(&start);
//
//	for(i = 0 ; i < N ; i ++)
//		{
//			cout<< i << "\t";
//
//		// Get one triangle of the matrix, ignoring the diagonal
//		for(j = 0 ; j < i ; j ++)
//			{
//			tmp = i;
//			tmp *= j;
//			sum += tmp;
//			}
//
//		// Save the diagonal value
//		tmp = i;
//		tmp *= j;
//		diagonal += tmp;
//		}
//
//	// double the triangle result
//	sum *= 2;
//
//	// add the diagonal just once
//	sum += diagonal;
//
//	// Get Stop Time
//	time(&stop);
//
//	//printf("For HalfWork Way result was {%s}, in time{%.0f}\n",sum.ToString(),difftime(stop,start));
//	cout<< "HalfWay   : " << sum.ToString() << endl;
//	}
//
//void main(int argv, char **argc)
//	{
//	BruteForce();
//	HalfWork();
//	}