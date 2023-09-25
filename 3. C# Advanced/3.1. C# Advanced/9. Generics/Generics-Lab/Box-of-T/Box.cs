using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly Stack<T> items = new Stack<T>();

        public int Count => this.items.Count;

        public void Add(T element) => this.items.Push(element);

        public T Remove() { return this.items.Pop(); }
    }
}
