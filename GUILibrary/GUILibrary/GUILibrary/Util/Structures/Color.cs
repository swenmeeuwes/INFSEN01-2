using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Structures
{
    public class Color
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }

        public static Color Black { get { return new Color(0, 0, 0); } }
        public static Color White { get { return new Color(255, 255, 255); } }
        public static Color Red { get { return new Color(255, 0, 0); } }
        public static Color Green { get { return new Color(0, 255, 0); } }
        public static Color Blue { get { return new Color(0, 0, 255); } }

        public Color(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
            A = 255;
        }

        public Color Clone()
        {
            return new Color(R, G, B);
        }
    }
}
