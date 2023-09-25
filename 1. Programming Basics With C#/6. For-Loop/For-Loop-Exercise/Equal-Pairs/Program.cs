using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsNumsCount = int.Parse(Console.ReadLine());
            int currentSum = 0;
            int lastSum = 0;
            int greatestDifference = 0;

            for (int i = 0; i < groupsNumsCount; i++)
            {
                int firstCurrentNumber = int.Parse(Console.ReadLine());
                int secondCurrentNumber = int.Parse(Console.ReadLine());
                currentSum = firstCurrentNumber + secondCurrentNumber;
                if (i > 0)
                {
                    if (Math.Abs(currentSum - lastSum) > greatestDifference)
                    {
                        greatestDifference = Math.Abs(currentSum - lastSum);
                    }
                }
                lastSum = currentSum;
            }

            if (greatestDifference == 0)
            {
                Console.WriteLine($"Yes, value={lastSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={greatestDifference}");   
            }
        }
    }
}
