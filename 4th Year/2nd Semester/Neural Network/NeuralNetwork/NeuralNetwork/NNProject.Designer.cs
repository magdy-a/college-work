namespace NeuralNetwork
{
    partial class NNProject
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
            this.cmbProblem = new System.Windows.Forms.ComboBox();
            this.lblProblem = new System.Windows.Forms.Label();
            this.lblSamplesNum = new System.Windows.Forms.Label();
            this.lblTestingNum = new System.Windows.Forms.Label();
            this.lblEtaRange = new System.Windows.Forms.Label();
            this.lblMinError = new System.Windows.Forms.Label();
            this.lblMaxEpochs = new System.Windows.Forms.Label();
            this.nudMaxEpochs = new System.Windows.Forms.NumericUpDown();
            this.txtMinError = new System.Windows.Forms.TextBox();
            this.txtEtaMin = new System.Windows.Forms.TextBox();
            this.nudTestingNum = new System.Windows.Forms.NumericUpDown();
            this.nudSamplesNum = new System.Windows.Forms.NumericUpDown();
            this.btnOpenSamplesFile = new System.Windows.Forms.Button();
            this.btnOpenResultsFile = new System.Windows.Forms.Button();
            this.txtResultsFile = new System.Windows.Forms.TextBox();
            this.txtSamplesFile = new System.Windows.Forms.TextBox();
            this.txtEtaMax = new System.Windows.Forms.TextBox();
            this.lblColon_1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnTestIndex = new System.Windows.Forms.Button();
            this.txtTestResult = new System.Windows.Forms.TextBox();
            this.lblColon_2 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblCurrentEpochNum = new System.Windows.Forms.Label();
            this.lblCurrentError = new System.Windows.Forms.Label();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.txtCurrentEpochNum = new System.Windows.Forms.TextBox();
            this.txtElapsedTime = new System.Windows.Forms.TextBox();
            this.txtCurrentError = new System.Windows.Forms.TextBox();
            this.nudTestIndex = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nudInputs = new System.Windows.Forms.NumericUpDown();
            this.nudOutputs = new System.Windows.Forms.NumericUpDown();
            this.txtHiddenLayers = new System.Windows.Forms.TextBox();
            this.lblInputs = new System.Windows.Forms.Label();
            this.lblOutputs = new System.Windows.Forms.Label();
            this.lblHiddenLayers = new System.Windows.Forms.Label();
            this.btnChangeArchitecture = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxEpochs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestingNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSamplesNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestIndex)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInputs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputs)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbProblem
            // 
            this.cmbProblem.FormattingEnabled = true;
            this.cmbProblem.Location = new System.Drawing.Point(60, 16);
            this.cmbProblem.Name = "cmbProblem";
            this.cmbProblem.Size = new System.Drawing.Size(124, 21);
            this.cmbProblem.TabIndex = 0;
            this.cmbProblem.SelectedValueChanged += new System.EventHandler(this.cmbProblem_SelectedValueChanged);
            // 
            // lblProblem
            // 
            this.lblProblem.AutoSize = true;
            this.lblProblem.Location = new System.Drawing.Point(9, 19);
            this.lblProblem.Name = "lblProblem";
            this.lblProblem.Size = new System.Drawing.Size(45, 13);
            this.lblProblem.TabIndex = 1;
            this.lblProblem.Text = "Problem";
            // 
            // lblSamplesNum
            // 
            this.lblSamplesNum.AutoSize = true;
            this.lblSamplesNum.Location = new System.Drawing.Point(8, 21);
            this.lblSamplesNum.Name = "lblSamplesNum";
            this.lblSamplesNum.Size = new System.Drawing.Size(25, 13);
            this.lblSamplesNum.TabIndex = 2;
            this.lblSamplesNum.Text = "#All";
            // 
            // lblTestingNum
            // 
            this.lblTestingNum.AutoSize = true;
            this.lblTestingNum.Location = new System.Drawing.Point(8, 44);
            this.lblTestingNum.Name = "lblTestingNum";
            this.lblTestingNum.Size = new System.Drawing.Size(35, 13);
            this.lblTestingNum.TabIndex = 2;
            this.lblTestingNum.Text = "#Test";
            // 
            // lblEtaRange
            // 
            this.lblEtaRange.AutoSize = true;
            this.lblEtaRange.Location = new System.Drawing.Point(8, 23);
            this.lblEtaRange.Name = "lblEtaRange";
            this.lblEtaRange.Size = new System.Drawing.Size(29, 13);
            this.lblEtaRange.TabIndex = 2;
            this.lblEtaRange.Text = "Eta: ";
            // 
            // lblMinError
            // 
            this.lblMinError.AutoSize = true;
            this.lblMinError.Location = new System.Drawing.Point(8, 49);
            this.lblMinError.Name = "lblMinError";
            this.lblMinError.Size = new System.Drawing.Size(55, 13);
            this.lblMinError.TabIndex = 2;
            this.lblMinError.Text = "Min Error: ";
            // 
            // lblMaxEpochs
            // 
            this.lblMaxEpochs.AutoSize = true;
            this.lblMaxEpochs.Location = new System.Drawing.Point(8, 75);
            this.lblMaxEpochs.Name = "lblMaxEpochs";
            this.lblMaxEpochs.Size = new System.Drawing.Size(72, 13);
            this.lblMaxEpochs.TabIndex = 2;
            this.lblMaxEpochs.Text = "Max Epochs: ";
            // 
            // nudMaxEpochs
            // 
            this.nudMaxEpochs.Location = new System.Drawing.Point(88, 73);
            this.nudMaxEpochs.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMaxEpochs.Name = "nudMaxEpochs";
            this.nudMaxEpochs.Size = new System.Drawing.Size(58, 20);
            this.nudMaxEpochs.TabIndex = 3;
            // 
            // txtMinError
            // 
            this.txtMinError.Location = new System.Drawing.Point(88, 46);
            this.txtMinError.Name = "txtMinError";
            this.txtMinError.Size = new System.Drawing.Size(58, 20);
            this.txtMinError.TabIndex = 4;
            // 
            // txtEtaMin
            // 
            this.txtEtaMin.Location = new System.Drawing.Point(59, 19);
            this.txtEtaMin.Name = "txtEtaMin";
            this.txtEtaMin.Size = new System.Drawing.Size(38, 20);
            this.txtEtaMin.TabIndex = 4;
            // 
            // nudTestingNum
            // 
            this.nudTestingNum.Location = new System.Drawing.Point(47, 42);
            this.nudTestingNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTestingNum.Name = "nudTestingNum";
            this.nudTestingNum.Size = new System.Drawing.Size(52, 20);
            this.nudTestingNum.TabIndex = 3;
            // 
            // nudSamplesNum
            // 
            this.nudSamplesNum.Location = new System.Drawing.Point(47, 19);
            this.nudSamplesNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSamplesNum.Name = "nudSamplesNum";
            this.nudSamplesNum.Size = new System.Drawing.Size(52, 20);
            this.nudSamplesNum.TabIndex = 3;
            // 
            // btnOpenSamplesFile
            // 
            this.btnOpenSamplesFile.Location = new System.Drawing.Point(7, 17);
            this.btnOpenSamplesFile.Name = "btnOpenSamplesFile";
            this.btnOpenSamplesFile.Size = new System.Drawing.Size(51, 23);
            this.btnOpenSamplesFile.TabIndex = 5;
            this.btnOpenSamplesFile.Text = "Samples";
            this.btnOpenSamplesFile.UseVisualStyleBackColor = true;
            this.btnOpenSamplesFile.Click += new System.EventHandler(this.btnOpenSamplesFile_Click);
            // 
            // btnOpenResultsFile
            // 
            this.btnOpenResultsFile.Location = new System.Drawing.Point(7, 46);
            this.btnOpenResultsFile.Name = "btnOpenResultsFile";
            this.btnOpenResultsFile.Size = new System.Drawing.Size(51, 23);
            this.btnOpenResultsFile.TabIndex = 5;
            this.btnOpenResultsFile.Text = "Results";
            this.btnOpenResultsFile.UseVisualStyleBackColor = true;
            this.btnOpenResultsFile.Click += new System.EventHandler(this.btnOpenResultsFile_Click);
            // 
            // txtResultsFile
            // 
            this.txtResultsFile.Location = new System.Drawing.Point(64, 48);
            this.txtResultsFile.Name = "txtResultsFile";
            this.txtResultsFile.ReadOnly = true;
            this.txtResultsFile.Size = new System.Drawing.Size(97, 20);
            this.txtResultsFile.TabIndex = 4;
            // 
            // txtSamplesFile
            // 
            this.txtSamplesFile.Location = new System.Drawing.Point(64, 19);
            this.txtSamplesFile.Name = "txtSamplesFile";
            this.txtSamplesFile.ReadOnly = true;
            this.txtSamplesFile.Size = new System.Drawing.Size(97, 20);
            this.txtSamplesFile.TabIndex = 4;
            // 
            // txtEtaMax
            // 
            this.txtEtaMax.Location = new System.Drawing.Point(108, 19);
            this.txtEtaMax.Name = "txtEtaMax";
            this.txtEtaMax.Size = new System.Drawing.Size(38, 20);
            this.txtEtaMax.TabIndex = 4;
            // 
            // lblColon_1
            // 
            this.lblColon_1.AutoSize = true;
            this.lblColon_1.Location = new System.Drawing.Point(100, 23);
            this.lblColon_1.Name = "lblColon_1";
            this.lblColon_1.Size = new System.Drawing.Size(10, 13);
            this.lblColon_1.TabIndex = 6;
            this.lblColon_1.Text = ":";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(15, 19);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(52, 44);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "Train";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnTestIndex
            // 
            this.btnTestIndex.Location = new System.Drawing.Point(8, 19);
            this.btnTestIndex.Name = "btnTestIndex";
            this.btnTestIndex.Size = new System.Drawing.Size(44, 21);
            this.btnTestIndex.TabIndex = 7;
            this.btnTestIndex.Text = "Test Index";
            this.btnTestIndex.UseVisualStyleBackColor = true;
            this.btnTestIndex.Click += new System.EventHandler(this.btnTestIndex_Click);
            // 
            // txtTestResult
            // 
            this.txtTestResult.Enabled = false;
            this.txtTestResult.Location = new System.Drawing.Point(74, 49);
            this.txtTestResult.Name = "txtTestResult";
            this.txtTestResult.ReadOnly = true;
            this.txtTestResult.Size = new System.Drawing.Size(38, 20);
            this.txtTestResult.TabIndex = 4;
            // 
            // lblColon_2
            // 
            this.lblColon_2.AutoSize = true;
            this.lblColon_2.Location = new System.Drawing.Point(57, 23);
            this.lblColon_2.Name = "lblColon_2";
            this.lblColon_2.Size = new System.Drawing.Size(10, 13);
            this.lblColon_2.TabIndex = 6;
            this.lblColon_2.Text = ":";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(73, 19);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(52, 44);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblCurrentEpochNum
            // 
            this.lblCurrentEpochNum.AutoSize = true;
            this.lblCurrentEpochNum.Location = new System.Drawing.Point(128, 46);
            this.lblCurrentEpochNum.Name = "lblCurrentEpochNum";
            this.lblCurrentEpochNum.Size = new System.Drawing.Size(44, 13);
            this.lblCurrentEpochNum.TabIndex = 2;
            this.lblCurrentEpochNum.Text = "Epoch: ";
            // 
            // lblCurrentError
            // 
            this.lblCurrentError.AutoSize = true;
            this.lblCurrentError.Location = new System.Drawing.Point(12, 76);
            this.lblCurrentError.Name = "lblCurrentError";
            this.lblCurrentError.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentError.TabIndex = 2;
            this.lblCurrentError.Text = "Error: ";
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.AutoSize = true;
            this.lblTimeElapsed.Location = new System.Drawing.Point(12, 99);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(36, 13);
            this.lblTimeElapsed.TabIndex = 2;
            this.lblTimeElapsed.Text = "Time: ";
            // 
            // txtCurrentEpochNum
            // 
            this.txtCurrentEpochNum.Location = new System.Drawing.Point(178, 43);
            this.txtCurrentEpochNum.Name = "txtCurrentEpochNum";
            this.txtCurrentEpochNum.ReadOnly = true;
            this.txtCurrentEpochNum.Size = new System.Drawing.Size(52, 20);
            this.txtCurrentEpochNum.TabIndex = 4;
            // 
            // txtElapsedTime
            // 
            this.txtElapsedTime.Location = new System.Drawing.Point(62, 96);
            this.txtElapsedTime.Name = "txtElapsedTime";
            this.txtElapsedTime.ReadOnly = true;
            this.txtElapsedTime.Size = new System.Drawing.Size(168, 20);
            this.txtElapsedTime.TabIndex = 4;
            // 
            // txtCurrentError
            // 
            this.txtCurrentError.Location = new System.Drawing.Point(62, 73);
            this.txtCurrentError.Name = "txtCurrentError";
            this.txtCurrentError.ReadOnly = true;
            this.txtCurrentError.Size = new System.Drawing.Size(168, 20);
            this.txtCurrentError.TabIndex = 4;
            // 
            // nudTestIndex
            // 
            this.nudTestIndex.Location = new System.Drawing.Point(68, 20);
            this.nudTestIndex.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTestIndex.Name = "nudTestIndex";
            this.nudTestIndex.Size = new System.Drawing.Size(44, 20);
            this.nudTestIndex.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblResult);
            this.groupBox1.Controls.Add(this.btnTestIndex);
            this.groupBox1.Controls.Add(this.lblColon_2);
            this.groupBox1.Controls.Add(this.txtTestResult);
            this.groupBox1.Controls.Add(this.nudTestIndex);
            this.groupBox1.Location = new System.Drawing.Point(195, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 76);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Testing Result";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblColon_1);
            this.groupBox2.Controls.Add(this.txtEtaMax);
            this.groupBox2.Controls.Add(this.txtEtaMin);
            this.groupBox2.Controls.Add(this.txtMinError);
            this.groupBox2.Controls.Add(this.nudMaxEpochs);
            this.groupBox2.Controls.Add(this.lblMaxEpochs);
            this.groupBox2.Controls.Add(this.lblMinError);
            this.groupBox2.Controls.Add(this.lblEtaRange);
            this.groupBox2.Location = new System.Drawing.Point(12, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 104);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Learning";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudSamplesNum);
            this.groupBox3.Controls.Add(this.nudTestingNum);
            this.groupBox3.Controls.Add(this.lblTestingNum);
            this.groupBox3.Controls.Add(this.lblSamplesNum);
            this.groupBox3.Location = new System.Drawing.Point(326, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 76);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Samples Numbers";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnOpenResultsFile);
            this.groupBox4.Controls.Add(this.btnOpenSamplesFile);
            this.groupBox4.Controls.Add(this.txtSamplesFile);
            this.groupBox4.Controls.Add(this.txtResultsFile);
            this.groupBox4.Location = new System.Drawing.Point(12, 153);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(172, 76);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Files Paths";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnTest);
            this.groupBox5.Controls.Add(this.btnGo);
            this.groupBox5.Controls.Add(this.txtCurrentError);
            this.groupBox5.Controls.Add(this.txtElapsedTime);
            this.groupBox5.Controls.Add(this.txtCurrentEpochNum);
            this.groupBox5.Controls.Add(this.lblTimeElapsed);
            this.groupBox5.Controls.Add(this.lblCurrentError);
            this.groupBox5.Controls.Add(this.lblCurrentEpochNum);
            this.groupBox5.Location = new System.Drawing.Point(195, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(240, 135);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Main";
            // 
            // nudInputs
            // 
            this.nudInputs.Location = new System.Drawing.Point(54, 19);
            this.nudInputs.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudInputs.Name = "nudInputs";
            this.nudInputs.Size = new System.Drawing.Size(67, 20);
            this.nudInputs.TabIndex = 13;
            // 
            // nudOutputs
            // 
            this.nudOutputs.Location = new System.Drawing.Point(185, 19);
            this.nudOutputs.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudOutputs.Name = "nudOutputs";
            this.nudOutputs.Size = new System.Drawing.Size(67, 20);
            this.nudOutputs.TabIndex = 13;
            // 
            // txtHiddenLayers
            // 
            this.txtHiddenLayers.Location = new System.Drawing.Point(92, 45);
            this.txtHiddenLayers.Name = "txtHiddenLayers";
            this.txtHiddenLayers.Size = new System.Drawing.Size(102, 20);
            this.txtHiddenLayers.TabIndex = 14;
            // 
            // lblInputs
            // 
            this.lblInputs.AutoSize = true;
            this.lblInputs.Location = new System.Drawing.Point(6, 21);
            this.lblInputs.Name = "lblInputs";
            this.lblInputs.Size = new System.Drawing.Size(42, 13);
            this.lblInputs.TabIndex = 15;
            this.lblInputs.Text = "Inputs: ";
            // 
            // lblOutputs
            // 
            this.lblOutputs.AutoSize = true;
            this.lblOutputs.Location = new System.Drawing.Point(129, 21);
            this.lblOutputs.Name = "lblOutputs";
            this.lblOutputs.Size = new System.Drawing.Size(50, 13);
            this.lblOutputs.TabIndex = 16;
            this.lblOutputs.Text = "Outputs: ";
            // 
            // lblHiddenLayers
            // 
            this.lblHiddenLayers.AutoSize = true;
            this.lblHiddenLayers.Location = new System.Drawing.Point(5, 48);
            this.lblHiddenLayers.Name = "lblHiddenLayers";
            this.lblHiddenLayers.Size = new System.Drawing.Size(81, 13);
            this.lblHiddenLayers.TabIndex = 17;
            this.lblHiddenLayers.Text = "Hidden Layers: ";
            // 
            // btnChangeArchitecture
            // 
            this.btnChangeArchitecture.Location = new System.Drawing.Point(258, 17);
            this.btnChangeArchitecture.Name = "btnChangeArchitecture";
            this.btnChangeArchitecture.Size = new System.Drawing.Size(64, 46);
            this.btnChangeArchitecture.TabIndex = 18;
            this.btnChangeArchitecture.Text = "Apply";
            this.btnChangeArchitecture.UseVisualStyleBackColor = true;
            this.btnChangeArchitecture.Click += new System.EventHandler(this.btnChangeArchitecture_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnChangeArchitecture);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.lblHiddenLayers);
            this.groupBox6.Controls.Add(this.lblOutputs);
            this.groupBox6.Controls.Add(this.lblInputs);
            this.groupBox6.Controls.Add(this.txtHiddenLayers);
            this.groupBox6.Controls.Add(this.nudOutputs);
            this.groupBox6.Controls.Add(this.nudInputs);
            this.groupBox6.Location = new System.Drawing.Point(12, 235);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(332, 76);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Network Architecture";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 26);
            this.label1.TabIndex = 17;
            this.label1.Text = "Splitter is:\r\ncomma";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 52);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(43, 13);
            this.lblResult.TabIndex = 20;
            this.lblResult.Text = "Result: ";
            // 
            // NNProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 314);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblProblem);
            this.Controls.Add(this.cmbProblem);
            this.Name = "NNProject";
            this.Text = "NNProject";
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxEpochs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestingNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSamplesNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestIndex)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInputs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputs)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProblem;
        private System.Windows.Forms.Label lblProblem;
        private System.Windows.Forms.Label lblSamplesNum;
        private System.Windows.Forms.Label lblTestingNum;
        private System.Windows.Forms.Label lblEtaRange;
        private System.Windows.Forms.Label lblMinError;
        private System.Windows.Forms.Label lblMaxEpochs;
        private System.Windows.Forms.NumericUpDown nudMaxEpochs;
        private System.Windows.Forms.TextBox txtMinError;
        private System.Windows.Forms.TextBox txtEtaMin;
        private System.Windows.Forms.NumericUpDown nudTestingNum;
        private System.Windows.Forms.NumericUpDown nudSamplesNum;
        private System.Windows.Forms.Button btnOpenSamplesFile;
        private System.Windows.Forms.Button btnOpenResultsFile;
        private System.Windows.Forms.TextBox txtResultsFile;
        private System.Windows.Forms.TextBox txtSamplesFile;
        private System.Windows.Forms.TextBox txtEtaMax;
        private System.Windows.Forms.Label lblColon_1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnTestIndex;
        private System.Windows.Forms.TextBox txtTestResult;
        private System.Windows.Forms.Label lblColon_2;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblCurrentEpochNum;
        private System.Windows.Forms.Label lblCurrentError;
        private System.Windows.Forms.Label lblTimeElapsed;
        private System.Windows.Forms.TextBox txtCurrentEpochNum;
        private System.Windows.Forms.TextBox txtElapsedTime;
        private System.Windows.Forms.TextBox txtCurrentError;
        private System.Windows.Forms.NumericUpDown nudTestIndex;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown nudInputs;
        private System.Windows.Forms.NumericUpDown nudOutputs;
        private System.Windows.Forms.TextBox txtHiddenLayers;
        private System.Windows.Forms.Label lblInputs;
        private System.Windows.Forms.Label lblOutputs;
        private System.Windows.Forms.Label lblHiddenLayers;
        private System.Windows.Forms.Button btnChangeArchitecture;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResult;
    }
}

