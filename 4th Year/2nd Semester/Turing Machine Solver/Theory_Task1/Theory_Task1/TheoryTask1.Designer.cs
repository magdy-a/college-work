namespace Theory_Task1
{
    partial class TheoryTask1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clbFinalStates = new System.Windows.Forms.CheckedListBox();
            this.cmbStartState = new System.Windows.Forms.ComboBox();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblDataInputInfo = new System.Windows.Forms.Label();
            this.lblFinalStates = new System.Windows.Forms.Label();
            this.lblStartState = new System.Windows.Forms.Label();
            this.lblInputAlphabet = new System.Windows.Forms.Label();
            this.lblInputAlphabet_ex = new System.Windows.Forms.Label();
            this.lblTapeAlphabet_ex = new System.Windows.Forms.Label();
            this.lblStates_ex = new System.Windows.Forms.Label();
            this.lblTapeAlphabet = new System.Windows.Forms.Label();
            this.lblStates = new System.Windows.Forms.Label();
            this.lblSigma_f = new System.Windows.Forms.Label();
            this.lblSigma_t = new System.Windows.Forms.Label();
            this.cmb_t_s = new System.Windows.Forms.ComboBox();
            this.cmb_f_s = new System.Windows.Forms.ComboBox();
            this.lbl_f_end = new System.Windows.Forms.Label();
            this.txtInputAlphabet = new System.Windows.Forms.TextBox();
            this.txtTapeAlphabet = new System.Windows.Forms.TextBox();
            this.txtStates = new System.Windows.Forms.TextBox();
            this.lblComma_t_2 = new System.Windows.Forms.Label();
            this.cmb_t_c = new System.Windows.Forms.ComboBox();
            this.lblComma_t_1 = new System.Windows.Forms.Label();
            this.lbl_t_end = new System.Windows.Forms.Label();
            this.lblComma_f = new System.Windows.Forms.Label();
            this.cmb_f_i = new System.Windows.Forms.ComboBox();
            this.lblGoesTo = new System.Windows.Forms.Label();
            this.pnlAlphabet = new System.Windows.Forms.Panel();
            this.pnlTransition = new System.Windows.Forms.Panel();
            this.btnEmpty = new System.Windows.Forms.Button();
            this.btnTransitionTable = new System.Windows.Forms.Button();
            this.txt_t_o = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblNumOfTransitions = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblAccepted = new System.Windows.Forms.Label();
            this.btnSolve = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.pnlAlphabet.SuspendLayout();
            this.pnlTransition.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbFinalStates
            // 
            this.clbFinalStates.FormattingEnabled = true;
            this.clbFinalStates.Location = new System.Drawing.Point(234, 78);
            this.clbFinalStates.Name = "clbFinalStates";
            this.clbFinalStates.Size = new System.Drawing.Size(58, 64);
            this.clbFinalStates.TabIndex = 6;
            this.clbFinalStates.TabStop = false;
            // 
            // cmbStartState
            // 
            this.cmbStartState.FormattingEnabled = true;
            this.cmbStartState.Location = new System.Drawing.Point(84, 78);
            this.cmbStartState.Name = "cmbStartState";
            this.cmbStartState.Size = new System.Drawing.Size(51, 21);
            this.cmbStartState.TabIndex = 5;
            this.cmbStartState.TabStop = false;
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(6, 112);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 45);
            this.btnInfo.TabIndex = 89;
            this.btnInfo.TabStop = false;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(352, 84);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(53, 73);
            this.btnValidate.TabIndex = 3;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Location = new System.Drawing.Point(352, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(53, 73);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblDataInputInfo
            // 
            this.lblDataInputInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataInputInfo.AutoSize = true;
            this.lblDataInputInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInputInfo.Location = new System.Drawing.Point(171, 81);
            this.lblDataInputInfo.Name = "lblDataInputInfo";
            this.lblDataInputInfo.Size = new System.Drawing.Size(101, 12);
            this.lblDataInputInfo.TabIndex = 84;
            this.lblDataInputInfo.Text = "Separate by commas \',\'";
            // 
            // lblFinalStates
            // 
            this.lblFinalStates.AutoSize = true;
            this.lblFinalStates.Location = new System.Drawing.Point(157, 82);
            this.lblFinalStates.Name = "lblFinalStates";
            this.lblFinalStates.Size = new System.Drawing.Size(71, 13);
            this.lblFinalStates.TabIndex = 85;
            this.lblFinalStates.Text = "Final States : ";
            // 
            // lblStartState
            // 
            this.lblStartState.AutoSize = true;
            this.lblStartState.Location = new System.Drawing.Point(17, 82);
            this.lblStartState.Name = "lblStartState";
            this.lblStartState.Size = new System.Drawing.Size(66, 13);
            this.lblStartState.TabIndex = 82;
            this.lblStartState.Text = "Start State : ";
            // 
            // lblInputAlphabet
            // 
            this.lblInputAlphabet.AutoSize = true;
            this.lblInputAlphabet.Location = new System.Drawing.Point(3, 61);
            this.lblInputAlphabet.Name = "lblInputAlphabet";
            this.lblInputAlphabet.Size = new System.Drawing.Size(101, 13);
            this.lblInputAlphabet.TabIndex = 75;
            this.lblInputAlphabet.Text = "Input Alphabet (Σ) : ";
            // 
            // lblInputAlphabet_ex
            // 
            this.lblInputAlphabet_ex.AutoSize = true;
            this.lblInputAlphabet_ex.Location = new System.Drawing.Point(282, 61);
            this.lblInputAlphabet_ex.Name = "lblInputAlphabet_ex";
            this.lblInputAlphabet_ex.Size = new System.Drawing.Size(39, 13);
            this.lblInputAlphabet_ex.TabIndex = 71;
            this.lblInputAlphabet_ex.Text = "ex: b,c";
            // 
            // lblTapeAlphabet_ex
            // 
            this.lblTapeAlphabet_ex.AutoSize = true;
            this.lblTapeAlphabet_ex.Location = new System.Drawing.Point(282, 35);
            this.lblTapeAlphabet_ex.Name = "lblTapeAlphabet_ex";
            this.lblTapeAlphabet_ex.Size = new System.Drawing.Size(48, 13);
            this.lblTapeAlphabet_ex.TabIndex = 72;
            this.lblTapeAlphabet_ex.Text = "ex: a,b,c";
            // 
            // lblStates_ex
            // 
            this.lblStates_ex.AutoSize = true;
            this.lblStates_ex.Location = new System.Drawing.Point(282, 10);
            this.lblStates_ex.Name = "lblStates_ex";
            this.lblStates_ex.Size = new System.Drawing.Size(48, 13);
            this.lblStates_ex.TabIndex = 73;
            this.lblStates_ex.Text = "ex: 1,2,3";
            // 
            // lblTapeAlphabet
            // 
            this.lblTapeAlphabet.AutoSize = true;
            this.lblTapeAlphabet.Location = new System.Drawing.Point(3, 35);
            this.lblTapeAlphabet.Name = "lblTapeAlphabet";
            this.lblTapeAlphabet.Size = new System.Drawing.Size(101, 13);
            this.lblTapeAlphabet.TabIndex = 74;
            this.lblTapeAlphabet.Text = "Tape Alphabet (Γ) : ";
            // 
            // lblStates
            // 
            this.lblStates.AutoSize = true;
            this.lblStates.Location = new System.Drawing.Point(3, 10);
            this.lblStates.Name = "lblStates";
            this.lblStates.Size = new System.Drawing.Size(62, 13);
            this.lblStates.TabIndex = 76;
            this.lblStates.Text = "States (σ) : ";
            // 
            // lblSigma_f
            // 
            this.lblSigma_f.AutoSize = true;
            this.lblSigma_f.Location = new System.Drawing.Point(10, 37);
            this.lblSigma_f.Name = "lblSigma_f";
            this.lblSigma_f.Size = new System.Drawing.Size(20, 13);
            this.lblSigma_f.TabIndex = 70;
            this.lblSigma_f.Text = "σ (";
            // 
            // lblSigma_t
            // 
            this.lblSigma_t.AutoSize = true;
            this.lblSigma_t.Location = new System.Drawing.Point(170, 37);
            this.lblSigma_t.Name = "lblSigma_t";
            this.lblSigma_t.Size = new System.Drawing.Size(20, 13);
            this.lblSigma_t.TabIndex = 83;
            this.lblSigma_t.Text = "σ (";
            // 
            // cmb_t_s
            // 
            this.cmb_t_s.FormattingEnabled = true;
            this.cmb_t_s.Location = new System.Drawing.Point(196, 34);
            this.cmb_t_s.Name = "cmb_t_s";
            this.cmb_t_s.Size = new System.Drawing.Size(28, 21);
            this.cmb_t_s.TabIndex = 2;
            // 
            // cmb_f_s
            // 
            this.cmb_f_s.FormattingEnabled = true;
            this.cmb_f_s.Location = new System.Drawing.Point(36, 34);
            this.cmb_f_s.Name = "cmb_f_s";
            this.cmb_f_s.Size = new System.Drawing.Size(28, 21);
            this.cmb_f_s.TabIndex = 0;
            // 
            // lbl_f_end
            // 
            this.lbl_f_end.AutoSize = true;
            this.lbl_f_end.Location = new System.Drawing.Point(123, 38);
            this.lbl_f_end.Name = "lbl_f_end";
            this.lbl_f_end.Size = new System.Drawing.Size(10, 13);
            this.lbl_f_end.TabIndex = 77;
            this.lbl_f_end.Text = ")";
            // 
            // txtInputAlphabet
            // 
            this.txtInputAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputAlphabet.Location = new System.Drawing.Point(110, 58);
            this.txtInputAlphabet.Name = "txtInputAlphabet";
            this.txtInputAlphabet.Size = new System.Drawing.Size(162, 20);
            this.txtInputAlphabet.TabIndex = 2;
            this.txtInputAlphabet.Text = "a,b,c";
            // 
            // txtTapeAlphabet
            // 
            this.txtTapeAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTapeAlphabet.Location = new System.Drawing.Point(110, 32);
            this.txtTapeAlphabet.Name = "txtTapeAlphabet";
            this.txtTapeAlphabet.Size = new System.Drawing.Size(162, 20);
            this.txtTapeAlphabet.TabIndex = 1;
            this.txtTapeAlphabet.Text = "a,b,c";
            // 
            // txtStates
            // 
            this.txtStates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStates.Location = new System.Drawing.Point(110, 7);
            this.txtStates.Name = "txtStates";
            this.txtStates.Size = new System.Drawing.Size(162, 20);
            this.txtStates.TabIndex = 0;
            this.txtStates.Text = "1,2,3";
            // 
            // lblComma_t_2
            // 
            this.lblComma_t_2.AutoSize = true;
            this.lblComma_t_2.Location = new System.Drawing.Point(279, 37);
            this.lblComma_t_2.Name = "lblComma_t_2";
            this.lblComma_t_2.Size = new System.Drawing.Size(13, 13);
            this.lblComma_t_2.TabIndex = 80;
            this.lblComma_t_2.Text = ", ";
            // 
            // cmb_t_c
            // 
            this.cmb_t_c.FormattingEnabled = true;
            this.cmb_t_c.Location = new System.Drawing.Point(298, 33);
            this.cmb_t_c.Name = "cmb_t_c";
            this.cmb_t_c.Size = new System.Drawing.Size(32, 21);
            this.cmb_t_c.TabIndex = 4;
            // 
            // lblComma_t_1
            // 
            this.lblComma_t_1.AutoSize = true;
            this.lblComma_t_1.Location = new System.Drawing.Point(229, 37);
            this.lblComma_t_1.Name = "lblComma_t_1";
            this.lblComma_t_1.Size = new System.Drawing.Size(13, 13);
            this.lblComma_t_1.TabIndex = 81;
            this.lblComma_t_1.Text = ", ";
            // 
            // lbl_t_end
            // 
            this.lbl_t_end.AutoSize = true;
            this.lbl_t_end.Location = new System.Drawing.Point(332, 37);
            this.lbl_t_end.Name = "lbl_t_end";
            this.lbl_t_end.Size = new System.Drawing.Size(10, 13);
            this.lbl_t_end.TabIndex = 78;
            this.lbl_t_end.Text = ")";
            // 
            // lblComma_f
            // 
            this.lblComma_f.AutoSize = true;
            this.lblComma_f.Location = new System.Drawing.Point(68, 37);
            this.lblComma_f.Name = "lblComma_f";
            this.lblComma_f.Size = new System.Drawing.Size(13, 13);
            this.lblComma_f.TabIndex = 79;
            this.lblComma_f.Text = ", ";
            // 
            // cmb_f_i
            // 
            this.cmb_f_i.FormattingEnabled = true;
            this.cmb_f_i.Location = new System.Drawing.Point(87, 34);
            this.cmb_f_i.Name = "cmb_f_i";
            this.cmb_f_i.Size = new System.Drawing.Size(28, 21);
            this.cmb_f_i.TabIndex = 1;
            // 
            // lblGoesTo
            // 
            this.lblGoesTo.AutoSize = true;
            this.lblGoesTo.Location = new System.Drawing.Point(139, 38);
            this.lblGoesTo.Name = "lblGoesTo";
            this.lblGoesTo.Size = new System.Drawing.Size(25, 13);
            this.lblGoesTo.TabIndex = 6;
            this.lblGoesTo.Text = "==>";
            // 
            // pnlAlphabet
            // 
            this.pnlAlphabet.Controls.Add(this.btnInfo);
            this.pnlAlphabet.Controls.Add(this.txtInputAlphabet);
            this.pnlAlphabet.Controls.Add(this.txtStates);
            this.pnlAlphabet.Controls.Add(this.txtTapeAlphabet);
            this.pnlAlphabet.Controls.Add(this.lblStates);
            this.pnlAlphabet.Controls.Add(this.lblTapeAlphabet);
            this.pnlAlphabet.Controls.Add(this.lblStates_ex);
            this.pnlAlphabet.Controls.Add(this.btnValidate);
            this.pnlAlphabet.Controls.Add(this.lblDataInputInfo);
            this.pnlAlphabet.Controls.Add(this.lblTapeAlphabet_ex);
            this.pnlAlphabet.Controls.Add(this.lblInputAlphabet_ex);
            this.pnlAlphabet.Controls.Add(this.lblInputAlphabet);
            this.pnlAlphabet.Location = new System.Drawing.Point(12, 12);
            this.pnlAlphabet.Name = "pnlAlphabet";
            this.pnlAlphabet.Size = new System.Drawing.Size(408, 160);
            this.pnlAlphabet.TabIndex = 95;
            // 
            // pnlTransition
            // 
            this.pnlTransition.Controls.Add(this.btnEmpty);
            this.pnlTransition.Controls.Add(this.btnTransitionTable);
            this.pnlTransition.Controls.Add(this.txt_t_o);
            this.pnlTransition.Controls.Add(this.btnGo);
            this.pnlTransition.Controls.Add(this.lblGoesTo);
            this.pnlTransition.Controls.Add(this.clbFinalStates);
            this.pnlTransition.Controls.Add(this.cmb_f_i);
            this.pnlTransition.Controls.Add(this.cmbStartState);
            this.pnlTransition.Controls.Add(this.lblComma_f);
            this.pnlTransition.Controls.Add(this.lbl_t_end);
            this.pnlTransition.Controls.Add(this.lblComma_t_1);
            this.pnlTransition.Controls.Add(this.btnNext);
            this.pnlTransition.Controls.Add(this.cmb_t_c);
            this.pnlTransition.Controls.Add(this.lblFinalStates);
            this.pnlTransition.Controls.Add(this.lblComma_t_2);
            this.pnlTransition.Controls.Add(this.lblStartState);
            this.pnlTransition.Controls.Add(this.lbl_f_end);
            this.pnlTransition.Controls.Add(this.lblNumOfTransitions);
            this.pnlTransition.Controls.Add(this.lblSigma_f);
            this.pnlTransition.Controls.Add(this.cmb_f_s);
            this.pnlTransition.Controls.Add(this.lblSigma_t);
            this.pnlTransition.Controls.Add(this.cmb_t_s);
            this.pnlTransition.Location = new System.Drawing.Point(12, 12);
            this.pnlTransition.Name = "pnlTransition";
            this.pnlTransition.Size = new System.Drawing.Size(408, 160);
            this.pnlTransition.TabIndex = 96;
            // 
            // btnEmpty
            // 
            this.btnEmpty.Location = new System.Drawing.Point(234, 12);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(58, 22);
            this.btnEmpty.TabIndex = 87;
            this.btnEmpty.Text = "Space";
            this.btnEmpty.UseVisualStyleBackColor = true;
            this.btnEmpty.Click += new System.EventHandler(this.btnFai_Click);
            // 
            // btnTransitionTable
            // 
            this.btnTransitionTable.BackColor = System.Drawing.Color.Transparent;
            this.btnTransitionTable.Location = new System.Drawing.Point(6, 112);
            this.btnTransitionTable.Name = "btnTransitionTable";
            this.btnTransitionTable.Size = new System.Drawing.Size(75, 45);
            this.btnTransitionTable.TabIndex = 86;
            this.btnTransitionTable.Text = "Transition Table";
            this.btnTransitionTable.UseVisualStyleBackColor = false;
            this.btnTransitionTable.Click += new System.EventHandler(this.btnTransitionTable_Click);
            // 
            // txt_t_o
            // 
            this.txt_t_o.Location = new System.Drawing.Point(248, 34);
            this.txt_t_o.Name = "txt_t_o";
            this.txt_t_o.Size = new System.Drawing.Size(28, 20);
            this.txt_t_o.TabIndex = 3;
            this.txt_t_o.Enter += new System.EventHandler(this.txt_t_o_Enter);
            this.txt_t_o.Leave += new System.EventHandler(this.txt_t_o_Leave);
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.Transparent;
            this.btnGo.Location = new System.Drawing.Point(352, 84);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(53, 73);
            this.btnGo.TabIndex = 1;
            this.btnGo.TabStop = false;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblNumOfTransitions
            // 
            this.lblNumOfTransitions.AutoSize = true;
            this.lblNumOfTransitions.Location = new System.Drawing.Point(87, 141);
            this.lblNumOfTransitions.Name = "lblNumOfTransitions";
            this.lblNumOfTransitions.Size = new System.Drawing.Size(0, 13);
            this.lblNumOfTransitions.TabIndex = 70;
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.lblAccepted);
            this.pnlInput.Controls.Add(this.btnSolve);
            this.pnlInput.Controls.Add(this.lblOutput);
            this.pnlInput.Controls.Add(this.lblInput);
            this.pnlInput.Controls.Add(this.txtOutput);
            this.pnlInput.Controls.Add(this.txtInput);
            this.pnlInput.Location = new System.Drawing.Point(12, 12);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(408, 160);
            this.pnlInput.TabIndex = 87;
            // 
            // lblAccepted
            // 
            this.lblAccepted.AutoSize = true;
            this.lblAccepted.Location = new System.Drawing.Point(332, 99);
            this.lblAccepted.Name = "lblAccepted";
            this.lblAccepted.Size = new System.Drawing.Size(0, 13);
            this.lblAccepted.TabIndex = 3;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(335, 24);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(48, 23);
            this.btnSolve.TabIndex = 2;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(17, 99);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(48, 13);
            this.lblOutput.TabIndex = 1;
            this.lblOutput.Text = "Output : ";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(17, 29);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(40, 13);
            this.lblInput.TabIndex = 1;
            this.lblInput.Text = "Input : ";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(71, 96);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(250, 20);
            this.txtOutput.TabIndex = 0;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(71, 26);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(250, 20);
            this.txtInput.TabIndex = 0;
            // 
            // TheoryTask1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(431, 179);
            this.Controls.Add(this.pnlTransition);
            this.Controls.Add(this.pnlAlphabet);
            this.Controls.Add(this.pnlInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TheoryTask1";
            this.Text = "Theory Task 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlAlphabet.ResumeLayout(false);
            this.pnlAlphabet.PerformLayout();
            this.pnlTransition.ResumeLayout(false);
            this.pnlTransition.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbFinalStates;
        private System.Windows.Forms.ComboBox cmbStartState;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblDataInputInfo;
        private System.Windows.Forms.Label lblFinalStates;
        private System.Windows.Forms.Label lblStartState;
        private System.Windows.Forms.Label lblInputAlphabet;
        private System.Windows.Forms.Label lblInputAlphabet_ex;
        private System.Windows.Forms.Label lblTapeAlphabet_ex;
        private System.Windows.Forms.Label lblStates_ex;
        private System.Windows.Forms.Label lblTapeAlphabet;
        private System.Windows.Forms.Label lblStates;
        private System.Windows.Forms.Label lblSigma_f;
        private System.Windows.Forms.Label lblSigma_t;
        private System.Windows.Forms.ComboBox cmb_t_s;
        private System.Windows.Forms.ComboBox cmb_f_s;
        private System.Windows.Forms.Label lbl_f_end;
        private System.Windows.Forms.TextBox txtInputAlphabet;
        private System.Windows.Forms.TextBox txtTapeAlphabet;
        private System.Windows.Forms.TextBox txtStates;
        private System.Windows.Forms.Label lblComma_t_2;
        private System.Windows.Forms.ComboBox cmb_t_c;
        private System.Windows.Forms.Label lblComma_t_1;
        private System.Windows.Forms.Label lbl_t_end;
        private System.Windows.Forms.Label lblComma_f;
        private System.Windows.Forms.ComboBox cmb_f_i;
        private System.Windows.Forms.Label lblGoesTo;
        private System.Windows.Forms.Panel pnlAlphabet;
        private System.Windows.Forms.Panel pnlTransition;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txt_t_o;
        private System.Windows.Forms.Label lblNumOfTransitions;
        private System.Windows.Forms.Button btnTransitionTable;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblAccepted;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnEmpty;


    }
}

