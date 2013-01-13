//#include <cv.h>
//#include <cxcore.h>
//#include <highgui.h>
//
//#include "sift.h"
//#include "imgfeatures.h"
//#include "kdtree.h"
//#include "utils.h"
//#include "xform.h"
//
//#include <stdio.h>
//
//int main( int argc, char** argv )
//	{
//	CvPoint2D64f* pntSrc64,*pntDst64;
//
//	pntSrc64 = calloc(4,sizeof(CvPoint2D64f));
//	pntDst64 = calloc(4,sizeof(CvPoint2D64f));
//
//	pntSrc64[0] = cvPoint2D64f(1,1);
//	pntSrc64[1] = cvPoint2D64f(2,2);
//	pntSrc64[2] = cvPoint2D64f(3,3);
//	pntSrc64[3] = cvPoint2D64f(4,4);
//
//	pntDst64[0] = cvPoint2D64f(5,5);
//	pntDst64[1] = cvPoint2D64f(6,6);
//	pntDst64[2] = cvPoint2D64f(7,7);
//	pntDst64[3] = cvPoint2D64f(8,8);
//
//	lsq_homog(pntSrc64,pntDst64,4);
//
//	return 0;
//	}