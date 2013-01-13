/*
 * exp.cpp
 *
 * Code generation for function 'exp'
 *
 * C source code generated on: Tue May 22 03:41:52 2012
 *
 */

/* Include files */
#include "Calculate_Fitness_AF_fay.h"
#include "Calculate_Fitness_AFmin.h"
#include "calculate_pbest_obj_AF.h"
#include "exp.h"

/* Type Definitions */

/* Named Constants */

/* Variable Declarations */

/* Variable Definitions */

/* Function Declarations */

/* Function Definitions */

/*
 *
 */
void b_exp(creal_T x[2160])
{
  int32_T k;
  real_T r;
  real_T x_im;
  real_T b_x_im;
  for (k = 0; k < 2160; k++) {
    r = exp(x[k].re / 2.0);
    x_im = x[k].im;
    b_x_im = x[k].im;
    x[k].re = r * (r * cos(x_im));
    x[k].im = r * (r * sin(b_x_im));
  }
}

/* End of code generation (exp.cpp) */
