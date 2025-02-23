﻿using Collections.ADT;
using LinearCollection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCollection.ADTVectors
{
    public class ADTVectorStack<T> : ADT<T> , iADTStack<T> where T : IComparable<T>
    {
        #region Builders
        public ADTVectorStack() : base()
        {

        }
        public ADTVectorStack(int prmCapacity) : base(prmCapacity)
        {

        } 
        #endregion
        #region Methods
        public void toPeek(ref T prmItem) => toRetrieveRef(attLength - 1, ref prmItem);
        public void toPop(ref T prmItem) => toRemoveByIndex(attLength - 1, ref prmItem);
        public void toPush(T prmItem) => toInsertOn(prmItem, attLength); 
        #endregion
    }
}
