/*
 * sum.cpp
 *
 * Code generation for function 'sum'
 *
 * C source code generated on: Tue May 22 03:41:52 2012
 *
 */

/* Include files */
#include "Calculate_Fitness_AF_fay.h"
#include "Calculate_Fitness_AFmin.h"
#include "calculate_pbest_obj_AF.h"
#include "sum.h"

/* Type Definitions */

/* Named Constants */

/* Variable Declarations */

/* Variable Definitions */

/* Function Declarations */

/* Function Definitions */

/*
 *
 */
void sum(const creal_T x[2160], creal_T y[90])
{
  int32_T iy;
  int32_T ixstart;
  int32_T j;
  int32_T ix;
  real_T s_re;
  real_T s_im;
  int32_T k;
  iy = -1;
  ixstart = -1;
  for (j = 0; j < 90; j++) {
    ixstart++;
    ix = ixstart;
    s_re = x[ixstart].re;
    s_im = x[ixstart].im;
    for (k = 0; k < 23; k++) {
      ix += 90;
      s_re += x[ix].re;
      s_im += x[ix].im;
    }

    iy++;
    y[iy].re = s_re;
    y[iy].im = s_im;
  }
}

/* End of code generation (sum.cpp) */
