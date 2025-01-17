using Collections.ADT;
using LinearCollection.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCollection.ADT
{
    public class ADTLinked<T>: ADT<T> where T : IComparable<T>
    {
        #region Attributes
        protected LinkedNode<T> attCurrentNode { get; set; }
        protected LinkedNode<T> attFirstNode;
        protected LinkedNode<T> attMiddleNode;
        protected LinkedNode<T> attLastNode; 
        #endregion

        #region Builders
        public ADTLinked(int prmCapacity) : base(prmCapacity) { }
        public ADTLinked() : base() { }
        #endregion

        #region ProtectedMethods
        protected override void toIncrementCapacity()
        {
            this.attCapacity += this.incrementValue;
        }
        protected override void toInsertOn(T prmItem, int prmPosition)
        {
            if (this.attLength == 0 && prmPosition == 0)
            {
                FirstInsertion(prmItem);
                return;
            }
            LinkedNode<T> varNewNode = new LinkedNode<T>(prmItem);
            this.attLastNode.attNextNode = varNewNode;
            this.attLastNode = varNewNode;
            this.attLength++;
        }
        protected override void toModifyOn(int prmPosition, T prmItem)
        {
            ValidateRangePosition(prmPosition);

        }
        protected override void toRetrieveRef(int prmPosition, ref T prmItem)
        {
            ValidateRangePosition(prmPosition);
            ValidateNotEmpty();

        }

        protected LinkedNode<T> GetNodeByIndex(int prmPosition)
        {
            ValidateRangePosition(prmPosition);
            LinkedNode<T> varNodePositioner = getPositioner(prmPosition);
            TravelCollection(prmPosition, varNodePositioner);
            return this.attCurrentNode;
        }
        protected LinkedNode<T> getPositioner(int prmPosition)
        {
            if (prmPosition == this.attLength - 1)
            {
                this.attCurrentIndex = this.attLength;
                return this.attLastNode;
            }

            if (prmPosition < this.attLength / 2)
            {
                this.attCurrentIndex = 0;
                return this.attFirstNode;
            }

            if (prmPosition > this.attLength / 2)
            {
                this.attCurrentIndex = prmPosition / 2;
                return this.attMiddleNode;
            }
            return null;
        }
        protected void TravelCollection(int prmPosition, LinkedNode<T> prmNode)
        {
            attCurrentNode = prmNode;
            for (int varIdx = this.attCurrentIndex; varIdx < prmPosition; varIdx++)
            {
                attCurrentNode = attCurrentNode.attNextNode;
            }
        }
        protected void FirstInsertion(T prmItem)
        {
            LinkedNode<T> newNode = new LinkedNode<T>(prmItem);
            this.attFirstNode = newNode;
            this.attMiddleNode = newNode;
            this.attLastNode = newNode;
            this.attLength++;
        }
        protected void SetPositionersIncrement()
        {

        }
        protected void SetPositionersDecrement()
        {

        }
        #endregion

        #region PublicMethods
        public virtual void toRemoveByIndex(int prmPosition, ref T prmItem)
        {
            ValidateRangePosition(prmPosition);
            ValidateNotEmpty();

        }
        public virtual void toRemove(T prmItem)
        {
        }
        public virtual void toPrint()
        {
            ValidateNotEmpty();
        }
        public virtual void toSort()
        {

        }
        public virtual void toClear()
        {

        }
        public virtual void toCopyTo(T[] prmArray, int startIndex)
        {

        }
        public virtual void toReverse()
        {

        }
        #endregion

        #region Positioners
        public override T GoFirst()
        {
            base.GoFirst();
            this.attCurrentIndex = 0;
            this.attCurrentItem = this.attFirstNode.attItem;
            this.attCurrentNode = this.attFirstNode;
            return this.attCurrentItem;
        }
        public override T GoIndex(int prmPosition)
        {
            base.GoIndex(prmPosition);
            this.attCurrentIndex = prmPosition;
            this.attCurrentItem = this.attArrayItems[prmPosition];
            return this.attCurrentItem;
        }
        public override T GoLast()
        {
            base.GoLast();
            this.attCurrentIndex = attLength - 1;
            this.attCurrentItem = this.attLastNode.attItem;
            this.attCurrentNode = this.attLastNode;
            return this.attLastNode.attItem;
        }
        public override T GoNext()
        {
            base.GoNext();
            return GoIndex(attCurrentIndex);
        }
        public override T GoPrev()
        {
            base.GoPrev();
            return GoIndex(attCurrentIndex);
        }
        #endregion
    }
}
