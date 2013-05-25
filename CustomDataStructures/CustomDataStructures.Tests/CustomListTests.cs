using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomDataStructures.Tests
{
    [TestClass]
    public class CustomListTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            CustomList<int> list = new CustomList<int>();

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(4, list.Capacity);
        }

        [TestMethod]
        public void TestParamsConstructor()
        {
            CustomList<int> list = new CustomList<int>(10);

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(10, list.Capacity);
        }

        [TestMethod]
        public void TestAdd_OneItem()
        {
            CustomList<int> list = new CustomList<int>();

            list.Add(1);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void TestAdd_50Items()
        {
            CustomList<int> list = new CustomList<int>();

            int listCount = 50;
            for (int i = 0; i < listCount; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(0, list[0]);
            Assert.AreEqual(49, list[49]);
            Assert.AreEqual(50, list.Count);
            Assert.AreEqual(64, list.Capacity);
        }

        [TestMethod]
        public void TestAdd_ResizeFunctionality()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(1);
            list.Add(1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(4, list.Capacity);
        }

        [TestMethod]
        public void TestIndexOf_MustReturnMinus1()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.AreEqual(-1, list.IndexOf(5));
        }

        [TestMethod]
        public void TestIndexOf_MustReturn0()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.AreEqual(0, list.IndexOf(1));
        }

        [TestMethod]
        public void TestIndexOf_MustReturn3()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.AreEqual(3, list.IndexOf(4));
        }

        [TestMethod]
        public void TestIndexOf_MustReturn1()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.AreEqual(1, list.IndexOf(2));
        }

        [TestMethod]
        public void TestInsert_AtTheBegining()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Insert(0, 5);

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(8, list.Capacity);
            Assert.AreEqual(5, list[0]);
            Assert.AreEqual(1, list[1]);
            Assert.AreEqual(4, list[4]);
        }

        [TestMethod]
        public void TestInsert_AtTheEnd()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Insert(3, 5);

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(8, list.Capacity);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(5, list[3]);
            Assert.AreEqual(4, list[4]);
        }

        [TestMethod]
        public void TestInsert_AtRandomIndex()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Insert(1, 5);

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(8, list.Capacity);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(5, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(3, list[3]);
            Assert.AreEqual(4, list[4]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestInsert_ListIsEmpty()
        {
            CustomList<int> list = new CustomList<int>();
            list.Insert(1, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestInsert_CountEqualsOne()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);

            list.Insert(0, 5);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(5, list[0]);
            Assert.AreEqual(1, list[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestInsert_NegativeIndex()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Insert(-1, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestInsert_TooBigIndex()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Insert(4, 5);
        }

        [TestMethod]
        public void TestRemoveAt_Begining()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.RemoveAt(0);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(4, list[2]);
            Assert.AreEqual(4, list.Capacity);
        }

        [TestMethod]
        public void TestRemoveAt_End()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.RemoveAt(3);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(4, list.Capacity);
        }

        [TestMethod]
        public void TestRemoveAt_RandomIndex()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.RemoveAt(2);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(4, list[2]);
            Assert.AreEqual(5, list[3]);
            Assert.AreEqual(8, list.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestRemoveAt_NegativeIndex()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestRemoveAt_TooBigIndex()
        {
            CustomList<int> list = new CustomList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.RemoveAt(4);
        }

        [TestMethod]
        public void TestIndexator_GetItem()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(4, list[3]);
        }

        [TestMethod]
        public void TestIndexator_SetItem()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list[3] = 5;

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(5, list[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator_GetItem_NegativeIndex()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int num = list[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator_SetItem_NegativeIndex()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list[-1] = 5;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator_LargerIndex()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int num = list[4];
        }

        [TestMethod]
        public void TestClear()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);

            list.Clear();

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(4, list.Capacity);
        }

        [TestMethod]
        public void TestContains_MustReturnTrue()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.IsTrue(list.Contains(3));
        }

        [TestMethod]
        public void TestContains_MustReturnFalse()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.IsFalse(list.Contains(5));
        }

        [TestMethod]
        public void TestCopyTo()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int[] arr = new int[4];
            list.CopyTo(arr, 0);

            Assert.AreEqual(arr[0], list[0]);
            Assert.AreEqual(arr[1], list[1]);
            Assert.AreEqual(arr[2], list[2]);
            Assert.AreEqual(arr[3], list[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCopyTo_NullArray()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int[] arr = null;
            list.CopyTo(arr, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestCopyTo_NegativeIndex()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int[] arr = new int[4];
            list.CopyTo(arr, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestCopyTo_ArrayIsTooSmall()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int[] arr = new int[3];
            list.CopyTo(arr, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestCopyTo_InvalidIndex()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int[] arr = new int[5];
            list.CopyTo(arr, 2);
        }

        [TestMethod]
        public void TestRemove_FirstItem()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            bool isRemoved = list.Remove(1);

            Assert.AreEqual(true, isRemoved);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(4, list[2]);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestRemove_LastItem()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            bool isRemoved = list.Remove(4);

            Assert.AreEqual(true, isRemoved);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestRemove_MiddleItem()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            bool isRemoved = list.Remove(2);

            Assert.AreEqual(true, isRemoved);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(4, list[2]);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestForeachLoop()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            string expected = "12345";
            StringBuilder actual = new StringBuilder();

            foreach (var item in list)
            {
                actual.Append(item.ToString());
            }

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
