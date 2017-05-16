﻿using GUILibrary.UI.Drawing;
using GUILibrary.UI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.Util.Visitor;
using GUILibrary.Util.Collection.List;

namespace GUILibrary.UI.Window
{
    class GUIWindow : IUpdatable, IDrawable
    {
        public string Id { get; set; }
        CustomList<View.View> views;

        public GUIWindow(string id)
        {
            Id = id;
            views = new CustomList<View.View>();
        }
        public GUIWindow(string id, params View.View[] viewElements)
        {
            Id = id;
            views = viewElements.ToCustomList();
        }

        public GUIWindow(string id, CustomList<View.View> viewElements)
        {
            Id = id;
            views = viewElements;
        }

        public void Update(IUpdateVisitor updateVisitor, float deltaTime)
        {
            var viewIterator = views.GetIterator();
            while (viewIterator.HasNext())
            {
                var view = viewIterator.Next();
                view.Update(updateVisitor, deltaTime);
            }
        }

        public void Draw(IDrawVisitor drawVisitor)
        {
            var viewIterator = views.GetIterator();
            while (viewIterator.HasNext())
            {
                var view = viewIterator.Next();
                view.Draw(drawVisitor);
            }
        }
    }
}
