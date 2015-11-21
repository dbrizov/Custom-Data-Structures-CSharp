using System;
using System.Collections.Generic;

namespace CustomDataStructures
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private const int INITIAL_CAPACITY = 16;

        private T[] arr;
        private int lastItemIndex;
        private IComparer<T> comparer;

        public MaxHeap()
            : this(INITIAL_CAPACITY, Comparer<T>.Default)
        {
        }

        public MaxHeap(int capacity)
            : this(capacity, Comparer<T>.Default)
        {
        }

        public MaxHeap(IComparer<T> comparer)
            : this(INITIAL_CAPACITY, comparer)
        {
        }

        public MaxHeap(int capacity, IComparer<T> comparer)
        {
            this.arr = new T[capacity];
            this.lastItemIndex = -1;
            this.comparer = comparer;
        }

        public int Count
        {
            get
            {
                return this.lastItemIndex + 1;
            }
        }

        public void Add(T item)
        {
            if (this.lastItemIndex == this.arr.Length - 1)
            {
                this.Resize();
            }

            this.lastItemIndex++;
            this.arr[this.lastItemIndex] = item;

            this.MaxHeapifyUp(this.lastItemIndex);
        }

        public T Remove()
        {
            if (this.lastItemIndex == -1)
            {
                throw new InvalidOperationException("The heap is empty");
            }

            T removedItem = this.arr[0];
            this.arr[0] = this.arr[this.lastItemIndex];
            this.lastItemIndex--;

            this.MaxHeapifyDown(0);

            return removedItem;
        }

        public T Peek()
        {
            if (this.lastItemIndex == -1)
            {
                throw new InvalidOperationException("The heap is empty");
            }

            return this.arr[0];
        }

        public void Clear()
        {
            this.lastItemIndex = -1;
            this.arr = new T[INITIAL_CAPACITY];
        }

        private void MaxHeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int childIndex = index;
            int parentIndex = (index - 1) / 2;

            if (this.comparer.Compare(this.arr[childIndex], this.arr[parentIndex]) > 0)
            {
                // swap the parent and the child
                T temp = this.arr[childIndex];
                this.arr[childIndex] = this.arr[parentIndex];
                this.arr[parentIndex] = temp;

                this.MaxHeapifyUp(parentIndex);
            }
        }

        private void MaxHeapifyDown(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int largestItemIndex = index; // The index of the parent

            if (leftChildIndex <= this.lastItemIndex &&
                this.comparer.Compare(this.arr[leftChildIndex], this.arr[largestItemIndex]) > 0)
            {
                largestItemIndex = leftChildIndex;
            }

            if (rightChildIndex <= this.lastItemIndex &&
                this.comparer.Compare(this.arr[rightChildIndex], this.arr[largestItemIndex]) > 0)
            {
                largestItemIndex = rightChildIndex;
            }

            if (largestItemIndex != index)
            {
                // swap the parent with the largest of the child items
                T temp = this.arr[index];
                this.arr[index] = this.arr[largestItemIndex];
                this.arr[largestItemIndex] = temp;

                this.MaxHeapifyDown(largestItemIndex);
            }
        }

        private void Resize()
        {
            T[] newArr = new T[this.arr.Length * 2];
            for (int i = 0; i < this.arr.Length; i++)
            {
                newArr[i] = this.arr[i];
            }

            this.arr = newArr;
        }
    }
}
