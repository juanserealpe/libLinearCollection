using Collections.Vectors;

namespace UnitTest_LinearCollection.Tests
{
    public class UTest_ADTVectorQueue
    {
        private ADTVectorQueue<int> _instanceList;

        #region SetUp
        [SetUp]
        public void Setup()
        {
            _instanceList = new ADTVectorQueue<int>();
        }
        #endregion

        private void toPushItems(params int[] items)
        {
            foreach (var item in items)
            {
                _instanceList.toPush(item);
            }
        }

        [Test]
        public void toPush()
        {
            toPushItems(10, 20, 30);
            Assert.AreEqual(3, _instanceList.attLength);
        }

        [Test]
        public void toPeek()
        {
            toPushItems(10, 20, 30);
            int refResult = 0;
            _instanceList.toPeek(ref refResult);
            Assert.AreEqual(10, refResult);
            Assert.AreEqual(3, _instanceList.attLength);
        }
        [Test]
        public void toPop()
        {
            toPushItems(10, 20, 30);
            int refResult = 0;
            _instanceList.toPop(ref refResult);
            Assert.AreEqual(10, refResult);
            Assert.AreEqual(2, _instanceList.attLength);
        }

    }
}