/*
 * calculate_pbest_obj_AF.c
 *
 * Code generation for function 'calculate_pbest_obj_AF'
 *
 * C source code generated on: Mon May 21 22:08:14 2012
 *
 */

/* Include files */
#include "rt_nonfinite.h"
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
 * function [iterbest,pbest,oldpfitness,indx,bestfitness]=calculate_pbest_obj_AF(pos, pbest,oldpfitness)
 */
void calculate_pbest_obj_AF(const real_T pos[4320], real_T pbest[4320], real_T
  oldpfitness[90], real_T iterbest[4320], real_T *indx, real_T *bestfitness)
{
  real_T postion[24];
  int32_T ixstart;
  real_T dv1[24];
  int32_T ix;
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
  boolean_T exitg1;
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
  for (ixstart = 0; ixstart < 23; ixstart++) {
    /* 'calculate_pbest_obj_AF:33' postion(i)=postion(i-1)+degreestep; */
    postion[1 + ixstart] = postion[ixstart] + 15.0;
  }

  /* end of %Duplicated Code */
  /* 'calculate_pbest_obj_AF:38' temp=repmat(beta.*r1.*sind(seta).*cosd(fay1-postion),no_of_particle,1); */
  for (ix = 0; ix < 24; ix++) {
    dv1[ix] = 0.0 - postion[ix];
  }

  cosd(dv1);
  d0 = 90.0;
  sind(&d0);
  d0 *= 12.0;
  for (ix = 0; ix < 24; ix++) {
    dv2[ix] = d0 * dv1[ix];
  }

  repmat(dv2, temp);

  /* 'calculate_pbest_obj_AF:39' elements=I.*exp(1i.*(temp-phase)); */
  for (ix = 0; ix < 24; ix++) {
    for (ixstart = 0; ixstart < 90; ixstart++) {
      elements[ixstart + 90 * ix].re = (temp[ixstart + 90 * ix] - pos[ixstart +
        90 * (24 + ix)]) * 0.0;
      elements[ixstart + 90 * ix].im = temp[ixstart + 90 * ix] - pos[ixstart +
        90 * (24 + ix)];
    }
  }

  b_exp(elements);

  /* 'calculate_pbest_obj_AF:40' AFfay1=sum(elements,2); */
  for (ix = 0; ix < 24; ix++) {
    for (ixstart = 0; ixstart < 90; ixstart++) {
      elements[ixstart + 90 * ix].re *= pos[ixstart + 90 * ix];
      elements[ixstart + 90 * ix].im *= pos[ixstart + 90 * ix];
    }

    /* for all particles */
    /* 'calculate_pbest_obj_AF:42' temp=repmat(beta.*r1.*sind(seta).*cosd(fay2-postion),no_of_particle,1); */
    dv1[ix] = 90.0 - postion[ix];
  }

  sum(elements, AFfay1);
  cosd(dv1);
  d0 = 90.0;
  sind(&d0);
  d0 *= 12.0;
  for (ix = 0; ix < 24; ix++) {
    dv2[ix] = d0 * dv1[ix];
  }

  repmat(dv2, temp);

  /* 'calculate_pbest_obj_AF:43' elements=I.*exp(1i.*(temp-phase)); */
  for (ix = 0; ix < 24; ix++) {
    for (ixstart = 0; ixstart < 90; ixstart++) {
      elements[ixstart + 90 * ix].re = (temp[ixstart + 90 * ix] - pos[ixstart +
        90 * (24 + ix)]) * 0.0;
      elements[ixstart + 90 * ix].im = temp[ixstart + 90 * ix] - pos[ixstart +
        90 * (24 + ix)];
    }
  }

  b_exp(elements);

  /* 'calculate_pbest_obj_AF:44' AFfay2=sum(elements,2); */
  for (ix = 0; ix < 24; ix++) {
    for (ixstart = 0; ixstart < 90; ixstart++) {
      elements[ixstart + 90 * ix].re *= pos[ixstart + 90 * ix];
      elements[ixstart + 90 * ix].im *= pos[ixstart + 90 * ix];
    }

    /* for all particles */
    /* 'calculate_pbest_obj_AF:46' temp=repmat(beta.*r1.*sind(seta).*cosd(fay3-postion),no_of_particle,1); */
    dv1[ix] = 180.0 - postion[ix];
  }

  sum(elements, AFfay2);
  cosd(dv1);
  d0 = 90.0;
  sind(&d0);
  d0 *= 12.0;
  for (ix = 0; ix < 24; ix++) {
    dv2[ix] = d0 * dv1[ix];
  }

  repmat(dv2, temp);

  /* 'calculate_pbest_obj_AF:47' elements=I.*exp(1i.*(temp-phase)); */
  for (ix = 0; ix < 24; ix++) {
    for (ixstart = 0; ixstart < 90; ixstart++) {
      elements[ixstart + 90 * ix].re = (temp[ixstart + 90 * ix] - pos[ixstart +
        90 * (24 + ix)]) * 0.0;
      elements[ixstart + 90 * ix].im = temp[ixstart + 90 * ix] - pos[ixstart +
        90 * (24 + ix)];
    }
  }

  b_exp(elements);

  /* 'calculate_pbest_obj_AF:48' AFfay3=sum(elements,2); */
  for (ix = 0; ix < 24; ix++) {
    for (ixstart = 0; ixstart < 90; ixstart++) {
      elements[ixstart + 90 * ix].re *= pos[ixstart + 90 * ix];
      elements[ixstart + 90 * ix].im *= pos[ixstart + 90 * ix];
    }

    /* for all particles */
    /* 'calculate_pbest_obj_AF:50' temp=repmat(beta.*r1.*sind(seta).*cosd(fay4-postion),no_of_particle,1); */
    postion[ix] = 30.0 - postion[ix];
  }

  sum(elements, AFfay3);
  cosd(postion);
  d0 = 90.0;
  sind(&d0);
  d0 *= 12.0;
  for (ix = 0; ix < 24; ix++) {
    dv1[ix] = d0 * postion[ix];
  }

  repmat(dv1, temp);

  /* 'calculate_pbest_obj_AF:51' elements=I.*exp(1i.*(temp-phase)); */
  for (ix = 0; ix < 24; ix++) {
    for (ixstart = 0; ixstart < 90; ixstart++) {
      elements[ixstart + 90 * ix].re = (temp[ixstart + 90 * ix] - pos[ixstart +
        90 * (24 + ix)]) * 0.0;
      elements[ixstart + 90 * ix].im = temp[ixstart + 90 * ix] - pos[ixstart +
        90 * (24 + ix)];
    }
  }

  b_exp(elements);
  for (ix = 0; ix < 24; ix++) {
    for (ixstart = 0; ixstart < 90; ixstart++) {
      elements[ixstart + 90 * ix].re *= pos[ixstart + 90 * ix];
      elements[ixstart + 90 * ix].im *= pos[ixstart + 90 * ix];
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
  for (ix = 0; ix < 90; ix++) {
    fitness[ix] = ((fitness[ix] + dv5[ix]) + dv4[ix]) - dv3[ix];
  }

  /* 'calculate_pbest_obj_AF:56' [bestfitness,indx]=max(fitness); */
  ixstart = 1;
  *bestfitness = fitness[0];
  itmp = 0;
  if (rtIsNaN(fitness[0])) {
    ix = 2;
    exitg1 = FALSE;
    while ((exitg1 == 0U) && (ix < 91)) {
      ixstart = ix;
      if (!rtIsNaN(fitness[ix - 1])) {
        *bestfitness = fitness[ix - 1];
        exitg1 = TRUE;
      } else {
        ix++;
      }
    }
  }

  if (ixstart < 90) {
    while (ixstart + 1 < 91) {
      if (fitness[ixstart] > *bestfitness) {
        *bestfitness = fitness[ixstart];
        itmp = ixstart;
      }

      ixstart++;
    }
  }

  *indx = (real_T)(itmp + 1);

  /* 'calculate_pbest_obj_AF:57' iterbest=pos(indx,:); */
  /* 'calculate_pbest_obj_AF:58' iterbest=repmat(iterbest,no_of_particle,1); */
  for (ix = 0; ix < 48; ix++) {
    b_pos[ix] = pos[itmp + 90 * ix];
  }

  b_repmat(b_pos, iterbest);

  /* pbest = zeros(no_of_particle,2*n); */
  /* 'calculate_pbest_obj_AF:62' for P=1:no_of_particle */
  for (ixstart = 0; ixstart < 90; ixstart++) {
    /* 'calculate_pbest_obj_AF:63' if(fitness(P)>oldpfitness(P)) */
    if (fitness[ixstart] > oldpfitness[ixstart]) {
      /* 'calculate_pbest_obj_AF:64' pbest(P,:)=pos(P,:); */
      for (ix = 0; ix < 48; ix++) {
        pbest[ixstart + 90 * ix] = pos[ixstart + 90 * ix];
      }

      /* 'calculate_pbest_obj_AF:65' oldpfitness(P)=fitness(P); */
      oldpfitness[ixstart] = fitness[ixstart];
    }

    /*  oldpfitness(P)=fitness(P); */
  }
}

/* End of code generation (calculate_pbest_obj_AF.c) */
