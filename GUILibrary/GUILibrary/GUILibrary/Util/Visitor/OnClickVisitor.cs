using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.View;
using Microsoft.Xna.Framework.Input;
using GUILibrary.Util.Observable;

namespace GUILibrary.Util.Visitor
{
    class OnClickVisitor : IOnClickVisitor
    {
        public void Visit(View element)
        {
            //var mouseState = Mouse.GetState();
            //var mousePosition = mouseState.Position;

            //var mouseIsInArea = element.Bounds.Contains(mouseState.Position);
            //var mouseIsPressed = mouseState.LeftButton == ButtonState.Pressed || mouseState.MiddleButton == ButtonState.Pressed || mouseState.RightButton == ButtonState.Pressed;

            //if (mouseIsInArea)
            //{
                var eventObject = new Event("Click", this);
                element.Notify(eventObject);
            //}
        }
    }
}
