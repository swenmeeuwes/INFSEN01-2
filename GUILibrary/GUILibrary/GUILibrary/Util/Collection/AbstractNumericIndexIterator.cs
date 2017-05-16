using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Collection
{
    abstract class AbstractNumericIndexIterator<T> : IIterator<T>
    {
        protected int indexCounter;
        public abstract T Current();

        public abstract bool HasNext();

        public abstract T Next();
    }
}
