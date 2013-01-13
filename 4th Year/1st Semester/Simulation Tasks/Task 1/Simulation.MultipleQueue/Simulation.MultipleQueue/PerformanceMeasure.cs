using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace MultipleQueue
{
    public enum ChartType
    {
        CustomerDelayFrequency,
        CustomerQueue,
        ServersIdle,
        ServersBusyTime
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

        List<PointPairList> serversIdleCharts = new List<PointPairList>();
        List<PointPairList> serversBusyTimes = new List<PointPairList>();

        PointPairList customerDelayGraph, customerQueueGraph;

        double averageCustomersDelay;

        double probabilityOfWait;
       
        List<double> serversIdleProbabilities;

        #endregion

        #region Properties

        public List<PointPairList> ServersIdleCharts
        {
            get { return serversIdleCharts; }
            set { serversIdleCharts = value; }
        }

        public List<PointPairList> ServersBusyTime
        {
            get { return serversBusyTimes; }
            set { serversBusyTimes = value; }
        }

        public PointPairList CustomerQueueGraph
        {
            get { return customerQueueGraph; }
            set { customerQueueGraph = value; }
        }

        public PointPairList CustomerDelayGraph
        {
            get { return customerDelayGraph; }
            set { customerDelayGraph = value; }
        }

        public double AverageCustomersDelay
        {
            get { return averageCustomersDelay; }
            set { averageCustomersDelay = value; }
        }

        public double ProbabilityOfWait
        {
            get { return probabilityOfWait; }
            set { probabilityOfWait = value; }
        }

        public List<double> ServersIdleProbabilities
        {
            get { return serversIdleProbabilities; }
            set { serversIdleProbabilities = value; }
        }

        #endregion

        public PerformanceMeasure(List<PointPairList> Ser_Idel_Chart, List<PointPairList> Ser_BusyTime_Chart, PointPairList Cust_Delay_Graph, PointPairList Cust_Que_Graph, List<double> serverIdelPro, double averageDelay, double proOfWait)
        {
            this.serversIdleCharts = Ser_Idel_Chart;

            this.serversBusyTimes = Ser_BusyTime_Chart;

            this.customerDelayGraph = Cust_Delay_Graph;

            this.customerQueueGraph = Cust_Que_Graph;

            this.serversIdleProbabilities = serverIdelPro;
            this.averageCustomersDelay = averageDelay;
            this.probabilityOfWait = proOfWait;

            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            this.cmbChartType.Items.AddRange(Enum.GetNames(typeof(ChartType)));
            this.cmbChartType.SelectedItem = ChartType.ServersIdle.ToString();

            this.cmbViewType.Items.AddRange(Enum.GetNames(typeof(ViewType)));
            this.cmbViewType.SelectedItem = ViewType.Bar.ToString();

            UpdateSheet();
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
            GraphPane tmp = this.zgcMain.GraphPane;
            tmp.CurveList.Clear();

            ChartType tmpChart;
            ViewType tmpView;

            int variant;

            tmpChart = (ChartType)cmbChartType.SelectedIndex;
            tmpView = (ViewType)cmbViewType.SelectedIndex;

            switch (tmpChart)
            {
                case ChartType.ServersIdle:

                    tmp.Title.Text = "Servers Idle Chart";

                    for (int i = 0; i < serversIdleCharts.Count; i++)
                    {
                        variant = i * 150;
                        while (variant > 255)
                        {
                            variant = variant % i;
                        }
                        switch (tmpView)
                        {
                            case ViewType.Bar:
                                tmp.AddBar("Server " + (i + 1).ToString(), serversIdleCharts[i], Color.FromArgb((i % 2 == 0) ? 255 : 0, variant, variant));
                                break;
                            case ViewType.Curve:
                                tmp.AddCurve("Server " + (i + 1).ToString(), serversIdleCharts[i], Color.FromArgb((i % 2 == 0) ? 255 : 0, variant, variant));
                                break;
                        }
                    }
                    break;
                case ChartType.ServersBusyTime:
                    tmp.Title.Text = "Servers Busy Time Chart";
                    for (int i = 0; i < serversBusyTimes.Count; i++)
                    {
                        variant = i * 150;
                        while (variant > 255)
                        {
                            variant = variant % i;
                        }
                        switch (tmpView)
                        {
                            case ViewType.Bar:
                                tmp.AddBar("Server " + (i + 1).ToString(), serversBusyTimes[i], Color.FromArgb(variant, (i % 2 == 0) ? 255 : 0, variant));
                                break;
                            case ViewType.Curve:
                                tmp.AddCurve("Server " + (i + 1).ToString(), serversBusyTimes[i], Color.FromArgb(variant, (i % 2 == 0) ? 255 : 0, variant));
                                break;
                        }
                    }
                    break;
                case ChartType.CustomerDelayFrequency:
                    tmp.Title.Text = "Customer Delay Frequency (Queue Size) Chart";
                    switch (tmpView)
                    {
                        case ViewType.Bar:
                            tmp.AddBar("Customer Queue Size", customerDelayGraph, Color.Black);
                            break;
                        case ViewType.Curve:
                            tmp.AddCurve("Customer Queue Size", customerDelayGraph, Color.Black);
                            break;
                    }
                    break;
                case ChartType.CustomerQueue:
                    tmp.Title.Text = "Customer Queue Chart";
                    switch (tmpView)
                    {
                        case ViewType.Bar:
                            tmp.AddBar("Customer Queue", customerQueueGraph, Color.Black);
                            break;
                        case ViewType.Curve:
                            tmp.AddCurve("Customer Queue", customerQueueGraph, Color.Black);
                            break;
                    }
                    break;
            }

            // Refresh for drawing
            this.zgcMain.Refresh();

            // Rescale the Graph Pane
            this.zgcMain.AxisChange();
        }

        public void UpdateSheet()
        {
            this.txtPerformanceMeasure.Text = "";

            this.txtPerformanceMeasure.Text += "Probability of Wait: " + this.probabilityOfWait.ToString() + Environment.NewLine;
            this.txtPerformanceMeasure.Text += "Average Customer Delay: " + this.averageCustomersDelay.ToString() + Environment.NewLine;

            for (int i = 0; i < this.serversIdleProbabilities.Count; i++)
            {
                this.txtPerformanceMeasure.Text += "Server [" + (i + 1).ToString() + "] Idle Probability: " + this.serversIdleProbabilities[i].ToString() + Environment.NewLine;
            }

            btnDraw_Click(null, null);
        }
    }
}