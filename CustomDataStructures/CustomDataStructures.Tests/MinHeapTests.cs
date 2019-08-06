using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;

namespace CustomDataStructures.Tests
{
    [TestClass]
    public class MinHeapTests
    {
        [TestMethod]
        public void TestPush_OneItem()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Push(1);

            Assert.AreEqual(1, minHeap.Count);
        }

        [TestMethod]
        public void TestPush_100Item()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 100;
            for (int i = 0; i < items; i++)
            {
                minHeap.Push(i);
            }

            Assert.AreEqual(100, minHeap.Count);
        }

        [TestMethod]
        [Timeout(2000)]
        public void TestPush_Performace_WorstCase()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 500000;
            for (int i = items; i >= 1; i--)
            {
                minHeap.Push(i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPop_EmptyHeap()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Pop();
        }

        [TestMethod]
        public void TestPop_TenItems()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 10;
            minHeap.Push(10);
            minHeap.Push(1);
            minHeap.Push(9);
            minHeap.Push(2);
            minHeap.Push(8);
            minHeap.Push(3);
            minHeap.Push(7);
            minHeap.Push(4);
            minHeap.Push(6);
            minHeap.Push(5);

            string actual = GetString(minHeap);
            string expected = "12345678910";

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void TestPop_EqualItems()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 15;
            for (int i = 0; i < items - 5; i++)
            {
                minHeap.Push(1);
            }

            minHeap.Push(2);
            minHeap.Push(0);
            minHeap.Push(0);
            minHeap.Push(3);
            minHeap.Push(3);

            string actual = GetString(minHeap);
            string expected = "001111111111233";

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void TestPop_RandomItems()
        {
            MinHeap<int> minHeap = new MinHeap<int>();

            int itemsCount = 10000;
            int[] items = new int[itemsCount];
            Random random = new Random();

            for (int i = 0; i < itemsCount; i++)
            {
                int randomNumber = random.Next(50000);
                items[i] = randomNumber;
                minHeap.Push(randomNumber);
            }

            Assert.AreEqual(itemsCount, minHeap.Count);

            Array.Sort(items);
            for (int i = 0; i < itemsCount; i++)
            {
                Assert.AreEqual(items[i], minHeap.Pop());
            }

            Assert.AreEqual(0, minHeap.Count);
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestPop_Performace()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 500000;
            for (int i = 0; i < items; i++)
            {
                minHeap.Push(i);
            }

            for (int i = 0; i < items; i++)
            {
                minHeap.Pop();
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
            minHeap.Push(90);
            minHeap.Push(5);
            minHeap.Push(15);
            minHeap.Push(89);

            Assert.AreEqual(5, minHeap.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestClear()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            for (int i = 0; i < 100; i++)
            {
                minHeap.Push(i);
            }

            minHeap.Clear();
            Assert.AreEqual(0, minHeap.Count);
            minHeap.Peek();

            minHeap.Push(90);
            minHeap.Push(5);
            minHeap.Push(15);
            minHeap.Push(89);

            Assert.AreEqual(4, minHeap.Count);
            Assert.AreEqual(5, minHeap.Peek());
        }

        [TestMethod]
        public void TestRemove()
        {
            MinHeap<int> minHeap = GetHeap();
            minHeap.Remove(1);
            Assert.AreEqual("23456789", GetString(minHeap));

            minHeap = GetHeap();
            minHeap.Remove(2);
            Assert.AreEqual("13456789", GetString(minHeap));

            minHeap = GetHeap();
            minHeap.Remove(3);
            Assert.AreEqual("12456789", GetString(minHeap));

            minHeap = GetHeap();
            minHeap.Remove(4);
            Assert.AreEqual("12356789", GetString(minHeap));

            minHeap = GetHeap();
            minHeap.Remove(5);
            Assert.AreEqual("12346789", GetString(minHeap));

            minHeap = GetHeap();
            minHeap.Remove(6);
            Assert.AreEqual("12345789", GetString(minHeap));

            minHeap = GetHeap();
            minHeap.Remove(7);
            Assert.AreEqual("12345689", GetString(minHeap));

            minHeap = GetHeap();
            minHeap.Remove(8);
            Assert.AreEqual("12345679", GetString(minHeap));

            minHeap = GetHeap();
            minHeap.Remove(9);
            Assert.AreEqual("12345678", GetString(minHeap));

            minHeap = GetHeap();
            minHeap.Remove(10);
            Assert.AreEqual("123456789", GetString(minHeap));
        }

        private MinHeap<int> GetHeap()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Push(1);
            minHeap.Push(9);
            minHeap.Push(2);
            minHeap.Push(8);
            minHeap.Push(3);
            minHeap.Push(7);
            minHeap.Push(4);
            minHeap.Push(6);
            minHeap.Push(5);

            return minHeap;
        }

        private string GetString(MinHeap<int> heap)
        {
            StringBuilder str = new StringBuilder();
            while (heap.Count > 0)
            {
                str.Append(heap.Pop());
            }

            return str.ToString();
        }
    }
}
