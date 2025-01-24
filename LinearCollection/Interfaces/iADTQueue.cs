using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Interfaces
{
    public interface iADTQueue<T> where T : IComparable<T>
    {
        void toPush(T prmItem);
        void toPop(ref T prmItem);
        void toPeek(ref T prmItem);
    }
}
