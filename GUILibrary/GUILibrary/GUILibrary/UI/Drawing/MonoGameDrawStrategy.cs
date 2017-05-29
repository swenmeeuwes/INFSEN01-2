using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.Button;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GUILibrary.UI.Label;

namespace GUILibrary.UI.Drawing
{
    class MonoGameDrawStrategy : IDrawStrategy
    {
        private SpriteBatch spriteBatch;
        public MonoGameDrawStrategy(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }
        public void Draw(Button.Button element)
        {
            spriteBatch.Draw(element.CurrentTexture, element.Bounds, element.Color);
        }

        public void Draw(Label.Label element)
        {
            var measuredStringSize = element.Font.MeasureString(element.Text);

            Vector2 calculatedPosition;
            switch (element.Align)
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
