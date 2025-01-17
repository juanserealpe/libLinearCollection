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
                this.attCurrentIndex = 0;
                FirstInsertion(prmItem);
                return;
            }
            LinkedNode<T> varNewNode = new LinkedNode<T>(prmItem);
            this.attLastNode.attNextNode = varNewNode;
            this.attLastNode = varNewNode;
            this.attLength++;
            SetPositionerIncrement();
        }
        protected override void toModifyOn(int prmPosition, T prmItem)
        {
            ValidateRangePosition(prmPosition);

        }
        protected override void toRetrieveRef(int prmPosition, ref T prmItem) 
            => prmItem = GetNodeByIndex(prmPosition).attItem;
        protected LinkedNode<T> GetNodeByIndex(int prmPosition)
        {
            ValidateNotEmpty();
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

            if (prmPosition <= this.attLength / 2)
            {
                this.attCurrentIndex = 0;
                if (prmPosition < this.attLength / 2) return this.attFirstNode;
                this.attCurrentIndex = attLength - 1 / 2;
                return this.attMiddleNode;
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
            this.attCurrentIndex = prmPosition;
        }
        protected void FirstInsertion(T prmItem)
        {
            LinkedNode<T> newNode = new LinkedNode<T>(prmItem);
            this.attFirstNode = newNode;
            this.attMiddleNode = newNode;
            this.attLastNode = newNode;
            this.attLength++;
        }
        protected void SetPositionerIncrement()
        {
            if (attLength == 2) return;
            if (this.attLength % 2 != 0)
                this.attMiddleNode = attMiddleNode.attNextNode;
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
            this.attCurrentItem = this.attFirstNode.attItem;
            this.attCurrentNode = this.attFirstNode;
            return this.attCurrentItem;
        }
        public override T GoIndex(int prmPosition)
        {
            base.GoIndex(prmPosition);
            this.attCurrentNode = GetNodeByIndex(prmPosition);
            this.attCurrentItem = this.attCurrentNode.attItem;
            return this.attCurrentNode.attItem;
        }
        public override T GoLast()
        {
            base.GoLast();
            this.attCurrentItem = this.attLastNode.attItem;
            this.attCurrentNode = this.attLastNode;
            return this.attLastNode.attItem;
        }
        public override T GoNext()
        {
            base.GoNext();
            this.attCurrentNode = attCurrentNode.attNextNode;
            this.attCurrentItem = this.attCurrentNode.attItem;
            this.attCurrentIndex++;
            return attCurrentItem;
        }
        public override T GoPrev()
        {
            base.GoPrev();
            GoIndex(attCurrentIndex--);
            this.attCurrentIndex -= 1;
            return attCurrentNode.attItem;
        }
        #endregion
    }
}
