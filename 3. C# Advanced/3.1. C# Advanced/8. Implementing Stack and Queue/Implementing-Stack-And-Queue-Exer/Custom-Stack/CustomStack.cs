using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Stack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items = new int[InitialCapacity];

        public int Count { get; private set; }

        private void Resize()
        {
            int[] arrayCopy = new int[this.items.Length * 2];
            this.items.CopyTo(arrayCopy, 0);
            this.items = arrayCopy;
        }

        public void Push(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[Count] = element;
            this.Count++;
        }

        public int Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            int element = this.items[this.Count - 1];
            this.items[this.Count - 1] = 0;
            this.Count--;
            return element;
        }

        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            return this.items[this.Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
