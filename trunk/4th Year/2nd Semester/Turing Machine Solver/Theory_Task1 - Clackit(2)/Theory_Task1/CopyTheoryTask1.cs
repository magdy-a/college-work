using System;
using System.Windows.Forms;

namespace Theory_Task1
{
    public partial class CopyOfTheoryTask1 : Form
    {
        TuringMachine TM;

        public CopyOfTheoryTask1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lvStates.AllowColumnReorder = false;
            this.lvStates.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            this.TM = new TuringMachine();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            new InfoForm().ShowDialog();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            this.TM.Set_States_Alphabet(txtStates.Text, txtTapeAlphabet.Text, txtInputAlphabet.Text);
        }
    }
}