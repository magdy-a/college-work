namespace Scanner
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Scanner Form, the UI
    /// </summary>
    public partial class ScannerForm : Form
    {
        #region Members

        /// <summary>
        /// The Last Location of mouse down, used in Moving the form
        /// </summary>
        private Point movingMouseDownLocation;

        /// <summary>
        /// The Last Location of mouse down, used to resize the form
        /// </summary>
        private Point resizingMouseDownLocation;

        /// <summary>
        /// Scanner Object
        /// </summary>
        private Scanner scanner;

        /// <summary>
        /// A boolean indication to the Functionality of RunEvents Button
        /// </summary>
        private bool toTokens;

        #endregion Members

        // TODO Make More than one Status Label, on for the Overall Statistics, one for the active respond

        /// <summary>
        /// Initializes a new instance of the ScannerForm class
        /// </summary>
        public ScannerForm()
        {
            this.InitializeComponent();

            //// Set BackColors
            this.pnlBackground.BackColor = Color.RosyBrown;
            this.scMain.BackColor = Color.RosyBrown;
            this.scData.BackColor = Color.RosyBrown;

            //// Set the Min&Max Boundaries
            this.MinimumSize = new Size(400, 300);
            this.MaximumSize = Screen.AllScreens[0].WorkingArea.Size;

            //// Create an Object from Scanner Class
            this.scanner = new Scanner();

            //// Set Values for the ListView
            this.lvTokens.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            this.lvTokens.AllowColumnReorder = false;
            foreach (ColumnHeader ch in this.lvTokens.Columns)
            {
                ch.TextAlign = HorizontalAlignment.Center;
            }

            //// Set the Initial Form Event Values
            this.toTokens = true;

            //// Set Image for the Picture Box
            this.pbResize.Image = Properties.Resources.CornerDrag.GetThumbnailImage(this.pbResize.Width, this.pbResize.Height, null, IntPtr.Zero);

            //// Set Image for Label Status
            this.lblStatus.Image = this.lblStatus.Image.GetThumbnailImage(this.lblStatus.Height, this.lblStatus.Height, null, IntPtr.Zero);

            //// Open a start up File
            this.rtxtCode.Text = "A = 5;\nB = 4;\nA = B * A + 3 * B;\nB = A / 3 + 4 * B;\nIf(A < B)\n\tWrite(A);\nElse\n\tWrite(B);\nEnd";
            ////this.rtxtCode.Text = "if then else end repeat until read write\n\n( ) ;\n\n+ - * / = < >\n\n:= ++ -- *= /= += -= <= >=";

            this.BtnRun_Click(null, null);
        }

        /// <summary>
        /// RunEvents the Scanner Code Here, set the Form Values
        /// </summary>
        private void RunScanner()
        {
            // Create a tmp ListViewItem
            ListViewItem tmpItem;

            // Set Code in Scanner
            this.scanner.FileCode = this.rtxtCode.Text;

            // RunEvents the Scanner
            this.scanner.Run();

            // Clear the List
            this.lvTokens.Items.Clear();

            foreach (Token tok in this.scanner.GeneratedTokens)
            {
                // Create a new Item with the current Token
                tmpItem = new ListViewItem(new string[] { tok.TokenRepresenation, tok.Name.ToString(), tok.Category.ToString() });

                // TODO Why not make this colors customizable from the form, so user can change them, also they would be in an XML file, so they don't change next run
                if (tok.Category == TokenCategory.ReservedWord)
                {
                    tmpItem.BackColor = Color.GreenYellow;
                    //// tmpItem.BackColor = Color.LightGoldenrodYellow;
                }
                else if (tok.Category == TokenCategory.SpecialSymbol)
                {
                    tmpItem.BackColor = Color.LightGreen;
                    //// tmpItem.BackColor = Color.AliceBlue;
                }
                else if (tok.Name == TokenType.Error)
                {
                    tmpItem.BackColor = Color.Red;
                }
                else if (tok.Name == TokenType.EndFile)
                {
                    tmpItem.BackColor = Color.DarkGray;
                }

                // Add it to the List
                this.lvTokens.Items.Add(tmpItem);
            }

            // Set Auto Resize to ColumnContent
            this.lvTokens.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /// <summary>
        /// Searches for a Token in the Input Code, with token Index
        /// </summary>
        /// <param name="tokenIndex">Token Index</param>
        /// <returns>First Char Index in the Token in Input Code</returns>
        private int FindInCode(int tokenIndex)
        {
            int index = 0, indexInClearCode = 0;

            if (this.rtxtCode.Text == string.Empty)
            {
                return 0;
            }

            // Get Number of Chars in all the tokens before this one (Get index in Clear Code that is without any splitters)
            for (int i = 0; i < tokenIndex; i++)
            {
                indexInClearCode += this.scanner.GeneratedTokens[i].TokenRepresenation.Length;
            }

            // Loop all chars in the code, if the char isn't a splitter, decrement the index in clear code by one, until you reach zero, if zero you are there
            for (index = 0; index < this.rtxtCode.Text.Length && indexInClearCode >= 0; index++)
            {
                if (!Scanner.Separators.Contains(this.rtxtCode.Text[index]))
                {
                    indexInClearCode -= 1;
                }
            }

            if (index > 0)
            {
                index--;
            }

            return index;
        }

        /// <summary>
        /// Opens the File, reads it and shows the data on the Form
        /// </summary>
        /// <param name="path">The Path of the File to Open</param>
        private void OpenMyFile(string path)
        {
            // Create Stream Objects
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                // Read the File, in a one big string, then Show the Code on the Form
                this.rtxtCode.Text = sr.ReadToEnd();

                // Run the Code
                this.RunScanner();
                this.toTokens = false;

                this.lblStatus.Text = string.Format("File \"{0}\" opened successfully", path);

                this.RunEvents();
            }
            catch
            {
            }
            finally
            {
                // Close
                if (fs != null && fs.CanRead)
                {
                    sr.Close();
                    fs.Close();
                }
            }
        }

        #region Events

        #region Usability

        /// <summary>
        /// If Move Mouse Down, Save the Location
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void Scanner_MouseDown_Move(object sender, MouseEventArgs e)
        {
            this.movingMouseDownLocation = e.Location;
        }

        /// <summary>
        /// If Move Mouse Move, ReLocate the Form
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void Scanner_MouseMove_Move(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            Location = new Point(Location.X + e.X - this.movingMouseDownLocation.X, Location.Y + e.Y - this.movingMouseDownLocation.Y);
        }

        /// <summary>
        /// If Resize Mouse Down, Save the Location
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void Scanner_MouseDown_Resize(object sender, MouseEventArgs e)
        {
            this.resizingMouseDownLocation = e.Location;
        }

        /// <summary>
        /// If Resize Mouse Move, ReSize the Form
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void Scanner_MouseMove_Resize(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            Size = new Size(Size.Width + e.X - this.resizingMouseDownLocation.X, Size.Height + e.Y - this.resizingMouseDownLocation.Y);

            Refresh();
        }

        /// <summary>
        /// If Double Clicked on the ToolBar
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void Scanner_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        #endregion Usability

        #region Drag & Drop

        /// <summary>
        /// Drag Enter the Form
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void Scanner_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        /// <summary>
        /// Drag Drop in the Form
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void Scanner_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // Go Open the File
                this.OpenMyFile(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Happened" + "\r\n" + ex.Message);
            }
        }

        #endregion Drag & Drop

        #region Buttons Clicks

        /// <summary>
        /// Next Label Click
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (this.toTokens)
            {
                if (this.rtxtCode.Text != string.Empty)
                {
                    // RunEvents the Scanner
                    this.RunScanner();
                }
                else
                {
                    // The Arrow look forward the Tokens, but the code is empty
                    return;
                }
            }

            this.toTokens = !this.toTokens;

            this.RunEvents();
        }

        /// <summary>
        /// Events on Form relevant to Run
        /// </summary>
        private void RunEvents()
        {
            Color activeColor;
            Color notActiveColor;

            activeColor = Color.SkyBlue;

            notActiveColor = Color.DarkGray;

            if (this.toTokens)
            {
                this.rtxtCode.ReadOnly = false;

                this.btnRun.BackgroundImage = Properties.Resources.Tokens.GetThumbnailImage(this.btnRun.Width, this.btnRun.Height, null, IntPtr.Zero);
                this.ttMain.SetToolTip(this.btnRun, "RunEvents Scanner");

                this.rtxtCode.SelectionLength = 0;
                this.rtxtCode.Cursor = Cursors.IBeam;
                this.rtxtCode.BackColor = activeColor;

                this.lvTokens.HotTracking = false;
                this.lvTokens.HoverSelection = false;
                this.lvTokens.FullRowSelect = false;
                this.lvTokens.Cursor = Cursors.No;
                this.lvTokens.BackColor = notActiveColor;
            }
            else
            {
                this.rtxtCode.ReadOnly = true;

                this.btnRun.BackgroundImage = Properties.Resources.Code.GetThumbnailImage(this.btnRun.Width, this.btnRun.Height, null, IntPtr.Zero);
                this.ttMain.SetToolTip(this.btnRun, "Allow Code Change");

                this.rtxtCode.Cursor = Cursors.No;
                this.rtxtCode.BackColor = notActiveColor;

                this.lvTokens.HotTracking = true;
                this.lvTokens.HoverSelection = true;
                this.lvTokens.FullRowSelect = true;
                this.lvTokens.Cursor = Cursors.Hand;
                this.lvTokens.BackColor = activeColor;
            }
        }

        /// <summary>
        /// If Clicked on Tools
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void BtnTools_Click(object sender, EventArgs e)
        {
            this.scMain.Panel1Collapsed = !this.scMain.Panel1Collapsed;

            this.scBackground.Panel2Collapsed = !this.scBackground.Panel2Collapsed;

            if (this.scMain.Panel1Collapsed)
            {
                this.ttMain.SetToolTip(this.btnTools, "Show ToolBar's Panel");
            }
            else
            {
                this.ttMain.SetToolTip(this.btnTools, "Hide ToolBar's Panel");
            }
        }

        /// <summary>
        /// If Undoing to some previous state
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void BtnUndo_Click(object sender, EventArgs e)
        {
            // TODO Implement this Function
        }

        /// <summary>
        /// If Redoing to some Undoed states
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void BtnRedo_Click(object sender, EventArgs e)
        {
            // TODO Implement this Function
        }

        #region Static Buttons

        /// <summary>
        /// Close the File
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// If Minimize the Debugger
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Open the File
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            // Create an Open File Dialog
            OpenFileDialog ofd = new OpenFileDialog();

            // Set Some Initial Data
            ofd.Title = "Open Code";
            ofd.Filter = "Text Files *.txt|*.txt";
            ofd.FileName = "Open My Code";

            // If OK Button is pressed, go Open the File
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.OpenMyFile(ofd.FileName);
            }
        }

        /// <summary>
        /// Save the Text Box Code
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog
            SaveFileDialog sfd = new SaveFileDialog();

            // Set Some Initial Data
            sfd.Title = "Save Code";
            sfd.Filter = "Text Files *.txt|*.txt";
            sfd.FileName = "Save My Code";

            try
            {
                // If Ok Button is Clicked
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Create FileStream & StreamWriter
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);

                    // Write the File
                    sw.Write(this.rtxtCode.Text);

                    // Close both StreamWrite & FileStream
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// If Clear the Code Box
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.rtxtCode.Clear();

            this.lvTokens.Items.Clear();

            this.lblStatus.Text = string.Empty;
        }

        #endregion Static Buttons

        #endregion Buttons Clicks

        #region Active Code HighLighting

        /// <summary>
        /// If Item is Selected
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void LvTokens_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Go do same as Item Activated
            this.LvTokens_ItemActivate(null, null);
        }

        /// <summary>
        /// If Item Activated
        /// </summary>
        /// <param name="sender">The Send to this Event</param>
        /// <param name="e">Then Event Arguments of this Event</param>
        private void LvTokens_ItemActivate(object sender, EventArgs e)
        {
            int tmpCodeIndex;

            // Tmp Code for Checking the multiple select
            ////if (this.lvTokens.SelectedIndices.Count > 1)
            ////{
            ////    string tmp = string.Empty;
            ////    for (int i = 0; i < this.lvTokens.SelectedIndices.Count; i++)
            ////    {
            ////        tmp += this.lvTokens.SelectedIndices[i].ToString() + " ";
            ////    }
            ////    MessageBox.Show(tmp);
            ////}

            // If the Count of Selected Indices is less than 1, Or the RunEvents Button is looking forward generating Tokens, so I am not ready yet
            if (this.lvTokens.SelectedIndices.Count < 1 || this.toTokens)
            {
                return;
            }

            tmpCodeIndex = this.FindInCode(this.lvTokens.SelectedIndices[0]);
            this.rtxtCode.SelectionStart = tmpCodeIndex;
            this.rtxtCode.SelectionLength = 0;

            for (int i = 0; i < this.lvTokens.SelectedIndices.Count; i++)
            {
                this.rtxtCode.SelectionLength += this.scanner.GeneratedTokens[this.lvTokens.SelectedIndices[i]].TokenRepresenation.Length;
            }

            this.lblStatus.Text = string.Format("Number: \"{0}\", Lexeme: \"{1}\", Type: \"{2}\", Category: \"{3}\"", this.lvTokens.SelectedIndices[0] + 1, this.scanner.GeneratedTokens[this.lvTokens.SelectedIndices[0]].TokenRepresenation, this.scanner.GeneratedTokens[this.lvTokens.SelectedIndices[0]].Name, this.scanner.GeneratedTokens[this.lvTokens.SelectedIndices[0]].Category);

            this.rtxtCode.ScrollToCaret();
        }

        #endregion Active Code HighLighting

        #endregion Events
    }
}