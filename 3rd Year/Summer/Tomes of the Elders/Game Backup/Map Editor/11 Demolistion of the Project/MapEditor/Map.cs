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
        //Fields
        public Ground ground;
        public Wall wall;
        public ArrayList items;

        bool updated;

        //Properties
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


        //Constructor
        public Tile()
        {
            items = new ArrayList();
            updated = false;
        }

        /// <summary>
        /// Gets the Top Color on Specific Pixel
        /// </summary>
        /// <param name="Coordinates">Coordinates of the Pixel in the Tile</param>
        /// <param name="ProjectSheets">The ArrayList of SpriteSheet that Holds the Game Sprites</param>
        /// <returns>The Color of Pixel</returns>
        public Color TopColor(Point Coordinates,ArrayList ProjectSheets)
        {
            Color CurrentColor;

            if (items.Count != 0)
            {
                Item CurrentItem;
                for (int i = items.Count-1; i >= 0; i--)
                {
                    CurrentItem = ((Item)items[i]);
                    CurrentColor = GetPixelFromSprite(Coordinates,(ParentDataObject)CurrentItem,ProjectSheets);
                    if (CurrentColor != Color.Black)
                        return CurrentColor;
                }
            }

            if (wall != null)
            {
                CurrentColor = GetPixelFromSprite(Coordinates, (ParentDataObject)wall, ProjectSheets);
                if (CurrentColor != Color.Black)
                    return CurrentColor;
            }

            if (ground != null)
            {
                CurrentColor = GetPixelFromSprite(Coordinates, (ParentDataObject)ground, ProjectSheets);
                if (CurrentColor != Color.Black)
                    return CurrentColor;
            }

            return Color.Black;
        }

        /// <summary>
        /// Gets the Top Object of a specific Coordinates
        /// </summary>
        /// <param name="Coordinates">Coordinates to the Pixel in the Sprite</param>
        /// <param name="PixelColor">The Color of the Coordinates on the Map</param>
        /// <param name="ProjectSheets">The ArrayList of SpriteSheet that Holds the Game Sprites</param>
        /// <returns>The Top Object from a Given Coordinates in a Sprite</returns>
        public ParentDataObject TopObject(Point Coordinates,Color PixelColor,ArrayList ProjectSheets)
        {
            Color CurrentColor;

            if (items.Count != 0)
            {
                Item CurrentItem;
                for (int i = items.Count - 1; i >= 0; i--)
                {
                    CurrentItem = ((Item)items[i]);
                    CurrentColor = GetPixelFromSprite(Coordinates, (ParentDataObject)CurrentItem, ProjectSheets);
                    if (CurrentColor == PixelColor)
                        return CurrentItem;
                }
            }

            if (wall != null)
            {
                CurrentColor = GetPixelFromSprite(Coordinates, (ParentDataObject)wall, ProjectSheets);
                if (CurrentColor == PixelColor)
                    return wall;
            }

            if (ground != null)
            {
                CurrentColor = GetPixelFromSprite(Coordinates, (ParentDataObject)ground, ProjectSheets);
                if (CurrentColor == PixelColor)
                    return ground;
            }

            return null;
        }
        
        /// <summary>
        /// Gets specific Color from Given Object's Sprite, by accessing the first sprites from the ID.
        /// </summary>
        /// <param name="Coordinates">X & Y in the Object's Sprite</param>
        /// <param name="Object">The Object that carries Sprite's Information</param>
        /// <param name="ProjectSheets">SpriteSheets that Carries the Game's Sprites</param>
        /// <returns>The Sprites Color from Coordinates</returns>
        private Color GetPixelFromSprite(Point Coordinates, ParentDataObject Object, ArrayList ProjectSheets)
        {
            SpriteSheet CurrentSheet;
            Bitmap CurrentSprite;

            CurrentSheet = ((SpriteSheet)ProjectSheets[Object.SheetNumber]);

            CurrentSprite = CurrentSheet.GetSprite(Object.ColumnNumber, Object.RowNumber);

            return CurrentSprite.GetPixel(Coordinates.X, Coordinates.Y);
        }
    }

    class Map
    {
        public Tile[,,] Tiles;
       
        public Size MapSize;

        //wht do u think if we made every floor a separate Object in an ArrayList instead of making it in an array
        public int NumOfFloors;
        public int CurrentFloor;
        public SpriteSheet Sheet;

        public Map(MapEditorForm Ref,Size mapSize, int numOfFloors,int currentFloor)
        {
            MapSize = mapSize;

            Sheet = new SpriteSheet(Ref.pbMap, Ref.HeightInMap, Ref.WidthInMap);
            Sheet.BackgroundColor = Color.Black;
            Sheet.ClearAll();

            NumOfFloors = numOfFloors;
            CurrentFloor = currentFloor;

            Tiles = new Tile[NumOfFloors, MapSize.Width,MapSize.Height];
        }
    }
}
