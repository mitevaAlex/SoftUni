using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            int divider = int.Parse(Console.ReadLine());
            nums.Reverse();
            Func<List<int>, List<int>> exclude = x => x.Where(y => y % divider != 0).ToList();
            nums = exclude(nums);
            Console.WriteLine(string.Join(' ', nums));
        }
    }
}
