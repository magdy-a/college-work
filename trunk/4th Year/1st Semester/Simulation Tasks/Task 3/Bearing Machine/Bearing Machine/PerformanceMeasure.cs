using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace Bearing_Machine
{
    public partial class PerformanceMeasure : Form
    {
        #region Attributes

        Point lastLocation;

        PointPairList currentModule, proposedModule;

        int currentTotalMin, currentTotalMax;
        int proposedTotalMin, proposedTotalMax;

        float currentBearingsAvg, proposedBearingsAvg;
        float currentDelayAvg, proposedDelayAvg;
        float currentDowntimeAvg, proposedDowntimeAvg;
        float currentRepairpersonsAvg, proposedRepairpersonsAvg;
        float currentTotalAvg, proposedTotalAvg;

        Simulation.SimulationManager manager;

        bool isCurrentModule;

        bool isViewBar;

        #endregion Attributes

        public PerformanceMeasure(Simulation.SimulationManager man)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            this.isCurrentModule = true;

            this.isViewBar = true;

            InitializeComponent();

            this.manager = man;

            CreateCharts();

            setText();

            Draw();
        }

        private void Draw()
        {
            GraphPane Pane = this.zgcMain.GraphPane;

            Pane.CurveList.Clear();

            switch (this.isCurrentModule)
            {
                case true:

                    Pane.Title.Text = string.Format("Current Module With (Max, Min): ({0}, {1})", currentTotalMax, currentTotalMin);

                    switch (this.isViewBar)
                    {
                        case true:
                            Pane.AddBar("Total Cost", currentModule, Color.Red);
                            break;
                        case false:
                            Pane.AddCurve("Total Cost", currentModule, Color.Red);
                            break;
                    }

                    break;

                case false:

                    Pane.Title.Text = string.Format("Proposed Module With (Max, Min): ({0}, {1})", proposedTotalMax, proposedTotalMin);

                    switch (this.isViewBar)
                    {
                        case true:
                            Pane.AddBar("Total Cost", proposedModule, Color.Red);
                            break;
                        case false:
                            Pane.AddCurve("Total Cost", proposedModule, Color.Red);
                            break;
                    }

                    break;
            }

            // Refresh for drawing
            this.zgcMain.Refresh();

            // Rescale the Graph Pane
            this.zgcMain.AxisChange();
        }

        private void CreateCharts()
        {
            double[] xAxis, yAxis;

            // Current Method
            {
                currentTotalMin = int.MaxValue;
                currentTotalMax = int.MinValue;
                currentBearingsAvg = currentDelayAvg = currentDowntimeAvg = currentRepairpersonsAvg = currentTotalAvg = 0;

                foreach (CurrentModule mod in this.manager.CurrentModules)
                {
                    if (mod.StatCostTotal < currentTotalMin)
                    {
                        currentTotalMin = mod.StatCostTotal;
                    }

                    if (mod.StatCostTotal > currentTotalMax)
                    {
                        currentTotalMax = mod.StatCostTotal;
                    }

                    currentBearingsAvg += mod.StatCostBearings;
                    currentDelayAvg += mod.StatCostDelayTime;
                    currentDowntimeAvg += mod.StatCostDownTime;
                    currentRepairpersonsAvg += mod.StatCostRepairpersons;
                    currentTotalAvg += mod.StatCostTotal;
                }

                currentBearingsAvg /= this.manager.CurrentModules.Count;
                currentDelayAvg /= this.manager.CurrentModules.Count;
                currentDowntimeAvg /= this.manager.CurrentModules.Count;
                currentRepairpersonsAvg /= this.manager.CurrentModules.Count;
                currentTotalAvg /= this.manager.CurrentModules.Count;

                xAxis = new double[currentTotalMax - currentTotalMin + 1];
                //yAxis = new double[Simulation.SimulationManager.SIMULATION_RUNS];
                yAxis = new double[currentTotalMax - currentTotalMin + 1];

                for (int i = 0; i <= currentTotalMax - currentTotalMin; i++)
                {
                    xAxis[i] = i + currentTotalMin;
                }

                //foreach (CurrentModule mod in this.manager.CurrentModules)
                //{
                //    yAxis[mod.StatCostTotal - currentTotalMin] = mod.StatCostTotal;
                //}

                foreach (CurrentModule mod in this.manager.CurrentModules)
                {
                    yAxis[mod.StatCostTotal - currentTotalMin]++;
                }

                this.currentModule = new PointPairList(xAxis, yAxis);
            }

            // Proposed Method
            {
                proposedTotalMin = int.MaxValue;
                proposedTotalMax = int.MinValue;
                proposedBearingsAvg = proposedDelayAvg = proposedDowntimeAvg = proposedRepairpersonsAvg = proposedTotalAvg = 0;

                foreach (ProposedModule mod in this.manager.ProposedModules)
                {
                    if (mod.StatCostTotal < proposedTotalMin)
                    {
                        proposedTotalMin = mod.StatCostTotal;
                    }

                    if (mod.StatCostTotal > proposedTotalMax)
                    {
                        proposedTotalMax = mod.StatCostTotal;
                    }

                    proposedBearingsAvg += mod.StatCostBearings;
                    proposedDelayAvg += mod.StatCostDelayTime;
                    proposedDowntimeAvg += mod.StatCostDownTime;
                    proposedRepairpersonsAvg += mod.StatCostRepairpersons;
                    proposedTotalAvg += mod.StatCostTotal;
                }

                proposedBearingsAvg /= this.manager.ProposedModules.Count;
                proposedDelayAvg /= this.manager.ProposedModules.Count;
                proposedDowntimeAvg /= this.manager.ProposedModules.Count;
                proposedRepairpersonsAvg /= this.manager.ProposedModules.Count;
                proposedTotalAvg /= this.manager.ProposedModules.Count;

                xAxis = new double[proposedTotalMax - proposedTotalMin + 1];
                yAxis = new double[proposedTotalMax - proposedTotalMin + 1];

                for (int i = 0; i <= proposedTotalMax - proposedTotalMin; i++)
                {
                    xAxis[i] = i + proposedTotalMin;
                }

                foreach (ProposedModule mod in this.manager.ProposedModules)
                {
                    yAxis[mod.StatCostTotal - proposedTotalMin]++;
                }

                //foreach (ProposedModule mod in this.manager.ProposedModules)
                //{
                //    yAxis[mod.StatCostTotal - proposedTotalMin] = mod.StatCostTotal;
                //}

                this.proposedModule = new PointPairList(xAxis, yAxis);
            }
        }

        #region Events

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PerformanceMeasure_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void PerformanceMeasure_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            Location = new Point(Location.X + e.X - lastLocation.X, Location.Y + e.Y - lastLocation.Y);
        }

        #endregion Events

        private void lblStatistics_Click(object sender, EventArgs e)
        {
            this.isCurrentModule = !this.isCurrentModule;

            Draw();

            setText();
        }

        private void setText()
        {
            if (this.isCurrentModule)
            {
                //this.lblStatistics.Text = string.Format("Current Module: Min={0}, Max={1},Avg={2}", currentTotalMin, currentTotalMax, currentTotalAvg);
                this.lblStatistics.Text = string.Format("Current Module: Avg, Total={4}\nBearings={0}, Delay={1}, Downtime={2}, Repairpersons={3}", currentBearingsAvg, currentDelayAvg, currentDowntimeAvg, currentRepairpersonsAvg, currentTotalAvg);
            }
            else
            {
                //this.lblStatistics.Text = string.Format("Proposed Module: Min={0}, Max={1},Avg={2}", proposedTotalMin, proposedTotalMax, proposedTotalAvg);
                this.lblStatistics.Text = string.Format("Proposed Module: Avg, Total={4}\nBearings={0}, Delay={1}, Downtime={2}, Repairpersons={3}", proposedBearingsAvg, proposedDelayAvg, proposedDowntimeAvg, proposedRepairpersonsAvg, proposedTotalAvg);
            }
        }

        private void zgcMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.isViewBar = !this.isViewBar;

            Draw();
        }
    }
}