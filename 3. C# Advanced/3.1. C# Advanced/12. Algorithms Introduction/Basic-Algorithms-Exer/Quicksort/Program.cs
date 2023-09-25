using System;
using System.Linq;

namespace Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort<int> mergeSort = new QuickSort<int>();
            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            mergeSort.Sort(nums);
            Console.WriteLine(string.Join(' ', nums));
        }
    }
}
