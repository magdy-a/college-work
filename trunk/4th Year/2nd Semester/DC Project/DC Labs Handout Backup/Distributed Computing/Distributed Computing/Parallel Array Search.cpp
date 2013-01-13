#include <omp.h>
#include <stdio.h>
#include <stdlib.h>

#define CHUNKSIZE 3

void main2(int argc, char *argv[]){
	int id = 0,chunk = CHUNKSIZE, i, target = 3, size;

	int arr[] = {0,1,2,3,4,5,6,7,3,4,6,7,3,9,7,8,3,3,3,3,3,3,3,3};

	size = sizeof(arr)/sizeof(int);

#pragma omp parallel shared(arr,chunk, target,size) private(id,i)
		{
		id = omp_get_thread_num();

#pragma omp for schedule(dynamic,chunk)
			for(i = 0; i < size ; i ++)
				{
				if(arr[i] == target)
					{
					printf("Thread: %d, found: %d, @ Index: %d\n",id,target,i);
					}
			}
		}
	}