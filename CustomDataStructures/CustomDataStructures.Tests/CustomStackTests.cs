using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomDataStructures.Tests
{
    [TestClass]
    public class CustomStackTests
    {
        [TestMethod]
        public void TestPush_FiveItems()
        {
            CustomStack<int> stack = new CustomStack<int>();

            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(stackCount, stack.Count);
            Assert.AreEqual("43210", stack.ToString());
        }

        [TestMethod]
        public void TestPush_TenItems()
        {
            CustomStack<int> stack = new CustomStack<int>();

            int stackCount = 10;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(stackCount, stack.Count);
            Assert.AreEqual("9876543210", stack.ToString());
        }

        [TestMethod]
        public void TestPeek_NonEmptyStack()
        {
            CustomStack<int> stack = new CustomStack<int>();

            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(4, stack.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPeek_EmptyStack()
        {
            CustomStack<int> stack = new CustomStack<int>();

            Assert.AreEqual(4, stack.Peek());
        }

        [TestMethod]
        public void TestPop_OneItem()
        {
            CustomStack<int> stack = new CustomStack<int>();

            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            int popped = stack.Pop();
            Assert.AreEqual(4, popped);
            Assert.AreEqual(4, stack.Count);
            Assert.AreEqual("3210", stack.ToString());
        }

        [TestMethod]
        public void TestPop_MultipleItems()
        {
            CustomStack<int> stack = new CustomStack<int>();

            int stackCount = 10;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < 5; i++)
            {
                int popped = stack.Pop();
                Assert.AreEqual(9 - i, popped);
            }

            Assert.AreEqual(5, stack.Count);
            Assert.AreEqual("43210", stack.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPop_EmptyStack()
        {
            CustomStack<int> stack = new CustomStack<int>();

            Assert.AreEqual(4, stack.Pop());
        }

        [TestMethod]
        public void TestToString_NonEmptyStack()
        {
            CustomStack<int> stack = new CustomStack<int>();
            int stackCount = 10;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual("9876543210", stack.ToString());
        }

        [TestMethod]
        public void TestToString_EmptyStack()
        {
            CustomStack<int> stack = new CustomStack<int>();

            Assert.AreEqual(string.Empty, stack.ToString());
        }

        [TestMethod]
        public void TestToArray_EmptyStack()
        {
            CustomStack<int> stack = new CustomStack<int>();

            int[] arr = stack.ToArray();

            Assert.AreEqual(0, arr.Length);
        }

        [TestMethod]
        public void TestToArray_NonEmptyStack()
        {
            CustomStack<int> stack = new CustomStack<int>();

            int stackCount = 10;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            int[] arr = stack.ToArray();

            Assert.AreEqual(10, arr.Length);
            Assert.AreEqual("9876543210", string.Join(string.Empty, arr));
        }

        [TestMethod]
        public void TestClone_EmptyStack()
        {
            CustomStack<int> stack = new CustomStack<int>();
            CustomStack<int> clone = (CustomStack<int>)stack.Clone();

            int count = 5;
            for (int i = 0; i < count; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(5, stack.Count);
            Assert.AreEqual(0, clone.Count);
            Assert.AreEqual(string.Empty, clone.ToString());
        }

        [TestMethod]
        public void TestClone_NonEmptyStack()
        {
            CustomStack<int> stack = new CustomStack<int>();

            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            CustomStack<int> clone = (CustomStack<int>)stack.Clone();

            for (int i = 0; i < stackCount; i++)
            {
                stack.Pop();
            }

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(5, clone.Count);
            Assert.AreEqual("43210", clone.ToString());
        }

        [TestMethod]
        public void TestClear_EmptyStack()
        {
            CustomStack<int> stack = new CustomStack<int>();

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(string.Empty, stack.ToString());
        }

        [TestMethod]
        public void TestClear_NonEmptyStack()
        {
            CustomStack<int> stack = new CustomStack<int>();
            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(string.Empty, stack.ToString());
        }

        [TestMethod]
        public void TestForeachLoop_Enumerator()
        {
            CustomStack<int> stack = new CustomStack<int>();

            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            string expected = "43210";
            StringBuilder actual = new StringBuilder();

            foreach (var item in stack)
            {
                actual.Append(item.ToString());
            }

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
