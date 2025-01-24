using LinealCollection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinealCollection.Helpers
{
    public class Iterator<T> : iIterator<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attCurrentIndex = -1;
        protected T attCurrentItem = default;
        public int attLength = 0;
        #endregion
        #region Builders
        public Iterator() { } 
        #endregion
        #region Positioners
        public virtual T GoFirst()
        {
            ValidateNotEmpty();
            this.attCurrentIndex = 0;
            return default(T);
        }
        public virtual T GoIndex(int prmPosition)
        {
            ValidateNotEmpty();
            ValidateRangePosition(prmPosition);
            this.attCurrentIndex = prmPosition;
            return default(T);
        }
        public virtual T GoLast()
        {
            ValidateNotEmpty();
            this.attCurrentIndex = attLength - 1;
            return default(T);
        }
        public virtual T GoNext()
        {
            ValidateNotEmpty();
            ValidateRangePosition(attCurrentIndex+1);
            attCurrentIndex += 1;
            return default(T);
        }
        public virtual T GoPrev()
        {
            ValidateNotEmpty();
            ValidateRangePosition(this.attCurrentIndex-1);
            ValidateRangePosition(this.attCurrentIndex);
            attCurrentIndex -= 1;
            return default(T);
        }
        public virtual T GoItem()
        {
            ValidateNotEmpty();
            ValidateRangePosition(this.attCurrentIndex);
            return default(T);
        }
        #endregion
        #region Utilities
        public bool isEmpty()
        {
            if (this.attLength == 0) return true;
            return false;
        }
        protected bool isValid(int prmPosition)
        {
            if (prmPosition >= this.attLength) return false;
            if (prmPosition < 0) return false;
            return true;
        }
        protected void ValidateRangePosition(int prmPosition)
        {
            if (!isValid(prmPosition))
                throw new ArgumentOutOfRangeException(nameof(prmPosition), "Position is out of range.");
        }
        protected void ValidateNotEmpty()
        {
            if (isEmpty()) throw new Exception("The collection is empty.");
        } 
        #endregion
    }
}
