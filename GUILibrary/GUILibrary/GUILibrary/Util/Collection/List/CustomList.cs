using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Collection.List
{
    class CustomList<T> : IAggregate<T>
    {
        private List<T> content;
        // Allow for index lookup, ex: customList[0]
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

        public CustomList()
        {
            this.content = new List<T>();
        }
        public IIterator<T> GetIterator()
        {
            return new CustomListIterator<T>(content);
        }

        // Expose list methods
        public void Add(T item)
        {
            content.Add(item);
        }
    }
}
