using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEditor.Data;
using DataEditor;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace MapEditor
{
    class MManager
    {
        //Create Properties !!!!!!!!!!*********
        DManager DatMan;

        Map Map;

        MapEditorForm MapForm;

        public ArrayList Objects;
        public ArrayList ProjectSheets;

        public ArrayList Tileset;

        public SpriteSheet ThumbnailSheet;
        public static int WidthOfThumbnailSheet;

        public MManager(MapEditorForm Ref)
        {
            DatMan = new DataEditor.DManager();
            Map = new Map();
            MapForm = Ref;
            WidthOfThumbnailSheet = 5;
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

                DatMan.Load(FilePath);
            }

            Objects = DatMan.Objects;
            ProjectSheets = DatMan.ProjectSheets;
        }

        internal ArrayList GetTilesetObjects(ParentTypes ParentType, String ChildType)
        {
            ArrayList Arr = new ArrayList();
            foreach (ParentDataObject Object in Objects)
                if (Object.ParentType == ParentType && Object.ChildType == ChildType)
                    Arr.Add(Object);
            return Arr;
        }

        internal Bitmap GetObjectThumbnail(ParentDataObject Object)
        {
            int ObjectSheetNumber = 0, ObjectSpriteNumber = 0;
            int RowNumber = 0, ColumnNumber = 0;

            DManager.DefineID(Object.ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);
            SpriteSheet.GetTextureDimensions(ObjectSpriteNumber, DManager.SheetSize.Width, ref RowNumber, ref ColumnNumber);

            return ((SpriteSheet)ProjectSheets[ObjectSheetNumber - 1]).GetSprite(ColumnNumber, RowNumber);
        }

        internal SpriteSheet GetTilesetSpriteSheet(PictureBox pbRef,ParentTypes ParentType, String ChildType)
        {
            Tileset = GetTilesetObjects(ParentType, ChildType);

            ThumbnailSheet = new SpriteSheet(ref pbRef, pbRef.Height / ThumbnailSheet.SpriteSize.Height, WidthOfThumbnailSheet);

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

        }
    }
}
