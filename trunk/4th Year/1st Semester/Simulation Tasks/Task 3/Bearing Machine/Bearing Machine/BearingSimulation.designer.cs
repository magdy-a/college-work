namespace Bearing_Machine
{
    partial class BearingSimulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BearingSimulation));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblModuleType = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPerformanceMeasure = new System.Windows.Forms.Button();
            this.pnlInformation = new System.Windows.Forms.Panel();
            this.lblStatistics = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.dgvProposedModule = new System.Windows.Forms.DataGridView();
            this.colPorposedIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProposedBearingOneLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProposedBearingTwoLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProposedBearingThreeLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProposedFirstFailure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProposedAccLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProposedDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCurrentModule = new System.Windows.Forms.DataGridView();
            this.colCurrentBearingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBearingOneLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBearingOneAccLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBearingOneDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBearingTwoLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBearingTwoAccLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBearingTwoDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBearingThreeLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBearingThreeAccLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBearingThreeDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            this.pnlInformation.SuspendLayout();
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProposedModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentModule)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.lblModuleType);
            this.pnlMain.Controls.Add(this.btnExit);
            this.pnlMain.Controls.Add(this.btnPerformanceMeasure);
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(630, 89);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseDown);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseMove);
            // 
            // lblModuleType
            // 
            this.lblModuleType.BackColor = System.Drawing.Color.GreenYellow;
            this.lblModuleType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModuleType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblModuleType.Font = new System.Drawing.Font("Bodoni MT Condensed", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuleType.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblModuleType.Location = new System.Drawing.Point(124, 2);
            this.lblModuleType.Name = "lblModuleType";
            this.lblModuleType.Size = new System.Drawing.Size(382, 80);
            this.lblModuleType.TabIndex = 5;
            this.lblModuleType.Text = "Current Module";
            this.lblModuleType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblModuleType.Click += new System.EventHandler(this.lblModuleType_Click);
            this.lblModuleType.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseDown);
            this.lblModuleType.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseMove);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.BackgroundImage = global::Bearing_Machine.Properties.Resources.close;
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
            // btnPerformanceMeasure
            // 
            this.btnPerformanceMeasure.BackgroundImage = global::Bearing_Machine.Properties.Resources.reports;
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
            this.pnlInformation.Controls.Add(this.lblStatistics);
            this.pnlInformation.Controls.Add(this.btnPrevious);
            this.pnlInformation.Controls.Add(this.btnNext);
            this.pnlInformation.Location = new System.Drawing.Point(3, 405);
            this.pnlInformation.Name = "pnlInformation";
            this.pnlInformation.Size = new System.Drawing.Size(630, 84);
            this.pnlInformation.TabIndex = 2;
            this.pnlInformation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseDown);
            this.pnlInformation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseMove);
            // 
            // lblStatistics
            // 
            this.lblStatistics.Font = new System.Drawing.Font("Bodoni MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatistics.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblStatistics.Location = new System.Drawing.Point(89, 2);
            this.lblStatistics.Name = "lblStatistics";
            this.lblStatistics.Size = new System.Drawing.Size(452, 80);
            this.lblStatistics.TabIndex = 5;
            this.lblStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttMain.SetToolTip(this.lblStatistics, "Statistics");
            this.lblStatistics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseDown);
            this.lblStatistics.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseMove);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackgroundImage = global::Bearing_Machine.Properties.Resources._119499808318794028711leftarrow;
            this.btnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrevious.Location = new System.Drawing.Point(0, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(80, 80);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnPrevious, "Previous Model");
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.BackgroundImage = global::Bearing_Machine.Properties.Resources._119499808318794028711rightarrow;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.Location = new System.Drawing.Point(548, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 80);
            this.btnNext.TabIndex = 1;
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnNext, "Next Model");
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnlBackground
            // 
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackground.Controls.Add(this.pnlMain);
            this.pnlBackground.Controls.Add(this.pnlInformation);
            this.pnlBackground.Controls.Add(this.dgvProposedModule);
            this.pnlBackground.Controls.Add(this.dgvCurrentModule);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(637, 494);
            this.pnlBackground.TabIndex = 2;
            // 
            // dgvProposedModule
            // 
            this.dgvProposedModule.BackgroundColor = System.Drawing.Color.White;
            this.dgvProposedModule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProposedModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProposedModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPorposedIndex,
            this.colProposedBearingOneLife,
            this.colProposedBearingTwoLife,
            this.colProposedBearingThreeLife,
            this.colProposedFirstFailure,
            this.colProposedAccLife,
            this.colProposedDelay});
            this.dgvProposedModule.GridColor = System.Drawing.Color.DarkRed;
            this.dgvProposedModule.Location = new System.Drawing.Point(3, 92);
            this.dgvProposedModule.Name = "dgvProposedModule";
            this.dgvProposedModule.RowHeadersVisible = false;
            this.dgvProposedModule.Size = new System.Drawing.Size(630, 312);
            this.dgvProposedModule.TabIndex = 1;
            // 
            // colPorposedIndex
            // 
            this.colPorposedIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPorposedIndex.DividerWidth = 3;
            this.colPorposedIndex.HeaderText = "Index (Number)";
            this.colPorposedIndex.Name = "colPorposedIndex";
            this.colPorposedIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProposedBearingOneLife
            // 
            this.colProposedBearingOneLife.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProposedBearingOneLife.DividerWidth = 2;
            this.colProposedBearingOneLife.HeaderText = "Bearing 1 Life (Hours)";
            this.colProposedBearingOneLife.Name = "colProposedBearingOneLife";
            this.colProposedBearingOneLife.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProposedBearingTwoLife
            // 
            this.colProposedBearingTwoLife.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProposedBearingTwoLife.DividerWidth = 2;
            this.colProposedBearingTwoLife.HeaderText = "Bearing 2 Life (Hours)";
            this.colProposedBearingTwoLife.Name = "colProposedBearingTwoLife";
            this.colProposedBearingTwoLife.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProposedBearingThreeLife
            // 
            this.colProposedBearingThreeLife.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProposedBearingThreeLife.DividerWidth = 2;
            this.colProposedBearingThreeLife.HeaderText = "Bearing 3 Life (Hours)";
            this.colProposedBearingThreeLife.Name = "colProposedBearingThreeLife";
            this.colProposedBearingThreeLife.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProposedFirstFailure
            // 
            this.colProposedFirstFailure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProposedFirstFailure.HeaderText = "First Failure (Hours)";
            this.colProposedFirstFailure.Name = "colProposedFirstFailure";
            this.colProposedFirstFailure.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProposedAccLife
            // 
            this.colProposedAccLife.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProposedAccLife.HeaderText = "Acc Life (Hours)";
            this.colProposedAccLife.Name = "colProposedAccLife";
            this.colProposedAccLife.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProposedDelay
            // 
            this.colProposedDelay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProposedDelay.HeaderText = "Delay (Min)";
            this.colProposedDelay.Name = "colProposedDelay";
            this.colProposedDelay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvCurrentModule
            // 
            this.dgvCurrentModule.BackgroundColor = System.Drawing.Color.White;
            this.dgvCurrentModule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCurrentModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCurrentBearingNumber,
            this.colBearingOneLife,
            this.colBearingOneAccLife,
            this.colBearingOneDelay,
            this.colBearingTwoLife,
            this.colBearingTwoAccLife,
            this.colBearingTwoDelay,
            this.colBearingThreeLife,
            this.colBearingThreeAccLife,
            this.colBearingThreeDelay});
            this.dgvCurrentModule.GridColor = System.Drawing.Color.DarkRed;
            this.dgvCurrentModule.Location = new System.Drawing.Point(3, 92);
            this.dgvCurrentModule.Name = "dgvCurrentModule";
            this.dgvCurrentModule.RowHeadersVisible = false;
            this.dgvCurrentModule.Size = new System.Drawing.Size(630, 312);
            this.dgvCurrentModule.TabIndex = 1;
            // 
            // colCurrentBearingNumber
            // 
            this.colCurrentBearingNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCurrentBearingNumber.DividerWidth = 3;
            this.colCurrentBearingNumber.HeaderText = "Index (Number)";
            this.colCurrentBearingNumber.Name = "colCurrentBearingNumber";
            this.colCurrentBearingNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBearingOneLife
            // 
            this.colBearingOneLife.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBearingOneLife.HeaderText = "Life (Hours)";
            this.colBearingOneLife.Name = "colBearingOneLife";
            this.colBearingOneLife.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBearingOneAccLife
            // 
            this.colBearingOneAccLife.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBearingOneAccLife.HeaderText = "Acc Life (Hours)";
            this.colBearingOneAccLife.Name = "colBearingOneAccLife";
            this.colBearingOneAccLife.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBearingOneDelay
            // 
            this.colBearingOneDelay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBearingOneDelay.DividerWidth = 2;
            this.colBearingOneDelay.HeaderText = "Delay (Min)";
            this.colBearingOneDelay.Name = "colBearingOneDelay";
            this.colBearingOneDelay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBearingTwoLife
            // 
            this.colBearingTwoLife.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBearingTwoLife.HeaderText = "Life (Hours)";
            this.colBearingTwoLife.Name = "colBearingTwoLife";
            this.colBearingTwoLife.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBearingTwoAccLife
            // 
            this.colBearingTwoAccLife.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBearingTwoAccLife.HeaderText = "Acc Life (Hours)";
            this.colBearingTwoAccLife.Name = "colBearingTwoAccLife";
            this.colBearingTwoAccLife.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBearingTwoDelay
            // 
            this.colBearingTwoDelay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBearingTwoDelay.DividerWidth = 2;
            this.colBearingTwoDelay.HeaderText = "Delay (Min)";
            this.colBearingTwoDelay.Name = "colBearingTwoDelay";
            this.colBearingTwoDelay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBearingThreeLife
            // 
            this.colBearingThreeLife.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBearingThreeLife.HeaderText = "Life (Hours)";
            this.colBearingThreeLife.Name = "colBearingThreeLife";
            this.colBearingThreeLife.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBearingThreeAccLife
            // 
            this.colBearingThreeAccLife.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBearingThreeAccLife.HeaderText = "Acc Life (Hours)";
            this.colBearingThreeAccLife.Name = "colBearingThreeAccLife";
            this.colBearingThreeAccLife.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBearingThreeDelay
            // 
            this.colBearingThreeDelay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBearingThreeDelay.HeaderText = "Delay (Min)";
            this.colBearingThreeDelay.Name = "colBearingThreeDelay";
            this.colBearingThreeDelay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBearingThreeDelay.Width = 60;
            // 
            // BearingSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(637, 494);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BearingSimulation";
            this.Text = "Task1";
            this.Load += new System.EventHandler(this.BearingSimulation_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseMove);
            this.pnlMain.ResumeLayout(false);
            this.pnlInformation.ResumeLayout(false);
            this.pnlBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProposedModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentModule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPerformanceMeasure;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.Panel pnlInformation;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblModuleType;
        private System.Windows.Forms.Label lblStatistics;
        private System.Windows.Forms.DataGridView dgvProposedModule;
        private System.Windows.Forms.DataGridView dgvCurrentModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentBearingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBearingOneLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBearingOneAccLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBearingOneDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBearingTwoLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBearingTwoAccLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBearingTwoDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBearingThreeLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBearingThreeAccLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBearingThreeDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorposedIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProposedBearingOneLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProposedBearingTwoLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProposedBearingThreeLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProposedFirstFailure;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProposedAccLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProposedDelay;




    }
}

