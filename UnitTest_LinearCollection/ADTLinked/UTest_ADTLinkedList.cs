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
            Assert.AreEqual(3, _instanceLinkedList.GoLast());
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

        }

        #endregion

        #region Positioning Operations

        [Test]
        public void Positioners_WorkAsExpected()
        {
            AddItems(1, 2, 3, 4, 5);
            Assert.AreEqual(1, _instanceLinkedList.GoFirst());
            Assert.AreEqual(5, _instanceLinkedList.GoLast());
            Assert.AreEqual(3, _instanceLinkedList.GoIndex(2));
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
        }

        #endregion
    }
}
