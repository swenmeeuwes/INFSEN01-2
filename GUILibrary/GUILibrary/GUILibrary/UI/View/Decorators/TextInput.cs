using GUILibrary.Util.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.UI.View.Decorators
{
    class TextInput : ViewDecorator
    {
        public bool Selected { get; set; }
        public string Content { get; set; }
        public TextInput(AbstractView view) : base(view)
        {
            
        }
        public override void Draw(IDrawVisitor visitor)
        {
            visitor.Draw(this);
            view.Draw(visitor);
        }
        public override void Update(IUpdateVisitor visitor, float deltaTime)
        {
            visitor.Update(this, deltaTime);
            view.Update(visitor, deltaTime);
        }
        public override void HandleClick(IOnClickVisitor visitor)
        {
            visitor.HandleClick(this);
            view.HandleClick(visitor);
        }
    }
}
