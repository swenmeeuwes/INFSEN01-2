using GUILibrary.UI.View.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.UI.Drawing
{
    interface IDrawStrategy
    {
        void Draw(Clickable element);
        void Draw(Labeled element);
        void Draw(Panel element);
    }
}
