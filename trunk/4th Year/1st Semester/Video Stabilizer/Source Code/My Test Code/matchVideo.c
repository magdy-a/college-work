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
//#define KDTREE_BBF_MAX_NN_CHKS 200
//
//#define NN_SQ_DIST_RATIO_THR 0.4
//
//#define NUM_FRAMES_WITH_SAME_MATCH 50
//
//char* srcVid = "testVideo3.avi";
//char* dstVid = "matchWrapResult.avi";
//char *frmOriginal = "Xoriginal",*frmStabilized = "Xformed";
//
//int main( int argc, char** argv )
//	{
//	IplImage* img1, * img2,* xformed;
//
//	struct feature* feat1, * feat2, * feat;
//	struct feature** nbrs;
//
//	struct kd_node* kd_root;
//
//	double d0, d1;
//	int n1, n2, k, i, m = 0;
//	int pntCounter,frmCounter = 0;
//
//	CvCapture* capture = cvCaptureFromFile(srcVid);
//	CvVideoWriter* writer = cvCreateAVIWriter(dstVid,(int)cvGetCaptureProperty(capture,CV_CAP_PROP_FOURCC), (double)cvGetCaptureProperty(capture,CV_CAP_PROP_FPS),cvSize((int)cvGetCaptureProperty(capture,CV_CAP_PROP_FRAME_WIDTH),(int)cvGetCaptureProperty(capture,CV_CAP_PROP_FRAME_HEIGHT)),1);
//
//	CvMat *H;
//	//CvPoint2D32f* pntSrc32,*pntDst32;
//
//	// TODO get the return type of getAffineTransform and see what is it : CvMat *z = cvCreateImage(
//
//	fprintf(stderr,"Video file: %s is opened successfully, which has #frames: %d, fps: %d",srcVid, (int)cvGetCaptureProperty(capture,CV_CAP_PROP_FRAME_COUNT), (int)cvGetCaptureProperty(capture,CV_CAP_PROP_FPS));
//
//	cvNamedWindow( frmStabilized, 1 );
//	cvNamedWindow( frmOriginal, 1 );
//
//	// Get the First Frame from the Camera
//	cvGrabFrame(capture);
//	img1 = cvRetrieveFrame(capture,0);
//	if(! img1)return -1;
//	n1 = sift_features(img1,&feat1);
//
//	fprintf(stderr,"got match frame @: %d", ++frmCounter);
//
//	for(;;)
//		{
//		// Get new Frame from the Camera
//		cvGrabFrame(capture);
//		img2 = cvRetrieveFrame(capture,0);
//		if(!img2) break;
//		n2 = sift_features(img2,&feat2);
//		// End of Get new Frame from the Camera
//
//		// TODO inverse Match case
//
//		// Get Matches, using KD_Tree, but them in feat2 Array ... "feat2[i].bck_match"
//		kd_root = kdtree_build( feat1, n1 );
//		for( i = 0; i < n2; i++ )
//			{
//			feat = feat2 + i;
//			k = kdtree_bbf_knn( kd_root, feat, 2, &nbrs, KDTREE_BBF_MAX_NN_CHKS );
//			if( k == 2 )
//				{
//				d0 = descr_dist_sq( feat, nbrs[0] );
//				d1 = descr_dist_sq( feat, nbrs[1] );
//				if( d0 < d1 * NN_SQ_DIST_RATIO_THR )
//					{
//					m++;
//					feat2[i].bck_match = nbrs[0];
//					}
//				}
//			free( nbrs );
//			}
//		// End of Get Matches
//
//		// End of Inverse Match case
//
//		//// Get Matches, using KD_Tree, but them in feat1 Array ... "feat1[i].fwd_match"
//		//kd_root = kdtree_build( feat2, n2 );
//		//for( i = 0; i < n1; i++ )
//		//	{
//		//	feat = feat1 + i;
//		//	k = kdtree_bbf_knn( kd_root, feat, 2, &nbrs, KDTREE_BBF_MAX_NN_CHKS );
//		//	if( k == 2 )
//		//		{
//		//		d0 = descr_dist_sq( feat, nbrs[0] );
//		//		d1 = descr_dist_sq( feat, nbrs[1] );
//		//		if( d0 < d1 * NN_SQ_DIST_RATIO_THR )
//		//			{
//		//			m++;
//		//			feat1[i].fwd_match = nbrs[0];
//		//			}
//		//		}
//		//	free( nbrs );
//		//	}
//		//// End of Get Matches
//
//		// Transformations
//
//		// TODO Test inverse perespective tranform
//
//		// Perespective Transform
//
//		// TODO See if you can update the ransac_xform function to return a homography matrix, that returns the warped image to it's original place directly
//
//		// get homography matrix
//		H = ransac_xform( feat2, n2, FEATURE_BCK_MATCH, lsq_homog, 4, 0.01,homog_xfer_err, 3.0, NULL, NULL );
//
//		// warp the image prespectively
//		if( H )
//			{
//			// Create a result image
//			xformed = cvCreateImage( cvGetSize( img1 ), IPL_DEPTH_8U, 3 );
//
//			// Warp the Image Perespectively
//			cvWarpPerspective( img2, xformed, H,CV_INTER_LINEAR + CV_WARP_FILL_OUTLIERS,cvScalarAll( 0 ) );
//
//			// Testing Perespective Transform only
//			cvWriteFrame(writer,xformed);
//
//			cvShowImage(frmOriginal,img2);
//			cvShowImage( frmStabilized, xformed );
//			if(cvWaitKey( 0 ) == 27) break;
//
//			// End of Testing Perespective Transform only
//			}
//		else
//			{
//			// Grab new frame
//			cvGrabFrame(capture);
//			img1 = cvRetrieveFrame(capture,0);
//			if(!img1) break;
//			n1 = sift_features(img1,&feat1);
//
//			// TODO No Need for continue, all the code is already commented
//			//continue;
//			}
//
//		// End of Perespective Transform
//
//		// TODO End of Test inverse perespective transfore
//
//		//// Perespective Transform
//
//		//// TODO See if you can update the ransac_xform function to return a homography matrix, that returns the warped image to it's original place directly
//
//		////// get homography matrix
//		//H = ransac_xform( feat1, n1, FEATURE_FWD_MATCH, lsq_homog, 4, 0.01,homog_xfer_err, 3.0, NULL, NULL );
//
//		//// warp the image prespectively
//		//if( H )
//		//	{
//		//	// Create a result image
//		//	xformed = cvCreateImage( cvGetSize( img2 ), IPL_DEPTH_8U, 3 );
//
//		//	// Warp the Image Perespectively
//		//	cvWarpPerspective( img1, xformed, H,CV_INTER_LINEAR + CV_WARP_FILL_OUTLIERS,cvScalarAll( 0 ) );
//
//		//	// Testing Perespective Transform only
//		//	//cvWriteFrame(writer,xformed);
//		//	cvShowImage( frmStabilized, xformed );
//		//	if(cvWaitKey( 10 ) == 27) break;
//		//	// End of Testing Perespective Transform only
//		//	}
//		//else continue;
//
//		//// End of Perespective Transform
//
//		// Affine Transform
//
//		//// create empty matrix_map 2X3
//		//H = cvCreateMat(2,3,CV_32FC1);
//
//		//// create empty lists with length of 3
//		//pntSrc32 = calloc(3,sizeof(struct CvPoint2D32f));
//		//pntDst32 = calloc(3,sizeof(struct CvPoint2D32f));
//
//		//// TODO See another way to define the 3 points of the affine transformation
//		//// TODO See a way to determine the rotation in the current frame
//
//		//// Get first 3 matched points
//		//for(i = 0, pntCounter = 0 ; i < n1 && pntCounter < 3 ; i ++)
//		//	{
//		//	if(feat1[i].fwd_match)
//		//		{
//		//		pntSrc32[pntCounter] = cvPoint2D32f(feat1[i].x,feat1[i].y);
//		//		pntDst32[pntCounter] = cvPoint2D32f(feat1[i].fwd_match->x,feat1[i].fwd_match->y);
//
//		//		// Inc counter
//		//		pntCounter ++;
//		//		}
//		//	}
//		//// End of Get first 3 matched points
//
//		//// Get Affine Transform
//		//cvGetAffineTransform(pntDst32,pntSrc32, H);
//
//		//// Warp the image Affinly
//		//if( H )
//		//	{
//		//	//xformed = cvCreateImage( cvGetSize( img2 ), IPL_DEPTH_8U, 3 );
//
//		//	cvWarpAffine( img1, xformed, H,CV_INTER_LINEAR + CV_WARP_FILL_OUTLIERS,cvScalarAll( 0 ) );
//
//		//	cvShowImage( frmStabilized, xformed );
//		//	//cvWriteFrame(writer,xformed);
//		//	if(cvWaitKey( 10 ) == 27) break;
//		//	}
//
//		// End of Affine Transform
//
//		// End Transformation
//
//		// TODO Test New way to get a matching frame
//		// m is the number of matches
//
//		/*if(m < 100 || frmCounter % NUM_FRAMES_WITH_SAME_MATCH == 0)
//		{
//		cvGrabFrame(capture);
//		img1 = cvRetrieveFrame(capture,0);
//		if(!img1) break;
//		n1 = sift_features(img1,&feat1);
//		fprintf(stderr,"\ngot match frame (m=%d) @: %d\n",m,++frmCounter);
//		}*/
//
//		// TODO End Test New way to get a matching frame
//
//		//// Check for a specific num of Frames to get a new match frame
//		//if(++frmCounter % NUM_FRAMES_WITH_SAME_MATCH == 0)
//		//	{
//		//	cvGrabFrame(capture);
//		//	img1 = cvRetrieveFrame(capture,0);
//		//	if(!img1) break;
//		//	n1 = sift_features(img1,&feat1);
//		//	fprintf(stderr,"got match frame @: %d", ++frmCounter);
//		//	}
//		//// End of check a specific number of frames
//
//		// Write the frame number on screen
//		//fprintf(stderr,"frame:%d",++frmCounter);
//		}
//
//	// Release data
//	cvReleaseCapture(&capture);
//	cvReleaseVideoWriter(&writer);
//
//	return 0;
//	}