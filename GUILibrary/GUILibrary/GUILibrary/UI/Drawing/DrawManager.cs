using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.View.Decorators;

namespace GUILibrary.UI.Drawing
{
    class DrawManager : IDrawManager
    {
        private IDrawStrategy drawStrategy;
        public DrawManager(IDrawStrategy drawStrategy)
        {
            this.drawStrategy = drawStrategy;
        }

        public void Draw(View.Decorators.Label element)
        {
            drawStrategy.Draw(element);
        }

        public void Draw(Button element)
        {
            drawStrategy.Draw(element);
        }
        public void Draw(Panel element)
        {
            drawStrategy.Draw(element);
        }
        public void Draw(TextInput element)
        {
            drawStrategy.Draw(element);
        }
    }
}
