using System;
using System.Linq;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sortedNums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();
            int wantedNum = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch.IndexOf(sortedNums, wantedNum));
        }
    }

    static class BinarySearch
    {
        public static int IndexOf(int[] array, int num)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low < high)
            {
                int middle = low + (high + low) + 1 / 2;
                if (num < array[middle])
                {
                    high = middle - 1;
                }
                else if (num > array[middle])
                {
                    low = middle + 1;
                }
                else
                {
                    return middle;
                }
            }

            if (low == high && num == array[low])
            {
                return low;
            }

            return -1;
        }
    }
}
