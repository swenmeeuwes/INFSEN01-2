using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Observable
{
    interface IObservable
    {
        void RegisterObserver(IObserver observer);
        void DeregisterObserver(IObserver observer);
        void Notify(Event eventObject);
    }
}
