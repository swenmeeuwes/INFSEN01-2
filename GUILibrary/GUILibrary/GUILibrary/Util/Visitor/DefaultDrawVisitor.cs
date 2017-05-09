using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.Button;
using Microsoft.Xna.Framework.Graphics;
using GUILibrary.UI.Label;
using Microsoft.Xna.Framework;

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
            spriteBatch.Draw(element.CurrentTexture, element.Bounds, element.Color);
            spriteBatch.DrawString(element.Label.Font, element.Label.Text, new Vector2(element.Label.Bounds.X, element.Label.Bounds.Y), element.Label.Color);
        }

        public void Draw(Label element)
        {
            spriteBatch.DrawString(element.Font, element.Text, new Vector2(element.Bounds.X, element.Bounds.Y), element.Color);
        }
    }
}
