using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Observable
{
    class ActionObserver : IObserver
    {
        private Action<Event> action;
        public ActionObserver(Action<Event> action)
        {
            this.action = action;
        }
        public void OnNotify(Event eventObject)
        {
            action.Invoke(eventObject);
        }
    }
}
