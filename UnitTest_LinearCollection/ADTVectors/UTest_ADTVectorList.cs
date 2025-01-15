using Collections.Vectors;

namespace UnitTest_LinearCollection.Tests
{
    public class UTest_ADTVectorList
    {
        private ADTVectorList<int> _instanceList;

        #region SetUp

        [SetUp]
        public void Setup()
        {
            _instanceList = new ADTVectorList<int>();
        }
        private void AddItems(params int[] items)
        {
            foreach (var item in items)
            {
                _instanceList.toAdd(item);
            }
        }
        #endregion

        #region Tests

        #region Positioners
        [Test]
        public void Positioners()
        {
            _instanceList.toAdd(10);
            Assert.AreEqual(10, _instanceList.GoFirst());
            Assert.AreEqual(10, _instanceList.GoLast());
            Assert.AreEqual(10, _instanceList.GoIndex(0));

            _instanceList.toAdd(20);
            Assert.AreEqual(10, _instanceList.GoFirst());
            Assert.AreEqual(20, _instanceList.GoLast());
            Assert.AreEqual(20, _instanceList.GoIndex(1));

            _instanceList.toAdd(30);
            Assert.AreEqual(10, _instanceList.GoFirst());
            Assert.AreEqual(30, _instanceList.GoLast());
            Assert.AreEqual(20, _instanceList.GoIndex(1));

            _instanceList.GoIndex(0);
            int resultGoNext = _instanceList.GoNext();
            Assert.AreEqual(20, resultGoNext);

            resultGoNext = _instanceList.GoNext();
            Assert.AreEqual(30, resultGoNext);

            Assert.Throws<ArgumentOutOfRangeException>(() => _instanceList.GoNext());

            int resultGoPrev = _instanceList.GoIndex(2);
            resultGoPrev = _instanceList.GoPrev();
            Assert.AreEqual(20, resultGoPrev);

            resultGoPrev = _instanceList.GoPrev();
            Assert.AreEqual(10, resultGoPrev);

            Assert.Throws<ArgumentOutOfRangeException>(() => _instanceList.GoPrev());
        } 
        #endregion

        #region CRUDs
        [Test]
        public void ToAdd()
        {
            AddItems(10, 20, 30);

            Assert.AreEqual(10, _instanceList.GoIndex(0));
            Assert.AreEqual(20, _instanceList.GoIndex(1));
            Assert.AreEqual(30, _instanceList.GoIndex(2));
            Assert.AreEqual(3, _instanceList.attLength);
        }
        [Test]
        public void ToRetrieve()
        {
            AddItems(10);
            int result = 0;
            _instanceList.toRetrieve(0, ref result);

            Assert.AreEqual(10, result);
            Assert.AreEqual(1, _instanceList.attLength);
        }
        [Test]
        public void ToRemoveByIdx()
        {
            AddItems(10, 15, 20);

            int refResult = 0;

            _instanceList.toRemoveByIndex(0, ref refResult);
            Assert.AreEqual(10, refResult);
            Assert.AreEqual(2, _instanceList.attLength);

            _instanceList.toRemoveByIndex(1, ref refResult);
            Assert.AreEqual(1, _instanceList.attLength);
            Assert.AreEqual(20, refResult);
        }
        [Test]
        public void ToRemove()
        {
            AddItems(10, 12, 13);

            _instanceList.toRemove(12);
            Assert.AreEqual(2, _instanceList.attLength);
            int resultGo = _instanceList.GoIndex(1);
            Assert.AreEqual(13, resultGo);

            _instanceList.toRemove(10);
            Assert.AreEqual(1, _instanceList.attLength);
            resultGo = _instanceList.GoIndex(0);
            Assert.AreEqual(13, resultGo);

            _instanceList.toRemove(13);
            Assert.AreEqual(0, _instanceList.attLength);
        }
        [Test]
        public void ToModify()
        {
            _instanceList.toAdd(1);
            _instanceList.toModify(0, 2);

            int resultValue = _instanceList.GoIndex(0);

            Assert.AreEqual(2, resultValue);
            Assert.AreEqual(1, _instanceList.attLength);
        }
        #endregion

        #region Utilities
        [Test]
        public void toCrearArray()
        {
            AddItems(10, 20, 30);
            _instanceList.toClear();
            Assert.AreEqual(0, _instanceList.attLength);
        }
        [Test]
        public void toReverse()
        {
            AddItems(10, 20, 30);
            _instanceList.toReverse();
            Assert.AreEqual(30, _instanceList.GoIndex(0));
            Assert.AreEqual(20, _instanceList.GoIndex(1));
            Assert.AreEqual(10, _instanceList.GoIndex(2));
        }
        [Test]
        public void toSort()
        {
            AddItems(30, 10, 20);
            _instanceList.toSort();
            Assert.AreEqual(10, _instanceList.GoIndex(0));
            Assert.AreEqual(20, _instanceList.GoIndex(1));
            Assert.AreEqual(30, _instanceList.GoIndex(2));
        }


        #endregion

        #region Exceptions
        [Test]
        public void ArgumentOutOfRangeException()
        {
            _instanceList.toAdd(10);
            Assert.Throws<ArgumentOutOfRangeException>(() => _instanceList.GoIndex(5));
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