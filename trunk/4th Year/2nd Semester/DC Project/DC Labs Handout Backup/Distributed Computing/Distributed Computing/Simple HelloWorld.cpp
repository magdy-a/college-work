#include <omp.h>
#include <stdio.h>
#include <stdlib.h>

void main1(int argc, char *argv[]){
	int id = 0, nThreads = 4;

	int arr[] = {0,1,2,3,4,5,6,7,3,4,6,7,3,9,7,8,3};

#pragma omp parallel private(id)
		{
		id = omp_get_thread_num();

		printf("HelloWorld! from thread %d\n", id);
		}
	}