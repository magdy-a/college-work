using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataEditor.Data;

namespace MapEditor
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
        public Tile[,,] Tiles;
        public Size MapSize;
        public int NumOfFloors;
        public int CurrentFloor;

        public Map()
        {
            MapSize = new Size(1000, 500);
            NumOfFloors = 16;
            CurrentFloor = 7;
            Tiles = new Tile[MapSize.Height, MapSize.Width,NumOfFloors];
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
