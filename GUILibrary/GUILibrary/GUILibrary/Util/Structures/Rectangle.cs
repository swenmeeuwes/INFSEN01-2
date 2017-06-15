using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Structures
{
    /// <summary>
    /// Represents a rectangle in a 2-dimensional space
    /// </summary>
    class Rectangle<T>
    {
        public dynamic X { get; set; }
        public dynamic Y { get; set; }
        public dynamic Width { get; set; }
        public dynamic Height { get; set; }

        public Rectangle(T x, T y, T w, T h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }

        public bool Contains(Point2D<T> point)
        {
            return point.X > X && point.X < X + Width
                && point.Y > Y && point.Y < Y + Height;
        }
    }
}
