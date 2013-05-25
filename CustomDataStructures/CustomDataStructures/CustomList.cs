using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDataStructures
{
    public class CustomList<T> : IList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int count;
        private int capacity;

        public CustomList()
            : this(DefaultCapacity)
        {
        }

        public CustomList(int capacity)
        {
            this.items = new T[capacity];
            this.count = 0;
            this.capacity = capacity;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Invalid index: " + index);
                }

                return this.items[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Invalid index: " + index);
                }

                this.items[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(this.items, item, 0, this.Count);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            int itemsLength = this.items.Length;
            if (this.Count == itemsLength)
            {
                this.Resize();
            }

            T[] extendedItems = new T[this.Capacity];

            // copy in range [0, index - 1]
            for (int i = 0; i < index; i++)
            {
                extendedItems[i] = this.items[i];
            }

            extendedItems[index] = item;

            // copy in range [index, itemsLength - 1]
            for (int i = index + 1; i <= itemsLength; i++)
            {
                extendedItems[i] = this.items[i - 1];
            }

            this.items = extendedItems;
            this.count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            T[] itemsCopy = (T[])this.items.Clone();
            this.items = new T[itemsCopy.Length];

            // copy from [0, index - 1]
            for (int i = 0; i < index; i++)
            {
                this.items[i] = itemsCopy[i];
            }

            // copy from [index + 1, this.Count]
            for (int i = index + 1; i < this.Count; i++)
            {
                this.items[i - 1] = itemsCopy[i];
            }

            this.count--;
        }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.count++;
        }

        public void Clear()
        {
            this.items = new T[DefaultCapacity];
            this.count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array is null");
            }

            if (arrayIndex < 0 ||
                arrayIndex >= array.Length ||
                arrayIndex + this.Count - 1 >= array.Length)
            {
                throw new IndexOutOfRangeException("Invalid index: " + arrayIndex);
            }

            for (int i = 0; i < this.Count; i++)
            {
                array[arrayIndex + i] = this.items[i];
            }
        }

        public bool Remove(T item)
        {
            bool found = false;

            // Find the item
            int index = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    index = i;
                    found = true;
                    break;
                }
            }

            this.RemoveAt(index);
            return found;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            T[] itemsClone = (T[])this.items.Clone();
            this.items = new T[this.items.Length * 2];
            Array.Copy(itemsClone, this.items, itemsClone.Length);
            this.capacity *= 2;
        }
    }
}
