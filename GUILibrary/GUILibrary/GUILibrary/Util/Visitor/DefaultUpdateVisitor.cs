using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.View;
using GUILibrary.Input;
using GUILibrary.UI.View.Decorators;

namespace GUILibrary.Util.Visitor
{
    class DefaultUpdateVisitor : IUpdateVisitor
    {
        public void Update(AbstractView element, float deltaTime)
        {
            //element.UpdateState(InputManager.Instance.Mouse);
        }

        public void Update(Clickable element, float deltaTime)
        {
            
        }

        public void Update(Labeled element, float deltaTime)
        {

        }
    }
}
