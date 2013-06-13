using System;
using System.Collections.Generic;

namespace CustomDataStructures
{
    // A PriorityQueue implemented with Max-Binary-Heap
    public class PriorityQueue<T> where T : IComparable
    {
        private const int INITIAL_CAPACITY = 16;

        private T[] arr;
        private int lastItemIndex;

        public PriorityQueue()
            : this(INITIAL_CAPACITY)
        {
        }

        public PriorityQueue(int capacity)
        {
            this.arr = new T[capacity];
            lastItemIndex = -1;
        }

        public int Count
        {
            get
            {
                return this.lastItemIndex + 1;
            }
        }

        public void Enqueue(T item)
        {
            if (this.lastItemIndex == this.arr.Length - 1)
            {
                this.Resize();
            }

            this.lastItemIndex++;
            this.arr[lastItemIndex] = item;

            this.MaxHeapifyUp(lastItemIndex);
        }

        public T Dequeue()
        {
            T dequeuedItem = this.arr[0];
            this.arr[0] = this.arr[lastItemIndex];
            lastItemIndex--;

            this.MaxHeapifyDown(0);

            return dequeuedItem;
        }

        public void Clear()
        {
            this.lastItemIndex = -1;
        }

        private void MaxHeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int childIndex = index;
            int parentIndex = (index - 1) / 2;

            if (this.arr[childIndex].CompareTo(this.arr[parentIndex]) > 0)
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
                this.arr[leftChildIndex].CompareTo(this.arr[largestItemIndex]) > 0)
            {
                largestItemIndex = leftChildIndex;
            }

            if (rightChildIndex <= this.lastItemIndex &&
                this.arr[rightChildIndex].CompareTo(this.arr[largestItemIndex]) > 0)
            {
                largestItemIndex = rightChildIndex;
            }

            if (largestItemIndex != index)
            {
                // swap the parent with the largest of the child items
                T temp = this.arr[index];
                this.arr[index] = this.arr[largestItemIndex];
                this.arr[largestItemIndex] = temp;

                MaxHeapifyDown(largestItemIndex);
            }
        }

        private void Resize()
        {
            T[] newArr = new T[this.arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = this.arr[i];
            }

            this.arr = newArr;
        }
    }
}
