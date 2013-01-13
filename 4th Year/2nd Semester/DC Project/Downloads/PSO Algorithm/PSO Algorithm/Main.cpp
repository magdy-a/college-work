#include <iostream>
#include <tchar.h> 
#include <Windows.h> 
#include <omp.h> 
 using namespace std;
int main (int argc, char *argv[])  
{ 
  int id, nthreads; 
  // set number of threads to 4 
  omp_set_num_threads(4); 
  // start the fork 
 
  #pragma omp	parallel 
  {// parallel region started 
    //Obtain thread number 
    id = omp_get_thread_num(); 
    printf("Hello World from thread %d\n", id); 
  }// parallel region ended.  
  //all threads joined the master thread now. 
   
 }