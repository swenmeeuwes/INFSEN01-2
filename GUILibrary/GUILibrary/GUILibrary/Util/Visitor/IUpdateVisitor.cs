using GUILibrary.UI.Button;
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
    }
}
