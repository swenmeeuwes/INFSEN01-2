using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Structures
{
    /// <summary>
    /// Represents a vector in a 2-dimensional space
    /// </summary>
    public class Vector2<T>
    {
        public dynamic X { get; set; }
        public dynamic Y { get; set; }

        public Vector2(T x, T y)
        {
            X = x;
            Y = y;
        }
    }
}
