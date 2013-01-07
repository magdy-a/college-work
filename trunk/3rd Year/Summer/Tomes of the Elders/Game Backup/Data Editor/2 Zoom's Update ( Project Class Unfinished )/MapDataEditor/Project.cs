using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapDataEditor
{
    public class Project
    {
        private System.Windows.Forms.ListView SheetslistView;
        private System.Windows.Forms.ListView ItemslistView;

        public Project()
        {

        }


        internal void Save(string p)
        {
            throw new NotImplementedException();
        }

        internal void Load(string p)
        {
            throw new NotImplementedException();
        }

        internal void AddItem(Data.ParentDataObject NewItem, SpriteSheetMaker SSM)
        {
            throw new NotImplementedException();
        }

        internal int GetNextID()
        {
            return 0;
        }

        internal System.Drawing.Image GetSpriteSheet(int p)
        {
            throw new NotImplementedException();
        }
    }
}
