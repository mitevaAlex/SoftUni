using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            int maxNum = int.MinValue;
            int sum = 0;

            for (int i = 0; i < numbersCount; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber > maxNum)
                {
                    maxNum = currentNumber;
                }
                sum += currentNumber;
            }

            sum -= maxNum;
            int diff = Math.Abs(sum - maxNum);

            if (diff == 0)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
