namespace NNLibrary
{
    partial class TrainingData
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
            this.txtCurrentError = new System.Windows.Forms.TextBox();
            this.txtTimeElapsed = new System.Windows.Forms.TextBox();
            this.txtCurrentEpochNum = new System.Windows.Forms.TextBox();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.lblCurrentError = new System.Windows.Forms.Label();
            this.lblCurrentEpochNum = new System.Windows.Forms.Label();
            this.lblSampleIndex = new System.Windows.Forms.Label();
            this.txtSampleIndex = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtCurrentError
            // 
            this.txtCurrentError.Location = new System.Drawing.Point(66, 52);
            this.txtCurrentError.Name = "txtCurrentError";
            this.txtCurrentError.Size = new System.Drawing.Size(147, 20);
            this.txtCurrentError.TabIndex = 8;
            // 
            // txtTimeElapsed
            // 
            this.txtTimeElapsed.Location = new System.Drawing.Point(66, 75);
            this.txtTimeElapsed.Name = "txtTimeElapsed";
            this.txtTimeElapsed.Size = new System.Drawing.Size(147, 20);
            this.txtTimeElapsed.TabIndex = 9;
            // 
            // txtCurrentEpochNum
            // 
            this.txtCurrentEpochNum.Location = new System.Drawing.Point(66, 28);
            this.txtCurrentEpochNum.Name = "txtCurrentEpochNum";
            this.txtCurrentEpochNum.Size = new System.Drawing.Size(37, 20);
            this.txtCurrentEpochNum.TabIndex = 10;
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.AutoSize = true;
            this.lblTimeElapsed.Location = new System.Drawing.Point(16, 78);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(36, 13);
            this.lblTimeElapsed.TabIndex = 6;
            this.lblTimeElapsed.Text = "Time: ";
            // 
            // lblCurrentError
            // 
            this.lblCurrentError.AutoSize = true;
            this.lblCurrentError.Location = new System.Drawing.Point(16, 55);
            this.lblCurrentError.Name = "lblCurrentError";
            this.lblCurrentError.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentError.TabIndex = 5;
            this.lblCurrentError.Text = "Error: ";
            // 
            // lblCurrentEpochNum
            // 
            this.lblCurrentEpochNum.AutoSize = true;
            this.lblCurrentEpochNum.Location = new System.Drawing.Point(16, 31);
            this.lblCurrentEpochNum.Name = "lblCurrentEpochNum";
            this.lblCurrentEpochNum.Size = new System.Drawing.Size(44, 13);
            this.lblCurrentEpochNum.TabIndex = 7;
            this.lblCurrentEpochNum.Text = "Epoch: ";
            // 
            // lblSampleIndex
            // 
            this.lblSampleIndex.AutoSize = true;
            this.lblSampleIndex.Location = new System.Drawing.Point(117, 31);
            this.lblSampleIndex.Name = "lblSampleIndex";
            this.lblSampleIndex.Size = new System.Drawing.Size(39, 13);
            this.lblSampleIndex.TabIndex = 7;
            this.lblSampleIndex.Text = "Index: ";
            // 
            // txtSampleIndex
            // 
            this.txtSampleIndex.Location = new System.Drawing.Point(167, 28);
            this.txtSampleIndex.Name = "txtSampleIndex";
            this.txtSampleIndex.Size = new System.Drawing.Size(37, 20);
            this.txtSampleIndex.TabIndex = 10;
            // 
            // TrainingData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 123);
            this.Controls.Add(this.txtCurrentError);
            this.Controls.Add(this.txtTimeElapsed);
            this.Controls.Add(this.txtSampleIndex);
            this.Controls.Add(this.txtCurrentEpochNum);
            this.Controls.Add(this.lblTimeElapsed);
            this.Controls.Add(this.lblSampleIndex);
            this.Controls.Add(this.lblCurrentError);
            this.Controls.Add(this.lblCurrentEpochNum);
            this.Name = "TrainingData";
            this.Text = "TrainingData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCurrentError;
        private System.Windows.Forms.TextBox txtTimeElapsed;
        private System.Windows.Forms.TextBox txtCurrentEpochNum;
        private System.Windows.Forms.Label lblTimeElapsed;
        private System.Windows.Forms.Label lblCurrentError;
        private System.Windows.Forms.Label lblCurrentEpochNum;
        private System.Windows.Forms.Label lblSampleIndex;
        private System.Windows.Forms.TextBox txtSampleIndex;
    }
}