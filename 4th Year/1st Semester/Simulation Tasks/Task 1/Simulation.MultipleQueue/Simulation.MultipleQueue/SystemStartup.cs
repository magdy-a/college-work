using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MultipleQueue
{
    public partial class SystemStartup : Form
    {
        #region Attributes

        // Const
        private const int minValue = 1, errorValue = -1;
        private Random rnd;

        // Form Location
        private Point mouseDownLocation;

        // Form Controls
        private const Distributions.DistributionTypes dist = Distributions.DistributionTypes.Discrete;

        private int currentServer;

        // Simulation
        Simulation.Model model;

        List<Entities.Server> servers;

        List<float> values, probabilities;

        List<Distributions.DiscreteDistribution> serversDistribution;

        Distributions.DiscreteDistribution customerDistribution;

        List<int> priorities;

        private Simulation.ServerSelection.ServerSelectionTypes serverSel;

        private int MaxServersNo, MaxCustomersNo, MaxClockTime;

        // Tmp Values
        private DataGridViewCell tmpCell;
        private int tmpInt;
        private float tmpFloat;
        private string tmpString;
        private object tmpValue;

        #endregion

        #region Properties

        public Distributions.DistributionTypes DistributionType
        {
            get { return dist; }
        }

        public int MaxServers
        {
            get { return this.MaxServersNo; }
        }

        public int MaxCustomers
        {
            get { return this.MaxCustomersNo; }
        }

        public Simulation.ServerSelection.ServerSelectionTypes SelectionType
        {
            get { return this.serverSel; }
        }

        public Simulation.Model Model
        {
            get { return this.model; }
        }

        #endregion

        #region Form

        public SystemStartup()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            rnd = new Random();

            InitializeComponent();

            this.btnClose.BackgroundImage = MultipleQueue.Properties.Resources.close.GetThumbnailImage(40, 40, null, IntPtr.Zero);
        }

        private void SystemStartup_Load(object sender, EventArgs e)
        {
            // Testing
            //try
            //{
            //    OpenMyFile(@"SavedStartUpData\TestCaseVersion2.txt");
            //    this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //    this.BtnFinish_Click(null, null);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("An Error Happened" + "\r\n" + ex.Message);
            //}

            // Initite Window
            setPnlMainInitialData();
        }

        private void setPnlMainInitialData()
        {
            // Start Up Values

            // Dialog Results
            this.btnFinish.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // Servers No.
            this.nudNumOfServers.Minimum = minValue;
            this.nudNumOfServers.Value = 2;

            // cmbServerSelection
            this.cmbServerSelection.Items.AddRange(Enum.GetNames(typeof(MultipleQueue.Simulation.ServerSelection.ServerSelectionTypes)));
            try { this.cmbServerSelection.SelectedIndex = 0; }
            catch { }

            // Customers No.
            this.nudMaxCustomers.Value = 100;


            // Start Up View

            // SystemStartup Form
            MaximumSize = Size;

            btnFinish.Enabled = false;
            btnFinish.Visible = false;

            // Close pnlDataGridView
            this.pnlDataGridView.Enabled = false;
            this.pnlDataGridView.Visible = false;

            // Set Minimum Size of DataGridView
            this.dgvMain.MinimumSize = this.dgvMain.Size;

            // Clear Priority
            this.lblServerPriority.Visible = false;
            this.nudServerPriority.Visible = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Close the StartUp Data Window?", "Close StartUp Data Window", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Close();
            }
        }

        #endregion

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

        #endregion

        #region pnlData

        private void BtnOK_Click(object sender, EventArgs e)
        {
            setPnlGridInitialData();
        }

        private void setPnlGridInitialData()
        {
            // Close PnlMain
            this.pnlMain.Enabled = false;
            this.pnlMain.Visible = false;

            // Open PnlGridview
            this.pnlDataGridView.Enabled = true;
            this.pnlDataGridView.Visible = true;

            // Enable GridView
            this.pnlDataGridView.Enabled = true;

            // Close Finish button
            this.btnFinish.Enabled = false;
            this.btnFinish.Visible = false;

            // Create Lists
            if (serverSel == Simulation.ServerSelection.ServerSelectionTypes.HighestPriority)
            {
                this.priorities = new List<int>(MaxServersNo);
            }

            this.serversDistribution = new List<Distributions.DiscreteDistribution>(MaxServersNo);
            this.servers = new List<Entities.Server>(MaxServersNo);

            // Set Servers Number, Current
            MaxServersNo = (int)nudNumOfServers.Value;

            // Set Server Selection
            serverSel = (Simulation.ServerSelection.ServerSelectionTypes)cmbServerSelection.SelectedIndex;

            if (serverSel == Simulation.ServerSelection.ServerSelectionTypes.HighestPriority)
            {
                lblServerPriority.Visible = true;
                nudServerPriority.Visible = true;
            }

            // Set Server Priority
            this.nudServerPriority.Minimum = minValue;

            // Set Customers Number
            MaxCustomersNo = (int)nudMaxCustomers.Value;

            // Set Max Clock Time
            MaxClockTime = (int)nudMaxClock.Value;

            InitiateForCutomersDist();
        }

        private void InitiateForCutomersDist()
        {
            this.lblServerPriority.Enabled = false;
            this.lblServerPriority.Visible = false;

            this.nudServerPriority.Enabled = false;
            this.nudServerPriority.Visible = false;

            // I set currentServer by -1, to indicate that this is the CustomerDist
            currentServer = errorValue;

            this.lblServerNumber.Text = "Customers Dist.";
        }

        private void InitiateForServersDist()
        {
            if (this.serverSel == Simulation.ServerSelection.ServerSelectionTypes.HighestPriority)
            {
                this.lblServerPriority.Enabled = true;
                this.lblServerPriority.Visible = true;

                this.nudServerPriority.Enabled = true;
                this.nudServerPriority.Visible = true;
            }

            // Set current Server to First Value
            currentServer = 0;

            // Set lblServerNumber Text
            lblServerNumber.Text = "Server No.: " + (currentServer + 1).ToString();
        }

        // Finish
        private void BtnFinish_Click(object sender, EventArgs e)
        {
            // Create model
            model = new Simulation.Model(new Simulation.ServerSelection(serverSel), customerDistribution, this.servers, this.MaxCustomersNo, this.MaxClockTime);

            Close();
        }

        // Next Server
        private void btnNextServer_Click(object sender, EventArgs e)
        {
            // tmpInt will carry the lastIndex(working Index) in the table that carry data
            tmpInt = checkIfCurrentDataIsValid();

            // DataGridView
            if (tmpInt == errorValue)
            {
                MessageBox.Show("Please enter COMPLETE table values");

                return;
            }

            if (float.TryParse(this.dgvMain.Rows[tmpInt].Cells[this.dgvMain.ColumnCount - 1].Value.ToString(), out tmpFloat) == false || tmpFloat != (float)minValue)
            {
                MessageBox.Show("Please enter valid Probabilities");

                return;
            }

            // Clear Lists
            this.values = new List<float>();
            this.probabilities = new List<float>();

            for (int i = 0; i <= tmpInt; i++)
            {
                this.values.Add(float.Parse(this.dgvMain.Rows[i].Cells[0].Value.ToString()));
                this.probabilities.Add(float.Parse(this.dgvMain.Rows[i].Cells[1].Value.ToString()));
            }

            // If I am Customers Distribution
            if (currentServer == errorValue)
            {
                this.customerDistribution = new Distributions.DiscreteDistribution(values, probabilities);

                InitiateForServersDist();

                return;
            }

            // Server Priority
            if (this.serverSel == Simulation.ServerSelection.ServerSelectionTypes.HighestPriority)
            {
                this.priorities.Add((int)this.nudServerPriority.Value);
                this.nudServerPriority.Value++;
            }


            this.serversDistribution.Add(new Distributions.DiscreteDistribution(values, probabilities));

            if (serverSel == Simulation.ServerSelection.ServerSelectionTypes.HighestPriority)
            {
                this.servers.Add(new Entities.Server(serversDistribution[currentServer], this.priorities[currentServer]));
            }
            else
            {
                this.servers.Add(new Entities.Server(serversDistribution[currentServer], null));
            }

            currentServer++;

            // NextServer button Enabled + CurrentServer Label
            NavigateAndCheckForEnd();
        }

        private bool NavigateAndCheckForEnd()
        {
            // Set Enabled of NextServer Button
            if (this.currentServer == MaxServersNo)
            {
                this.pnlDataGridView.Enabled = false;
                this.pnlDataGridView.Visible = false;

                this.btnClose.Enabled = false;
                this.btnClose.Visible = false;

                // Open Finish button
                this.btnFinish.Enabled = true;
                this.btnFinish.Visible = true;

                // Open Save button
                this.btnSave.Enabled = true;
                this.btnSave.Visible = true;

                // Close Open button
                this.btnOpen.Enabled = false;
                this.btnOpen.Visible = false;

                // Close lbl Server Number
                this.lblServerNumber.Visible = false;

                //this.Height = this.btnClose.Height + 8;

                // return true, Yeah, we have reached the end
                return true;
            }
            else
            {
                this.btnNextServer.Enabled = true;

                // Set lblServerNumber Text
                lblServerNumber.Text = "Server No.: " + (currentServer + 1).ToString();

                // return fales, we didn't make it yet
                return false;
            }
        }

        private void TakeCurrentValues(int lastIndexInTable)
        {

        }

        // GridView
        private void dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // If Just left from the accumlative Probability, return
                if (e.ColumnIndex == this.dgvMain.ColumnCount - 1)
                {
                    return;
                }

                // If not all row data is True
                if (RowDataIsValid(e.RowIndex) == false)
                {
                    return;
                }

                // If Current Value is removed, so remove all Accumaltive Probs
                if (this.dgvMain.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == string.Empty)
                {
                    RemoveAllAccProbsFromIndex(e.RowIndex);

                    return;
                }

                // Take the value of current AccProb before I change it
                tmpValue = this.dgvMain.Rows[e.RowIndex].Cells[this.dgvMain.ColumnCount - 1].Value;

                // Set Accumlative Probability of this column
                SetAccumProb(e.RowIndex);

                // If Value Changed after, Renew the rest of the Column
                if (this.dgvMain.Rows[e.RowIndex].Cells[this.dgvMain.ColumnCount - 1].Value != tmpValue)
                {
                    // Check if the row was in the middle of the table, then the rest of values will to be changed
                    FixAccumProbColumnCollapseIfExist(e.RowIndex);
                }
            }
            catch
            {
                // If any unexpected error happened, remove all AccProbs
                MessageBox.Show("Error Happened!");
                btnClear_Click(null, null);
            }
        }

        private int checkIfCurrentDataIsValid()
        {
            int i, j = 0;

            for (i = 0; i < this.dgvMain.Rows.Count; i++)
            {
                // If First Cell is null, neglect the rest of the Table, we've reached the end guys
                if (this.dgvMain.Rows[i].Cells[0].Value == null)
                {
                    i--;
                    break;
                }

                // If value inside the table is null, return false
                for (j = 0; j < this.dgvMain.Rows[i].Cells.Count - 1; j++)
                {
                    if (this.dgvMain.Rows[i].Cells[j].Value == null)
                    {
                        return errorValue;
                    }
                }
            }

            // If he got out of the nested loop, but the length is less than 1, return false
            if (i + 1 < minValue)
            {
                return errorValue;
            }

            // Return the last Index
            return i;
        }

        private bool RowDataIsValid(int RowIndex)
        {
            for (int j = 0; j < this.dgvMain.ColumnCount - 1; j++)
            {
                tmpCell = this.dgvMain.Rows[RowIndex].Cells[j];

                if (tmpCell.Value == null || float.TryParse(tmpCell.Value.ToString(), out tmpFloat) == false)
                {
                    return false;
                }
            }

            if (RowIndex != 0 && this.dgvMain.Rows[RowIndex - 1].Cells[this.dgvMain.ColumnCount - 1].Value == null)
            {
                return false;
            }

            return true;
        }

        private void SetAccumProb(int RowIndex)
        {
            // If I am first row, Just set the probabiblity return
            if (RowIndex == 0)
            {
                // Set this Accumlative Prob. with this Prob
                this.dgvMain.Rows[RowIndex].Cells[this.dgvMain.ColumnCount - 1].Value = this.dgvMain.Rows[RowIndex].Cells[this.dgvMain.ColumnCount - 2].Value;

                //FixAccumProbCollapseIfExist(RowIndex);

                return;
            }

            // Get the string of the cumlative Probability of last Column
            //tmpString = this.dgvMain.Rows[RowIndex - 1].Cells[this.dgvMain.ColumnCount - 1].EditedFormattedValue.ToString();
            tmpString = this.dgvMain.Rows[RowIndex - 1].Cells[this.dgvMain.ColumnCount - 1].Value.ToString();

            // Get Last accumlative Value
            tmpFloat = float.Parse(this.dgvMain.Rows[RowIndex - 1].Cells[this.dgvMain.ColumnCount - 1].Value.ToString());

            // Add to the Current probability
            tmpFloat += float.Parse(this.dgvMain.Rows[RowIndex].Cells[this.dgvMain.ColumnCount - 2].Value.ToString());

            // Set my Cumlative Value with my previous + my Probability
            this.dgvMain.Rows[RowIndex].Cells[this.dgvMain.ColumnCount - 1].Value = tmpFloat;
        }

        private void FixAccumProbColumnCollapseIfExist(int RowIndex)
        {
            // If I am not the last row && the next row contains data in Acculative Prob., clear all next
            if (this.dgvMain.Rows.Count > RowIndex + 1)
            {
                // Starting from the next row to the end, clear all next, until you find the next row's Accum Prob not set (this means this row's data is no complete)
                for (int j = RowIndex + 1; j < this.dgvMain.Rows.Count && this.dgvMain.Rows[j].Cells[this.dgvMain.ColumnCount - 1].Value != null; j++)
                {
                    if (RowDataIsValid(RowIndex))
                    {
                        SetAccumProb(j);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void RemoveAllAccProbsFromIndex(int RowIndex)
        {
            for (int i = RowIndex; i < this.dgvMain.Rows.Count; i++)
            {
                this.dgvMain.Rows[i].Cells[this.dgvMain.ColumnCount - 1].Value = string.Empty;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Clear the Table?", "Clear Table", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.dgvMain.Rows.Clear();
            }
        }

        private void nudServerPriority_ValueChanged(object sender, EventArgs e)
        {
            if (priorities.Contains((int)nudServerPriority.Value))
            {
                MessageBox.Show("A Server contains the same Priority Value");
                while (true)
                {
                    nudServerPriority.Value = rnd.Next(MaxServersNo) + 1;
                    if (!priorities.Contains((int)nudServerPriority.Value))
                    {
                        break;
                    }
                }
            }
        }

        // Unused
        private void pnlDataGridViewReset()
        {
            this.dgvMain.Rows.Clear();

            this.currentServer = errorValue;
            this.nudServerPriority.Value = minValue;
        }

        #endregion

        #region Open & Save Data

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Txt Files *.txt|*.txt";
            OFD.Title = "Open Data File";
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenMyFile(OFD.FileName);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                BtnFinish_Click(null, null);
            }
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

        #endregion

        private List<byte> GetDoubleList(List<float> LF)
        {
            List<byte> List = new List<byte>(LF.Count * 8);

            foreach(float f in LF)
            {
                List.AddRange(BitConverter.GetBytes((double)f));
            }

            return List;
        }

        private List<float> GetFloatListFromDoublesInByteArr(List<byte> List, int Count)
        {
            List<float> LF = new List<float>(Count);

            for (int i = 0; i < Count; i++)
            {
                LF.Add((float)readDoubleThenRemoveIt(List));
            }

            return LF;
        }

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

        private void OpenMyFile(string filePath)
        {
            // Create FileStream
            FileStream FS = new FileStream(filePath, FileMode.Open);

            // The Array to read the file into
            byte[] ArrFile = new byte[FS.Length];

            // The List<byte> contains File to Decode
            List<byte> file;

            // Tmp Int For Looping
            int i;

            int tmpTableHeight;

            // Read the File
            FS.Read(ArrFile, 0, ArrFile.Length);

            // Close the File
            FS.Close();

            file = new List<byte>(ArrFile);

            // Int max Costumers
            MaxCustomersNo = readIntThenRemoveIt(file);

            // Int max Clock
            MaxClockTime = readIntThenRemoveIt(file);

            // Int Height of Customers Table
            tmpTableHeight = readIntThenRemoveIt(file);

            // List<Double> Values of Customer Distribution
            values = GetFloatListFromDoublesInByteArr(file, tmpTableHeight);

            // List<Double> Probabilities of Customer Distribution
            probabilities = GetFloatListFromDoublesInByteArr(file, tmpTableHeight);

            // Create CustomerDistribution
            this.customerDistribution = new Distributions.DiscreteDistribution(values, probabilities);

            // Int Max Servers
            MaxServersNo = readIntThenRemoveIt(file);

            // Int Server Selection
            serverSel = (Simulation.ServerSelection.ServerSelectionTypes)readIntThenRemoveIt(file);

            // Create New ServerDistribution List
            serversDistribution = new List<Distributions.DiscreteDistribution>(MaxServersNo);

            // Create New Server List
            servers = new List<Entities.Server>(MaxServersNo);

            // List<Int + List<Double> + List<Double>> == Foreach Server Add the (Height + Values + Probabilities)
            for (i = 0; i < MaxServersNo; i++)
            {
                // Int Height of this Server Table
                tmpTableHeight = readIntThenRemoveIt(file);

                // List<Double> Values of this Server Distribution
                values = GetFloatListFromDoublesInByteArr(file, tmpTableHeight);

                // List<Double> Probabilities of this Server Distribution
                probabilities = GetFloatListFromDoublesInByteArr(file, tmpTableHeight);

                // Add new Server to the List with ::
                // If Selection was Priority, Read Int Priority of this Server
                if (serverSel == Simulation.ServerSelection.ServerSelectionTypes.HighestPriority)
                {
                    servers.Add(new Entities.Server(new Distributions.DiscreteDistribution(values, probabilities), readIntThenRemoveIt(file)));
                }
                else
                {
                    servers.Add(new Entities.Server(new Distributions.DiscreteDistribution(values, probabilities), null));
                }
            }
        }

        private void SaveMyFile(string filePath)
        {
            // The File To write
            List<byte> file = new List<byte>();

            // Tmp Discrete Distribution
            Distributions.DiscreteDistribution tmpDist;

            // Int max Costumers
            file.AddRange(BitConverter.GetBytes(MaxCustomersNo));

            // Int max Clock
            file.AddRange(BitConverter.GetBytes(MaxClockTime));

            // Int Height of Customers Table
            file.AddRange(BitConverter.GetBytes(customerDistribution.Values.Count));

            // List<Double> Values of Customer Distribution
            file.AddRange(GetDoubleList(customerDistribution.Values));

            // List<Double> Probabilities of Customer Distribution
            file.AddRange(GetDoubleList(customerDistribution.Probabilities));

            // Int Max Servers
            file.AddRange(BitConverter.GetBytes(MaxServersNo));

            // Int Server Selection
            file.AddRange(BitConverter.GetBytes((int)serverSel));

            // List<Int + List<Double> + List<Double>> == Foreach Server Add the (Height + Values + Probabilities)
            foreach (Entities.Server s in servers)
            {
                // Int Height of this Server Table
                file.AddRange(BitConverter.GetBytes(((Distributions.DiscreteDistribution)(s.ServiceTimeDistribution)).Values.Count));

                // Take the Distribution in a Tmp Object
                tmpDist = (Distributions.DiscreteDistribution)s.ServiceTimeDistribution;

                // List<Double> Values of this Server Distribution
                file.AddRange(GetDoubleList(tmpDist.Values));

                // List<Double> Probabilities of this Server Distribution
                file.AddRange(GetDoubleList(tmpDist.Probabilities));

                // If Selection with Priority, Add Int Priority of File
                if (serverSel == Simulation.ServerSelection.ServerSelectionTypes.HighestPriority)
                {
                    file.AddRange(BitConverter.GetBytes((int)s.Priority));
                }
            }

            // Create FileStream
            FileStream FS = new FileStream(filePath, FileMode.Append);

            // Write the Stream
            FS.Write(file.ToArray(), 0, file.Count);

            // Close the File
            FS.Close();
        }
    }
}
