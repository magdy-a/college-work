//#include "opencv2/core/core.hpp"
//#include "opencv2/features2d/features2d.hpp"
//#include "opencv2/highgui/highgui.hpp"
//
//#include <cv.h>
//#include <highgui.h>
//
//#include "sift.h"
//#include "imgfeatures.h"
//#include "kdtree.h"
//#include "utils.h"
//#include "xform.h"
//
//#include <cv.h>
//#include <cxcore.h>
//#include <highgui.h>
//
//#include <stdio.h>
//
//#define KDTREE_BBF_MAX_NN_CHKS 200
//
//#define NN_SQ_DIST_RATIO_THR 0.4
//
////char img1_file[] = "..\\beaver.png";
////char img2_file[] = "..\\beaver_xform.png";
//char img1_file[] = "input1.jpg";
//char img2_file[] = "input2.jpg";
////char img1_file[] = "..\\image 7.bmp";
////char img2_file[] = "..\\image 8.bmp";
//
//int main(int argc, char* argv[])
//	{
//	IplImage* img1, * img2, * stacked;
//	struct feature* feat1, * feat2, * feat;
//	struct feature** nbrs;
//	struct kd_node* kd_root;
//	CvPoint pt1, pt2;
//	double d0, d1;
//	int n1, n2, k, i, m = 0;
//
//	// Load Images
//	img1 = cvLoadImage( img1_file, 1 );
//	if( ! img1 )
//		fatal_error( "unable to load image from %s", img1_file );
//	img2 = cvLoadImage( img2_file, 1 );
//	if( ! img2 )
//		fatal_error( "unable to load image from %s", img2_file );
//
//	// Load Stacked Image
//	stacked = cvLoadImage("stackedOriginal.jpg",1);
//
//	// Create Stacked Image
//	/*stacked = stack_imgs( img1, img2 );
//	cvSaveImage("stackedOriginal.jpg",stacked,0);*/
//
//	// Load Features
//	n1 = import_features("input1.sift",FEATURE_LOWE,&feat1);
//	if( n1 == -1 )
//		fatal_error( "unable to import features from %s", "input1.sift" );
//	n2 = import_features("input2.sift",FEATURE_LOWE,&feat2);
//	if( n2 == -1 )
//		fatal_error( "unable to import features from %s", "input2.sift" );
//
//	//// Get Features
//	//fprintf( stderr, "Finding features in %s...\n", img1_file );
//	//n1 = sift_features( img1, &feat1 );
//	//fprintf( stderr, "Finding features in %s...\n", img2_file );
//	//n2 = sift_features( img2, &feat2 );
//
//	// Get Matches
//	kd_root = kdtree_build( feat2, n2 );
//
//	for( i = 0; i < n1; i++ )
//		{
//		feat = feat1 + i;
//		k = kdtree_bbf_knn( kd_root, feat, 2, &nbrs, KDTREE_BBF_MAX_NN_CHKS );
//		if( k == 2 )
//			{
//			d0 = descr_dist_sq( feat, nbrs[0] );
//			d1 = descr_dist_sq( feat, nbrs[1] );
//			if( d0 < d1 * NN_SQ_DIST_RATIO_THR )
//				{
//				pt1 = cvPoint( cvRound( feat->x ), cvRound( feat->y ) );
//				pt2 = cvPoint( cvRound( nbrs[0]->x ), cvRound( nbrs[0]->y ) );
//				pt2.y += img1->height;
//				cvLine( stacked, pt1, pt2, CV_RGB(255,0,255), 1, 8, 0 );
//				m++;
//				feat1[i].fwd_match = nbrs[0];
//				}
//			}
//		free( nbrs );
//		}
//
//	fprintf( stderr, "Found %d total matches\n", m );
//	cvNamedWindow( "Matches", 1 );
//	cvShowImage( "Matches", stacked );
//	cvSaveImage("stackedMatch.jpg",stacked,0);
//
//		{
//	CvMat* H ;
//	IplImage* HDash;
//
//	// My Test Code
//
//	CvPoint2D32f* pntSrc32,*pntDst32;
//	CvPoint2D64f* pntSrc64,*pntDst64;
//
//	//CvMat* mapMatrix = cvCreateMat(3,3,CV_MAT32F), *homogMat;
//
//	int counter = 0;
//
//	for(i = 0 ; i < n1 ; i ++)
//		{
//		if(feat1[i].fwd_match)
//			{
//			counter ++;
//			}
//		}
//
//	/*pntSrc32 = calloc(counter,sizeof(struct CvPoint2D32f));
//	pntDst32 = calloc(counter,sizeof(struct CvPoint2D32f));
//
//	pntSrc64 = calloc(counter,sizeof(struct CvPoint2D64f));
//	pntDst64 = calloc(counter,sizeof(struct CvPoint2D64f));*/
//
//	counter = 0;
//
//	for(i = 0 ; i < n1 ; i ++)
//		{
//		if(feat1[i].fwd_match)
//			{
//			// Set 32 data
//			pntSrc32[counter] = cvPoint2D32f(feat1[i].x,feat1[i].y);
//			pntDst32[counter] = cvPoint2D32f(feat1[i].fwd_match->x,feat1[i].fwd_match->y);
//
//			// Set 64 data
//			pntSrc64[counter] = cvPoint2D64f(feat1[i].x,feat1[i].y);
//			pntDst64[counter] = cvPoint2D64f(feat1[i].fwd_match->x,feat1[i].fwd_match->y);
//
//			// Inc counter
//			counter ++;
//			}
//		}
//
//	HDash = cvCreateImage(cvSize(2,3),IPL_DEPTH_8U,3);
//	//H = cv::cvarrToMat(HDash);
//
//	// TODO Check this function's parameters and how to use it
//	cvConvertImage(HDash,H,0);
//	cvGetAffineTransform(pntSrc32,pntDst32, H);
//
//	// End of My Test Code
//
//	H = ransac_xform( feat1, n1, FEATURE_FWD_MATCH, lsq_homog, 4, 0.01,homog_xfer_err, 3.0, NULL, NULL );
//
//	//H = dlt_homog(pntSrc64,pntDst64,counter);
//
//	//H = lsq_homog(pntSrc64,pntDst64,counter);
//
//	// Test change of lsq_homog to dlt_homog
//	//H = ransac_xform(feat1,n1,FEATURE_FWD_MATCH,dlt_homog,4,0.01,homog_xfer_err,3.0,NULL,NULL);
//
//	if( H )
//		{
//		IplImage* xformed;
//		xformed = cvCreateImage( cvGetSize( img2 ), IPL_DEPTH_8U, 3 );
//
//		cvWarpAffine( img1, xformed, H,
//			CV_INTER_LINEAR + CV_WARP_FILL_OUTLIERS,
//			cvScalarAll( 0 ) );
//
//		/*cvWarpPerspective( img1, xformed, H,
//		CV_INTER_LINEAR + CV_WARP_FILL_OUTLIERS,
//		cvScalarAll( 0 ) );*/
//
//		cvNamedWindow( "Xformed", 1 );
//		cvShowImage( "Xformed", xformed );
//		cvSaveImage("Xformed.jpg",xformed,0);
//
//		cvWaitKey( 0 );
//		cvReleaseImage( &xformed );
//		cvReleaseMat( &H );
//		}
//		}
//
//	cvReleaseImage( &stacked );
//	cvReleaseImage( &img1 );
//	cvReleaseImage( &img2 );
//	kdtree_release( kd_root );
//	free( feat1 );
//	free( feat2 );
//	return 0;
//	}