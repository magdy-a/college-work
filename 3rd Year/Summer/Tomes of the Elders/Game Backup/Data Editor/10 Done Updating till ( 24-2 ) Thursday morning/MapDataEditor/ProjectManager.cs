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
        #region Fields

        private ListView SheetslistView;
        private ListView ObjectslistView;
        
        /// <summary>
        /// DataEditor Objects in Array List
        /// </summary>
        private ArrayList ParentDataObject;
        /// <summary>
        /// The (20*20) Sheets that carries all Textures for the Game
        /// </summary>
        private ArrayList ProjectSheets;

        /// <summary>
        /// Number of Sheet Current Used
        /// </summary>
        private int CurrentSheetNumber;
        /// <summary>
        /// Next Sprite Number to Write in
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

            ParentDataObject = new ArrayList();
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
        internal void AddObject(ParentDataObject NewItem, SpriteSheetMaker SSM)
        {
            //Add Textures to the ProjectSheets
            int ObjectSpriteNumber = 0, ObjectSheetNumber = 0;

            DefineID(NewItem.ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);
            AddTexturesToTheSheet(ObjectSpriteNumber, NewItem.Length, SSM);

            //Add the object to the array
            ParentDataObject.Add(NewItem);

            ObjectslistView.Items.Add(NewItem.Name + '(' + NewItem.ID.ToString() + ')');

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
        internal void Save(String FilePath)
        {
            //Save the ProjectSheets
            String SheetsCommonName = FilePath.Substring(0, FilePath.Length - 4);
            String tmp;
            for (int i = 1; i <= CurrentSheetNumber; i++)
            {
                tmp = SheetsCommonName + " Sheet " + i.ToString() + ".png";
                if (File.Exists(tmp))
                    File.Delete(tmp);
                ((SpriteSheetMaker)ProjectSheets[i - 1]).Bitmap.Save(tmp);
            }

            //Save the objects to the file (.dat)
            Stream stream = File.Open(FilePath, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, ParentDataObject);
            stream.Close();
        }

        /// <summary>
        /// Save's Texture of an Object in ProjectSheets
        /// </summary>
        /// <param name="ObjectSpriteNumber">(Starting Sprite Number in ObjectSheetNumber) the 3 right digits of the Object's ID</param>
        /// <param name="ObjectSheetNumber">(Starting Sheet Number )the rest of the Object's ID, without the 3 right digits</param>
        /// <param name="Length">Count of Texutres used by this Object</param>
        /// <param name="SSM">SpriteSheetMaker Object which carries the Textures of this Object</param>
        internal void AddTexturesToTheSheet(int ObjectSpriteNumber, int Length, SpriteSheetMaker SSM)
        {
            int SheetEmptySpace = SheetLastSpriteNumber - ObjectSpriteNumber + 1;
            Bitmap[] Sprites = SSM.SheetBitmaps();
            int X = 0, Y = 0;

            if (Length <= SheetEmptySpace)
            {
                for (int i = 0; i < Length; i++)
                {
                    GetTextureDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    ((SpriteSheetMaker)ProjectSheets[CurrentSheetNumber - 1]).SetSprite(X, Y, Sprites[i]);
                }
            }
            else
            {
                for (int i = 0; i < SheetEmptySpace; i++)
                {
                    GetTextureDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    ((SpriteSheetMaker)ProjectSheets[CurrentSheetNumber - 1]).SetSprite(X, Y, Sprites[i]);
                }

                AddNewSheet();

                for (int i = 0; i < Length-SheetEmptySpace; i++)
                {
                    GetTextureDimensions(i, SheetSize.Width, ref Y, ref X);
                    ((SpriteSheetMaker)ProjectSheets[CurrentSheetNumber -1]).SetSprite(X, Y, Sprites[i+SheetEmptySpace]);
                }
            }
        }

        /// <summary>
        /// Loads all Data of a specific version of the Project
        /// </summary>
        /// <param name="FilePath">the File Path of the (.dat) file</param>
        internal void Load(String FilePath)
        {
            //Load the Objects file ( ArrayList )
            Stream stream = File.Open(FilePath, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            ParentDataObject = (ArrayList)bFormatter.Deserialize(stream);
            stream.Close();

            //Load ProjectSheets
            ReadAllSheets(FilePath);
        }

        /// <summary>
        /// Read all Sheets in the same folder as the FilePath
        /// </summary>
        /// <param name="FilePath">The Path that contains the Objects file</param>
        internal void ReadAllSheets(String FilePath)
        {
            SpriteSheetMaker SSM;
            ProjectSheets = new ArrayList();
            String CommonSheetName = FilePath.Substring(0, FilePath.Length - 4);
            String tmp;
            CurrentSheetNumber = GetNumOfSheets();
            for (int i = 1; i <= CurrentSheetNumber; i++)
            {
                tmp = CommonSheetName + " Sheet " + i.ToString() + ".png";
                SSM = new SpriteSheetMaker(ref DummyPictureBoxRef, SheetSize.Height, SheetSize.Width);
                Stream Stream = File.Open(tmp,FileMode.Open);
                SSM.Bitmap = (Bitmap)Image.FromStream(Stream);
                Stream.Close();
                ProjectSheets.Add(SSM);
            }
            NextInsertionPosition = GetNextInsertionPosition();
        }

        /// <summary>
        /// Separets the ID to it's Two Parts
        /// </summary>
        /// <param name="ID">The ID to Define</param>
        /// <param name="ObjectSpriteNumber">The 3 right digits in the ID, means the Number of Sprite in the Starting Sheet</param>
        /// <param name="ObjectSheetNumber">The rest of the ID without the 3 right digits, means the Number of Starting Sheet</param>
        static internal void DefineID(int ID, ref int ObjectSpriteNumber, ref int ObjectSheetNumber)
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
        static internal void GetTextureDimensions(int Number, int Width, ref int RowNumber, ref int ColumnNumber)
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
        internal void AddNewSheet()
        {
            ProjectSheets.Add(new SpriteSheetMaker(ref DummyPictureBoxRef, SheetSize.Height, SheetSize.Width));
            CurrentSheetNumber++;
            SheetslistView.Items.Add("Sheet " + CurrentSheetNumber.ToString());
        }

        /// <summary>
        /// Gets the Number of Sheets used by the DataEditor
        /// </summary>
        /// <returns>Number of Sheets</returns>
        internal int GetNumOfSheets()
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
        /// Gets the Next Insertion Position using the ArrayList of Objects
        /// </summary>
        ///
        internal int GetNextInsertionPosition()
        {
            int NIP;
            int ObjectSpriteNumber = 0, ObjectSheetNumber = 0;

            ParentDataObject LastObject = ((ParentDataObject)ParentDataObject[ParentDataObject.Count - 1]);

            DefineID(LastObject.ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);

            NIP = ObjectSpriteNumber + LastObject.Length;

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
            return ((SpriteSheetMaker)ProjectSheets[p - 1]).Bitmap;
        }
    }
}
