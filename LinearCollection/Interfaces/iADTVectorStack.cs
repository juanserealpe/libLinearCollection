using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCollection.Interfaces
{
    public interface iADTVectorStack <T> where T : IComparable<T>
    {
        void toPush(T prmItem);
        void toPop(ref T prmItem);
        void toPeek(ref T prmItem);
    }
}
