using Collections.Vectors;
using LinearCollection.ADTVectors;

namespace UnitTest_LinearCollection.Tests
{
    public class UTest_ADTVectorStack
    {
        private ADTVectorStack<int> _instanceVectorStack;

        #region SetUp
        [SetUp]
        public void Setup()
        {
            _instanceVectorStack = new ADTVectorStack<int>();
        }
        private void toPushItems(params int[] items)
        {
            foreach (var item in items)
            {
                _instanceVectorStack.toPush(item);
            }
        }
        #endregion

        #region CRUDs
        [Test]
        public void toPush()
        {
            toPushItems(10, 20, 30);
            Assert.AreEqual(3, _instanceVectorStack.attLength);
        }

        [Test]
        public void toPeek()
        {
            toPushItems(10, 20, 30);
            int refResult = 0;
            _instanceVectorStack.toPeek(ref refResult);
            Assert.AreEqual(30, refResult);
            Assert.AreEqual(3, _instanceVectorStack.attLength);
        }
        [Test]
        public void toPop()
        {
            toPushItems(10, 20, 30);
            int refResult = 0;
            _instanceVectorStack.toPop(ref refResult);
            Assert.AreEqual(30, refResult);
            Assert.AreEqual(2, _instanceVectorStack.attLength);
        } 
        #endregion

        #region Utilities
        [Test]
        public void toCrearArray()
        {
            toPushItems(10, 20, 30);
            _instanceVectorStack.toClear();
            Assert.AreEqual(0, _instanceVectorStack.attLength);
        }
        [Test]
        public void toReverse()
        {
            toPushItems(10, 20, 30);
            _instanceVectorStack.toReverse();
            Assert.AreEqual(30, _instanceVectorStack.GoIndex(0));
            Assert.AreEqual(20, _instanceVectorStack.GoIndex(1));
            Assert.AreEqual(10, _instanceVectorStack.GoIndex(2));
        }
        [Test]
        public void toSort()
        {
            toPushItems(30, 10, 20);
            _instanceVectorStack.QuickSort(0, _instanceVectorStack.attLength - 1);
            Assert.AreEqual(10, _instanceVectorStack.GoIndex(0));
            Assert.AreEqual(20, _instanceVectorStack.GoIndex(1));
            Assert.AreEqual(30, _instanceVectorStack.GoIndex(2));
        }
        #endregion

    }
}