using GUILibrary.UI.View.Decorators;
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
        void Draw(Label element);
        void Draw(Panel element);
        void Draw(TextInput element);
    }
}
