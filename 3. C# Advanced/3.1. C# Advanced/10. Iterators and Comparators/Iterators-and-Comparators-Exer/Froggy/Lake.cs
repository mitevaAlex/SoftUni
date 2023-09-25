using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly List<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public int this[int index] => this.stones[index];

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int stone in this.stones)
            {
                yield return stone;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
