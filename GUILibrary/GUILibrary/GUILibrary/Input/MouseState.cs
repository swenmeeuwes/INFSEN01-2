using GUILibrary.Util.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Input
{
    class MouseState
    {
        public Point2D<int> Position { get; }
        public float ScrollDelta { get; }
        public ButtonState LeftButton { get; }
        public ButtonState MiddleButton { get; }
        public ButtonState RightButton { get; }

        // Shortcuts
        public int X { get { return Position.X; } }
        public int Y { get { return Position.Y; } }

        public MouseState(Point2D<int> position, float scrollDelta, ButtonState leftButton, ButtonState middleButton, ButtonState rightButton)
        {
            Position = position;
            ScrollDelta = scrollDelta;
            LeftButton = leftButton;
            MiddleButton = middleButton;
            RightButton = rightButton;
        }
    }
}
