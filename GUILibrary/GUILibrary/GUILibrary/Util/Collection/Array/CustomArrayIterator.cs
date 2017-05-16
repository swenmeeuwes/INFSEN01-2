using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Collection.Array
{
    class CustomArrayIterator<T> : AbstractNumericIndexIterator<T>
    {
        public T[] Content { get; private set; }
        public CustomArrayIterator(T[] content)
        {
            Content = content;
            indexCounter = -1;
        }
        public override T Current()
        {
            if (indexCounter < 0)
                throw new Exception("[CustomArrayIterator] Next() should be called before accessing the current value.");

            return Content[indexCounter];
        }

        public override bool HasNext()
        {
            return indexCounter < Content.Length;
        }

        public override T Next()
        {
            return Content[indexCounter++];
        }
    }
}
