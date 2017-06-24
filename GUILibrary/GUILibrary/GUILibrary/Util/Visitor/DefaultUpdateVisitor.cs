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
        public void Update(PlainView element, float deltaTime)
        {
            element.UpdateState(InputManager.Instance.Mouse);
        }

        public void Update(Button element, float deltaTime)
        {
            var mouseState = InputManager.Instance.Mouse;
            var mouseIsInArea = element.Bounds.Contains(new Point2D<int>(mouseState.Position.X, mouseState.Position.Y));
            if (mouseIsInArea)
                Mouse.SetCursor(MouseCursor.Hand); // Probably make an adapter for this
        }

        public void Update(Label element, float deltaTime)
        {

        }
    }
}
