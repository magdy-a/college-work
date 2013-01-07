using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapDataEditor.Data
{
    /// <summary>
    /// Parent Types for map editor items.
    /// </summary>
    public enum ParentTypes
    {
        Terrain, StaticItems, Brushes
    }
    /// <summary>
    /// Terrain types for terrain items.
    /// </summary>
    public enum TerrainTypes
    {
        Cave, Hell, Garden, Desert, Snow, Rocky, Town, 
    }
    /// <summary>
    /// Static Items types for static items.
    /// </summary>
    public enum StaticItemsTypes
    {
        Stairs, Beds, Exterior, Hangable, Interior, Nature, Signs, Smiths, Snow, Statues
    }
    /// <summary>
    /// Brushes types for brushes items.
    /// </summary>
    public enum BrushesTypes
    {
        PlayerStartingPoint, AreaEdge
    }
}