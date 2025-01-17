using Collections.Vectors;
using LinearCollection.ADTLinked;

namespace UnitTest_LinearCollection.Tests
{
    public class UTest_ADTLinkedList
    {
        private ADTLinkedList<int> _instanceLinkedList;

        #region SetUp
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

        #region Tests

        #region CRUDs
        [Test]
        public void toAdd()
        {
            AddItems(1, 2, 3);
            Assert.AreEqual(3, _instanceLinkedList.GoLast());
        }
        [Test]
        public void toRetrieve()
        {
            AddItems(1, 2, 3);
            int refItem = 0;
            _instanceLinkedList.toRetrieve(1, ref refItem);
            Assert.AreEqual(2, refItem);
            _instanceLinkedList.toRetrieve(0, ref refItem);
            Assert.AreEqual(1, refItem);
            _instanceLinkedList.toRetrieve(2, ref refItem);
            Assert.AreEqual(3, refItem);
        }
        #endregion

        #region Positioners
        [Test]
        public void Positioners()
        {
            AddItems(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Assert.AreEqual(10, _instanceLinkedList.GoLast());
            Assert.AreEqual(5, _instanceLinkedList.GoIndex(4));
            Assert.AreEqual(1, _instanceLinkedList.GoFirst());

            int IndexItem = _instanceLinkedList.GoIndex(3);
            Assert.AreEqual(4, IndexItem);

            int PreviousItem = _instanceLinkedList.GoPrev();
            Assert.AreEqual(3, PreviousItem);

            int NextItem = _instanceLinkedList.GoNext();
            Assert.AreEqual(4, NextItem);

            IndexItem = _instanceLinkedList.GoIndex(9);
            Assert.Throws<ArgumentOutOfRangeException>(() => _instanceLinkedList.GoNext());
        }
        #endregion 

        #endregion
    }
}