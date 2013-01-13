namespace Theory_Task1
{
    partial class TransitionTable
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
            this.lvStates = new System.Windows.Forms.ListView();
            this.chFromState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFromInput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chToState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chToOutput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chToCursor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
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
            this.lvStates.Location = new System.Drawing.Point(1, 1);
            this.lvStates.Name = "lvStates";
            this.lvStates.Size = new System.Drawing.Size(328, 177);
            this.lvStates.TabIndex = 62;
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
            // TransitionTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 179);
            this.Controls.Add(this.lvStates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TransitionTable";
            this.Text = "TransitionTable";
            this.Load += new System.EventHandler(this.TransitionTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvStates;
        private System.Windows.Forms.ColumnHeader chFromState;
        private System.Windows.Forms.ColumnHeader chFromInput;
        private System.Windows.Forms.ColumnHeader chToState;
        private System.Windows.Forms.ColumnHeader chToOutput;
        private System.Windows.Forms.ColumnHeader chToCursor;
    }
}