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
        MManager Manager;
        public MapEditorForm()
        {
            InitializeComponent();

            Manager = new MManager(this);
            Manager.LoadData();

            SetcmbPaletteItems();

            cmbPalette.SelectedItem = ParentTypes.Terrain.ToString();

            SetcmbTilesetItems();

            cmbTileset.SelectedItem = TerrainTypes.Cave.ToString();

            pbTileset.Image = Manager.GetTilesetSpriteSheet(pbTileset, cmbPalette.Text, cmbTileset.Text).Bitmap;
        }

        private void SetcmbPaletteItems()
        {
            foreach (string item in Enum.GetNames(typeof(ParentTypes)))
                cmbPalette.Items.Add(item);
        }
        private void SetcmbTilesetItems()
        {
            cmbTileset.Items.Clear();
            switch (cmbPalette.Text)
            {
                case "Terrain":
                    foreach (string item in Enum.GetNames(typeof(TerrainTypes)))
                        cmbTileset.Items.Add(item);
                    break;
                case "StaticItems":
                    foreach (string item in Enum.GetNames(typeof(StaticItemsTypes)))
                        cmbTileset.Items.Add(item);
                    break;
                case "Brushes":
                    foreach (string item in Enum.GetNames(typeof(BrushesTypes)))
                        cmbTileset.Items.Add(item);
                    break;
                default:
                    throw new Exception();
            }
        }

        private void cmbPalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetcmbTilesetItems();
            pbTileset.Image = Manager.GetTilesetSpriteSheet(pbTileset, cmbPalette.Text, cmbTileset.Text).Bitmap;
        }

        private void cmbTileset_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbTileset.Image = Manager.GetTilesetSpriteSheet(pbTileset, cmbPalette.Text, cmbTileset.Text).Bitmap;
        }
    }
}
