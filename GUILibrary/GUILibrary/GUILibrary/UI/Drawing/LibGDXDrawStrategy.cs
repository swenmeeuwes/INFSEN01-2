using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.Label;
using GUILibrary.UI.View.Decorators;

namespace GUILibrary.UI.Drawing
{
    /// <summary>
    /// This class is a stub
    /// It shows how the strategies for adapters in other drawing libraries should be implemented
    /// </summary>
    class LibGDXDrawStrategy : IDrawStrategy
    {
        private object drawClass;
        public LibGDXDrawStrategy(object drawClass)
        {
            // Composite relationship with the draw class here
            this.drawClass = drawClass;
        }

        public void Draw(View.Decorators.Label element)
        {
            // Handle call the draw method from the draw class here
            throw new NotImplementedException();
        }

        public void Draw(Button element)
        {
            throw new NotImplementedException();
        }

        public void Draw(Panel element)
        {
            throw new NotImplementedException();
        }

        public void Draw(TextInput element)
        {
            throw new NotImplementedException();
        }
    }
}
