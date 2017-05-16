using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Collection.List
{
    class CustomListIterator<T> : IIterator<T>
    {
        public List<T> Content { get; private set; }
        private int indexCounter;
        public CustomListIterator(List<T> content)
        {
            Content = content;
            indexCounter = -1;
        }
        public T Current()
        {
            if (indexCounter < 0)
                throw new Exception("[CustomListIterator] Next() should be called before accessing the current value.");

            return Content[indexCounter];
        }

        public bool HasNext()
        {
            return indexCounter < Content.Count;
        }

        public T Next()
        {
            return Content[indexCounter++];
        }
    }
}
