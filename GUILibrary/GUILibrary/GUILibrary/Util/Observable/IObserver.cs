using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Observable
{
    interface IObserver
    {
        void onNotify(Event eventObject);
    }
}
