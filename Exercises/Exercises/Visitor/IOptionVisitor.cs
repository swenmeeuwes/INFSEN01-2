using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    interface IOptionVisitor<T, U>
    {
        U OnSome(T value);
        U OnNone();
    }
}
