using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map_Editor_Behaviour
{
    public class StaticBrush : Brush
    {
        public void IsHangable()
        {
            throw new System.NotImplementedException();
        }

        public void CheckGroundsOrWalls()
        {
            throw new System.NotImplementedException();
        }

        public void PlaceItem()
        {
            throw new System.NotImplementedException();
        }
    }

    public class ItemBrush : StaticBrush
    {
    }
}
