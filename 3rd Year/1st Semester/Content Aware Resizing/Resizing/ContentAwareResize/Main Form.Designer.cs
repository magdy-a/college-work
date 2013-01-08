namespace Content_Aware
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnOpen = new System.Windows.Forms.Button();
			this.lblnewHeight = new System.Windows.Forms.Label();
			this.txtNewWidth = new System.Windows.Forms.TextBox();
			this.txtNewHeight = new System.Windows.Forms.TextBox();
			this.lblOriginalWidth = new System.Windows.Forms.Label();
			this.lblOriginalHeight = new System.Windows.Forms.Label();
			this.lblnewWidth = new System.Windows.Forms.Label();
			this.btnEnergyImage = new System.Windows.Forms.Button();
			this.btnContentAwareBackward = new System.Windows.Forms.Button();
			this.btnNormalResizing = new System.Windows.Forms.Button();
			this.gbDimensions = new System.Windows.Forms.GroupBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainPictureBox = new System.Windows.Forms.PictureBox();
			this.lblClock = new System.Windows.Forms.Label();
			this.lblMinEnergy = new System.Windows.Forms.Label();
			this.btnOriginalImage = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblC = new System.Windows.Forms.Label();
			this.lblM = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rbDirect = new System.Windows.Forms.RadioButton();
			this.rbGreedy = new System.Windows.Forms.RadioButton();
			this.rbDP = new System.Windows.Forms.RadioButton();
			this.pbProgress = new System.Windows.Forms.ProgressBar();
			this.btnContentAwareForward = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.gbMoreOptions = new System.Windows.Forms.GroupBox();
			this.cbColour = new System.Windows.Forms.CheckBox();
			this.cbAnimate = new System.Windows.Forms.CheckBox();
			this.gbDimensions.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gbMoreOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.BackColor = System.Drawing.Color.Linen;
			this.btnOpen.BackgroundImage = global::Content_Aware.Properties.Resources.open__2_;
			this.btnOpen.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOpen.Location = new System.Drawing.Point(82, 15);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(87, 50);
			this.btnOpen.TabIndex = 4;
			this.btnOpen.UseVisualStyleBackColor = false;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// lblnewHeight
			// 
			this.lblnewHeight.AutoSize = true;
			this.lblnewHeight.BackColor = System.Drawing.Color.Transparent;
			this.lblnewHeight.ForeColor = System.Drawing.Color.Black;
			this.lblnewHeight.Location = new System.Drawing.Point(13, 65);
			this.lblnewHeight.Name = "lblnewHeight";
			this.lblnewHeight.Size = new System.Drawing.Size(73, 13);
			this.lblnewHeight.TabIndex = 3;
			this.lblnewHeight.Text = "New Height";
			// 
			// txtNewWidth
			// 
			this.txtNewWidth.BackColor = System.Drawing.Color.Linen;
			this.txtNewWidth.Location = new System.Drawing.Point(92, 22);
			this.txtNewWidth.Name = "txtNewWidth";
			this.txtNewWidth.Size = new System.Drawing.Size(100, 20);
			this.txtNewWidth.TabIndex = 0;
			this.txtNewWidth.TextChanged += new System.EventHandler(this.txtNewWidth_TextChanged);
			// 
			// txtNewHeight
			// 
			this.txtNewHeight.BackColor = System.Drawing.Color.Linen;
			this.txtNewHeight.Location = new System.Drawing.Point(92, 62);
			this.txtNewHeight.Name = "txtNewHeight";
			this.txtNewHeight.Size = new System.Drawing.Size(100, 20);
			this.txtNewHeight.TabIndex = 1;
			this.txtNewHeight.TextChanged += new System.EventHandler(this.txtNewHeight_TextChanged);
			// 
			// lblOriginalWidth
			// 
			this.lblOriginalWidth.AutoSize = true;
			this.lblOriginalWidth.BackColor = System.Drawing.Color.Transparent;
			this.lblOriginalWidth.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOriginalWidth.ForeColor = System.Drawing.Color.Black;
			this.lblOriginalWidth.Location = new System.Drawing.Point(92, 46);
			this.lblOriginalWidth.Name = "lblOriginalWidth";
			this.lblOriginalWidth.Size = new System.Drawing.Size(86, 13);
			this.lblOriginalWidth.TabIndex = 5;
			this.lblOriginalWidth.Text = "Original Width";
			this.lblOriginalWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblOriginalHeight
			// 
			this.lblOriginalHeight.AutoSize = true;
			this.lblOriginalHeight.BackColor = System.Drawing.Color.Transparent;
			this.lblOriginalHeight.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOriginalHeight.ForeColor = System.Drawing.Color.Black;
			this.lblOriginalHeight.Location = new System.Drawing.Point(92, 85);
			this.lblOriginalHeight.Name = "lblOriginalHeight";
			this.lblOriginalHeight.Size = new System.Drawing.Size(90, 13);
			this.lblOriginalHeight.TabIndex = 5;
			this.lblOriginalHeight.Text = "Original Height";
			// 
			// lblnewWidth
			// 
			this.lblnewWidth.AutoSize = true;
			this.lblnewWidth.BackColor = System.Drawing.Color.Transparent;
			this.lblnewWidth.ForeColor = System.Drawing.Color.Black;
			this.lblnewWidth.Location = new System.Drawing.Point(17, 25);
			this.lblnewWidth.Name = "lblnewWidth";
			this.lblnewWidth.Size = new System.Drawing.Size(69, 13);
			this.lblnewWidth.TabIndex = 6;
			this.lblnewWidth.Text = "New Width";
			// 
			// btnEnergyImage
			// 
			this.btnEnergyImage.BackColor = System.Drawing.Color.Linen;
			this.btnEnergyImage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEnergyImage.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnEnergyImage.Location = new System.Drawing.Point(175, 59);
			this.btnEnergyImage.Name = "btnEnergyImage";
			this.btnEnergyImage.Size = new System.Drawing.Size(58, 50);
			this.btnEnergyImage.TabIndex = 3;
			this.btnEnergyImage.Text = "Energy Image";
			this.btnEnergyImage.UseVisualStyleBackColor = false;
			this.btnEnergyImage.Click += new System.EventHandler(this.btnEnergyImage_Click);
			// 
			// btnContentAwareBackward
			// 
			this.btnContentAwareBackward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnContentAwareBackward.BackColor = System.Drawing.Color.Linen;
			this.btnContentAwareBackward.Font = new System.Drawing.Font("Californian FB", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnContentAwareBackward.ForeColor = System.Drawing.Color.Black;
			this.btnContentAwareBackward.Location = new System.Drawing.Point(132, 19);
			this.btnContentAwareBackward.Name = "btnContentAwareBackward";
			this.btnContentAwareBackward.Size = new System.Drawing.Size(110, 52);
			this.btnContentAwareBackward.TabIndex = 0;
			this.btnContentAwareBackward.Text = "Backward";
			this.btnContentAwareBackward.UseVisualStyleBackColor = false;
			this.btnContentAwareBackward.Click += new System.EventHandler(this.btnContentAwareBackward_Click);
			// 
			// btnNormalResizing
			// 
			this.btnNormalResizing.BackColor = System.Drawing.Color.Linen;
			this.btnNormalResizing.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNormalResizing.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnNormalResizing.Location = new System.Drawing.Point(18, 59);
			this.btnNormalResizing.Name = "btnNormalResizing";
			this.btnNormalResizing.Size = new System.Drawing.Size(58, 50);
			this.btnNormalResizing.TabIndex = 1;
			this.btnNormalResizing.Text = "Normal Resizing";
			this.btnNormalResizing.UseVisualStyleBackColor = false;
			this.btnNormalResizing.Click += new System.EventHandler(this.btnNormalResizing_Click);
			// 
			// gbDimensions
			// 
			this.gbDimensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gbDimensions.BackColor = System.Drawing.Color.Transparent;
			this.gbDimensions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.gbDimensions.Controls.Add(this.lblnewWidth);
			this.gbDimensions.Controls.Add(this.lblOriginalHeight);
			this.gbDimensions.Controls.Add(this.lblOriginalWidth);
			this.gbDimensions.Controls.Add(this.txtNewHeight);
			this.gbDimensions.Controls.Add(this.txtNewWidth);
			this.gbDimensions.Controls.Add(this.lblnewHeight);
			this.gbDimensions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.gbDimensions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbDimensions.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.gbDimensions.Location = new System.Drawing.Point(922, 291);
			this.gbDimensions.Name = "gbDimensions";
			this.gbDimensions.Size = new System.Drawing.Size(248, 117);
			this.gbDimensions.TabIndex = 12;
			this.gbDimensions.TabStop = false;
			this.gbDimensions.Text = "Dimensions";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1185, 24);
			this.menuStrip1.TabIndex = 15;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// MainPictureBox
			// 
			this.MainPictureBox.BackColor = System.Drawing.Color.Transparent;
			this.MainPictureBox.Location = new System.Drawing.Point(12, 41);
			this.MainPictureBox.Name = "MainPictureBox";
			this.MainPictureBox.Size = new System.Drawing.Size(100, 100);
			this.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.MainPictureBox.TabIndex = 0;
			this.MainPictureBox.TabStop = false;
			this.MainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseMove);
			this.MainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseDown);
			this.MainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseUp);
			// 
			// lblClock
			// 
			this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblClock.AutoSize = true;
			this.lblClock.BackColor = System.Drawing.Color.Linen;
			this.lblClock.Location = new System.Drawing.Point(922, 448);
			this.lblClock.Name = "lblClock";
			this.lblClock.Size = new System.Drawing.Size(34, 13);
			this.lblClock.TabIndex = 16;
			this.lblClock.Text = "Clock";
			// 
			// lblMinEnergy
			// 
			this.lblMinEnergy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinEnergy.AutoSize = true;
			this.lblMinEnergy.BackColor = System.Drawing.Color.Linen;
			this.lblMinEnergy.Location = new System.Drawing.Point(1029, 448);
			this.lblMinEnergy.Name = "lblMinEnergy";
			this.lblMinEnergy.Size = new System.Drawing.Size(57, 13);
			this.lblMinEnergy.TabIndex = 17;
			this.lblMinEnergy.Text = "MinEnergy";
			// 
			// btnOriginalImage
			// 
			this.btnOriginalImage.BackColor = System.Drawing.Color.Linen;
			this.btnOriginalImage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOriginalImage.ForeColor = System.Drawing.Color.Black;
			this.btnOriginalImage.Location = new System.Drawing.Point(82, 71);
			this.btnOriginalImage.Name = "btnOriginalImage";
			this.btnOriginalImage.Size = new System.Drawing.Size(87, 38);
			this.btnOriginalImage.TabIndex = 2;
			this.btnOriginalImage.Text = "Original Image";
			this.btnOriginalImage.UseVisualStyleBackColor = false;
			this.btnOriginalImage.Click += new System.EventHandler(this.btnOriginalImage_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.btnOriginalImage);
			this.groupBox1.Controls.Add(this.btnEnergyImage);
			this.groupBox1.Controls.Add(this.btnOpen);
			this.groupBox1.Controls.Add(this.btnNormalResizing);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.groupBox1.Location = new System.Drawing.Point(922, 41);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(248, 114);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Operations";
			// 
			// lblC
			// 
			this.lblC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblC.AutoSize = true;
			this.lblC.BackColor = System.Drawing.Color.Linen;
			this.lblC.Location = new System.Drawing.Point(922, 420);
			this.lblC.Name = "lblC";
			this.lblC.Size = new System.Drawing.Size(64, 13);
			this.lblC.TabIndex = 20;
			this.lblC.Text = "Time Taken";
			// 
			// lblM
			// 
			this.lblM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblM.AutoSize = true;
			this.lblM.BackColor = System.Drawing.Color.Linen;
			this.lblM.Location = new System.Drawing.Point(1029, 420);
			this.lblM.Name = "lblM";
			this.lblM.Size = new System.Drawing.Size(67, 13);
			this.lblM.TabIndex = 21;
			this.lblM.Text = "Total Energy";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.BackColor = System.Drawing.Color.Transparent;
			this.groupBox3.Controls.Add(this.rbDirect);
			this.groupBox3.Controls.Add(this.rbGreedy);
			this.groupBox3.Controls.Add(this.rbDP);
			this.groupBox3.Location = new System.Drawing.Point(923, 244);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(248, 41);
			this.groupBox3.TabIndex = 25;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Algorithm";
			// 
			// rbDirect
			// 
			this.rbDirect.AutoSize = true;
			this.rbDirect.BackColor = System.Drawing.Color.Linen;
			this.rbDirect.Location = new System.Drawing.Point(180, 18);
			this.rbDirect.Name = "rbDirect";
			this.rbDirect.Size = new System.Drawing.Size(53, 17);
			this.rbDirect.TabIndex = 2;
			this.rbDirect.Text = "Direct";
			this.rbDirect.UseVisualStyleBackColor = false;
			// 
			// rbGreedy
			// 
			this.rbGreedy.AutoSize = true;
			this.rbGreedy.BackColor = System.Drawing.Color.Linen;
			this.rbGreedy.Checked = true;
			this.rbGreedy.Location = new System.Drawing.Point(92, 18);
			this.rbGreedy.Name = "rbGreedy";
			this.rbGreedy.Size = new System.Drawing.Size(59, 17);
			this.rbGreedy.TabIndex = 1;
			this.rbGreedy.TabStop = true;
			this.rbGreedy.Text = "Greedy";
			this.rbGreedy.UseVisualStyleBackColor = false;
			// 
			// rbDP
			// 
			this.rbDP.AutoSize = true;
			this.rbDP.BackColor = System.Drawing.Color.Linen;
			this.rbDP.Location = new System.Drawing.Point(18, 18);
			this.rbDP.Name = "rbDP";
			this.rbDP.Size = new System.Drawing.Size(40, 17);
			this.rbDP.TabIndex = 0;
			this.rbDP.Text = "DP";
			this.rbDP.UseVisualStyleBackColor = false;
			// 
			// pbProgress
			// 
			this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbProgress.BackColor = System.Drawing.Color.Linen;
			this.pbProgress.ForeColor = System.Drawing.Color.DodgerBlue;
			this.pbProgress.Location = new System.Drawing.Point(922, 475);
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(251, 25);
			this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pbProgress.TabIndex = 26;
			// 
			// btnContentAwareForward
			// 
			this.btnContentAwareForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnContentAwareForward.BackColor = System.Drawing.Color.Linen;
			this.btnContentAwareForward.Font = new System.Drawing.Font("Californian FB", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnContentAwareForward.ForeColor = System.Drawing.Color.Black;
			this.btnContentAwareForward.Location = new System.Drawing.Point(6, 19);
			this.btnContentAwareForward.Name = "btnContentAwareForward";
			this.btnContentAwareForward.Size = new System.Drawing.Size(110, 52);
			this.btnContentAwareForward.TabIndex = 27;
			this.btnContentAwareForward.Text = "Forward";
			this.btnContentAwareForward.UseVisualStyleBackColor = false;
			this.btnContentAwareForward.Click += new System.EventHandler(this.btnContentAwareForward_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.btnContentAwareBackward);
			this.groupBox2.Controls.Add(this.btnContentAwareForward);
			this.groupBox2.Location = new System.Drawing.Point(922, 161);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(248, 77);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Content Aware Resizing";
			// 
			// gbMoreOptions
			// 
			this.gbMoreOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gbMoreOptions.Controls.Add(this.cbColour);
			this.gbMoreOptions.Controls.Add(this.cbAnimate);
			this.gbMoreOptions.Location = new System.Drawing.Point(1102, 410);
			this.gbMoreOptions.Name = "gbMoreOptions";
			this.gbMoreOptions.Size = new System.Drawing.Size(71, 59);
			this.gbMoreOptions.TabIndex = 29;
			this.gbMoreOptions.TabStop = false;
			this.gbMoreOptions.Text = "More";
			// 
			// cbColour
			// 
			this.cbColour.AutoSize = true;
			this.cbColour.Checked = true;
			this.cbColour.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbColour.Location = new System.Drawing.Point(5, 37);
			this.cbColour.Name = "cbColour";
			this.cbColour.Size = new System.Drawing.Size(56, 17);
			this.cbColour.TabIndex = 1;
			this.cbColour.Text = "Colour";
			this.cbColour.UseVisualStyleBackColor = true;
			// 
			// cbAnimate
			// 
			this.cbAnimate.AutoSize = true;
			this.cbAnimate.Checked = true;
			this.cbAnimate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbAnimate.Location = new System.Drawing.Point(5, 19);
			this.cbAnimate.Name = "cbAnimate";
			this.cbAnimate.Size = new System.Drawing.Size(64, 17);
			this.cbAnimate.TabIndex = 0;
			this.cbAnimate.Text = "Animate";
			this.cbAnimate.UseVisualStyleBackColor = true;
			this.cbAnimate.CheckedChanged += new System.EventHandler(this.cbAnimate_CheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1185, 611);
			this.Controls.Add(this.gbMoreOptions);
			this.Controls.Add(this.pbProgress);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.lblM);
			this.Controls.Add(this.lblC);
			this.Controls.Add(this.lblMinEnergy);
			this.Controls.Add(this.lblClock);
			this.Controls.Add(this.gbDimensions);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.MainPictureBox);
			this.Controls.Add(this.groupBox2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Resizing";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.gbDimensions.ResumeLayout(false);
			this.gbDimensions.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.gbMoreOptions.ResumeLayout(false);
			this.gbMoreOptions.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Label lblnewHeight;
		private System.Windows.Forms.TextBox txtNewWidth;
		private System.Windows.Forms.TextBox txtNewHeight;
		private System.Windows.Forms.Label lblOriginalWidth;
		private System.Windows.Forms.Label lblOriginalHeight;
		private System.Windows.Forms.Label lblnewWidth;
		private System.Windows.Forms.Button btnEnergyImage;
		private System.Windows.Forms.Button btnContentAwareBackward;
		private System.Windows.Forms.Button btnContentAwareForward;
		private System.Windows.Forms.Button btnNormalResizing;
		private System.Windows.Forms.GroupBox gbDimensions;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		public System.Windows.Forms.PictureBox MainPictureBox;
		private System.Windows.Forms.Label lblClock;
		private System.Windows.Forms.Label lblMinEnergy;
		private System.Windows.Forms.Button btnOriginalImage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblC;
		private System.Windows.Forms.Label lblM;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbDirect;
		private System.Windows.Forms.RadioButton rbGreedy;
		private System.Windows.Forms.RadioButton rbDP;
		private System.Windows.Forms.ProgressBar pbProgress;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox gbMoreOptions;
		private System.Windows.Forms.CheckBox cbColour;
		private System.Windows.Forms.CheckBox cbAnimate;
	}
}