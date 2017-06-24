using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GUILibrary.UI.Label;
using GUILibrary.UI.View.Decorators;
using Microsoft.Xna.Framework.Content;
using GUILibrary.UI.View.State;

namespace GUILibrary.UI.Drawing
{
    class MonoGameDrawStrategy : IDrawStrategy
    {
        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphicsDeviceManager;
        private ContentManager contentManager;
        public MonoGameDrawStrategy(SpriteBatch spriteBatch, GraphicsDeviceManager graphicsDeviceManager, ContentManager contentManager)
        {
            this.spriteBatch = spriteBatch;
            this.graphicsDeviceManager = graphicsDeviceManager;
            this.contentManager = contentManager;
        }
        public void Draw(Button element)
        {
            //spriteBatch.Draw(
            //    element.CurrentTexture, 
            //    new Rectangle(element.Bounds.X, element.Bounds.Y, element.Bounds.Width, element.Bounds.Height), 
            //    new Color(element.Color.R, element.Color.G, element.Color.B, element.Color.A)
            //);
        }

        public void Draw(View.Decorators.Label element)
        {
            var measuredStringSize = element.Font.MeasureString(element.Text);

            Vector2 calculatedPosition = new Vector2(element.Bounds.X, element.Bounds.Y);
            switch ((int)element.Align)
            {
                case (int)TextAlign.LEFT:
                    calculatedPosition = new Vector2(element.Bounds.X, element.Bounds.Y);
                    break;
                case (int)TextAlign.RIGHT:
                    calculatedPosition = new Vector2(element.Bounds.X - measuredStringSize.X, element.Bounds.Y);
                    break;
                case (int)TextAlign.CENTER:
                    calculatedPosition = new Vector2(element.Bounds.X + element.Bounds.Width / 2 - measuredStringSize.X / 2, element.Bounds.Y);
                    break;
                case (int)TextAlign.CENTER + (int)TextAlign.MIDDLE:
                    calculatedPosition = new Vector2(element.Bounds.X + element.Bounds.Width / 2 - measuredStringSize.X / 2, element.Bounds.Y + element.Bounds.Height / 2 - measuredStringSize.Y / 2);
                    break;
                case (int)TextAlign.CENTER + (int)TextAlign.BOTTOM:
                    calculatedPosition = new Vector2(element.Bounds.X + element.Bounds.Width / 2 - measuredStringSize.X / 2, element.Bounds.Y + element.Bounds.Height - measuredStringSize.Y);
                    break;
            }

            spriteBatch.DrawString(element.Font, element.Text, calculatedPosition, new Color(element.FontColor.R, element.FontColor.G, element.FontColor.B, element.FontColor.A));
        }

        public void Draw(Panel element)
        {
            // Construct a rectangle, may be moved to a factory later?
            var rectangle = new Texture2D(graphicsDeviceManager.GraphicsDevice, element.Size.X, element.Size.Y);

            var data = new Color[element.Size.X * element.Size.Y];

            var backgroundColor = new Color(element.BackgroundColor.R, element.BackgroundColor.G, element.BackgroundColor.B, element.BackgroundColor.A);
            var borderColor = new Color(element.BorderColor.R, element.BorderColor.G, element.BorderColor.B, element.BorderColor.A);
            for (int i = 0; i < data.Length; i++)
            {
                if(i % element.Size.X == 0 || i % element.Size.X == element.Size.X - 1 || i < element.Size.X || i > element.Size.X * (element.Size.Y - 1))
                    data[i] = borderColor;
                else
                    data[i] = backgroundColor;
            }

            rectangle.SetData(data);

            spriteBatch.Draw(rectangle, new Vector2(element.Position.X, element.Position.Y), Color.White);
        }

        public void Draw(TextInput element)
        {
            var measuredStringSize = element.Font.MeasureString("how tall is this");

            // Draw input indicator if the input field is selected
            if (element.Selected && DateTime.Now.Millisecond % 1000 < 500)
            {
                var indicator = new Texture2D(graphicsDeviceManager.GraphicsDevice, 1, (int)measuredStringSize.Y);
                var data = new Color[(int)measuredStringSize.Y];
                for (int i = 0; i < data.Length; i++)
                    data[i] = Color.Black;
                indicator.SetData(data);

                var measuredContentSize = element.Font.MeasureString(element.Content);
                spriteBatch.Draw(indicator, new Vector2(element.Position.X + measuredContentSize.X + 4, element.Bounds.Y + element.Bounds.Height / 2 - measuredStringSize.Y / 2), Color.White);
            }

            var calculatedPosition = new Vector2(element.Bounds.X + 4, element.Bounds.Y + element.Bounds.Height / 2 - measuredStringSize.Y / 2);
            if (element.Content.Length > 0)
                spriteBatch.DrawString(element.Font, element.Content, calculatedPosition, new Color(element.FontColor.R, element.FontColor.G, element.FontColor.B, element.FontColor.A));
            else
                spriteBatch.DrawString(element.Font, element.Placeholder, calculatedPosition, Color.Gray);
        }
    }
}
