namespace Theory_Task1
{
    partial class CopyOfTheoryTask1
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
            this.cbStartState = new System.Windows.Forms.ComboBox();
            this.lvStates = new System.Windows.Forms.ListView();
            this.chFromState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFromInput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chToState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chToOutput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chToCursor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGo = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblDataInputInfo = new System.Windows.Forms.Label();
            this.lblFinalStates = new System.Windows.Forms.Label();
            this.lblStartState = new System.Windows.Forms.Label();
            this.lblAlphabet = new System.Windows.Forms.Label();
            this.lblStates = new System.Windows.Forms.Label();
            this.lblSigma_f = new System.Windows.Forms.Label();
            this.lblSigma_t = new System.Windows.Forms.Label();
            this.cb_t_s = new System.Windows.Forms.ComboBox();
            this.cb_f_s = new System.Windows.Forms.ComboBox();
            this.lbl_f_end = new System.Windows.Forms.Label();
            this.txtTapeAlphabet = new System.Windows.Forms.TextBox();
            this.txtStates = new System.Windows.Forms.TextBox();
            this.lblComma_t_2 = new System.Windows.Forms.Label();
            this.cb_t_c = new System.Windows.Forms.ComboBox();
            this.lblComma_t_1 = new System.Windows.Forms.Label();
            this.lbl_t_end = new System.Windows.Forms.Label();
            this.lblComma_f = new System.Windows.Forms.Label();
            this.cb_t_o = new System.Windows.Forms.ComboBox();
            this.cb_f_i = new System.Windows.Forms.ComboBox();
            this.lblGoesTo = new System.Windows.Forms.Label();
            this.txtInputAlphabet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clbFinalStates
            // 
            this.clbFinalStates.FormattingEnabled = true;
            this.clbFinalStates.Location = new System.Drawing.Point(228, 162);
            this.clbFinalStates.Name = "clbFinalStates";
            this.clbFinalStates.Size = new System.Drawing.Size(58, 79);
            this.clbFinalStates.TabIndex = 62;
            this.clbFinalStates.TabStop = false;
            // 
            // cbStartState
            // 
            this.cbStartState.FormattingEnabled = true;
            this.cbStartState.Location = new System.Drawing.Point(78, 162);
            this.cbStartState.Name = "cbStartState";
            this.cbStartState.Size = new System.Drawing.Size(51, 21);
            this.cbStartState.TabIndex = 61;
            this.cbStartState.TabStop = false;
            // 
            // lvStates
            // 
            this.lvStates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFromState,
            this.chFromInput,
            this.chToState,
            this.chToOutput,
            this.chToCursor});
            this.lvStates.Location = new System.Drawing.Point(14, 248);
            this.lvStates.Name = "lvStates";
            this.lvStates.Size = new System.Drawing.Size(381, 135);
            this.lvStates.TabIndex = 60;
            this.lvStates.TabStop = false;
            this.lvStates.UseCompatibleStateImageBehavior = false;
            this.lvStates.View = System.Windows.Forms.View.Details;
            // 
            // chFromState
            // 
            this.chFromState.Text = "From State";
            this.chFromState.Width = 75;
            // 
            // chFromInput
            // 
            this.chFromInput.Text = "From Input";
            this.chFromInput.Width = 79;
            // 
            // chToState
            // 
            this.chToState.Text = "To State";
            // 
            // chToOutput
            // 
            this.chToOutput.Text = "To Ouput";
            // 
            // chToCursor
            // 
            this.chToCursor.Text = "Cursor";
            this.chToCursor.Width = 50;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(323, 197);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(69, 45);
            this.btnGo.TabIndex = 59;
            this.btnGo.TabStop = false;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(14, 196);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(69, 45);
            this.btnInfo.TabIndex = 57;
            this.btnInfo.TabStop = false;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.Location = new System.Drawing.Point(332, 26);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(69, 45);
            this.btnValidate.TabIndex = 58;
            this.btnValidate.TabStop = false;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(323, 146);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(69, 45);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // lblDataInputInfo
            // 
            this.lblDataInputInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataInputInfo.AutoSize = true;
            this.lblDataInputInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInputInfo.Location = new System.Drawing.Point(144, 88);
            this.lblDataInputInfo.Name = "lblDataInputInfo";
            this.lblDataInputInfo.Size = new System.Drawing.Size(101, 12);
            this.lblDataInputInfo.TabIndex = 47;
            this.lblDataInputInfo.Text = "Separate by commas \',\'";
            // 
            // lblFinalStates
            // 
            this.lblFinalStates.AutoSize = true;
            this.lblFinalStates.Location = new System.Drawing.Point(151, 166);
            this.lblFinalStates.Name = "lblFinalStates";
            this.lblFinalStates.Size = new System.Drawing.Size(71, 13);
            this.lblFinalStates.TabIndex = 48;
            this.lblFinalStates.Text = "Final States : ";
            // 
            // lblStartState
            // 
            this.lblStartState.AutoSize = true;
            this.lblStartState.Location = new System.Drawing.Point(11, 166);
            this.lblStartState.Name = "lblStartState";
            this.lblStartState.Size = new System.Drawing.Size(66, 13);
            this.lblStartState.TabIndex = 45;
            this.lblStartState.Text = "Start State : ";
            // 
            // lblAlphabet
            // 
            this.lblAlphabet.AutoSize = true;
            this.lblAlphabet.Location = new System.Drawing.Point(14, 42);
            this.lblAlphabet.Name = "lblAlphabet";
            this.lblAlphabet.Size = new System.Drawing.Size(101, 13);
            this.lblAlphabet.TabIndex = 38;
            this.lblAlphabet.Text = "Tape Alphabet (Γ) : ";
            // 
            // lblStates
            // 
            this.lblStates.AutoSize = true;
            this.lblStates.Location = new System.Drawing.Point(14, 17);
            this.lblStates.Name = "lblStates";
            this.lblStates.Size = new System.Drawing.Size(62, 13);
            this.lblStates.TabIndex = 39;
            this.lblStates.Text = "States (σ) : ";
            // 
            // lblSigma_f
            // 
            this.lblSigma_f.AutoSize = true;
            this.lblSigma_f.Location = new System.Drawing.Point(14, 123);
            this.lblSigma_f.Name = "lblSigma_f";
            this.lblSigma_f.Size = new System.Drawing.Size(20, 13);
            this.lblSigma_f.TabIndex = 36;
            this.lblSigma_f.Text = "σ (";
            // 
            // lblSigma_t
            // 
            this.lblSigma_t.AutoSize = true;
            this.lblSigma_t.Location = new System.Drawing.Point(191, 123);
            this.lblSigma_t.Name = "lblSigma_t";
            this.lblSigma_t.Size = new System.Drawing.Size(20, 13);
            this.lblSigma_t.TabIndex = 46;
            this.lblSigma_t.Text = "σ (";
            // 
            // cb_t_s
            // 
            this.cb_t_s.FormattingEnabled = true;
            this.cb_t_s.Location = new System.Drawing.Point(217, 119);
            this.cb_t_s.Name = "cb_t_s";
            this.cb_t_s.Size = new System.Drawing.Size(37, 21);
            this.cb_t_s.TabIndex = 2;
            // 
            // cb_f_s
            // 
            this.cb_f_s.FormattingEnabled = true;
            this.cb_f_s.Location = new System.Drawing.Point(40, 120);
            this.cb_f_s.Name = "cb_f_s";
            this.cb_f_s.Size = new System.Drawing.Size(37, 21);
            this.cb_f_s.TabIndex = 0;
            // 
            // lbl_f_end
            // 
            this.lbl_f_end.AutoSize = true;
            this.lbl_f_end.Location = new System.Drawing.Point(143, 124);
            this.lbl_f_end.Name = "lbl_f_end";
            this.lbl_f_end.Size = new System.Drawing.Size(10, 13);
            this.lbl_f_end.TabIndex = 40;
            this.lbl_f_end.Text = ")";
            // 
            // txtTapeAlphabet
            // 
            this.txtTapeAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTapeAlphabet.Location = new System.Drawing.Point(121, 39);
            this.txtTapeAlphabet.Name = "txtTapeAlphabet";
            this.txtTapeAlphabet.Size = new System.Drawing.Size(149, 20);
            this.txtTapeAlphabet.TabIndex = 49;
            this.txtTapeAlphabet.TabStop = false;
            // 
            // txtStates
            // 
            this.txtStates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStates.Location = new System.Drawing.Point(121, 14);
            this.txtStates.Name = "txtStates";
            this.txtStates.Size = new System.Drawing.Size(149, 20);
            this.txtStates.TabIndex = 50;
            this.txtStates.TabStop = false;
            // 
            // lblComma_t_2
            // 
            this.lblComma_t_2.AutoSize = true;
            this.lblComma_t_2.Location = new System.Drawing.Point(322, 123);
            this.lblComma_t_2.Name = "lblComma_t_2";
            this.lblComma_t_2.Size = new System.Drawing.Size(13, 13);
            this.lblComma_t_2.TabIndex = 43;
            this.lblComma_t_2.Text = ", ";
            // 
            // cb_t_c
            // 
            this.cb_t_c.FormattingEnabled = true;
            this.cb_t_c.Location = new System.Drawing.Point(341, 119);
            this.cb_t_c.Name = "cb_t_c";
            this.cb_t_c.Size = new System.Drawing.Size(37, 21);
            this.cb_t_c.TabIndex = 4;
            // 
            // lblComma_t_1
            // 
            this.lblComma_t_1.AutoSize = true;
            this.lblComma_t_1.Location = new System.Drawing.Point(260, 123);
            this.lblComma_t_1.Name = "lblComma_t_1";
            this.lblComma_t_1.Size = new System.Drawing.Size(13, 13);
            this.lblComma_t_1.TabIndex = 44;
            this.lblComma_t_1.Text = ", ";
            // 
            // lbl_t_end
            // 
            this.lbl_t_end.AutoSize = true;
            this.lbl_t_end.Location = new System.Drawing.Point(385, 122);
            this.lbl_t_end.Name = "lbl_t_end";
            this.lbl_t_end.Size = new System.Drawing.Size(10, 13);
            this.lbl_t_end.TabIndex = 41;
            this.lbl_t_end.Text = ")";
            // 
            // lblComma_f
            // 
            this.lblComma_f.AutoSize = true;
            this.lblComma_f.Location = new System.Drawing.Point(83, 123);
            this.lblComma_f.Name = "lblComma_f";
            this.lblComma_f.Size = new System.Drawing.Size(13, 13);
            this.lblComma_f.TabIndex = 42;
            this.lblComma_f.Text = ", ";
            // 
            // cb_t_o
            // 
            this.cb_t_o.FormattingEnabled = true;
            this.cb_t_o.Location = new System.Drawing.Point(279, 120);
            this.cb_t_o.Name = "cb_t_o";
            this.cb_t_o.Size = new System.Drawing.Size(37, 21);
            this.cb_t_o.TabIndex = 3;
            // 
            // cb_f_i
            // 
            this.cb_f_i.FormattingEnabled = true;
            this.cb_f_i.Location = new System.Drawing.Point(100, 120);
            this.cb_f_i.Name = "cb_f_i";
            this.cb_f_i.Size = new System.Drawing.Size(37, 21);
            this.cb_f_i.TabIndex = 1;
            // 
            // lblGoesTo
            // 
            this.lblGoesTo.AutoSize = true;
            this.lblGoesTo.Location = new System.Drawing.Point(159, 124);
            this.lblGoesTo.Name = "lblGoesTo";
            this.lblGoesTo.Size = new System.Drawing.Size(28, 13);
            this.lblGoesTo.TabIndex = 2;
            this.lblGoesTo.Text = " ==>";
            // 
            // txtInputAlphabet
            // 
            this.txtInputAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputAlphabet.Location = new System.Drawing.Point(121, 65);
            this.txtInputAlphabet.Name = "txtInputAlphabet";
            this.txtInputAlphabet.Size = new System.Drawing.Size(149, 20);
            this.txtInputAlphabet.TabIndex = 49;
            this.txtInputAlphabet.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Input Alphabet (Σ) : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "ex: 1,2,3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "ex: a,b,c";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "ex: b,c";
            // 
            // CopyOfTheoryTask1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 397);
            this.Controls.Add(this.clbFinalStates);
            this.Controls.Add(this.cbStartState);
            this.Controls.Add(this.lvStates);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblDataInputInfo);
            this.Controls.Add(this.lblFinalStates);
            this.Controls.Add(this.lblStartState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAlphabet);
            this.Controls.Add(this.lblStates);
            this.Controls.Add(this.lblSigma_f);
            this.Controls.Add(this.lblSigma_t);
            this.Controls.Add(this.cb_t_s);
            this.Controls.Add(this.cb_f_s);
            this.Controls.Add(this.lbl_f_end);
            this.Controls.Add(this.txtInputAlphabet);
            this.Controls.Add(this.txtTapeAlphabet);
            this.Controls.Add(this.txtStates);
            this.Controls.Add(this.lblComma_t_2);
            this.Controls.Add(this.cb_t_c);
            this.Controls.Add(this.lblComma_t_1);
            this.Controls.Add(this.lbl_t_end);
            this.Controls.Add(this.lblComma_f);
            this.Controls.Add(this.cb_t_o);
            this.Controls.Add(this.cb_f_i);
            this.Controls.Add(this.lblGoesTo);
            this.Name = "CopyOfTheoryTask1";
            this.Text = "Theory Task 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbFinalStates;
        private System.Windows.Forms.ComboBox cbStartState;
        private System.Windows.Forms.ListView lvStates;
        private System.Windows.Forms.ColumnHeader chFromState;
        private System.Windows.Forms.ColumnHeader chFromInput;
        private System.Windows.Forms.ColumnHeader chToState;
        private System.Windows.Forms.ColumnHeader chToOutput;
        private System.Windows.Forms.ColumnHeader chToCursor;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblDataInputInfo;
        private System.Windows.Forms.Label lblFinalStates;
        private System.Windows.Forms.Label lblStartState;
        private System.Windows.Forms.Label lblAlphabet;
        private System.Windows.Forms.Label lblStates;
        private System.Windows.Forms.Label lblSigma_f;
        private System.Windows.Forms.Label lblSigma_t;
        private System.Windows.Forms.ComboBox cb_t_s;
        private System.Windows.Forms.ComboBox cb_f_s;
        private System.Windows.Forms.Label lbl_f_end;
        private System.Windows.Forms.TextBox txtTapeAlphabet;
        private System.Windows.Forms.TextBox txtStates;
        private System.Windows.Forms.Label lblComma_t_2;
        private System.Windows.Forms.ComboBox cb_t_c;
        private System.Windows.Forms.Label lblComma_t_1;
        private System.Windows.Forms.Label lbl_t_end;
        private System.Windows.Forms.Label lblComma_f;
        private System.Windows.Forms.ComboBox cb_t_o;
        private System.Windows.Forms.ComboBox cb_f_i;
        private System.Windows.Forms.Label lblGoesTo;
        private System.Windows.Forms.TextBox txtInputAlphabet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

    }
}

