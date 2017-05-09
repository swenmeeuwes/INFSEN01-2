using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.Util.Visitor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GUILibrary.AssetLoading;

namespace GUILibrary.UI.Label
{
    class Label : View.View
    {
        public string Text { get; set; }
        public TextAlign Align { get; set; } = TextAlign.LEFT;
        public SpriteFont Font { get; set; }

        public Label(string text, Vector2 position)
        {
            this.Text = text;
            this.Position = position;

            // Use a font as "default" label font
            this.Font = AssetLibrary.Instance.RetrieveAsset<SpriteFont>("Arial");
            this.Color = Color.Black;
        }
        public Label(string text, SpriteFont font)
        {
            this.Text = text;
            this.Font = font;

            this.Color = Color.Black;
        }

        public override void Update(IUpdateVisitor updateVisitor, float deltaTime)
        {
            updateVisitor.Update(this, deltaTime);
            base.Update(updateVisitor, deltaTime);
        }
        public override void Draw(IDrawVisitor drawVisitor)
        {
            drawVisitor.Draw(this);
        }        
    }
}
