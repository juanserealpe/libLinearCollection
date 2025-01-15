using Collections.ADT;
using Collections.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Vectors
{
    public class ADTVectorQueue<T> : ADT<T>, iVectorQueue<T> where T : IComparable<T>
    {
        #region Builders
        public ADTVectorQueue(int prmCapacity) : base(prmCapacity){}
        public ADTVectorQueue() : base(){}
        #endregion

        #region Methods
        public void toPeek(ref T prmItem) => toRetrieveRef(0, ref prmItem);
        public void toPop(ref T prmItem) => toRemoveByIndex(0, ref prmItem);
        public void toPush(T prmItem) => toInsertOn(prmItem, attLength);
        #endregion
    }
}
