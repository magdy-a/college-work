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
    public class Project
    {
        private System.Windows.Forms.ListView SheetslistView;
        private System.Windows.Forms.ListView ItemslistView;

        private ArrayList SpriteSheetMaker;
        private ArrayList ParentDataObject;

        private ArrayList ProjectSheets;
        private int SheetNumber, LastSpriteNumber;
        private static int MaxSpriteNumber;
        private Size SheetSize;

        private static PictureBox DummyPictureBoxRef;

        public Project()
        {
            SpriteSheetMaker = new ArrayList();
            ParentDataObject = new ArrayList();
            ProjectSheets = new ArrayList();
            SheetSize = new Size(20,20);
            MaxSpriteNumber = (SheetSize.Width * SheetSize.Height) - 1;
            LastSpriteNumber = 0;
            SheetNumber = 1;
            DummyPictureBoxRef = new PictureBox();
        }

        internal void Save(string p)
        {
            //save the objects to the BinaryFile ( .odt  )
            Stream stream = File.Open(p, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, ParentDataObject);
            //for (int i = 0; i < ParentDataObject.Count; i++)
            //    bFormatter.Serialize(stream, ParentDataObject[i]);

            //add the Sprites for every Object to the Project Sheets
            int ObjectSpriteNumber = 0, ObjectSheetNumber = 0;
            //To save the Sheets to the same parent folder as the Objects
            String ParentFolder = GetParentFolder(p);
            for (int i = 0; i < ParentDataObject.Count; i++)
            {
                DefineID(((ParentDataObject)ParentDataObject[i]).ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);
                AddTexturesToTheSheet(ObjectSpriteNumber, ObjectSheetNumber, ((ParentDataObject)ParentDataObject[i]).Length, ((SpriteSheetMaker)SpriteSheetMaker[i]));
            }
            for (int i = 0; i < SheetNumber; i++)
            {
                ((SpriteSheetMaker)ProjectSheets[i]).Bitmap.Save(ParentFolder+(i+1).ToString()+".png");
            }
            //Remember to create a txt file in the parent folder as Sheets holds the sheets number to Know how many to load
            stream = File.Open(ParentFolder + "NumOfSheets.txt", FileMode.Create);
            StreamWriter SW = new StreamWriter(stream);
            SW.Write(SheetNumber.ToString());
            SW.Close();
            stream.Close();
        }

        private void AddTexturesToTheSheet(int ObjectSpriteNumber, int ObjectSheetNumber,int Length, SpriteSheetMaker SSM)
        {
            int SheetEmptySpace = MaxSpriteNumber - ObjectSpriteNumber;
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
                    GetDimensions(ObjectSpriteNumber+i,SheetSize.Width,ref Y,ref X);
                    ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber-1]).SetSprite(X, Y, Sprites[i]);
                }
            }
            else
            {
                //not sure about the correctness of this else code ... so check it again
                for (int i = 0; i < SheetEmptySpace; i++)
                {
                    GetDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber - 1]).SetSprite(X, Y, Sprites[i]);
                }
                AddNewSheet();
                for (int i = 0; i < Length-SheetEmptySpace; i++)
                {
                    GetDimensions(i, SheetSize.Width, ref Y, ref X);
                    ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber]).SetSprite(X, Y, Sprites[i+SheetEmptySpace]);
                }
                //you really do use that loop a lot ... so why not to name it in a function ?!
            }
        }
        private void DefineID(int ID, ref int ObjectSpriteNumber, ref int ObjectSheetNumber)
        {
            ObjectSpriteNumber = ID % 1000;
            ObjectSheetNumber = ID / 1000;
        }
        private string GetParentFolder(string p)
        {
            string[] Splitters = { "\\" };
            string[] SplitObjectSavePath = p.Split(Splitters, StringSplitOptions.None);
            string ParentFolder = "";
            for (int i = 0; i < SplitObjectSavePath.Length - 1; i++)
            {
                ParentFolder += SplitObjectSavePath[i] + "\\";
            }
            return ParentFolder;
        }
        private void GetDimensions(int Number, int Width, ref int RowNumber, ref int ColumnNumber)
        {
            if (Number == 0)
            {
                RowNumber = ColumnNumber = 0;
                return;
            }
            RowNumber = Number / Width;
            ColumnNumber = Number - (RowNumber * Width);
        }
        private void AddNewSheet()
        {
            ProjectSheets.Add(new SpriteSheetMaker(ref DummyPictureBoxRef, SheetSize.Height, SheetSize.Width));
        }

        internal void Load(string p)
        {
            //the string p should alocate the ( .dat ) file, then i'll get the parent folder that should contain
            //the sheets and the txt with fixed name ( SheetNumber.txt ) for example

            string ParentFolder = GetParentFolder(p);
            int NumofSheets, ObjectSheetNumber = 0, ObjectSpriteNumber = 0;
            int SpriteWidth, SpriteHeight;
            SpriteSheetMaker SSM;

            Stream stream = File.Open(p, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            ParentDataObject = (ArrayList)bFormatter.Deserialize(stream);

            stream = File.Open(ParentFolder + "NumOfSheets.txt", FileMode.Open);
            StreamReader SR = new StreamReader(stream);
            NumofSheets = int.Parse(SR.ReadLine());
            SR.Close();
            stream.Close();

            //Don't know yet how to deserialize a file ( contains a list ) ( what is the ( end of file ) here ) ?

            //gonna read all Sheets
            ProjectSheets = new ArrayList();
            for (int i = 0; i < NumofSheets; i++)
            {
                SSM = new SpriteSheetMaker(ref DummyPictureBoxRef,SheetSize.Height,SheetSize.Width);
                SSM.Bitmap = (Bitmap)Image.FromFile(ParentFolder + (i + 1).ToString() + ".png");
                ProjectSheets.Add(SSM);
            }

            //getting the Sprites from the Project Sheet
            for (int i = 0; i < ParentDataObject.Count; i++)
            {
                int X = 0, Y = 0;
                Bitmap[] Textures;

                if(((ParentDataObject)ParentDataObject[i]).GetType() == typeof(Item)){
                    Item tmp = (Item)ParentDataObject[i];

                    SpriteWidth = tmp.Width;
                    SpriteHeight = tmp.Height;

                    SSM = new SpriteSheetMaker(ref DummyPictureBoxRef, SpriteHeight, SpriteWidth);

                    DefineID(tmp.ID,ref ObjectSpriteNumber,ref ObjectSheetNumber);

                    Textures = GetTexturesFromSheets(ObjectSpriteNumber, ObjectSheetNumber, tmp.Length);

                    for (int g = 0; g < tmp.Length; g++)
                    {
                        GetDimensions(g, SpriteWidth, ref Y, ref X);
                        SSM.SetSprite(X, Y, Textures[g]);
                    }
                }
                else if (((ParentDataObject)ParentDataObject[i]).GetType() == typeof(Wall))
                {
                    Wall tmp = (Wall)ParentDataObject[i];

                    if (((Wall)ParentDataObject[i]).Tall == true)
                    {
                        SpriteWidth = 8;
                        SpriteHeight = 2;
                    }
                    else
                    {
                        SpriteWidth = 4;
                        SpriteHeight = 1;
                    }

                    SSM = new SpriteSheetMaker(ref DummyPictureBoxRef, SpriteHeight, SpriteWidth);

                    DefineID(tmp.ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);

                    Textures = GetTexturesFromSheets(ObjectSpriteNumber, ObjectSheetNumber, tmp.Length);

                    for (int g = 0; g < tmp.Length; g++)
                    {
                        GetDimensions(g, SpriteWidth, ref Y, ref X);
                        SSM.SetSprite(X, Y, Textures[g]);
                    }
                }
                else
                {
                    Ground tmp = (Ground)ParentDataObject[i];

                    SpriteWidth = 10;
                    SpriteHeight = (int)(Math.Ceiling((double)(tmp.Length) / 10.0));

                    SSM = new SpriteSheetMaker(ref DummyPictureBoxRef, SpriteHeight, SpriteWidth);

                    DefineID(tmp.ID, ref ObjectSpriteNumber, ref ObjectSheetNumber);

                    Textures = GetTexturesFromSheets(ObjectSpriteNumber, ObjectSheetNumber, tmp.Length);

                    for (int g = 0; g < tmp.Length; g++)
                    {
                        GetDimensions(g, SpriteWidth, ref Y, ref X);
                        SSM.SetSprite(X, Y, Textures[g]);
                    }
                }
                //we have a tiny litte problem here ... we didn't set spritesCount in SSM, and also it couldn't be set
                //so either we use addSprite instead of setSprite Or we change in SpritesCount Property and make a set in it
                //alse the NextInsertionPosition in every SSM Object will be 0,0 because u didn't use addSprite method
                //the solution >>>> Use addSprite method <<<< :), but after a while because i just made it, i'll not delete it right now, am i ?
                SpriteSheetMaker.Add(SSM);
            }
        }

        private Bitmap[] GetTexturesFromSheets(int ObjectSpriteNumber, int ObjectSheetNumber, int Length)
        {
            int SheetEmptySpace = MaxSpriteNumber - ObjectSpriteNumber;
            int X = 0, Y = 0;
            Bitmap[] Textures = new Bitmap[Length];
            if (Length <= SheetEmptySpace)
            {
                for (int i = 0; i < Length; i++)
                {
                    GetDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    Textures[i] = ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber - 1]).GetSprite(X, Y);
                }
            }
            else
            {
                for (int i = 0; i < SheetEmptySpace; i++)
                {
                    GetDimensions(ObjectSpriteNumber + i, SheetSize.Width, ref Y, ref X);
                    Textures[i] = ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber - 1]).GetSprite(X, Y);
                }
                for (int i = 0; i < Length - SheetEmptySpace; i++)
                {
                    GetDimensions(i, SheetSize.Width, ref Y, ref X);
                    Textures[i + SheetEmptySpace] = ((SpriteSheetMaker)ProjectSheets[ObjectSheetNumber]).GetSprite(X, Y);
                }
            }
            return Textures;
        }

        internal void AddItem(ParentDataObject NewItem, SpriteSheetMaker SSM)
        {
            //Add the object to the array
            ParentDataObject.Add(NewItem);

            //Add the Sprite to the Editor Sheets

            SpriteSheetMaker.Add(SSM);

            //Change the Sheet Number and Sprite Number
            if (MaxSpriteNumber - LastSpriteNumber > NewItem.Length)
            {
                LastSpriteNumber += NewItem.Length;
            }
            else
            {
                LastSpriteNumber += NewItem.Length - (MaxSpriteNumber - LastSpriteNumber);
                SheetNumber++;
            }
        }

        internal int GetNextID()
        {
            //gets the next ID for the Project Sheets
            return (SheetNumber * 1000) + LastSpriteNumber;
        }

        internal Image GetSpriteSheet(int p)
        {
            throw new NotImplementedException();
        }
    }
}
