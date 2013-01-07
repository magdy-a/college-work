using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataEditor;
using DataEditor.Data;

namespace MapEditor
{
    public partial class MapEditorForm : Form
    {
        public MapEditorForm()
        {
            InitializeComponent();
            MManager Manager = new MManager(this);
            Manager.LoadData();

            SetcmbPaletteItems();

            cmbPalette.SelectedItem = ParentTypes.Terrain.ToString();

            SetcmbTilesetItems();

            Manager.Objects = Manager.GetTilesetObjects(((ParentTypes)cmbPalette.SelectedItem), ((String)cmbTileset.SelectedItem));

            SpriteSheet SS = new SpriteSheet(ref this.pbTileset, 20, 5);

            foreach (ParentDataObject Object in Manager.Objects)
            {
                SS.AddSprite(Manager.GetObjectThumbnail(Object));
            }
            this.pbTileset.Image = SS.Bitmap;
        }
        private void SetcmbPaletteItems()
        {
            foreach (string item in Enum.GetNames(typeof(ParentTypes)))
                cmbPalette.Items.Add(item);
        }
        private void SetcmbTilesetItems()
        {
            cmbTileset.Items.Clear();
            foreach (string item in Enum.GetNames(Type.GetType("DataEditor.Data." + cmbPalette.Text +"Types")))
                cmbTileset.Items.Add(item);
        }
    }
}
