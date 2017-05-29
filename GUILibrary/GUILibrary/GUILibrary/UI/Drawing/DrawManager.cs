using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.Button;
using GUILibrary.UI.Label;

namespace GUILibrary.UI.Drawing
{
    class DrawManager : IDrawManager
    {
        private IDrawStrategy drawStrategy;
        public DrawManager(IDrawStrategy drawStrategy)
        {
            this.drawStrategy = drawStrategy;
        }

        public void Draw(Button.Button element)
        {
            drawStrategy.Draw(element);
        }

        public void Draw(Label.Label element)
        {
            drawStrategy.Draw(element);
        }
    }
}
