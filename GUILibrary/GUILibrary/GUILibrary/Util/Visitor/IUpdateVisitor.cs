using GUILibrary.UI.Button;
using GUILibrary.UI.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Visitor
{
    interface IUpdateVisitor
    {
        void Update(Button element, float deltaTime);
        void Update(Label element, float deltaTime);
    }
}
