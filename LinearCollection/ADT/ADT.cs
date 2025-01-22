using Collections.Interfaces;
using LinealCollection.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.ADT
{
    public abstract class ADT<T> : Iterator<T>, iADT<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attCapacity;
        protected T attItem { get; set; }
        protected T[] attArrayItems = new T[100];
        protected bool isFlexible = false;
        protected int incrementValue = 100;
        #endregion
        #region Builders
        public ADT(int prmCapacity)
        {
            this.attCapacity = prmCapacity;
            this.attArrayItems = new T[prmCapacity];
        }
        public ADT()
        {
            this.attCapacity = 100;
            this.isFlexible = true;
            this.attArrayItems = new T[attCapacity];
        }
        #endregion
        #region ProtectedMethods
        protected virtual void toIncrementCapacity()
        {
            if (!this.isFlexible) ValidateRangePosition(this.attCapacity);
            this.attCapacity += this.incrementValue;
            T[] newArray = new T[this.attCapacity];
            for (int varIdx = 0; varIdx < this.attLength; varIdx++) newArray[varIdx] = this.attArrayItems[varIdx];
            this.attArrayItems = newArray;
        }
        protected virtual void toInsertOn(T prmItem, int prmPosition)
        {
            if (this.attLength == this.attCapacity) toIncrementCapacity();
            attArrayItems[prmPosition] = prmItem;
            this.attLength++;
        }
        protected virtual void toModifyOn(int prmPosition, T prmItem)
        {
            ValidateRangePosition(prmPosition);
            if (this.attArrayItems[prmPosition] == null)
            {
                throw new Exception("Item is null in this position.");
            }
            attArrayItems[prmPosition] = prmItem;
        }
        protected virtual void toRetrieveRef(int prmPosition, ref T prmItem)
        {
            ValidateRangePosition(prmPosition);
            ValidateNotEmpty();
            prmItem = this.attArrayItems[prmPosition];
        }
        protected virtual void SetCurrentAttributes(int prmPosition)
        {
            this.attCurrentItem = this.attArrayItems[prmPosition];
            this.attCurrentIndex = prmPosition;
        }
        #endregion
        #region PublicMethods
        public virtual void toRemoveByIndex(int prmPosition, ref T prmItem)
        {
            ValidateRangePosition(prmPosition);
            ValidateNotEmpty();

            prmItem = this.attArrayItems[prmPosition];

            for (int varIdx = prmPosition; varIdx < this.attLength; varIdx++)
                this.attArrayItems[varIdx] = this.attArrayItems[varIdx + 1];

            this.attArrayItems[this.attLength - 1] = default(T);
            this.attLength--;
        }
        public virtual void toRemove(T prmItem)
        {
            for (int varIdx = 0; varIdx < this.attLength; varIdx++)
            {
                if (this.attArrayItems[varIdx].Equals(prmItem))
                {
                    for (global::System.Int32 varYdy = varIdx; varYdy < this.attLength - 1; varYdy++)
                    {
                        this.attArrayItems[varYdy] = this.attArrayItems[varYdy + 1];
                    }
                    this.attArrayItems[this.attLength - 1] = default(T);
                    this.attLength--;
                    break;
                }
            }
        }
        public virtual void toSort()
        {
            if (this.attLength <= 1) return;

            for (int i = 0; i < this.attLength - 1; i++)
            {
                for (int j = 0; j < this.attLength - i - 1; j++)
                {
                    if (this.attArrayItems[j].CompareTo(this.attArrayItems[j + 1]) > 0)
                    {
                        T temp = this.attArrayItems[j];
                        this.attArrayItems[j] = this.attArrayItems[j + 1];
                        this.attArrayItems[j + 1] = temp;
                    }
                }
            }
        }
        public virtual void toClear()
        {
            if (isFlexible) this.attCapacity = 100;

            for (int varIdx = 0; varIdx < this.attLength; varIdx++)
                this.attArrayItems[varIdx] = default(T);

            this.attArrayItems = new T[this.attCapacity];
            this.attLength = 0;
        }
        public virtual void toCopyTo(T[] prmArray, int startIndex)
        {
            if (prmArray == null)
                throw new ArgumentNullException(nameof(prmArray));

            if (startIndex < 0 || startIndex + this.attLength > prmArray.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Index is out of range.");

            for (int i = 0; i < this.attLength; i++)
            {
                prmArray[startIndex + i] = this.attArrayItems[i];
            }
        }
        public virtual void toReverse()
        {
            for (int varIdx = 0, varIdy = this.attLength - 1; varIdx < varIdy; varIdx++, varIdy--)
            {
                T auxItem = this.attArrayItems[varIdx];
                this.attArrayItems[varIdx] = this.attArrayItems[varIdy];
                this.attArrayItems[varIdy] = auxItem;
            }
        }
        #endregion
        #region Positioners
        public override T GoFirst()
        {
            base.GoFirst();
            SetCurrentAttributes(0);
            return this.attCurrentItem;
        }
        public override T GoIndex(int prmPosition)
        {

            base.GoIndex(prmPosition); 
            SetCurrentAttributes(prmPosition);
            return this.attCurrentItem;
        }
        public override T GoLast()
        {
            base.GoLast();
            SetCurrentAttributes(this.attCurrentIndex);
            return this.attCurrentItem;
        }
        public override T GoNext()
        {
            base.GoNext();
            SetCurrentAttributes(this.attCurrentIndex);
            return this.attCurrentItem;
        }
        public override T GoPrev()
        {
            base.GoPrev();
            SetCurrentAttributes(this.attCurrentIndex);
            return this.attCurrentItem;
        }
        #endregion
    }
}
