//#include "opencv2/core/core.hpp"
//#include "opencv2/features2d/features2d.hpp"
//#include "opencv2/highgui/highgui.hpp"

#include <cv.h>
#include <highgui.h>

//int main(int argc, char* argv[])
//	{
//	cv::Mat img1, img2;
//	cv::Mat output1,output2;
//	cv::Mat descriptor1,descriptor2;
//	cv::vector<cv::DMatch> matches;
//	cv::Mat result;
//
//	// loading images
//
//	img1 = cv::imread("input1.jpg",CV_LOAD_IMAGE_GRAYSCALE);
//	img2 = cv::imread("input2.jpg",CV_LOAD_IMAGE_GRAYSCALE);
//
//	if(img1.empty() || img2.empty())
//	{
//		printf("Can't read one of the images\n");
//		return -1;
//	}
//
//	/*cv::imshow("Image1 Original",img1);
//	cv::imshow("Image2 Original",img2);*/
//
//	// detecting keypoints
//	cv::SiftFeatureDetector detector;
//	std::vector<cv::KeyPoint> keyPoints1,keyPoints2;
//	detector.detect(img1,keyPoints1);
//	detector.detect(img2,keyPoints2);
//
//	cv::drawKeypoints(img1,keyPoints1,output1);
//	cv::drawKeypoints(img2,keyPoints2,output2);
//
//	cv::imshow("Image1 SIFT",output1);
//	cv::imshow("Image2 SIFT",output2);
//
//	cvMoveWindow("Image2 SIFT",140,160);
//
//	// computing descriptors
//	cv::SiftDescriptorExtractor extractor;
//	extractor.compute(img1,keyPoints1,descriptor1);
//	extractor.compute(img2,keyPoints2,descriptor2);
//
//	// matching descriptors
//	//cv::BruteForceMatcher< cv::L2<float> > matcher;
//	cv::FlannBasedMatcher matcher;
//	matcher.match(descriptor1,descriptor2,matches);
//
//	/*cv::imshow("descriptor1",descriptor1);
//	cv::imshow("descriptor2",descriptor2);*/
//
//	// drawing the result
//	cv::drawMatches(img1,keyPoints1,img2,keyPoints2,matches,result,cvScalarAll(-1),cvScalarAll(-1));
//	cv::imshow("matches",result);
//
//	// Saving Images
//
//	cv::imwrite("input1_features.jpg",output1);
//	cv::imwrite("input2_features.jpg",output2);
//	cv::imwrite("matches.jpg",result);
//
//	cv::waitKey();
//
//	return 0;
//
//	/*cvMatchTemplate(&ipImg1,&ipImg2,&ipResult,1);
//	cv::KDTree kd;
//	kd = cv::KDTree.build(*/
//
//	//cv::imwrite("result.jpg",&ipResult);
//	//cvSaveImage("result.jpg",&ipResult);
//
//	//cvShowImage("result",&ipResult);
//	//cv::imshow("result",ipResult);
//
//	//cv::GenericDescriptorMatcher::add(output1,keyPoints1);
//	//cv::GenericDescriptorMatch* ptrGeneric = cv::GenericDescriptorMatch::create("MyDescriptorMatch");
//	//ptrGeneric->add(output1,keyPoints1);
//
//	/*match.add(output1,keyPoints1);
//	match.add(output2,keyPoints2);*/
//}