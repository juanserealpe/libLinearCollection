using Collections.Vectors;
using LinearCollection.ADTVectors;

namespace UnitTest_LinearCollection.Tests
{
    public class UTest_ADTVectorStack
    {
        private ADTVectorStack<int> _instanceList;

        #region SetUp
        [SetUp]
        public void Setup()
        {
            _instanceList = new ADTVectorStack<int>();
        }
        private void toPushItems(params int[] items)
        {
            foreach (var item in items)
            {
                _instanceList.toPush(item);
            }
        }
        #endregion

        #region CRUDs
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
            Assert.AreEqual(30, refResult);
            Assert.AreEqual(3, _instanceList.attLength);
        }
        [Test]
        public void toPop()
        {
            toPushItems(10, 20, 30);
            int refResult = 0;
            _instanceList.toPop(ref refResult);
            Assert.AreEqual(30, refResult);
            Assert.AreEqual(2, _instanceList.attLength);
        } 
        #endregion

        #region Utilities
        [Test]
        public void toCrearArray()
        {
            toPushItems(10, 20, 30);
            _instanceList.toClear();
            Assert.AreEqual(0, _instanceList.attLength);
        }
        [Test]
        public void toReverse()
        {
            toPushItems(10, 20, 30);
            _instanceList.toReverse();
            Assert.AreEqual(30, _instanceList.GoIndex(0));
            Assert.AreEqual(20, _instanceList.GoIndex(1));
            Assert.AreEqual(10, _instanceList.GoIndex(2));
        }
        [Test]
        public void toSort()
        {
            toPushItems(30, 10, 20);
            _instanceList.toSort();
            Assert.AreEqual(10, _instanceList.GoIndex(0));
            Assert.AreEqual(20, _instanceList.GoIndex(1));
            Assert.AreEqual(30, _instanceList.GoIndex(2));
        }
        #endregion

    }
}