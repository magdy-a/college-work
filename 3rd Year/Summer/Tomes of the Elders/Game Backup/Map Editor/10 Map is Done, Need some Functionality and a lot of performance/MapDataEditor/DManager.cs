using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using DataEditor.Data;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataEditor
{
    public class DManager
    {   
        #region Fields
        
        /// <summary>
        /// DataEditor Objects in Array List
        /// </summary>
        public ArrayList Objects;
        /// <summary>
        /// The (20*20) Sheets that carries all Textures for the Game
        /// </summary>
        public ArrayList ProjectSheets;

        /// <summary>
        /// Number of Sheet Current Used
        /// </summary>
        private int CurrentSheetNumber;
        /// <summary>
        /// Next Sprite Number to Write in
        /// </summary>
        private int NextInsertionPosition;
        /// <summary>
        /// Last Sprite ID in the Sheet starting from Zero, is ( (Width*Height) - 1 )
        /// </summary>
        private static int SheetLastSpriteNumber;
        /// <summary>
        /// Project Sheet Size (20*20)
        /// </summary>
        public static Size SheetSize;
        /// <summary>
        /// A Dummy Picture Box, to send it to the ctor in SpriteSheetMaker new Object
        /// </summary>
        private static PictureBox DummyPictureBoxRef;

        #endregion

        /// <summary>
        /// Ctor
        /// </summary>
        public DManager()
        {
            Objects = new ArrayList();
            ProjectSheets = new ArrayList();

            SheetSize = new Size(20,20);
            SheetLastSpriteNumber = (SheetSize.Width * SheetSize.Height) - 1;

            NextInsertionPosition = 0;
            CurrentSheetNumber = 0;

            DummyPictureBoxRef = new PictureBox();

            AddNewSheet();
        }

        /// <summary>
        /// Adds a new Object ( Object's Data & it's Texture ) to the Project
        /// </summary>
        /// <param name="NewItem">Data of the New Item</param>
        /// <param name="SSM">Sprite Sheet Maker Object which carries the Textures to add</param>
        /// 
        public void AddObject(ParentDataObject NewItem, SpriteSheet SSM)
        {
            //Add Textures to the ProjectSheets
            AddTexturesToTheSheet(NewItem.ID, NewItem.Length, SSM);

            //Add the object to the array
            Objects.Add(NewItem);

            //Change the Sheet Number and Sprite Number
            if ((SheetLastSpriteNumber + 1) - NextInsertionPosition > NewItem.Length)
                NextInsertionPosition += NewItem.Length;
            else
                NextInsertionPosition += NewItem.Length - (SheetLastSpriteNumber + 1);
        }

        /// <summary>
        /// Takes the path of the (.dat) file, save the ArrayList of Objects in it
        /// in the Parent Folder same as (.dat) file, saves the Project Sheets in (png) files
        /// </summary>
        /// <param name="FilePath">Path to the File contains the Objects</param>
        public void Save(String FilePath)
        {
            //Save the ProjectSheets
            String SheetsCommonName = FilePath.Substring(0, FilePath.Length - 4);
            String tmp;
            for (int i = 1; i <= CurrentSheetNumber; i++)
            {
                tmp = SheetsCommonName + " Sheet " + i.ToString() + ".png";
                if (File.Exists(tmp))
                    File.Delete(tmp);
                ((SpriteSheet)ProjectSheets[i - 1]).Bitmap.Save(tmp);
            }

            //Save the objects to the file (.dat)
            Stream stream = File.Open(FilePath, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, Objects);
            stream.Close();
        }

        /// <summary>
        /// Save's Texture of an Object in ProjectSheets
        /// </summary>
        ///<param name="ID">Object's ID</param>
        /// <param name="Length">Count of Texutres used by this Object</param>
        /// <param name="SSM">SpriteSheetMaker Object which carries the Textures of this Object</param>
        private void AddTexturesToTheSheet(int ID, int Length, SpriteSheet SSM)
        {
            int SheetEmptySpace;
            int ObjectSpriteNumber = 0, ObjectSheetNumber = 0;
            int X = 0, Y = 0;
            
            Bitmap[] Sprites = SSM.SheetBitmaps();

            ParentDataObject.DefineID(ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);

            SheetEmptySpace = SheetLastSpriteNumber - ObjectSpriteNumber + 1;

            if (Length <= SheetEmptySpace)
            {
                for (int i = 0; i < Length; i++)
                {
                    SpriteSheet.GetTextureDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    ((SpriteSheet)ProjectSheets[CurrentSheetNumber - 1]).SetSprite(X, Y, Sprites[i]);
                }
            }
            else
            {
                for (int i = 0; i < SheetEmptySpace; i++)
                {
                    SpriteSheet.GetTextureDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    ((SpriteSheet)ProjectSheets[CurrentSheetNumber - 1]).SetSprite(X, Y, Sprites[i]);
                }

                AddNewSheet();

                for (int i = 0; i < Length - SheetEmptySpace; i++)
                {
                    SpriteSheet.GetTextureDimensions(i, SheetSize.Width, ref Y, ref X);
                    ((SpriteSheet)ProjectSheets[CurrentSheetNumber - 1]).SetSprite(X, Y, Sprites[i + SheetEmptySpace]);
                }
            }
        }
        /// <summary>
        /// Loads all Data of a specific version of the Project
        /// </summary>
        /// <param name="FilePath">the File Path of the (.dat) file</param>
        /// <param name="Objects">ArrayList to carry back the Objects</param>
        /// <param name="Sheets">ArrayList to carry back the Sheets</param>
        public void Load(String FilePath)
        {
            //Load Objects
            Objects = LoadObjects(FilePath);
            //Load ProjectSheets
            ProjectSheets = LoadSheets(FilePath);
        }
        /// <summary>
        /// Load Objects from (.dat) file
        /// </summary>
        /// <param name="FilePath">FilePath to the (.dat) file</param>
        /// <param name="Objects">ArrayList which will carry the Objects back</param>
        public ArrayList LoadObjects(String FilePath)
        {
            //Load the Objects file ( ArrayList )
            ArrayList Objects;
            Stream stream = File.Open(FilePath, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            Objects = (ArrayList)bFormatter.Deserialize(stream);
            stream.Close();
            return Objects;
        }
        /// <summary>
        /// Read all Sheets in the same folder as the FilePath
        /// </summary>
        /// <param name="FilePath">The Path that contains the Objects file</param>
        /// <param name="Sheets">ArrayList which will carry the Sheets back</param>
        public ArrayList LoadSheets(String FilePath)
        {
            SpriteSheet SS;
            ArrayList Sheets = new ArrayList();
            char[] Splitters = { '.' };
            String[] Splits = FilePath.Split(Splitters);
            String CommonSheetName = Splits[0];
            //String CommonSheetName = FilePath.Substring(0, FilePath.Length - 4);
            String tmp;
            CurrentSheetNumber = GetNumOfSheets();
            for (int i = 1; i <= CurrentSheetNumber; i++)
            {
                tmp = CommonSheetName + " Sheet " + i.ToString() + ".png";
                SS = new SpriteSheet(ref DummyPictureBoxRef, SheetSize.Height, SheetSize.Width);
                Stream Stream = File.Open(tmp,FileMode.Open);
                SS.Bitmap = (Bitmap)Image.FromStream(Stream);
                Stream.Close();

                Sheets.Add(SS);
            }
            NextInsertionPosition = GetNextInsertionPosition();
            return Sheets;
        }

        /// <summary>
        /// Creats a SpriteSheetMaker for an Object, get's the Textures, sets the Variables
        /// </summary>
        /// <param name="Object">ParentDataObject</param>
        /// <returns>SpriteSheetMaker SSM which has the Textures of the Object</returns>
        public SpriteSheet CreateSpriteSheetMakerForObject(ParentDataObject Object)
        {
            int SpriteWidth, SpriteHeight;
            Bitmap[] Textures;
            ParentDataObject tmp;
            SpriteSheet SSM;

            if (((ParentDataObject)Object).GetType() == typeof(Item))
            {
                tmp = (Item)Object;
                SpriteWidth = ((Item)tmp).Width;
                SpriteHeight = ((Item)tmp).Height;
            }
            else if (((ParentDataObject)Object).GetType() == typeof(Wall))
            {
                tmp = (Wall)Object;

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
                tmp = (Ground)Object;

                SpriteWidth = 10;
                SpriteHeight = (int)(Math.Ceiling((double)(tmp.Length) / 10.0));
            }

            SSM = new SpriteSheet(ref DummyPictureBoxRef, SpriteHeight, SpriteWidth);

            Textures = GetTexturesFromSheets(tmp.ID, tmp.Length);

            for (int g = 0; g < tmp.Length; g++)
                SSM.AddSprite(Textures[g]);

            return SSM;
        }

        /// <summary>
        /// Gets Object's Textues form Sheets using the ID
        /// </summary>
        /// <param name="ID">Object's ID</param>
        /// <param name="Length">The Count of Object's Textures</param>
        /// <returns>Bitmap[] of this Object's Textures</returns>
        public Bitmap[] GetTexturesFromSheets(int ID, int Length)
        {
            int SheetEmptySpace;
            int ObjectSpriteNumber = 0, ObjectSheetNumber = 0;
            int X = 0, Y = 0;

            ParentDataObject.DefineID(ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);

            SheetEmptySpace = SheetLastSpriteNumber - ObjectSpriteNumber + 1;

            Bitmap[] Textures = new Bitmap[Length];

            if (Length <= SheetEmptySpace)
            {
                for (int i = 0; i < Length; i++)
                {
                    SpriteSheet.GetTextureDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    Textures[i] = ((SpriteSheet)ProjectSheets[ObjectSheetNumber - 1]).GetSprite(X, Y);
                }
            }
            else
            {
                for (int i = 0; i < SheetEmptySpace; i++)
                {
                    SpriteSheet.GetTextureDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    Textures[i] = ((SpriteSheet)ProjectSheets[ObjectSheetNumber - 1]).GetSprite(X, Y);
                }
                for (int i = 0; i < Length - SheetEmptySpace; i++)
                {
                    SpriteSheet.GetTextureDimensions(i, SheetSize.Width, ref Y, ref X);
                    Textures[i + SheetEmptySpace] = ((SpriteSheet)ProjectSheets[ObjectSheetNumber]).GetSprite(X, Y);
                }
            }
            return Textures;
        }

        /// <summary>
        /// Adds new Sheets to Project Sheets
        /// </summary>
        private void AddNewSheet()
        {
            ProjectSheets.Add(new SpriteSheet(ref DummyPictureBoxRef, SheetSize.Height, SheetSize.Width));
            CurrentSheetNumber++;
        }

        /// <summary>
        /// Gets the Number of Sheets used by the DataEditor
        /// </summary>
        /// <returns>Number of Sheets</returns>
        private int GetNumOfSheets()
        {
            int NumOfSheets;

            ParentDataObject LastObject = ((ParentDataObject)Objects[Objects.Count - 1]);


            int LastObjectLength = ((ParentDataObject)Objects[Objects.Count - 1]).Length;

            NumOfSheets = LastObject.SheetNumber;

            if (LastObject.SpriteNumber + LastObjectLength > SheetLastSpriteNumber)
                NumOfSheets++;

            return NumOfSheets;
        }

        /// <summary>
        /// Gets the Next Insertion Position using the ArrayList of Objects
        /// </summary>
        ///
        private int GetNextInsertionPosition()
        {
            int NIP;

            ParentDataObject LastObject = ((ParentDataObject)Objects[Objects.Count - 1]);


            NIP = LastObject.SpriteNumber + LastObject.Length;

            if (NIP > SheetLastSpriteNumber)
                NIP -= (SheetLastSpriteNumber + 1);

            return NIP;
        }

        /// <summary>
        /// The Next Object's ID
        /// </summary>
        /// <returns>Int NextID</returns>
        internal int GetNextID()
        {
            return (CurrentSheetNumber * 1000) + NextInsertionPosition;
        }

        /// <summary>
        /// Gets the Sprite Sheet in Specified Index
        /// </summary>
        /// <param name="p">Sheet Number</param>
        /// <returns>Sheet's Image</returns>
        internal Image GetSpriteSheet(int p)
        {
            return ((SpriteSheet)ProjectSheets[p - 1]).Bitmap;
        }
    }
}
