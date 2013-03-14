using System;
using System.Drawing;
using System.Windows.Forms;

namespace MD5HashGenerator
{
    public partial class MD5HashGeneratorForm : Form
    {
        #region Attributes

        private Point movingMouseDownLocation;

        private MD5 md5;

        private ToolTip tip;

        #endregion

        #region Constructor

        public MD5HashGeneratorForm()
        {
            InitializeComponent();

            this.md5 = new MD5();

            this.tip = new ToolTip();

            this.tip.SetToolTip(this.txtPlain, "Write text to encode");
            this.tip.SetToolTip(this.txtMD5Hash, "Encoded MD5 Hash");
            this.tip.SetToolTip(this.btnCopyToClipboard, "Copy MD5 Hash to the Clipboard");
            this.tip.SetToolTip(this.btnClose, "Close");
            this.tip.SetToolTip(this.pnlBackground, "Drag to move the window");

            this.TxtPlain_TextChanged(null, null);
        }

        #endregion

        #region Methods

        private void MD5_Encrypt()
        {
            this.md5.PlainText = this.txtPlain.Text;
            this.md5.Encrypt();
            this.txtMD5Hash.Text = this.md5.CipherText;
        }

        #endregion

        #region Form Events

        private void TxtPlain_TextChanged(object sender, EventArgs e)
        {
            this.MD5_Encrypt();
        }

        private void BtnCopyToClipboard_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(this.txtMD5Hash.Text);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Style Events

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

        #endregion
    }
}
