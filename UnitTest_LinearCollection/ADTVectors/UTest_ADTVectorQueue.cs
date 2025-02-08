using Collections.Vectors;

namespace UnitTest_LinearCollection.Tests
{
    public class UTest_ADTVectorQueue
    {
        private ADTVectorQueue<int> _instanceVectorQueue;

        #region SetUp and Helpers
        [SetUp]
        public void Setup()
        {
            _instanceVectorQueue = new ADTVectorQueue<int>();
        }
        private void PushItems(params int[] items)
        {
            foreach (var item in items)
            {
                _instanceVectorQueue.toPush(item);
            }
        }
        #endregion
        #region Tests
        #region CRUDs
        [Test]
        public void toPush_AsExpected()
        {
            _instanceVectorQueue.toPush(10);
            _instanceVectorQueue.toPush(20);
            _instanceVectorQueue.toPush(30);
            Assert.AreEqual(3, _instanceVectorQueue.attLength);
        }
        [Test]
        public void toPeek_AsExpected()
        {
            PushItems(10, 20, 30);
            int refResult = 0;
            _instanceVectorQueue.toPeek(ref refResult);
            Assert.AreEqual(10, refResult);
            Assert.AreEqual(3, _instanceVectorQueue.attLength);
        }
        [Test]
        public void toPop_AsExpected()
        {
            PushItems(10, 20, 30);
            int refResult = 0;
            _instanceVectorQueue.toPop(ref refResult);
            Assert.AreEqual(10, refResult);
            Assert.AreEqual(2, _instanceVectorQueue.attLength);
        }
        #endregion

        #region Utilities
        [Test]
        public void toClear_AsExpected()
        {
            PushItems(10, 20, 30);
            _instanceVectorQueue.toClear();
            Assert.AreEqual(0, _instanceVectorQueue.attLength);
        }
        [Test]
        public void toReverse_AsExpected()
        {
            PushItems(10, 20, 30);
            _instanceVectorQueue.toReverse();
            Assert.AreEqual(30, _instanceVectorQueue.GoIndex(0));
            Assert.AreEqual(20, _instanceVectorQueue.GoIndex(1));
            Assert.AreEqual(10, _instanceVectorQueue.GoIndex(2));
        }
        [Test]
        public void toSort_AsExpected()
        {
            PushItems(30, 10, 20);
            _instanceVectorQueue.QuickSort(0, _instanceVectorQueue.attLength - 1);
            Assert.AreEqual(10, _instanceVectorQueue.GoIndex(0));
            Assert.AreEqual(20, _instanceVectorQueue.GoIndex(1));
            Assert.AreEqual(30, _instanceVectorQueue.GoIndex(2));
        }
        #endregion 
        #endregion

    }
}