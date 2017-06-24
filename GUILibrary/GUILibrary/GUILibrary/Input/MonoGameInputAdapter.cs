using GUILibrary.Util.Structures;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Input
{
    class MonoGameInputAdapter : IInputAdapter
    {
        public MouseState GetMouseState()
        {
            var monoGameMouseState = Mouse.GetState();
            return new MouseState(
                new Point2D<int>(monoGameMouseState.X, monoGameMouseState.Y),
                monoGameMouseState.ScrollWheelValue, // Needs to be changed to delta
                AdaptButtonState(monoGameMouseState.LeftButton),
                AdaptButtonState(monoGameMouseState.MiddleButton),
                AdaptButtonState(monoGameMouseState.RightButton)
            );
        }
        private ButtonState AdaptButtonState(Microsoft.Xna.Framework.Input.ButtonState xnaButtonState)
        {
            switch(xnaButtonState)
            {
                case Microsoft.Xna.Framework.Input.ButtonState.Pressed:
                    return ButtonState.PRESSED;                
                case Microsoft.Xna.Framework.Input.ButtonState.Released:
                default:
                    return ButtonState.RELEASED;
            }
        }
    }
}
