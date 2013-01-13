namespace MultipleQueue
{
    partial class SystemStartup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemStartup));
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.InterarrivalTimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CumlativeProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDataGridView = new System.Windows.Forms.Panel();
            this.lblServerPriority = new System.Windows.Forms.Label();
            this.nudServerPriority = new System.Windows.Forms.NumericUpDown();
            this.btnNextServer = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblServerNumber = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.nudMaxClock = new System.Windows.Forms.NumericUpDown();
            this.nudMaxCustomers = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbServerSelection = new System.Windows.Forms.ComboBox();
            this.nudNumOfServers = new System.Windows.Forms.NumericUpDown();
            this.lblMaxClock = new System.Windows.Forms.Label();
            this.lblMaxCostumers = new System.Windows.Forms.Label();
            this.lblServers = new System.Windows.Forms.Label();
            this.lblStoppingCondition = new System.Windows.Forms.Label();
            this.lblServerSelection = new System.Windows.Forms.Label();
            this.lblNumOfServers = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPriority)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxClock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumOfServers)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InterarrivalTimes,
            this.Probability,
            this.CumlativeProbability});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.GridColor = System.Drawing.Color.DarkRed;
            this.dgvMain.Location = new System.Drawing.Point(3, 3);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.Size = new System.Drawing.Size(223, 229);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellEndEdit);
            this.dgvMain.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellEndEdit);
            this.dgvMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.dgvMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // InterarrivalTimes
            // 
            this.InterarrivalTimes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InterarrivalTimes.HeaderText = "Value";
            this.InterarrivalTimes.MinimumWidth = 2;
            this.InterarrivalTimes.Name = "InterarrivalTimes";
            this.InterarrivalTimes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Probability
            // 
            this.Probability.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Probability.HeaderText = "Probability";
            this.Probability.MinimumWidth = 2;
            this.Probability.Name = "Probability";
            this.Probability.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CumlativeProbability
            // 
            this.CumlativeProbability.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CumlativeProbability.HeaderText = "Cumulative Probability";
            this.CumlativeProbability.MinimumWidth = 2;
            this.CumlativeProbability.Name = "CumlativeProbability";
            this.CumlativeProbability.ReadOnly = true;
            this.CumlativeProbability.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.lblServerPriority);
            this.pnlDataGridView.Controls.Add(this.nudServerPriority);
            this.pnlDataGridView.Controls.Add(this.btnNextServer);
            this.pnlDataGridView.Controls.Add(this.btnClear);
            this.pnlDataGridView.Controls.Add(this.dgvMain);
            this.pnlDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGridView.Location = new System.Drawing.Point(0, 0);
            this.pnlDataGridView.Name = "pnlDataGridView";
            this.pnlDataGridView.Size = new System.Drawing.Size(284, 235);
            this.pnlDataGridView.TabIndex = 3;
            this.pnlDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.pnlDataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // lblServerPriority
            // 
            this.lblServerPriority.AutoSize = true;
            this.lblServerPriority.Location = new System.Drawing.Point(232, 58);
            this.lblServerPriority.Name = "lblServerPriority";
            this.lblServerPriority.Size = new System.Drawing.Size(48, 13);
            this.lblServerPriority.TabIndex = 2;
            this.lblServerPriority.Text = "Priority: ";
            // 
            // nudServerPriority
            // 
            this.nudServerPriority.Location = new System.Drawing.Point(235, 74);
            this.nudServerPriority.Name = "nudServerPriority";
            this.nudServerPriority.Size = new System.Drawing.Size(45, 20);
            this.nudServerPriority.TabIndex = 3;
            this.nudServerPriority.ValueChanged += new System.EventHandler(this.nudServerPriority_ValueChanged);
            // 
            // btnNextServer
            // 
            this.btnNextServer.BackColor = System.Drawing.Color.White;
            this.btnNextServer.BackgroundImage = global::MultipleQueue.Properties.Resources.Next_119499808318794028711rightarrow;
            this.btnNextServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNextServer.Location = new System.Drawing.Point(240, 192);
            this.btnNextServer.Name = "btnNextServer";
            this.btnNextServer.Size = new System.Drawing.Size(40, 40);
            this.btnNextServer.TabIndex = 1;
            this.btnNextServer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnNextServer, "Next Server");
            this.btnNextServer.UseVisualStyleBackColor = false;
            this.btnNextServer.Click += new System.EventHandler(this.btnNextServer_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.BackgroundImage = global::MultipleQueue.Properties.Resources.edit_clear;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.Location = new System.Drawing.Point(240, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(40, 40);
            this.btnClear.TabIndex = 4;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnClear, "Clear Data");
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblServerNumber
            // 
            this.lblServerNumber.AutoSize = true;
            this.lblServerNumber.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerNumber.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblServerNumber.Location = new System.Drawing.Point(81, 13);
            this.lblServerNumber.Name = "lblServerNumber";
            this.lblServerNumber.Size = new System.Drawing.Size(0, 18);
            this.lblServerNumber.TabIndex = 2;
            this.lblServerNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.lblServerNumber.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.nudMaxClock);
            this.pnlMain.Controls.Add(this.nudMaxCustomers);
            this.pnlMain.Controls.Add(this.btnOK);
            this.pnlMain.Controls.Add(this.cmbServerSelection);
            this.pnlMain.Controls.Add(this.nudNumOfServers);
            this.pnlMain.Controls.Add(this.lblMaxClock);
            this.pnlMain.Controls.Add(this.lblMaxCostumers);
            this.pnlMain.Controls.Add(this.lblServers);
            this.pnlMain.Controls.Add(this.lblStoppingCondition);
            this.pnlMain.Controls.Add(this.lblServerSelection);
            this.pnlMain.Controls.Add(this.lblNumOfServers);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(284, 235);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // nudMaxClock
            // 
            this.nudMaxClock.Location = new System.Drawing.Point(114, 179);
            this.nudMaxClock.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudMaxClock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxClock.Name = "nudMaxClock";
            this.nudMaxClock.Size = new System.Drawing.Size(100, 20);
            this.nudMaxClock.TabIndex = 6;
            this.nudMaxClock.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // nudMaxCustomers
            // 
            this.nudMaxCustomers.Location = new System.Drawing.Point(114, 150);
            this.nudMaxCustomers.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudMaxCustomers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxCustomers.Name = "nudMaxCustomers";
            this.nudMaxCustomers.Size = new System.Drawing.Size(100, 20);
            this.nudMaxCustomers.TabIndex = 6;
            this.nudMaxCustomers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = global::MultipleQueue.Properties.Resources.Next_119499808318794028711rightarrow;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOK.Location = new System.Drawing.Point(240, 192);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(40, 40);
            this.btnOK.TabIndex = 5;
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnOK, "Set Values");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // cmbServerSelection
            // 
            this.cmbServerSelection.FormattingEnabled = true;
            this.cmbServerSelection.Location = new System.Drawing.Point(114, 73);
            this.cmbServerSelection.Name = "cmbServerSelection";
            this.cmbServerSelection.Size = new System.Drawing.Size(100, 21);
            this.cmbServerSelection.TabIndex = 3;
            // 
            // nudNumOfServers
            // 
            this.nudNumOfServers.Location = new System.Drawing.Point(114, 41);
            this.nudNumOfServers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumOfServers.Name = "nudNumOfServers";
            this.nudNumOfServers.Size = new System.Drawing.Size(100, 20);
            this.nudNumOfServers.TabIndex = 2;
            this.nudNumOfServers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMaxClock
            // 
            this.lblMaxClock.AutoSize = true;
            this.lblMaxClock.Location = new System.Drawing.Point(16, 181);
            this.lblMaxClock.Name = "lblMaxClock";
            this.lblMaxClock.Size = new System.Drawing.Size(59, 13);
            this.lblMaxClock.TabIndex = 1;
            this.lblMaxClock.Text = "Max Clock:";
            // 
            // lblMaxCostumers
            // 
            this.lblMaxCostumers.AutoSize = true;
            this.lblMaxCostumers.Location = new System.Drawing.Point(16, 152);
            this.lblMaxCostumers.Name = "lblMaxCostumers";
            this.lblMaxCostumers.Size = new System.Drawing.Size(88, 13);
            this.lblMaxCostumers.TabIndex = 1;
            this.lblMaxCostumers.Text = "Max Costumers: ";
            // 
            // lblServers
            // 
            this.lblServers.AutoSize = true;
            this.lblServers.Font = new System.Drawing.Font("Tempus Sans ITC", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServers.Location = new System.Drawing.Point(81, 12);
            this.lblServers.Name = "lblServers";
            this.lblServers.Size = new System.Drawing.Size(43, 17);
            this.lblServers.TabIndex = 1;
            this.lblServers.Text = "Servers";
            // 
            // lblStoppingCondition
            // 
            this.lblStoppingCondition.AutoSize = true;
            this.lblStoppingCondition.Font = new System.Drawing.Font("Tempus Sans ITC", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoppingCondition.Location = new System.Drawing.Point(43, 110);
            this.lblStoppingCondition.Name = "lblStoppingCondition";
            this.lblStoppingCondition.Size = new System.Drawing.Size(120, 17);
            this.lblStoppingCondition.TabIndex = 1;
            this.lblStoppingCondition.Text = "Stopping Conditions";
            // 
            // lblServerSelection
            // 
            this.lblServerSelection.AutoSize = true;
            this.lblServerSelection.Location = new System.Drawing.Point(16, 76);
            this.lblServerSelection.Name = "lblServerSelection";
            this.lblServerSelection.Size = new System.Drawing.Size(92, 13);
            this.lblServerSelection.TabIndex = 1;
            this.lblServerSelection.Text = "Server Selection: ";
            // 
            // lblNumOfServers
            // 
            this.lblNumOfServers.AutoSize = true;
            this.lblNumOfServers.Location = new System.Drawing.Point(16, 42);
            this.lblNumOfServers.Name = "lblNumOfServers";
            this.lblNumOfServers.Size = new System.Drawing.Size(59, 13);
            this.lblNumOfServers.TabIndex = 1;
            this.lblNumOfServers.Text = "#Servers: ";
            // 
            // tlpMain
            // 
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.pnl1, 0, 1);
            this.tlpMain.Controls.Add(this.pnl2, 0, 0);
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.40614F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.59386F));
            this.tlpMain.Size = new System.Drawing.Size(292, 294);
            this.tlpMain.TabIndex = 7;
            this.tlpMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.tlpMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.pnlDataGridView);
            this.pnl1.Controls.Add(this.pnlMain);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(4, 55);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(284, 235);
            this.pnl1.TabIndex = 0;
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.btnOpen);
            this.pnl2.Controls.Add(this.lblServerNumber);
            this.pnl2.Controls.Add(this.btnClose);
            this.pnl2.Controls.Add(this.btnFinish);
            this.pnl2.Controls.Add(this.btnSave);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl2.Location = new System.Drawing.Point(4, 4);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(284, 44);
            this.pnl2.TabIndex = 1;
            this.pnl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.pnl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.White;
            this.btnOpen.BackgroundImage = global::MultipleQueue.Properties.Resources.folder_open;
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpen.Location = new System.Drawing.Point(3, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(40, 40);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnOpen, "Open Saved StartUp Data");
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = global::MultipleQueue.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(240, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.BackgroundImage = global::MultipleQueue.Properties.Resources.done_icon_5;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFinish.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFinish.Location = new System.Drawing.Point(240, 1);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(40, 40);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnFinish, "End StartUp Data");
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::MultipleQueue.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SystemStartup
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(293, 295);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SystemStartup";
            this.Text = "SystemStartup";
            this.Load += new System.EventHandler(this.SystemStartup_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.SystemStartup_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.SystemStartup_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.pnlDataGridView.ResumeLayout(false);
            this.pnlDataGridView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPriority)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxClock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumOfServers)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblNumOfServers;
        private System.Windows.Forms.ComboBox cmbServerSelection;
        private System.Windows.Forms.NumericUpDown nudNumOfServers;
        private System.Windows.Forms.Label lblMaxCostumers;
        private System.Windows.Forms.Label lblServerSelection;
        private System.Windows.Forms.Panel pnlDataGridView;
        private System.Windows.Forms.Button btnNextServer;
        private System.Windows.Forms.Label lblServerPriority;
        private System.Windows.Forms.NumericUpDown nudServerPriority;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Label lblServerNumber;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown nudMaxClock;
        private System.Windows.Forms.NumericUpDown nudMaxCustomers;
        private System.Windows.Forms.Label lblMaxClock;
        private System.Windows.Forms.Label lblStoppingCondition;
        private System.Windows.Forms.Label lblServers;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterarrivalTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Probability;
        private System.Windows.Forms.DataGridViewTextBoxColumn CumlativeProbability;
    }
}