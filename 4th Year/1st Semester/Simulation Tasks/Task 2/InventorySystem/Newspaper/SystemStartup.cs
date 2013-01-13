using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newspaper.Distributions;
using Newspaper.Simulation;

namespace Newspaper
{
    public partial class SystemStartup : Form
    {
        #region Attributes

        private const int minValue = 1, errorValue = -1;

        private Random rnd;

        private Point mouseDownLocation;
        private int currentPanel;

        private float purchasePrice, sellingPrice, scrapValue;
        private int from, to;

        private IDistribution NewsdaysDistribution;
        private List<IDistribution> DemandDistribution;

        private SimulationManager manager;
        private List<float> values, probabilities;

        private static int NUMBER_OF_PANELS = 3;

        #endregion Attributes

        #region Properties

        public SimulationManager Manager
        {
            get { return this.manager; }
        }

        #endregion Properties

        #region Form

        public SystemStartup()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            rnd = new Random();

            InitializeComponent();

            this.btnClose.BackgroundImage = Newspaper.Properties.Resources.close.GetThumbnailImage(40, 40, null, IntPtr.Zero);
        }

        private void SystemStartup_Load(object sender, EventArgs e)
        {
            // General Panel
            currentPanel = 1;

            this.btnPrevious.Enabled = false;

            GotoPnl(currentPanel);

            // Set data in Main Panel
            this.nudFrom.Value = 4;
            this.nudTo.Value = 10;
            this.nudPurchasePrice.Value = 33;
            this.nudSellingPrice.Value = 50;
            this.nudScrap.Value = 5;

            // Set News Day Type Column in Newsday Distribution
            this.dgvNewsdaysDistribution.AllowUserToAddRows = false;

            this.dgvNewsdaysDistribution.Rows.Add(Enum.GetNames(typeof(NewsdayType)).Length);

            this.dgvNewsdaysDistribution.Columns[0].ReadOnly = true;

            this.dgvNewsdaysDistribution[0, 0].Value = Newspaper.Simulation.NewsdayType.Poor.ToString();
            this.dgvNewsdaysDistribution[0, 1].Value = Newspaper.Simulation.NewsdayType.Fair.ToString();
            this.dgvNewsdaysDistribution[0, 2].Value = Newspaper.Simulation.NewsdayType.Good.ToString();

            // Set Demand Distribution Table
            this.dgvDemandDistribution.AllowUserToAddRows = false;
            this.dgvDemandDistribution.Columns[0].ReadOnly = true;
            this.nudRange_ValueChanged(null, null);

            // Test
            //OpenMyFile(@"Startup Data\Newspaper.txt");
            //BtnFinish_Click(null, null);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Close the StartUp Data Window?", "Close StartUp Data Window", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

                Close();
            }
        }

        #endregion Form

        #region Events

        private void TsMain_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = e.Location;
        }

        private void TsMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            Location = new Point(Location.X + e.X - mouseDownLocation.X, Location.Y + e.Y - mouseDownLocation.Y);
        }

        private void nudRange_ValueChanged(object sender, EventArgs e)
        {
            // Check for the availability of values
            if (((NumericUpDown)sender) == this.nudFrom)
            {
                this.nudTo.Minimum = this.nudFrom.Value;
                //this.nudTo.Value = this.nudFrom.Value;
            }

            // Set the Rows Count
            int range = (int)(this.nudTo.Value - this.nudFrom.Value + 1);
            if (this.dgvDemandDistribution.Rows.Count < range)
            {
                this.dgvDemandDistribution.Rows.Add(range - this.dgvDemandDistribution.Rows.Count);
            }
            else
            {
                for (int i = range; i < this.dgvDemandDistribution.Rows.Count; i++)
                {
                    this.dgvDemandDistribution.Rows.RemoveAt(i);
                }
            }

            // Set Demand Column Values
            for (int i = 0; i < range; i++)
            {
                this.dgvDemandDistribution[0, i].Value = (int)(this.nudFrom.Value + i) * 10;
            }
        }

        private void nudPurchasePrice_ValueChanged(object sender, EventArgs e)
        {
            this.nudSellingPrice.Minimum = this.nudPurchasePrice.Value;
        }

        private void SystemStartup_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void SystemStartup_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                this.OpenMyFile(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.BtnFinish_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Happened" + "\r\n" + ex.Message);
            }
        }

        #endregion Events

        #region pnlData

        private void GotoPnl(int pnlNumber)
        {
            this.pnlMain.Enabled = false;
            this.pnlMain.Visible = false;

            this.pnlNewdaysTypesDistribution.Enabled = false;
            this.pnlNewdaysTypesDistribution.Visible = false;

            this.pnlDemandDistribution.Enabled = false;
            this.pnlDemandDistribution.Visible = false;

            switch (pnlNumber)
            {
                case 1:
                    this.pnlMain.Enabled = true;
                    this.pnlMain.Visible = true;
                    break;
                case 2:
                    this.pnlNewdaysTypesDistribution.Enabled = true;
                    this.pnlNewdaysTypesDistribution.Visible = true;
                    break;
                case 3:
                    this.pnlDemandDistribution.Enabled = true;
                    this.pnlDemandDistribution.Visible = true;
                    break;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPanel < NUMBER_OF_PANELS)
            {
                this.GotoPnl(++currentPanel);
                this.btnPrevious.Enabled = true;
            }

            if (this.currentPanel == NUMBER_OF_PANELS)
            {
                this.btnNext.Enabled = false;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.currentPanel > 1)
            {
                this.GotoPnl(--currentPanel);
                this.btnNext.Enabled = true;
            }

            if (this.currentPanel == 1)
            {
                this.btnPrevious.Enabled = false;
            }
        }

        #endregion pnlData

        #region Open & Save Data

        private void OpenMyFile(string filePath)
        {
            try
            {
                // Create FileStream
                FileStream FS = new FileStream(filePath, FileMode.Open);

                // The Array to read the file into
                byte[] ArrFile = new byte[FS.Length];

                // The List<byte> contains File to Decode
                List<byte> file;

                // Tmp Int For Looping
                int i;

                int tmpLength;

                // Read the File
                FS.Read(ArrFile, 0, ArrFile.Length);

                // Close the File
                FS.Close();

                // Convert to List
                file = new List<byte>(ArrFile);

                // Purchase Price
                this.nudPurchasePrice.Value = readIntThenRemoveIt(file);

                // Selling Price
                this.nudSellingPrice.Value = readIntThenRemoveIt(file);

                // Scrap Value
                this.nudScrap.Value = (int)readIntThenRemoveIt(file);

                // From
                this.nudFrom.Value = readIntThenRemoveIt(file);

                // To
                this.nudTo.Value = readIntThenRemoveIt(file);

                // Force Event of From Value Changed
                this.nudRange_ValueChanged(this.nudFrom, null);

                // Newsdays Distribution
                // Length
                tmpLength = readIntThenRemoveIt(file);

                // Probabilities
                for (i = 0; i < this.dgvNewsdaysDistribution.Rows.Count; i++)
                {
                    this.dgvNewsdaysDistribution[this.Probability.Name, i].Value = (float)readDoubleThenRemoveIt(file);
                }

                // Demand Distribution
                // Length
                tmpLength = readIntThenRemoveIt(file);

                // Each Column Probability
                for (int j = 1; j < this.dgvDemandDistribution.Columns.Count; j++)
                {
                    for (i = 0; i < this.dgvDemandDistribution.Rows.Count; i++)
                    {
                        this.dgvDemandDistribution[j, i].Value = (float)readDoubleThenRemoveIt(file);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveMyFile(string filePath)
        {
            try
            {
                // The File to Write
                List<byte> file = new List<byte>();

                // Pane Iterator
                int i;

                // Purchase Price
                file.AddRange(BitConverter.GetBytes((int)this.nudPurchasePrice.Value));

                // Selling Price
                file.AddRange(BitConverter.GetBytes((int)this.nudSellingPrice.Value));

                //  Scrap Value
                file.AddRange(BitConverter.GetBytes((int)this.nudScrap.Value));

                // From
                file.AddRange(BitConverter.GetBytes((int)this.nudFrom.Value));

                // To
                file.AddRange(BitConverter.GetBytes((int)this.nudTo.Value));

                // NewsdaysDistribution
                // Length
                file.AddRange(BitConverter.GetBytes(this.dgvNewsdaysDistribution.Rows.Count));

                // Probabilities
                for (i = 0; i < this.dgvNewsdaysDistribution.Rows.Count; i++)
                {
                    file.AddRange(BitConverter.GetBytes((double)(float.Parse(this.dgvNewsdaysDistribution[this.Probability.Name, i].Value.ToString()))));
                }

                // Demand Distribution
                // Length
                file.AddRange(BitConverter.GetBytes(this.dgvDemandDistribution.Rows.Count));

                // Probabilities of Each Column
                for (int j = 1; j < this.dgvDemandDistribution.Columns.Count; j++)
                {
                    for (i = 0; i < this.dgvDemandDistribution.Rows.Count; i++)
                    {
                        file.AddRange(BitConverter.GetBytes((double)(float.Parse(this.dgvDemandDistribution[j, i].Value.ToString()))));
                    }
                }

                // Create FileStream
                FileStream FS = new FileStream(filePath, FileMode.Append);

                // Write the Stream
                FS.Write(file.ToArray(), 0, file.Count);

                // Close the File
                FS.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Save&Load_Events

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Txt Files *.txt|*.txt";
            OFD.Title = "Open Data File";
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenMyFile(OFD.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Txt Files *.txt|*.txt";
            SFD.Title = "Save File";
            if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaveMyFile(SFD.FileName);
            }
        }

        #endregion Save&Load_Events

        #region Save&Load_HelpingFunctions

        private int readIntThenRemoveIt(List<byte> L)
        {
            int tmp = BitConverter.ToInt32(L.GetRange(0, 4).ToArray(), 0);
            L.RemoveRange(0, 4);
            return tmp;
        }

        private double readDoubleThenRemoveIt(List<byte> L)
        {
            double tmp = BitConverter.ToDouble(L.GetRange(0, 8).ToArray(), 0);
            L.RemoveRange(0, 8);
            return tmp;
        }

        #endregion Save&Load_HelpingFunctions

        #endregion Open & Save Data

        #region Finalizing

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            if (TakeInformation() == false)
            {
                return;
            }

            // Create Simulation Manager
            manager = new SimulationManager(this.from, this.to, this.purchasePrice, this.sellingPrice, this.scrapValue, NewsdaysDistribution, DemandDistribution);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            Close();
        }

        private bool TakeInformation()
        {
            // pnl Main
            this.from = ((int)this.nudFrom.Value) * 10;

            this.to = ((int)this.nudTo.Value) * 10;

            this.purchasePrice = (float)((int)this.nudPurchasePrice.Value) / 100;

            this.sellingPrice = (float)((int)this.nudSellingPrice.Value) / 100;

            this.scrapValue = (float)((int)this.nudScrap.Value) / 100;

            bool AccCheck;

            // pnl Newsdays Distribution
            // Chec for ACC
            AccCheck = CheckForColumnAcc(this.dgvNewsdaysDistribution, this.Probability.Index);
            if (AccCheck == false)
            {
                MessageBox.Show("Plz Enter right probabilities :: Newsdays Distribution Table");
                return false;
            }

            values = new List<float>();
            probabilities = new List<float>();
            for (int i = 0; i < this.dgvNewsdaysDistribution.Rows.Count; i++)
            {
                // Get the string into the cell of first column then get it's value from the enum NewsdayType
                values.Add(((float)((int)Enum.Parse(typeof(NewsdayType), this.dgvNewsdaysDistribution[this.TypeOfNewsDay.Name, i].Value.ToString()))));
                probabilities.Add(float.Parse(this.dgvNewsdaysDistribution[this.Probability.Name, i].Value.ToString()));
            }

            NewsdaysDistribution = new DiscreteDistribution(values, probabilities);

            // pnl Demand Distribution
            // Check for ACC
            for (int i = 1; i < this.dgvDemandDistribution.Columns.Count; i++)
            {
                AccCheck = CheckForColumnAcc(this.dgvDemandDistribution, i);
                if (AccCheck == false)
                {
                    MessageBox.Show("Plz Enter right probabilities :: Demand Distribution Table :: " + this.dgvDemandDistribution.Columns[i].Name + " Column");
                    return false;
                }
            }

            DemandDistribution = new List<IDistribution>((Enum.GetNames(typeof(NewsdayType)).Length));

            // Get Values Just Once
            values = new List<float>();
            for (int i = 0; i < this.dgvDemandDistribution.Rows.Count; i++)
            {
                values.Add(float.Parse(this.dgvDemandDistribution[this.Demand.Name, i].Value.ToString()));
            }

            // Get every Probabilities (their count is columns -1 (all except the values column)
            for (int j = 1; j < this.dgvDemandDistribution.Columns.Count; j++)
            {
                probabilities = new List<float>();
                // Get this Probability and set it into the array of Demand distributions according to it's value inside the Enum
                // Note that the Columns is sorted according to their sort in the Enum, so I can take the index of the column as an indicator to the Array of the Demand distributions (the array will be sorted with the enum values)
                for (int i = 0; i < this.dgvDemandDistribution.Rows.Count; i++)
                {
                    probabilities.Add(float.Parse(this.dgvDemandDistribution[j, i].Value.ToString()));
                }

                DemandDistribution.Add(new DiscreteDistribution(values, probabilities));
            }

            return true;
        }

        private bool CheckForColumnAcc(DataGridView dgv, int columnIndex)
        {
            List<float> floatValues = new List<float>();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv[columnIndex, i].Value == null)
                {
                    floatValues.Clear();
                    floatValues.Add(0);
                    break;
                }

                floatValues.Add(float.Parse(dgv[columnIndex, i].Value.ToString()));
            }

            if (floatValues.Sum() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Finalizing
    }
}