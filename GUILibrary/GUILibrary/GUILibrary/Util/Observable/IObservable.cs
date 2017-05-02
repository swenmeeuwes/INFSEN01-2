using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Observable
{
    interface IObservable
    {
        void registerObserver(IObserver observer);
        void deregisterObserver(IObserver observer);
        void notify(Event eventObject);
    }
}
