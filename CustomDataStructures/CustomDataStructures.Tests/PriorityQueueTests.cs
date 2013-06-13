using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace CustomDataStructures.Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void TestEnqueue_OneItem()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(1);

            Assert.AreEqual(1, priorityQueue.Count);
        }

        [TestMethod]
        public void TestEnqueue_100Item()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            int items = 100;
            for (int i = 0; i < items; i++)
            {
                priorityQueue.Enqueue(i);
            }

            Assert.AreEqual(100, priorityQueue.Count);
        }

        [TestMethod]
        [Timeout(2000)]
        public void TestEnqueue_Performace_WorstCase()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            int items = 500000;
            for (int i = 0; i < items; i++)
            {
                priorityQueue.Enqueue(i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestDequeue_EmptyQueue()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            priorityQueue.Dequeue();
        }

        [TestMethod]
        public void TestDequeue_TenItems()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            int items = 10;
            for (int i = 0; i < items; i++)
            {
                priorityQueue.Enqueue(i);
            }

            StringBuilder actual = new StringBuilder();
            for (int i = 0; i < items; i++)
            {
                actual.Append(priorityQueue.Dequeue());
            }

            string expected = "9876543210";

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestDequeue_Performace()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            int items = 500000;
            for (int i = 0; i < items; i++)
            {
                priorityQueue.Enqueue(i);
            }

            for (int i = 0; i < items; i++)
            {
                priorityQueue.Dequeue();
            }
        }
    }
}
