using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;

namespace CustomDataStructures.Tests
{
    [TestClass]
    public class MaxHeapTests
    {
        [TestMethod]
        public void TestPush_OneItem()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();
            maxHeap.Push(1);

            Assert.AreEqual(1, maxHeap.Count);
        }

        [TestMethod]
        public void TestPush_100Item()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();
            int items = 100;
            for (int i = 0; i < items; i++)
            {
                maxHeap.Push(i);
            }

            Assert.AreEqual(100, maxHeap.Count);
        }

        [TestMethod]
        [Timeout(2000)]
        public void TestPush_Performace_WorstCase()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();
            int items = 500000;
            for (int i = 0; i < items; i++)
            {
                maxHeap.Push(i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPop_EmptyHeap()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();
            maxHeap.Pop();
        }

        [TestMethod]
        public void TestPop_TenItems()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();
            int items = 10;
            maxHeap.Push(10);
            maxHeap.Push(1);
            maxHeap.Push(9);
            maxHeap.Push(2);
            maxHeap.Push(8);
            maxHeap.Push(3);
            maxHeap.Push(7);
            maxHeap.Push(4);
            maxHeap.Push(6);
            maxHeap.Push(5);

            string actual = GetString(maxHeap);
            string expected = "10987654321";

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void TestPop_EqualItems()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();
            int items = 11;
            for (int i = 0; i < items - 1; i++)
            {
                maxHeap.Push(1);
            }

            maxHeap.Push(2);

            string actual = GetString(maxHeap);
            string expected = "21111111111";

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void TestPop_RandomItems()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();

            int itemsCount = 10000;
            int[] items = new int[itemsCount];
            Random random = new Random();

            for (int i = 0; i < itemsCount; i++)
            {
                int randomNumber = random.Next(50000);
                items[i] = randomNumber;
                maxHeap.Push(randomNumber);
            }

            Assert.AreEqual(itemsCount, maxHeap.Count);

            Array.Sort(items, (x, y) =>
            {
                return y.CompareTo(x);
            });

            for (int i = 0; i < itemsCount; i++)
            {
                Assert.AreEqual(items[i], maxHeap.Pop());
            }

            Assert.AreEqual(0, maxHeap.Count);
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestPop_Performace()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();
            int items = 500000;
            for (int i = items; i > 0; i--)
            {
                maxHeap.Push(i);
            }

            for (int i = 0; i < items; i++)
            {
                maxHeap.Pop();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPeek_EmptyHeap()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();
            maxHeap.Peek();
        }

        [TestMethod]
        public void TestPeek_NonEmptyHeap()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();
            maxHeap.Push(5);
            maxHeap.Push(90);
            maxHeap.Push(15);
            maxHeap.Push(89);

            Assert.AreEqual(90, maxHeap.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestClear()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();
            for (int i = 0; i < 100; i++)
            {
                maxHeap.Push(i);
            }

            maxHeap.Clear();
            Assert.AreEqual(0, maxHeap.Count);
            maxHeap.Peek();

            maxHeap.Push(90);
            maxHeap.Push(5);
            maxHeap.Push(15);
            maxHeap.Push(89);

            Assert.AreEqual(4, maxHeap.Count);
            Assert.AreEqual(90, maxHeap.Peek());
        }

        [TestMethod]
        public void TestRemove()
        {
            MinHeap<int> maxHeap = GetHeap();
            maxHeap.Remove(1);
            Assert.AreEqual("98765432", GetString(maxHeap));

            maxHeap = GetHeap();
            maxHeap.Remove(2);
            Assert.AreEqual("98765431", GetString(maxHeap));

            maxHeap = GetHeap();
            maxHeap.Remove(3);
            Assert.AreEqual("98765421", GetString(maxHeap));

            maxHeap = GetHeap();
            maxHeap.Remove(4);
            Assert.AreEqual("98765321", GetString(maxHeap));

            maxHeap = GetHeap();
            maxHeap.Remove(5);
            Assert.AreEqual("98764321", GetString(maxHeap));

            maxHeap = GetHeap();
            maxHeap.Remove(6);
            Assert.AreEqual("98754321", GetString(maxHeap));

            maxHeap = GetHeap();
            maxHeap.Remove(7);
            Assert.AreEqual("98654321", GetString(maxHeap));

            maxHeap = GetHeap();
            maxHeap.Remove(8);
            Assert.AreEqual("97654321", GetString(maxHeap));

            maxHeap = GetHeap();
            maxHeap.Remove(9);
            Assert.AreEqual("87654321", GetString(maxHeap));

            maxHeap = GetHeap();
            maxHeap.Remove(10);
            Assert.AreEqual("987654321", GetString(maxHeap));
        }

        private MinHeap<int> GetHeap()
        {
            MinHeap<int> maxHeap = CreateMaxHeap();
            maxHeap.Push(1);
            maxHeap.Push(9);
            maxHeap.Push(2);
            maxHeap.Push(8);
            maxHeap.Push(3);
            maxHeap.Push(7);
            maxHeap.Push(4);
            maxHeap.Push(6);
            maxHeap.Push(5);

            return maxHeap;
        }

        private MinHeap<int> CreateMaxHeap()
        {
            MinHeap<int> maxHeap = new MinHeap<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            return maxHeap;
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
