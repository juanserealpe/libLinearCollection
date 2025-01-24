using Collections.Interfaces;
using LinearCollection.ADT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCollection.ADTLinked
{
    public class ADTLinkedQueue<T> : ADTLinked<T>, iADTQueue<T> where T: IComparable<T>
    {
        #region Builders
        public ADTLinkedQueue() : base()
        {

        }
        public ADTLinkedQueue(int prmCapacity) : base(prmCapacity)
        {

        }
        #endregion

        #region Methods
        public void toPeek(ref T prmItem) => toRetrieveRef(0, ref prmItem);
        public void toPop(ref T prmItem) => toRemoveByIndex(0, ref prmItem);
        public void toPush(T prmItem) => toInsertOn(prmItem, attLength);
        #endregion

    }
}
