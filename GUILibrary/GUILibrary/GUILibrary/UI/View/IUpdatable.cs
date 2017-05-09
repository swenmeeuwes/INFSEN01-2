using GUILibrary.Util.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.UI.View
{
    interface IUpdatable
    {
        void Update(IUpdateVisitor updateVisitor, float deltaTime);
    }
}
