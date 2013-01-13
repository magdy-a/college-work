using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newspaper.Simulation;
using ZedGraph;
using System.Threading;

namespace Newspaper
{
    public partial class NewspaperSimulation : Form
    {
        #region Attributes

        Point lastLocation;

        SimulationManager manager;

        int currentModel;

        SystemStartup startup;

        PerformanceMeasure performanceSheet;

        #endregion

        #region Form

        public NewspaperSimulation()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
        }

        private void NewspaperSimulation_Load(object sender, EventArgs e)
        {
            this.dgvMain.Enabled = false;
            this.dgvMain.Visible = false;

            this.pnlInformation.Enabled = false;
            this.pnlInformation.Visible = false;

            this.btnRestartAll.Enabled = false;
            this.btnRestartAll.Visible = false;

            this.btnPerformanceMeasure.Enabled = false;
            this.btnPerformanceMeasure.Visible = false;

            btnStartUpData_MouseUp(null, null);

            // If the user closed the startup form, close the program
            if (this.manager == null)
            {
                Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (this.manager == null || MessageBox.Show("Do you want to EXIT the Simulation?", "Exit Simulation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
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

                StartSimulation();
            }
        }

        private void StartSimulation()
        {
            this.btnPerformanceMeasure.Enabled = true;
            this.btnPerformanceMeasure.Visible = true;

            this.btnStartUpData.Enabled = false;
            this.btnStartUpData.Visible = false;

            this.manager = startup.Manager;

            #region Main Table Values

            this.dgvMain.ReadOnly = true;
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.Rows.Add(Model.TestDays + 1);

            this.dgvMain.GridColor = Color.LightGray;

            this.dgvMain.Columns[this.Day.Name].DividerWidth = 2;
            this.dgvMain.Columns[this.DailyProfit.Index - 1].DividerWidth = 2;

            this.dgvMain.Rows[this.dgvMain.Rows.Count - 2].DividerHeight = 10;
            this.dgvMain.Rows[this.dgvMain.Rows.Count - 2].Height += this.dgvMain.Rows[this.dgvMain.Rows.Count - 2].DividerHeight;

            for (int i = 0; i < Model.TestDays; i++)
            {
                this.dgvMain[this.Day.Name, i].Value = i + 1;
            }
            this.dgvMain[this.Day.Name, Model.TestDays].Value = "Total";

            #endregion

            manager.StartSimulation();

            this.btnPrevious.Enabled = false;

            this.currentModel = 1;

            GotoModel(this.currentModel);
        }

        private void GotoModel(int ModelNumber)
        {
            // Get Model
            Model model = this.manager.Models[ModelNumber - 1];

            // Set Precision
            int precision = 3;

            // Show Inventory
            this.lblInventory.Text = "Inventory " + model.Inventory;
            //this.lblInventory.Text = model.Inventory + " In Inventory";

            // Show Inventory Buy Price
            this.lblStatistics.Text = "Inventory Buy Price = " + model.InventoryPurchasePrice + " :: Total = " + model.InventoryPurchasePrice * Model.TestDays + Environment.NewLine;
            this.lblStatistics.Text += "Total Days With Excess Demand = " + model.TotalDaysWithExcessDemand + Environment.NewLine;
            this.lblStatistics.Text += "Total Days With Unsold Papers = " + model.TotalDaysWithUnsoldPapers;

            // Table
            for (int i = 0; i < Model.TestDays; i++)
            {
                this.dgvMain[this.NewsdayType.Name, i].Value = model.Type[i];
                this.dgvMain[this.Demand.Name, i].Value = model.Demand[i];
                this.dgvMain[this.RevenueFromSales.Name, i].Value = Math.Round((double)model.Revenue[i], precision);
                this.dgvMain[this.LostProfitFromExcessDemand.Name, i].Value = Math.Round((double)model.Lost[i], precision);
                this.dgvMain[this.SalvageFromSalesOfScrap.Name, i].Value = Math.Round((double)model.Salvage[i], precision);
                this.dgvMain[this.DailyProfit.Name, i].Value = Math.Round((double)model.Profit[i], precision);
            }

            // Total
            this.dgvMain[this.RevenueFromSales.Name, Model.TestDays].Value = Math.Round((double)model.Revenue[Model.TestDays], precision);
            this.dgvMain[this.LostProfitFromExcessDemand.Name, Model.TestDays].Value = Math.Round((double)model.Lost[Model.TestDays], precision);
            this.dgvMain[this.SalvageFromSalesOfScrap.Name, Model.TestDays].Value = Math.Round((double)model.Salvage[Model.TestDays], precision);
            this.dgvMain[this.DailyProfit.Name, Model.TestDays].Value = Math.Round((double)model.Profit[Model.TestDays], precision);
        }

        #region Helping Functions

        #endregion

        #endregion

        #region PerformanceMeasure

        private void btnPerformanceMeasure_Click(object sender, EventArgs e)
        {
            if (this.performanceSheet == null || this.performanceSheet.IsDisposed)
            {
                this.performanceSheet = this.CreatePerformanceSheet(this.currentModel);
            }

            this.performanceSheet.Show();
        }

        private PerformanceMeasure CreatePerformanceSheet(int currentModel)
        {
            return new PerformanceMeasure(this.manager, currentModel);
        }

        private void updatePerformanceSheet()
        {
            if (this.performanceSheet == null || this.performanceSheet.IsDisposed)
            {
                return;
            }

            PerformanceMeasure tmpPerformance = this.CreatePerformanceSheet(this.currentModel);

            this.performanceSheet.UpdateSheet(this.currentModel);
        }

        #endregion

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
            if (this.currentModel < this.manager.Range)
            {
                this.GotoModel(++currentModel);
                this.btnPrevious.Enabled = true;
            }

            if (this.currentModel == this.manager.Range)
            {
                this.btnNext.Enabled = false;
            }

            this.updatePerformanceSheet();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.currentModel > 1)
            {
                this.GotoModel(--currentModel);
                this.btnNext.Enabled = true;
            }

            if (this.currentModel == 1)
            {
                this.btnPrevious.Enabled = false;
            }

            this.updatePerformanceSheet();
        }

        #endregion
    }
}