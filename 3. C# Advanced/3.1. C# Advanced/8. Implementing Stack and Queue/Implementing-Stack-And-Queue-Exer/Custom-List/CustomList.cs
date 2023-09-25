using System;
using System.Linq;
using System.Text;

namespace Custom_List
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items = new int[InitialCapacity];

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.items[index];
            }

            set
            {
                ValidateIndex(index);
                this.items[index] = value;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void Resize()
        {
            int[] arrayCopy = new int[this.items.Length * 2];
            this.items.CopyTo(arrayCopy, 0);
            this.items = arrayCopy;
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.Count - 1] = 0;
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        private void Shrink()
        {
            int[] arrayCopy = new int[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                arrayCopy[i] = this.items[i];
            }
            this.items = arrayCopy;
        }

        public void Add(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            ValidateIndex(index);
            int element = this.items[index];
            this.ShiftToLeft(index);
            this.Count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return element;
        }

        public void Insert(int index, int element)
        {
            if (index > this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);
            this.items[index] = element;
            this.Count++;
        }

        public bool Contains(int element)
        {
            bool contains = false;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);
            int firstElement = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = firstElement;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append($"{this.items[i]} ");
            }

            return sb.ToString().Trim();
        }

    }
}
