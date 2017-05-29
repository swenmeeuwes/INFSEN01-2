using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.Button;
using GUILibrary.UI.Label;

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
        public void Draw(Button.Button element)
        {
            // Handle call the draw method from the draw class here
            throw new NotImplementedException();
        }

        public void Draw(Label.Label element)
        {
            // Handle call the draw method from the draw class here
            throw new NotImplementedException();
        }
    }
}
