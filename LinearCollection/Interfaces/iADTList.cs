using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Interfaces
{
    public interface iADTList<T>
    {
        void toAdd(T prmItem);
        void toRemove(T prmItem);
        void toRetrieve(int prmPosition, ref T prmItem);
        void toModify(int prmPosition, T prmItem);
        void toRemoveByPosition(int prmPosition, ref T prmItem);
    }
}
