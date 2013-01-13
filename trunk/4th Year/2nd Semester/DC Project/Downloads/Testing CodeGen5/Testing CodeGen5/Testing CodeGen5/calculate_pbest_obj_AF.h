/*
 * calculate_pbest_obj_AF.h
 *
 * Code generation for function 'calculate_pbest_obj_AF'
 *
 * C source code generated on: Mon May 21 22:08:14 2012
 *
 */

#ifndef __CALCULATE_PBEST_OBJ_AF_H__
#define __CALCULATE_PBEST_OBJ_AF_H__
/* Include files */
#include <math.h>
#include <stddef.h>
#include <stdlib.h>
#include <string.h>
#include "rt_nonfinite.h"

#include "rtwtypes.h"
#include "Calculate_Fitness_AF_fay_types.h"

/* Type Definitions */

/* Named Constants */

/* Variable Declarations */

/* Variable Definitions */

/* Function Declarations */
#ifdef __cplusplus
extern "C" {
#endif
extern void calculate_pbest_obj_AF(const real_T pos[4320], real_T pbest[4320], real_T oldpfitness[90], real_T iterbest[4320], real_T *indx, real_T *bestfitness);
#ifdef __cplusplus
}
#endif
#endif
/* End of code generation (calculate_pbest_obj_AF.h) */
