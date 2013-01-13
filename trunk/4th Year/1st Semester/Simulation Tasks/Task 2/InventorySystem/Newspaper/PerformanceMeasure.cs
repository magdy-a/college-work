using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Newspaper
{
    public enum ChartType
    {
        OverAllModels,
        CurrentModelProfitValues,
        CurrentModelProfitFrequency
    }

    public enum ViewType
    {
        Curve,
        Bar
    }

    public partial class PerformanceMeasure : Form
    {
        #region Attributes

        Point lastLocation;

        PointPairList overAllChart;

        int currentModel;

        Simulation.SimulationManager manager;

        #endregion

        public PerformanceMeasure(Simulation.SimulationManager man, int currentModel)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            this.manager = man;

            this.currentModel = currentModel;

            double[] tmpDoubleX = new double[this.manager.Range];
            for (int i = 0; i < tmpDoubleX.Length; i++)
            {
                tmpDoubleX[i] = this.manager.Start + (i * 10);
            }

            double[] tmpDoubleY = new double[this.manager.Range];
            for (int i = 0; i < tmpDoubleY.Length; i++)
            {
                tmpDoubleY[i] = this.manager.Models[i].Profit[this.manager.Models[i].Profit.Count - 1];
            }

            this.overAllChart = new PointPairList(tmpDoubleX, tmpDoubleY);

            this.cmbChartType.Items.AddRange(Enum.GetNames(typeof(ChartType)));
            this.cmbChartType.SelectedItem = ChartType.OverAllModels.ToString();

            this.cmbViewType.Items.AddRange(Enum.GetNames(typeof(ViewType)));
            this.cmbViewType.SelectedItem = ViewType.Bar.ToString();

            btnDraw_Click(null, null);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            GraphPane Pane = this.zgcMain.GraphPane;
            Pane.CurveList.Clear();

            ChartType tmpChart;
            ViewType tmpView;

            tmpChart = (ChartType)cmbChartType.SelectedIndex;
            tmpView = (ViewType)cmbViewType.SelectedIndex;

            List<double> tmpYValues;

            switch (tmpChart)
            {
                case ChartType.OverAllModels:

                    tmpYValues = this.Get_Y_Values(overAllChart);

                    Pane.Title.Text = string.Format("OverAll Models Total Profit With (Max, Min): ({0}, {1})", Math.Round(tmpYValues.Max(), 3), Math.Round(tmpYValues.Min(), 3));
                    switch (tmpView)
                    {
                        case ViewType.Bar:
                            Pane.AddBar("Total Profit", overAllChart, Color.Blue);
                            break;
                        case ViewType.Curve:
                            Pane.AddCurve("Total Profit", overAllChart, Color.Blue);
                            break;
                    }
                    break;
                case ChartType.CurrentModelProfitValues:
                    tmpYValues = this.Get_Y_Values(this.manager.Models[this.currentModel - 1].DailyProfitChart);
                    Pane.Title.Text = string.Format("Model with Inventory: {0} :: Chart of Daily Profit With (Max, Min): ({1}, {2})", this.manager.Models[this.currentModel - 1].Inventory, Math.Round(tmpYValues.Max(), 3), Math.Round(tmpYValues.Min(), 3));
                    switch (tmpView)
                    {
                        case ViewType.Bar:
                            Pane.AddBar("Daily Profit", this.manager.Models[this.currentModel - 1].DailyProfitChart, Color.Blue);
                            break;
                        case ViewType.Curve:
                            Pane.AddCurve("Daily Profit", this.manager.Models[this.currentModel - 1].DailyProfitChart, Color.Blue);
                            break;
                    }
                    break;
                case ChartType.CurrentModelProfitFrequency:

                    tmpYValues = this.Get_Y_Values(this.manager.Models[this.currentModel - 1].FrequencyProfitChart);
                    Pane.Title.Text = string.Format("Model with Inventory: {0} :: Chart of Frequency Profit With (Max, Min): ({1}, {2})", this.manager.Models[this.currentModel - 1].Inventory, Math.Round(tmpYValues.Max(), 3), Math.Round(tmpYValues.Min(), 3));
                    switch (tmpView)
                    {
                        case ViewType.Bar:
                            Pane.AddBar("Daily Frequency", this.manager.Models[this.currentModel - 1].FrequencyProfitChart, Color.Blue);
                            break;
                        case ViewType.Curve:
                            Pane.AddCurve("Daily Frequency", this.manager.Models[this.currentModel - 1].FrequencyProfitChart, Color.Blue);
                            break;
                    }

                    break;
            }

            // Refresh for drawing
            this.zgcMain.Refresh();

            // Rescale the Graph Pane
            this.zgcMain.AxisChange();
        }

        public void UpdateSheet(int ModelNumber)
        {
            this.currentModel = ModelNumber;

            btnDraw_Click(ModelNumber, null);
        }

        private List<double> Get_Y_Values(PointPairList list){
            List<double> tmp = new List<double>();
            foreach(PointPair p in list){
                tmp.Add(p.Y);
            }
            return tmp;
        }
    }
}