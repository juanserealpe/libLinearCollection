using Collections.Vectors;
using LinearCollection.ADTLinked;

namespace UnitTest_LinearCollection.Tests
{
    public class UTest_ADTLinkedList
    {
        private ADTLinkedList<int> _instanceLinkedList;

        #region Setup and Helpers
        [SetUp]
        public void Setup()
        {
            _instanceLinkedList = new ADTLinkedList<int>();
        }

        private void AddItems(params int[] items)
        {
            foreach (var item in items)
            {
                _instanceLinkedList.toAdd(item);
            }
        }
        #endregion

        #region CRUD Operations

        [Test]
        public void AddItem_AddsElementAtEnd()
        {
            AddItems(1, 2, 3);
            Assert.AreEqual(3, _instanceLinkedList.attLength);
        }
        [Test]
        public void AddManyItemsToCheckCapacity()
        {
            for (int varIdx = 0; varIdx < 1000; varIdx++)
            {
                AddItems(varIdx + 1);
            }
        }
        [Test]
        public void RetrieveItemByIndex_ReturnsCorrectValue()
        {
            AddItems(1, 2, 3);
            int retrievedItem = 0;

            _instanceLinkedList.toRetrieve(1, ref retrievedItem);
            Assert.AreEqual(2, retrievedItem);
        }
        [Test]
        public void ModifyItem_UpdatesValueCorrectly()
        {
            AddItems(1, 2, 3);
            _instanceLinkedList.toModify(1, 99);

            Assert.AreEqual(99, _instanceLinkedList.GoIndex(1));
        }
        [Test]
        public void RemoveItemByIndex_DeletesCorrectItem()
        {
            AddItems(1, 2, 3, 4, 5);
            int itemRemoved = 0; 

            //(1,2,3,4,5);
            //(1,2,4,5);
            _instanceLinkedList.toRemoveByIndex(2, ref itemRemoved);
            Assert.AreEqual(3, itemRemoved);

            //(1,2,4,5);
            //(1,4,5);
            _instanceLinkedList.toRemoveByIndex(1, ref itemRemoved);
            Assert.AreEqual(2, itemRemoved);

            //(1,4,5);
            //(4,5);
            _instanceLinkedList.toRemoveByIndex(0, ref itemRemoved);
            Assert.AreEqual(1, itemRemoved);

            //(4,5);
            //(5);
            _instanceLinkedList.toRemoveByIndex(0, ref itemRemoved);
            Assert.AreEqual(4, itemRemoved);

            //(5);
            //empty
            _instanceLinkedList.toRemoveByIndex(0, ref itemRemoved);
            Assert.AreEqual(5, itemRemoved);
            Assert.IsTrue(_instanceLinkedList.isEmpty());
        }
        [Test]
        public void RemoveItemByIndex_if_itsLastOrFirst()
        {
            AddItems(1, 2, 3, 4, 5);
            int itemRemoved = 0;
            //(1, 2, 3, 4, 5)
            //(2, 3, 4, 5);
            _instanceLinkedList.toRemoveByIndex(0, ref itemRemoved);
            Assert.AreEqual(1, itemRemoved);
            Assert.AreEqual(2, _instanceLinkedList.GoFirst());

            //(2, 3, 4, 5);
            //(2, 3, 4);
            _instanceLinkedList.toRemoveByIndex(3, ref itemRemoved);
            Assert.AreEqual(5, itemRemoved);
            Assert.AreEqual(4, _instanceLinkedList.GoLast());

            //(2, 3, 4);
            //(2, 3);
            _instanceLinkedList.toRemoveByIndex(2, ref itemRemoved);
            Assert.AreEqual(4, itemRemoved);
            Assert.AreEqual(3, _instanceLinkedList.GoLast());
            //(2, 3);
            //(2);
            _instanceLinkedList.toRemoveByIndex(1, ref itemRemoved);
            Assert.AreEqual(3, itemRemoved);
            Assert.AreEqual(2, _instanceLinkedList.GoLast());

            //(2);
            //Null
            _instanceLinkedList.toRemoveByIndex(0, ref itemRemoved);
            Assert.AreEqual(2, itemRemoved);
            Assert.IsTrue(_instanceLinkedList.isEmpty());

        }
        [Test]
        public void RemoveItem_DeletesCorrectItem()
        {
            AddItems(1, 2, 3, 4, 5);

            //(1, 2, 3, 4, 5);
            //(2, 3, 4, 5);
            _instanceLinkedList.toRemove(1);
            Assert.AreEqual(2, _instanceLinkedList.GoFirst());
            //(2, 3, 4, 5);
            //(2, 3, 4);
            _instanceLinkedList.toRemove(5);
            Assert.AreEqual(4, _instanceLinkedList.GoLast());
            //(2, 3, 4);
            //(2, 4);
            _instanceLinkedList.toRemove(3);
            Assert.AreEqual(4, _instanceLinkedList.GoLast());
            //(2, 4);
            //(2);
            _instanceLinkedList.toRemove(4);
            Assert.AreEqual(2, _instanceLinkedList.GoFirst());
            Assert.AreEqual(2, _instanceLinkedList.attMiddleNode.attItem);
            Assert.AreEqual(2, _instanceLinkedList.GoLast());
            //(2)
            //empty
            _instanceLinkedList.toRemove(2);
            Assert.IsTrue(_instanceLinkedList.isEmpty());
        }
        [Test]
        public void RemoveCheckMiddle()
        {
            //(1, 2, 3, [4], 5, 6, 7, 8);
            AddItems(1, 2, 3, 4, 5, 6, 7, 8);
            Assert.AreEqual(4, _instanceLinkedList.attMiddleNode.attItem);

            //(1, 2, 3, [4], 5, 6, 7, 8);
            //(1, 3, 4, [5], 6, 7, 8);
            int itemRemoved = 0;
            _instanceLinkedList.toRemoveByIndex(1, ref itemRemoved);
            Assert.AreEqual(2, itemRemoved);
            Assert.AreEqual(5, _instanceLinkedList.attMiddleNode.attItem);

            //(1, 3, 4, [5], 6, 7, 8);
            //(1, 4, [5], 6, 7, 8);
            _instanceLinkedList.toRemoveByIndex(1, ref itemRemoved);
            Assert.AreEqual(3, itemRemoved);
            Assert.AreEqual(5, _instanceLinkedList.attMiddleNode.attItem);


            //(1, 4, [5], 6, 7, 8);
            //(1, 5, [6], 7, 8);
            _instanceLinkedList.toRemoveByIndex(1, ref itemRemoved);
            Assert.AreEqual(4, itemRemoved);
            Assert.AreEqual(6, _instanceLinkedList.attMiddleNode.attItem);

            //(1, 5, [6], 7, 8);
            //(1, [6], 7, 8);
            _instanceLinkedList.toRemoveByIndex(1, ref itemRemoved);
            Assert.AreEqual(5, itemRemoved);
            Assert.AreEqual(6, _instanceLinkedList.attMiddleNode.attItem);

            //(1, [6], 7, 8);
            //(1, [6], 8);
            _instanceLinkedList.toRemoveByIndex(2, ref itemRemoved);
            Assert.AreEqual(7, itemRemoved);
            Assert.AreEqual(6, _instanceLinkedList.attMiddleNode.attItem);

            //(1, [6], 8);
            //([1], 8);
            _instanceLinkedList.toRemoveByIndex(1, ref itemRemoved);
            Assert.AreEqual(6, itemRemoved);
            Assert.AreEqual(1, _instanceLinkedList.attMiddleNode.attItem);
        }

        #endregion

        #region Positioning Operations

        [Test]
        public void Positioners_WorkAsExpected()
        {
            AddItems(1, 2, 3, 4, 5);
            Assert.AreEqual(1, _instanceLinkedList.GoFirst());
            Assert.AreEqual(2, _instanceLinkedList.GoNext());
            Assert.AreEqual(3, _instanceLinkedList.GoNext());
            Assert.AreEqual(4, _instanceLinkedList.GoNext());
            Assert.AreEqual(5, _instanceLinkedList.GoNext());
            Assert.AreEqual(5, _instanceLinkedList.GoLast());
            Assert.AreEqual(3, _instanceLinkedList.GoIndex(2));
            AddItems(6);
            Assert.AreEqual(5, _instanceLinkedList.GoPrev());
            Assert.AreEqual(4, _instanceLinkedList.GoPrev());
            Assert.AreEqual(3, _instanceLinkedList.GoPrev());
            Assert.AreEqual(2, _instanceLinkedList.GoPrev());
            Assert.AreEqual(1, _instanceLinkedList.GoPrev());
            Assert.AreEqual(2, _instanceLinkedList.GoNext());
        }

        [Test]
        public void Middle_WorkAsExpected()
        {
            int varIncrement = 1; //1
            AddItems(1);
            Assert.AreEqual(_instanceLinkedList.attMiddleNode.attItem, varIncrement);
            AddItems(2);
            Assert.AreEqual(_instanceLinkedList.attMiddleNode.attItem, varIncrement);

            varIncrement += 1; //2
            AddItems(3);
            Assert.AreEqual(_instanceLinkedList.attMiddleNode.attItem, varIncrement);
            AddItems(4);
            Assert.AreEqual(_instanceLinkedList.attMiddleNode.attItem, varIncrement);

            varIncrement += 1; //3
            AddItems(5);
            Assert.AreEqual(_instanceLinkedList.attMiddleNode.attItem, varIncrement);
            AddItems(6);
            Assert.AreEqual(_instanceLinkedList.attMiddleNode.attItem, varIncrement);

            varIncrement += 1; //4
            AddItems(7);
            Assert.AreEqual(_instanceLinkedList.attMiddleNode.attItem, varIncrement);
            AddItems(8);
            Assert.AreEqual(_instanceLinkedList.attMiddleNode.attItem, varIncrement);

            varIncrement += 1; //5
            AddItems(9);
            Assert.AreEqual(_instanceLinkedList.attMiddleNode.attItem, varIncrement);
            AddItems(10);
            Assert.AreEqual(_instanceLinkedList.attMiddleNode.attItem, varIncrement);
        }

        #endregion

        #region Exception Handling

        [Test]
        public void AddItem_ThrowsExceptionWhenExceedingCapacity()
        {
            var limitedList = new ADTLinkedList<int>(5);
            
            for (int varIdx = 0; varIdx < 5; varIdx++)
            {
                limitedList.toAdd(varIdx+1);
            }
            Assert.Throws<ArgumentOutOfRangeException>(() => limitedList.toAdd(6));
        }

        [Test]
        public void RetrieveItem_ThrowsExceptionForInvalidIndex()
        {
            AddItems(1, 2, 3);

            Assert.Throws<ArgumentOutOfRangeException>(() => _instanceLinkedList.GoIndex(5));
            Assert.Throws<ArgumentOutOfRangeException>(() => _instanceLinkedList.GoIndex(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => _instanceLinkedList.GoNext());
            _instanceLinkedList.GoPrev();
            _instanceLinkedList.GoPrev();
            Assert.Throws<ArgumentOutOfRangeException>(() => _instanceLinkedList.GoPrev());
        }

        #endregion
    }
}
