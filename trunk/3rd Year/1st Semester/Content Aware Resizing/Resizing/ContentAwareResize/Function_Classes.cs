using System;
using System.Collections.Generic;
using System.Text;

namespace Content_Aware
{
	public static class Functions
	{
		//For Simplification of Code ... when removing a horizontal Seam
		//we get the Transpose of the Image then remove a Vertical Seam
		//then return the Transpose of the Result .. instead of Duplicating the code
		//more Steps, but less time ( Tracing Code )

		#region Horizontal_Functions
		//Get the Seam using the ( Summed Matrix ) & Direction Matrix
		public static int[] H_GetSeam(ref int[,] dir, ref int[,] Energy)//O(max(Width,Height))   v
		{
			int Height = Energy.GetLength(0), Width = Energy.GetLength(1), LastColumn = Width - 1; // O(1)
			int j = LastColumn, I;// O(1)
			int[] Seam = new int[Width];// O(1)
			Child minimum = new Child();// O(1)
			minimum.setData(int.MaxValue, -1, LastColumn);// O(1)
			for (int i = 0 ; i < Height ; i++)
			{
				if (Energy[i, LastColumn] < minimum.Energy)                  //O(Height)
					minimum.setData(Energy[i, LastColumn], i, LastColumn);
			}
			Resizing.E_LastSeam = minimum.Energy;// O(1)
			I = minimum.X;// O(1)
			while (j != -1)
			{
				Seam[j] = I;                // O(Width)
				I = dir[I, j];
				j--;
			}
			return Seam;
		}
		//Delete the Seam Using Direct Method ( in a ONE nested Loop )
		public static MyColor[,] H_Del_Direct(ref MyColor[,] Pix, int[] Seam)//O(Width *Height)
		{
			int Height = Pix.GetLength(0); // O(1)
			int Width = Pix.GetLength(1);// O(1)
			MyColor[,] tmp = new MyColor[Height - 1, Width];// O(1)
			for (int j = 0 ; j < Width ; j++)
			{
				for (int i = 0, idash = 0 ; idash < Height - 1 ; i++, idash++)
				{
					if (Seam[j] == i) // O(1)
						i++;// O(1)                                            O(Width *Height)
					tmp[idash, j] = Pix[i, j];// O(1)
				}
			}
			return tmp;
		}
		//Delete the Seam by Shifting and Cutting
		public static MyColor[,] H_Del_ShiftCut(ref MyColor[,] Pix, int[] Seam)//O(Width * Height)
		{
			int Height = Pix.GetLength(0);
			int Width = Pix.GetLength(1);
			int lastRow = Height - 1;
			MyColor[,] New = new MyColor[Height - 1, Width];//shift up
			for (int j = 0 ; j < Width ; j++)
				for (int i = Seam[j] ; i < lastRow ; i++) //O(Width * Height)
					Pix[i, j] = Pix[i + 1, j];
			//cut
			
			for (int j = 0 ; j < Width ; j++)
			{
				for (int i = 0 ; i < lastRow ; i++) //O(Width * Height)
				{
					New[i, j] = Pix[i, j];
				}
			}
			return New;
		}
		//Sets the Seam's Colour to RED
		public static MyColor[,] H_PaintSeam(ref MyColor[,] Pix, int[] Seam)//O(Wdith)
		{
			MyColor[,] PixClone = (MyColor[,])Pix.Clone();
			int Width = PixClone.GetLength(1);
			MyColor Red = new MyColor();
			Red.G = 0;
			Red.R = 0;
			Red.B = 255;
			for (int j = 0 ; j < Width ; j++)
				PixClone[Seam[j], j] = Red;			//O(Wdith)
			return PixClone;
		}
		#endregion

		#region Vertical_Functions
		//Get the Seam using the ( Summed Matrix ) & Direction Matrix
		public static int[] V_GetSeam(ref int[,] dir, ref int[,] Energy)//O(max(Width,Height))
		{
			Child minimum;// O(1)
			int Height = Energy.GetLength(0);// O(1)
			int Width = Energy.GetLength(1);// O(1)
			int i = Height - 1, j;// O(1)
			int[] Seam = new int[Height];// O(1)

			minimum.Energy = int.MaxValue;// O(1)
			minimum.Y = -1;// O(1)

			for (j = 0 ; j < Width ; j++)
			{
				if (Energy[Height - 1, j] < minimum.Energy)
				{
					minimum.Energy = Energy[Height - 1, j];// O(1)           O(Width)
					minimum.Y = j;// O(1)
				}
			}

			Resizing.E_LastSeam = minimum.Energy;  // O(1)
			j = minimum.Y;// O(1)
			while (i != -1)
			{
				Seam[i] = j;
				j = dir[i, j];                    // O(Height)
				i--;
			}
			return Seam;
		}
		//Delete the Seam Using Direct Method ( in a ONE nested Loop )
		public static MyColor[,] V_Del_Direct(ref MyColor[,] Pix, int[] Seam)//O(Width * Height)
		{
			int Height = Pix.GetLength(0);// O(1)
			int Width = Pix.GetLength(1);// O(1)
			MyColor[,] tmp = new MyColor[Height, Width - 1];// O(1)
			for (int i = 0 ; i < Height ; i++)
			{
				for (int j = 0, jdash = 0 ; jdash < Width - 1 ; j++, jdash++)
				{
					if (Seam[i] == j)// O(1)
						j++;                                                //O(Height*width)
					tmp[i, jdash] = Pix[i, j];// O(1)
				}
			}
			return tmp;
		}
		//Delete the Seam by Shifting and Cutting
		public static MyColor[,] V_Del_ShiftCut(ref MyColor[,] Pix, int[] Seam)//O(Width * Height)
		{
			MyColor[,] PixClone = (MyColor[,])Pix.Clone();
			int Height = PixClone.GetLength(0);
			int Width = PixClone.GetLength(1);
			int lastColumn = Width - 1;
			//shift
			for (int i = 0 ; i < Height ; i++)
				for (int j = Seam[i] ; j < lastColumn ; j++)
					PixClone[i, j] = PixClone[i, j + 1];			//O(Width * Height)
			//cut
			MyColor[,] New = new MyColor[Height, lastColumn];
			for (int i = 0 ; i < Height ; i++)
				for (int j = 0 ; j < lastColumn ; j++)
					New[i, j] = PixClone[i, j];				//O(Width * Height)
			return New;
		}
		//Sets the Seam's Colour to RED
		public static MyColor[,] V_PaintSeam(ref MyColor[,] Pix, int[] Seam)//O(Height)
		{
			MyColor[,] PixClone = (MyColor[,])Pix.Clone();
			int Height = PixClone.GetLength(0);
			MyColor Red = new MyColor();
			Red.G = 0;
			Red.R = 0;
			Red.B = 255;
			for (int i = 0 ; i < Height ; i++)			//O(Height)
				PixClone[i, Seam[i]] = Red;
			return PixClone;
		}
		#endregion
	}

	#region Classes
	//Holds a Position ( X & Y ) And Energy ( E )
	public struct Child
	{
		internal int X, Y;
		internal Int64 Energy;
		internal void setLocation(int i, int j)
		{
			X = i;
			Y = j;
		}
		internal void setData(Int64 e, int i, int j)
		{
			Energy = e;
			X = i;
			Y = j;
		}
	}
	//Holds a 2D Array of MyColor (MyColor[,] Pix) And Energy ( E )
	public class Picture
	{
		public Int64 E;
		public MyColor[,] Pix;
		public void set(MyColor[,] P, Int64 E)
		{
			this.E = E;
			this.Pix = P;
		}
	}
	//Holds a Picture ( picture ) And String ( Time Taken )
	public class SavePicture
	{
		public Picture picture = new Picture();
		public String TimeTaken;

	}
	#endregion
}