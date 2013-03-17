using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class CategoryForm : Form
    {
        private Category newCategory;

        private Point movingMouseDownLocation;

        public CategoryForm(Category categoryToUpdate)
        {
            this.InitializeComponent();

            this.txtID.Text = categoryToUpdate.ID.ToString();
            this.txtName.Text = categoryToUpdate.Name;

            this.lblUpdateTitle.Visible = true;
        }

        public CategoryForm(int newCategoryID)
        {
            this.InitializeComponent();

            this.txtID.Text = newCategoryID.ToString();

            this.lblCreateTitle.Visible = true;
        }

        /// <summary>
        /// Gets the NewCategory Object
        /// </summary>
        internal Category NewCategory
        {
            get { return this.newCategory; }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            bool successful = true;

            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Category Name", "Name Not Valid!");
                successful = false;
            }
            else
            {
                this.newCategory = new Category()
                {
                    ID = int.Parse(this.txtID.Text),
                    Name = this.txtName.Text
                };

                for (int i = 1; i <= Category.Categories.Count; i++)
                {
                    if (i != this.newCategory.ID && this.newCategory.Name.ToLower().Equals(Category.Categories[i - 1].Name.ToLower()))
                    {
                        successful = false;

                        MessageBox.Show(Category.GetCategoryByID(i).ToString() + "Have the same letters", "Name not Valid!");

                        break;
                    }
                }
            }

            if (successful)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        #region Move Form

        private void BtnStyle_MouseDown(object sender, MouseEventArgs e)
        {
            this.movingMouseDownLocation = e.Location;
        }

        private void BtnStyle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            this.Location = new Point(this.Location.X + e.X - this.movingMouseDownLocation.X, this.Location.Y + e.Y - this.movingMouseDownLocation.Y);
        }

        #endregion

        #region Button Style

        private void BtnStyle_MouseHover(object sender, EventArgs e)
        {
            ((Button)sender).FlatStyle = FlatStyle.Standard;
        }

        private void BtnStyle_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).FlatStyle = FlatStyle.Flat;
        }

        #endregion
    }
}
