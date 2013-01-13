namespace Bearing_Machine
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
            this.lblStatistics = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlBackground.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // zgcMain
            // 
            this.zgcMain.BackColor = System.Drawing.Color.Transparent;
            this.zgcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcMain.Location = new System.Drawing.Point(0, 64);
            this.zgcMain.Name = "zgcMain";
            this.zgcMain.ScrollGrace = 0D;
            this.zgcMain.ScrollMaxX = 0D;
            this.zgcMain.ScrollMaxY = 0D;
            this.zgcMain.ScrollMaxY2 = 0D;
            this.zgcMain.ScrollMinX = 0D;
            this.zgcMain.ScrollMinY = 0D;
            this.zgcMain.ScrollMinY2 = 0D;
            this.zgcMain.Size = new System.Drawing.Size(640, 308);
            this.zgcMain.TabIndex = 0;
            this.zgcMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.zgcMain_MouseDoubleClick);
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.White;
            this.pnlBackground.Controls.Add(this.zgcMain);
            this.pnlBackground.Controls.Add(this.pnlData);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(640, 372);
            this.pnlBackground.TabIndex = 1;
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.White;
            this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlData.Controls.Add(this.lblStatistics);
            this.pnlData.Controls.Add(this.btnClose);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(640, 64);
            this.pnlData.TabIndex = 1;
            this.pnlData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PerformanceMeasure_MouseDown);
            this.pnlData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PerformanceMeasure_MouseMove);
            // 
            // lblStatistics
            // 
            this.lblStatistics.BackColor = System.Drawing.Color.GreenYellow;
            this.lblStatistics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatistics.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatistics.Font = new System.Drawing.Font("Bodoni MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatistics.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblStatistics.Location = new System.Drawing.Point(11, 5);
            this.lblStatistics.Name = "lblStatistics";
            this.lblStatistics.Size = new System.Drawing.Size(515, 52);
            this.lblStatistics.TabIndex = 6;
            this.lblStatistics.Text = "Current Module";
            this.lblStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatistics.Click += new System.EventHandler(this.lblStatistics_Click);
            this.lblStatistics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PerformanceMeasure_MouseDown);
            this.lblStatistics.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PerformanceMeasure_MouseMove);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = global::Bearing_Machine.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Location = new System.Drawing.Point(577, 1);
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
            this.ClientSize = new System.Drawing.Size(640, 372);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PerformanceMeasure";
            this.Text = "PerformanceMeasure";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PerformanceMeasure_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PerformanceMeasure_MouseMove);
            this.pnlBackground.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zgcMain;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblStatistics;
    }
}