﻿using GUILibrary.UI.Drawing;
using GUILibrary.UI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.Util.Visitor;
using GUILibrary.Util.Collection.List;
using GUILibrary.Util.Structures;

namespace GUILibrary.UI.Window
{
    class GUIWindow : IUpdatable, IDrawable
    {
        public string Id { get; set; }

        private CustomList<AbstractView> views;
        public GUIWindow(string id)
        {
            Id = id;
            views = new CustomList<AbstractView>();
            InjectParent(views);
        }
        public GUIWindow(string id, params AbstractView[] viewElements)
        {
            Id = id;
            views = viewElements.ToCustomList();
            InjectParent(views);
        }

        public GUIWindow(string id, CustomList<AbstractView> viewElements)
        {
            Id = id;
            views = viewElements;
            InjectParent(views);
        }

        public void HandleClick(IOnClickVisitor onClickVisitor)
        {
            var viewIterator = views.GetIterator();
            while (viewIterator.HasNext())
            {
                var view = viewIterator.Next();
                view.HandleClick(onClickVisitor);
            }
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

        private void InjectParent(CustomList<AbstractView> viewElements)
        {
            var viewIterator = viewElements.GetIterator();
            while (viewIterator.HasNext())
            {
                var view = viewIterator.Next();
                view.Parent = this;
            }
        }
    }
}
