using GUILibrary.Input.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Input
{
    interface IInputAdapter
    {
        Key[] GetPressedKeys();
        MouseState GetMouseState();
    }
}
