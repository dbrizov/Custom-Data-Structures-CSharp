using System;
using System.Collections.Generic;

namespace CustomDataStructures
{
    public class MaxHeap<T>
    {
        private const int InitialCapacity = 4;

        private T[] _arr;
        private int _lastItemIndex;
        private IComparer<T> _comparer;

        public MaxHeap()
            : this(InitialCapacity, Comparer<T>.Default)
        {
        }

        public MaxHeap(int capacity)
            : this(capacity, Comparer<T>.Default)
        {
        }

        public MaxHeap(IComparer<T> comparer)
            : this(InitialCapacity, comparer)
        {
        }

        public MaxHeap(int capacity, IComparer<T> comparer)
        {
            _arr = new T[capacity];
            _lastItemIndex = -1;
            _comparer = comparer;
        }

        public int Count
        {
            get
            {
                return _lastItemIndex + 1;
            }
        }

        public void Add(T item)
        {
            if (_lastItemIndex == _arr.Length - 1)
            {
                Resize();
            }

            _lastItemIndex++;
            _arr[_lastItemIndex] = item;

            MaxHeapifyUp(_lastItemIndex);
        }

        public T Remove()
        {
            if (_lastItemIndex == -1)
            {
                throw new InvalidOperationException("The heap is empty");
            }

            T removedItem = _arr[0];
            _arr[0] = _arr[_lastItemIndex];
            _lastItemIndex--;

            MaxHeapifyDown(0);

            return removedItem;
        }

        public T Peek()
        {
            if (_lastItemIndex == -1)
            {
                throw new InvalidOperationException("The heap is empty");
            }

            return _arr[0];
        }

        public void Clear()
        {
            _lastItemIndex = -1;
        }

        private void MaxHeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int childIndex = index;
            int parentIndex = (index - 1) / 2;

            if (_comparer.Compare(_arr[childIndex], _arr[parentIndex]) > 0)
            {
                // swap the parent and the child
                T temp = _arr[childIndex];
                _arr[childIndex] = _arr[parentIndex];
                _arr[parentIndex] = temp;

                MaxHeapifyUp(parentIndex);
            }
        }

        private void MaxHeapifyDown(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int largestItemIndex = index; // The index of the parent

            if (leftChildIndex <= _lastItemIndex &&
                _comparer.Compare(_arr[leftChildIndex], _arr[largestItemIndex]) > 0)
            {
                largestItemIndex = leftChildIndex;
            }

            if (rightChildIndex <= _lastItemIndex &&
                _comparer.Compare(_arr[rightChildIndex], _arr[largestItemIndex]) > 0)
            {
                largestItemIndex = rightChildIndex;
            }

            if (largestItemIndex != index)
            {
                // swap the parent with the largest of the child items
                T temp = _arr[index];
                _arr[index] = _arr[largestItemIndex];
                _arr[largestItemIndex] = temp;

                MaxHeapifyDown(largestItemIndex);
            }
        }

        private void Resize()
        {
            T[] newArr = new T[_arr.Length * 2];
            for (int i = 0; i < _arr.Length; i++)
            {
                newArr[i] = _arr[i];
            }

            _arr = newArr;
        }
    }
}
