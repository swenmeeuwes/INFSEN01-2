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
        void Draw(Button element);
        void Draw(View.Decorators.Label element);
        void Draw(Panel element);
        void Draw(TextInput element);
    }
}
