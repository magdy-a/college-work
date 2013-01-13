using System;
using System.Windows.Forms;

namespace Theory_Task1
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            this.InfoForm_Resize(null, null);
        }

        private void InfoForm_Resize(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Properties.Resources.TM_Info.GetThumbnailImage(this.pictureBox1.Width, this.pictureBox1.Height, null, IntPtr.Zero);
        }
    }
}