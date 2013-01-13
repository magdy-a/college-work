/*
 * cosd.c
 *
 * Code generation for function 'cosd'
 *
 * C source code generated on: Mon May 21 22:08:14 2012
 *
 */

/* Include files */
#include "rt_nonfinite.h"
#include "Calculate_Fitness_AF_fay.h"
#include "Calculate_Fitness_AFmin.h"
#include "calculate_pbest_obj_AF.h"
#include "cosd.h"
#include "sind.h"

/* Type Definitions */

/* Named Constants */

/* Variable Declarations */

/* Variable Definitions */

/* Function Declarations */

/* Function Definitions */

/*
 *
 */
void cosd(real_T x[24])
{
  int32_T k;
  real_T b_x;
  real_T n;
  for (k = 0; k < 24; k++) {
    if (!((!rtIsInf(x[k])) && (!rtIsNaN(x[k])))) {
      b_x = rtNaN;
    } else {
      eml_scalar_rem90(x[k], &n, &b_x);
      if (n == 0.0) {
        b_x = cos(b_x);
      } else if (n == 1.0) {
        b_x = -sin(b_x);
      } else if (n == -1.0) {
        b_x = sin(b_x);
      } else {
        b_x = -cos(b_x);
      }
    }

    x[k] = b_x;
  }
}

/* End of code generation (cosd.c) */
