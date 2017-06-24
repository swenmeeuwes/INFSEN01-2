using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.View;
using GUILibrary.Util.Observable;
using GUILibrary.Input;
using GUILibrary.UI.View.State;
using GUILibrary.Util.Structures;
using GUILibrary.UI.View.Decorators;

namespace GUILibrary.Util.Visitor
{
    class OnClickVisitor : IOnClickVisitor
    {
        private IInputAdapter inputAdapter;
        private MouseState previousMouseState;
        private MouseState mouseState;

        public OnClickVisitor(IInputAdapter inputAdapter)
        {
            this.inputAdapter = inputAdapter;

            previousMouseState = inputAdapter.GetMouseState();
            mouseState = inputAdapter.GetMouseState();
        }

        public void HandleClick(Button element)
        {
            var mouseIsInArea = element.Bounds.Contains(new Point2D<int>(mouseState.Position.X, mouseState.Position.Y));
            if (mouseState.LeftButton == ButtonState.RELEASED && previousMouseState.LeftButton == ButtonState.PRESSED && mouseIsInArea)
                element.Action.Invoke(element);            
        }

        public void HandleClick(TextInput element)
        {
            var mouseIsInArea = element.Bounds.Contains(new Point2D<int>(mouseState.Position.X, mouseState.Position.Y));
            if (mouseState.LeftButton == ButtonState.RELEASED && previousMouseState.LeftButton == ButtonState.PRESSED && mouseIsInArea)
                element.Selected = true;
            else if (mouseState.LeftButton == ButtonState.RELEASED && previousMouseState.LeftButton == ButtonState.PRESSED)
                element.Selected = false;
        }

        public void UpdateMouseState()
        {
            previousMouseState = mouseState;
            mouseState = inputAdapter.GetMouseState();
        }
    }
}
