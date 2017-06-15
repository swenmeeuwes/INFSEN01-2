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

namespace GUILibrary.Util.Visitor
{
    class OnClickVisitor : IOnClickVisitor
    {
        public void HandleClick(View element)
        {
            var mouseState = InputManager.Instance.Mouse;
            var mouseIsInArea = element.Bounds.Contains(new Point2D<int>(mouseState.Position.X, mouseState.Position.Y));
            if (element.GetState() == ViewState.RELEASED && mouseIsInArea)
            {
                var eventObject = new Event("Click", element);
                element.Notify(eventObject);
            }
        }
    }
}
