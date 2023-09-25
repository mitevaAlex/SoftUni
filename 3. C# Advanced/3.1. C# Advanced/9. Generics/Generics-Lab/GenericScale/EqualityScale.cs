using System;

namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable
    {
        private readonly T left;
        private readonly T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual() => this.left.Equals(this.right);
    }
}
