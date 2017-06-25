using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.Util.Visitor;
using GUILibrary.UI.View.State;
using GUILibrary.Util.Observable;
using GUILibrary.Util.Structures;
using GUILibrary.Input;
using GUILibrary.UI.Window;

namespace GUILibrary.UI.View
{
    class PlainView : AbstractView
    {
        public override bool Visible { get; set; }
        public override float Opacity { get; set; }
        public override Point2D<int> Position { get; set; }
        public override Vector2<int> Size { get; set; }
        //public Vector2 Origin { get; set; }
        public override Rectangle<int> Bounds
        {
            get
            {
                return new Rectangle<int>(Position.X, Position.Y, Size.X, Size.Y);
            }
        }
        public override ViewState State { get; set; }
        public override GUIWindow Parent { get; set; }

        public PlainView(Point2D<int> position, Vector2<int> size)
        {
            State = ViewState.IDLE;

            Position = position;
            Size = size;
        }

        public override void Draw(IDrawVisitor drawVisitor)
        {
            // Did you know? A plain view is also a ninja, so they can hide themselves really well!
        }

        public override void Update(IUpdateVisitor updateVisitor, float deltaTime)
        {
            
        }

        public override void HandleClick(IOnClickVisitor onClickVisitor)
        {
            // And because ninja's arent visible, you cannot click them!
        }

        public void UpdateState(MouseState mouseState)
        {
            var mouseIsInArea = Bounds.Contains(new Point2D<int>(mouseState.Position.X, mouseState.Position.Y));
            var mouseIsPressed = mouseState.LeftButton == ButtonState.PRESSED || mouseState.MiddleButton == ButtonState.PRESSED || mouseState.RightButton == ButtonState.PRESSED;

            switch (State)
            {
                case ViewState.IDLE:
                    // Transitions
                    if (mouseIsInArea && mouseIsPressed)
                        State = ViewState.PRESSED;
                    else if (mouseIsInArea && !mouseIsPressed)
                        State = ViewState.ENTER;

                    break;
                case ViewState.ENTER:
                    // Trigger lifecycle method
                    OnMouseEnter(mouseState);

                    // Transitions
                    if (mouseIsInArea && mouseIsPressed)
                        State = ViewState.PRESSED;
                    else if (mouseIsInArea && !mouseIsPressed)
                        State = ViewState.OVER;
                    else if (!mouseIsInArea && !mouseIsPressed)
                        State = ViewState.EXIT;

                    break;
                case ViewState.OVER:
                    // Trigger lifecycle method
                    OnMouseOver(mouseState);

                    // Transitions
                    if (mouseIsInArea && mouseIsPressed)
                        State = ViewState.PRESSED;
                    else if (mouseIsInArea && !mouseIsPressed)
                        State = ViewState.OVER;
                    else if (!mouseIsInArea)
                        State = ViewState.EXIT;
                    break;
                case ViewState.EXIT:
                    // Trigger lifecycle method
                    OnMouseExit(mouseState);

                    // Transitions
                    State = ViewState.IDLE;

                    break;
                case ViewState.PRESSED:
                    // Trigger lifecycle method
                    OnMousePress(mouseState);

                    // Transitions
                    if (mouseIsPressed)
                        State = ViewState.DOWN;
                    else
                        State = ViewState.EXIT;

                    break;
                case ViewState.DOWN:
                    // Trigger lifecycle method
                    OnMouseDown(mouseState);

                    // Transitions
                    if (mouseIsPressed)
                        State = ViewState.DOWN;
                    else
                        State = ViewState.RELEASED;

                    break;
                case ViewState.RELEASED:
                    // Trigger lifecycle method
                    OnMouseRelease(mouseState);

                    // Transitions
                    if (mouseIsInArea)
                        State = ViewState.OVER;
                    else
                        State = ViewState.EXIT;

                    break;
            }
        }

        protected virtual void OnMousePress(MouseState mouseState)
        {

        }

        protected virtual void OnMouseDown(MouseState mouseState)
        {

        }

        protected virtual void OnMouseRelease(MouseState mouseState)
        {

        }

        protected virtual void OnMouseEnter(MouseState mouseState)
        {

        }

        protected virtual void OnMouseOver(MouseState mouseState)
        {

        }

        protected virtual void OnMouseExit(MouseState mouseState)
        {

        }
    }
}
