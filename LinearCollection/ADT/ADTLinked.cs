﻿using Collections.ADT;
using LinealCollection.Helpers;
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
        protected LinkedNode<T> attLastNode;
        protected LinkedNode<T> attMiddleNode;
        #endregion
        #region Builders
        public ADTLinked(int prmCapacity) : base(prmCapacity) { }
        public ADTLinked() : base() { }
        #endregion
        #region ProtectedMethods
        protected override void toIncrementCapacity()
        {
            if (!this.isFlexible)
            {
                ValidateRangePosition(this.attCapacity);
                return;
            }
            this.attCapacity += this.incrementValue;
        }
        protected override void toInsertOn(T prmItem, int prmPosition)
        {
            if (this.attLength == this.attCapacity) toIncrementCapacity();
            LinkedNode<T> varNewNode = new LinkedNode<T>(prmItem);
            this.attCurrentNode = varNewNode;
            if (this.attLength == 0)
            {
                FirstInsertion(prmItem);
                return;
            }
            this.attLastNode.attNextNode = this.attCurrentNode;
            this.attLastNode = this.attCurrentNode;
            this.attLength++;
            SetCurrentAttributes(attLength - 1);
            SetPositionerIncrement();
        }
        protected override void toModifyOn(int prmPosition, T prmItem)
        {
            GoIndex(prmPosition);
            this.attCurrentNode.attItem = prmItem;
            this.attCurrentItem = prmItem;
        }
        protected override void toRetrieveRef(int prmPosition, ref T prmItem)
        {
            GoIndex(prmPosition);
            prmItem = this.attCurrentItem;
        }
        protected LinkedNode<T> GetNodeByIndex(int prmPosition)
        {
            GetPositioner(prmPosition);
            TravelCollection(prmPosition);
            return this.attCurrentNode;
        }
        protected void GetPositioner(int prmPosition)
        {
            if (prmPosition == this.attLength - 1) GoLast();
            if (prmPosition == this.attLength / 2 || prmPosition > this.attLength / 2) GoIndex(prmPosition / 2);
            if (prmPosition < this.attLength / 2) GoFirst();
        }
        protected void TravelCollection(int prmPosition)
        {
            for (int varIdx = this.attCurrentIndex; varIdx < prmPosition; varIdx++) attCurrentNode = attCurrentNode.attNextNode;
            this.attCurrentIndex = prmPosition;
        }
        protected void FirstInsertion(T prmItem)
        {
            SetCurrentAttributes(0);
            this.attFirstNode = attMiddleNode = attLastNode = this.attCurrentNode;
            this.attLength++;
        }
        protected void SetPositionerIncrement()
        {
            if (attLength == 2) return;
            if (this.attLength % 2 != 0)
                this.attMiddleNode = attMiddleNode.attNextNode;
        }
        protected void SetPositionersDecrement(int prmPosition, ref T prmItemByRef)
        {
            if(this.attLength == 1)
            {
                prmItemByRef = this.attFirstNode.attItem;
                this.attCurrentNode = this.attFirstNode = this.attMiddleNode = this.attLastNode = null;
                this.attLength--;
                return;
            }
            if(prmPosition == 0)
            {
                GoFirst();
                prmItemByRef = this.attCurrentItem;
                this.attCurrentNode = this.attCurrentNode.attNextNode;
                this.attFirstNode = attCurrentNode;
                SetCurrentAttributes(0);
            }
            if (prmPosition == this.attLength-1)
            {
                GoIndex(prmPosition-1);
                prmItemByRef = this.attCurrentNode.attNextNode.attItem;
                this.attCurrentNode.attNextNode = null;
                this.attLastNode = attCurrentNode;
                SetCurrentAttributes(attLength - 1);
            }
            this.attLength--;
        }
        protected override void SetCurrentAttributes(int prmPosition)
        {
            this.attCurrentItem = this.attCurrentNode.attItem;
            this.attCurrentIndex = prmPosition;
        }
        protected void SetMiddleWhenDecrement()
        {
            int varAuxLength = attLength-1;
            GoIndex(varAuxLength/2);
            this.attMiddleNode = this.attCurrentNode;
        }
        #endregion
        #region PublicMethods
        public override void toRemoveByIndex(int prmPosition, ref T prmItemByRef)
        {
            if (prmPosition == 0 || prmPosition == this.attLength-1)
            {
                SetPositionersDecrement(prmPosition, ref prmItemByRef);
                return;
            }
            GoIndex(prmPosition - 1);
            prmItemByRef = this.attCurrentNode.attNextNode.attItem;
            this.attCurrentNode.attNextNode = this.attCurrentNode.attNextNode.attNextNode;
            SetCurrentAttributes(prmPosition-1);
            this.attLength--;
            SetMiddleWhenDecrement();
            GoIndex(prmPosition);
        }
        public override void toRemove(T prmItem)
        {
            LinkedNode<T> nodeFound = this.attFirstNode;
            T dummyRef = default(T);
            for (int varIdx = 0; varIdx < this.attLength; varIdx++)
            {
                if (nodeFound.attItem.Equals(prmItem))
                {
                    toRemoveByIndex(varIdx, ref dummyRef);
                    break;
                }
                nodeFound = nodeFound.attNextNode;
            }
        }
        public override void toSort()
        {

        }
        public override void toClear()
        {

        }
        public override void toCopyTo(T[] prmArray, int startIndex)
        {

        }
        public override void toReverse()
        {

        }
        #endregion
        #region Positioners
        public override T GoFirst()
        {
            ValidateNotEmpty();
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
            ValidateNotEmpty();
            this.attCurrentNode = this.attLastNode;
            SetCurrentAttributes(this.attLength-1);
            return this.attCurrentItem;
        }
        public override T GoNext()
        {
            base.GoNext();
            this.attCurrentNode = attCurrentNode.attNextNode;
            SetCurrentAttributes(attCurrentIndex);
            return attCurrentItem;
        }
        public override T GoPrev()
        {
            base.GoPrev();
            GoIndex(this.attCurrentIndex);
            return attCurrentItem;
        }
        #endregion
    }
}
