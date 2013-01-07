using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using MapDataEditor.Data;

namespace MapDataEditor
{
    public class Project
    {
        private System.Windows.Forms.ListView SheetslistView;
        private System.Windows.Forms.ListView ItemslistView;

        private ArrayList SpriteSheetMaker;
        private ArrayList ParentDataObject;

        private int SheetNumber, LastSpriteNumber;
        private static int MaxSpriteNumber;
        private Size SheetSize;

        public Project()
        {
            SheetSize = new Size(20,20);
            MaxSpriteNumber = (SheetSize.Width * SheetSize.Height) - 1;
            SheetNumber = LastSpriteNumber = 0;
        }


        internal void Save(string p)
        {

            throw new NotImplementedException();
        }

        internal void Load(string p)
        {
            throw new NotImplementedException();
        }

        internal void AddItem(ParentDataObject NewItem, SpriteSheetMaker SSM)
        {
            //Add the object to the array
            ParentDataObject.Add(NewItem);

            //
            if (MaxSpriteNumber - LastSpriteNumber > NewItem.Length)
            {
                LastSpriteNumber += NewItem.Length;
            }
            else
            {
                LastSpriteNumber += NewItem.Length - (MaxSpriteNumber - LastSpriteNumber);
                SheetNumber++;
            }


            //Add the Sprite to the Editor Sheets
        }

        internal int GetNextID()
        {
            return (SheetNumber * 1000) + LastSpriteNumber;
        }

        internal Image GetSpriteSheet(int p)
        {
            throw new NotImplementedException();
        }
    }
}
