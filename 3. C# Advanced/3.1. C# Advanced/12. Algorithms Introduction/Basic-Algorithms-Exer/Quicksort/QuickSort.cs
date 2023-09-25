using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Quicksort
{
    class QuickSort<T> where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            this.Sort(array, 0, array.Length - 1);
        }

        private void Sort(T[] array, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int pivotIndex = Partition(array, low, high);
            this.Sort(array, low, pivotIndex - 1);
            this.Sort(array, pivotIndex + 1, high);
        }

        private int Partition(T[] array, int low, int high)
        {
            if (low >= high)
            {
                return low;
            }

            int i = low;
            int j = high + 1;
            while (true)
            {
                while (array[++i].CompareTo(array[low]) < 0)
                {
                    if (i == high)
                    {
                        break;
                    }
                }

                while (array[low].CompareTo(array[--j]) < 0)
                {
                    if (j == low)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }

                T item1 = array[i];
                array[i] = array[j];
                array[j] = item1;
            }

            T item = array[low];
            array[low] = array[j];
            array[j] = item;
            return j;
        }
    }
}
