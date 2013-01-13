using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MultipleQueue.Simulation;
using ZedGraph;
using System.Threading;

namespace MultipleQueue
{
    /// <summary>
    /// Jump Type in Model Tracing
    /// </summary>
    public enum JumpType
    {
        /// <summary>
        /// Jumb to NextEvent, Normal State
        /// </summary>
        NextEvent,
        /// <summary>
        /// Jump to specific Clock
        /// </summary>
        SpecificClock,
        /// <summary>
        /// Jump to specific Customer Arrival
        /// </summary>
        SpecificCustomerArrival,
        /// <summary>
        /// Jump to specific Customer Departure
        /// </summary>
        SpecificCustomerDeparture,
        /// <summary>
        /// Jumb ot the end of the Simulation
        /// </summary>
        EndOfSimulation,
    }

    public partial class MultipleServerSimulation : Form
    {

        #region Attributes

        Point lastLocation;

        Model model;

        SystemStartup startup;

        PerformanceMeasure performanceSheet;

        #endregion

        #region Form

        public MultipleServerSimulation()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
        }

        private void MultipleServerSimulation_Load(object sender, EventArgs e)
        {
            this.dgvMain.Enabled = false;
            this.dgvMain.Visible = false;

            this.pnlInformation.Enabled = false;
            this.pnlInformation.Visible = false;

            this.btnRestartAll.Enabled = false;
            this.btnRestartAll.Visible = false;

            this.btnRestartModel.Enabled = false;
            this.btnRestartModel.Visible = false;

            this.lblClockTime.Enabled = false;
            this.lblClockTime.Visible = false;

            this.btnPerformanceMeasure.Enabled = false;
            this.btnPerformanceMeasure.Visible = false;

            string[] names = Enum.GetNames(typeof(JumpType));
            this.cmbJumpType.Items.AddRange(Enum.GetNames(typeof(JumpType)));
            this.cmbJumpType.SelectedIndex = this.cmbJumpType.Items.IndexOf(JumpType.EndOfSimulation.ToString());

            btnStartUpData_MouseUp(null, null);

            // If the user closed the startup form, close the program
            if (this.model == null)
            {
                Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (this.model == null || MessageBox.Show("Do you want to EXIT the Simulation?", "Exit Simulation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnRestartAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to RESTART the Simulation?", "Restart Simulation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void btnRestartModel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to RERUN this Model?", "RERUN Model", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Not Implemented yet!");
            }
        }

        #endregion

        #region Simulation

        private void btnStartUpData_MouseUp(object sender, MouseEventArgs e)
        {
            this.Enabled = false;
            this.Visible = false;

            startup = new SystemStartup();

            startup.ShowDialog();

            this.Enabled = true;
            this.Visible = true;

            if (startup.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.dgvMain.Enabled = true;
                this.dgvMain.Visible = true;

                this.pnlInformation.Enabled = true;
                this.pnlInformation.Visible = true;

                this.btnRestartAll.Enabled = true;
                this.btnRestartAll.Visible = true;

                this.btnRestartModel.Enabled = true;
                this.btnRestartModel.Visible = true;

                this.lblClockTime.Enabled = true;
                this.lblClockTime.Visible = true;

                StartSimulation();

                // Test
                //this.cmbJumpType.SelectedItem = (JumpType.EndOfSimulation).ToString();

                //this.btnJump_Click(null, null);

                //this.btnPerformanceMeasure_Click(null, null);
            }
        }

        /// <summary>
        /// Fixes DataGridView, and initiates the Simulation
        /// </summary>
        private void StartSimulation()
        {
            this.btnPerformanceMeasure.Enabled = true;
            this.btnPerformanceMeasure.Visible = true;

            this.btnStartUpData.Enabled = false;
            this.btnStartUpData.Visible = false;

            // Set Model
            model = startup.Model;

            // Add a Column for every Server in its location one after one, after the Service Begins column
            for (int i = 1; i <= model.ServersCount; i++)
            {
                // Add Server End Time Column

                // Create Column, with Name & HeaderText
                this.dgvMain.Columns.Add(getServer_ServiceEndColumn_Name(i), getServer_ServiceEndColumn_HeaderText(i));

                // Set Sort to NotSortable
                this.dgvMain.Columns[getServer_ServiceEndColumn_Name(i)].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set it's DisplayIndex
                this.dgvMain.Columns[getServer_ServiceEndColumn_Name(i)].DisplayIndex = this.dgvMain.Columns[this.TimeServiceBegins.Name].DisplayIndex + i;
            }

            // Add divider before the first server
            this.TimeServiceBegins.DividerWidth = 3;

            // Add divider after the last server
            this.dgvMain.Columns[getServer_ServiceEndColumn_Name(model.ServersCount)].DividerWidth = 3;
        
            // Add Server Idle Time Column
            for (int i = 1; i <= model.ServersCount; i++)
            {
                // Create Column, with Name & HeaderText
                this.dgvMain.Columns.Add(getServer_IdleTime_Name(i), getServer_IdleTime_HeaderText(i));

                // Set Sort to NotSortable
                this.dgvMain.Columns[getServer_IdleTime_Name(i)].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Loop servers and set width to header text
            foreach (DataGridViewColumn c in this.dgvMain.Columns)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }

            // Set Rows to Number of a suitable number
            for (int i = 1; i < model.CustomerCountStoppingCondition * 1.5; i++)
            {
                this.dgvMain.Rows.Add();
            }

            // Initialize Model
            model.Initialize();
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            if (model.IsComplete)
            {
                return;
            }

            if (cmbJumpType.SelectedItem.ToString().CompareTo(JumpType.NextEvent.ToString()) == 0)
            {
                NextMove();
            }
            else if (cmbJumpType.SelectedItem.ToString().CompareTo(JumpType.EndOfSimulation.ToString()) == 0)
            {
                while (! model.IsComplete)
                {
                    NextMove();
                }
            }
            else if (cmbJumpType.SelectedItem.ToString().CompareTo(JumpType.SpecificClock.ToString()) == 0)
            {
                while (!model.IsComplete && (decimal)this.model.Clock < nudJumpValue.Value)
                {
                    NextMove();
                }
            }
            else if (cmbJumpType.SelectedItem.ToString().CompareTo(JumpType.SpecificCustomerArrival.ToString()) == 0)
            {
                while (!model.IsComplete && (this.model.LastCustomer == null || (decimal)this.model.LastCustomer.CustomerNumber < this.nudJumpValue.Value))
                {
                    NextMove();
                }
            }
            else if (cmbJumpType.SelectedItem.ToString().CompareTo(JumpType.SpecificCustomerDeparture.ToString()) == 0)
            {
                while (!model.IsComplete && (this.model.CompletedCustomers.Count == 0 || (decimal)this.model.CompletedCustomers.Count < this.nudJumpValue.Value))
                {
                    NextMove();
                }
            }

            this.cmbJumpType_SelectedIndexChanged(null, null);

            this.updatePerformanceSheet();
        }

        private void NextMove()
        {
            // If Completed, return
            if (this.model.IsComplete)
            {
                return;
            }

            // Tmp Row
            DataGridViewRow tmpRow;

            // Tmp Customer
            Entities.Customer tmpCustomer;

            // Tmp Int
            int tmpInt;

            // Move the model to the next move
            this.model.Next();

            // Show Current Event
            lblCurrentEvent.Text = model.LastEvent.ToString();
            // In case of Arrival, Add some Spacing for Alignment
            if (model.LastEvent == Simulation.EventType.Arrival)
            {
                lblCurrentEvent.Text += "   ";
            }

            // Show Current Clock
            lblClockTime.Text = model.Clock.ToString();

            if (this.dgvMain.Rows.Count < model.LastCustomer.CustomerNumber)
            {
                this.dgvMain.Rows.Add();
            }

            // Tmp Row
            tmpRow = this.dgvMain.Rows[model.LastCustomer.CustomerNumber - 1];

            // Tmp Customer
            tmpCustomer = model.LastCustomer;

            switch (model.LastEvent)
            {
                case EventType.Arrival:

                    // Customer Number
                    tmpRow.Cells[this.CustomerNumber.Name].Value = tmpCustomer.CustomerNumber;

                    // InterArrival Time
                    if (tmpRow.Index > 0)
                    {
                        tmpRow.Cells[this.InterArrivalTime.Name].Value = tmpCustomer.InterarrivalTime;
                    }

                    // Arrival Time
                    tmpRow.Cells[this.ArrivalTime.Name].Value = tmpCustomer.ArrivalTime;

                    // Customer Queue
                    tmpRow.Cells[this.CustomerQueue.Name].Value = this.model.CustomerQueue.Count.ToString();

                    break;
                case EventType.Departure:

                    // Server Chosen
                    tmpRow.Cells[this.ServerChosen.Name].Value = (tmpCustomer.ServerIndex + 1);

                    // Service Time
                    tmpRow.Cells[this.ServiceTime.Name].Value = tmpCustomer.ServiceTime;

                    // Time Service Begins
                    tmpRow.Cells[this.TimeServiceBegins.Name].Value = tmpCustomer.ServiceStartTime;

                    // Service Time End (for chosen server)
                    tmpRow.Cells[getServer_ServiceEndColumn_Name(tmpCustomer.ServerIndex + 1)].Value = tmpCustomer.DepartureTime;

                    // Customer Delay
                    tmpRow.Cells[this.CustomerDelay.Name].Value = tmpCustomer.DelayTime;

                    // Customer Time in System
                    tmpRow.Cells[this.TimeInSystem.Name].Value = tmpCustomer.TimeInSystem;

                    // Server Idle Time (for chosen server)
                    tmpInt = get_FirstRowIndex_WithValidInt_BeforeMe(tmpRow.Index, this.dgvMain.Columns[getServer_ServiceEndColumn_Name(tmpCustomer.ServerIndex + 1)].Name);

                    if (tmpInt != -1)
                    {
                        // Calc This Idle Time = Last ServiceBeginTime - LastServiceEndTime
                        tmpRow.Cells[getServer_IdleTime_Name(tmpCustomer.ServerIndex + 1)].Value = int.Parse(tmpRow.Cells[TimeServiceBegins.Name].Value.ToString()) - int.Parse(this.dgvMain.Rows[tmpInt].Cells[getServer_ServiceEndColumn_Name(tmpCustomer.ServerIndex + 1)].Value.ToString());
                    }
                    else
                    {
                        tmpRow.Cells[getServer_IdleTime_Name(tmpCustomer.ServerIndex + 1)].Value = int.Parse(tmpRow.Cells[TimeServiceBegins.Name].Value.ToString());
                    }

                    break;
            }
        }

        #region Helping Functions

        /// <summary>
        /// Creates a Name for the Server Service end
        /// </summary>
        /// <param name="serverNumber">Server Number (1 Based)</param>
        /// <returns>Server Name</returns>
        private string getServer_ServiceEndColumn_Name(int serverNumber)
        {
            return "ServerServiceEnd" + serverNumber.ToString();
        }

        /// <summary>
        /// Creates a HeaderText for the Server Service end
        /// </summary>
        /// <param name="serverNumber">Server Number (1 Based)</param>
        /// <returns>Server HeaderText</returns>
        private string getServer_ServiceEndColumn_HeaderText(int serverNumber)
        {
            return "Server[" + serverNumber.ToString() + "]\r\nTime Service Ends (Duration)";
            //return "Time Service Ends (Duration)\r\n Server[" + serverNumber.ToString() + "]";
        }

        /// <summary>
        /// Creates a Name for the Server Idle Char
        /// </summary>
        /// <param name="serverNumber">Server Number (1 Based)</param>
        /// <returns>Server Name</returns>
        private string getServer_IdleTime_Name(int serverNumber)
        {
            return "ServerIdleTime" + serverNumber.ToString();
        }

        /// <summary>
        /// Creates a HeaderText for the Server Idle Time
        /// </summary>
        /// <param name="serverNumber">Server Number (1 Based)</param>
        /// <returns>Server HeaderText</returns>
        private string getServer_IdleTime_HeaderText(int serverNumber)
        {
            return "Server[" + serverNumber.ToString() + "]\r\n Idle Time (Duration)";
            //return "Time Service Ends (Duration)\r\n Server[" + serverNumber.ToString() + "]";
        }

        /// <summary>
        /// Gets the First value in column before me
        /// </summary>
        /// <param name="RowIndex">Row Index in DGV</param>
        /// <param name="ColumnIndex">Column Index in DGV</param>
        /// <returns>The Result Row Index, Or -1 if nothing found</returns>
        private int get_FirstRowIndex_WithValidInt_BeforeMe(int RowIndex, string ColumnName)
        {
            if (RowIndex == 0)
                return -1;

            int tmpInt;

            for (int i = RowIndex - 1; i >= 0; i--)
            {
                if (this.dgvMain[ColumnName, i].Value != null && int.TryParse(this.dgvMain[ColumnName, i].Value.ToString(), out tmpInt) == true)
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion

        #endregion

        #region PerformanceMeasure

        private void btnPerformanceMeasure_Click(object sender, EventArgs e)
        {
            if (this.performanceSheet == null || this.performanceSheet.IsDisposed)
            {
                this.performanceSheet = this.CreatePerformanceSheet();
            }

            this.performanceSheet.Show();
        }

        private PerformanceMeasure CreatePerformanceSheet()
        {
            // Charts
            List<PointPairList> ServersIdleCharts = new List<PointPairList>();
            List<PointPairList> ServersBusyTime = new List<PointPairList>();

            PointPairList CustomerDelayGraph, CustomerQueueGraph;

            List<double> tmpList;

            double[] tmpDoubleX, tmpDoubleY;
            //End of Charts

            // Performance Measure
            List<double> ServersIdleProbabilities;
            double AverageCustomersDelay;
            double ProbabilityOfWait;

            int tmpPerformance;
            // End of Performance Measure

            // Tmp Values
            int tmpRowIndex;
            int tmpOutInt;
            // End of TmpValues

            // Get Idle Chart for each server
            ServersIdleProbabilities = new List<double>();
            for (int i = 0; i < model.ServersCount; i++)
            {
                // Create New Double List
                tmpList = new List<double>();

                // Load Server's Idle Values in a List
                for (int j = 0; j < this.model.CompletedCustomers.Count; j++)
                {
                    // Get Row Number
                    tmpRowIndex = this.model.CompletedCustomers[j].CustomerNumber - 1;

                    // Add Idle Value to List
                    // If Value was Null, Add 0 instead
                    if (this.dgvMain[getServer_IdleTime_Name(i + 1), tmpRowIndex].Value == null)
                    {
                        tmpList.Add(0);
                    }
                    else
                    {
                        tmpList.Add((int.TryParse(this.dgvMain[getServer_IdleTime_Name(i + 1), tmpRowIndex].Value.ToString(), out tmpOutInt) == true) ? tmpOutInt : 0);
                    }
                }

                // Get this Server Idle time Probabilities
                ServersIdleProbabilities.Add(tmpList.Sum() / this.model.Clock);

                // Clear the X&Y Axis
                if (tmpList.Count > 0)
                {
                    tmpDoubleX = new double[(int)tmpList.Max() + 1];
                }
                else
                {
                    tmpDoubleX = new double[1];
                }
                tmpDoubleY = new double[tmpDoubleX.Length];

                // Create X Axis in Graph
                for (int j = 0; j < tmpDoubleX.Length; j++)
                {
                    tmpDoubleX[j] = j;
                }

                // Create Y Axis in Graph
                for (int j = 0; j < tmpList.Count; j++)
                {
                    tmpDoubleY[(int)tmpList[j]]++;
                }

                // Add Current Server Chart
                ServersIdleCharts.Add(new PointPairList(tmpDoubleX, tmpDoubleY));
            }
            // End of ServersIdleCharts
            //********************************************************************************************

            // Get Servers Busy Times
            for (int i = 0; i < model.ServersCount; i++)
            {
                // Create a new double List For X-Axis with the last clock in the model run
                tmpDoubleX = new double[(int)this.model.Clock + 1];

                // Create a new double List For Y-Axis with the length of X-Axis List
                tmpDoubleY = new double[tmpDoubleX.Length];
                // Set all values to 0, indicating Idle Times
                for (int j = 0; j < tmpDoubleY.Length; j++)
                {
                    tmpDoubleX[j] = j;
                    tmpDoubleY[j] = 0;
                }

                for (int j = 0; j < this.model.CompletedCustomers.Count; j++)
                {
                    // Get Row Number
                    tmpRowIndex = this.model.CompletedCustomers[j].CustomerNumber - 1;

                    // If this Customer wasn't for this server, neglect
                    if (int.Parse(this.dgvMain[this.ServerChosen.Name, tmpRowIndex].Value.ToString()) != i + 1)
                    {
                        continue;
                    }

                    // Set Values to 1, from the range of service begins, to the service end, indicating busy time
                    for (int k = int.Parse(this.dgvMain[this.TimeServiceBegins.Name, tmpRowIndex].Value.ToString()); k < int.Parse(this.dgvMain[getServer_ServiceEndColumn_Name(i + 1), tmpRowIndex].Value.ToString()); k++)
                    {
                        tmpDoubleY[k] = 1;
                    }
                }

                // Add Current Server Chart
                ServersBusyTime.Add(new PointPairList(tmpDoubleX, tmpDoubleY));
            }
            // End of Servers Busy Times
            //********************************************************************************************

            // Get Customer Queue Size (Customer Delay Frequency)
            tmpList = new List<double>();
            tmpPerformance = 0;
            for (int j = 0; j < this.model.CompletedCustomers.Count; j++)
            {
                // Get Row Number
                tmpRowIndex = this.model.CompletedCustomers[j].CustomerNumber - 1;

                // Add Idle Value to List

                // If Value was null, set 0
                if (this.dgvMain[this.CustomerDelay.Name, tmpRowIndex].Value == null)
                {
                    tmpList.Add(0);
                }
                else
                {
                    tmpList.Add((int.TryParse(this.dgvMain[this.CustomerDelay.Name, tmpRowIndex].Value.ToString(), out tmpOutInt) == true) ? tmpOutInt : 0);
                }

                if (tmpList[j] > 0)
                {
                    tmpPerformance++;
                }
            }
            // Calculate Average Customer Delay
            AverageCustomersDelay = tmpList.Sum() / this.model.CompletedCustomers.Count;

            // Calculate Probability of Wait
            ProbabilityOfWait = tmpPerformance / (double)this.model.CompletedCustomers.Count;

            // Clear Lists with lengths of the Maximum Number in the TmpList + 1
            if (tmpList.Count > 0)
            {
                tmpDoubleX = new double[(int)tmpList.Max() + 1];
            }
            else
            {
                tmpDoubleX = new double[1];
            }

            tmpDoubleY = new double[tmpDoubleX.Length];

            // Set the X Axix 
            for (int j = 0; j < tmpDoubleX.Length; j++)
            {
                tmpDoubleX[j] = j;
            }

            // Set the Y Axis
            for (int j = 0; j < tmpList.Count; j++)
            {
                tmpDoubleY[(int)tmpList[j]]++;
            }

            // Create Customer Delay Curve
            CustomerDelayGraph = new PointPairList(tmpDoubleX, tmpDoubleY);
            // End of Customer Delay
            //********************************************************************************************

            // Get Customer Queue Graph
            tmpList = new List<double>();
            for (int j = 0; j < this.model.CompletedCustomers.Count; j++)
            {
                // Get Row Number
                tmpRowIndex = this.model.CompletedCustomers[j].CustomerNumber - 1;

                // Add Queue Size Value to List

                // If Value was null, set 0
                if (this.dgvMain[this.CustomerQueue.Name, tmpRowIndex].Value == null)
                {
                    tmpList.Add(0);
                }
                else
                {
                    tmpList.Add((int.TryParse(this.dgvMain[this.CustomerQueue.Name, tmpRowIndex].Value.ToString(), out tmpOutInt) == true) ? tmpOutInt : 0);
                }
            }

            // Clear Lists with lengths of the Maximum Number in the TmpList + 1
            if (this.model.CompletedCustomers.Count > 0)
            {
                //tmpDoubleX = new double[(int)this.model.CompletedCustomers[this.model.CompletedCustomers.Count - 1].ArrivalTime + 1];
                tmpDoubleX = new double[this.model.CompletedCustomers.Count];
            }
            else
            {
                tmpDoubleX = new double[1];
            }

            tmpDoubleY = new double[tmpDoubleX.Length];

            // Set the X Axix 
            for (int j = 0; j < this.model.CompletedCustomers.Count; j++)
            {
                tmpDoubleX[j] = this.model.CompletedCustomers[j].ArrivalTime;
            }

            // Set the Y Axis
            for (int j = 0; j < this.model.CompletedCustomers.Count; j++)
            {
                tmpDoubleY[j] = double.Parse(this.dgvMain[this.CustomerQueue.Name, this.model.CompletedCustomers[j].CustomerNumber - 1].Value.ToString());
            }

            // Create Customer Delay Curve
            CustomerQueueGraph = new PointPairList(tmpDoubleX, tmpDoubleY);
            // End of Customer Queue Graph
            //********************************************************************************************

            // Create new Performance Sheet, with calculated values
            return new PerformanceMeasure(ServersIdleCharts, ServersBusyTime, CustomerDelayGraph, CustomerQueueGraph, ServersIdleProbabilities, AverageCustomersDelay, ProbabilityOfWait);
        }

        private void updatePerformanceSheet()
        {
            if (this.performanceSheet == null || this.performanceSheet.IsDisposed)
            {
                return;
            }

            PerformanceMeasure tmpPerformance = this.CreatePerformanceSheet();

            this.performanceSheet.ServersIdleCharts = tmpPerformance.ServersIdleCharts;
            this.performanceSheet.ServersBusyTime = tmpPerformance.ServersBusyTime;
            this.performanceSheet.ServersIdleProbabilities = tmpPerformance.ServersIdleProbabilities;

            this.performanceSheet.CustomerDelayGraph = tmpPerformance.CustomerDelayGraph;
            this.performanceSheet.CustomerQueueGraph = tmpPerformance.CustomerQueueGraph;
            this.performanceSheet.AverageCustomersDelay = tmpPerformance.AverageCustomersDelay;

            this.performanceSheet.ProbabilityOfWait = tmpPerformance.ProbabilityOfWait;

            this.performanceSheet.UpdateSheet();
        }

        #endregion

        #region Events

        private void MultipleServerSimulation_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void MultipleServerSimulation_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            Location = new Point(Location.X + e.X - lastLocation.X, Location.Y + e.Y - lastLocation.Y);
        }

        private void cmbJumpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)this.cmbJumpType.SelectedItem == JumpType.NextEvent.ToString() || (string)this.cmbJumpType.SelectedItem == JumpType.EndOfSimulation.ToString())
            {
                this.nudJumpValue.Enabled = false;
                this.nudJumpValue.Visible = false;
            }
            else
            {
                this.nudJumpValue.Enabled = true;
                this.nudJumpValue.Visible = true;

                if (this.model == null)
                {
                    this.nudJumpValue.Minimum = 0;
                }
                else if (this.cmbJumpType.SelectedItem.ToString().CompareTo(JumpType.SpecificClock.ToString()) == 0)
                {
                    this.nudJumpValue.Minimum = (decimal)this.model.Clock;

                    if (this.model.IsComplete)
                    {
                        this.nudJumpValue.Maximum = (decimal)this.model.Clock;
                    }
                    else
                    {
                        this.nudJumpValue.Minimum++;
                        this.nudJumpValue.Maximum = this.model.MaxClockStoppingCondition;
                    }
                }
                else if (this.cmbJumpType.SelectedItem.ToString().CompareTo(JumpType.SpecificCustomerArrival.ToString()) == 0)
                {
                    if (this.model.LastCustomer != null)
                    {
                        this.nudJumpValue.Minimum = (decimal)this.model.LastCustomer.CustomerNumber;

                        if (!this.model.IsComplete)
                        {
                            this.nudJumpValue.Minimum++;
                        }
                    }
                    else
                    {
                        this.nudJumpValue.Minimum = 0;
                    }

                    this.nudJumpValue.Maximum = (decimal)this.model.CustomerCountStoppingCondition;
                }
                else if (this.cmbJumpType.SelectedItem.ToString().CompareTo(JumpType.SpecificCustomerDeparture.ToString()) == 0)
                {
                    if (this.model.CompletedCustomers.Count > 0)
                    {
                        this.nudJumpValue.Minimum = (decimal)this.model.CompletedCustomers[this.model.CompletedCustomers.Count - 1].CustomerNumber;

                        if (!this.model.IsComplete)
                        {
                            this.nudJumpValue.Minimum++;
                        }
                    }
                    else
                    {
                        this.nudJumpValue.Minimum = 0;
                    }

                    this.nudJumpValue.Maximum = (decimal)this.model.CustomerCountStoppingCondition;
                }

                this.nudJumpValue.Value = this.nudJumpValue.Minimum;
            }
        }

        #endregion
    }
}