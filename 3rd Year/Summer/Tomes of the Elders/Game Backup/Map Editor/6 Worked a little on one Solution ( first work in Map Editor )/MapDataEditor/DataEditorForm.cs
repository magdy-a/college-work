﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataEditor.Data;
using DataEditor;

namespace DataEditor
{
    public partial class DataEditorForm : Form
    {
        #region Data Members
        /// <summary>
        /// The Project object used to manipulate the data.
        /// </summary>
        DManager currentProject;
        #endregion

        #region Properties
        /// <summary>
        /// Returns the Project object used to manipulate the data.
        /// </summary>
        public DManager CurrentProject { get { return currentProject; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the form.
        /// </summary>
        public DataEditorForm()
        {
            InitializeComponent();
            currentProject = new DManager();
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
            currentProject = new DManager();
        }
        /// <summary>
        /// Event executed when user presses the save button.
        /// </summary>
        private void Savebutton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "dat Files (*.dat)|*.dat";
            dialog.FileName = "ProjectData.dat";
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
            dialog.Title = "Open File";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentProject = new DManager();
                currentProject.Load(dialog.FileName);
            }
        }
        /// <summary>
        /// Event executed when user presses the add wall button. 
        /// </summary>
        private void AddWallbutton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddObjectForm addForm = new AddObjectForm(this, AdditionType.Wall, currentProject.GetNextID());
            addForm.Show();
        }
        /// <summary>
        /// Event executed when user presses the add ground button. 
        /// </summary>
        private void AddGroundbutton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddObjectForm addForm = new AddObjectForm(this, AdditionType.Ground, currentProject.GetNextID());
            addForm.Show();
        }
        /// <summary>
        /// Event executed when user presses the add item button. 
        /// </summary>
        private void AddItembutton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddObjectForm addForm = new AddObjectForm(this, AdditionType.Item, currentProject.GetNextID());
            addForm.Show();
        }
        #endregion
    }
}
