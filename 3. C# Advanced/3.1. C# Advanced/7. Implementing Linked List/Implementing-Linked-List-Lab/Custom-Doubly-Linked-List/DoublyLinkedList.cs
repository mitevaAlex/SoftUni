using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<ListNode<T>>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public DoublyLinkedList() { }

        public DoublyLinkedList(T value)
        {
            this.AddFirst(value);
        }

        public DoublyLinkedList(IEnumerable<T> list)
            : this(list.First())
        {
            list = list.Skip(1);
            foreach (T element in list)
            {
                this.AddLast(element);
            }
        }

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newHead = new ListNode<T>(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newTail = new ListNode<T>(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T firstElement = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;
            if (this.tail != null)
            {
                this.head.NextNode = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] elements = new T[this.Count];
            ListNode<T> currentNode = this.head;
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return elements;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.ForEach(element => sb.Append(element + " "));
            return sb.ToString().Trim();
        }

        public IEnumerator<ListNode<T>> GetEnumerator()
        {
            ListNode<T> currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class ListNode<V>
    {
        public ListNode(V value)
        {
            this.Value = value;
        }

        public V Value { get; set; }

        public ListNode<V> NextNode { get; set; }

        public ListNode<V> PreviousNode { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
