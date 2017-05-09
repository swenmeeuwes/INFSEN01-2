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
            Draw(element.Label);            
        }

        public void Draw(Label element)
        {
            var measuredStringSize = element.Font.MeasureString(element.Text);

            Vector2 calculatedPosition;            
            switch(element.Align)
            {
                case TextAlign.CENTER:
                    calculatedPosition = new Vector2(element.Bounds.X - measuredStringSize.X / 2, element.Bounds.Y);
                    break;
                case TextAlign.RIGHT:
                    calculatedPosition = new Vector2(element.Bounds.X - measuredStringSize.X, element.Bounds.Y);
                    break;
                case TextAlign.LEFT:
                default:
                    calculatedPosition = new Vector2(element.Bounds.X, element.Bounds.Y);
                    break;
            }

            spriteBatch.DrawString(element.Font, element.Text, calculatedPosition, element.Color);
        }
    }
}
