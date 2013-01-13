//#include <cv.h>
//#include <highgui.h>
//
//#include "sift.h"
//#include "imgfeatures.h"
//#include "kdtree.h"
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
//char *srcVid = "testVideo3.avi", * dstVid = "matchWrapResult.avi";
//
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
//
//	int frmCounter = 0;
//
//	CvCapture* capture = cvCaptureFromFile(srcVid);
//	CvVideoWriter* writer = cvCreateAVIWriter(dstVid,(int)cvGetCaptureProperty(capture,CV_CAP_PROP_FOURCC), (double)cvGetCaptureProperty(capture,CV_CAP_PROP_FPS),cvSize((int)cvGetCaptureProperty(capture,CV_CAP_PROP_FRAME_WIDTH),(int)cvGetCaptureProperty(capture,CV_CAP_PROP_FRAME_HEIGHT)),1);
//
//	CvMat *H;
//
//	fprintf(stderr,"Video file: %s is opened successfully, which has #frames: %d, fps: %d",srcVid, (int)cvGetCaptureProperty(capture,CV_CAP_PROP_FRAME_COUNT), (int)cvGetCaptureProperty(capture,CV_CAP_PROP_FPS));
//
//	cvNamedWindow( frmStabilized, 1 );
//	cvNamedWindow( frmOriginal, 1 );
//
//	// Get the First Match Frame
//	cvGrabFrame(capture);
//	img1 = cvRetrieveFrame(capture,0);
//	if(! img1)return -1;
//	n1 = sift_features(img1,&feat1);
//	// End of Get First Match Frame
//
//	fprintf(stderr,"got match frame @: %d", ++frmCounter);
//
//	for(;;)
//		{
//		// Get new Frame
//		cvGrabFrame(capture);
//		img2 = cvRetrieveFrame(capture,0);
//		if(!img2) break;
//		n2 = sift_features(img2,&feat2);
//		// End of Get new Frame
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
//		// Perespective Transform
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
//			// Save the Frame
//			cvWriteFrame(writer,xformed);
//
//			// Show the Images
//			cvShowImage(frmOriginal,img2);
//			cvShowImage( frmStabilized, xformed );
//
//			fprintf(stderr,"frame:%d",++frmCounter);
//
//			// Wait for Key
//			if(cvWaitKey( 0 ) == 27) break;
//			}
//		else
//			{
//			// Get new Match Frame
//			cvGrabFrame(capture);
//			img1 = cvRetrieveFrame(capture,0);
//			if(!img1) break;
//			n1 = sift_features(img1,&feat1);
//			// End of Get new Match Frame
//
//			fprintf(stderr,"got match frame @: %d", ++frmCounter);
//			}
//		// End of Perespective Transform
//		}
//
//	// Release data
//	cvReleaseCapture(&capture);
//	cvReleaseVideoWriter(&writer);
//
//	return 0;
//	}