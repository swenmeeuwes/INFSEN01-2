using GUILibrary.Util.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.Util.Observable;

namespace GUILibrary.UI.View.Decorators
{
    class Button : ViewDecorator
    {
        public Action<AbstractView> Action { get; set; }
        public Button(AbstractView view, Action<AbstractView> action) : base(view)
        {
            Action = action;
        }
        public override void Draw(IDrawVisitor visitor)
        {
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
