namespace Newspaper
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemStartup));
            this.dgvNewsdaysDistribution = new System.Windows.Forms.DataGridView();
            this.TypeOfNewsDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlNewdaysTypesDistribution = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblServerNumber = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.nudScrap = new System.Windows.Forms.NumericUpDown();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblSimuRuns = new System.Windows.Forms.Label();
            this.nudFrom = new System.Windows.Forms.NumericUpDown();
            this.nudTo = new System.Windows.Forms.NumericUpDown();
            this.nudSellingPrice = new System.Windows.Forms.NumericUpDown();
            this.nudPurchasePrice = new System.Windows.Forms.NumericUpDown();
            this.lblScrapValue = new System.Windows.Forms.Label();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.pnlDemandDistribution = new System.Windows.Forms.Panel();
            this.dgvDemandDistribution = new System.Windows.Forms.DataGridView();
            this.Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Poor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Good = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewsdaysDistribution)).BeginInit();
            this.pnlNewdaysTypesDistribution.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScrap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSellingPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPurchasePrice)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.pnlDemandDistribution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemandDistribution)).BeginInit();
            this.pnl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNewsdaysDistribution
            // 
            this.dgvNewsdaysDistribution.BackgroundColor = System.Drawing.Color.White;
            this.dgvNewsdaysDistribution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNewsdaysDistribution.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNewsdaysDistribution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewsdaysDistribution.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeOfNewsDay,
            this.Probability});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNewsdaysDistribution.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNewsdaysDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNewsdaysDistribution.GridColor = System.Drawing.Color.DarkRed;
            this.dgvNewsdaysDistribution.Location = new System.Drawing.Point(0, 0);
            this.dgvNewsdaysDistribution.Name = "dgvNewsdaysDistribution";
            this.dgvNewsdaysDistribution.RowHeadersVisible = false;
            this.dgvNewsdaysDistribution.Size = new System.Drawing.Size(284, 189);
            this.dgvNewsdaysDistribution.TabIndex = 0;
            this.dgvNewsdaysDistribution.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.dgvNewsdaysDistribution.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // TypeOfNewsDay
            // 
            this.TypeOfNewsDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TypeOfNewsDay.HeaderText = "Type of Newsday";
            this.TypeOfNewsDay.MinimumWidth = 2;
            this.TypeOfNewsDay.Name = "TypeOfNewsDay";
            this.TypeOfNewsDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Probability
            // 
            this.Probability.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Probability.HeaderText = "Probability";
            this.Probability.MinimumWidth = 2;
            this.Probability.Name = "Probability";
            this.Probability.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlNewdaysTypesDistribution
            // 
            this.pnlNewdaysTypesDistribution.Controls.Add(this.dgvNewsdaysDistribution);
            this.pnlNewdaysTypesDistribution.Location = new System.Drawing.Point(0, 0);
            this.pnlNewdaysTypesDistribution.Name = "pnlNewdaysTypesDistribution";
            this.pnlNewdaysTypesDistribution.Size = new System.Drawing.Size(284, 189);
            this.pnlNewdaysTypesDistribution.TabIndex = 3;
            this.pnlNewdaysTypesDistribution.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.pnlNewdaysTypesDistribution.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.BackgroundImage = global::Newspaper.Properties.Resources._119499808318794028711rightarrow;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.Location = new System.Drawing.Point(241, 195);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 40);
            this.btnNext.TabIndex = 1;
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttMain.SetToolTip(this.btnNext, "Next Server");
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
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
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.nudScrap);
            this.pnlMain.Controls.Add(this.lblTo);
            this.pnlMain.Controls.Add(this.lblFrom);
            this.pnlMain.Controls.Add(this.lblSimuRuns);
            this.pnlMain.Controls.Add(this.nudFrom);
            this.pnlMain.Controls.Add(this.nudTo);
            this.pnlMain.Controls.Add(this.nudSellingPrice);
            this.pnlMain.Controls.Add(this.nudPurchasePrice);
            this.pnlMain.Controls.Add(this.lblScrapValue);
            this.pnlMain.Controls.Add(this.lblSellingPrice);
            this.pnlMain.Controls.Add(this.lblPurchasePrice);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(284, 189);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // nudScrap
            // 
            this.nudScrap.Location = new System.Drawing.Point(134, 157);
            this.nudScrap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScrap.Name = "nudScrap";
            this.nudScrap.Size = new System.Drawing.Size(106, 20);
            this.nudScrap.TabIndex = 10;
            this.nudScrap.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(155, 36);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(19, 13);
            this.lblTo.TabIndex = 9;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(44, 36);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(31, 13);
            this.lblFrom.TabIndex = 8;
            this.lblFrom.Text = "From";
            // 
            // lblSimuRuns
            // 
            this.lblSimuRuns.AutoSize = true;
            this.lblSimuRuns.Location = new System.Drawing.Point(8, 9);
            this.lblSimuRuns.Name = "lblSimuRuns";
            this.lblSimuRuns.Size = new System.Drawing.Size(118, 13);
            this.lblSimuRuns.TabIndex = 7;
            this.lblSimuRuns.Text = "Simulation Runs ( X10):";
            // 
            // nudFrom
            // 
            this.nudFrom.Location = new System.Drawing.Point(81, 34);
            this.nudFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFrom.Name = "nudFrom";
            this.nudFrom.Size = new System.Drawing.Size(51, 20);
            this.nudFrom.TabIndex = 2;
            this.nudFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFrom.ValueChanged += new System.EventHandler(this.nudRange_ValueChanged);
            // 
            // nudTo
            // 
            this.nudTo.Location = new System.Drawing.Point(189, 34);
            this.nudTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTo.Name = "nudTo";
            this.nudTo.Size = new System.Drawing.Size(51, 20);
            this.nudTo.TabIndex = 2;
            this.nudTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTo.ValueChanged += new System.EventHandler(this.nudRange_ValueChanged);
            // 
            // nudSellingPrice
            // 
            this.nudSellingPrice.Location = new System.Drawing.Point(151, 119);
            this.nudSellingPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSellingPrice.Name = "nudSellingPrice";
            this.nudSellingPrice.Size = new System.Drawing.Size(89, 20);
            this.nudSellingPrice.TabIndex = 2;
            this.nudSellingPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudPurchasePrice
            // 
            this.nudPurchasePrice.Location = new System.Drawing.Point(165, 78);
            this.nudPurchasePrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPurchasePrice.Name = "nudPurchasePrice";
            this.nudPurchasePrice.Size = new System.Drawing.Size(75, 20);
            this.nudPurchasePrice.TabIndex = 2;
            this.nudPurchasePrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPurchasePrice.ValueChanged += new System.EventHandler(this.nudPurchasePrice_ValueChanged);
            // 
            // lblScrapValue
            // 
            this.lblScrapValue.AutoSize = true;
            this.lblScrapValue.Location = new System.Drawing.Point(44, 159);
            this.lblScrapValue.Name = "lblScrapValue";
            this.lblScrapValue.Size = new System.Drawing.Size(84, 13);
            this.lblScrapValue.TabIndex = 1;
            this.lblScrapValue.Text = "Scrap Value (¢):";
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Location = new System.Drawing.Point(44, 121);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(84, 13);
            this.lblSellingPrice.TabIndex = 1;
            this.lblSellingPrice.Text = "Selling Price (¢):";
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(44, 80);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(98, 13);
            this.lblPurchasePrice.TabIndex = 1;
            this.lblPurchasePrice.Text = "Purchase Price (¢):";
            // 
            // tlpMain
            // 
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.pnl1, 0, 1);
            this.tlpMain.Controls.Add(this.pnl2, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.40614F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.59386F));
            this.tlpMain.Size = new System.Drawing.Size(293, 295);
            this.tlpMain.TabIndex = 7;
            this.tlpMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.tlpMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.pnlDemandDistribution);
            this.pnl1.Controls.Add(this.pnlMain);
            this.pnl1.Controls.Add(this.btnPrevious);
            this.pnl1.Controls.Add(this.btnNext);
            this.pnl1.Controls.Add(this.pnlNewdaysTypesDistribution);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(4, 55);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(285, 236);
            this.pnl1.TabIndex = 0;
            this.pnl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.pnl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // pnlDemandDistribution
            // 
            this.pnlDemandDistribution.Controls.Add(this.dgvDemandDistribution);
            this.pnlDemandDistribution.Location = new System.Drawing.Point(0, 0);
            this.pnlDemandDistribution.Name = "pnlDemandDistribution";
            this.pnlDemandDistribution.Size = new System.Drawing.Size(284, 189);
            this.pnlDemandDistribution.TabIndex = 8;
            // 
            // dgvDemandDistribution
            // 
            this.dgvDemandDistribution.BackgroundColor = System.Drawing.Color.White;
            this.dgvDemandDistribution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDemandDistribution.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDemandDistribution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDemandDistribution.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Demand,
            this.Poor,
            this.Fair,
            this.Good});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDemandDistribution.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDemandDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDemandDistribution.GridColor = System.Drawing.Color.DarkRed;
            this.dgvDemandDistribution.Location = new System.Drawing.Point(0, 0);
            this.dgvDemandDistribution.Name = "dgvDemandDistribution";
            this.dgvDemandDistribution.RowHeadersVisible = false;
            this.dgvDemandDistribution.Size = new System.Drawing.Size(284, 189);
            this.dgvDemandDistribution.TabIndex = 1;
            // 
            // Demand
            // 
            this.Demand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Demand.HeaderText = "Demand (Number)";
            this.Demand.MinimumWidth = 2;
            this.Demand.Name = "Demand";
            this.Demand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Poor
            // 
            this.Poor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Poor.HeaderText = "Poor";
            this.Poor.MinimumWidth = 2;
            this.Poor.Name = "Poor";
            this.Poor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Fair
            // 
            this.Fair.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fair.HeaderText = "Fair";
            this.Fair.MinimumWidth = 2;
            this.Fair.Name = "Fair";
            this.Fair.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Good
            // 
            this.Good.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Good.HeaderText = "Good";
            this.Good.MinimumWidth = 2;
            this.Good.Name = "Good";
            this.Good.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackgroundImage = global::Newspaper.Properties.Resources._119499808318794028711leftarrow;
            this.btnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrevious.Location = new System.Drawing.Point(3, 195);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(40, 40);
            this.btnPrevious.TabIndex = 5;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
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
            this.pnl2.Size = new System.Drawing.Size(285, 44);
            this.pnl2.TabIndex = 1;
            this.pnl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseDown);
            this.pnl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsMain_MouseMove);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.White;
            this.btnOpen.BackgroundImage = global::Newspaper.Properties.Resources.folder_open;
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
            this.btnClose.BackgroundImage = global::Newspaper.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
            this.btnFinish.BackgroundImage = global::Newspaper.Properties.Resources.done_icon_5;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFinish.Location = new System.Drawing.Point(200, 3);
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
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.BackgroundImage = global::Newspaper.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(43, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.UseVisualStyleBackColor = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewsdaysDistribution)).EndInit();
            this.pnlNewdaysTypesDistribution.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScrap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSellingPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPurchasePrice)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.pnlDemandDistribution.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemandDistribution)).EndInit();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNewsdaysDistribution;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.NumericUpDown nudPurchasePrice;
        private System.Windows.Forms.Panel pnlNewdaysTypesDistribution;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Label lblServerNumber;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown nudSellingPrice;
        private System.Windows.Forms.Label lblScrapValue;
        private System.Windows.Forms.Label lblSellingPrice;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOfNewsDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Probability;
        private System.Windows.Forms.Panel pnlDemandDistribution;
        private System.Windows.Forms.DataGridView dgvDemandDistribution;
        private System.Windows.Forms.DataGridViewTextBoxColumn Demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Poor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fair;
        private System.Windows.Forms.DataGridViewTextBoxColumn Good;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblSimuRuns;
        private System.Windows.Forms.NumericUpDown nudFrom;
        private System.Windows.Forms.NumericUpDown nudTo;
        private System.Windows.Forms.NumericUpDown nudScrap;
    }
}