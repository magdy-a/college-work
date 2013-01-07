using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using MapDataEditor.Data;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MapDataEditor
{
    public class ProjectManager
    {   
        //Remember to Use these two ListViews in Add and Load
        //Delete SpriteSheetMaker ArrayList
        //Improve You Naming System :) ( GetDimension )
        //Check again from setNextSpriteNumber Fn
        //Check the error in Second.dat in Ahmad Folder in C://
        //Try it again ... it uses First.dat and adds an Item ( 3 * 4 ), error: leavs 16 space before it adds the Item's Textures
        //You change the order of the Textures in the Sheet in Save Functio ( will move this part into AddObject Fn ).

        //Issues in Zoom's Part : 
        //1. in AddObjectForm, set the Image Size in the SpriteSheetMaker (Exactly) as the Input should be ( according to the Object's Width & Height ), so when i click in another position outside this small area ( in ( 255 0 255 ) ) it acts as if a swap operation will happen, which shouldn't happen.
        //2. in when adding a Ground, the SpriteSheetForm Input Image size is bigger than needed

        #region Fields

        private ListView SheetslistView;
        private ListView ObjectslistView;
        
        /// <summary>
        /// Sprites Sheets Array for which carries the Textures for every Object
        /// </summary>
        private ArrayList SpriteSheetMaker;
        /// <summary>
        /// Game Objects in Array List
        /// </summary>
        private ArrayList ParentDataObject;
        /// <summary>
        /// the (20*20) Sheets that carries all Textures for the Game
        /// </summary>
        private ArrayList ProjectSheets;

        /// <summary>
        /// Number of Sheet Current Used
        /// </summary>
        private int CurrentSheetNumber;
        /// <summary>
        /// Next Sprite Number to Write in in Project Sheets
        /// </summary>
        int NextInsertionPosition;
        /// <summary>
        /// Last Sprite ID in the Sheet starting from Zero, is ( (Width*Height) - 1 )
        /// </summary>
        private static int SheetLastSpriteNumber;
        /// <summary>
        /// Project Sheet Size (20*20)
        /// </summary>
        private Size SheetSize;
        /// <summary>
        /// A Dummy Picture Box, to send it to the ctor in SpriteSheetMaker new Object
        /// </summary>
        private static PictureBox DummyPictureBoxRef;

        #endregion

        /// <summary>
        /// Ctor
        /// </summary>
        public ProjectManager(ListView SheetsLV,ListView ObjectsLV)
        {
            SheetslistView = SheetsLV;
            ObjectslistView = ObjectsLV;
            SpriteSheetMaker = new ArrayList();
            ParentDataObject = new ArrayList();
            ProjectSheets = new ArrayList();
            SheetSize = new Size(20,20);
            SheetLastSpriteNumber = (SheetSize.Width * SheetSize.Height) - 1;
            NextInsertionPosition = 0;
            CurrentSheetNumber = 1;
            DummyPictureBoxRef = new PictureBox();
        }

        /// <summary>
        /// Adds a new Object ( Object's Data & it's Texture ) to the Project
        /// </summary>
        /// <param name="NewItem">Data of the New Item</param>
        /// <param name="SSM">Sprite Sheet Maker Object which carries the Textures to add</param>
        /// 
        internal void AddObject(ParentDataObject NewItem, SpriteSheetMaker SSM)
        {
            //Add the object to the array
            ParentDataObject.Add(NewItem);

            //Add the Sprite to the Editor Sheets
            SpriteSheetMaker.Add(SSM);

            int ObjectSpriteNumber = 0, ObjectSheetNumber = 0;

            DefineID(NewItem.ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);
            AddTexturesToTheSheet(ObjectSpriteNumber, ObjectSheetNumber, NewItem.Length, SSM);



            //Change the Sheet Number and Sprite Number
            if (SheetLastSpriteNumber - NextInsertionPosition > NewItem.Length)
            {
                NextInsertionPosition += NewItem.Length;
            }
            else
            {
                NextInsertionPosition += NewItem.Length - (SheetLastSpriteNumber - NextInsertionPosition);
                CurrentSheetNumber++;
            }
        }

        /// <summary>
        /// Takes the path of the (.dat) file, save the ArrayList of Objects in it
        /// in the Parent Folder same as (.dat) file, saves the Project Sheets in (Png) files
        /// </summary>
        /// <param name="p"></param>
        internal void Save(String p)
        {
            //save the objects to the BinaryFile ( .dat  )
            Stream stream = File.Open(p, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, ParentDataObject);
            stream.Close();

            String SheetsCommonName = p.Substring(0, p.Length - 4);
            String tmp;
            for (int i = 1; i <= CurrentSheetNumber; i++)
            {
                tmp = SheetsCommonName + " Sheet " + i.ToString() + ".png";
                if (File.Exists(tmp))
                    File.Delete(tmp);
                ((SpriteSheetMaker)ProjectSheets[i-1]).Bitmap.Save(tmp);
            }
        }

        /// <summary>
        /// Save's Texture of an Object in ProjectSheets
        /// </summary>
        /// <param name="ObjectSpriteNumber">(Starting Sprite Number in ObjectSheetNumber) the 3 right digits of the Object's ID</param>
        /// <param name="ObjectSheetNumber">(Starting Sheet Number )the rest of the Object's ID, without the 3 right digits</param>
        /// <param name="Length">Count of Texutres used in this Object</param>
        /// <param name="SSM">SpriteSheetMaker Object which carries the Textures of this Object</param>
        private void AddTexturesToTheSheet(int ObjectSpriteNumber, int ObjectSheetNumber,int Length, SpriteSheetMaker SSM)
        {
            int SheetEmptySpace = SheetLastSpriteNumber - ObjectSpriteNumber;
            Bitmap[] Sprites = SSM.SheetBitmaps();
            int X = 0, Y = 0;
            if (ObjectSheetNumber > ProjectSheets.Count)
            {
                AddNewSheet();
            }
            if (Length <= SheetEmptySpace)
            {
                for (int i = 0; i < Length; i++)
                {
                    GetTextureDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber - 1]).SetSprite(X, Y, Sprites[i]);
                }
            }
            else
            {
                //not sure about the correctness of this else code ... so check it again
                for (int i = 0; i < SheetEmptySpace; i++)
                {
                    GetTextureDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber - 1]).SetSprite(X, Y, Sprites[i]);
                }
                AddNewSheet();
                for (int i = 0; i < Length-SheetEmptySpace; i++)
                {
                    GetTextureDimensions(i, SheetSize.Width, ref Y, ref X);
                    ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber]).SetSprite(X, Y, Sprites[i+SheetEmptySpace]);
                }
                //you really do use that loop a lot ... so why not to name it in a function ?!
            }
        }

        /// <summary>
        /// Loads all Data of a specific version of the Project
        /// </summary>
        /// <param name="FilePath">the File Path of the (.dat) file</param>
        internal void Load(String FilePath)
        {
            int ObjectSheetNumber = 0, ObjectSpriteNumber = 0;
            int SpriteWidth, SpriteHeight;
            SpriteSheetMaker SSM;

            Stream stream = File.Open(FilePath, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            ParentDataObject = (ArrayList)bFormatter.Deserialize(stream);
            stream.Close();

            ReadAllSheets(FilePath);

            //Get the Sprites from the Project Sheet
            Bitmap[] Textures;
            ParentDataObject tmp;
            for (int i = 0; i < ParentDataObject.Count; i++)
            {
                if (((ParentDataObject)ParentDataObject[i]).GetType() == typeof(Item))
                {
                    tmp = (Item)ParentDataObject[i];
                    SpriteWidth = ((Item)tmp).Width;
                    SpriteHeight = ((Item)tmp).Height;
                }
                else if (((ParentDataObject)ParentDataObject[i]).GetType() == typeof(Wall))
                {
                    tmp = (Wall)ParentDataObject[i];

                    if (((Wall)tmp).Tall == true)
                    {
                        SpriteWidth = 8;
                        SpriteHeight = 2;
                    }
                    else
                    {
                        SpriteWidth = 4;
                        SpriteHeight = 1;
                    }
                }
                else
                {
                    tmp = (Ground)ParentDataObject[i];

                    SpriteWidth = 10;
                    SpriteHeight = (int)(Math.Ceiling((double)(tmp.Length) / 10.0));
                }


                SSM = new SpriteSheetMaker(ref DummyPictureBoxRef, SpriteHeight, SpriteWidth);

                DefineID(tmp.ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);

                Textures = GetTexturesFromSheets(ObjectSpriteNumber, ObjectSheetNumber, tmp.Length);

                for (int g = 0; g < tmp.Length; g++)
                    SSM.AddSprite(Textures[g]);

                SpriteSheetMaker.Add(SSM);
            }

        }

        /// <summary>
        /// Using ID (ObjectSpriteNumber,ObjectSheetNumber) & the Length of the Object
        /// it finds its Textures from ProjectSheets
        /// </summary>
        /// <param name="ObjectSpriteNumber">The Sprite Number in Starting Sheet</param>
        /// <param name="ObjectSheetNumber">The Sheet Number which this Object's Textures starts in</param>
        /// <param name="Length">The Count of Object's Textures</param>
        /// <returns>Bitmap[] of this Object's Textures</returns>
        private Bitmap[] GetTexturesFromSheets(int ObjectSpriteNumber, int ObjectSheetNumber, int Length)
        {
            int SheetEmptySpace = SheetLastSpriteNumber - ObjectSpriteNumber;
            int X = 0, Y = 0;
            Bitmap[] Textures = new Bitmap[Length];
            if (Length <= SheetEmptySpace)
            {
                for (int i = 0; i < Length; i++)
                {
                    GetTextureDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    Textures[i] = ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber - 1]).GetSprite(X, Y);
                }
            }
            else
            {
                for (int i = 0; i < SheetEmptySpace; i++)
                {
                    GetTextureDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    Textures[i] = ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber - 1]).GetSprite(X, Y);
                }
                for (int i = 0; i < Length - SheetEmptySpace; i++)
                {
                    GetTextureDimensions(i, SheetSize.Width, ref Y, ref X);
                    Textures[i + SheetEmptySpace] = ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber]).GetSprite(X, Y);
                }
            }
            return Textures;
        }

        /// <summary>
        /// Separets the ID to it's Two Parts
        /// </summary>
        /// <param name="ID">The ID to Define</param>
        /// <param name="ObjectSpriteNumber">The 3 right digits in the ID, means the Number of Sprite in the Starting Sheet</param>
        /// <param name="ObjectSheetNumber">The rest of the ID without the 3 right digits, means the Number of Starting Sheet</param>
        private void DefineID(int ID, ref int ObjectSpriteNumber, ref int ObjectSheetNumber)
        {
            ObjectSpriteNumber = ID % 1000;
            ObjectSheetNumber = ID / 1000;
        }

        /// <summary>
        /// takes the number of Sprite and returns the Row&Column Number of, ( It's X&Y )
        /// </summary>
        /// <param name="Number">The Number of the Sprite</param>
        /// <param name="Width">The Width of the Sheet contains Sprites</param>
        /// <param name="RowNumber">(ref) Returns the Row Number</param>
        /// <param name="ColumnNumber">(ref) Returns the Column Number</param>
        private void GetTextureDimensions(int Number, int Width, ref int RowNumber, ref int ColumnNumber)
        {
            if (Number == 0)
            {
                RowNumber = ColumnNumber = 0;
                return;
            }
            RowNumber = Number / Width;
            ColumnNumber = Number - (RowNumber * Width);
        }

        /// <summary>
        /// Adds new Sheets to Project Sheets
        /// </summary>
        private void AddNewSheet()
        {
            ProjectSheets.Add(new SpriteSheetMaker(ref DummyPictureBoxRef, SheetSize.Height, SheetSize.Width));
        }

        /// <summary>
        /// Read all Sheets in same folder as the FilePath
        /// </summary>
        /// <param name="FilePath">The Path that contains the Objects</param>
        private void ReadAllSheets(String FilePath)
        {
            SpriteSheetMaker SSM;
            ProjectSheets = new ArrayList();
            String CommonSheetName = FilePath.Substring(0, FilePath.Length - 4);
            String tmp;
            for (int i = 1; i <= GetNumOfSheets(); i++)
            {
                tmp = CommonSheetName + " Sheet " + i.ToString() + ".png";
                SSM = new SpriteSheetMaker(ref DummyPictureBoxRef, SheetSize.Height, SheetSize.Width);
                SSM.Bitmap = (Bitmap)Image.FromFile(tmp);
                ProjectSheets.Add(SSM);
            }
            NextInsertionPosition = GetNextInsertionPosition();
        }

        /// <summary>
        /// Gets the Number of Sheet used by the Game
        /// </summary>
        /// <returns>Int Number of Sheets</returns>
        private int GetNumOfSheets()
        {
            int ObjectSheetNumber = 0,ObjectSpriteNumber = 0, NumOfSheets;

            int LastObjectLength = ((ParentDataObject)ParentDataObject[ParentDataObject.Count - 1]).Length;

            DefineID(((ParentDataObject)ParentDataObject[ParentDataObject.Count - 1]).ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);

            NumOfSheets = ObjectSheetNumber;

            if (ObjectSpriteNumber + LastObjectLength > SheetLastSpriteNumber)
                NumOfSheets++;

            return NumOfSheets;
        }

        /// <summary>
        /// Sets the NextSpriteNumber using the ArrayList of Objects, exactly the last one's ID & Length
        /// </summary>
        ///
        private int GetNextInsertionPosition()
        {
            int NIP;
            int ObjectSpriteNumber = 0, ObjectSheetNumber = 0;
            ParentDataObject LastObject = ((ParentDataObject)ParentDataObject[ParentDataObject.Count - 1]);
            DefineID(LastObject.ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);
            NIP = ObjectSpriteNumber + LastObject.Length;
            if (NIP > SheetLastSpriteNumber)
                NIP -= SheetLastSpriteNumber;
            return NIP;
        }

        /// <summary>
        /// The Next Object's ID
        /// </summary>
        /// <returns>Int ID</returns>
        internal int GetNextID()
        {
            //gets the next ID for the Project Sheets
            return (CurrentSheetNumber * 1000) + NextInsertionPosition;
        }

        /// <summary>
        /// Gets the Sprite Sheet in Specified Index
        /// </summary>
        /// <param name="p">Sheet Number</param>
        /// <returns>Sheet's Image</returns>
        internal Image GetSpriteSheet(int p)
        {
            return ((SpriteSheetMaker)ProjectSheets[p - 1]).Bitmap;
        }
    }
}
