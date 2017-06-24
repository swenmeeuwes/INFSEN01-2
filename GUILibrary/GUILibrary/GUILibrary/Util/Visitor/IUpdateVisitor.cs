using GUILibrary.UI.View;
using GUILibrary.UI.View.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Visitor
{
    interface IUpdateVisitor
    {
        void Update(Clickable element, float deltaTime);
        void Update(Labeled element, float deltaTime);        
    }
}
