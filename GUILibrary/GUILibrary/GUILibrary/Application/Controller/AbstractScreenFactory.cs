using GUILibrary.UI.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Application.Controller
{
    // It would probably be better to construct screen out of external files, such as .xml files
    abstract class AbstractScreenFactory
    {
        public abstract GUIWindow CreateMainScreen(ScreenNavigator screenNavigator);
        public abstract GUIWindow CreateInputScreen(ScreenNavigator screenNavigator);
        public abstract GUIWindow CreateLabelScreen(ScreenNavigator screenNavigator);

        public abstract GUIWindow CreateScreenFromId(string id, ScreenNavigator screenNavigator);
    }
}
