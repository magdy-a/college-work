using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MapDataEditor.Data
{
    [Serializable]
    class Tile
    {
        Ground Ground;
        Wall Wall;
        ArrayList Items;
    }

    class Map
    {
        //not a good idea to serialize a 3d ( 100 * 1000 * 15  ) array, alooooot of space, Imagine if it were a Struct Array not a Class either
        Tile[,,] Tiles;
        Size MapSize;
        int NumOfLevels;

        public Map()
        {
            MapSize = new Size(1000, 500);
            NumOfLevels = 15;
            Tiles = new Tile[MapSize.Height, MapSize.Width,NumOfLevels];
        }

        internal void Save(String FilePath)
        {
            Stream Stream = File.Open(FilePath, FileMode.Create);
            BinaryFormatter BFormatter = new BinaryFormatter();
            BFormatter.Serialize(Stream, Tiles);
            Stream.Close();
        }
    }
}
