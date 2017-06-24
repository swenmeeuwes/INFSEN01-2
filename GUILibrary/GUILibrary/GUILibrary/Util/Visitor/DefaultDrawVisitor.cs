using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using GUILibrary.UI.Label;
using Microsoft.Xna.Framework;
using GUILibrary.UI.Drawing;
using GUILibrary.UI.View.Decorators;

namespace GUILibrary.Util.Visitor
{
    class DefaultDrawVisitor : IDrawVisitor
    {
        private IDrawManager drawManager;
        public DefaultDrawVisitor(IDrawManager drawManager)
        {
            this.drawManager = drawManager;
        }      
        public void Draw(Button element)
        {
            drawManager.Draw(element);        
        }

        public void Draw(Label element)
        {
            drawManager.Draw(element);
        }

        public void Draw(Panel element)
        {
            drawManager.Draw(element);
        }
    }
}
