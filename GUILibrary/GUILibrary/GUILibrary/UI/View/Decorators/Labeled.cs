using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.Util.Structures;
using GUILibrary.Util.Observable;
using GUILibrary.UI.Label;
using Microsoft.Xna.Framework.Graphics;
using GUILibrary.Util.Visitor;
using GUILibrary.AssetLoading;

namespace GUILibrary.UI.View.Decorators
{
    class Labeled : ViewDecorator
    {
        public string Text { get; set; }
        public TextAlign Align { get; set; } = TextAlign.LEFT;
        public SpriteFont Font { get; set; }

        public Labeled(AbstractView view, string text) : base(view)
        {
            // Use a font as "default" label font
            this.Font = AssetLibrary.Instance.RetrieveAsset<SpriteFont>("Arial");
            this.Color = Color.Black;
            
            this.Text = text;
        }
        public override void Draw(IDrawVisitor visitor)
        {
            visitor.Draw(this);
        }
    }
}
