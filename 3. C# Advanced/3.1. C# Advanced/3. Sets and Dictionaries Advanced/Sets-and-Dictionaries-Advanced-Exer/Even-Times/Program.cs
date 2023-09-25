using System;
using System.Collections.Generic;
using System.Linq;

namespace Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            int numscount = int.Parse(Console.ReadLine());
            for (int i = 0; i < numscount; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!counts.ContainsKey(num))
                {
                    counts.Add(num, 0);
                }

                counts[num]++;
            }

            int evenTimeNum = counts
                .Where(x => x.Value % 2 == 0)
                .Select(x => x.Key)
                .First();
            Console.WriteLine(evenTimeNum);
        }
    }
}
