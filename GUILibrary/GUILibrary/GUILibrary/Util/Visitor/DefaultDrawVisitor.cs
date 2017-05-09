using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.Button;
using Microsoft.Xna.Framework.Graphics;

namespace GUILibrary.Util.Visitor
{
    class DefaultDrawVisitor : IDrawVisitor
    {
        private SpriteBatch spriteBatch;
        public DefaultDrawVisitor(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }      
        public void Draw(Button element)
        {
            spriteBatch.Draw(element.CurrentTexture, element.Area, element.Color);
        }
    }
}
