using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Temperature
{
    public interface IElement
    {
        // accept visitor on this element
        void Accept(IVisitor visitor);

        // call accept(visitor) on all child elements (called only from visitors)
        void Traverse(IVisitor visitor);
    }
}
