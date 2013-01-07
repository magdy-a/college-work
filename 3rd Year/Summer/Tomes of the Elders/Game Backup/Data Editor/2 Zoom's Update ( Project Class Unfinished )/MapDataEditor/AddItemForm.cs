using System;
using System.Windows.Forms;
using MapDataEditor.Data;

namespace MapDataEditor
{
    /// <summary>
    /// Different Object Types.
    /// </summary>
    public enum AdditionType { Item, Wall, Ground }

    /// <summary>
    /// Form to enter Items properties.
    /// </summary>
    public partial class AddItemForm : Form
    {
        #region Data Members
        /// <summary>
        /// A pointer to the Main Form executed from.
        /// </summary>
        MainForm myParent;
        /// <summary>
        /// The item being added to the collection.
        /// </summary>
        ParentDataObject NewItem;
        /// <summary>
        /// Type of item being added to the collection.
        /// </summary>
        AdditionType myType;
        /// <summary>
        /// ID of item being added to the collection.
        /// </summary>
        int myID;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of this form.
        /// </summary>
        /// <param name="Parent">A pointer to the Main Form executed from.</param>
        /// <param name="Type">Type of item being added to the collection.</param>
        /// <param name="ID">ID of item being added to the collection.</param>
        public AddItemForm(MainForm Parent, AdditionType Type, int ID)
        {
            InitializeComponent();
            myParent = Parent;
            myID = ID;
            myType = Type;

            if (myType == AdditionType.Ground)
                GroundgroupBox.Visible = true;
            else if (myType == AdditionType.Item)
                ItemgroupBox.Visible = true;
            else if (myType == AdditionType.Wall)
                WallgroupBox.Visible = true;

            foreach (string item in Enum.GetNames(typeof(ParentTypes)))
                ParentTypecomboBox.Items.Add(item);
        }
        #endregion

        #region Form Buttons
        /// <summary>
        /// Event executed when the cancel button is pressed.
        /// </summary>
        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            myParent.Enabled = true;
            this.Dispose();
        }
        /// <summary>
        /// Event executed when the add sprites button is pressed.
        /// </summary>
        private void AddSpritesbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (myType == AdditionType.Ground)
                {
                    NewItem = new Ground();
                    ((Ground)NewItem).NumberofGrounds = int.Parse(GroundPieceslabel.Text);
                    if (((Ground)NewItem).NumberofGrounds < 1)
                    {
                        MessageBox.Show("Number of Grounds must be > 0.");
                        return;
                    }
                    ((Ground)NewItem).HasBorders = HasBorderscheckBox.Checked;
                    ((Ground)NewItem).CanWalkOn = CanWalkOncheckBox.Checked;

                    ((Ground)NewItem).GroundsImportances = new int[((Ground)NewItem).NumberofGrounds];
                    string[] values = ImportancetextBox.Text.Split(',');
                    if (values.Length != ((Ground)NewItem).NumberofGrounds)
                    {
                        MessageBox.Show("Importances values are not equal to number of ground pieces.");
                        return;
                    }
                    for (int i = 0; i < values.Length; i++)
                        ((Ground)NewItem).GroundsImportances[i] = int.Parse(values[i]);
                }
                else if (myType == AdditionType.Item)
                {
                    NewItem = new Item();
                    ((Item)NewItem).Height = int.Parse(HeighttextBox.Text);
                    ((Item)NewItem).Width = int.Parse(WidthtextBox.Text);
                    if (((Item)NewItem).Height < 1 || ((Item)NewItem).Width < 1)
                    {
                        MessageBox.Show("Invalid Height or Width.");
                        return;
                    }
                }
                else if (myType == AdditionType.Wall)
                {
                    NewItem = new Wall();
                    ((Wall)NewItem).Tall = TallWallradioButton.Checked;
                }

                NewItem.ID = myID;
                NewItem.Name = NametextBox.Text;
                NewItem.ParentType = (ParentTypes)Enum.Parse(typeof(ParentTypes), ParentTypecomboBox.Text, false);
                NewItem.ChildType = ChildTypecomboBox.Text;

                AddSpritesForm spritesForm = new AddSpritesForm(myParent, myType, NewItem);
                spritesForm.Show();
                this.Dispose();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Text Input.");
            }
        }
        #endregion

        #region Form Events
        /// <summary>
        /// Event executed when user selects a parent type.
        /// </summary>
        private void ParentTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChildTypecomboBox.Enabled = true;
            ChildTypecomboBox.Items.Clear();
            foreach (string item in Enum.GetNames(Type.GetType("MapDataEditor.Data." + ParentTypecomboBox.Text + "Types")))
                ChildTypecomboBox.Items.Add(item);
        }
        /// <summary>
        /// Event executed when form is closed.
        /// </summary>
        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myParent.Enabled = true;
            this.Dispose();
        }
        #endregion
    }
}
