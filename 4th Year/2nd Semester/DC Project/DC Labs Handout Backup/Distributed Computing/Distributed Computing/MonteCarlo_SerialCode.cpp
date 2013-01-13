//#include "mpi.h"
//#include <iostream>
//#include <time.h>
//
//using namespace std;
//
//#define SamplesNum 108
////#define MaxRand 9350 //goes for 1M samples
//#define MaxRand 3000 //goes for 108 sampes
//
//double Random_From_Neg1_To_1()
//	{
//	return  (-1) + (2) * ((rand() % MaxRand) / (double)MaxRand);
//	}
//
//double CalcDistance_From_0(double x, double y)
//	{
//	return sqrt(pow(x, 2.0) + pow(y, 2.0));
//	}
//
//void main(int argc, char** argv)
//	{
//	MPI::Init(argc,argv);
//
//	srand(4687564);
//
//	// Variables for calculating elapsed time
//	time_t start, stop;
//
//	// The number of sample fall into the circle
//	int hit = 0;
//
//	// Save Start time
//	time(&start);
//
//	// Generate Randoms, and get the number of samples that fall into the circle
//	double dist = 0.0;
//	for(int i = 0 ; i < SamplesNum; i++)
//		{
//		dist = CalcDistance_From_0(Random_From_Neg1_To_1(), Random_From_Neg1_To_1());
//		if(dist <= 1.0)
//			{
//			hit ++;
//			}
//		else
//			{
//			}
//		}
//
//	cout<< "#Samples: " << SamplesNum << "\t#Hits: " << hit << endl;
//
//	// Calculate the Pi Value
//	cout<< "Pi = " << 4*hit/(double)SamplesNum << endl;
//
//	// Save Stop Time
//	time(&stop);
//
//	// Show Elapsed Time
//	printf("Time Elapsed %.0f\n",difftime(stop,start));
//
//	MPI::Finalize();
//	}