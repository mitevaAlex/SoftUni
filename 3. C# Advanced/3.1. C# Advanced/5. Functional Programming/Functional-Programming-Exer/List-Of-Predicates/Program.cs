using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNum = int.Parse(Console.ReadLine());
            HashSet<int> dividers = new HashSet<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            List<int> wantedNums = new List<int>();
            Func<int, int, bool> isValid = (num, divider) => num % divider == 0;
            for (int i = 1; i <= lastNum; i++)
            {
                wantedNums.Add(i);
                foreach (int divider in dividers)
                {
                    if (isValid(i, divider) == false)
                    {
                        wantedNums.Remove(i);
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(' ', wantedNums));
        }
    }
}
