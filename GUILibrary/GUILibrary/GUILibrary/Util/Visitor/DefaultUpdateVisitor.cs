using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.Button;
using GUILibrary.UI.Label;

namespace GUILibrary.Util.Visitor
{
    class DefaultUpdateVisitor : IUpdateVisitor
    {
        public void Update(Button element, float deltaTime)
        {
            
        }

        public void Update(Label element, float deltaTime)
        {

        }
    }
}
