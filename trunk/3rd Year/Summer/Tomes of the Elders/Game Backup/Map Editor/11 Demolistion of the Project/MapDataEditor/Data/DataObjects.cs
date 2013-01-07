using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEditor;
using System.Drawing;

namespace DataEditor.Data
{
    /// <summary>
    /// Exists as a parent to all Data Objects in the editor.
    /// </summary>
    [Serializable]
    abstract public class ParentDataObject
    {
        /// <summary>
        /// ID of the Object.
        /// </summary>
        public int ID;

        /// <summary>
        /// Name of the Object.
        /// </summary>
        public string Name;

        /// <summary>
        /// Editor Parent Type.
        /// </summary>
        public ParentTypes ParentType;

        /// <summary>
        /// Editor Child Type.
        /// </summary>
        public string ChildType;

        /// <summary>
        /// Number of sprites the Object holds.
        /// </summary>
        public virtual int Length { get { return 0; } }

        /// <summary>
        /// Separets the ID to it's Two Parts
        /// </summary>
        /// <param name="ID">The ID to Define</param>
        /// <param name="ObjectSpriteNumber">The 3 right digits in the ID, means the Number of Sprite in the Starting Sheet</param>
        /// <param name="ObjectSheetNumber">The rest of the ID without the 3 right digits, means the Number of Starting Sheet</param>
        static public void DefineID(int ID, ref int ObjectSpriteNumber, ref int ObjectSheetNumber)
        {
            ObjectSpriteNumber = ID % 1000;
            ObjectSheetNumber = ID / 1000;
        }

        public int SpriteNumber
        {
            get { return ID % 1000; }
        }

        public int SheetNumber
        {
            get { return ID / 1000; }
        }

        /// <summary>
        /// Returns the height and width of the Project Sheets represented in sprites.
        /// </summary>
        public static Size ProjectSheetSize
        {
            get { return (new Size(20, 20)); }
        }
        
        public static int ProjectSheetWidth{
            get{return 20;}
        }
        public static int ProjectSheetHeight{
            get{return 20;}
        }

        static public void GetTextureDimensions(int Number, int Width, ref int RowNumber, ref int ColumnNumber)
        {
            if (Number == 0)
            {
                RowNumber = ColumnNumber = 0;
                return;
            }
            RowNumber = Number / Width;
            ColumnNumber = Number - (RowNumber * Width);
        }

        public int RowNumber
        {
            get { return ((SpriteNumber == 0) ? 0 : SpriteNumber / ProjectSheetWidth); }
        }

        public int ColumnNumber
        {
            get { return (SpriteNumber - (RowNumber * ProjectSheetWidth)); }
        }
    }

    /// <summary>
    /// Ground Class for storing information about ground brush.
    /// </summary>
    [Serializable]
    public class Ground : ParentDataObject
    {
        /// <summary>
        /// Number of sprites in the ground.
        /// </summary>
        public int NumberofGrounds;
        /// <summary>
        /// Importance of each ground sprite.
        /// </summary>
        public int[] GroundsImportances;
        /// <summary>
        /// True if the ground has borders, false otherwise.
        /// </summary>
        public bool HasBorders;
        /// <summary>
        /// True if user can walk on this ground, false otherwise.
        /// </summary>
        public bool CanWalkOn;
        /// <summary>
        /// Number of sprites the Object holds.
        /// </summary>
        public override int Length { get { return (HasBorders) ? NumberofGrounds + 10 : NumberofGrounds; } }
    }

    /// <summary>
    /// Item Class for storing information about Item brush.
    /// </summary>
    [Serializable]
    public class Item : ParentDataObject
    {
        /// <summary>
        /// Vertical number of sprites.
        /// </summary>
        public int Height;
        /// <summary>
        /// Horizontal number of sprites.
        /// </summary>
        public int Width;
        /// <summary>
        /// Number of sprites the Object holds.
        /// </summary>
        public override int Length { get { return Height * Width; } }
    }

    /// <summary>
    /// Wall Class for storing information about wall brush.
    /// </summary>
    [Serializable]
    public class Wall : ParentDataObject
    {
        /// <summary>
        /// True if the wall is tall, false otherwise.
        /// </summary>
        public bool Tall;
        /// <summary>
        /// Number of sprites the Object holds.
        /// </summary>
        public override int Length { get { return (Tall) ? 16 : 4; } }
    }
}
