using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    interface IOption<T>
    {
        U Visit<U>(IOptionVisitor<T, U> visitor);
    }
}
