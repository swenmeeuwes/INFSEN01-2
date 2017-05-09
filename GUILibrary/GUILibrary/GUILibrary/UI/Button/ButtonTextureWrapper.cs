using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.UI.Button
{
    class ButtonTextureWrapper
    {
        public Texture2D ButtonUp { get; private set; }
        public Texture2D ButtonDown { get; private set; }

        public ButtonTextureWrapper(Texture2D buttonUp, Texture2D buttonDown)
        {
            ButtonUp = buttonUp;
            ButtonDown = buttonDown;
        }
    }
}
