using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinealCollection.Interfaces
{
    public interface iIterator<T> where T : IComparable<T>
    {
        T GoIndex(int prmPosition);
        T GoFirst();
        T GoLast();
        T GoNext();
        T GoPrev();
        bool isEmpty();

    }
}
