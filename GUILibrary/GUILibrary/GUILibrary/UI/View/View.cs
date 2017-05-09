using GUILibrary.UI.Drawing;
using GUILibrary.UI.View.State;
using GUILibrary.Util.Observable;
using GUILibrary.Util.Visitor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.UI.View
{
    abstract class View : Drawing.IDrawable, IObservable
    {
        public bool Visible { get; set; }
        public float Opacity { get; set; }
        public Color Color { get; set; }
        public Rectangle Area { get; set; }
        //public Vector2 Position { get; set; } // Vector 2 instead of a point since XNA draw calls only take Vector2 types
        //public Vector2 Origin { get; set; } // Vector 2 instead of a point since XNA draw calls only take Vector2 types

        protected List<IObserver> observers = new List<IObserver>();
        protected ViewState state = ViewState.IDLE;

        public abstract void Draw(IDrawVisitor drawVisitor);

        public virtual void Update()
        {
            var mouseState = Mouse.GetState();
            HandleState(mouseState);
        }

        private void HandleState(MouseState mouseState)
        {
            var mouseIsInArea = Area.Contains(mouseState.Position);
            var mouseIsPressed = mouseState.LeftButton == ButtonState.Pressed || mouseState.MiddleButton == ButtonState.Pressed || mouseState.RightButton == ButtonState.Pressed;

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
