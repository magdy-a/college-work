using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bearing_Machine.Distributions;
using Bearing_Machine.Simulation;

namespace Bearing_Machine
{
    public partial class SystemStartup : Form
    {
        #region Members

        private Point mouseDownLocation;

        private List<float> values, probabilities;

        private static int NUMBER_OF_PANELS = 3;
        private int currentPanel;

        #endregion Members

        #region Form

        public SystemStartup()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            setSomeInitialData();

            this.btnClose.BackgroundImage = Bearing_Machine.Properties.Resources.close.GetThumbnailImage(40, 40, null, IntPtr.Zero);
        }

        private void SystemStartup_Load(object sender, EventArgs e)
        {
            // General Panel
            currentPanel = 1;

            this.btnPrevious.Enabled = false;

            GotoPnl(currentPanel);
        }

        private void setSomeInitialData()
        {
            values = new float[] { 5, 10, 15 }.ToList();
            probabilities = new float[] { 0.6f, 0.3f, 0.1f }.ToList();

            // Set Delay Time Distribution
            this.dgvDelayTimeDistribution.Rows.Add(3);
            for (int i = 0; i < 3; i++)
            {
                this.dgvDelayTimeDistribution[this.colDelayTime.Name, i].Value = values[i];
                this.dgvDelayTimeDistribution[this.colDelayTimeProbability.Name, i].Value = probabilities[i];
            }

            // Set Bearing Life Distribution
            this.dgvBearingLifeDistribution.Rows.Add(10);
            values = new float[] { 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900 }.ToList();
            probabilities = new float[] { 0.10f, 0.13f, 0.25f, 0.13f, 0.09f, 0.12f, 0.02f, 0.06f, 0.05f, 0.05f }.ToList();
            for (int i = 0; i < 10; i++)
            {
                this.dgvBearingLifeDistribution[this.colBearingLife.Name, i].Value = values[i];
                this.dgvBearingLifeDistribution[this.colBearingLifeProbability.Name, i].Value = probabilities[i];
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
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

        #region Finalizing

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            if (TakeInformation() == false)
            {
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            Close();
        }

        private bool TakeInformation()
        {
            // Check the data in the data grid view
            if (getAcceptedRowCount(this.dgvBearingLifeDistribution) == 0 ||
                this.getAcceptedRowCount(this.dgvDelayTimeDistribution) == 0 ||
                !this.CheckForColumnAcc(this.dgvBearingLifeDistribution, this.colBearingLifeProbability.Index) ||
                !this.CheckForColumnAcc(this.dgvDelayTimeDistribution, this.colDelayTimeProbability.Index))
            {
                return false;
            }

            // pnl Main
            // Set Costs
            Module.COST_DOWNTIME_PER_MIN = (int)nudDownTime.Value;
            Module.COST_DIRECT_ONSITE_REPAIRPERSON_Per_Hour = (int)nudOnsiteCost.Value;
            Module.COST_BEARING = (int)nudBearingCost.Value;

            // Set Times
            Module.TIME_CHANGE_ONE_BEARING = (int)nudOneBearingChange.Value;
            Module.TIME_CHANGE_TWO_BEARINGS = (int)nudTwoBearingChange.Value;
            Module.TIME_CHANGE_THREE_BEARINGS = (int)nudThreeBearingChange.Value;

            // Set Simulation Hours
            Module.SIMULATION_HOURS = (int)nudSimulationHours.Value;

            // Set Simulation Runs
            SimulationManager.SIMULATION_RUNS = (int)nudSimulationRuns.Value;

            // Set Number of Bearing in the Machine
            Module.NUM_OF_BEARINGS_IN_MACHINE = 3;

            // Set Distributions
            // Bearing Life
            this.values = new List<float>();
            this.probabilities = new List<float>();
            for (int i = 0; i < getAcceptedRowCount(this.dgvBearingLifeDistribution); i++)
            {
                this.values.Add(float.Parse(this.dgvBearingLifeDistribution[colBearingLife.Name, i].Value.ToString()));
                this.probabilities.Add(float.Parse(this.dgvBearingLifeDistribution[colBearingLifeProbability.Name, i].Value.ToString()));
            }
            Module.DIST_BEARING_LIFE = new DiscreteDistribution(values, probabilities);

            // Delay Time
            this.values = new List<float>();
            this.probabilities = new List<float>();
            for (int i = 0; i < getAcceptedRowCount(this.dgvDelayTimeDistribution); i++)
            {
                this.values.Add(float.Parse(this.dgvDelayTimeDistribution[colDelayTime.Name, i].Value.ToString()));
                this.probabilities.Add(float.Parse(this.dgvDelayTimeDistribution[colDelayTimeProbability.Name, i].Value.ToString()));
            }
            Module.DIST_DELAY_TIME = new DiscreteDistribution(values, probabilities);

            return true;
        }

        private bool CheckForColumnAcc(DataGridView dgv, int columnIndex)
        {
            List<float> floatValues = new List<float>();

            for (int i = 0; i < getAcceptedRowCount(dgv); i++)
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

        private int getAcceptedRowCount(DataGridView dgv)
        {
            int i;

            // Loop each row in the data grid view, foreach cell in the row if it was null, return this index as count
            for (i = 0; i < dgv.RowCount; i++)
            {
                foreach (DataGridViewCell c in dgv.Rows[i].Cells)
                {
                    if (c.Value == null)
                    {
                        return i;
                    }
                }
            }

            return i;
        }

        #endregion Finalizing
    }
}