using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapDataEditor.Data;

namespace MapDataEditor
{
    class MapEditor
    {
        Map TheMap;
        MainForm MainFormRef;
        int CurrentLevel;
        

        public MapEditor(MainForm Ref)
        {
            TheMap = new Map();
            MainFormRef = Ref;
            CurrentLevel = 6;//The Seventh ( Zero Place )
        }



        internal void Save(String FilePath)
        {

        }

        internal void Load(String FilePath)
        {

        }

        internal void RefreshMap()
        {

        }
    }
}
