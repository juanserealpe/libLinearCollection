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
            return default(T);
        }

        public virtual T GoIndex(int prmPosition)
        {
            ValidateNotEmpty();
            ValidateRangePosition(prmPosition);
            return default(T);
        }

        public virtual T GoLast()
        {
            ValidateNotEmpty();
            return default(T);
        }

        public virtual T GoNext()
        {
            ValidateNotEmpty();
            ValidateRangePosition(attCurrentIndex+1);

            if (attCurrentIndex == null || attCurrentIndex == -1)
                throw new Exception("There isn't reference to use this method.");
            
            attCurrentIndex += 1;
            return default(T);
        }

        public virtual T GoPrev()
        {
            ValidateNotEmpty();
            if (attCurrentIndex-1 < 0)
            {
                throw new ArgumentOutOfRangeException("The position cannot be negative.");
            }
            attCurrentIndex -= 1;
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
            if (this.attLength <= prmPosition) return false;
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
