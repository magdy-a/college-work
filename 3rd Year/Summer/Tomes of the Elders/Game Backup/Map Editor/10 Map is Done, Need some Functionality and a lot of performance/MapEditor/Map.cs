using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataEditor;
using DataEditor.Data;
using System.Windows.Forms;

namespace MapEditor
{
    [Serializable]
    class Tile
    {
        public Ground ground;
        public Wall wall;
        public ArrayList items;

        bool updated;

        public Ground Ground
        {
            set { ground = value; }
            get { return ground; }
        }
        public Wall Wall
        {
            set { wall = value; }
            get { return wall; }
        }
        public ArrayList Items
        {
            set { items = value; }
            get { return items; }
        }

        public bool Updated
        {
            set { updated = value; }
            get { return Updated; }
        }
        
        //will use in kind of just adding ane Object .. no need to set all the Sheet

        //you should also know wht the top ( Object ) in every Pixel ( by a method or any other idea )

        public Tile()
        {
            Items = new ArrayList();
            Updated = false;
        }
    }

    class Map
    {
        public Tile[,,] Tiles;
        public Size MapSize;
        public int NumOfFloors;
        public int CurrentFloor;
        public SpriteSheet Sheet;

        public Map(MapEditorForm Ref,Size mapSize, int numOfFloors,int currentFloor)
        {
            MapSize = mapSize;

            PictureBox Dummy = new PictureBox();

            Sheet = new SpriteSheet(ref Ref.pbMap, Ref.HeightInMap, Ref.WidthInMap);
            SpriteSheet.Set_Black(Sheet.Bitmap);

            //Ref.pbMap.Image = Sheet.Bitmap;

            NumOfFloors = numOfFloors;
            CurrentFloor = currentFloor;

            Tiles = new Tile[NumOfFloors, MapSize.Width,MapSize.Height];
        }

        internal void SetData(Size mapSize, int numOfFloors, int currentFloor)
        {
            MapSize = mapSize;
            NumOfFloors = numOfFloors;
            CurrentFloor = currentFloor;
        }

        internal void SetSpriteInScreen(int x, int y,Bitmap Texture)
        {
            Color Transparent = Color.FromArgb(255,0,255);
            //u better check the r & g & b instead of the color, cause the A parameter might effect


            for (int i = 0; i < SpriteSheet.SpriteSize.Width; i++)
            {
                for (int j = 0; j < SpriteSheet.SpriteSize.Height; j++)
                {
                    if (Texture.GetPixel(i, j) != Transparent)
                        Sheet.Bitmap.SetPixel(x + i, y + j, Texture.GetPixel(i, j));
                }
            }
        }
    }
}
