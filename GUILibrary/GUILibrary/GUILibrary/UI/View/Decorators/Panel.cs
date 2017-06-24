using GUILibrary.Util.Structures;
using GUILibrary.Util.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.UI.View.Decorators
{
    class Panel : ViewDecorator
    {
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
        public Panel(AbstractView view) : base(view)
        {
            BackgroundColor = Color.White;
            BorderColor = Color.Black;
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
