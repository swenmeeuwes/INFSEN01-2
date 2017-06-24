using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.View;
using GUILibrary.Input;
using GUILibrary.UI.View.Decorators;
using GUILibrary.Util.Structures;
using Microsoft.Xna.Framework.Input;

namespace GUILibrary.Util.Visitor
{
    class DefaultUpdateVisitor : IUpdateVisitor
    {
        private IInputAdapter inputAdapter;
        public DefaultUpdateVisitor(IInputAdapter inputAdapter)
        {
            this.inputAdapter = inputAdapter;
        }
        public void Update(PlainView element, float deltaTime)
        {
            element.UpdateState(inputAdapter.GetMouseState());
        }

        public void Update(Button element, float deltaTime)
        {
            var mouseState = inputAdapter.GetMouseState();
            var mouseIsInArea = element.Bounds.Contains(new Point2D<int>(mouseState.Position.X, mouseState.Position.Y));
            if (mouseIsInArea)
                Mouse.SetCursor(MouseCursor.Hand); // Probably make an adapter for this
        }

        public void Update(Label element, float deltaTime)
        {

        }

        public void Update(TextInput element, float deltaTime)
        {
            var pressedKeys = inputAdapter.GetPressedKeys();
            if (element.Selected && pressedKeys.Length > 0)
                element.HandleInput(pressedKeys);
        }
    }
}
