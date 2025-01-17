using Collections.Interfaces;
using LinearCollection.ADT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCollection.ADTLinked
{
    public class ADTLinkedList<T> : ADTLinked<T>, iADTList<T> where T : IComparable<T>
    {
        public void toAdd(T prmItem) => toInsertOn(prmItem, this.attLength);

        public void toModify(int prmPosition, T prmItem)
        {
            throw new NotImplementedException();
        }

        public void toRetrieve(int prmPosition, ref T prmItem)
        {
            throw new NotImplementedException();
        }
    }
}
