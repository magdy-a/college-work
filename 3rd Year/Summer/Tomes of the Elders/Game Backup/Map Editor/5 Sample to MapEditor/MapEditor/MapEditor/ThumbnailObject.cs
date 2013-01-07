using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MapEditor
{
    class ThumbnailObject
    {
        Bitmap Thumbnail;
        static Size ThumbnailSize;

        int DataID;

        String Palette;
        String Tileset;
        int SpriteNumber;

        public ThumbnailObject()
        {
        }
    }
}
