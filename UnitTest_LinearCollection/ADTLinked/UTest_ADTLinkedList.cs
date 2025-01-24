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
        public void toAdd_AsExpected()
        {
            AddItems(1, 2, 3);
            Assert.AreEqual(3, _instanceLinkedList.attLength);
        }
        [Test]
        public void toRetrieveItemByIndex_AsExpected()
        {
            AddItems(1, 2, 3);
            int retrievedItem = 0;

            _instanceLinkedList.toRetrieve(1, ref retrievedItem);
            Assert.AreEqual(2, retrievedItem);
        }
        [Test]
        public void toRemoveItem_AsExpected()
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
            Assert.AreEqual(2, _instanceLinkedList.GoLast());
            //(2)
            //empty
            _instanceLinkedList.toRemove(2);
            Assert.IsTrue(_instanceLinkedList.isEmpty());
        }
        [Test]
        public void toModifyItem_AsExpected()
        {
            AddItems(1, 2, 3);
            _instanceLinkedList.toModify(1, 99);

            Assert.AreEqual(99, _instanceLinkedList.GoIndex(1));
        }
        [Test]
        public void toRemoveItemByIndex_AsExpected()
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

        #region DeepChecks
        [Test]
        public void toRemoveItemByIndex_FirstAndLast_toCheckFlow()
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
        public void AddManyItems_toCheckCapacity()
        {
            for (int varIdx = 0; varIdx < 1000; varIdx++)
            {
                AddItems(varIdx + 1);
            }
        } 
        #endregion

        #endregion

        #region Positioning Operations
        [Test]
        public void Positioners_AsExpected()
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
        public void PositionersThenRemoved_AsExpected()
        {
            AddItems(1, 2, 3, 4, 5, 6);
            _instanceLinkedList.toRemove(4);
            //(1, 2, 3, 5, 6)
            Assert.AreEqual(5, _instanceLinkedList.GoItem());
            _instanceLinkedList.toRemove(6);
            //(1, 2, 3, 5)
            Assert.AreEqual(5, _instanceLinkedList.GoItem());

            _instanceLinkedList.toRemove(2);
            //(1, 3, 5)
            Assert.AreEqual(3, _instanceLinkedList.GoItem());

            _instanceLinkedList.toRemove(1);
            //(3, 5)
            Assert.AreEqual(3, _instanceLinkedList.GoItem());

            _instanceLinkedList.toRemove(3);
            //(5)
            Assert.AreEqual(5, _instanceLinkedList.GoItem());
        }
        #endregion

        #region Utilities
        [Test]
        public void toClear_AsExpected()
        {
            AddItems(1, 2, 3, 4, 5, 6, 7, 8, 9);
            _instanceLinkedList.toClear();
            Assert.IsTrue(_instanceLinkedList.isEmpty());
        }
        [Test]
        public void toClear_ThenInsertion()
        {
            AddItems(1, 2, 3, 4, 5, 6, 7, 8, 9);
            _instanceLinkedList.toClear();
            Assert.IsTrue(_instanceLinkedList.isEmpty());

            AddItems(1);
            Assert.IsTrue(!_instanceLinkedList.isEmpty());
            Assert.AreEqual(1, _instanceLinkedList.GoIndex(0));
            Assert.AreEqual(1, _instanceLinkedList.GoLast());

            AddItems(2);
            Assert.AreEqual(2, _instanceLinkedList.GoIndex(1));
            Assert.AreEqual(2, _instanceLinkedList.GoLast());
        }
        [Test]
        public void toReverse_AsExpected()
        {
            AddItems(1, 2, 3, 4, 5, 6, 7);
            _instanceLinkedList.toReverse();
            Assert.AreEqual(7, _instanceLinkedList.GoFirst());
            Assert.AreEqual(1, _instanceLinkedList.GoLast());

            int auxLast = _instanceLinkedList.attLength-1;
            int auxFirst = 0;

            auxLast -= 1;
            auxFirst += 1;
            Assert.AreEqual(2, _instanceLinkedList.GoIndex(auxLast));
            Assert.AreEqual(6, _instanceLinkedList.GoIndex(auxFirst));

            auxLast -= 1;
            auxFirst += 1;
            Assert.AreEqual(3, _instanceLinkedList.GoIndex(auxLast));
            Assert.AreEqual(5, _instanceLinkedList.GoIndex(auxFirst));

            Assert.AreEqual(4, _instanceLinkedList.GoNext());

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
