/*
 * abs.cpp
 *
 * Code generation for function 'abs'
 *
 * C source code generated on: Tue May 22 03:41:52 2012
 *
 */

/* Include files */
#include "Calculate_Fitness_AF_fay.h"
#include "Calculate_Fitness_AFmin.h"
#include "calculate_pbest_obj_AF.h"
#include "abs.h"
#include "PSO_Library_rtwutil.h"

/* Type Definitions */

/* Named Constants */

/* Variable Declarations */

/* Variable Definitions */

/* Function Declarations */

/* Function Definitions */

/*
 *
 */
void b_abs(const creal_T x[90], real_T y[90])
{
  int32_T k;
  for (k = 0; k < 90; k++) {
    y[k] = rt_hypotd(fabs(x[k].re), fabs(x[k].im));
  }
}

/* End of code generation (abs.cpp) */
