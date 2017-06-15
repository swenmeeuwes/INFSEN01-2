using GUILibrary.Input;
using GUILibrary.UI.Drawing;
using GUILibrary.UI.View.State;
using GUILibrary.Util.Observable;
using GUILibrary.Util.Structures;
using GUILibrary.Util.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.UI.View
{
    abstract class View : Drawing.IDrawable, IObservable, IUpdatable
    {
        public bool Visible { get; set; }
        public float Opacity { get; set; }
        public Color Color { get; set; }
        public Point2D<int> Position { get; set; }
        public Vector2<int> Size { get; set; }
        //public Vector2 Origin { get; set; }
        public Rectangle<int> Bounds
        {
            get
            {
                return new Rectangle<int>(Position.X, Position.Y, Size.X, Size.Y);
            }
        }

        protected List<IObserver> observers = new List<IObserver>();
        protected ViewState state = ViewState.IDLE;

        public abstract void Draw(IDrawVisitor drawVisitor);

        public virtual void Update(IUpdateVisitor updateVisitor, float deltaTime)
        {
            var mouseState = InputManager.Instance.Mouse;
            HandleState(mouseState); // Don't like exposing this method.. just for the visitor
        }

        private void HandleState(MouseState mouseState)
        {
            var mouseIsInArea = Bounds.Contains(new Point2D<int>(mouseState.Position.X, mouseState.Position.Y));
            var mouseIsPressed = mouseState.LeftButton == ButtonState.PRESSED || mouseState.MiddleButton == ButtonState.PRESSED || mouseState.RightButton == ButtonState.PRESSED;

            switch (state)
            {
                case ViewState.IDLE:
                    // Transitions
                    if (mouseIsInArea && mouseIsPressed)
                        state = ViewState.PRESSED;
                    else if(mouseIsInArea && !mouseIsPressed)
                        state = ViewState.ENTER;

                    break;
                case ViewState.ENTER:
                    // Trigger lifecycle method
                    OnMouseEnter(mouseState);

                    // Transitions
                    if (mouseIsInArea && mouseIsPressed)
                        state = ViewState.PRESSED;
                    else if (mouseIsInArea && !mouseIsPressed)
                        state = ViewState.OVER;
                    else if (!mouseIsInArea && !mouseIsPressed)
                        state = ViewState.EXIT;

                    break;
                case ViewState.OVER:
                    // Trigger lifecycle method
                    // Could call OnMouseOver here if implementation is needed

                    // Transitions
                    if (mouseIsInArea && mouseIsPressed)
                        state = ViewState.PRESSED;
                    else if (mouseIsInArea && !mouseIsPressed)
                        state = ViewState.OVER;
                    else if (!mouseIsInArea)
                        state = ViewState.EXIT;
                    break;
                case ViewState.EXIT:
                    // Trigger lifecycle method
                    OnMouseExit(mouseState);

                    // Transitions
                    state = ViewState.IDLE;

                    break;
                case ViewState.PRESSED:
                    // Trigger lifecycle method
                    OnMousePress(mouseState);

                    // Transitions
                    if (mouseIsPressed)
                        state = ViewState.DOWN;
                    else
                        state = ViewState.EXIT;

                    break;
                case ViewState.DOWN:
                    // Trigger lifecycle method
                    OnMouseDown(mouseState);

                    // Transitions
                    if (mouseIsPressed)
                        state = ViewState.DOWN;
                    else
                        state = ViewState.RELEASED;

                    break;
                case ViewState.RELEASED:
                    // Trigger lifecycle method
                    OnMouseRelease(mouseState);

                    // Transitions
                    if (mouseIsInArea)
                        state = ViewState.OVER;
                    else
                        state = ViewState.EXIT;

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

        protected virtual void OnMouseExit(MouseState mouseState)
        {

        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void DeregisterObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(Event eventObject)
        {
            observers.ForEach(observer => observer.OnNotify(eventObject));
        }
    }
}
