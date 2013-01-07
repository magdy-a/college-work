using System;
using System.Windows.Forms;
using DataEditor.Data;
using System.Drawing;

namespace DataEditor
{
    /// <summary>
    /// Different Object Types.
    /// </summary>
    public enum AdditionType { Item, Wall, Ground }

    /// <summary>
    /// Form to enter Items properties.
    /// </summary>
    public partial class AddObjectForm : Form
    {
        #region Data Members
        /// <summary>
        /// A pointer to the Main Form executed from.
        /// </summary>
        DataEditorForm myParent;
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
        public AddObjectForm(DataEditorForm Parent, AdditionType Type, int ID)
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
                AddSpritesForm spritesForm;

                if (myType == AdditionType.Ground)
                {
                    NewItem = new Ground();
                    ((Ground)NewItem).NumberofGrounds = int.Parse(GroundPiecestextBox.Text);
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
                    //int SheetWidth, SheetHeight;
                    //SheetHeight = NewItem.Length / 10;
                    //SheetWidth = NewItem.Length - (SheetHeight * 10);
                    spritesForm = new AddSpritesForm(myParent, myType, NewItem,
                        new Size(10, (int)(Math.Ceiling((double)(NewItem.Length) / 10.0))));
                    //spritesForm = new AddSpritesForm(myParent, myType, NewItem,
                    //    new Size(SheetWidth,++SheetHeight));
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
                    spritesForm = new AddSpritesForm(myParent, myType, NewItem,
                        new Size(((Item)NewItem).Width, ((Item)NewItem).Height));
                }
                else
                {
                    NewItem = new Wall();
                    ((Wall)NewItem).Tall = TallWallradioButton.Checked;
                    if (((Wall)NewItem).Tall)
                    {
                        spritesForm = new AddSpritesForm(myParent, myType, NewItem,
                            new Size(8, 2));
                    }
                    else
                    {
                        spritesForm = new AddSpritesForm(myParent, myType, NewItem,
                            new Size(4, 1));
                    }
                }

                if (NametextBox.Text.Length == 0)
                {
                    MessageBox.Show("You must enter a valid name.");
                    return;
                }

                NewItem.ID = myID;
                NewItem.Name = NametextBox.Text;
                NewItem.ParentType = (ParentTypes)Enum.Parse(typeof(ParentTypes), ParentTypecomboBox.Text, false);
                NewItem.ChildType = ChildTypecomboBox.Text;

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
            foreach (string item in Enum.GetNames(Type.GetType("DataEditor.Data." + ParentTypecomboBox.Text + "Types")))
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
