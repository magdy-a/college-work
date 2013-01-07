using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
