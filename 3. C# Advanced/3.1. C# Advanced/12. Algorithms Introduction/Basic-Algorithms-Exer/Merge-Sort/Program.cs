using System;
using System.Linq;

namespace Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeSort<int> mergeSort = new MergeSort<int>();
            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            nums = mergeSort.Sort(nums);
            Console.WriteLine(string.Join(' ', nums));
        }
    }
}
