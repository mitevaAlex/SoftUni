using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            Dictionary<double, int> numsCount = new Dictionary<double, int>();
            foreach (double num in nums)
            {
                if (!numsCount.ContainsKey(num))
                {
                    numsCount.Add(num, 0);
                }

                numsCount[num]++;
            }

            Console.WriteLine(string.Join(Environment.NewLine, numsCount.Select(x => $"{x.Key} - {x.Value} times")));
        }
    }
}
