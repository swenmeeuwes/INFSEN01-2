using GUILibrary.UI.Drawing;
using GUILibrary.UI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.Util.Visitor;

namespace GUILibrary.UI.Window
{
    class GUIWindow : IUpdatable, IDrawable
    {
        public string Id { get; set; }
        List<View.View> views;

        public GUIWindow(string id)
        {
            Id = id;
            views = new List<View.View>();
        }
        public GUIWindow(string id, params View.View[] viewElements)
        {
            Id = id;
            views = viewElements.ToList();
        }

        public void Update(IUpdateVisitor updateVisitor, float deltaTime)
        {
            views.ForEach(v => v.Update(updateVisitor, deltaTime));
        }

        public void Draw(IDrawVisitor drawVisitor)
        {
            views.ForEach(v => v.Draw(drawVisitor));
        }
    }
}
