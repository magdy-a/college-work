using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapDataEditor
{
    public partial class MainForm : Form
    {
        #region Data Members
        /// <summary>
        /// The Project object used to manipulate the data.
        /// </summary>
        Project currentProject;
        #endregion

        #region Properties
        /// <summary>
        /// Returns the Project object used to manipulate the data.
        /// </summary>
        public Project CurrentProject { get { return currentProject; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the form.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            currentProject = new Project();
        }
        #endregion

        #region Form Events
        /// <summary>
        /// Event executed when user selects a different sprite sheet.
        /// </summary>
        private void SheetslistView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in SheetslistView.Items)
                if (item.Selected)
                    pictureBox.Image = currentProject.GetSpriteSheet(item.Index);
        }
        #endregion

        #region Form Buttons
        /// <summary>
        /// Event executed when user presses the clear button.
        /// </summary>
        private void Clearbutton_Click(object sender, EventArgs e)
        {
            currentProject = new Project();
        }
        /// <summary>
        /// Event executed when user presses the save button.
        /// </summary>
        private void Savebutton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "dat Files (*.dat)|*.dat";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentProject.Save(dialog.FileName);
            }
        }
        /// <summary>
        /// Event executed when user presses the load button. 
        /// </summary>
        private void Loadbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "dat Files (*.dat)|*.dat";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentProject = new Project();
                currentProject.Load(dialog.FileName);
            }
        }
        /// <summary>
        /// Event executed when user presses the add wall button. 
        /// </summary>
        private void AddWallbutton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddItemForm addForm = new AddItemForm(this, AdditionType.Wall, currentProject.GetNextID());
            addForm.Show();
        }
        /// <summary>
        /// Event executed when user presses the add ground button. 
        /// </summary>
        private void AddGroundbutton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddItemForm addForm = new AddItemForm(this, AdditionType.Ground, currentProject.GetNextID());
            addForm.Show();
        }
        /// <summary>
        /// Event executed when user presses the add item button. 
        /// </summary>
        private void AddItembutton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddItemForm addForm = new AddItemForm(this, AdditionType.Item, currentProject.GetNextID());
            addForm.Show();
        }
        #endregion
    }
}