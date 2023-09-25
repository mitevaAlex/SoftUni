using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> items;

        public Stack(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public void Push(params T[] items)
        {
            this.items.AddRange(items);
        }

        public T Pop()
        {
            if (this.items.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            T item = this.items[this.items.Count - 1];
            this.items.RemoveAt(this.items.Count - 1);
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.items.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
