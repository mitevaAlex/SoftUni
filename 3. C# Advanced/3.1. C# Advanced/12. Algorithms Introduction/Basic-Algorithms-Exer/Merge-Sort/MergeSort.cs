using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Merge_Sort
{
    class MergeSort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            else
            {
                int middle = array.Length / 2;
                T[] firstHalf = new T[middle];
                T[] secondHalf = new T[array.Length - middle];
                Array.ConstrainedCopy(array, 0, firstHalf, 0, firstHalf.Length);
                Array.ConstrainedCopy(array, firstHalf.Length, secondHalf, 0, secondHalf.Length);
                firstHalf = this.Sort(firstHalf);
                secondHalf = this.Sort(secondHalf);
                T[] sorted = this.Merge(firstHalf, secondHalf);
                return sorted;
            }
        }

        private T[] Merge(T[] left, T[] right)
        {
            T[] mergedItems = new T[left.Length + right.Length];
            int rightIndex = 0;
            int leftIndex = 0;
            while (leftIndex < left.Length || rightIndex < right.Length)
            {
                int mergeIndex = rightIndex + leftIndex;
                if (leftIndex < left.Length && rightIndex < right.Length)
                {
                    bool leftIsSmaller = left[leftIndex].CompareTo(right[rightIndex]) < 0;
                    if (leftIsSmaller)
                    {
                        mergedItems[mergeIndex] = left[leftIndex++];
                    }
                    else
                    {
                        mergedItems[mergeIndex] = right[rightIndex++];
                    }
                }
                else if (leftIndex < left.Length)
                {
                    mergedItems[mergeIndex] = left[leftIndex++];
                }
                else if (rightIndex < right.Length)
                {
                    mergedItems[mergeIndex] = right[rightIndex++];
                }
            }

            return mergedItems;
        }
    }
}
