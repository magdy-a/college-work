/*
 * cosd.cpp
 *
 * Code generation for function 'cosd'
 *
 * C source code generated on: Tue May 22 03:41:52 2012
 *
 */

/* Include files */
#include "Calculate_Fitness_AF_fay.h"
#include "Calculate_Fitness_AFmin.h"
#include "calculate_pbest_obj_AF.h"
#include "cosd.h"

/* Type Definitions */

/* Named Constants */

/* Variable Declarations */

/* Variable Definitions */

/* Function Declarations */
static real_T rt_remd(real_T u0, real_T u1);
static real_T rt_roundd(real_T u);

/* Function Definitions */
static real_T rt_remd(real_T u0, real_T u1)
{
  real_T y;
  real_T tr;
  if (u1 < 0.0) {
    y = ceil(u1);
  } else {
    y = floor(u1);
  }

  if ((u1 != 0.0) && (u1 != y)) {
    tr = u0 / u1;
    if (fabs(tr - rt_roundd(tr)) <= DBL_EPSILON * fabs(tr)) {
      y = 0.0;
    } else {
      y = fmod(u0, u1);
    }
  } else {
    y = fmod(u0, u1);
  }

  return y;
}

static real_T rt_roundd(real_T u)
{
  real_T y;
  if (fabs(u) < 4.503599627370496E+15) {
    if (u >= 0.5) {
      y = floor(u + 0.5);
    } else if (u > -0.5) {
      y = 0.0;
    } else {
      y = ceil(u - 0.5);
    }
  } else {
    y = u;
  }

  return y;
}

/*
 *
 */
void cosd(real_T x[24])
{
  int32_T k;
  real_T b_x;
  real_T n;
  for (k = 0; k < 24; k++) {
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

    x[k] = b_x;
  }
}

/*
 *
 */
void eml_scalar_rem90(real_T x, real_T *n, real_T *y)
{
  real_T ix;
  x = rt_remd(x, 360.0);
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

/* End of code generation (cosd.cpp) */
