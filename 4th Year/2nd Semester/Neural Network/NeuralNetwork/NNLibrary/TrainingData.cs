using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NNLibrary
{
    public partial class TrainingData : Form
    {
        public TrainingData()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public void UpdateData(int epoch, int sampleIndex, double error, TimeSpan duration)
        {
            this.txtCurrentEpochNum.Text = epoch.ToString();
            this.txtSampleIndex.Text = sampleIndex.ToString();
            this.txtCurrentError.Text = error.ToString();
            this.txtTimeElapsed.Text = duration.ToString();

            this.Update();
        }
    }
}