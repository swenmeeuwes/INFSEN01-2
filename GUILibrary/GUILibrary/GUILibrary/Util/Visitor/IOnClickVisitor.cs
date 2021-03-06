﻿using GUILibrary.Input;
using GUILibrary.UI.View.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Visitor
{
    interface IOnClickVisitor
    {
        void UpdateMouseState();

        void HandleClick(Button element);
        void HandleClick(TextInput element);
    }
}
