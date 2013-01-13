/*
 * calculate_pbest_obj_AF.cpp
 *
 * Code generation for function 'calculate_pbest_obj_AF'
 *
 * C source code generated on: Tue May 22 03:41:52 2012
 *
 */

/* Include files */
#include "Calculate_Fitness_AF_fay.h"
#include "Calculate_Fitness_AFmin.h"
#include "calculate_pbest_obj_AF.h"
#include "repmat.h"
#include "abs.h"
#include "sum.h"
#include "exp.h"
#include "sind.h"
#include "cosd.h"

/* Type Definitions */

/* Named Constants */

/* Variable Declarations */

/* Variable Definitions */

/* Function Declarations */

/* Function Definitions */

/*
 * function [iterbest,pbest,oldpfitness,indx,bestfitness] = calculate_pbest_obj_AF(pos, pbest,oldpfitness)
 */
void calculate_pbest_obj_AF(const real_T pos[4320], real_T pbest[4320], real_T
  oldpfitness[90], real_T iterbest[4320], real_T *indx, real_T *bestfitness)
{
  real_T postion[24];
  int32_T i;
  real_T dv1[24];
  int32_T i0;
  real_T d0;
  real_T dv2[24];
  real_T temp[2160];
  creal_T elements[2160];
  creal_T AFfay1[90];
  creal_T AFfay2[90];
  creal_T AFfay3[90];
  creal_T dcv0[90];
  real_T dv3[90];
  real_T dv4[90];
  real_T dv5[90];
  real_T fitness[90];
  int32_T itmp;
  real_T b_pos[48];

  /* 'calculate_pbest_obj_AF:3' coder.inline('never') */
  /* calculate personal best , iterbest and bestfitness */
  /* 'calculate_pbest_obj_AF:7' fay1=0; */
  /* 'calculate_pbest_obj_AF:8' fay2=90; */
  /* 'calculate_pbest_obj_AF:9' fay3=180; */
  /* 'calculate_pbest_obj_AF:10' fay4=30; */
  /* 'calculate_pbest_obj_AF:11' no_of_particle=90; */
  /* Duplicated Code */
  /* 'calculate_pbest_obj_AF:14' n=24; */
  /* number of antenna element in the array */
  /* 'calculate_pbest_obj_AF:15' degreestep=360/n; */
  /* 'calculate_pbest_obj_AF:16' wl=1; */
  /* wave length */
  /* 'calculate_pbest_obj_AF:17' d=0.5; */
  /* 'calculate_pbest_obj_AF:18' beta=(2*pi)/wl; */
  /* phase shift */
  /* 'calculate_pbest_obj_AF:19' seta=90; */
  /* because we will work only on horizontal level (in 2d)so zaxis will be 90 */
  /* 'calculate_pbest_obj_AF:20' r1=(n*d*wl)/(2*pi); */
  /* radius of the circle */
  /* 'calculate_pbest_obj_AF:22' I=pos(1:90,1:24); */
  /* 'calculate_pbest_obj_AF:23' phase=pos(1:90,25:48); */
  /* Initialize Postion Vector */
  /* 'calculate_pbest_obj_AF:26' postion = zeros(1,n); */
  memset(&postion[0], 0, 24U * sizeof(real_T));

  /* Set Initial Value */
  /* 'calculate_pbest_obj_AF:29' postion(1)=0; */
  postion[0] = 0.0;

  /*  from 2 to n */
  /* 'calculate_pbest_obj_AF:32' for i=2:n */
  for (i = 0; i < 23; i++) {
    /* 'calculate_pbest_obj_AF:33' postion(i)=postion(i-1)+degreestep; */
    postion[1 + i] = postion[i] + 15.0;
  }

  /* end of %Duplicated Code */
  /* 'calculate_pbest_obj_AF:38' temp=repmat(beta.*r1.*sind(seta).*cosd(fay1-postion),no_of_particle,1); */
  for (i0 = 0; i0 < 24; i0++) {
    dv1[i0] = 0.0 - postion[i0];
  }

  cosd(dv1);
  d0 = 90.0;
  sind(&d0);
  d0 *= 12.0;
  for (i0 = 0; i0 < 24; i0++) {
    dv2[i0] = d0 * dv1[i0];
  }

  repmat(dv2, temp);

  /* 'calculate_pbest_obj_AF:39' elements=I.*exp(1i.*(temp-phase)); */
  for (i0 = 0; i0 < 24; i0++) {
    for (i = 0; i < 90; i++) {
      elements[i + 90 * i0].re = 0.0;
      elements[i + 90 * i0].im = temp[i + 90 * i0] - pos[i + 90 * (24 + i0)];
    }
  }

  b_exp(elements);

  /* 'calculate_pbest_obj_AF:40' AFfay1=sum(elements,2); */
  for (i0 = 0; i0 < 24; i0++) {
    for (i = 0; i < 90; i++) {
      elements[i + 90 * i0].re *= pos[i + 90 * i0];
      elements[i + 90 * i0].im *= pos[i + 90 * i0];
    }

    /* for all particles */
    /* 'calculate_pbest_obj_AF:42' temp=repmat(beta.*r1.*sind(seta).*cosd(fay2-postion),no_of_particle,1); */
    dv1[i0] = 90.0 - postion[i0];
  }

  sum(elements, AFfay1);
  cosd(dv1);
  d0 = 90.0;
  sind(&d0);
  d0 *= 12.0;
  for (i0 = 0; i0 < 24; i0++) {
    dv2[i0] = d0 * dv1[i0];
  }

  repmat(dv2, temp);

  /* 'calculate_pbest_obj_AF:43' elements=I.*exp(1i.*(temp-phase)); */
  for (i0 = 0; i0 < 24; i0++) {
    for (i = 0; i < 90; i++) {
      elements[i + 90 * i0].re = 0.0;
      elements[i + 90 * i0].im = temp[i + 90 * i0] - pos[i + 90 * (24 + i0)];
    }
  }

  b_exp(elements);

  /* 'calculate_pbest_obj_AF:44' AFfay2=sum(elements,2); */
  for (i0 = 0; i0 < 24; i0++) {
    for (i = 0; i < 90; i++) {
      elements[i + 90 * i0].re *= pos[i + 90 * i0];
      elements[i + 90 * i0].im *= pos[i + 90 * i0];
    }

    /* for all particles */
    /* 'calculate_pbest_obj_AF:46' temp=repmat(beta.*r1.*sind(seta).*cosd(fay3-postion),no_of_particle,1); */
    dv1[i0] = 180.0 - postion[i0];
  }

  sum(elements, AFfay2);
  cosd(dv1);
  d0 = 90.0;
  sind(&d0);
  d0 *= 12.0;
  for (i0 = 0; i0 < 24; i0++) {
    dv2[i0] = d0 * dv1[i0];
  }

  repmat(dv2, temp);

  /* 'calculate_pbest_obj_AF:47' elements=I.*exp(1i.*(temp-phase)); */
  for (i0 = 0; i0 < 24; i0++) {
    for (i = 0; i < 90; i++) {
      elements[i + 90 * i0].re = 0.0;
      elements[i + 90 * i0].im = temp[i + 90 * i0] - pos[i + 90 * (24 + i0)];
    }
  }

  b_exp(elements);

  /* 'calculate_pbest_obj_AF:48' AFfay3=sum(elements,2); */
  for (i0 = 0; i0 < 24; i0++) {
    for (i = 0; i < 90; i++) {
      elements[i + 90 * i0].re *= pos[i + 90 * i0];
      elements[i + 90 * i0].im *= pos[i + 90 * i0];
    }

    /* for all particles */
    /* 'calculate_pbest_obj_AF:50' temp=repmat(beta.*r1.*sind(seta).*cosd(fay4-postion),no_of_particle,1); */
    postion[i0] = 30.0 - postion[i0];
  }

  sum(elements, AFfay3);
  cosd(postion);
  d0 = 90.0;
  sind(&d0);
  d0 *= 12.0;
  for (i0 = 0; i0 < 24; i0++) {
    dv1[i0] = d0 * postion[i0];
  }

  repmat(dv1, temp);

  /* 'calculate_pbest_obj_AF:51' elements=I.*exp(1i.*(temp-phase)); */
  for (i0 = 0; i0 < 24; i0++) {
    for (i = 0; i < 90; i++) {
      elements[i + 90 * i0].re = 0.0;
      elements[i + 90 * i0].im = temp[i + 90 * i0] - pos[i + 90 * (24 + i0)];
    }
  }

  b_exp(elements);
  for (i0 = 0; i0 < 24; i0++) {
    for (i = 0; i < 90; i++) {
      elements[i + 90 * i0].re *= pos[i + 90 * i0];
      elements[i + 90 * i0].im *= pos[i + 90 * i0];
    }
  }

  /* 'calculate_pbest_obj_AF:52' AFfay4=sum(elements,2); */
  /* for all particles */
  /* 'calculate_pbest_obj_AF:54' fitness=abs(AFfay1)+abs(AFfay2)+abs(AFfay3)-abs(AFfay4); */
  sum(elements, dcv0);
  b_abs(dcv0, dv3);
  b_abs(AFfay3, dv4);
  b_abs(AFfay2, dv5);
  b_abs(AFfay1, fitness);
  for (i0 = 0; i0 < 90; i0++) {
    fitness[i0] = ((fitness[i0] + dv5[i0]) + dv4[i0]) - dv3[i0];
  }

  /* 'calculate_pbest_obj_AF:56' [bestfitness,indx]=max(fitness); */
  *bestfitness = fitness[0];
  itmp = -1;
  for (i = 0; i < 89; i++) {
    if (fitness[i + 1] > *bestfitness) {
      *bestfitness = fitness[i + 1];
      itmp = i;
    }
  }

  *indx = (real_T)itmp + 2.0;

  /* 'calculate_pbest_obj_AF:57' iterbest=pos(indx,:); */
  /* 'calculate_pbest_obj_AF:58' iterbest=repmat(iterbest,no_of_particle,1); */
  for (i0 = 0; i0 < 48; i0++) {
    b_pos[i0] = pos[(itmp + 90 * i0) + 1];
  }

  b_repmat(b_pos, iterbest);

  /* pbest = zeros(no_of_particle,2*n); */
  /* 'calculate_pbest_obj_AF:62' for P=1:no_of_particle */
  for (i = 0; i < 90; i++) {
    /* 'calculate_pbest_obj_AF:63' if(fitness(P)>oldpfitness(P)) */
    if (fitness[i] > oldpfitness[i]) {
      /* 'calculate_pbest_obj_AF:64' pbest(P,:)=pos(P,:); */
      for (i0 = 0; i0 < 48; i0++) {
        pbest[i + 90 * i0] = pos[i + 90 * i0];
      }

      /* 'calculate_pbest_obj_AF:65' oldpfitness(P)=fitness(P); */
      oldpfitness[i] = fitness[i];
    }

    /*  oldpfitness(P)=fitness(P); */
  }
}

/* End of code generation (calculate_pbest_obj_AF.cpp) */
