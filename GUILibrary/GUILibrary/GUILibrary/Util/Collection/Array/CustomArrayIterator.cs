using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Collection.Array
{
    public class CustomArrayIterator<T> : IIterator<T>
    {
        public T[] Content { get; private set; }
        private int indexCounter;
        public CustomArrayIterator(T[] content)
        {
            Content = content;
            indexCounter = -1;
        }
        public T Current()
        {
            if (indexCounter < 0)
                throw new Exception("[CustomArrayIterator] Next() should be called before accessing the current value.");

            return Content[indexCounter];
        }

        public bool HasNext()
        {
            return indexCounter < Content.Length - 1;
        }

        public T Next()
        {
            return Content[++indexCounter];
        }
    }
}
