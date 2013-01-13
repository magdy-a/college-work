using System;
using System.Drawing;
using System.Windows.Forms;

namespace MD5HashGenerator
{
    public partial class MD5HashGeneratorForm : Form
    {
        private Point movingMouseDownLocation;

        MD5 md5;

        public MD5HashGeneratorForm()
        {
            InitializeComponent();

            this.md5 = new MD5();
        }

        private void BtnMD5Encrypt_Click(object sender, System.EventArgs e)
        {
            this.md5.PlainText = this.txtPlain.Text;
            this.md5.Encrypt();
            this.txtMD5Hash.Text = this.md5.CipherText;
        }

        private void MD5HashGeneratorForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.movingMouseDownLocation = e.Location;
        }

        private void MD5HashGeneratorForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            this.Location = new Point(this.Location.X + e.X - this.movingMouseDownLocation.X, this.Location.Y + e.Y - this.movingMouseDownLocation.Y);
        }

        private void BtnStyle_MouseHover(object sender, EventArgs e)
        {
            ((Button)sender).FlatStyle = FlatStyle.Standard;
        }

        private void BtnStyle_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).FlatStyle = FlatStyle.Flat;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
