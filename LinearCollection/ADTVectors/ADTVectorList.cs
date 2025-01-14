using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections.ADT;
using Collections.Interfaces;

namespace Collections.Vectors
{
    public class ADTVectorList<T> : ADT<T> , iADTList<T> where T : IComparable<T>
    {

        #region Builders
        public ADTVectorList(int prmCapacity) : base(prmCapacity) { }
        public ADTVectorList() : base() { }
        #endregion

        #region Methods
        public void toAdd(T prmItem) => toInsertOn(prmItem, this.attLength);
        public void toRemove(T prmItem) => toRemoveOn(prmItem);
        public void toRemoveByPosition(int prmPosition, ref T prmItem) => toRemoveByIndex(prmPosition, ref prmItem);
        public void toRetrieve(int prmPosition, ref T prmItem) => toRetrieveRef(prmPosition, ref prmItem); 
        public void toModify(int prmPosition, T prmItem) => toModifyOn(prmPosition, prmItem);
        #endregion

    }
}
