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
    class Label : ViewDecorator
    {
        public string Text { get; set; }
        public TextAlign Align { get; set; } = TextAlign.LEFT;
        public SpriteFont Font { get; set; }
        public Color FontColor { get; set; }

        public Label(AbstractView view, string text, TextAlign textAlign) : base(view)
        {
            // Use a font as "default" label font
            Font = AssetLibrary.Instance.RetrieveAsset<SpriteFont>("Arial");
            FontColor = Color.Black;
            
            Text = text;
            Align = textAlign;
        }
        public override void Draw(IDrawVisitor visitor)
        {
            visitor.Draw(this);
            view.Draw(visitor);
        }
        public override void Update(IUpdateVisitor visitor, float deltaTime)
        {            
            view.Update(visitor, deltaTime);
        }
        public override void HandleClick(IOnClickVisitor onClickVisitor)
        {
            view.HandleClick(onClickVisitor);
        }
    }
}
