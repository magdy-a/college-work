namespace IPClassLibrary.ResizeClasses
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using IPClassLibrary.ImageClasses;
    using IPClassLibrary.ObjectTypes;
    using IPClassLibrary.StaticClasses;

    /// <summary>
    /// HandleResize Class
    /// </summary>
    public class HandleResize : ICloneable
    {
        /// <summary>
        /// Original Image
        /// </summary>
        private HandleImage original;

        /// <summary>
        /// Resized Image
        /// </summary>
        private HandleImage resized;

        /// <summary>
        /// Resize Algorithm Type
        /// </summary>
        private ResizeType itype;

        /// <summary>
        /// HandleResize Object for resizing
        /// </summary>
        private HandleResize tmpResize;

        /// <summary>
        /// Initializes a new instance of the HandleResize class
        /// </summary>
        public HandleResize()
        {
            this.original = new HandleImage();
        }

        /// <summary>
        /// Initializes a new instance of the HandleResize class
        /// </summary>
        /// <param name="ori">The Original Image to use</param>
        public HandleResize(HandleImage ori)
        {
            this.original = ori;
        }

        #region Properties

        /// <summary>
        /// Gets or sets Original Image
        /// </summary>
        public HandleImage Original
        {
            get { return this.original; }
            set { this.original = value; }
        }

        /// <summary>
        /// Gets or sets Resized Image
        /// </summary>
        public HandleImage Resized
        {
            get { return this.resized; }
            protected set { this.resized = value; }
        }

        /// <summary>
        /// Gets or sets the Resize Algorithm Type
        /// </summary>
        public ResizeType Type
        {
            get { return this.itype; }
            protected set { this.itype = value; }
        }

        /// <summary>
        /// Gets or sets a tmp Resize Object for resizing
        /// </summary>
        protected HandleResize TmpResize
        {
            get { return this.tmpResize; }
            set { this.tmpResize = value; }
        } 

        #endregion

        /// <summary>
        /// Resized using any Algorthim
        /// </summary>
        /// <param name="newSize">Size to resize to</param>
        /// <param name="type">Algorthim to use</param>
        public void Resize(Size newSize, ResizeType type)
        {
            switch (type)
            {
                case ResizeType.Bilinear:
                    this.tmpResize = new Bilinear();
                    break;
                case ResizeType.BiCubic:
                    this.tmpResize = new BiCubic();
                    break;
            }

            this.tmpResize.original = this.original;

            this.tmpResize.ResizeImage(newSize);

            if (this.tmpResize.resized == null || this.tmpResize.resized.Type == ImageType.Corrupted)
            {
                return;
            }

            this.resized = this.tmpResize.resized;

            this.tmpResize = null;
        }

        /// <summary>
        /// Resizes the Image
        /// </summary>
        /// <param name="newSize">Size to Resize to</param>
        public virtual void ResizeImage(Size newSize)
        {
        }

        /// <summary>
        /// Returns a Shallow Copy of this instance
        /// </summary>
        /// <returns>Shallow Copy</returns>
        public virtual object Clone()
        {
            HandleResize newObject = (HandleResize)this.MemberwiseClone();

            return newObject;
        }
    }
}
