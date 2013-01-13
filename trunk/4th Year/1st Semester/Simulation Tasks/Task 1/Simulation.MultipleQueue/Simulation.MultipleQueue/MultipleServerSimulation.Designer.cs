namespace MultipleQueue
{
    partial class MultipleServerSimulation
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultipleServerSimulation));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnRestartModel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRestartAll = new System.Windows.Forms.Button();
            this.lblClockTime = new System.Windows.Forms.Label();
            this.btnStartUpData = new System.Windows.Forms.Button();
            this.btnPerformanceMeasure = new System.Windows.Forms.Button();
            this.pnlInformation = new System.Windows.Forms.Panel();
            this.lblJumpType = new System.Windows.Forms.Label();
            this.cmbJumpType = new System.Windows.Forms.ComboBox();
            this.nudJumpValue = new System.Windows.Forms.NumericUpDown();
            this.btnJump = new System.Windows.Forms.Button();
            this.lblCurrentEvent = new System.Windows.Forms.Label();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.CustomerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerChosen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeServiceBegins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeInSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerQueue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            this.pnlInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudJumpValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.pnlBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.btnRestartModel);
            this.pnlMain.Controls.Add(this.btnExit);
            this.pnlMain.Controls.Add(this.btnRestartAll);
            this.pnlMain.Controls.Add(this.lblClockTime);
            this.pnlMain.Controls.Add(this.btnStartUpData);
            this.pnlMain.Controls.Add(this.btnPerformanceMeasure);
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(630, 89);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MultipleServerSimulation_MouseDown);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MultipleServerSimulation_MouseMove);
            // 
            // btnRestartModel
            // 
            this.btnRestartModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestartModel.BackColor = System.Drawing.Color.White;
            this.btnRestartModel.BackgroundImage = global::MultipleQueue.Properties.Resources.edit_clear;
            this.btnRestartModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRestartModel.Location = new System.Drawing.Point(375, 2);
            this.btnRestartModel.Name = "btnRestartModel";
            this.btnRestartModel.Size = new System.Drawing.Size(80, 80);
            this.btnRestartModel.TabIndex = 5;
            this.btnRestartModel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnRestartModel, "Clear Simulation");
            this.btnRestartModel.UseVisualStyleBackColor = false;
            this.btnRestartModel.Click += new System.EventHandler(this.btnRestartModel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.BackgroundImage = global::MultipleQueue.Properties.Resources.close;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Location = new System.Drawing.Point(547, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 80);
            this.btnExit.TabIndex = 2;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnExit, "Close");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRestartAll
            // 
            this.btnRestartAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestartAll.BackColor = System.Drawing.Color.White;
            this.btnRestartAll.BackgroundImage = global::MultipleQueue.Properties.Resources.restart_md;
            this.btnRestartAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRestartAll.Location = new System.Drawing.Point(461, 2);
            this.btnRestartAll.Name = "btnRestartAll";
            this.btnRestartAll.Size = new System.Drawing.Size(80, 80);
            this.btnRestartAll.TabIndex = 1;
            this.btnRestartAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnRestartAll, "Restart Program");
            this.btnRestartAll.UseVisualStyleBackColor = false;
            this.btnRestartAll.Click += new System.EventHandler(this.btnRestartAll_Click);
            // 
            // lblClockTime
            // 
            this.lblClockTime.BackColor = System.Drawing.Color.Transparent;
            this.lblClockTime.Font = new System.Drawing.Font("Bodoni MT Poster Compressed", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClockTime.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblClockTime.Image = global::MultipleQueue.Properties.Resources.syd_5aerlntueyg1b1urwbro_layout80X80;
            this.lblClockTime.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblClockTime.Location = new System.Drawing.Point(84, 2);
            this.lblClockTime.Name = "lblClockTime";
            this.lblClockTime.Size = new System.Drawing.Size(163, 80);
            this.lblClockTime.TabIndex = 0;
            this.lblClockTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttMain.SetToolTip(this.lblClockTime, "Current Clock");
            this.lblClockTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MultipleServerSimulation_MouseDown);
            this.lblClockTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MultipleServerSimulation_MouseMove);
            // 
            // btnStartUpData
            // 
            this.btnStartUpData.BackColor = System.Drawing.Color.White;
            this.btnStartUpData.BackgroundImage = global::MultipleQueue.Properties.Resources.Restart_Button_1;
            this.btnStartUpData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStartUpData.Location = new System.Drawing.Point(3, 2);
            this.btnStartUpData.Name = "btnStartUpData";
            this.btnStartUpData.Size = new System.Drawing.Size(80, 80);
            this.btnStartUpData.TabIndex = 4;
            this.btnStartUpData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnStartUpData, "Set StartUp Data");
            this.btnStartUpData.UseVisualStyleBackColor = false;
            this.btnStartUpData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStartUpData_MouseUp);
            // 
            // btnPerformanceMeasure
            // 
            this.btnPerformanceMeasure.BackgroundImage = global::MultipleQueue.Properties.Resources.reports;
            this.btnPerformanceMeasure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPerformanceMeasure.Location = new System.Drawing.Point(3, 2);
            this.btnPerformanceMeasure.Name = "btnPerformanceMeasure";
            this.btnPerformanceMeasure.Size = new System.Drawing.Size(80, 80);
            this.btnPerformanceMeasure.TabIndex = 0;
            this.btnPerformanceMeasure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnPerformanceMeasure, "Generate Report");
            this.btnPerformanceMeasure.UseVisualStyleBackColor = true;
            this.btnPerformanceMeasure.Click += new System.EventHandler(this.btnPerformanceMeasure_Click);
            // 
            // pnlInformation
            // 
            this.pnlInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInformation.Controls.Add(this.lblJumpType);
            this.pnlInformation.Controls.Add(this.cmbJumpType);
            this.pnlInformation.Controls.Add(this.nudJumpValue);
            this.pnlInformation.Controls.Add(this.btnJump);
            this.pnlInformation.Controls.Add(this.lblCurrentEvent);
            this.pnlInformation.Location = new System.Drawing.Point(3, 405);
            this.pnlInformation.Name = "pnlInformation";
            this.pnlInformation.Size = new System.Drawing.Size(630, 84);
            this.pnlInformation.TabIndex = 2;
            this.pnlInformation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MultipleServerSimulation_MouseDown);
            this.pnlInformation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MultipleServerSimulation_MouseMove);
            // 
            // lblJumpType
            // 
            this.lblJumpType.AutoSize = true;
            this.lblJumpType.Location = new System.Drawing.Point(395, 11);
            this.lblJumpType.Name = "lblJumpType";
            this.lblJumpType.Size = new System.Drawing.Size(66, 13);
            this.lblJumpType.TabIndex = 5;
            this.lblJumpType.Text = "Jump Type: ";
            // 
            // cmbJumpType
            // 
            this.cmbJumpType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbJumpType.FormattingEnabled = true;
            this.cmbJumpType.Location = new System.Drawing.Point(395, 27);
            this.cmbJumpType.Name = "cmbJumpType";
            this.cmbJumpType.Size = new System.Drawing.Size(147, 21);
            this.cmbJumpType.TabIndex = 4;
            this.cmbJumpType.SelectedIndexChanged += new System.EventHandler(this.cmbJumpType_SelectedIndexChanged);
            // 
            // nudJumpValue
            // 
            this.nudJumpValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudJumpValue.Location = new System.Drawing.Point(461, 52);
            this.nudJumpValue.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudJumpValue.Name = "nudJumpValue";
            this.nudJumpValue.Size = new System.Drawing.Size(80, 20);
            this.nudJumpValue.TabIndex = 3;
            // 
            // btnJump
            // 
            this.btnJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJump.BackColor = System.Drawing.Color.White;
            this.btnJump.BackgroundImage = global::MultipleQueue.Properties.Resources.Next_119499808318794028711rightarrow;
            this.btnJump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnJump.Location = new System.Drawing.Point(548, 2);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(80, 80);
            this.btnJump.TabIndex = 1;
            this.btnJump.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnJump, "Next Event");
            this.btnJump.UseVisualStyleBackColor = false;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // lblCurrentEvent
            // 
            this.lblCurrentEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentEvent.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentEvent.Font = new System.Drawing.Font("Bodoni MT Poster Compressed", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentEvent.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblCurrentEvent.Image = global::MultipleQueue.Properties.Resources.News_clipart_80x80;
            this.lblCurrentEvent.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblCurrentEvent.Location = new System.Drawing.Point(1, 2);
            this.lblCurrentEvent.Name = "lblCurrentEvent";
            this.lblCurrentEvent.Size = new System.Drawing.Size(270, 80);
            this.lblCurrentEvent.TabIndex = 0;
            this.lblCurrentEvent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttMain.SetToolTip(this.lblCurrentEvent, "Current Event");
            this.lblCurrentEvent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MultipleServerSimulation_MouseDown);
            this.lblCurrentEvent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MultipleServerSimulation_MouseMove);
            // 
            // dgvMain
            // 
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerNumber,
            this.InterArrivalTime,
            this.ArrivalTime,
            this.ServerChosen,
            this.ServiceTime,
            this.TimeServiceBegins,
            this.CustomerDelay,
            this.TimeInSystem,
            this.CustomerQueue});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.GridColor = System.Drawing.Color.DarkRed;
            this.dgvMain.Location = new System.Drawing.Point(3, 92);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.Size = new System.Drawing.Size(630, 312);
            this.dgvMain.TabIndex = 1;
            // 
            // pnlBackground
            // 
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackground.Controls.Add(this.pnlMain);
            this.pnlBackground.Controls.Add(this.pnlInformation);
            this.pnlBackground.Controls.Add(this.dgvMain);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(637, 494);
            this.pnlBackground.TabIndex = 2;
            // 
            // CustomerNumber
            // 
            this.CustomerNumber.HeaderText = "Customer# (Number)";
            this.CustomerNumber.Name = "CustomerNumber";
            this.CustomerNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InterArrivalTime
            // 
            this.InterArrivalTime.HeaderText = "Inter-Arrival Time (Duration)";
            this.InterArrivalTime.Name = "InterArrivalTime";
            this.InterArrivalTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ArrivalTime
            // 
            this.ArrivalTime.HeaderText = "Arrival Time (Clock)";
            this.ArrivalTime.Name = "ArrivalTime";
            this.ArrivalTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ServerChosen
            // 
            this.ServerChosen.HeaderText = "Server Chosen (Number)";
            this.ServerChosen.Name = "ServerChosen";
            this.ServerChosen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ServiceTime
            // 
            this.ServiceTime.HeaderText = "Service Time (Duration)";
            this.ServiceTime.Name = "ServiceTime";
            this.ServiceTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TimeServiceBegins
            // 
            this.TimeServiceBegins.HeaderText = "Time Service Begins (Clock)";
            this.TimeServiceBegins.Name = "TimeServiceBegins";
            this.TimeServiceBegins.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CustomerDelay
            // 
            this.CustomerDelay.HeaderText = "Customer Delay (Duration)";
            this.CustomerDelay.Name = "CustomerDelay";
            this.CustomerDelay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TimeInSystem
            // 
            this.TimeInSystem.HeaderText = "Time In System (Duration)";
            this.TimeInSystem.Name = "TimeInSystem";
            this.TimeInSystem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CustomerQueue
            // 
            this.CustomerQueue.HeaderText = "Customer Queue (Number)";
            this.CustomerQueue.Name = "CustomerQueue";
            // 
            // MultipleServerSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(637, 494);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultipleServerSimulation";
            this.Text = "Task1";
            this.Load += new System.EventHandler(this.MultipleServerSimulation_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MultipleServerSimulation_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MultipleServerSimulation_MouseMove);
            this.pnlMain.ResumeLayout(false);
            this.pnlInformation.ResumeLayout(false);
            this.pnlInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudJumpValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRestartAll;
        private System.Windows.Forms.Button btnPerformanceMeasure;
        private System.Windows.Forms.Label lblClockTime;
        private System.Windows.Forms.Button btnStartUpData;
        private System.Windows.Forms.Button btnRestartModel;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel pnlInformation;
        private System.Windows.Forms.ComboBox cmbJumpType;
        private System.Windows.Forms.NumericUpDown nudJumpValue;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.Label lblCurrentEvent;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lblJumpType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerChosen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeServiceBegins;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeInSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerQueue;
    }
}

