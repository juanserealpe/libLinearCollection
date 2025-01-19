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
        public LinkedNode<T> attMiddleNode;
        protected LinkedNode<T> attLastNode; 
        #endregion
        #region Builders
        public ADTLinked(int prmCapacity) : base(prmCapacity) { }
        public ADTLinked() : base() { }
        #endregion
        #region ProtectedMethods
        protected override void toIncrementCapacity() 
            => this.attCapacity += this.incrementValue;
        protected override void toInsertOn(T prmItem, int prmPosition)
        {
            if (this.attLength == 0)
            {
                FirstInsertion(prmItem);
                return;
            }
            LinkedNode<T> varNewNode = new LinkedNode<T>(prmItem);
            this.attLastNode.attNextNode = this.attCurrentNode = varNewNode;
            this.attCurrentItem = this.attCurrentNode.attItem;
            this.attCurrentIndex = attLength-1;
            this.attLastNode = varNewNode;
            this.attLength++;
            SetPositionerIncrement();
        }
        protected override void toModifyOn(int prmPosition, T prmItem)
        {
            ValidateRangePosition(prmPosition);
            GoIndex(prmPosition);
            this.attCurrentNode.attItem = prmItem;
            this.attCurrentItem = prmItem;
        }
        protected override void toRetrieveRef(int prmPosition, ref T prmItem) 
            => prmItem = GetNodeByIndex(prmPosition).attItem;
        protected LinkedNode<T> GetNodeByIndex(int prmPosition)
        {
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
            this.attCurrentIndex = 0;
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
            //This method is to set positioners; Example : Middle.
        }
        #endregion
        #region PublicMethods
        public override void toRemoveByIndex(int prmPosition, ref T prmItemByRef)
        {

        }
        protected void SetCurrentAttributes(int prmPosition)
        {
            this.attCurrentItem = this.attCurrentNode.attItem;
            this.attCurrentIndex = prmPosition;
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
            this.attCurrentNode = this.attFirstNode;
            SetCurrentAttributes(0);
            return this.attCurrentItem;
        }
        public override T GoIndex(int prmPosition)
        {
            base.GoIndex(prmPosition);
            this.attCurrentNode = GetNodeByIndex(prmPosition);
            SetCurrentAttributes(prmPosition);
            return this.attCurrentNode.attItem;
        }
        public override T GoLast()
        {
            base.GoLast();
            this.attCurrentNode = this.attLastNode;
            SetCurrentAttributes(this.attLength-1);
            return this.attLastNode.attItem;
        }
        public override T GoNext()
        {
            base.GoNext();
            this.attCurrentNode = attCurrentNode.attNextNode;
            SetCurrentAttributes(attCurrentIndex+1);
            return attCurrentItem;
        }
        public override T GoPrev()
        {
            base.GoPrev();
            GoIndex(attCurrentIndex--);
            SetCurrentAttributes(attCurrentIndex - 1);
            return attCurrentItem;
        }
        #endregion
    }
}
