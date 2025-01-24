using Collections.Vectors;
using LinearCollection.ADTLinked;

namespace UnitTest_LinearCollection.Tests
{
    public class UTest_ADTLinkedQueue
    {
        private ADTLinkedQueue<int> _instanceLinkedQueue;

        #region Setup and Helpers
        [SetUp]
        public void Setup()
        {
            _instanceLinkedQueue = new ADTLinkedQueue<int>();
        }

        private void PushItems(params int[] items)
        {
            foreach (var item in items)
            {
                _instanceLinkedQueue.toPush(item);
            }
        }
        #endregion
        #region Tests
        #region CRUDs
        [Test]
        public void toPush_AsExpected()
        {
            _instanceLinkedQueue.toPush(10);
            _instanceLinkedQueue.toPush(20);
            _instanceLinkedQueue.toPush(30);
            Assert.AreEqual(3, _instanceLinkedQueue.attLength);
        }
        [Test]
        public void toPeek_AsExpected()
        {
            PushItems(10, 20, 30);
            int refResult = 0;
            _instanceLinkedQueue.toPeek(ref refResult);
            Assert.AreEqual(10, refResult);
            Assert.AreEqual(3, _instanceLinkedQueue.attLength);
        }
        [Test]
        public void toPop_AsExpected()
        {
            PushItems(10, 20, 30);
            int refResult = 0;
            _instanceLinkedQueue.toPop(ref refResult);
            Assert.AreEqual(10, refResult);
            Assert.AreEqual(2, _instanceLinkedQueue.attLength);
        }
        #endregion
        #region Utilities
        [Test]
        public void toClear_AsExpected()
        {

        }
        #endregion
        #endregion

    }
}
