using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Content_Aware
{
	public partial class MainForm : Form
	{

		#region Variables
		public static MyColor[,] Original_Image,Normal;//Save NormalResized Image && Save Original
		public static int[,] Energy_Image;//Save Energy Matrix
		//Save the Different Choices for Content Aware Resizing, to avoid Recalculations in the same dimensions
		public static SavePicture Content_Direct_Backward, Content_Direct_Forward,
			Content_Greedy_Backward, Content_Greedy_Forward,
			Content_DP_Backward, Content_DP_Forward;
		public static int OriginalWidth, OriginalHeight, NewWidth, NewHeight;
		public static String TimeTaken;//Time Elapsed to Change the Picture, Global Variable Accessed by Resizing Functions
		public static Int64 MinEnergy;//Energy Removed form the Picture, Global Variable Accessed by Resizing Functions

		private static bool IsMouseDown;

		public static ProgressBar Bar;//to access ProgressBar from MainCode
		public static PictureBox Box;//to access Main PictureBox from MainCode

		public static CheckBox Animate, DrawSeams;
		#endregion

		//The Project run in O(n^4)
		//              O((Width-1*Height-1)*(Width * Height))
		//              O(Width^2 * Height^2) ===> O(n^2 * m^2)
		//
		//The Constructor for MainForm
		public MainForm()//O(Width * Height)
		{
			InitializeComponent();
			Original_Image = ImageOperations.OpenImage("Resources\\Arch.bmp");//O(Width * Height)

			Content_Direct_Backward = Content_Direct_Forward =
				Content_DP_Backward = Content_DP_Forward =
					Content_Greedy_Backward = Content_Greedy_Forward = null;

			Energy_Image = ImageOperations.CalculateEnergy(Original_Image);//O(Width * Height)
			Normal = Original_Image;
			OriginalHeight = Original_Image.GetLength(0);
			OriginalWidth = Original_Image.GetLength(1);
			txtNewHeight.Text = OriginalHeight.ToString();
			txtNewWidth.Text = OriginalWidth.ToString();
			lblOriginalWidth.Text = "Original Width = " + OriginalWidth.ToString();
			lblOriginalHeight.Text = "Original Height = " + OriginalHeight.ToString();
			lblClock.Text = lblMinEnergy.Text = lblC.Text = lblM.Text = "";
			ImageOperations.DisplayImage(Original_Image, MainPictureBox);//O(Width * Height)

			pbProgress.Visible = false;
			Box = MainPictureBox;
			Bar = pbProgress;

			Animate = cbAnimate;
			DrawSeams = cbColour;

		}

		//Restart the Application
		private void newToolStripMenuItem_Click(object sender, EventArgs e)//O(Width * Height) ... Same as Constructor
		{
			Application.Restart();
		}

		//Save Picture
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)//O(1)
		{
			SaveFileDialog SaveFileDialog = new SaveFileDialog();
			SaveFileDialog.FileName = "Image1";
			SaveFileDialog.DefaultExt = ".JPG";
			SaveFileDialog.Filter = "Image (.JPG)|*.JPG";

			if (SaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string filename = SaveFileDialog.FileName;
				MainPictureBox.Image.Save(filename);
			}
		}

		//Exit Application
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)//O(1)
		{
			Application.Exit();
		}

		//Clear Picture
		private void clearToolStripMenuItem_Click(object sender, EventArgs e)//O(1)
		{
			MainPictureBox.Image = null;
			pbProgress.Visible = false;
			lblClock.Text = lblMinEnergy.Text = lblC.Text = lblM.Text = "";
		}

		//Open button to Choose Picture
		private void btnOpen_Click(object sender, EventArgs e)//O(Width * Height)
		{
			OpenFileDialog OpenFD = new OpenFileDialog();
			if (OpenFD.ShowDialog() == DialogResult.OK)
			{
				Original_Image = ImageOperations.OpenImage(OpenFD.FileName);//O(Width * Height)
				Energy_Image = ImageOperations.CalculateEnergy(Original_Image);//O(Width * Height)
				Normal = Original_Image;
				Content_Direct_Backward = Content_Direct_Forward =
					Content_DP_Backward = Content_DP_Forward =
						Content_Greedy_Backward = Content_Greedy_Forward = null;

				NewWidth = OriginalWidth = Original_Image.GetLength(1);
				NewHeight = OriginalHeight = Original_Image.GetLength(0);
				txtNewHeight.Text = OriginalHeight.ToString();
				lblOriginalHeight.Text = "Original Height : " + OriginalHeight.ToString();
				txtNewWidth.Text = OriginalWidth.ToString();
				lblOriginalWidth.Text = "Original Width : " + OriginalWidth.ToString();
				lblClock.Text = lblMinEnergy.Text = lblC.Text = lblM.Text = "";
				ImageOperations.DisplayImage(Original_Image, MainPictureBox);//O(Width * Height)
				pbProgress.Visible = false;
			}
		}

		//Show Energy Matrix
		private void btnEnergyImage_Click(object sender, EventArgs e)//O(Width * Height)
		{
			pbProgress.Visible = false;
			lblClock.Text = lblMinEnergy.Text = lblC.Text = lblM.Text = "";
			ImageOperations.DisplayEnergy(Energy_Image, MainPictureBox);//O(Width * Height)
		}

		//Show Normal Resizing
		private void btnNormalResizing_Click(object sender, EventArgs e)//O(Width * Height)
		{
			pbProgress.Visible = false;
			if (txtNewWidth.Text == null || txtNewHeight.Text == null)
			{
				return;
			} else
			{
				lblClock.Text = lblMinEnergy.Text = lblC.Text = lblM.Text = "";
				NewWidth = int.Parse(txtNewWidth.Text);
				NewHeight = int.Parse(txtNewHeight.Text);
				if (NewWidth != Normal.GetLength(1) || NewHeight != Normal.GetLength(0))
					Normal = ImageOperations.NormalResize(Original_Image, NewWidth, NewHeight);//O(Width * Height)
				ImageOperations.DisplayImage(Normal, MainPictureBox);//O(Width * Height)
			}
		}

		//Show Content Aware Resizing ( According to the Specifications you Choosed )
		private void btnContentAwareBackward_Click(object sender, EventArgs e)//O(Width^2 * Height^2)
		{
			lblClock.Text = lblMinEnergy.Text = lblC.Text = lblM.Text = "";
			Resizing.Forward = false;
			pbProgress.Visible = true;
			Thread Content = new Thread(ContentThread);
			Content.Start();//O(Width^2 * Height^2)
		}

		private void btnContentAwareForward_Click(object sender, EventArgs e)
		{
			lblClock.Text = lblMinEnergy.Text = lblC.Text = lblM.Text = "";
			Resizing.Forward = true;
			pbProgress.Visible = true;
			Thread Content = new Thread(ContentThread);
			Content.Start();//O(Width^2 * Height^2)
		}

		private void ContentThread()//O(Width^2 * Height^2)
		{
			if (txtNewWidth.Text == null || txtNewHeight.Text == null || int.Parse(txtNewWidth.Text) > OriginalWidth || int.Parse(txtNewHeight.Text) > OriginalHeight)
			{
				return;
			} else
			{
				MinEnergy = 0;
				if (rbDP.Checked)
				{
					if (Resizing.Forward)
					{
						if (Content_DP_Forward == null)
						{
							Content_DP_Forward = new SavePicture();
							Content_DP_Forward.picture.Pix = Resizing.Resize_DP(ref Original_Image, NewWidth, NewHeight);//O(Width^2*Height^2)
							Content_DP_Forward.picture.E = MinEnergy;
							Content_DP_Forward.TimeTaken = TimeTaken;
						} else
						{
							pbProgress.Value = pbProgress.Maximum;
							TimeTaken = Content_DP_Forward.TimeTaken;
							MinEnergy = Content_DP_Forward.picture.E;
						}
						ImageOperations.DisplayImage(Content_DP_Forward.picture.Pix, MainPictureBox);//O(Width * Height)
					} else
					{
						if (Content_DP_Backward == null)
						{
							Content_DP_Backward = new SavePicture();
							Content_DP_Backward.picture.Pix = Resizing.Resize_DP(ref Original_Image, NewWidth, NewHeight);//O(Width^2*Height^2)
							Content_DP_Backward.picture.E = MinEnergy;
							Content_DP_Backward.TimeTaken = TimeTaken;
						} else
						{
							pbProgress.Value = pbProgress.Maximum;
							TimeTaken = Content_DP_Backward.TimeTaken;
							MinEnergy = Content_DP_Backward.picture.E;
						}
						ImageOperations.DisplayImage(Content_DP_Backward.picture.Pix, MainPictureBox);//O(Width * Height)
					}
				} else if (rbGreedy.Checked)
				{
					if (Resizing.Forward)
					{
						if (Content_Greedy_Forward == null)
						{
							Content_Greedy_Forward = new SavePicture();
							Content_Greedy_Forward.picture.Pix = Resizing.Resize_Greedy(ref Original_Image, NewWidth, NewHeight);//O(Columns + Rows)*(Width * Height)
							Content_Greedy_Forward.picture.E = MinEnergy;
							Content_Greedy_Forward.TimeTaken = TimeTaken;
						} else
						{
							pbProgress.Value = pbProgress.Maximum;
							TimeTaken = Content_Greedy_Forward.TimeTaken;
							MinEnergy = Content_Greedy_Forward.picture.E;
						}
						ImageOperations.DisplayImage(Content_Greedy_Forward.picture.Pix, MainPictureBox);//O(Width * Height)
					} else
					{
						if (Content_Greedy_Backward == null)
						{
							Content_Greedy_Backward = new SavePicture();
							Content_Greedy_Backward.picture.Pix = Resizing.Resize_Greedy(ref Original_Image, NewWidth, NewHeight);//O(Columns + Rows)*(Width * Height)
							Content_Greedy_Backward.picture.E = MinEnergy;
							Content_Greedy_Backward.TimeTaken = TimeTaken;
						} else
						{
							pbProgress.Value = pbProgress.Maximum;
							MinEnergy = Content_Greedy_Backward.picture.E;
							TimeTaken = Content_Greedy_Backward.TimeTaken;
						}
						ImageOperations.DisplayImage(Content_Greedy_Backward.picture.Pix, MainPictureBox);//O(Width * Height)
					}
				} else if (rbDirect.Checked)
				{
					if (Resizing.Forward)
					{
						if (Content_Direct_Forward == null)
						{
							Content_Direct_Forward = new SavePicture();
							Content_Direct_Forward.picture.Pix = Resizing.Resize_Direct(ref Original_Image, NewWidth, NewHeight);//max(Rows , Columns)*(Width * Height)
							Content_Direct_Forward.picture.E = MinEnergy;
							Content_Direct_Forward.TimeTaken = TimeTaken;
						} else
						{
							pbProgress.Value = pbProgress.Maximum;
							MinEnergy = Content_Direct_Forward.picture.E;
							TimeTaken = Content_Direct_Forward.TimeTaken;
						}
						ImageOperations.DisplayImage(Content_Direct_Forward.picture.Pix, MainPictureBox);//O(Width * Height)
					} else
					{
						if (Content_Direct_Backward == null)
						{
							Content_Direct_Backward = new SavePicture();
							Content_Direct_Backward.picture.Pix = Resizing.Resize_Direct(ref Original_Image, NewWidth, NewHeight);//max(Rows , Columns)*(Width * Height)
							Content_Direct_Backward.picture.E = MinEnergy;
							Content_Direct_Backward.TimeTaken = TimeTaken;
						} else
						{
							pbProgress.Value = pbProgress.Maximum;
							MinEnergy = Content_Direct_Backward.picture.E;
							TimeTaken = Content_Direct_Backward.TimeTaken;
						}
						ImageOperations.DisplayImage(Content_Direct_Backward.picture.Pix, MainPictureBox);//O(Width * Height)
					}
				}
				if (TimeTaken != null && MinEnergy != 0)
				{
					lblC.Text = "Time Taken";
					lblClock.Text = TimeTaken.ToString();
					lblM.Text = "Total Energy";
					lblMinEnergy.Text = MinEnergy.ToString();
				}
			}
		}

		//Show Original Image
		private void btnOriginalImage_Click(object sender, EventArgs e)//O(Width * Height)
		{
			pbProgress.Visible = false;
			lblClock.Text = lblMinEnergy.Text = lblC.Text = lblM.Text = "";
			ImageOperations.DisplayImage(Original_Image, MainPictureBox);//O(Width * Height)
		}

		//Save New Height, and set all Images to null
		private void txtNewHeight_TextChanged(object sender, EventArgs e)//O(1)
		{
			if (txtNewHeight.Text == "")
				NewHeight = 0;
			else
				NewHeight = int.Parse(txtNewHeight.Text);
			Content_Direct_Backward = Content_Direct_Forward =
				Content_DP_Backward = Content_DP_Forward =
					Content_Greedy_Backward = Content_Greedy_Forward = null;
		}

		//Save New Width, and set all Images to null
		private void txtNewWidth_TextChanged(object sender, EventArgs e)//O(1)
		{
			if (txtNewWidth.Text == "")
				NewWidth = 0;
			else
				NewWidth = int.Parse(txtNewWidth.Text);
			Content_Direct_Backward = Content_Direct_Forward =
				Content_DP_Backward = Content_DP_Forward =
					Content_Greedy_Backward = Content_Greedy_Forward = null;
		}

		private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			IsMouseDown = true;
		}

		private void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			IsMouseDown = false;
		}

		private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (!IsMouseDown)
				return;
		}

		private void cbAnimate_CheckedChanged(object sender, EventArgs e)
		{
			if (cbAnimate.Checked == true)
			{
				cbColour.Enabled = true;
			} else
			{
				cbColour.Enabled = false;
			}
		}
	}
}
