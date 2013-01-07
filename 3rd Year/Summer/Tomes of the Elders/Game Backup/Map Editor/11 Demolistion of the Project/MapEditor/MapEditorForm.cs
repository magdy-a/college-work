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

        ParentDataObject CurrentObject;

        private Point MouseLocation;

        private Point TileLocation
        {
            get { return new Point(MouseLocation.X / SpriteSheet.SpriteSize.Width + hScrollBarMap.Value, MouseLocation.Y / SpriteSheet.SpriteSize.Height + vScrollBarMap.Value); }
        }

        private Tile TileSelected
        {
            set { Manager.Map.Tiles[Manager.Map.CurrentFloor, TileLocation.Y, TileLocation.X] = value; }
            get { return Manager.Map.Tiles[Manager.Map.CurrentFloor, TileLocation.Y, TileLocation.X]; }
        }

        private int Last_V_MapScroll_Value, Last_H_MapScroll_Value;


        internal int HeightInMap
        {
            get { return pbMap.Height / SpriteSheet.SpriteSize.Height; }
        }
        internal int WidthInMap
        {
            get { return pbMap.Width / SpriteSheet.SpriteSize.Width; }
        }

        internal int Num_ColumnMapTiles
        {
            get { return pbTileset.Height/ SpriteSheet.SpriteSize.Height; }
        }
        internal int Num_MapRowTiles
        {
            get { return pbTileset.Width / SpriteSheet.SpriteSize.Width; }
        }


        //
        //Constructor
        //
        public MapEditorForm()
        {
            InitializeComponent();

            //Creating the Map
            CreateMap CMap;

            //CMap = new CreateMap(5);                //DummyUse

            CMap = new CreateMap();
            CMap.ShowDialog();

            Manager = new MManager(this,CMap);

            CMap.Dispose();
            CMap.Close();

            vScrollBarMap.Maximum = Manager.Map.MapSize.Height - HeightInMap + vScrollBarMap.LargeChange - vScrollBarMap.SmallChange;
            Last_V_MapScroll_Value = vScrollBarMap.Value = vScrollBarMap.Maximum / 2;

            hScrollBarMap.Maximum = Manager.Map.MapSize.Width - WidthInMap + hScrollBarMap.LargeChange - hScrollBarMap.SmallChange;
            Last_H_MapScroll_Value = hScrollBarMap.Value = hScrollBarMap.Maximum / 2;

            //Remember to strict the number of floor to 8 or more ( the default is always 7 ) ... or maybe not
            for (int i = 0; i < CMap.NumOfFloors; i++)
                floorToolStripMenuItem.DropDownItems.Add("Floor " + i.ToString());
            

            //Setting the ComboBoxes
            SetcmbPaletteItems();

            cmbPalette.SelectedItem = ParentTypes.Terrain.ToString();

            SetcmbTilesetItems();

            cmbTileset.SelectedItem = TerrainTypes.Cave.ToString();

            //Setting the Thumbnail Sheet
            pbTileset.Image = Manager.GetThumbnailSpriteSheet(pbTileset, cmbPalette.Text, cmbTileset.Text).Bitmap;
            SetThumbnailSheetScrollBar();

            //setting the Dummy Status of the Map
            toolStripStatusLabelCoordinates.Text = toolStripStatusLabelObject.Text = "";
            toolStripStatusLabelBlank.Text = "          ";
        }


        //
        //MenuStrip
        //
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //
        //ComboBoxes
        //
        private void cmbPalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetcmbTilesetItems();
            pbTileset.Image = Manager.GetThumbnailSpriteSheet(pbTileset, cmbPalette.Text, cmbTileset.Text).Bitmap;
            SetThumbnailSheetScrollBar();
        }

        private void cmbTileset_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbTileset.Image = Manager.GetThumbnailSpriteSheet(pbTileset, cmbPalette.Text, cmbTileset.Text).Bitmap;
            SetThumbnailSheetScrollBar();
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


        //
        //Tileset
        //
        private void SetThumbnailSheetScrollBar()
        {
            int LastObjectSpriteNumber;

            if (Manager.Tileset.Count == 0)
                LastObjectSpriteNumber = 0;
            else
                LastObjectSpriteNumber = ((ParentDataObject)Manager.Tileset[Manager.Tileset.Count - 1]).SpriteNumber;

            int RowNumber = 0, ColumnNumber = 0;
            SpriteSheet.GetSpriteDimensions(LastObjectSpriteNumber, ((SpriteSheet)Manager.ProjectSheets[0]).SheetSize.Width, ref RowNumber, ref ColumnNumber);
            if (RowNumber <= Num_ColumnMapTiles)
            {
                vScrollBarThumbnail.Visible = false;
            }
            else
            {
                vScrollBarThumbnail.Visible = true;
                Double d = RowNumber / (Num_ColumnMapTiles);
                d = Math.Ceiling(d);
                vScrollBarThumbnail.Maximum = (int)d + vScrollBarThumbnail.LargeChange - vScrollBarThumbnail.SmallChange;
                vScrollBarThumbnail.Value = 0;
            }
        }

        private void pbTileset_MouseClick(object sender, MouseEventArgs e)
        {
            int X = e.X / SpriteSheet.SpriteSize.Width;
            int Y = e.Y / SpriteSheet.SpriteSize.Height;
            int TextureNumber = SpriteSheet.GetSpriteNumber(Num_MapRowTiles, Y, X);

           

            if (TextureNumber > Manager.Tileset.Count)
            {
                throw new Exception("UnImplemented Exception !");
                //need to check the scroll before u return ! if the scroll isn't Zero so do ur calculations.
                return;
            }

            CurrentObject = ((ParentDataObject)Manager.Tileset[TextureNumber]);

            ToolTip tip = new ToolTip();
            tip.Show(((ParentDataObject)Manager.Tileset[TextureNumber]).Name, this.pbTileset, e.X, e.Y, 1000);

            toolStripStatusLabelObject.Text = CurrentObject.Name + '(' + CurrentObject.SheetNumber + '-' + CurrentObject.SpriteNumber + ')';
        }


        //
        //Map
        //
        private void pbMap_MouseClick(object sender, MouseEventArgs e)
        {
            MouseLocation = new Point(e.X, e.Y);

            if (CurrentObject == null)
                return;

            //Brush

            //DummyBrush for ex:,
            if(TileSelected == null)
                TileSelected = new Tile();

            if (CurrentObject.GetType() == typeof(Ground))
                TileSelected.Ground = (Ground)CurrentObject;
            else if (CurrentObject.GetType() == typeof(Wall))
                TileSelected.Wall = (Wall)CurrentObject;
            else
                TileSelected.Items.Add((Item)CurrentObject);

            Manager.RefreshMap();

            pbMap.Image = Manager.Map.Sheet.Bitmap;
        }

        private void pbMap_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation = new Point(e.X, e.Y);

            toolStripStatusLabelCoordinates.Text = TileLocation.X + ", " + TileLocation.Y;
        }

        private void hScrollBarMap_Scroll(object sender, ScrollEventArgs e)
        {
            Manager.RefreshMap();
        }







        private void floorToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void vScrollBarThumbnail_Scroll(object sender, ScrollEventArgs e)
        {
            if (vScrollBarThumbnail.Visible == false)
                return;

            throw new NotImplementedException();
        }
    }
}