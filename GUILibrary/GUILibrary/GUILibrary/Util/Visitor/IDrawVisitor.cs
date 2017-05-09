using GUILibrary.UI.Button;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Visitor
{
    interface IDrawVisitor
    {
        void Draw(Button element);
    }
}
