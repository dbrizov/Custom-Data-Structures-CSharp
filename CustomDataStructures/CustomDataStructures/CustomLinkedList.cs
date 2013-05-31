using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDataStructures
{
    public class CustomLinkedList<T> : IList<T>
    {
        private class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }

            public Node(T item)
            {
                this.Item = item;
                this.Next = null;
            }

            public Node(T item, Node previous)
            {
                this.Item = item;
                this.Next = null;
                previous.Next = this;
            }
        }

        private Node first;
        private Node last;
        private int count;

        public CustomLinkedList()
        {
            this.first = null;
            this.last = null;
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
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
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException("Invalid index " + index);
                }

                Node node = this.GetNode(index);
                return node.Item;
            }

            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException("Invalid index " + index);
                }

                Node node = this.GetNode(index);
                node.Item = value;
            }
        }

        public int IndexOf(T item)
        {
            int index = 0;
            Node currentNode = this.first;

            while (currentNode != null)
            {
                if (currentNode.Item.Equals(item))
                {
                    return index;
                }

                currentNode = currentNode.Next;
                index++;
            }

            return -1;
        }

        public void Add(T item)
        {
            if (this.first == null)
            {
                // We have empty list
                this.first = new Node(item);
                this.last = this.first;
            }
            else
            {
                Node newNode = new Node(item, this.last); // Connect the last node with the new node
                this.last = newNode; // The new node is made the last in the list
            }

            this.count++;
        }

        public void AddFirst(T item)
        {
            if (this.first == null)
            {
                // We have empty list
                this.first = new Node(item);
                this.last = this.first;
            }
            else
            {
                Node newNode = new Node(item);
                newNode.Next = this.first; // Connect the new node with the first
                this.first = newNode; // The new node is now the first in the list
            }

            this.count++;
        }

        // The same as Add(T item)
        public void AddLast(T item)
        {
            this.Add(item);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            if (this.count == 1 || index == 0)
            {
                this.AddFirst(item);
            }
            else
            {
                Node previousNode = this.GetNode(index - 1);
                Node nodeAtIndex = previousNode.Next;
                Node newNode = new Node(item, previousNode); // Connect the previous node with the new node
                newNode.Next = nodeAtIndex; // Connect the new node with the one at the given index

                this.count++;
            }
        }

        public bool Remove(T item)
        {
            bool removed = false;
            int index = this.IndexOf(item);

            if (index != -1)
            {
                this.RemoveAt(index);
                removed = true;
            }

            return removed;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            if (index == 0 || this.count == 1)
            {
                this.RemoveFirst();
            }
            else if (index == this.count - 1)
            {
                this.RemoveLast();
            }
            else
            {
                Node previousNode = this.GetNode(index - 1);
                Node nodeThatWillBeRemove = previousNode.Next;
                previousNode.Next = nodeThatWillBeRemove.Next; // Connect the previous node with the node after the one that will be removed
                nodeThatWillBeRemove = null; // This will force the garbage collector to delete the node

                this.count--;
            }
        }

        public void RemoveFirst()
        {
            if (this.count == 1 || this.count == 0)
            {
                this.Clear();
            }
            else
            {
                this.first = this.first.Next;
                this.count--;
            }
        }

        public void RemoveLast()
        {
            if (this.count == 1 || this.count == 0)
            {
                this.Clear();
            }
            else
            {
                Node beforeLast = this.GetNode(this.count - 2);
                beforeLast.Next = null;
                this.last = beforeLast;

                this.count--;
            }
        }

        public void Clear()
        {
            this.first = null;
            this.last = null;
            this.count = 0;
        }

        public bool Contains(T item)
        {
            int index = this.IndexOf(item);
            bool found = (index != -1);

            return found;
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

            Node currentNode = this.first;
            while (currentNode != null)
            {
                array[arrayIndex] = currentNode.Item;
                currentNode = currentNode.Next;
                arrayIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.first;

            while (currentNode != null)
            {
                T result = currentNode.Item;
                currentNode = currentNode.Next;

                yield return result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private Node GetNode(int index)
        {
            Node currentNode = this.first;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }
    }
}
