namespace Scanner
{
    partial class ScannerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScannerForm));
            this.lvTokens = new System.Windows.Forms.ListView();
            this.colToken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.rtxtCode = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTools = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.scData = new System.Windows.Forms.SplitContainer();
            this.pnlCodeTools = new System.Windows.Forms.Panel();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.scBackground = new System.Windows.Forms.SplitContainer();
            this.pbResize = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scData)).BeginInit();
            this.scData.Panel1.SuspendLayout();
            this.scData.Panel2.SuspendLayout();
            this.scData.SuspendLayout();
            this.pnlCodeTools.SuspendLayout();
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scBackground)).BeginInit();
            this.scBackground.Panel1.SuspendLayout();
            this.scBackground.Panel2.SuspendLayout();
            this.scBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResize)).BeginInit();
            this.SuspendLayout();
            // 
            // lvTokens
            // 
            this.lvTokens.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvTokens.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvTokens.AllowDrop = true;
            this.lvTokens.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colToken,
            this.colType,
            this.colCategory});
            this.lvTokens.FullRowSelect = true;
            this.lvTokens.GridLines = true;
            this.lvTokens.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTokens.HideSelection = false;
            this.lvTokens.HotTracking = true;
            this.lvTokens.HoverSelection = true;
            this.lvTokens.LabelEdit = true;
            this.lvTokens.LabelWrap = false;
            this.lvTokens.Location = new System.Drawing.Point(7, 3);
            this.lvTokens.Name = "lvTokens";
            this.lvTokens.Size = new System.Drawing.Size(344, 316);
            this.lvTokens.TabIndex = 3;
            this.ttMain.SetToolTip(this.lvTokens, "Tokens");
            this.lvTokens.UseCompatibleStateImageBehavior = false;
            this.lvTokens.View = System.Windows.Forms.View.Details;
            this.lvTokens.ItemActivate += new System.EventHandler(this.LvTokens_ItemActivate);
            this.lvTokens.SelectedIndexChanged += new System.EventHandler(this.LvTokens_SelectedIndexChanged);
            this.lvTokens.DragDrop += new System.Windows.Forms.DragEventHandler(this.Scanner_DragDrop);
            this.lvTokens.DragEnter += new System.Windows.Forms.DragEventHandler(this.Scanner_DragEnter);
            // 
            // colToken
            // 
            this.colToken.Text = "Token";
            // 
            // colType
            // 
            this.colType.Text = "Type";
            // 
            // colCategory
            // 
            this.colCategory.Text = "Category";
            // 
            // rtxtCode
            // 
            this.rtxtCode.AllowDrop = true;
            this.rtxtCode.AutoWordSelection = true;
            this.rtxtCode.BackColor = System.Drawing.Color.White;
            this.rtxtCode.HideSelection = false;
            this.rtxtCode.Location = new System.Drawing.Point(2, 3);
            this.rtxtCode.Name = "rtxtCode";
            this.rtxtCode.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtxtCode.Size = new System.Drawing.Size(290, 316);
            this.rtxtCode.TabIndex = 5;
            this.rtxtCode.Text = "";
            this.ttMain.SetToolTip(this.rtxtCode, "Write Your Code Or Open A File Then Tokenize");
            this.rtxtCode.WordWrap = false;
            this.rtxtCode.DragDrop += new System.Windows.Forms.DragEventHandler(this.Scanner_DragDrop);
            this.rtxtCode.DragEnter += new System.Windows.Forms.DragEventHandler(this.Scanner_DragEnter);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = global::Scanner.Properties.Resources.Close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(655, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 50);
            this.btnClose.TabIndex = 5;
            this.ttMain.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.BackgroundImage = global::Scanner.Properties.Resources.Open;
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Location = new System.Drawing.Point(7, 0);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(50, 50);
            this.btnOpen.TabIndex = 5;
            this.ttMain.SetToolTip(this.btnOpen, "Open a File in Text Box");
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackgroundImage = global::Scanner.Properties.Resources.Save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(58, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 50);
            this.btnSave.TabIndex = 5;
            this.ttMain.SetToolTip(this.btnSave, "Save the Text Box\'es Code");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnTools
            // 
            this.btnTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTools.BackgroundImage = global::Scanner.Properties.Resources.Tools;
            this.btnTools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTools.FlatAppearance.BorderSize = 0;
            this.btnTools.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTools.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTools.Location = new System.Drawing.Point(2, 2);
            this.btnTools.Name = "btnTools";
            this.btnTools.Size = new System.Drawing.Size(50, 50);
            this.btnTools.TabIndex = 5;
            this.ttMain.SetToolTip(this.btnTools, "Hide ToolBar");
            this.btnTools.UseVisualStyleBackColor = true;
            this.btnTools.Click += new System.EventHandler(this.BtnTools_Click);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRun.BackgroundImage = global::Scanner.Properties.Resources.Tokens;
            this.btnRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRun.FlatAppearance.BorderSize = 0;
            this.btnRun.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRun.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Location = new System.Drawing.Point(2, 141);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(50, 50);
            this.btnRun.TabIndex = 5;
            this.ttMain.SetToolTip(this.btnRun, "RunEvents Scanner");
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackgroundImage = global::Scanner.Properties.Resources.Clear;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PeachPuff;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(2, 273);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 50);
            this.btnClear.TabIndex = 5;
            this.ttMain.SetToolTip(this.btnClear, "Clear the Code Box");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Image = ((System.Drawing.Image)(resources.GetObject("lblStatus.Image")));
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Location = new System.Drawing.Point(7, 11);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(698, 51);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttMain.SetToolTip(this.lblStatus, "Compiler\'s Status");
            // 
            // scMain
            // 
            this.scMain.AllowDrop = true;
            this.scMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.AllowDrop = true;
            this.scMain.Panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.scMain.Panel1.Controls.Add(this.btnMinimize);
            this.scMain.Panel1.Controls.Add(this.btnClose);
            this.scMain.Panel1.Controls.Add(this.btnUndo);
            this.scMain.Panel1.Controls.Add(this.btnRedo);
            this.scMain.Panel1.Controls.Add(this.btnOpen);
            this.scMain.Panel1.Controls.Add(this.btnSave);
            this.scMain.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Scanner_DragDrop);
            this.scMain.Panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Scanner_DragEnter);
            this.scMain.Panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseDoubleClick);
            this.scMain.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseDown_Move);
            this.scMain.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseMove_Move);
            this.scMain.Panel1MinSize = 0;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.AllowDrop = true;
            this.scMain.Panel2.Controls.Add(this.scData);
            this.scMain.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Scanner_DragDrop);
            this.scMain.Panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Scanner_DragEnter);
            this.scMain.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseDown_Move);
            this.scMain.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseMove_Move);
            this.scMain.Size = new System.Drawing.Size(715, 385);
            this.scMain.SplitterDistance = 53;
            this.scMain.SplitterWidth = 1;
            this.scMain.TabIndex = 7;
            this.scMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.Scanner_DragDrop);
            this.scMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.Scanner_DragEnter);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackgroundImage = global::Scanner.Properties.Resources.Minimize;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(602, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(50, 50);
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnUndo.BackgroundImage = global::Scanner.Properties.Resources.Undo;
            this.btnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnUndo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Location = new System.Drawing.Point(299, 0);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(50, 50);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnRedo.BackgroundImage = global::Scanner.Properties.Resources.Redo;
            this.btnRedo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRedo.FlatAppearance.BorderSize = 0;
            this.btnRedo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRedo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedo.Location = new System.Drawing.Point(360, 0);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(50, 50);
            this.btnRedo.TabIndex = 5;
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.BtnRedo_Click);
            // 
            // scData
            // 
            this.scData.AllowDrop = true;
            this.scData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scData.Location = new System.Drawing.Point(0, 0);
            this.scData.Name = "scData";
            // 
            // scData.Panel1
            // 
            this.scData.Panel1.AllowDrop = true;
            this.scData.Panel1.BackColor = System.Drawing.Color.White;
            this.scData.Panel1.Controls.Add(this.pnlCodeTools);
            this.scData.Panel1.Controls.Add(this.rtxtCode);
            this.scData.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Scanner_DragDrop);
            this.scData.Panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Scanner_DragEnter);
            this.scData.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseDown_Move);
            this.scData.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseMove_Move);
            this.scData.Panel1MinSize = 150;
            // 
            // scData.Panel2
            // 
            this.scData.Panel2.AllowDrop = true;
            this.scData.Panel2.BackColor = System.Drawing.Color.White;
            this.scData.Panel2.Controls.Add(this.lvTokens);
            this.scData.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Scanner_DragDrop);
            this.scData.Panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Scanner_DragEnter);
            this.scData.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseDown_Move);
            this.scData.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseMove_Move);
            this.scData.Panel2MinSize = 100;
            this.scData.Size = new System.Drawing.Size(711, 327);
            this.scData.SplitterDistance = 352;
            this.scData.SplitterWidth = 1;
            this.scData.TabIndex = 5;
            this.scData.DragDrop += new System.Windows.Forms.DragEventHandler(this.Scanner_DragDrop);
            this.scData.DragEnter += new System.Windows.Forms.DragEventHandler(this.Scanner_DragEnter);
            // 
            // pnlCodeTools
            // 
            this.pnlCodeTools.Controls.Add(this.btnTools);
            this.pnlCodeTools.Controls.Add(this.btnRun);
            this.pnlCodeTools.Controls.Add(this.btnClear);
            this.pnlCodeTools.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCodeTools.Location = new System.Drawing.Point(296, 0);
            this.pnlCodeTools.Name = "pnlCodeTools";
            this.pnlCodeTools.Size = new System.Drawing.Size(54, 325);
            this.pnlCodeTools.TabIndex = 6;
            this.pnlCodeTools.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseDown_Move);
            this.pnlCodeTools.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseMove_Move);
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBackground.Controls.Add(this.scBackground);
            this.pnlBackground.Controls.Add(this.pbResize);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(723, 464);
            this.pnlBackground.TabIndex = 8;
            this.pnlBackground.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseDoubleClick);
            // 
            // scBackground
            // 
            this.scBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scBackground.IsSplitterFixed = true;
            this.scBackground.Location = new System.Drawing.Point(1, 1);
            this.scBackground.Name = "scBackground";
            this.scBackground.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scBackground.Panel1
            // 
            this.scBackground.Panel1.Controls.Add(this.scMain);
            // 
            // scBackground.Panel2
            // 
            this.scBackground.Panel2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.scBackground.Panel2.Controls.Add(this.lblStatus);
            this.scBackground.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseDown_Move);
            this.scBackground.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseMove_Move);
            this.scBackground.Size = new System.Drawing.Size(715, 456);
            this.scBackground.SplitterDistance = 385;
            this.scBackground.SplitterWidth = 1;
            this.scBackground.TabIndex = 9;
            // 
            // pbResize
            // 
            this.pbResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbResize.BackColor = System.Drawing.Color.Transparent;
            this.pbResize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pbResize.Image = global::Scanner.Properties.Resources.CornerDrag;
            this.pbResize.Location = new System.Drawing.Point(713, 454);
            this.pbResize.Name = "pbResize";
            this.pbResize.Size = new System.Drawing.Size(7, 7);
            this.pbResize.TabIndex = 8;
            this.pbResize.TabStop = false;
            this.pbResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseDown_Resize);
            this.pbResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scanner_MouseMove_Resize);
            // 
            // ScannerForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(723, 464);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "ScannerForm";
            this.Text = "ScannerForm";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Scanner_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Scanner_DragEnter);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scData.Panel1.ResumeLayout(false);
            this.scData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scData)).EndInit();
            this.scData.ResumeLayout(false);
            this.pnlCodeTools.ResumeLayout(false);
            this.pnlBackground.ResumeLayout(false);
            this.scBackground.Panel1.ResumeLayout(false);
            this.scBackground.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBackground)).EndInit();
            this.scBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbResize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvTokens;
        private System.Windows.Forms.ColumnHeader colToken;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer scData;
        private System.Windows.Forms.RichTextBox rtxtCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnTools;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Panel pnlCodeTools;
        private System.Windows.Forms.PictureBox pbResize;
        private System.Windows.Forms.SplitContainer scBackground;
        private System.Windows.Forms.Label lblStatus;
    }
}

