using System.Windows.Forms;

namespace Theory_Task1
{
    public partial class TransitionTable : Form
    {
        private TuringMachine TM;

        public TransitionTable(TuringMachine _tm)
        {
            InitializeComponent();

            this.TM = _tm;
        }

        private void TransitionTable_Load(object sender, System.EventArgs e)
        {
            this.lvStates.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            this.TM.Trans.ForEach(x => this.lvStates.Items.Add(x.ToListViewItem()));
        }
    }
}