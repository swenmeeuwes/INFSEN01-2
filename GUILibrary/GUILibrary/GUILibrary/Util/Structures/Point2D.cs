using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Structures
{
    /// <summary>
    /// Represents a point in a 2-dimensional space
    /// </summary>
    public class Point2D<T>
    {
        public dynamic X { get; set; }
        public dynamic Y { get; set; }
        public Point2D(T x, T y)
        {
            X = x;
            Y = y;
        }
        public static Point2D<T> operator +(Point2D<T> p1, Point2D<T> p2)
        {
            return new Point2D<T>(p1.X + p2.X, p1.Y + p2.Y);
        }
    }
}
