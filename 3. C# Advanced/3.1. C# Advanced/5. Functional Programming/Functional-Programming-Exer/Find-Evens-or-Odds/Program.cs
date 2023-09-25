using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numBounds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string numsType = Console.ReadLine();
            Predicate<int> wantedNumTypeCheck = x => numsType == "even" ? x % 2 == 0 : x % 2 != 0;
            List<int> wantedNums = new List<int>();
            for (int i = numBounds[0]; i <= numBounds[1]; i++)
            {
                if (wantedNumTypeCheck(i))
                {
                    wantedNums.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ', wantedNums));
        }
    }
}
