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
        DManager DMan;

        internal Map Map;

        MapEditorForm MapForm;

        internal ArrayList Objects;
        internal ArrayList ProjectSheets;

        internal ArrayList Tileset;

        internal SpriteSheet ThumbnailSheet;

        internal static int WidthOfThumbnailSheet;

        public MManager(MapEditorForm Ref,CreateMap CMap)
        {
            DMan = new DataEditor.DManager();

            MapForm = Ref;

            Map = new Map(Ref,CMap.MapSize,CMap.NumOfFloors,CMap.CurrentFloor);

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

            SpriteSheet.GetTextureDimensions(Object.SpriteNumber, DManager.SheetSize.Width, ref RowNumber, ref ColumnNumber);

            return ((SpriteSheet)ProjectSheets[Object.SheetNumber - 1]).GetSprite(ColumnNumber, RowNumber);
        }

        internal SpriteSheet GetTilesetSpriteSheet(PictureBox pbRef,String ParentType, String ChildType)
        {
            Tileset = GetTilesetObjects(ParentType, ChildType);

            ThumbnailSheet = new SpriteSheet(ref pbRef, pbRef.Height / 32, WidthOfThumbnailSheet);

            SpriteSheet.Set_Black(ThumbnailSheet.Bitmap);

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
            //
            //
            //
            //                          Performance is Awful
            //
            //
            int vScrollValue = MapForm.vScrollBarMap.Value;
            int hScrollValue = MapForm.hScrollBarMap.Value;

            Tile tmpTile;
            SpriteSheet tmpSheet;
            //String tmpFilePath;

            //u should do brush here
            //In Refresh i better to loop all ParentDataObjects and set them one by one
            //by setting the item in one (nested loop ), i'll loop the 3*2 textures in loop ( row textures * 32 * columntextures * 32 )
            //instead of setting every tile
            //get the sheet in using the function DManager.CreateSpriteSheetFromObject(ParentDataObject Object), then set all the sheet once

            SpriteSheet.Set_Black(Map.Sheet.Bitmap);

            for (int x = 0; x < MapForm.WidthInMap; x++)
            {
                for (int y = 0; y < MapForm.HeightInMap; y++)
                {
                    tmpTile = Map.Tiles[Map.CurrentFloor, y + vScrollValue, x + hScrollValue];
                    if (tmpTile == null)
                        continue;
                    if (tmpTile.Ground != null)
                    {
                        tmpSheet = DMan.CreateSpriteSheetMakerForObject(tmpTile.Ground);
                        //tmpFilePath = "C:\\Users\\magdy\\Desktop\\" + (x + hScrollValue).ToString() + (y + vScrollValue).ToString() + "Ground" + ".png";
                        //if (File.Exists(tmpFilePath))
                        //    File.Delete(tmpFilePath);
                        //tmpSheet.Bitmap.Save(tmpFilePath);
                        Map.Sheet.SetSprite(x, y, tmpSheet.GetSprite(0, 0));
                        //Map.SetSpriteInScreen(x, y, tmpSheet.SheetBitmaps()[0]);
                    }
                    if (tmpTile.Wall != null)
                    {
                        tmpSheet = DMan.CreateSpriteSheetMakerForObject(tmpTile.Wall);
                        //tmpFilePath = "C:\\Users\\magdy\\Desktop\\" + (x + hScrollValue).ToString() + (y + vScrollValue).ToString() + "Wall" + ".png";
                        //if (File.Exists(tmpFilePath))
                        //    File.Delete(tmpFilePath);
                        //tmpSheet.Bitmap.Save(tmpFilePath);
                        Map.Sheet.SetSprite(x, y, tmpSheet.GetSprite(0, 0));
                        //Map.SetSpriteInScreen(x, y, tmpSheet.SheetBitmaps()[0]);
                    }
                    if (tmpTile.Items.Count != 0 || ( x == MapForm.WidthInMap-1 && y == MapForm.HeightInMap-1 ))
                    {
                        for (int i = 0; i < tmpTile.Items.Count; i++)
                        {
                            tmpSheet = DMan.CreateSpriteSheetMakerForObject(((Item)tmpTile.Items[i]));
                            //tmpFilePath = "C:\\Users\\magdy\\Desktop\\" + (x + hScrollValue).ToString() + (y + vScrollValue).ToString() + "Item" + i.ToString() + ".png";
                            //if (File.Exists(tmpFilePath))
                            //    File.Delete(tmpFilePath);
                            //tmpSheet.Bitmap.Save(tmpFilePath);
                            Map.Sheet.SetSprite(x, y, tmpSheet.GetSprite(0,0));
                            //Map.SetSpriteInScreen(x, y, tmpSheet.SheetBitmaps()[0]);
                        }
                    }
                }
            }
        }
    }
}
