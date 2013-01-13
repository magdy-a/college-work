/*
 * Calculate_Fitness_AFmin.c
 *
 * Code generation for function 'Calculate_Fitness_AFmin'
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
 * function AF=Calculate_Fitness_AFmin(p)
 */
real_T Calculate_Fitness_AFmin(const real_T p[48])
{
  real_T postion[24];
  int32_T i;
  real_T dv0[24];
  real_T AF4_re;
  creal_T elements[24];
  creal_T x[24];
  real_T AF4_im;
  real_T x_im;
  real_T AF1_re;
  real_T AF1_im;
  real_T AF2_re;
  real_T AF2_im;
  real_T AF3_re;
  real_T AF3_im;

  /* 'Calculate_Fitness_AFmin:3' coder.inline('never') */
  /* Calculate fitness of specific particle */
  /* 'Calculate_Fitness_AFmin:7' fay1=0; */
  /* 'Calculate_Fitness_AFmin:8' fay2=90; */
  /* 'Calculate_Fitness_AFmin:9' fay3=180; */
  /* 'Calculate_Fitness_AFmin:10' fay4=30; */
  /* Duplicated Code */
  /* 'Calculate_Fitness_AFmin:13' n=24; */
  /* number of antenna element in the array */
  /* 'Calculate_Fitness_AFmin:14' degreestep=360/n; */
  /* 'Calculate_Fitness_AFmin:15' wl=1; */
  /* wave length */
  /* 'Calculate_Fitness_AFmin:16' d=0.5; */
  /* 'Calculate_Fitness_AFmin:17' beta=(2*pi)/wl; */
  /* phase shift */
  /* 'Calculate_Fitness_AFmin:18' seta=90; */
  /* because we will work only on horizontal level (in 2d)so zaxis will be 90 */
  /* 'Calculate_Fitness_AFmin:19' r1=(n*d*wl)/(2*pi); */
  /* radius of the circle */
  /* 'Calculate_Fitness_AFmin:21' I=p(1:24); */
  /* 'Calculate_Fitness_AFmin:22' phase=p(25:48); */
  /* Initialize Postion Vector */
  /* 'Calculate_Fitness_AFmin:25' postion = zeros(1,n); */
  memset(&postion[0], 0, 24U * sizeof(real_T));

  /* Set Initial Value */
  /* 'Calculate_Fitness_AFmin:28' postion(1)=0; */
  postion[0] = 0.0;

  /*  from 2 to n */
  /* 'Calculate_Fitness_AFmin:31' for i=2:n */
  for (i = 0; i < 23; i++) {
    /* 'Calculate_Fitness_AFmin:32' postion(i)=postion(i-1)+degreestep; */
    postion[1 + i] = postion[i] + 15.0;
  }

  /* end of %Duplicated Code */
  /* 'Calculate_Fitness_AFmin:37' elements=I.*exp(1i.*(beta.*r1.*sind(seta).*cosd(fay1-postion)-phase)); */
  for (i = 0; i < 24; i++) {
    dv0[i] = 0.0 - postion[i];
  }

  cosd(dv0);
  AF4_re = 90.0;
  sind(&AF4_re);
  AF4_re *= 12.0;
  for (i = 0; i < 24; i++) {
    x[i].re = (AF4_re * dv0[i] - p[24 + i]) * 0.0;
    x[i].im = AF4_re * dv0[i] - p[24 + i];
    AF4_im = exp(x[i].re / 2.0);
    x_im = x[i].im;
    x[i].re = AF4_im * (AF4_im * cos(x[i].im));
    x[i].im = AF4_im * (AF4_im * sin(x_im));
    elements[i].re = p[i] * x[i].re;
    elements[i].im = p[i] * x[i].im;
  }

  /* 'Calculate_Fitness_AFmin:38' AF1=sum(elements); */
  AF1_re = elements[0].re;
  AF1_im = elements[0].im;
  for (i = 0; i < 23; i++) {
    AF1_re += elements[i + 1].re;
    AF1_im += elements[i + 1].im;
  }

  /* 'Calculate_Fitness_AFmin:41' elements=I.*exp(1i.*(beta.*r1.*sind(seta).*cosd(fay2-postion)-phase)); */
  for (i = 0; i < 24; i++) {
    dv0[i] = 90.0 - postion[i];
  }

  cosd(dv0);
  AF4_re = 90.0;
  sind(&AF4_re);
  AF4_re *= 12.0;
  for (i = 0; i < 24; i++) {
    x[i].re = (AF4_re * dv0[i] - p[24 + i]) * 0.0;
    x[i].im = AF4_re * dv0[i] - p[24 + i];
    AF4_im = exp(x[i].re / 2.0);
    x_im = x[i].im;
    x[i].re = AF4_im * (AF4_im * cos(x[i].im));
    x[i].im = AF4_im * (AF4_im * sin(x_im));
    elements[i].re = p[i] * x[i].re;
    elements[i].im = p[i] * x[i].im;
  }

  /* 'Calculate_Fitness_AFmin:42' AF2=sum(elements); */
  AF2_re = elements[0].re;
  AF2_im = elements[0].im;
  for (i = 0; i < 23; i++) {
    AF2_re += elements[i + 1].re;
    AF2_im += elements[i + 1].im;
  }

  /* 'Calculate_Fitness_AFmin:44' elements=I.*exp(1i.*(beta.*r1.*sind(seta).*cosd(fay3-postion)-phase)); */
  for (i = 0; i < 24; i++) {
    dv0[i] = 180.0 - postion[i];
  }

  cosd(dv0);
  AF4_re = 90.0;
  sind(&AF4_re);
  AF4_re *= 12.0;
  for (i = 0; i < 24; i++) {
    x[i].re = (AF4_re * dv0[i] - p[24 + i]) * 0.0;
    x[i].im = AF4_re * dv0[i] - p[24 + i];
    AF4_im = exp(x[i].re / 2.0);
    x_im = x[i].im;
    x[i].re = AF4_im * (AF4_im * cos(x[i].im));
    x[i].im = AF4_im * (AF4_im * sin(x_im));
    elements[i].re = p[i] * x[i].re;
    elements[i].im = p[i] * x[i].im;
  }

  /* 'Calculate_Fitness_AFmin:45' AF3=sum(elements); */
  AF3_re = elements[0].re;
  AF3_im = elements[0].im;
  for (i = 0; i < 23; i++) {
    AF3_re += elements[i + 1].re;
    AF3_im += elements[i + 1].im;
  }

  /* 'Calculate_Fitness_AFmin:47' elements=I.*exp(1i.*(beta.*r1.*sind(seta).*cosd(fay4-postion)-phase)); */
  for (i = 0; i < 24; i++) {
    postion[i] = 30.0 - postion[i];
  }

  cosd(postion);
  AF4_re = 90.0;
  sind(&AF4_re);
  AF4_re *= 12.0;
  for (i = 0; i < 24; i++) {
    x[i].re = (AF4_re * postion[i] - p[24 + i]) * 0.0;
    x[i].im = AF4_re * postion[i] - p[24 + i];
    AF4_im = exp(x[i].re / 2.0);
    x_im = x[i].im;
    x[i].re = AF4_im * (AF4_im * cos(x[i].im));
    x[i].im = AF4_im * (AF4_im * sin(x_im));
    elements[i].re = p[i] * x[i].re;
    elements[i].im = p[i] * x[i].im;
  }

  /* 'Calculate_Fitness_AFmin:48' AF4=sum(elements); */
  AF4_re = elements[0].re;
  AF4_im = elements[0].im;
  for (i = 0; i < 23; i++) {
    AF4_re += elements[i + 1].re;
    AF4_im += elements[i + 1].im;
  }

  /* 'Calculate_Fitness_AFmin:50' AF=-1*(abs(AF1)+abs(AF2)+abs(AF3)-abs(AF4)); */
  return -(((hypot(fabs(AF1_re), fabs(AF1_im)) + hypot(fabs(AF2_re), fabs(AF2_im)))
            + hypot(fabs(AF3_re), fabs(AF3_im))) - hypot(fabs(AF4_re), fabs
            (AF4_im)));
}

/* End of code generation (Calculate_Fitness_AFmin.c) */
