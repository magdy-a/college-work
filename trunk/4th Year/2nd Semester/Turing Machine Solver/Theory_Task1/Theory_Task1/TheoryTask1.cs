using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Theory_Task1
{
    public partial class TheoryTask1 : Form
    {
        TuringMachine TM;

        int Num_Of_Transitions;

        public TheoryTask1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TM = new TuringMachine();

            // Set #Transitions to ZERO
            this.Num_Of_Transitions = 0;
            this.lblNumOfTransitions.Text = "Number of Transitions = " + this.Num_Of_Transitions.ToString();

            this.pnlAlphabet.BringToFront();

            // Make the other PNLs Disappear
            this.pnlTransition.Enabled = false;
            this.pnlTransition.Visible = false;
            this.pnlInput.Enabled = false;
            this.pnlInput.Visible = false;

            // Test Code
            btnValidate_Click(null, null);
            this.clbFinalStates.SetItemChecked(0, false);
            this.clbFinalStates.SetItemChecked(1, true);
            this.TM.Trans.AddRange(
                new List<Transition>() {
                new Transition(){From = 1, Input = 'a', To = 1, Output = "b", Cursor = TuringMachine.Right},
                new Transition(){From = 1, Input = ' ', To = 2, Output = " ", Cursor = TuringMachine.Stop},
            });
            this.btnGo_Click(null, null);
            this.txtInput.Text = "aaa";
            this.btnSolve_Click(null, null);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            new InfoForm().ShowDialog();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (this.txtStates.TextLength == 0 || this.txtTapeAlphabet.TextLength == 0 || this.txtInputAlphabet.TextLength == 0)
            {
                MessageBox.Show("Plz fill all the boxes");
                return;
            }
            // Set the states and alphabet for this TuringMachine
            this.TM.Set_States_Alphabet(txtStates.Text, txtTapeAlphabet.Text, txtInputAlphabet.Text);

            // Set Lists Values
            this.TM.States.ForEach(x => this.cmb_f_s.Items.Add(x));
            this.TM.States.ForEach(x => this.cmb_t_s.Items.Add(x));
            this.TM.States.ForEach(x => this.cmbStartState.Items.Add(x));
            this.TM.States.ForEach(x => this.clbFinalStates.Items.Add(x));
            this.TM.TapeAlphabet.ForEach(x => this.cmb_f_i.Items.Add(x));
            this.cmb_t_c.Items.AddRange(new object[] { TuringMachine.Left, TuringMachine.Right, TuringMachine.Stop });

            // Set tape field to space
            //this.txt_t_o.Text = TuringMachine.Space.ToString();

            // Set Index to first element
            this.cmb_f_s.SelectedIndex = this.cmb_f_i.SelectedIndex = this.cmb_t_s.SelectedIndex = this.cmb_t_c.SelectedIndex = this.cmbStartState.SelectedIndex = 0;

            // Set default final state
            this.clbFinalStates.SetItemChecked(0, true);

            // Show Next Pnl (Transition)
            this.pnlAlphabet.Enabled = false;
            this.pnlAlphabet.Visible = false;
            this.pnlTransition.Enabled = true;
            this.pnlTransition.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.txt_t_o.TextLength == 0)
            {
                MessageBox.Show("Plz enter value the tape field");
                return;
            }
            if (this.txt_t_o.TextLength == 0 || this.txt_t_o.TextLength > 2)
            {
                MessageBox.Show("You can't enter more than two chars in the tape field");
                return;
            }

            // TODO You should check for the input char, and check that is exists in the inputAlphabet List in TM
            //if (new List<char>(this.txt_t_o.Text.ToCharArray()).FindAll(x => this.TM.TapeAlphabet.Find(y => y.CompareTo(x) == 0) != null).Count < this.txt_t_o.TextLength)
            //{
            //    MessageBox.Show("Some chars don't exist in the tapeAlphabet List");
            //    return;
            //}

            // Create new Transition
            Transition tmp = new Transition();
            tmp.From = int.Parse(this.cmb_f_s.SelectedItem.ToString());
            tmp.To = int.Parse(this.cmb_t_s.SelectedItem.ToString());
            tmp.Input = this.cmb_f_i.SelectedItem.ToString()[0];
            tmp.Output = this.txt_t_o.Text;
            tmp.Cursor = this.cmb_t_c.SelectedItem.ToString()[0];

            // Check for duplication of transition
            if (this.TM.Trans.Find(x => x.Equals((object)tmp)) != null)
            {
                MessageBox.Show("You entered the same transition before");
                return;
            }

            // Add the transition to the List of Transitions
            this.TM.Trans.Add(tmp);

            // Inc the #Transitions and display it in it's label
            this.lblNumOfTransitions.Text = "Number of Transitions = " + (++this.Num_Of_Transitions).ToString();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (this.TM.Trans.Count == 0)
            {
                MessageBox.Show("Plz enter some transitions");
                return;
            }

            // Set the final states
            foreach (int index in this.clbFinalStates.CheckedIndices)
            {
                this.TM.FinalStates.Add(int.Parse(this.clbFinalStates.Items[index].ToString()));
            }

            if (this.TM.FinalStates.Count == 0)
            {
                MessageBox.Show("Please define the final states");
                return;
            }

            // Create the transitionTable
            this.TM.CreateTable();

            // Show Next Pnl (Input)
            this.pnlTransition.Enabled = false;
            this.pnlTransition.Visible = false;
            this.pnlInput.Enabled = true;
            this.pnlInput.Visible = true;
        }

        private void txt_t_o_Enter(object sender, EventArgs e)
        {
            this.txt_t_o.SelectionStart = 0;
            this.txt_t_o.SelectionLength = this.txt_t_o.TextLength;
        }

        private void btnTransitionTable_Click(object sender, EventArgs e)
        {
            new TransitionTable(this.TM).ShowDialog();
        }

        /// <summary>
        /// Solves the input with the TuringMachine
        /// </summary>
        /// <param name="sender">The Sender to this event</param>
        /// <param name="e">The EventArgs for this event</param>
        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (this.txtInput.TextLength == 0)
            {
                MessageBox.Show("Plz enter any Input");
                return;
            }

            // Set the input in the TuringMachine
            this.TM.Input = this.txtInput.Text;

            // Solve the input, and display if it is Accepted or not
            if (this.TM.Solve())
            {
                this.lblAccepted.Text = "Accepted";
            }
            else
            {
                this.lblAccepted.Text = "Rejected";
            }

            // Display the tape
            this.txtOutput.Text = new string(this.TM.Tape.ToArray());
        }

        private void btnFai_Click(object sender, EventArgs e)
        {
            this.txt_t_o.Text += TuringMachine.Fai;
            txt_t_o_Leave(null, null);
        }

        private void txt_t_o_Leave(object sender, EventArgs e)
        {
            int length = this.txt_t_o.TextLength;
            new List<char>(this.txt_t_o.Text.ToCharArray()).FindAll(x => this.TM.TapeAlphabet.Contains(x)).ForEach(x => this.txt_t_o.Text += x);
            this.txt_t_o.Text = this.txt_t_o.Text.Remove(0, length);
            if (this.txt_t_o.TextLength > 2)
            {
                this.txt_t_o.Text = this.txt_t_o.Text.Remove(2);
            }
        }
    }
}