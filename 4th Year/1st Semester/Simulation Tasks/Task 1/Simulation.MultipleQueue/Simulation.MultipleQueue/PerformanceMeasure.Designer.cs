namespace MultipleQueue
{
    partial class PerformanceMeasure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformanceMeasure));
            this.zgcMain = new ZedGraph.ZedGraphControl();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlData = new System.Windows.Forms.Panel();
            this.btnDraw = new System.Windows.Forms.Button();
            this.txtPerformanceMeasure = new System.Windows.Forms.TextBox();
            this.lblViewType = new System.Windows.Forms.Label();
            this.lblChartType = new System.Windows.Forms.Label();
            this.cmbViewType = new System.Windows.Forms.ComboBox();
            this.cmbChartType = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlBackground.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // zgcMain
            // 
            this.zgcMain.Location = new System.Drawing.Point(0, 63);
            this.zgcMain.Name = "zgcMain";
            this.zgcMain.ScrollGrace = 0D;
            this.zgcMain.ScrollMaxX = 0D;
            this.zgcMain.ScrollMaxY = 0D;
            this.zgcMain.ScrollMaxY2 = 0D;
            this.zgcMain.ScrollMinX = 0D;
            this.zgcMain.ScrollMinY = 0D;
            this.zgcMain.ScrollMinY2 = 0D;
            this.zgcMain.Size = new System.Drawing.Size(605, 313);
            this.zgcMain.TabIndex = 0;
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.White;
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackground.Controls.Add(this.zgcMain);
            this.pnlBackground.Controls.Add(this.pnlData);
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(607, 374);
            this.pnlBackground.TabIndex = 1;
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.White;
            this.pnlData.Controls.Add(this.btnDraw);
            this.pnlData.Controls.Add(this.txtPerformanceMeasure);
            this.pnlData.Controls.Add(this.lblViewType);
            this.pnlData.Controls.Add(this.lblChartType);
            this.pnlData.Controls.Add(this.cmbViewType);
            this.pnlData.Controls.Add(this.cmbChartType);
            this.pnlData.Controls.Add(this.btnClose);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(605, 65);
            this.pnlData.TabIndex = 1;
            this.pnlData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PerformanceMeasure_MouseDown);
            this.pnlData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PerformanceMeasure_MouseMove);
            // 
            // btnDraw
            // 
            this.btnDraw.BackgroundImage = global::MultipleQueue.Properties.Resources.go___;
            this.btnDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDraw.Location = new System.Drawing.Point(229, 3);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(60, 60);
            this.btnDraw.TabIndex = 4;
            this.btnDraw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // txtPerformanceMeasure
            // 
            this.txtPerformanceMeasure.BackColor = System.Drawing.Color.White;
            this.txtPerformanceMeasure.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPerformanceMeasure.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtPerformanceMeasure.Location = new System.Drawing.Point(335, 0);
            this.txtPerformanceMeasure.Multiline = true;
            this.txtPerformanceMeasure.Name = "txtPerformanceMeasure";
            this.txtPerformanceMeasure.ReadOnly = true;
            this.txtPerformanceMeasure.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPerformanceMeasure.Size = new System.Drawing.Size(170, 63);
            this.txtPerformanceMeasure.TabIndex = 2;
            this.txtPerformanceMeasure.WordWrap = false;
            // 
            // lblViewType
            // 
            this.lblViewType.AutoSize = true;
            this.lblViewType.Location = new System.Drawing.Point(3, 44);
            this.lblViewType.Name = "lblViewType";
            this.lblViewType.Size = new System.Drawing.Size(60, 13);
            this.lblViewType.TabIndex = 3;
            this.lblViewType.Text = "View Type:";
            // 
            // lblChartType
            // 
            this.lblChartType.AutoSize = true;
            this.lblChartType.Location = new System.Drawing.Point(3, 8);
            this.lblChartType.Name = "lblChartType";
            this.lblChartType.Size = new System.Drawing.Size(68, 13);
            this.lblChartType.TabIndex = 3;
            this.lblChartType.Text = "Chart Type: ";
            // 
            // cmbViewType
            // 
            this.cmbViewType.FormattingEnabled = true;
            this.cmbViewType.Location = new System.Drawing.Point(77, 41);
            this.cmbViewType.Name = "cmbViewType";
            this.cmbViewType.Size = new System.Drawing.Size(121, 21);
            this.cmbViewType.TabIndex = 1;
            this.cmbViewType.SelectedIndexChanged += new System.EventHandler(this.btnDraw_Click);
            // 
            // cmbChartType
            // 
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.Location = new System.Drawing.Point(77, 5);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(121, 21);
            this.cmbChartType.TabIndex = 1;
            this.cmbChartType.SelectedIndexChanged += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = global::MultipleQueue.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Location = new System.Drawing.Point(542, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 60);
            this.btnClose.TabIndex = 0;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PerformanceMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 374);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PerformanceMeasure";
            this.Text = "PerformanceMeasure";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PerformanceMeasure_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PerformanceMeasure_MouseMove);
            this.pnlBackground.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zgcMain;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbChartType;
        private System.Windows.Forms.Label lblChartType;
        private System.Windows.Forms.TextBox txtPerformanceMeasure;
        private System.Windows.Forms.Label lblViewType;
        private System.Windows.Forms.ComboBox cmbViewType;
        private System.Windows.Forms.Button btnDraw;
    }
}