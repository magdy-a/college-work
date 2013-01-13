#include "mpi.h"
#include <iostream>
#include <math.h>
#include <stdlib.h>
#include<time.h>

#pragma once

#using <mscorlib.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace std;

void saveImage(int* RedImg,int* GreenImg,int *BlueImg,int Length,int Width,int ID);

int main(int argc,char ** argv)
{
	int localWidth;
	int localHeight;
	int coords[2];
	int stride=0;
	int PaddedSize, PaddedXSize,PaddedYSize;

	int OriginalImageWidth, OriginalImageHeight;

	System::Drawing::Bitmap BM("C:\\Bitmix.bmp");

	OriginalImageWidth = BM.Width;
	OriginalImageHeight = BM.Height;

	int *Red =   new int  [BM.Height * BM.Width];
	int *Green = new int  [BM.Height * BM.Width];
	int *Blue =  new int  [BM.Height * BM.Width];

	for(int i=0;i<BM.Height;i++)
	{
		for(int j=0;j<BM.Width;j++)
		{
			System::Drawing::Color c= BM.GetPixel(j,i);

			Red[i * BM.Width + j] = c.R;
			Blue[i * BM.Width + j] = c.B;
			Green[i * BM.Width + j] = c.G;
		}
	}

	int *Result =   new int  [BM.Height * BM.Width];

	int r1;int g1;int b1;
	int i;
	int avg=0;

	clock_t start=clock();

		for(i=0;i<OriginalImageHeight;i++)
		{
			for(int j=0;j<OriginalImageWidth;j++)
			{
				r1=Red [i * OriginalImageWidth + j];
				g1=Green [i * OriginalImageWidth + j];
				b1=Blue [i * OriginalImageWidth + j];
				avg=(r1+g1+b1)/3;
				Result[i * OriginalImageWidth + j]=avg;
			}
		}

	printf("Time elapsed:%f\n",((double)clock()-start)/CLOCKS_PER_SEC);

	System::Drawing::Bitmap MyNewImage(BM.Width,BM.Height);

	int R,G,B;
	for(int i=0;i<MyNewImage.Height;i++)
	{
		for(int j=0;j<MyNewImage.Width;j++)
		{
			R=Result  [i * OriginalImageWidth + j];
			G=Result[i * OriginalImageWidth + j];
			B=Result[i * OriginalImageWidth + j];

			System::Drawing::Color c=System::Drawing::Color::FromArgb(R,G,B);

			MyNewImage.SetPixel(j,i,System::Drawing::Color::FromArgb(R,G,B));
		}
	}

	MyNewImage.Save("D:\\ResultImageparallel.jpg");

	return 0;
}