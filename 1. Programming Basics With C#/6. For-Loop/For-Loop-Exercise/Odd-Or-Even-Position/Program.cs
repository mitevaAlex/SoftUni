using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Or_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            double oddSum = 0.0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0.0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= numbersCount; i++)
            {
                double currentNum = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += currentNum;
                    if (currentNum < evenMin)
                    {
                        evenMin = currentNum;
                    }

                    if (currentNum > evenMax)
                    {
                        evenMax = currentNum;
                    }
                }
                else
                {
                    oddSum += currentNum;
                    if (currentNum < oddMin)
                    {
                        oddMin = currentNum;
                    }

                    if (currentNum > oddMax)
                    {
                        oddMax = currentNum;
                    }
                }
            }
            string ifNo = "No";

            Console.WriteLine($"OddSum={oddSum:F2},");
            if (oddMin == double.MaxValue)
            {
                Console.WriteLine($"OddMin={ifNo},");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:F2},");
            }

            if (oddMax == double.MinValue)
            {
                Console.WriteLine($"OddMax={ifNo},");
            }
            else
            {
                Console.WriteLine($"OddMax={oddMax:F2},");
            }
                       
            Console.WriteLine($"EvenSum={evenSum:F2},");
            if (evenMin == double.MaxValue)
            {
                Console.WriteLine($"EvenMin={ifNo},");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:F2},");
            }

            if (evenMax == double.MinValue)
            {
                Console.WriteLine($"EvenMax={ifNo}");
            }
            else
            {
                Console.WriteLine($"EvenMax={evenMax:F2}");
            }
            
        }
    }
}
