using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.View.State;
using GUILibrary.Util.Structures;
using GUILibrary.Util.Visitor;

namespace GUILibrary.UI.View.Decorators
{
    abstract class ViewDecorator : AbstractView
    {
        protected AbstractView view;
        public ViewDecorator(AbstractView view)
        {
            this.view = view;
        }

        public override bool Visible { get => view.Visible; set => view.Visible = value; }
        public override float Opacity { get => view.Opacity; set => view.Opacity = value; }
        public override Color Color { get => view.Color; set => view.Color = value; }
        public override Point2D<int> Position { get => view.Position; set => view.Position = value; }
        public override Vector2<int> Size { get => view.Size; set => view.Size = value; }

        public override Rectangle<int> Bounds => view.Bounds;

        public override ViewState State { get => view.State; set => view.State = value; }

        public override void Draw(IDrawVisitor visitor)
        {
                        
        }

        public override void HandleClick(IOnClickVisitor visitor)
        {
            
        }

        public override void Update(IUpdateVisitor visitor, float deltaTime)
        {
            
        }
    }
}
