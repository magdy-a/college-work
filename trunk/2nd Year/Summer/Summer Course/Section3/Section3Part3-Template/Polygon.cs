using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Drawing.Drawing2D;

namespace ShapesLib
{
    public class Polygon : Shape
    {
        #region Constructor(s)
        public Polygon()
        {
            _points = new List<Point>();
            FillColor = Color.WhiteSmoke;
        }

        public Polygon(ICollection<Point> points)
        {
            _points = new List<Point>(points);
            FillColor = Color.WhiteSmoke;
        }
        #endregion

        #region Members
        private List<Point> _points = new List<Point>();
        #endregion


        #region Properties
        public List<Point> Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public int PointCount
        {
            get
            {
                return _points.Count;
            }
        }

        public Point this[int index]
        {
            get { return _points[index]; }
            set { _points[index] = value; }
        }
        #endregion 
        
        #region Methods
        public void AddPoint(Point point)
        {
            _points.Add(point);
        }
        public void RemovePointAt(int index)
        {
            _points.RemoveAt(index);
        }

        public override void Translate(int dx, int dy)
        {
            for (int i = 0; i < _points.Count; i++)
            {
                _points[i] = Point.Add(_points[i], new Size(dx, dy));
            }
        }

        public override bool PointInShape(int x, int y)
        {
            Point point = new Point(x,y);

            GraphicsPath _path = new GraphicsPath();
            _path.Reset();

            Point[] pointarr = new Point[_points.Count];
            for (int i = 0; i < _points.Count; i++)
                pointarr[i] = _points[i];

            _path.AddPolygon(pointarr);
            return _path.IsVisible(point);
        }

        public override void Draw(Graphics g)
        {
            Point[] points = new Point[PointCount];
            byte[] types = new byte[PointCount];

            for (int i = 0; i < PointCount; i++) 
            {
                points[i] = _points[i];
                types[i] = (byte)PathPointType.Line;
            }

            types[0] = (byte)PathPointType.Start;
            types[PointCount - 1] = (byte)PathPointType.CloseSubpath;

            g.FillPolygon(new SolidBrush(FillColor), points);
            Pen pen = new Pen(PenColor, PenWidth);
            g.DrawPolygon(pen, points);
        }
        public override void DrawForCreation(Graphics g)
        {
            Pen pen = new Pen(PenColor, PenWidth);

            for (int i = 0; i < PointCount - 1; i++)
            {
                g.DrawLine(pen, Points[i], Points[i + 1]);
            }

        }

        public override void Scale(double factor)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

    }
}
