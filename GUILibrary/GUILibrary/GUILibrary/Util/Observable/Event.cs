using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Observable
{
    class Event
    {
        public string Type { get; set; }
        public object Target { get; set; }
        public bool Cancelable { get; set; }

        public Event(string type, object target = null, bool cancelable = false)
        {
            this.Type = type;
            this.Target = target;
            this.Cancelable = cancelable;
        }
    }
}
