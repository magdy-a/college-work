using System;
using System.Collections.Generic;
using System.Text;
using ShapesLib;
namespace Section4
{
    class GraFICSModel
    {
        //Our Shapes ArrayList
        List<Shape> allShapes;
        public GraFICSModel()
        { 
            allShapes = new List<Shape>();
        }
        public void AddShape(Shape newShape)
        {
            allShapes.Add(newShape);
        }
        public Shape GetShapeAtPt(int x, int y)
        {
            Shape selectedShape = null;
            for (int i = 0; i < allShapes.Count; i++)
            {
                if (allShapes[i].PointInShape(x,y))
                    selectedShape = allShapes[i];
            }
            return selectedShape;
        }

    }
}
