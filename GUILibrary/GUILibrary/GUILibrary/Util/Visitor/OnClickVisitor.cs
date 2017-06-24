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
        public void HandleClick(Clickable clickable)
        {
            var mouseState = InputManager.Instance.Mouse;
            var mouseIsInArea = clickable.Bounds.Contains(new Point2D<int>(mouseState.Position.X, mouseState.Position.Y));
            if (clickable.State == ViewState.RELEASED && mouseIsInArea)
            {                
                var eventObject = new Event("Click", clickable);
                clickable.Notify(eventObject);
            }
        }
    }
}
