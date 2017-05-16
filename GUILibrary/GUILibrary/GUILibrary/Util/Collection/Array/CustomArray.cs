using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Collection.Array
{
    class CustomArray<T> : IAggregate<T>
    {
        private T[] content;
        // Allow for index lookup, ex: customArray[0]
        public T this[int key]
        {
            get
            {
                return content[key];
            }
            set
            {
                content[key] = value;
            }
        }

        public CustomArray(T[] content)
        {
            this.content = content;
        }
        public IIterator<T> GetIterator()
        {
            return new CustomArrayIterator<T>(content);
        }
    }
}
