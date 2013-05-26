using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomStack<T> : IEnumerable<T>, ICloneable
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

            public Node(T item, Node next)
            {
                this.Item = item;
                this.Next = next;
            }
        }

        private Node top;
        private int count;

        public CustomStack()
        {
            this.top = null;
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return this.top.Item;
        }

        public T Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            T result = this.top.Item;
            this.top = this.top.Next;
            this.count--;

            return result;
        }

        public void Push(T item)
        {
            if (this.top == null)
            {
                // We have empty stack
                this.top = new Node(item);
            }
            else
            {
                Node newNode = new Node(item, this.top);
                this.top = newNode;
            }

            this.count++;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            Node currentNode = this.top;
            while (currentNode != null)
            {
                result.Append(currentNode.Item.ToString());
                currentNode = currentNode.Next;
            }

            return result.ToString();
        }

        public T[] ToArray()
        {
            T[] result = new T[this.count];

            Node currentNode = this.top;
            for (int i = 0; i < this.count; i++)
            {
                result[i] = currentNode.Item;
                currentNode = currentNode.Next;
            }

            return result;
        }

        public void Clear()
        {
            this.top = null;
            this.count = 0;
        }

        public object Clone()
        {
            CustomStack<T> clone = new CustomStack<T>();

            if (this.count != 0)
            {
                // We have non-empty stack
                clone.top = new Node(this.top.Item);
                Node currentNode = this.top.Next;
                Node helperNode = clone.top; // helps us to make the links between the nodes of the clone

                while (currentNode != null)
                {
                    Node newNode = new Node(currentNode.Item);
                    helperNode.Next = newNode;
                    helperNode = newNode;
                    currentNode = currentNode.Next;
                }

                helperNode.Next = null;
                clone.count = this.count;
            }

            return clone;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.top;
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
