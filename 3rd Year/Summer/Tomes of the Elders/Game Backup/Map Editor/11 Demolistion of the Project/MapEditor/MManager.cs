using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEditor.Data;
using DataEditor;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MapEditor
{
    class MManager
    {
        internal DManager DMan;

        internal Map Map;

        internal MapEditorForm MapForm;

        internal ArrayList Objects;
        internal ArrayList ProjectSheets;

        internal ArrayList Tileset;

        internal SpriteSheet ThumbnailSheet;

        internal static int WidthOfThumbnailSheet;

        public MManager(MapEditorForm Ref,CreateMap CMap)
        {
            DMan = new DataEditor.DManager();

            MapForm = Ref;

            Map = new Map(Ref,new Size(CMap.MapSizeWidth,CMap.MapSizeHeight),CMap.NumOfFloors,CMap.CurrentFloor);

            WidthOfThumbnailSheet = Ref.Num_MapRowTiles;

            LoadData(CMap.FilePath);
        }

        internal void LoadData(String FilePath)
        {
            DMan.Load(FilePath);
            Objects = DMan.Objects;
            ProjectSheets = DMan.ProjectSheets;
        }
        internal void LoadData()
        {
            String FilePath;
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "dat Files (*.dat)|*.dat";
            OpenFile.Title = "Open File";

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                FilePath = OpenFile.FileName;

                DMan.Load(FilePath);
            }

            Objects = DMan.Objects;
            ProjectSheets = DMan.ProjectSheets;
        }

        internal ArrayList GetTilesetObjects(String ParentType, String ChildType)
        {
            ArrayList Arr = new ArrayList();
            foreach (ParentDataObject Object in Objects)
                if (Object.ParentType.ToString() == ParentType && Object.ChildType == ChildType)
                    Arr.Add(Object);
            return Arr;
        }

        internal Bitmap GetObjectThumbnail(ParentDataObject Object)
        {
            int RowNumber = 0, ColumnNumber = 0;

            SpriteSheet.GetSpriteDimensions(Object.SpriteNumber, DManager.SheetSize.Width, ref RowNumber, ref ColumnNumber);

            return ((SpriteSheet)ProjectSheets[Object.SheetNumber - 1]).GetSprite(ColumnNumber, RowNumber);
        }

        internal SpriteSheet GetThumbnailSpriteSheet(PictureBox pbRef,String ParentType, String ChildType)
        {
            Tileset = GetTilesetObjects(ParentType, ChildType);

            ThumbnailSheet = new SpriteSheet(pbRef, pbRef.Height / 32, WidthOfThumbnailSheet);
            ThumbnailSheet.BackgroundColor = Color.Black;
            ThumbnailSheet.ClearAll();

            foreach (ParentDataObject Object in Tileset)
                ThumbnailSheet.AddSprite(GetObjectThumbnail(Object));

            pbRef.Image = ThumbnailSheet.Bitmap;

            return ThumbnailSheet;
        }

        internal void SaveMap(String FilePath)
        {

        }
        internal void LoadMap(String FilePath)
        {

        }

        internal void RefreshMap()
        {
            int vScrollValue = MapForm.vScrollBarMap.Value;
            int hScrollValue = MapForm.hScrollBarMap.Value;

            Tile tmpTile;
            SpriteSheet tmpSheet;

            //U should do Brush here

            //In Refresh i better to loop all ParentDataObjects and set them one by one ( found 2 Issues, first: u will need to check if the object exists in the current view of the map, second: this will not avoid setting the same pixel more than once, cause of ground then wall, the best idea until now is to get the top object on every pixel and put it just once, and for changing object u should change them only without looping the whole view, last thing is when scrolling u shouldn't do all of the map, u could take part of the map and put it into the new view .. like copy & paste, ex: if u are scrolling to right, the last column from the left will disapear so cut the whole view except the left most column and put in into a new view ... draw only the most right column.

            //by setting the item in one (nested loop ), i'll loop the 3*2 textures in loop ( row textures * 32 * columntextures * 32 ) ,instead of setting every tile

            //get the sheet in using the function DManager.CreateSpriteSheetFromObject(ParentDataObject Object), then set all the sheet once

            Map.Sheet.ClearAll();

            for (int x = 0; x < MapForm.WidthInMap; x++)
            {
                for (int y = 0; y < MapForm.HeightInMap; y++)
                {
                    tmpTile = Map.Tiles[Map.CurrentFloor, y + vScrollValue, x + hScrollValue];

                    if (tmpTile == null) continue;

                    if (tmpTile.Ground != null)
                    {
                        tmpSheet = DMan.CreateSpriteSheetMakerForObject(tmpTile.Ground);
                        Map.Sheet.SetSprite(x, y, tmpSheet.GetSprite(0, 0));
                        //Map.SetSpriteInScreen(x, y, tmpSheet.SheetBitmaps()[0]);
                    }
                    if (tmpTile.Wall != null)
                    {
                        tmpSheet = DMan.CreateSpriteSheetMakerForObject(tmpTile.Wall);
                        Map.Sheet.SetSprite(x, y, tmpSheet.GetSprite(0, 0));
                        //Map.SetSpriteInScreen(x, y, tmpSheet.SheetBitmaps()[0]);
                    }
                    if (tmpTile.Items.Count != 0)
                    {
                        for (int i = 0; i < tmpTile.Items.Count; i++)
                        {
                            tmpSheet = DMan.CreateSpriteSheetMakerForObject(((Item)tmpTile.Items[i]));
                            Map.Sheet.SetSprite(x, y, tmpSheet.GetSprite(0,0));
                            //Map.SetSpriteInScreen(x, y, tmpSheet.SheetBitmaps()[0]);
                        }
                    }
                }
            }
            MapForm.pbMap.Image = Map.Sheet.Bitmap;
        }
    }
}
