/*
 * Calculate_Fitness_AF_fay.c
 *
 * Code generation for function 'Calculate_Fitness_AF_fay'
 *
 * C source code generated on: Mon May 21 22:08:14 2012
 *
 */

/* Include files */
#include "rt_nonfinite.h"
#include "Calculate_Fitness_AF_fay.h"
#include "Calculate_Fitness_AFmin.h"
#include "calculate_pbest_obj_AF.h"
#include "sind.h"
#include "cosd.h"

/* Type Definitions */

/* Named Constants */

/* Variable Declarations */

/* Variable Definitions */

/* Function Declarations */

/* Function Definitions */

/*
 * function AF=Calculate_Fitness_AF_fay(p,fay)
 */
real_T Calculate_Fitness_AF_fay(const real_T p[48], real_T fay)
{
  real_T postion[24];
  int32_T i;
  real_T AF1_re;
  creal_T elements[24];
  creal_T x[24];
  real_T AF1_im;
  real_T x_im;

  /* 'Calculate_Fitness_AF_fay:3' coder.inline('never') */
  /* calculate Fitness(Array Factor) at specific angle(fay) */
  /* Duplicated Code */
  /* 'Calculate_Fitness_AF_fay:8' n=24; */
  /* number of antenna element in the array */
  /* 'Calculate_Fitness_AF_fay:9' degreestep=360/n; */
  /* 'Calculate_Fitness_AF_fay:10' wl=1; */
  /* wave length */
  /* 'Calculate_Fitness_AF_fay:11' d=0.5; */
  /* 'Calculate_Fitness_AF_fay:12' beta=(2*pi)/wl; */
  /* phase shift */
  /* 'Calculate_Fitness_AF_fay:13' seta=90; */
  /* because we will work only on horizontal level (in 2d)so zaxis will be 90 */
  /* 'Calculate_Fitness_AF_fay:14' r1=(n*d*wl)/(2*pi); */
  /* radius of the circle */
  /* 'Calculate_Fitness_AF_fay:16' I=p(1:24); */
  /* 'Calculate_Fitness_AF_fay:17' phase=p(25:48); */
  /* Initialize Postion Vector */
  /* 'Calculate_Fitness_AF_fay:20' postion = zeros(1,n); */
  memset(&postion[0], 0, 24U * sizeof(real_T));

  /* Set Initial Value */
  /* 'Calculate_Fitness_AF_fay:23' postion(1)=0; */
  postion[0] = 0.0;

  /*  from 2 to n */
  /* 'Calculate_Fitness_AF_fay:26' for i=2:n */
  for (i = 0; i < 23; i++) {
    /* 'Calculate_Fitness_AF_fay:27' postion(i)=postion(i-1)+degreestep; */
    postion[1 + i] = postion[i] + 15.0;
  }

  /* end of %Duplicated Code */
  /* 'Calculate_Fitness_AF_fay:32' elements=I.*exp(1i.*(beta.*r1.*sind(seta).*cosd(fay-postion)-phase)); */
  for (i = 0; i < 24; i++) {
    postion[i] = fay - postion[i];
  }

  cosd(postion);
  AF1_re = 90.0;
  sind(&AF1_re);
  AF1_re *= 12.0;
  for (i = 0; i < 24; i++) {
    x[i].re = (AF1_re * postion[i] - p[24 + i]) * 0.0;
    x[i].im = AF1_re * postion[i] - p[24 + i];
    AF1_im = exp(x[i].re / 2.0);
    x_im = x[i].im;
    x[i].re = AF1_im * (AF1_im * cos(x[i].im));
    x[i].im = AF1_im * (AF1_im * sin(x_im));
    elements[i].re = p[i] * x[i].re;
    elements[i].im = p[i] * x[i].im;
  }

  /* 'Calculate_Fitness_AF_fay:33' AF1=sum(elements); */
  AF1_re = elements[0].re;
  AF1_im = elements[0].im;
  for (i = 0; i < 23; i++) {
    AF1_re += elements[i + 1].re;
    AF1_im += elements[i + 1].im;
  }

  /* 'Calculate_Fitness_AF_fay:34' AF=abs(AF1); */
  return hypot(fabs(AF1_re), fabs(AF1_im));
}

/* End of code generation (Calculate_Fitness_AF_fay.c) */