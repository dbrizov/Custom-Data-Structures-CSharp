using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomQueue<T> : IEnumerable<T>, ICloneable
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

        private Node front;
        private Node back;
        private int count;

        public CustomQueue()
        {
            this.front = null;
            this.back = null;
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Enqueue(T item)
        {
            if (this.front == null)
            {
                // We have empty queue
                this.front = new Node(item);
                this.back = this.front;
            }
            else
            {
                Node newNode = new Node(item, this.back);
                this.back = newNode;
            }

            this.count++;
        }

        public T Dequeue()
        {
            if (this.count == 0)
            {
                // We have empty queue
                throw new InvalidOperationException("The queue is empty");
            }

            T result = this.front.Item;
            this.front = this.front.Next;
            this.count--;

            return result;
        }

        public T Peek()
        {
            if (this.count == 0)
            {
                // We have empty queue
                throw new InvalidOperationException("The queue is empty");
            }

            return this.front.Item;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            Node currentNode = this.front;
            while (currentNode != null)
            {
                result.Append(currentNode.Item);
                currentNode = currentNode.Next;
            }

            return result.ToString();
        }

        public T[] ToArray()
        {
            T[] result = new T[this.count];

            Node currentNode = this.front;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = currentNode.Item;
                currentNode = currentNode.Next;
            }

            return result;
        }

        public void Clear()
        {
            this.front = null;
            this.back = null;
            this.count = 0;
        }

        public object Clone()
        {
            CustomQueue<T> clone = new CustomQueue<T>();

            Node currentNode = this.front;
            while (currentNode != null)
            {
                // We have non-empty queue
                clone.Enqueue(currentNode.Item);
                currentNode = currentNode.Next;
            }

            return clone;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.front;
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
    }
}
