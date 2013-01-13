#include <iostream>
#include <tchar.h> 
#include <Windows.h> 
#include <omp.h> 
 using namespace std;
int main (int argc, char *argv[])  
{ 
//-----------Constant Data------------
  int Numberofthethreads = 16;
  int AntennaNum=24;
  int NParticles=90; 
  int Nd=2*AntennaNum;
  omp_set_num_threads(Numberofthethreads); 
//-----------Normal Data Types------------
  int id;
  int nthreads; 
  int  no_of_iterations=1000;
  double wmax=0.9;
  double wmin=0.4;
  double c1max=2.5;
  double c1min=0.5;
  double c1=2;
  double c2max=2.5;
  double c2min=0.5;
  double c2=1.3;
  double c=c1+c2;
  double w=2.0/abs(2-c-sqrt(c*c-4*c));
  int itermax=0;
  double Gbest = 0;
  double Itrbest = 0;
  double Pbest = 0;
//-----------End Normal Data Types------------
//-----------Array Data Types For Matlab usage------------
  int id[];
  int nthreads[]; 
  int  no_of_iterations[]={1000};
  double wmax[]={0.9};
  double wmin[]={0.4};
  double c1max[]={2.5};
  double c1min[]={0.5};
  double c1[]={2};
  double c2max[]={2.5};
  double c2min[]={0.5};
  double c2[]={1.3};
  //double c[]=c1+c2;
  double c[]={3.3};
  //double w=2.0/abs(2-c-sqrt(c*c-4*c));
  double w[]={1};
  int itermax[]={0};
  double Gbest[] = {0};
  double Itrbest[] ={0};
  double Pbest[] = {0};
  double oldpfitness[];
  double maxdimension[];
  double mindimension[];
  double R[];//Postion
  double V[];//Velocity
  double VMax[];//Partcle Max Velocity
  double gfitness[];
  double pfitness[];
//--------End Array Data Types For Matlab usage-------

  //TODO : Define and intialize array with zero

  //TODO : intialize probe random
	//TODO : R(P,:)=rand(size(maxdimension)).*(maxdimension-mindimension) + mindimension;
	//TODO : V(P,:)=rand(size(maxv)).*(maxv-(-1*maxv))+(-1*maxv);
	//TODO : Return Resluts

  //TODO : Oldfitness intialize By Zero

  //TODO : Pbest intialize By Zero

  //TODO : calculate gfitness calculate_pbest_obj_AF
	//Steps :
	//TODO :1- Divide The 3 Parameters
	//TODO :2- Send To Matlab
	//TODO :3- Evaluate Results
	//TODO :4- Send Resluts Array To Matlab
	//TODO :5- Fill The Results Array With Datat
	//TODO :6- Send Back TO C++

  Gbest=Itrbest;
  itermax=0.75*no_of_iterations;
  #pragma omp parallel 
  {
	//TODO:Update Velocity
	  // V=w*V-c1*rand1.*(R(1:NParticles,:)-iterbest)-c2*rand2.*(R(1:NParticles,:)-gbest);
	  //R(1:NParticles,:)=R(1:NParticles,:)+V;

	//TODO:Update Postion
  }
  //TODO : Verfiy Partcle Location & Velocity
	//Step :
	//TODO :1- If Partcle Location > maxdimension (maxdimension is the sample space)
		//TODO : Partcle Location = maxdimension
	//TODO :2-If Partcle Location < mindimension
		//TODO :Partcle Location = mindimension
	//TODO :1- If Partcle Velocity > maxv (maxv is the sample allowed velocity)
		//TODO :Partcle Velocity = maxv
   //TODO :else Partcle Velocity = -maxv

  //TODO : Calculate calculate_pbest_obj_AF
	 //Steps :
	//TODO :1- Divide The 3 Parameters
	//TODO :2- Send To Matlab
	//TODO :3- Evaluate Results
	//TODO :4- Send Resluts Array To Matlab
	//TODO :5- Fill The Results Array With Datat
	//TODO :6- Send Back TO C++

	if(pfitness>gfitness)
	{
		Gbest=Itrbest;
		gfitness=pfitness;
	}
   //TODO : resultpso(iteration_no) = gfitness;
  //TODO : Draw Plot
}
