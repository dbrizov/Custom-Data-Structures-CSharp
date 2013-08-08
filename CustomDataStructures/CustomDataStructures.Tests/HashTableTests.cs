using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace CustomDataStructures.Tests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void TestAdd_OneItem()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            int count = 1;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            Assert.AreEqual(1, hashTable.Count);
        }

        [TestMethod]
        public void TestAdd_50000Item()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            int count = 50000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            Assert.AreEqual(50000, hashTable.Count);
        }

        [TestMethod]
        public void TestAdd_Duplicates()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 1);
            hashTable.Add("asd", 10);

            Assert.AreEqual(1, hashTable.Count);
            Assert.AreEqual(10, hashTable.Find("asd"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAdd_NullKey()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add(null, 5);
        }

        [TestMethod]
        public void TestAdd_AutoResizeOnLoadOverflow()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            Assert.AreEqual(16, hashTable.Capacity);

            for (int i = 0; i < 13; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            Assert.AreEqual(32, hashTable.Capacity);
            Assert.AreEqual(13, hashTable.Count);
        }

        [TestMethod]
        public void TestTryGetValue_Success()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            int value;
            bool found = hashTable.TryGetValue("asd", out value);

            Assert.AreEqual(true, found);
            Assert.AreEqual(10, value);
        }

        [TestMethod]
        public void TestTryGetValue_Fail()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            int value;
            bool found = hashTable.TryGetValue("qwe", out value);

            Assert.AreEqual(false, found);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void TestFind_Success()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            int value = hashTable.Find("asd");

            Assert.AreEqual(10, value);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestFind_Fail()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            int value = hashTable.Find("qwe");
        }

        [TestMethod]
        public void TestRemove_Success()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            Assert.AreEqual(1001, hashTable.Count);

            bool removed = hashTable.Remove("asd");

            Assert.AreEqual(1000, hashTable.Count);
            Assert.AreEqual(false, hashTable.ContainsKey("asd"));
        }

        [TestMethod]
        public void TestRemove_Fail()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            Assert.AreEqual(1001, hashTable.Count);

            bool removed = hashTable.Remove("rty");

            Assert.AreEqual(1001, hashTable.Count);
            Assert.AreEqual(true, hashTable.ContainsKey("asd"));
        }

        [TestMethod]
        public void TestContainsKey_True()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            Assert.AreEqual(true, hashTable.ContainsKey("asd"));
        }

        [TestMethod]
        public void TestContainsKey_False()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            Assert.AreEqual(false, hashTable.ContainsKey("qwe"));
        }

        [TestMethod]
        public void TestClear()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);
            hashTable.Add("qwe", 11);
            hashTable.Add("rty", 12);
            hashTable.Add("fgh", 13);

            hashTable.Clear();

            Assert.AreEqual(0, hashTable.Count);
            Assert.AreEqual(16, hashTable.Capacity);
        }

        [TestMethod]
        public void TestIndexator_Get_Success()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            int value = hashTable["asd"];

            Assert.AreEqual(10, value);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestIndexator_Get_Fail()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            int value = hashTable["qwe"];
        }

        [TestMethod]
        public void TestIndexator_Set_Success()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }
            Assert.AreEqual(10, hashTable["asd"]);

            hashTable["asd"] = 20;
            Assert.AreEqual(20, hashTable["asd"]);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestIndexator_Set_Fail()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("asd", 10);

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }
            Assert.AreEqual(10, hashTable["asd"]);

            hashTable["qwe"] = 20;
        }

        [TestMethod]
        public void TestKeysProperty()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            string[] keys = hashTable.Keys;
            string expected = "0123456789";
            string actual = "";

            foreach (var key in keys)
            {
                actual += key;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetEnumerator()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                hashTable.Add(i.ToString(), i);
            }

            string expected = "[0, 0][1, 1][2, 2]";
            string actual = "";
            foreach (var item in hashTable)
            {
                actual += item;
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
