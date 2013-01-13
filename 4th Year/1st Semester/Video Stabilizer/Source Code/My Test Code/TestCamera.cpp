#include "cv.h"
#include "highgui.h"

using namespace cv;

int main(int, char**)
{
    VideoCapture cap(0);
    if(!cap.isOpened()) return -1;

    Mat frame, edges;
	namedWindow("input",1);
	namedWindow("inputcvt",1);
    namedWindow("edges",1);
    for(;;)
    {
        cap >> frame;
		imshow("input",frame);
        cvtColor(frame, edges, CV_BGR2GRAY);
		imshow("inputcvt",edges);
        GaussianBlur(edges, edges, Size(7,7), 1.5, 1.5);
        Canny(edges, edges, 0, 30, 3);
        imshow("edges", edges);
        if(waitKey(30) >= 0) break;
    }
    return 0;
}