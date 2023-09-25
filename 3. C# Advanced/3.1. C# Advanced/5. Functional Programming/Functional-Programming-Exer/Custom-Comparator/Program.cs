using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            nums.Sort();
            Func<List<int>, List<int>> evenNums = x => x.Where(y => y % 2 == 0).ToList();
            Func<List<int>, List<int>> oddNums = x => x.Where(y => y % 2 != 0).ToList();
            List<int> sortedNums = evenNums(nums);
            sortedNums.AddRange(oddNums(nums));
            Console.WriteLine(string.Join(' ', sortedNums));
        }
    }
}
