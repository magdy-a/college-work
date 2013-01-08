using System;
using System.Collections.Generic;
using System.Text;
using Content_Aware;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Content_Aware
{
	class Resizing
	{

		//Save the Energy of the Seam I Removed Last ( Vertical & Horizontal )
		public static Int64 E_LastSeam;

		//Forward Or Backward Energy Function, Used by RemoveVerticalSeam && RemoveHorizontal Seam

		public static bool Forward;

		#region Vertical

		//Solving Top_Down DP ----> To get the Seam starting form Buttom

		//Chooses between Forward and Backward Energy
		internal static int[] GetVerticalSeam(ref MyColor[,] Pix)//O(Width * Height)
		{
			if (Forward)
			{
				return GetForwardVerticalSeam(ref Pix);//O(Width * Height)
			} else
			{
				return GetBackwardVerticalSeam(ref Pix);//O(Width * Height)
			}
		}
		//Remove a Vertical Seam Using Backward Energy function
		internal static int[] GetBackwardVerticalSeam(ref MyColor[,] Pix)//O(Width * Height)
		{
			int Width = Pix.GetLength(1), Height = Pix.GetLength(0),
				lastRow = Height - 1,
				lastColumn = Width - 1;
			int[,] Energy = ImageOperations.CalculateEnergy(Pix),//O(Width * Height)
				   dir = new int[Height, Width];

			Child left = new Child(), down = new Child(), right = new Child(), minimum = new Child();

			if (Width == 0 || Height == 0)
			{
				int[] Seam = null;
				return Seam;
			}


			for (int i = 1 ; i < Height ; i++)		//O(Width * Height)
			{
				for (int j = 0 ; j < Width ; j++)
				{
					down.setData(Energy[i - 1, j], i - 1, j);

					if (j == 0)
					{
						left.setData(int.MaxValue, -1, -1);
						right.setData(Energy[i - 1, j + 1], i - 1, j + 1);
					} else if (j == lastColumn)
					{
						left.setData(Energy[i - 1, j - 1], i - 1, j - 1);
						right.setData(int.MaxValue, -1, -1);
					} else
					{
						left.setData(Energy[i - 1, j - 1], i - 1, j - 1);
						right.setData(Energy[i - 1, j + 1], i - 1, j + 1);
					}

					minimum.setData(right.Energy, right.X, right.Y);

					if (left.Energy < down.Energy)
					{
						if (left.Energy < right.Energy)
							minimum.setData(left.Energy, left.X, left.Y);
					} else// if (Down.min <= Left.min)
					{
						if (down.Energy < right.Energy)
							minimum.setData(down.Energy, down.X, down.Y);
					}

					Energy[i, j] += (int)minimum.Energy; // shall i cast it to int ... woried about losing data
					dir[i, j] = minimum.Y;
				}
			}
			return Functions.V_GetSeam(ref dir, ref Energy);//O(Height)
			//seam = Functions.V_GetSeam(ref dir, ref Energy);//O(Height)

			//return Functions.V_Del_Direct(ref Pix, seam);//O(Width * Height)
		}
		
		internal static int[] GetForwardVerticalSeam(ref MyColor[,] Pix)//O(Width * Height)
		{
		    int Height = Pix.GetLength(0), Width = Pix.GetLength(1);
		    int[,] M = new int[Height, Width];
		    int[,] dir = new int[Height, Width];
		    int[] Seam = new int[Height];
		    Child CL = new Child(), CU = new Child(), CR = new Child(), minimum = new Child();
		    MyColor Left,Up,Right;

		    for (int i = 0 ; i < Height ; i++)			//O(Width * Height)
		    {
		        for (int j = 0 ; j < Width ; j++)
		        {
		            if (i == 0)
		            {
		                //=========================Consider_it_Up============================================
		                if (j == 0){//if first column, put the right pixel into me
		                    Right = Pix[i,j+1];
		                    M[i, j] = Right.R + Right.G + Right.B;
		                }
		                else if (j == Width - 1){//if last column, put the left pixel into me
		                    Left = Pix[i, j - 1];
		                    M[i, j] = Left.R + Left.G + Left.B;
		                }
		                else//not first no last ... |Right - Left|
		                {
		                    Left = Pix[i, j - 1];
		                    Right = Pix[i, j + 1];
		                    M[i, j] = Math.Abs(Right.R - Left.R) + Math.Abs(Right.G - Left.G) + Math.Abs(Right.B - Left.B);
		                }
		                continue;
		            }
		            if (j == 0)
		            {
		                //No Left
		                Up = Pix[i - 1, j];
		                Right = Pix[i, j + 1];
		                //			|Right - Left| == Right ---------- Initialize all by Right
		                CU.Energy = CR.Energy = Right.R + Right.G + Right.B;
		                //=========================Left================================================
		                CL.setData(int.MaxValue, -1, -1);
		                //=========================Up================================================
		                //			Dimensions
		                CU.setLocation(i - 1, j);
		                //			M[i-1,j]
		                CU.Energy += M[CU.X, CU.Y];
		                //=========================Right================================================
		                //			|Up - Right|
		                CR.Energy += Math.Abs(Up.R - Right.R) + Math.Abs(Up.G - Right.G) + Math.Abs(Up.B - Right.B);
		                //			Dimensions
		                CR.setLocation(i - 1, j + 1);
		                //			M[i-1,j+1]
		                CR.Energy += M[CR.X, CR.Y];

		            } else if (j == Width - 1)
		            {
		                Left = Pix[i, j - 1];
		                Up = Pix[i - 1, j];
		                //No Right
		                //			|Right - Left| == Left ------------- Initialize all by Left
		                CL.Energy = CU.Energy = Left.R + Left.G + Left.B;
		                //=========================Left================================================
		                //			|Up - Left|
		                CL.Energy += Math.Abs(Up.R - Left.R) + Math.Abs(Up.G - Left.G) + Math.Abs(Up.B - Left.B);
		                //			Dimensions
		                CL.setLocation(i - 1, j - 1);
		                //			M[i-1,j-1]
		                CL.Energy += M[CL.X, CL.Y];
		                //=========================Up================================================
		                //			Dimensions
		                CU.setLocation(i - 1, j);
		                //			M[i-1,j]
		                CU.Energy += M[CU.X, CU.Y];
		                //=========================Right================================================
		                CR.setData(int.MaxValue, -1, -1);

		            } else
		            {
		                Left = Pix[i, j - 1];
		                Up = Pix[i - 1, j];
		                Right = Pix[i, j + 1];
		                //			|Right - Left| -------  Initialize all by |Right - Left|
		                CL.Energy = CU.Energy = CR.Energy = Math.Abs(Right.R - Left.R) + Math.Abs(Right.G - Left.G) + Math.Abs(Right.B - Left.B);
		                //===================Left==================================
		                //			|Up - Left|
		                CL.Energy += Math.Abs(Up.R - Left.R) + Math.Abs(Up.G - Left.G) + Math.Abs(Up.B - Left.B);
		                //			Dimensions
		                CL.setLocation(i - 1, j - 1);
		                //			M[i-1,j-1]
		                CL.Energy += M[CL.X, CL.Y]; // M[i-1,j-1] + CL
		                //===================Up=====================================
		                //			Dimensions
		                CU.setLocation(i - 1, j);
		                //			M[i-1,j]
		                CU.Energy += M[CU.X, CU.Y]; // M[i-1,j] + CU
		                //===================Right==================================
		                //			|Up - Right|
		                CR.Energy += Math.Abs(Up.R - Right.R) + Math.Abs(Up.G - Right.G) + Math.Abs(Up.B - Right.B);
		                //			Dimensions
		                CR.setLocation(i - 1, j + 1);
		                //			M[i-1,j+1]
		                CR.Energy += M[CR.X, CR.Y];
		            }
		            //initialize minimum with Right
		            minimum.setData(CR.Energy,CR.X,CR.Y);

		            if (CL.Energy < CU.Energy)
		            {
		                if (CL.Energy < CR.Energy)
		                    minimum.setData(CL.Energy, CL.X, CL.Y);
		            } else// if(CU <= CL.Energy)
		            {
		                if (CU.Energy < CR.Energy)
		                    minimum.setData(CU.Energy, CU.X, CU.Y);
		            }

		            M[i, j] = (int)minimum.Energy;
		            dir[i, j] = minimum.Y;
		        }
		    }

		    return Functions.V_GetSeam(ref dir, ref M);//O(Height)
		    //Seam = Functions.V_GetSeam(ref dir, ref M);//O(Height)

		    //return Functions.V_Del_Direct(ref Pix, Seam);//O(Width * Height)
		}
		#endregion

		#region Horizontal

		//Solving Left_Right to get the Seam starting form Right

		//Chooses between Forward and Backward Energy
		internal static int[] GetHorizontalSeam(ref MyColor[,] Pix)//O(Width * Height)
		{
			if (Forward)
			{
				return GetForwardHorizontalSeam(ref Pix);//O(Width * Height)
			} else
			{
				return GetBackwardHorizontalSeam(ref Pix);//O(Width * Height)
			}
		}

		//Remove Horizontal Seam using Backward Energy function
		internal static int[] GetBackwardHorizontalSeam(ref MyColor[,] Pix)//O(Width * Height)
		{
			int Width = Pix.GetLength(1), Height = Pix.GetLength(0),
				lastRow = Height - 1,
				lastColumn = Width - 1;
			int[,] Energy = ImageOperations.CalculateEnergy(Pix),//O(Width * Height)
				   dir = new int[Height, Width];

			Child left = new Child(), down = new Child(), right = new Child(), minimum = new Child();
			if (Width == 0 || Height == 0)
			{
				int[] Seam = null;
				return Seam;
			}

			for (int j = 1 ; j <= lastColumn ; j++)			//O(Width * Height)
			{
				for (int i = 0 ; i <= lastRow ; i++)
				{
					down.setData(Energy[i, j - 1], i, j - 1);
					if (i == 0)
					{
						right.setData(int.MaxValue, -1, -1);
						left.setData(Energy[i + 1, j - 1], i + 1, j - 1);
					} else if (i == lastRow)
					{
						left.setData(int.MaxValue, -1, -1);
						right.setData(Energy[i - 1, j - 1], i - 1, j - 1);
					} else
					{
						right.setData(Energy[i - 1, j - 1], i - 1, j - 1);
						left.setData(Energy[i + 1, j - 1], i + 1, j - 1);
					}

					minimum.setData(right.Energy, right.X, right.Y);

					if (left.Energy < down.Energy)
					{
						if (left.Energy < right.Energy)
							minimum.setData(left.Energy, left.X, left.Y);
					} else// if (Down.min <= Left.min)
					{
						if (down.Energy < right.Energy)
							minimum.setData(down.Energy, down.X, down.Y);
					}

					Energy[i, j] += (int)minimum.Energy; // shall i cast it to int ... woried about losing data
					dir[i, j] = minimum.X;
				}
			}
			return Functions.H_GetSeam(ref dir, ref Energy);//O(Width)
			//seam = Functions.H_GetSeam(ref dir, ref Energy);//O(Width)

			//return Functions.H_Del_Direct(ref Pix, seam);//O(Width * Height)
		}

		//Remove Horizontal Seam using Forward Energy function
		internal static int[] GetForwardHorizontalSeam(ref MyColor[,] Pix)//O(Width * Height)
		{
			int Height = Pix.GetLength(0), Width = Pix.GetLength(1),
				LastRow = Height - 1;
			int[,] M = new int[Height, Width],
				   dir = new int[Height, Width];
			Child CL = new Child(), CU = new Child(), CR = new Child(), minimum = new Child();
			MyColor Left, Up, Right;
			for (int j = 0 ; j < Width ; j++)						//O(Width * Height)
			{
				for (int i = 0 ; i < Height ; i++)
				{
					if (j == 0)//no childs ... consider all as CU
					{
						//==================Consider_All_Up========================
						if (i == 0)
						{
							Left = Pix[i + 1, j];
							M[i, j] = Left.R + Left.G + Left.B;
						} else if (i == LastRow)
						{
							//no Left
							Right = Pix[i - 1, j];
							M[i, j] = Right.R + Right.G + Right.B;
						} else
						{
							Left = Pix[i + 1, j];
							Right = Pix[i - 1, j];
							M[i, j] = Math.Abs(Right.R - Left.R) + Math.Abs(Right.G - Left.G) + Math.Abs(Right.B - Left.B);
						}
						continue;
					}
					if (i == 0)//no right
					{
						Left = Pix[i + 1, j];
						Up = Pix[i, j - 1];
						//no right
						//			|Right - Left| == Left ----------- Initialize all by Left
						CL.Energy = CU.Energy = Left.R + Left.G + Left.B;
						//========================Left================================
						//			|Up - Left|
						CL.Energy += Math.Abs(Up.R - Left.R) + Math.Abs(Up.G - Left.G) + Math.Abs(Up.B - Left.B);
						//			Dimensions
						CL.setLocation(i + 1, j - 1);
						//			M[i+1,j-1]
						CL.Energy += M[CL.X, CL.Y];
						//========================Up================================
						//			Dimensions
						CU.setLocation(i, j - 1);
						//			M[i,j-1]
						CU.Energy += M[CU.X, CU.Y];
						//========================Right================================
						CR.setData(int.MaxValue, -1, -1);

					} else if (i == LastRow)//no left
					{
						//no left
						Up = Pix[i, j - 1];
						Right = Pix[i - 1, j];
						//			|Right - Left| == Right ------------- Initialize all by Right
						CU.Energy = CR.Energy = Right.R + Right.G + Right.B;
						//========================Left================================
						CL.setData(int.MaxValue, -1, -1);
						//========================Up================================
						//			Dimensions
						CU.setLocation(i, j - 1);
						//			M[i,j-1]
						CU.Energy += M[CU.X, CU.Y];
						//========================Right================================
						//			|Up - Right|
						CR.Energy += Math.Abs(Up.R - Right.R) + Math.Abs(Up.G - Right.G) + Math.Abs(Up.B - Right.B);
						//			Dimensions
						CR.setLocation(i - 1, j - 1);
						//			M[i-1,j-1]
						CR.Energy += M[CR.X, CR.Y];

					} else//all exists
					{
						Left = Pix[i + 1, j];
						Up = Pix[i, j - 1];
						Right = Pix[i, j - 1];
						//			|Right - Left| -------------- Initialize all by |Right - Left|
						CL.Energy = CU.Energy = CR.Energy = Math.Abs(Right.R - Left.R) + Math.Abs(Right.G - Left.G) + Math.Abs(Right.B - Left.B);
						//=============================Left=================================
						//			|Up - Left|
						CL.Energy += Math.Abs(Up.R - Left.R) + Math.Abs(Up.G - Left.G) + Math.Abs(Up.B - Left.B);
						//			Dimensions
						CL.setLocation(i + 1, j - 1);
						//			M[i+1,j-1]
						CL.Energy += M[CL.X, CL.Y];
						//=============================Up===================================
						//			Dimensions
						CU.setLocation(i, j - 1);
						//			M[i,j-1]
						CU.Energy += M[CU.X, CU.Y];
						//=============================Right=================================
						//			|Up - Right|
						CR.Energy += Math.Abs(Up.R - Right.R) + Math.Abs(Up.G - Right.G) + Math.Abs(Up.B - Right.B);
						//			Dimensions
						CR.setLocation(i - 1, j - 1);
						//			M[i-1,j-1]
						CR.Energy += M[CR.X, CR.Y];
					}
					//Initialize minimum by Right
					minimum.setData(CR.Energy, CR.X, CR.Y);
					if (CL.Energy < CU.Energy)
					{
						if (CL.Energy < CR.Energy)
							minimum.setData(CL.Energy, CL.X, CL.Y);
					} else
					{// if(Cu.Energy <= CL.Energy)
						if (CU.Energy < CR.Energy)
							minimum.setData(CU.Energy, CU.X, CU.Y);
					}
					M[i, j] = (int)minimum.Energy;
					dir[i, j] = minimum.X;
				}
			}
			return Functions.H_GetSeam(ref dir, ref M);//O(Width)
			//Seam = Functions.H_GetSeam(ref dir,ref M);//O(Width)

			//return Functions.H_Del_Direct(ref Pix, Seam);//O(Width * Height)
		}
		#endregion

		#region Resizing_Algorithms
		//Greedy Algorithm _ deleting Rows and Columns
		public static MyColor[,] Resize_Greedy(ref MyColor[,] Pix, int newWidth, int newHeight)//O(Columns + Rows) * (Width * Height)
		{
			DateTime Before = DateTime.Now;
			int OriginalHeight = Pix.GetLength(0), OriginalWidth = Pix.GetLength(1),
				Rows = OriginalHeight - newHeight, Columns = OriginalWidth - newWidth;
			MyColor[,] PixClone = (MyColor[,])Pix.Clone();//O(Width * Height)

			int[] SeamVertical = null, SeamHorizontal = null;
			int EnergyVertical, EnergyHorizontal;

			MainForm.Bar.Maximum = Rows + Columns;
			MainForm.Bar.Value = 0;

			while (Rows > 0 || Columns > 0)//O((Rows + Columns) * (Width * Height))
			{
				MainForm.Bar.Visible = true;
				MainForm.Bar.Value++;
				//find Possibilities
				if (Columns > 0)
				{
					SeamVertical = GetVerticalSeam(ref PixClone);//O(Width * Height)
					EnergyVertical = (int)E_LastSeam;
				} else
				{
					EnergyVertical = int.MaxValue;
				}

				if (Rows > 0)
				{
					SeamHorizontal = GetHorizontalSeam(ref PixClone);//O(Width * Height)
					EnergyHorizontal = (int)E_LastSeam;
				} else
				{
					EnergyHorizontal = int.MaxValue;
				}
				//find Minimum
				if (EnergyVertical < EnergyHorizontal)
				{
					if (MainForm.Animate.Checked)
					{
						if (MainForm.DrawSeams.Checked)
							ImageOperations.DisplayImage(Functions.V_PaintSeam(ref PixClone, SeamVertical), MainForm.Box);//O(Width * Height)
						else
							ImageOperations.DisplayImage(PixClone, MainForm.Box);//O(Width * Height)
					}
					PixClone = Functions.V_Del_Direct(ref PixClone, SeamVertical);//O(Width * Height)
					MainForm.MinEnergy += EnergyVertical;
					Columns--;
				} else
				{
					if (MainForm.Animate.Checked)
					{
						if (MainForm.DrawSeams.Checked)
							ImageOperations.DisplayImage(Functions.H_PaintSeam(ref PixClone, SeamHorizontal), MainForm.Box);//O(Width * Height)
						else
							ImageOperations.DisplayImage(PixClone, MainForm.Box);//O(Width * Height)
					}
					PixClone = Functions.H_Del_Direct(ref PixClone, SeamHorizontal);//O(Width * Height)
					MainForm.MinEnergy += EnergyHorizontal;
					Rows--;
				}
			}
			DateTime After = DateTime.Now;
			MainForm.TimeTaken = (After - Before).ToString();
			return PixClone;
		}

		//remove the desired rows and columns directly ( Columns then Rows ).
		public static MyColor[,] Resize_Direct(ref MyColor[,] Pix, int newWidth, int newHeight)//O(max(Width,Height) * (Width * Height))
		{
			DateTime Before = DateTime.Now;

			int OriginalHeight = Pix.GetLength(0), OriginalWidth = Pix.GetLength(1),
				Rows = OriginalHeight - newHeight, Columns = OriginalWidth - newWidth;

			MyColor[,] PixClone = (MyColor[,])Pix.Clone();

			MainForm.Bar.Maximum = Rows + Columns;
			MainForm.Bar.Value = 0;

			for (int j = 0 ; j < Columns ; j++)//O(Columns * (Width * Height))
			{
				int[] Seam = GetVerticalSeam(ref PixClone);//O(Width * Height)
				if (MainForm.Animate.Checked)
				{
					if (MainForm.DrawSeams.Checked)
						ImageOperations.DisplayImage(Functions.V_PaintSeam(ref PixClone, Seam), MainForm.Box);//O(Width * Height)
					else
						ImageOperations.DisplayImage(PixClone, MainForm.Box);//O(Width * Height)
				}
				PixClone = Functions.V_Del_Direct(ref PixClone, Seam);//O(Width * Height)
				MainForm.MinEnergy += E_LastSeam;
				MainForm.Bar.Visible = true;
				MainForm.Bar.Value++;
			}

			for (int i = 0 ; i < Rows ; i++)//O(Rows * (Width * Height))
			{
				int[] Seam = GetHorizontalSeam(ref PixClone);//O(Width * Height)
				if (MainForm.Animate.Checked)
				{
					if (MainForm.DrawSeams.Checked)
						ImageOperations.DisplayImage(Functions.H_PaintSeam(ref PixClone, Seam), MainForm.Box);//O(Width * Height)
					else
						ImageOperations.DisplayImage(PixClone, MainForm.Box);//O(Width * Height)
				}
				PixClone = Functions.H_Del_Direct(ref PixClone, Seam);//O(Width * Height)
				MainForm.MinEnergy += E_LastSeam;
				MainForm.Bar.Visible = true;
				MainForm.Bar.Value++;
			}

			DateTime After = DateTime.Now;
			MainForm.TimeTaken = (After - Before).ToString();
			return PixClone;
		}

		//takes the num of rows and columns to be deleted ( DP ) _ Very Slow _
		public static MyColor[,] Resize_DP(ref MyColor[,] Pix, int newWidth, int newHeight)//O(Width^2 * Height^2)
		{
			DateTime Before = DateTime.Now;

			int OriginalWidth = Pix.GetLength(1);
			int OriginalHeight = Pix.GetLength(0);
			int Rows = OriginalHeight - newHeight, Columns = OriginalWidth - newWidth;
			Picture[,] MatrixDP = new Picture[Rows + 1, Columns + 1];

			MainForm.Bar.Maximum = (Rows + 1) * (Columns + 1);
			MainForm.Bar.Value = 0;
			int[] SeamUp, SeamLeft;
			int EnergyUp, EnergyLeft;

			for (int i = 0 ; i <= Rows ; i++)//O(Width^2 * Height^2)
			{
				for (int j = 0 ; j <= Columns ; j++)
				{
					MainForm.Bar.Visible = true;
					MainForm.Bar.Value++;

					MatrixDP[i, j] = new Picture();

					if (i == 0 && j == 0)
					{
						MatrixDP[i, j].set(Pix, 0);
						continue;
					}
					if (i == 0)// delete a column
					{
						SeamLeft = GetVerticalSeam(ref MatrixDP[i, j - 1].Pix);//O(Width * Height)

						if (MainForm.Animate.Checked)
						{
							if (MainForm.DrawSeams.Checked)
								ImageOperations.DisplayImage(Functions.V_PaintSeam(ref MatrixDP[i, j - 1].Pix, SeamLeft), MainForm.Box);//O(Width * Height)
							else
								ImageOperations.DisplayImage(MatrixDP[i, j - 1].Pix, MainForm.Box);//O(Width * Height)
						}

						MatrixDP[i, j].set(Functions.V_Del_Direct(ref MatrixDP[i, j - 1].Pix, SeamLeft), (Int64)(MatrixDP[i, j - 1].E + E_LastSeam));//O(Width * Height)
					} else if (j == 0)// delete a row
					{
						SeamUp = GetHorizontalSeam(ref MatrixDP[i - 1, j].Pix);//O(Width * Height)
						if (MainForm.Animate.Checked)
						{
							if (MainForm.DrawSeams.Checked)
								ImageOperations.DisplayImage(Functions.H_PaintSeam(ref MatrixDP[i - 1, j].Pix, SeamUp), MainForm.Box);//O(Width * Height)
							else
								ImageOperations.DisplayImage(MatrixDP[i - 1, j].Pix, MainForm.Box);//O(Width * Height)
						}
						MatrixDP[i, j].set(Functions.H_Del_Direct(ref MatrixDP[i - 1, j].Pix, SeamUp), (Int64)(MatrixDP[i - 1, j].E + E_LastSeam));//O(Width * Height)
					} else// find the optimal from up & left
					{
						SeamLeft = GetVerticalSeam(ref MatrixDP[i, j - 1].Pix);//O(Width * Height)
						EnergyLeft = (int)(E_LastSeam + MatrixDP[i, j - 1].E);
						SeamUp = GetHorizontalSeam(ref MatrixDP[i - 1, j].Pix);//O(Width * Height)
						EnergyUp = (int)(E_LastSeam + MatrixDP[i - 1, j].E);
						if (EnergyLeft < EnergyUp)
						{
							if (MainForm.Animate.Checked)
							{
								if (MainForm.DrawSeams.Checked)
									ImageOperations.DisplayImage(Functions.V_PaintSeam(ref MatrixDP[i, j - 1].Pix, SeamLeft), MainForm.Box);//O(Width * Height)
								else
									ImageOperations.DisplayImage(MatrixDP[i, j - 1].Pix, MainForm.Box);//O(Width * Height)
							}
							MatrixDP[i, j].set(Functions.V_Del_Direct(ref MatrixDP[i, j - 1].Pix, SeamLeft), EnergyLeft);//O(Width * Height)
						} else
						{
							if (MainForm.Animate.Checked)
							{
								if (MainForm.DrawSeams.Checked)
									ImageOperations.DisplayImage(Functions.H_PaintSeam(ref MatrixDP[i - 1, j].Pix, SeamUp), MainForm.Box);//O(Width * Height)
								else
									ImageOperations.DisplayImage(MatrixDP[i - 1, j].Pix, MainForm.Box);//O(Width * Height)
							}
							MatrixDP[i, j].set(Functions.H_Del_Direct(ref MatrixDP[i - 1, j].Pix, SeamUp), EnergyUp);//O(Width * Height)
						}
					}
					//delete up
					if (i != 0)
						MatrixDP[i - 1, j] = null;
				}
			}

			MainForm.Bar.Value = MainForm.Bar.Maximum;

			DateTime After = DateTime.Now;

			MainForm.TimeTaken = (After - Before).ToString();
			MainForm.MinEnergy = MatrixDP[Rows, Columns].E;
			return MatrixDP[Rows, Columns].Pix;
		}
		#endregion
	}
}