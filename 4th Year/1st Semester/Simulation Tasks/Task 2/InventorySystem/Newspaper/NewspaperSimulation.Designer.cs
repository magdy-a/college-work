namespace Newspaper
{
    partial class NewspaperSimulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewspaperSimulation));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblInventory = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRestartAll = new System.Windows.Forms.Button();
            this.btnStartUpData = new System.Windows.Forms.Button();
            this.btnPerformanceMeasure = new System.Windows.Forms.Button();
            this.pnlInformation = new System.Windows.Forms.Panel();
            this.lblStatistics = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsdayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RevenueFromSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LostProfitFromExcessDemand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalvageFromSalesOfScrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DailyProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            this.pnlInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.pnlBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.lblInventory);
            this.pnlMain.Controls.Add(this.btnExit);
            this.pnlMain.Controls.Add(this.btnRestartAll);
            this.pnlMain.Controls.Add(this.btnStartUpData);
            this.pnlMain.Controls.Add(this.btnPerformanceMeasure);
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(630, 89);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseDown);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseMove);
            // 
            // lblInventory
            // 
            this.lblInventory.Font = new System.Drawing.Font("Bodoni MT Condensed", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblInventory.Location = new System.Drawing.Point(89, 2);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(366, 80);
            this.lblInventory.TabIndex = 5;
            this.lblInventory.Text = "Inventory ";
            this.lblInventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInventory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseDown);
            this.lblInventory.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseMove);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.BackgroundImage = global::Newspaper.Properties.Resources.close;
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
            this.btnRestartAll.BackgroundImage = global::Newspaper.Properties.Resources.restart_md;
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
            // btnStartUpData
            // 
            this.btnStartUpData.BackColor = System.Drawing.Color.White;
            this.btnStartUpData.BackgroundImage = global::Newspaper.Properties.Resources.Restart_Button_1;
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
            this.btnPerformanceMeasure.BackgroundImage = global::Newspaper.Properties.Resources.reports;
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
            this.btnPrevious.BackgroundImage = global::Newspaper.Properties.Resources._119499808318794028711leftarrow;
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
            this.btnNext.BackgroundImage = global::Newspaper.Properties.Resources._119499808318794028711rightarrow;
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
            // dgvMain
            // 
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.NewsdayType,
            this.Demand,
            this.RevenueFromSales,
            this.LostProfitFromExcessDemand,
            this.SalvageFromSalesOfScrap,
            this.DailyProfit});
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
            // Day
            // 
            this.Day.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Day.HeaderText = "Day (Number)";
            this.Day.Name = "Day";
            this.Day.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NewsdayType
            // 
            this.NewsdayType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NewsdayType.HeaderText = "Type of Newsday (Type)";
            this.NewsdayType.Name = "NewsdayType";
            this.NewsdayType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Demand
            // 
            this.Demand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Demand.HeaderText = "Demand (Number)";
            this.Demand.Name = "Demand";
            this.Demand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RevenueFromSales
            // 
            this.RevenueFromSales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RevenueFromSales.HeaderText = "Revenue from Sales ($)";
            this.RevenueFromSales.Name = "RevenueFromSales";
            this.RevenueFromSales.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LostProfitFromExcessDemand
            // 
            this.LostProfitFromExcessDemand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LostProfitFromExcessDemand.HeaderText = "Lost Profit from Excess Demand ($)";
            this.LostProfitFromExcessDemand.Name = "LostProfitFromExcessDemand";
            this.LostProfitFromExcessDemand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SalvageFromSalesOfScrap
            // 
            this.SalvageFromSalesOfScrap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SalvageFromSalesOfScrap.HeaderText = "Salvage from Sales of Scrap ($)";
            this.SalvageFromSalesOfScrap.Name = "SalvageFromSalesOfScrap";
            this.SalvageFromSalesOfScrap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DailyProfit
            // 
            this.DailyProfit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DailyProfit.HeaderText = "DailyProfit ($)";
            this.DailyProfit.Name = "DailyProfit";
            this.DailyProfit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NewspaperSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(637, 494);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewspaperSimulation";
            this.Text = "Task1";
            this.Load += new System.EventHandler(this.NewspaperSimulation_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewspaperSimulation_MouseMove);
            this.pnlMain.ResumeLayout(false);
            this.pnlInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRestartAll;
        private System.Windows.Forms.Button btnPerformanceMeasure;
        private System.Windows.Forms.Button btnStartUpData;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel pnlInformation;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Label lblStatistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsdayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn RevenueFromSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn LostProfitFromExcessDemand;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalvageFromSalesOfScrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn DailyProfit;




    }
}

