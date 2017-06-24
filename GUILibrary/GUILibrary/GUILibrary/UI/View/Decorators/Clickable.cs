using GUILibrary.Util.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.Util.Observable;

namespace GUILibrary.UI.View.Decorators
{
    class Clickable : ViewDecorator
    {

        public Clickable(AbstractView view, ActionObserver actionObserver) : base(view)
        {
            view.RegisterObserver(actionObserver);
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
