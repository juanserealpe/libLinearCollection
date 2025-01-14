using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Interfaces
{
    public interface iADT<T> where T : IComparable<T>
    {
        void toPrint();
        void toSort();
        void toClear();
        void toReverse();
    }
}
