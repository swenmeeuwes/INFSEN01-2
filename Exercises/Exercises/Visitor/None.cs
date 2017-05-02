using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class None<T> : IOption<T>
    {
        public U Visit<U>(IOptionVisitor<T, U> visitor)
        {
            return visitor.OnNone<U>();
        }
    }
}
