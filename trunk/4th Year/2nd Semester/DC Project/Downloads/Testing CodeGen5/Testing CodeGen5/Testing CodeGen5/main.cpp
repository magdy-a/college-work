#include <stdio.h> 
#include <iostream>
#include "Calculate_Fitness_AF_fay.h"
using namespace std;
void main() 
{ 
	real_T p[48];
	real_T fay=3;
	real_T resluts;
	resluts = Calculate_Fitness_AF_fay(p,fay);
	cout<<resluts;
}