using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;

namespace CustomDataStructures.Tests
{
    public class ReverseIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    [TestClass]
    public class MinHeapTests
    {
        [TestMethod]
        public void TestAdd_OneItem()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Add(1);

            Assert.AreEqual(1, minHeap.Count);
        }

        [TestMethod]
        public void TestAdd_100Item()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 100;
            for (int i = 0; i < items; i++)
            {
                minHeap.Add(i);
            }

            Assert.AreEqual(100, minHeap.Count);
        }

        [TestMethod]
        [Timeout(2000)]
        public void TestAdd_Performace_WorstCase()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 500000;
            for (int i = items; i >= 1; i--)
            {
                minHeap.Add(i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemove_EmptyHeap()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Remove();
        }

        [TestMethod]
        public void TestRemove_TenItems()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 10;
            minHeap.Add(10);
            minHeap.Add(1);
            minHeap.Add(9);
            minHeap.Add(2);
            minHeap.Add(8);
            minHeap.Add(3);
            minHeap.Add(7);
            minHeap.Add(4);
            minHeap.Add(6);
            minHeap.Add(5);

            StringBuilder actual = new StringBuilder();
            for (int i = 0; i < items; i++)
            {
                actual.Append(minHeap.Remove());
            }

            string expected = "12345678910";

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void TestRemove_EqualItems()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 15;
            for (int i = 0; i < items - 5; i++)
            {
                minHeap.Add(1);
            }

            minHeap.Add(2);
            minHeap.Add(0);
            minHeap.Add(0);
            minHeap.Add(3);
            minHeap.Add(3);

            StringBuilder actual = new StringBuilder();
            for (int i = 0; i < items; i++)
            {
                actual.Append(minHeap.Remove());
            }

            string expected = "001111111111233";

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void TestRemove_RandomItems()
        {
            MinHeap<int> minHeap = new MinHeap<int>();

            int itemsCount = 10000;
            int[] items = new int[itemsCount];
            Random random = new Random();

            for (int i = 0; i < itemsCount; i++)
            {
                int randomNumber = random.Next(50000);
                items[i] = randomNumber;
                minHeap.Add(randomNumber);
            }

            Assert.AreEqual(itemsCount, minHeap.Count);

            Array.Sort(items);
            for (int i = 0; i < itemsCount; i++)
            {
                Assert.AreEqual(items[i], minHeap.Remove());
            }

            Assert.AreEqual(0, minHeap.Count);
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestRemove_Performace()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 500000;
            for (int i = 0; i < items; i++)
            {
                minHeap.Add(i);
            }

            for (int i = 0; i < items; i++)
            {
                minHeap.Remove();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPeek_EmptyHeap()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Peek();
        }

        [TestMethod]
        public void TestPeek_NonEmptyHeap()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Add(90);
            minHeap.Add(5);
            minHeap.Add(15);
            minHeap.Add(89);

            Assert.AreEqual(5, minHeap.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestClear()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            for (int i = 0; i < 100; i++)
            {
                minHeap.Add(i);
            }

            minHeap.Clear();
            Assert.AreEqual(0, minHeap.Count);
            minHeap.Peek();

            minHeap.Add(90);
            minHeap.Add(5);
            minHeap.Add(15);
            minHeap.Add(89);

            Assert.AreEqual(4, minHeap.Count);
            Assert.AreEqual(5, minHeap.Peek());
        }

        [TestMethod]
        public void TestComparer()
        {
            MinHeap<int> minHeap = new MinHeap<int>(new ReverseIntComparer());
            int items = 10;
            minHeap.Add(10);
            minHeap.Add(1);
            minHeap.Add(9);
            minHeap.Add(2);
            minHeap.Add(8);
            minHeap.Add(3);
            minHeap.Add(7);
            minHeap.Add(4);
            minHeap.Add(6);
            minHeap.Add(5);

            StringBuilder actual = new StringBuilder();
            for (int i = 0; i < items; i++)
            {
                actual.Append(minHeap.Remove());
            }

            string expected = "10987654321";

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
