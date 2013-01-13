#include <iostream>
#include <math.h>
#include <stdlib.h>
#include <fstream>
#include <omp.h>

#using <mscorlib.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace std;

int main(int argc,char ** argv)
{
	// The Bitmap that carries the picture
	System::Drawing::Bitmap BM("C:\\Bitmix.bmp");

	// The Bitmap that holds the resultant picture
	System::Drawing::Bitmap newBM(BM.Width,BM.Height);

	// Dimensions
	int imgWidth = BM.Width, imgHeight = BM.Height, imagePixelsCount = imgWidth * imgHeight;

	// The Image with it's all pixels(R,B,G)
	int *image_R = new int[imagePixelsCount];
	int *image_G = new int[imagePixelsCount];
	int *image_B = new int[imagePixelsCount];

	int *newImage = new int[imagePixelsCount];

	// Iterators, tmpIndex
	int i,j, index, sum;

	// Get Temp Color
	System::Drawing::Color c;

	// Set Number of Threads
	omp_set_num_threads(4);

	// Set Pixels (R,G,B) into the buffer
	for(i=0;i<imgHeight;i++)
	{
		for(j=0;j<imgWidth;j++)
		{
			c = BM.GetPixel(j,i);

			image_R[index] = c.R;
			image_G[index] = c.G;
			image_B[index] = c.B;
		}
	}

	// Calculate the gray Scale
#pragma omp parallel shared(image_R,image_G,image_B, newImage, imgWidth, imgHeight) private(i, index, sum)
	{
#pragma omp for
		for(i = 0 ; i < imgHeight ; i ++)
		{
			for(int j = 0 ; j < imgWidth ; j ++)
			{
				// Get Index
				index = i + imgWidth + j;

				sum = image_R[index];

				sum += image_G[index];

				sum += image_B[index];

				sum /= 3;

				sum = (sum > 255) ? 255 : ((sum < 0)? 0 : sum);

				// Calc the Gray Scale
				newImage[index] = sum;
			}
		}
	}

	// Convert Result to BM
	for(i = 0 ; i < imgHeight ; i ++)
	{
		for(j = 0; j < imgWidth ; j ++)
		{
			index  = i * imgWidth + j;

			newBM.SetPixel(j,i,System::Drawing::Color::FromArgb(newImage[index],newImage[index],newImage[index]));
		}
	}

	// Save the Result
	newBM.Save("D:\\newImage1.jpg");
	return 0;
}