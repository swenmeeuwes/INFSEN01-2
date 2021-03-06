﻿using GUILibrary.UI.View;
using GUILibrary.UI.View.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Visitor
{
    interface IUpdateVisitor
    {
        void Update(PlainView element, float deltaTime);
        void Update(Button element, float deltaTime);
        void Update(Label element, float deltaTime);
        void Update(TextInput element, float deltaTime);
    }
}
