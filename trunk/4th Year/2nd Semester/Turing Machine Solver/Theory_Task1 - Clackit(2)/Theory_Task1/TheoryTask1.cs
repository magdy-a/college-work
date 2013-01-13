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

            //// Code 1 (Convert All A's To B's)
            //this.txtStates.Text = "1,2";
            //this.txtTapeAlphabet.Text = "a,b";
            //this.txtInputAlphabet.Text = "a,b";
            //btnValidate_Click(null, null);
            //this.clbFinalStates.SetItemChecked(0, false);
            //this.clbFinalStates.SetItemChecked(1, true);
            //this.TM.Trans.AddRange(
            //    new List<Transition>() {
            //    new Transition(){From = 1, Input = 'a', To = 1, Output = "b", Cursor = TuringMachine.Right},
            //    new Transition(){From = 1, Input = TuringMachine.Fai, To = 2, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Stop},
            //});
            //this.btnGo_Click(null, null);
            //this.txtInput.Text = "aaa";
            //this.btnSolve_Click(null, null);

            //// Code 2 (A's Equal to B's)
            //this.txtStates.Text = "1,2,3,4,5";
            //this.txtTapeAlphabet.Text = "a,b";
            //this.txtInputAlphabet.Text = "a,b";
            //btnValidate_Click(null, null);
            //this.clbFinalStates.SetItemChecked(0, false);
            //this.clbFinalStates.SetItemChecked(4, true);
            //this.TM.Trans.AddRange(
            //    new List<Transition>() {
            //    // Stopping Condition
            //    new Transition(){From = 1, Input = TuringMachine.Fai, To = 5, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Stop},

            //    // Remove a from start
            //    new Transition(){From = 1, Input = 'a', To = 2, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},

            //    // Continue to most right
            //    new Transition(){From = 2, Input = 'a', To = 2, Output = "a", Cursor = TuringMachine.Right},
            //    new Transition(){From = 2, Input = 'b', To = 2, Output = "b", Cursor = TuringMachine.Right},

            //    // If empty Stop and go back
            //    new Transition(){From = 2, Input = TuringMachine.Fai, To = 3, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},

            //    // Remove b from the end
            //    new Transition(){From = 3, Input = 'b', To = 4, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},

            //    // Go to most Left
            //    new Transition(){From = 4, Input = 'a', To = 4, Output = "a", Cursor = TuringMachine.Left},
            //    new Transition(){From = 4, Input = 'b', To = 4, Output = "b", Cursor = TuringMachine.Left},

            //    // If Empty Stop and go forward
            //    new Transition(){From = 4, Input = TuringMachine.Fai, To = 1, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},
            //});
            //this.btnGo_Click(null, null);
            //this.txtInput.Text = "";
            //this.btnSolve_Click(null, null);

            //// Code 3 (Palindrome)
            //this.txtStates.Text = "1,2,3,4,5,6,7,8";
            //this.txtTapeAlphabet.Text = "a,b";
            //this.txtInputAlphabet.Text = "a,b";

            //btnValidate_Click(null, null);
            //this.clbFinalStates.SetItemChecked(0, false);
            //this.clbFinalStates.SetItemChecked(7, true);
            //this.TM.Trans.AddRange(
            //    new List<Transition>() {
            //    // Stopping Condition
            //    new Transition(){From = 1, Input = TuringMachine.Fai, To = 8, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Stop},

            //    // Remove a from start
            //    new Transition(){From = 1, Input = 'a', To = 2, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},

            //    // Continue to most right
            //    new Transition(){From = 2, Input = 'a', To = 2, Output = "a", Cursor = TuringMachine.Right},
            //    new Transition(){From = 2, Input = 'b', To = 2, Output = "b", Cursor = TuringMachine.Right},

            //    // If empty Stop and go Left
            //    new Transition(){From = 2, Input = TuringMachine.Fai, To = 3, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},

            //    // If Still empty, go to final
            //    new Transition(){From = 3, Input = TuringMachine.Fai, To = 8, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Stop},

            //    // Remove a from the end
            //    new Transition(){From = 3, Input = 'a', To = 4, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},

            //    // Go to most Left
            //    new Transition(){From = 4, Input = 'a', To = 4, Output = "a", Cursor = TuringMachine.Left},
            //    new Transition(){From = 4, Input = 'b', To = 4, Output = "b", Cursor = TuringMachine.Left},

            //    // If Empty Stop and go Right
            //    new Transition(){From = 4, Input = TuringMachine.Fai, To = 1, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},

            //    // Remove b from start
            //    new Transition(){From = 1, Input = 'b', To = 5, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},

            //    // Continue to most right
            //    new Transition(){From = 5, Input = 'a', To = 5, Output = "a", Cursor = TuringMachine.Right},
            //    new Transition(){From = 5, Input = 'b', To = 5, Output = "b", Cursor = TuringMachine.Right},

            //    // If empty Stop and go Left
            //    new Transition(){From = 5, Input = TuringMachine.Fai, To = 6, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},

            //    // If Still empty, go to final
            //    new Transition(){From = 6, Input = TuringMachine.Fai, To = 8, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Stop},

            //    // Remove b from the end
            //    new Transition(){From = 6, Input = 'b', To = 7, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},

            //    // Go to most Left
            //    new Transition(){From = 7, Input = 'a', To = 7, Output = "a", Cursor = TuringMachine.Left},
            //    new Transition(){From = 7, Input = 'b', To = 7, Output = "b", Cursor = TuringMachine.Left},

            //    // If Empty Stop and go Right
            //    new Transition(){From = 7, Input = TuringMachine.Fai, To = 1, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},
            //});
            //this.btnGo_Click(null, null);
            //this.txtInput.Text = "abbba";
            //this.btnSolve_Click(null, null);

            //// Test Case _ Level 1 _ Recognizers _  a(b power 2n)
            //this.txtStates.Text = "1,2,3,4";
            //this.txtTapeAlphabet.Text = "a,b";
            //this.txtInputAlphabet.Text = "a,b";
            //btnValidate_Click(null, null);
            //this.clbFinalStates.SetItemChecked(0, false);
            //this.clbFinalStates.SetItemChecked(3, true);
            //this.TM.Trans.AddRange(
            //    new List<Transition>() {
            //    new Transition(){From = 1, Input = 'a', To = 2, Output = "a", Cursor = TuringMachine.Right},

            //    new Transition(){From = 2, Input = 'b', To = 3, Output = "b", Cursor = TuringMachine.Right},

            //    new Transition(){From = 3, Input = 'b', To = 2, Output = "b", Cursor = TuringMachine.Right},

            //    new Transition(){From = 2, Input = TuringMachine.Fai, To = 4, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Stop},
            //});
            //this.btnGo_Click(null, null);

            //// Test Case _ Level 1 _  Recognizers _ Accept odd Binary numbers
            //this.txtStates.Text = "1,2,3";
            //this.txtTapeAlphabet.Text = "1,0";
            //this.txtInputAlphabet.Text = "1,0";
            //btnValidate_Click(null, null);
            //this.clbFinalStates.SetItemChecked(0, false);
            //this.clbFinalStates.SetItemChecked(2, true);
            //this.TM.Trans.AddRange(
            //    new List<Transition>() {
            //    new Transition(){From = 1, Input = '1', To = 1, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 1, Input = '0', To = 1, Output = "0", Cursor = TuringMachine.Right},

            //    new Transition(){From = 1, Input = TuringMachine.Fai, To = 2, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},

            //    new Transition(){From = 2, Input = '1', To = 3, Output = "1", Cursor = TuringMachine.Stop},
            //});
            //this.btnGo_Click(null, null);

            //// Test Case _ Level 1 _ Transducers _ 1's Complement
            //this.txtStates.Text = "1,2,3";
            //this.txtTapeAlphabet.Text = "1,0";
            //this.txtInputAlphabet.Text = "1,0";
            //btnValidate_Click(null, null);
            //this.clbFinalStates.SetItemChecked(0, false);
            //this.clbFinalStates.SetItemChecked(2, true);
            //this.TM.Trans.AddRange(
            //    new List<Transition>() {
            //    new Transition(){From = 1, Input = '1', To = 2, Output = "0", Cursor = TuringMachine.Right},

            //    new Transition(){From = 1, Input = TuringMachine.Fai, To = 3, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Stop},

            //    new Transition(){From = 2, Input = '1', To = 2, Output = "0", Cursor = TuringMachine.Right},

            //    new Transition(){From = 2, Input = '0', To = 2, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 2, Input = TuringMachine.Fai, To = 3, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},
            //});
            //this.btnGo_Click(null, null);

            //// Test Case _ Level 1 _ Transducers _ Add one to binary
            //this.txtStates.Text = "1,2,3,4";
            //this.txtTapeAlphabet.Text = "1,0";
            //this.txtInputAlphabet.Text = "1,0";
            //btnValidate_Click(null, null);
            //this.clbFinalStates.SetItemChecked(0, false);
            //this.clbFinalStates.SetItemChecked(3, true);
            //this.TM.Trans.AddRange(
            //    new List<Transition>() {
            //    new Transition(){From = 1, Input = '1', To = 1, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 1, Input = '0', To = 1, Output = "0", Cursor = TuringMachine.Right},

            //    new Transition(){From = 1, Input = TuringMachine.Fai, To = 2, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},

            //    new Transition(){From = 2, Input = '1', To = 2, Output = "0", Cursor = TuringMachine.Left},

            //    new Transition(){From = 2, Input = '0', To = 3, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 2, Input = TuringMachine.Fai, To = 3, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 3, Input = '0', To = 3, Output = "0", Cursor = TuringMachine.Right},

            //    new Transition(){From = 3, Input = '1', To = 3, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 3, Input = TuringMachine.Fai, To = 4, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},
            //});
            //this.btnGo_Click(null, null);

            //// Test Case _ Level 1 _ Transducers _ Unary Adder
            //// Starting state from 0 :: new :)
            //this.txtStates.Text = "0,1,2,3";
            //this.txtTapeAlphabet.Text = "1,+";
            //this.txtInputAlphabet.Text = "1,+";
            //btnValidate_Click(null, null);
            //this.clbFinalStates.SetItemChecked(0, false);
            //this.clbFinalStates.SetItemChecked(3, true);
            //this.TM.Trans.AddRange(
            //    new List<Transition>() {
            //    new Transition(){From = 0, Input = '1', To = 0, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 0, Input = '+', To = 1, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 1, Input = '1', To = 1, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 1, Input = TuringMachine.Fai, To = 2, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},

            //    new Transition(){From = 2, Input = '1', To = 3, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Stop},
            //});
            //this.btnGo_Click(null, null);

            //// Test Case _ Add 3 to Unary
            //// Starting state from 0 :: new :)
            //this.txtStates.Text = "0,1,2,3,4";
            //this.txtTapeAlphabet.Text = "1";
            //this.txtInputAlphabet.Text = "1";
            //btnValidate_Click(null, null);
            //this.clbFinalStates.SetItemChecked(0, false);
            //this.clbFinalStates.SetItemChecked(4, true);
            //this.TM.Trans.AddRange(
            //    new List<Transition>() {
            //    new Transition(){From = 0, Input = TuringMachine.Fai, To = 1, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Stop},

            //    new Transition(){From = 0, Input = '1', To = 1, Output = "1", Cursor = TuringMachine.Left},

            //    new Transition(){From = 1, Input = TuringMachine.Fai, To = 2, Output = "1", Cursor = TuringMachine.Left},

            //    new Transition(){From = 2, Input = TuringMachine.Fai, To = 3, Output = "1", Cursor = TuringMachine.Left},

            //    new Transition(){From = 3, Input = TuringMachine.Fai, To = 4, Output = "1", Cursor = TuringMachine.Stop},
            //});
            //this.btnGo_Click(null, null);

            //// Test Case _ Level 2 _ Transducers _ Unary Numbers Multiplication
            //this.txtStates.Text = "0,1,2,3,4,5,6,7,8,9";
            //this.txtTapeAlphabet.Text = "1,y,*,#";
            //this.txtInputAlphabet.Text = "1,y,*,#";
            //btnValidate_Click(null, null);
            //this.clbFinalStates.SetItemChecked(0, false);
            //this.clbFinalStates.SetItemChecked(9, true);
            //this.TM.Trans.AddRange(
            //    new List<Transition>() {
            //    new Transition(){From = 0, Input = '1', To = 0, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 0, Input = '#', To = 0, Output = "#", Cursor = TuringMachine.Right},

            //    new Transition(){From = 0, Input = TuringMachine.Fai, To = 1, Output = "*", Cursor = TuringMachine.Left},

            //    new Transition(){From = 1, Input = '1', To = 1, Output = "1", Cursor = TuringMachine.Left},

            //    new Transition(){From = 1, Input = '#', To = 1, Output = "#", Cursor = TuringMachine.Left},

            //    new Transition(){From = 1, Input = TuringMachine.Fai, To = 2, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},

            //    new Transition(){From = 2, Input = '1', To = 3, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},

            //    new Transition(){From = 2, Input = '#', To = 8, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},

            //    new Transition(){From = 3, Input = '1', To = 3, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 3, Input = '#', To = 4, Output = "#", Cursor = TuringMachine.Right},

            //    new Transition(){From = 4, Input = 'y', To = 4, Output = "y", Cursor = TuringMachine.Right},

            //    new Transition(){From = 4, Input = '1', To = 5, Output = "y", Cursor = TuringMachine.Right},

            //    new Transition(){From = 4, Input = '*', To = 7, Output = "*", Cursor = TuringMachine.Left},

            //    new Transition(){From = 5, Input = '1', To = 5, Output = "1", Cursor = TuringMachine.Right},

            //    new Transition(){From = 5, Input = '*', To = 5, Output = "*", Cursor = TuringMachine.Right},

            //    new Transition(){From = 5, Input = TuringMachine.Fai, To = 6, Output = "1", Cursor = TuringMachine.Left},

            //    new Transition(){From = 6, Input = '1', To = 6, Output = "1", Cursor = TuringMachine.Left},

            //    new Transition(){From = 6, Input = '*', To = 6, Output = "*", Cursor = TuringMachine.Left},

            //    new Transition(){From = 6, Input = 'y', To = 4, Output = "y", Cursor = TuringMachine.Right},

            //    new Transition(){From = 7, Input = 'y', To = 7, Output = "1", Cursor = TuringMachine.Left},

            //    new Transition(){From = 7, Input = '1', To = 7, Output = "1", Cursor = TuringMachine.Left},

            //    new Transition(){From = 7, Input = '#', To = 7, Output = "#", Cursor = TuringMachine.Left},

            //    new Transition(){From = 7, Input = TuringMachine.Fai, To = 2, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},

            //    new Transition(){From = 8, Input = '1', To = 8, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},

            //    new Transition(){From = 8, Input = '*', To = 9, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Right},
            //});
            //this.btnGo_Click(null, null);

            // Test Case _ Level 2 _ Transducers _ Unary to Binary
            this.txtStates.Text = "0,1,2,3,4,5,6,7,8";
            this.txtTapeAlphabet.Text = "1,0,y,#";
            this.txtInputAlphabet.Text = "1,0,y,#";
            btnValidate_Click(null, null);
            this.clbFinalStates.SetItemChecked(0, false);
            this.clbFinalStates.SetItemChecked(1, true);
            this.TM.Trans.AddRange(
                new List<Transition>() {
                new Transition(){From = 0, Input = TuringMachine.Fai, To = 1, Output = "0", Cursor = TuringMachine.Stop},

                new Transition(){From = 0, Input = '1', To = 2, Output = "y", Cursor = TuringMachine.Left},

                new Transition(){From = 2, Input = TuringMachine.Fai, To = 3, Output = "#", Cursor = TuringMachine.Left},

                new Transition(){From = 3, Input = TuringMachine.Fai, To = 4, Output = "1", Cursor = TuringMachine.Right},

                new Transition(){From = 4, Input = '0', To = 4, Output = "0", Cursor = TuringMachine.Right},

                new Transition(){From = 4, Input = '1', To = 4, Output = "1", Cursor = TuringMachine.Right},

                new Transition(){From = 4, Input = '#', To = 5, Output = "#", Cursor = TuringMachine.Right},

                new Transition(){From = 5, Input = 'y', To = 5, Output = "y", Cursor = TuringMachine.Right},

                new Transition(){From = 5, Input = '1', To = 6, Output = "y", Cursor = TuringMachine.Left},

                new Transition(){From = 5, Input = TuringMachine.Fai, To = 8, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},

                new Transition(){From = 6, Input = 'y', To = 6, Output = "y", Cursor = TuringMachine.Left},

                new Transition(){From = 6, Input = '#', To = 7, Output = "#", Cursor = TuringMachine.Left},

                new Transition(){From = 7, Input = '1', To = 7, Output = "0", Cursor = TuringMachine.Left},

                new Transition(){From = 7, Input = '0', To = 4, Output = "1", Cursor = TuringMachine.Right},

                new Transition(){From = 7, Input = TuringMachine.Fai, To = 4, Output = "1", Cursor = TuringMachine.Right},

                new Transition(){From = 8, Input = 'y', To = 8, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},

                new Transition(){From = 8, Input = '#', To = 1, Output = TuringMachine.Fai.ToString(), Cursor = TuringMachine.Left},
            });
            this.btnGo_Click(null, null);
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
            // Set the input in the TuringMachine
            this.TM.Input = this.txtInput.Text;

            if (this.txtInput.TextLength == 0)
            {
                this.txtInput.Text = TuringMachine.Fai.ToString();
            }

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