/*
 * repmat.cpp
 *
 * Code generation for function 'repmat'
 *
 * C source code generated on: Tue May 22 03:41:52 2012
 *
 */

/* Include files */
#include "Calculate_Fitness_AF_fay.h"
#include "Calculate_Fitness_AFmin.h"
#include "calculate_pbest_obj_AF.h"
#include "repmat.h"

/* Type Definitions */

/* Named Constants */

/* Variable Declarations */

/* Variable Definitions */

/* Function Declarations */

/* Function Definitions */

/*
 *
 */
void b_repmat(const real_T a[48], real_T b[4320])
{
  int32_T ia;
  int32_T ib;
  int32_T iacol;
  int32_T jcol;
  int32_T itilerow;
  ia = 1;
  ib = 0;
  iacol = 1;
  for (jcol = 0; jcol < 48; jcol++) {
    for (itilerow = 0; itilerow < 90; itilerow++) {
      b[ib] = a[iacol - 1];
      ia = iacol + 1;
      ib++;
    }

    iacol = ia;
  }
}

/*
 *
 */
void repmat(const real_T a[24], real_T b[2160])
{
  int32_T ia;
  int32_T ib;
  int32_T iacol;
  int32_T jcol;
  int32_T itilerow;
  ia = 1;
  ib = 0;
  iacol = 1;
  for (jcol = 0; jcol < 24; jcol++) {
    for (itilerow = 0; itilerow < 90; itilerow++) {
      b[ib] = a[iacol - 1];
      ia = iacol + 1;
      ib++;
    }

    iacol = ia;
  }
}

/* End of code generation (repmat.cpp) */
