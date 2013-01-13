/*
 * sind.c
 *
 * Code generation for function 'sind'
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
/* Type Definitions */

/* Named Constants */

/* Variable Declarations */

/* Variable Definitions */

/* Function Declarations */

/* Function Definitions */

/*
 *
 */
void eml_scalar_rem90(real_T x, real_T *n, real_T *y)
{
  real_T ix;
  x = fmod(x, 360.0);
  ix = fabs(x);
  if (ix > 180.0) {
    if (x > 0.0) {
      x -= 360.0;
    } else {
      x += 360.0;
    }

    ix = fabs(x);
  }

  if (ix <= 45.0) {
    *y = 0.017453292519943295 * x;
    *n = 0.0;
  } else if (ix <= 135.0) {
    if (x > 0.0) {
      *y = 0.017453292519943295 * (x - 90.0);
      *n = 1.0;
    } else {
      *y = 0.017453292519943295 * (x + 90.0);
      *n = -1.0;
    }
  } else if (x > 0.0) {
    *y = 0.017453292519943295 * (x - 180.0);
    *n = 2.0;
  } else {
    *y = 0.017453292519943295 * (x + 180.0);
    *n = -2.0;
  }
}

/*
 *
 */
void sind(real_T *x)
{
  real_T b_x;
  real_T n;
  if (!((!rtIsInf(*x)) && (!rtIsNaN(*x)))) {
    *x = rtNaN;
  } else {
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
}

/* End of code generation (sind.c) */
