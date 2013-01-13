#include <opencv/cv.h>
#include <opencv/highgui.h>

//int main(int argc, const char* argv[])
//{
//    const cv::Mat input = cv::imread("input.jpg", 0); //Load as grayscale
//
//    cv::SiftFeatureDetector detector;
//    std::vector<cv::KeyPoint> keypoints;
//    detector.detect(input, keypoints);
//
//    // Add results to image and save.
//    cv::Mat output;
//    cv::drawKeypoints(input, keypoints, output);
//    cv::imwrite("sift_result.jpg", output);
//
//    return 0;
//}

//int main(int argc, char* argv[])
//{
//        IplImage *img = cvLoadImage("input.jpg",0);
//        //cvNamedWindow("Image:",1);
//        cvShowImage("image:",img);
//
//        cvWaitKey();
//
//        cvDestroyWindow("Image:");
//        cvReleaseImage(&img);
//
//        return 0;
//}