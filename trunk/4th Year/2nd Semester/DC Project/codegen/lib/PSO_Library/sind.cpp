/*
 * sind.cpp
 *
 * Code generation for function 'sind'
 *
 * C source code generated on: Tue May 22 03:41:52 2012
 *
 */

/* Include files */
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
 *
 */
void sind(real_T *x)
{
  real_T b_x;
  real_T n;
  eml_scalar_rem90(*x, &n, &b_x);
  if (n == 0.0) {
    *x = sin(b_x);
  } else if (n == 1.0) {
    *x = cos(b_x);
  } else if (n == -1.0) {
    *x = -cos(b_x);
  } else {
    *x = -sin(b_x);
  }
}

/* End of code generation (sind.cpp) */
