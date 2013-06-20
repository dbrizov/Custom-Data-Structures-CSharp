using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace CustomDataStructures.Tests
{
    [TestClass]
    public class MaxHeapTests
    {
        [TestMethod]
        public void TestAdd_OneItem()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            maxHeap.Add(1);

            Assert.AreEqual(1, maxHeap.Count);
        }

        [TestMethod]
        public void TestAdd_100Item()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            int items = 100;
            for (int i = 0; i < items; i++)
            {
                maxHeap.Add(i);
            }

            Assert.AreEqual(100, maxHeap.Count);
        }

        [TestMethod]
        [Timeout(2000)]
        public void TestAdd_Performace_WorstCase()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            int items = 500000;
            for (int i = 0; i < items; i++)
            {
                maxHeap.Add(i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemove_EmptyHeap()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            maxHeap.Remove();
        }

        [TestMethod]
        public void TestRemove_TenItems()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            int items = 10;
            maxHeap.Add(10);
            maxHeap.Add(1);
            maxHeap.Add(9);
            maxHeap.Add(2);
            maxHeap.Add(8);
            maxHeap.Add(3);
            maxHeap.Add(7);
            maxHeap.Add(4);
            maxHeap.Add(6);
            maxHeap.Add(5);

            StringBuilder actual = new StringBuilder();
            for (int i = 0; i < items; i++)
            {
                actual.Append(maxHeap.Remove());
            }

            string expected = "10987654321";

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void TestRemove_EqualItems()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            int items = 11;
            for (int i = 0; i < items - 1; i++)
            {
                maxHeap.Add(1);
            }

            maxHeap.Add(2);

            StringBuilder actual = new StringBuilder();
            for (int i = 0; i < items; i++)
            {
                actual.Append(maxHeap.Remove());
            }

            string expected = "21111111111";

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestRemove_Performace()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            int items = 500000;
            for (int i = 0; i < items; i++)
            {
                maxHeap.Add(i);
            }

            for (int i = 0; i < items; i++)
            {
                maxHeap.Remove();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPeek_EmptyHeap()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            maxHeap.Peek();
        }

        [TestMethod]
        public void TestPeek_NonEmptyHeap()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            maxHeap.Add(5);
            maxHeap.Add(90);
            maxHeap.Add(15);
            maxHeap.Add(89);

            Assert.AreEqual(90, maxHeap.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestClear()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            maxHeap.Add(1);
            maxHeap.Add(2);
            maxHeap.Add(3);

            maxHeap.Clear();
            Assert.AreEqual(0, maxHeap.Count);
            maxHeap.Peek();
        }
    }
}
