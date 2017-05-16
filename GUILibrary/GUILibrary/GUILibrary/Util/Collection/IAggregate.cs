using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Collection
{
    interface IAggregate<T>
    {
        IIterator<T> GetIterator();
    }
}
