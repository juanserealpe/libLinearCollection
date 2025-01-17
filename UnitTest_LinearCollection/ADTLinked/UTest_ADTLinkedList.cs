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

        #region CRUDs
        [Test]
        public void toAdd()
        {
            AddItems(1, 2, 3);
            Assert.AreEqual(3, _instanceLinkedList.GoLast());
        } 
        #endregion
    }
}