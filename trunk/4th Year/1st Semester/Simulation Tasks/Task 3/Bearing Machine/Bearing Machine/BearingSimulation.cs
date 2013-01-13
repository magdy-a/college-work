using System;
using System.Drawing;
using System.Windows.Forms;
using Bearing_Machine.Simulation;

namespace Bearing_Machine
{
    public partial class BearingSimulation : Form
    {
        #region Attributes

        Point lastLocation;

        SimulationManager manager;

        int currentModule;

        bool IsCurrentModule;

        PerformanceMeasure performanceSheet;

        #endregion Attributes

        #region Form

        public BearingSimulation()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            this.dgvCurrentModule.AllowUserToAddRows = false;
            this.dgvProposedModule.AllowUserToAddRows = false;

            this.IsCurrentModule = true;
        }

        private void BearingSimulation_Load(object sender, EventArgs e)
        {
            StartSimulation();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion Form

        #region Simulation

        private void StartSimulation()
        {
            this.manager = new SimulationManager();

            manager.StartSimulation();

            this.btnPrevious.Enabled = false;

            this.currentModule = 1;

            GotoModel(this.currentModule);
        }

        private void GotoModel(int ModuleNumber)
        {
            CurrentModule tmpCurrent = this.manager.CurrentModules[ModuleNumber - 1];
            ProposedModule tmpProposed = this.manager.ProposedModules[ModuleNumber - 1];

            int max;
            int sumDelay;

            SetText();

            // Current Module
            {
                DataGridViewColumn tmpColumnLife;
                DataGridViewColumn tmpColumnAccLife;
                DataGridViewColumn tmpColumnDelay;

                // Clear Values
                this.dgvCurrentModule.Rows.Clear();

                // Get Max Index
                max = int.MinValue;
                for (int i = 0; i < Module.NUM_OF_BEARINGS_IN_MACHINE; i++)
                {
                    max = Math.Max(max, tmpCurrent.Table[i].Count);
                }

                // Add Rows
                this.dgvCurrentModule.Rows.Add(max + 1);

                for (int i = 0; i < max; i++)
                {
                    this.dgvCurrentModule[colCurrentBearingNumber.Name, i].Value = (i + 1).ToString();
                }

                // StatCostTotal Row
                this.dgvCurrentModule.Rows[max - 1].DividerHeight = 5;
                this.dgvCurrentModule[colCurrentBearingNumber.Name, max].Value = "Total";

                // Add Values
                for (int i = 0; i < Module.NUM_OF_BEARINGS_IN_MACHINE; i++)
                {
                    tmpColumnLife = i == 0 ? colBearingOneLife : i == 1 ? colBearingTwoLife : colBearingThreeLife;
                    tmpColumnAccLife = i == 0 ? colBearingOneAccLife : i == 1 ? colBearingTwoAccLife : colBearingThreeAccLife;
                    tmpColumnDelay = i == 0 ? colBearingOneDelay : i == 1 ? colBearingTwoDelay : colBearingThreeDelay;

                    sumDelay = 0;

                    for (int j = 0; j < tmpCurrent.Table[i].Count; j++)
                    {
                        this.dgvCurrentModule[tmpColumnLife.Name, j].Value = tmpCurrent.Table[i][j].LifeHours;
                        this.dgvCurrentModule[tmpColumnAccLife.Name, j].Value = tmpCurrent.Table[i][j].AccLifeHours;
                        this.dgvCurrentModule[tmpColumnDelay.Name, j].Value = tmpCurrent.Table[i][j].Delay;

                        sumDelay += tmpCurrent.Table[i][j].Delay;
                    }

                    this.dgvCurrentModule[tmpColumnDelay.Name, max].Value = sumDelay;
                }
            }

            // Proposed Module
            {
                // Clear Values
                this.dgvProposedModule.Rows.Clear();

                // Get Max Index
                max = tmpProposed.FirstFailure.Count;

                // Add Rows
                this.dgvProposedModule.Rows.Add(max + 1);

                // Add another Row for the StatCostTotal
                this.dgvProposedModule.Rows[max - 1].DividerHeight = 5;
                this.dgvProposedModule[colPorposedIndex.Name, max].Value = "Total";

                // Add Values
                sumDelay = 0;
                for (int i = 0; i < max; i++)
                {
                    this.dgvProposedModule[colPorposedIndex.Name, i].Value = (i + 1).ToString();
                    this.dgvProposedModule[colProposedBearingOneLife.Name, i].Value = tmpProposed.Table[0][i].LifeHours;
                    this.dgvProposedModule[colProposedBearingTwoLife.Name, i].Value = tmpProposed.Table[1][i].LifeHours;
                    this.dgvProposedModule[colProposedBearingThreeLife.Name, i].Value = tmpProposed.Table[2][i].LifeHours;
                    this.dgvProposedModule[colProposedFirstFailure.Name, i].Value = tmpProposed.FirstFailure[i];
                    this.dgvProposedModule[colProposedAccLife.Name, i].Value = tmpProposed.AccLife[i];
                    this.dgvProposedModule[colProposedDelay.Name, i].Value = tmpProposed.Delay[i];
                    sumDelay += tmpProposed.Delay[i];
                }

                this.dgvProposedModule[colProposedDelay.Name, max].Value = sumDelay;
            }
        }

        #endregion Simulation

        #region PerformanceMeasure

        /// <summary>
        /// Shows the data of the Current Table
        /// </summary>
        private void SetText()
        {
            // Show Title & Statistics
            if (this.IsCurrentModule)
            {
                this.dgvCurrentModule.BringToFront();
                this.lblModuleType.Text = string.Format("#: {0} :: Current", this.currentModule);

                this.lblStatistics.Text = string.Format("#Bearings: {0}, SumDelay(Min): {1}\nBearings: {2}$, Delay: {3}$, Downtime: {4}$, Repairpersons: {5}$\nTotal: {6}$",
                    this.manager.CurrentModules[currentModule - 1].StatNumOfBearings,
                    this.manager.CurrentModules[currentModule - 1].StatDelayTotal,
                    this.manager.CurrentModules[currentModule - 1].StatCostBearings,
                    this.manager.CurrentModules[currentModule - 1].StatCostDelayTime,
                    this.manager.CurrentModules[currentModule - 1].StatCostDownTime,
                    this.manager.CurrentModules[currentModule - 1].StatCostRepairpersons,
                    this.manager.CurrentModules[currentModule - 1].StatCostTotal
                    );
            }
            else
            {
                this.dgvProposedModule.BringToFront();
                this.lblModuleType.Text = string.Format("#: {0} :: Proposed", this.currentModule);

                this.lblStatistics.Text = string.Format("#Bearings: {0}, SumDelay(Min): {1}\nBearings: {2}$, Delay: {3}$, Downtime: {4}$, Repairpersons: {5}$\nTotal: {6}$",
                    this.manager.ProposedModules[currentModule - 1].StatNumOfBearings,
                    this.manager.ProposedModules[currentModule - 1].StatDelayTotal,
                    this.manager.ProposedModules[currentModule - 1].StatCostBearings,
                    this.manager.ProposedModules[currentModule - 1].StatCostDelayTime,
                    this.manager.ProposedModules[currentModule - 1].StatCostDownTime,
                    this.manager.ProposedModules[currentModule - 1].StatCostRepairpersons,
                    this.manager.ProposedModules[currentModule - 1].StatCostTotal
                    );
            }
        }

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
            return new PerformanceMeasure(this.manager);
        }

        #endregion PerformanceMeasure

        #region Events

        private void NewspaperSimulation_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void NewspaperSimulation_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            Location = new Point(Location.X + e.X - lastLocation.X, Location.Y + e.Y - lastLocation.Y);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentModule < SimulationManager.SIMULATION_RUNS)
            {
                this.GotoModel(++currentModule);
                this.btnPrevious.Enabled = true;
            }

            if (this.currentModule == SimulationManager.SIMULATION_RUNS)
            {
                this.btnNext.Enabled = false;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.currentModule > 1)
            {
                this.GotoModel(--currentModule);
                this.btnNext.Enabled = true;
            }

            if (this.currentModule == 1)
            {
                this.btnPrevious.Enabled = false;
            }
        }

        /// <summary>
        /// Changes the table showed in the form
        /// </summary>
        /// <param name="sender">The Sender to this Function</param>
        /// <param name="e">The Event Arguments</param>
        private void lblModuleType_Click(object sender, EventArgs e)
        {
            // Inverse
            this.IsCurrentModule = !this.IsCurrentModule;

            this.SetText();
        }

        #endregion Events
    }
}