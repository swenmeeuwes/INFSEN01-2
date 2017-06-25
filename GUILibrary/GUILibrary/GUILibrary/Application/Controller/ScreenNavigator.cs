using GUILibrary.UI.Window;
using GUILibrary.Util.Collection;
using GUILibrary.Util.Collection.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Application.Controller
{
    class ScreenNavigator
    {
        private AbstractScreenFactory screenFactory;
        private IApplicationAdapter applicationAdapter;
        private CustomList<GUIWindow> screens;
        public ScreenNavigator(AbstractScreenFactory screenFactory, IApplicationAdapter applicationAdapter)
        {
            this.screenFactory = screenFactory;
            this.applicationAdapter = applicationAdapter;
            this.screens = new CustomList<GUIWindow>();
        }

        public IIterator<GUIWindow> GetScreenIterator()
        {
            return screens.GetIterator();
        }

        public void GotoScreen(string screenId)
        {
            screens = new CustomList<GUIWindow>();
            OpenScreen(screenId);
        }

        public void GotoScreen(GUIWindow screen)
        {
            screens = new CustomList<GUIWindow>();
            OpenScreen(screen);
        }

        public void OpenScreen(string screenId)
        {
            var screen = screenFactory.CreateScreenFromId(screenId, this);
            screens.Add(screen);
        }

        public void OpenScreen(GUIWindow screen)
        {            
            screens.Add(screen);
        }

        public void CloseScreen(GUIWindow screen)
        {
            screens.Remove(screen);
        }

        public void Exit()
        {
            applicationAdapter.Exit();
        }
    }
}
