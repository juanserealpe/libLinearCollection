using Collections.Vectors;

namespace UnitTest_LinearCollection.Tests
{
    public class UTest_ADTVectorList
    {
        private ADTVectorList<int> _instanceVectorList;

        #region SetUp

        [SetUp]
        public void Setup()
        {
            _instanceVectorList = new ADTVectorList<int>();
        }
        private void AddItems(params int[] items)
        {
            foreach (var item in items)
            {
                _instanceVectorList.toAdd(item);
            }
        }
        #endregion

        #region Tests

        #region Positioners
        [Test]
        public void Positioners()
        {
            _instanceVectorList.toAdd(10);
            Assert.AreEqual(10, _instanceVectorList.GoFirst());
            Assert.AreEqual(10, _instanceVectorList.GoLast());
            Assert.AreEqual(10, _instanceVectorList.GoIndex(0));

            _instanceVectorList.toAdd(20);
            Assert.AreEqual(10, _instanceVectorList.GoFirst());
            Assert.AreEqual(20, _instanceVectorList.GoLast());
            Assert.AreEqual(20, _instanceVectorList.GoIndex(1));

            _instanceVectorList.toAdd(30);
            Assert.AreEqual(10, _instanceVectorList.GoFirst());
            Assert.AreEqual(30, _instanceVectorList.GoLast());
            Assert.AreEqual(20, _instanceVectorList.GoIndex(1));

            _instanceVectorList.GoIndex(0);
            int resultGoNext = _instanceVectorList.GoNext();
            Assert.AreEqual(20, resultGoNext);

            resultGoNext = _instanceVectorList.GoNext();
            Assert.AreEqual(30, resultGoNext);


            int resultGoPrev = _instanceVectorList.GoIndex(2);
            resultGoPrev = _instanceVectorList.GoPrev();
            Assert.AreEqual(20, resultGoPrev);

            resultGoPrev = _instanceVectorList.GoPrev();
            Assert.AreEqual(10, resultGoPrev);

        }
        #endregion

        #region CRUDs
        [Test]
        public void ToAdd()
        {
            AddItems(10, 20, 30);

            Assert.AreEqual(10, _instanceVectorList.GoIndex(0));
            Assert.AreEqual(20, _instanceVectorList.GoIndex(1));
            Assert.AreEqual(30, _instanceVectorList.GoIndex(2));
            Assert.AreEqual(3, _instanceVectorList.attLength);
        }
        [Test]
        public void ToRetrieve()
        {
            AddItems(10);
            int result = 0;
            _instanceVectorList.toRetrieve(0, ref result);

            Assert.AreEqual(10, result);
            Assert.AreEqual(1, _instanceVectorList.attLength);
        }
        [Test]
        public void ToRemoveByIdx()
        {
            AddItems(10, 15, 20);

            int refResult = 0;

            _instanceVectorList.toRemoveByIndex(0, ref refResult);
            Assert.AreEqual(10, refResult);
            Assert.AreEqual(2, _instanceVectorList.attLength);

            _instanceVectorList.toRemoveByIndex(1, ref refResult);
            Assert.AreEqual(1, _instanceVectorList.attLength);
            Assert.AreEqual(20, refResult);
        }
        [Test]
        public void ToRemove()
        {
            AddItems(10, 12, 13);

            _instanceVectorList.toRemove(12);
            Assert.AreEqual(2, _instanceVectorList.attLength);
            int resultGo = _instanceVectorList.GoIndex(1);
            Assert.AreEqual(13, resultGo);

            _instanceVectorList.toRemove(10);
            Assert.AreEqual(1, _instanceVectorList.attLength);
            resultGo = _instanceVectorList.GoIndex(0);
            Assert.AreEqual(13, resultGo);

            _instanceVectorList.toRemove(13);
            Assert.AreEqual(0, _instanceVectorList.attLength);
        }
        [Test]
        public void ToModify()
        {
            _instanceVectorList.toAdd(1);
            _instanceVectorList.toModify(0, 2);

            int resultValue = _instanceVectorList.GoIndex(0);

            Assert.AreEqual(2, resultValue);
            Assert.AreEqual(1, _instanceVectorList.attLength);
        }
        [Test]
        public void AddManyItemsToCheckCapacity()
        {
            for (int varIdx = 0; varIdx < 1000; varIdx++)
            {
                AddItems(varIdx + 1);
            }
        }
        #endregion

        #region Utilities
        [Test]
        public void toClearArray()
        {
            AddItems(10, 20, 30);
            _instanceVectorList.toClear();
            Assert.AreEqual(0, _instanceVectorList.attLength);
        }
        [Test]
        public void toReverse()
        {
            AddItems(10, 20, 30);
            _instanceVectorList.toReverse();
            Assert.AreEqual(30, _instanceVectorList.GoIndex(0));
            Assert.AreEqual(20, _instanceVectorList.GoIndex(1));
            Assert.AreEqual(10, _instanceVectorList.GoIndex(2));
        }
        [Test]
        public void toSort()
        {
            AddItems(30, 10, 20);
            _instanceVectorList.toSort();
            Assert.AreEqual(10, _instanceVectorList.GoIndex(0));
            Assert.AreEqual(20, _instanceVectorList.GoIndex(1));
            Assert.AreEqual(30, _instanceVectorList.GoIndex(2));
        }


        #endregion

        #region Exceptions
        [Test]
        public void ArgumentOutOfRangeException()
        {
            _instanceVectorList.toAdd(10);
            Assert.Throws<ArgumentOutOfRangeException>(() => _instanceVectorList.GoIndex(5));
        }
        [Test]
        public void LimitCapactyException()
        {
            ADTVectorList<int> _instanceListWithCapacity = new ADTVectorList<int>(2);

            _instanceListWithCapacity.toAdd(10);
            _instanceListWithCapacity.toAdd(20);

            Assert.AreEqual(2, _instanceListWithCapacity.attLength);
            Assert.Throws<ArgumentOutOfRangeException>(() => _instanceListWithCapacity.toAdd(30));
        }
        #endregion

        #endregion
    }
}
