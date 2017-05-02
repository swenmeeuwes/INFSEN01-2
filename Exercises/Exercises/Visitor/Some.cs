using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Some<T> : IOption<T>
    {
        T value;
        public Some(T value)
        {
            this.value = value;
        }

        public U Visit<U>(IOptionVisitor<T, U> visitor)
        {
            return visitor.OnSome<U>(this.value);
        }
    }
}
