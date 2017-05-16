using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Util.Collection.List
{
    public static class CustomListExtensions
    {
        public static CustomList<T> ToCustomList<T>(this IEnumerable<T> enumerable)
        {
            var customList = new CustomList<T>();
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
                customList.Add(enumerator.Current);
            return customList;
        }
    }
}
