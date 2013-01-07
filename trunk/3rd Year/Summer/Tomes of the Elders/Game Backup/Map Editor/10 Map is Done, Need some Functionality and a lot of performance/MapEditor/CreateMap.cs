using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class CreateMap : Form
    {

        internal Size MapSize;
        internal int NumOfFloors;
        internal int CurrentFloor;
        internal String FilePath;

        public CreateMap()
        {
            InitializeComponent();
        }

        public CreateMap(int Nothing)
        {
            InitializeComponent();
            txtLoadData.Text = "C:\\Users\\magdy\\Desktop\\ProjectDataMapTest.dat";
            btnGo_Click(new object(), new EventArgs());
        }

        private void txtLoadData_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "dat Files (*.dat)|*.dat";
            openFileDialog1.Title = "Load File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLoadData.Text = openFileDialog1.FileName;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Plz Check the Data Again ! ");
            }
        }

        private void CreateMap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && CheckData())
            {
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Plz Check the Data Again ! ");
            }
        }

        private bool CheckData()
        {
            if (TxtMapSizeWidth.Text == "" ||
                txtMapSizeHeight.Text == "" ||
                txtNumOfFloors.Text == "" ||
                txtCurrentFloor.Text == "" ||
                txtLoadData.Text == "" ||
                txtLoadData.Text == "Click To Open"){
                return false;
            }
            MapSize = new Size(int.Parse(TxtMapSizeWidth.Text), int.Parse(txtMapSizeHeight.Text));
            NumOfFloors = int.Parse(txtNumOfFloors.Text);
            CurrentFloor = int.Parse(txtCurrentFloor.Text);
            FilePath = txtLoadData.Text;
            return true;
        }
    }
}