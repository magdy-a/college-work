using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Section4
{
    public partial class ScaleForm : Form
    {
        public ScaleForm()
        {
            InitializeComponent();
        }

        private double _scaleFactor;

        public double ScaleFactor
        {
            get { return _scaleFactor; }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _scaleFactor = double.Parse(txtScaleFactor.Text);
        }

    }
}