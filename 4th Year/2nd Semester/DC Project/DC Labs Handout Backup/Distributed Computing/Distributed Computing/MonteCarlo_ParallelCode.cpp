#include "mpi.h"
#include <iostream>
#include <time.h>

using namespace std;

//#define SamplesNum 131072
#define SamplesNum 1024
#define MaxRand 10000

// TODO you should test by numbers (2^[x]) + 1 : 2 : 3 : 5 : 9 : 17 : 33 : and so on ...

double Random_From_Neg1_To_1()
	{
	return  (-1) + (2) * ((rand() % MaxRand) / (double)MaxRand);
	}

double CalcDistance_From_0(double x, double y)
	{
	return sqrt(pow(x, 2.0) + pow(y, 2.0));
	}

int GetNumOfHits(int samples)
	{
	int hits = 0;
	for(int i = 0 ; i < samples ; i ++)
		{
		if(CalcDistance_From_0(Random_From_Neg1_To_1(), Random_From_Neg1_To_1()) <= 1.0)
			{
			hits ++;
			}
		}
	return hits;
	}

void main(int argc, char** argv)
	{
	srand(4687564);

	MPI::Init(argc,argv);

	// Get Size & Rank
	int size = MPI::COMM_WORLD.Get_size(), rank = MPI::COMM_WORLD.Get_rank();

	// Part for each computer to compute
	int part = 0;

	// If Master
	if(rank == 0)
		{
		// Variables for calculating elapsed time
		time_t start, stop;

		// The number of sample fall into the circle
		int hits;

		int j;

		for(int i = 1; i < size ; i *= 2)
			{
			//printf("============================================================\n");
			printf("#Computers{%d}\n",i);

			// Get Start Time
			time(&start);

			// Reset Hits
			hits = 0;

			// Clac Part
			part = SamplesNum / i;
			printf("Parts{%d}\n",part);

			// Send to All Computers
			for(j = 1 ; j <= i ; j++)
				{
				//printf("Sending to Computer{%d}\n",j);
				MPI::COMM_WORLD.Send(&part,1,MPI::INT,j,0);
				}

			// Recv From all Computers
			for(j = 1; j <= i ; j++)
				{
				MPI::COMM_WORLD.Recv(&part,1,MPI::INT,j,1);
				printf("Receiving from Computer{%d}, Hits{%d}\n",j, part);

				// Inc Hits Count
				hits += part;
				}

			//MPI::COMM_WORLD.Barrier();

			// Get Stop Time
			time(&stop);

			// Display Result
			printf("For #Computers{%d}, #Hits{%d}, in Time{%.0f}, Result{%f}\n",i,hits,difftime(stop,start),4*hits/(double)SamplesNum);
			printf("============================================================\n");
			}
		}
	else
		{
		for(int i = rank ; i < size ; i *= 2)
			{
			//printf("Receiving from Computer{0}, with parts{%d}\n", part);
			MPI::COMM_WORLD.Recv(&part,1,MPI::INT,0,0);

			part = GetNumOfHits(part);

			//printf("Sending to Computer{0}, with parts{%d}\n", part);
			MPI::COMM_WORLD.Send(&part,1,MPI::INT,0,1);
			}
		}

	MPI::Finalize();
	}