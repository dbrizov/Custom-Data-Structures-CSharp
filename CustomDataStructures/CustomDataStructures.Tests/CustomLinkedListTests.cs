using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomDataStructures.Tests
{
    [TestClass]
    public class CustomLinkedListTests
    {
        [TestMethod]
        public void TestAddLast()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
        }

        [TestMethod]
        public void TestAddFirst()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(3, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(1, list[2]);
        }

        [TestMethod]
        public void TestIndexator_GetItem()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator_GetItem_NegativeIndex()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);

            Assert.AreEqual(1, list[-1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator_GetItem_TooLargeIndex()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);

            Assert.AreEqual(1, list[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator_GetItem_EmptyList()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            Assert.AreEqual(1, list[0]);
        }

        [TestMethod]
        public void TestIndexator_SetItem()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list[0] = 4;
            list[1] = 5;
            list[2] = 6;

            Assert.AreEqual(4, list[0]);
            Assert.AreEqual(5, list[1]);
            Assert.AreEqual(6, list[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator_SetItem_NegativeIndex()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list[-1] = 5;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator_SetItem_TooLargeIndex()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list[1] = 5;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator_SetItem_EmptyList()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list[0] = 5;
        }

        [TestMethod]
        public void TestIndexOf_Found_MustReturn0()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.AreEqual(0, list.IndexOf(1));
        }

        [TestMethod]
        public void TestIndexOf_Found_MustReturn1()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.AreEqual(1, list.IndexOf(2));
        }

        [TestMethod]
        public void TestIndexOf_Found_MustReturn2()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.AreEqual(2, list.IndexOf(3));
        }

        [TestMethod]
        public void TestIndexOf_NotFound()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.AreEqual(-1, list.IndexOf(4));
        }

        [TestMethod]
        public void TestIndexOf_EmptyList()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            Assert.AreEqual(-1, list.IndexOf(0));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestInsert_TheListIsEmpty()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Insert(0, 2);
        }

        [TestMethod]
        public void TestInsert_MultipleItems()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list.Insert(0, 5);
            list.Insert(list.Count - 1, 10);
            list.Insert(2, 15);

            Assert.AreEqual(6, list.Count);
            Assert.AreEqual(5, list[0]);
            Assert.AreEqual(1, list[1]);
            Assert.AreEqual(15, list[2]);
            Assert.AreEqual(2, list[3]);
            Assert.AreEqual(10, list[4]);
            Assert.AreEqual(3, list[5]);
        }

        [TestMethod]
        public void TestInsert_AtZeroIndex()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(2);

            list.Insert(0, 1);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
        }

        [TestMethod]
        public void TestInsert_AtLastIndex()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list.Insert(2, 4);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(4, list[2]);
            Assert.AreEqual(3, list[3]);
        }

        [TestMethod]
        public void TestInsert_AtRandomMiddleIndex1()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);

            list.Insert(1, 5);

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(5, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(3, list[3]);
            Assert.AreEqual(4, list[4]);
        }

        [TestMethod]
        public void TestInsert_AtRandomMiddleIndex2()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);

            list.Insert(2, 5);

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(5, list[2]);
            Assert.AreEqual(3, list[3]);
            Assert.AreEqual(4, list[4]);
        }

        [TestMethod]
        public void TestRemove_ListIsEmpty()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            bool removed = list.Remove(0);
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void TestRemove_MustReturnTrue()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);

            bool removed = list.Remove(3);

            Assert.IsTrue(removed);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(4, list[2]);
        }

        [TestMethod]
        public void TestRemove_MultipleItems()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            bool removed1 = list.Remove(1);
            bool removed2 = list.Remove(3);
            bool removed3 = list.Remove(5);

            Assert.IsTrue(removed1);
            Assert.IsTrue(removed2);
            Assert.IsTrue(removed3);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(4, list[1]);
        }

        [TestMethod]
        public void TestRemove_MustReturnFalse()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);

            bool removed = list.Remove(5);

            Assert.IsFalse(removed);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(4, list[3]);
        }

        [TestMethod]
        public void TestRemove_First_TwoTimes()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            bool removed1 = list.Remove(1);
            bool removed2 = list.Remove(2);

            Assert.IsTrue(removed1);
            Assert.IsTrue(removed2);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(3, list[0]);
            Assert.AreEqual(4, list[1]);
            Assert.AreEqual(5, list[2]);
        }

        [TestMethod]
        public void TestRemove_Last_TwoTimes()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            bool removed1 = list.Remove(5);
            bool removed2 = list.Remove(4);

            Assert.IsTrue(removed1);
            Assert.IsTrue(removed2);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
        }

        [TestMethod]
        public void TestRemoveAt_FirstIndex_OneTime()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);

            list.RemoveAt(0);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(4, list[2]);
        }

        [TestMethod]
        public void TestRemoveAt_FirstIndex_TwoTime()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            list.RemoveAt(0);
            list.RemoveAt(0);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(3, list[0]);
            Assert.AreEqual(4, list[1]);
            Assert.AreEqual(5, list[2]);
        }

        [TestMethod]
        public void TestRemoveAt_LastIndex_OneTime()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);

            list.RemoveAt(3);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
        }

        [TestMethod]
        public void TestRemoveAt_LastIndex_TwoTimes()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            list.RemoveAt(4);
            list.RemoveAt(3);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
        }

        [TestMethod]
        public void TestRemoveAt_RandomMiddleIndex_OneTime()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);

            list.RemoveAt(1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(4, list[2]);
        }

        [TestMethod]
        public void TestRemoveAt_RandomMiddleIndex_TwoTimes()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            list.RemoveAt(2);
            list.RemoveAt(2);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(5, list[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestRemoveAt_ListIsEmpty()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.RemoveAt(0);
        }

        [TestMethod]
        public void TestRemoveAt_ListHasOnlyOneItem()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Add(1);

            list.RemoveAt(0);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestRemoveAt_MultipleItems()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.RemoveAt(0);
            list.RemoveAt(1);
            list.RemoveAt(list.Count - 1);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(4, list[1]);
        }

        [TestMethod]
        public void TestRemoveFirst_CalledOneTime()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.RemoveFirst();

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(4, list[2]);
            Assert.AreEqual(5, list[3]);
        }

        [TestMethod]
        public void TestRemoveFirst_AllItemsAreRemoved()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);


            for (int i = 0; i < 5; i++)
            {
                list.RemoveFirst();
            }

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestRemoveLast_CalledOneTime()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.RemoveLast();

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(4, list[3]);
        }

        [TestMethod]
        public void TestRemoveLast_AllItemsAreRemoved()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);


            for (int i = 0; i < 5; i++)
            {
                list.RemoveLast();
            }

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestClear()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            int listCount = 20;
            for (int i = 0; i < listCount; i++)
            {
                list.AddLast(i);
            }

            list.Clear();
            list.AddLast(1);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(1, list[0]);
        }

        [TestMethod]
        public void TestContains()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Contains(3));
            Assert.IsFalse(list.Contains(4));
            Assert.IsFalse(list.Contains(5));
        }

        //
        [TestMethod]
        public void TestCopyTo()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
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
            CustomLinkedList<int> list = new CustomLinkedList<int>();
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
            CustomLinkedList<int> list = new CustomLinkedList<int>();
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
            CustomLinkedList<int> list = new CustomLinkedList<int>();
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
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int[] arr = new int[5];
            list.CopyTo(arr, 2);
        }

        [TestMethod]
        public void TestRandomMethods()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Add(1);
            list.Add(2); // list = 1, 2

            list.Clear(); // list = null(empty)

            list.AddLast(3);
            list.AddLast(4);
            list.AddFirst(5);
            list.AddFirst(1);
            list.AddFirst(2); // list = 21534

            list.RemoveFirst();
            list.RemoveLast();
            list.RemoveAt(1);
            list.Remove(1); // list = 3

            list.Insert(0, 1); // list = 1, 3

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
        }

        [TestMethod]
        public void TestForeachLoop()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            int listCount = 5;
            for (int i = 0; i < listCount; i++)
            {
                list.AddLast(i);
            }

            string expected = "01234";
            StringBuilder actual = new StringBuilder();
            foreach (var item in list)
            {
                actual.Append(item.ToString());
            }

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
