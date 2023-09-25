using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            int sumPrimeNums = 0;
            int sumNonPrimeNums = 0;

            while ((command = Console.ReadLine()) != "stop")
            {
                int currentNum = int.Parse(command);
                bool isPrime = true;

                if (currentNum < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                if (currentNum == 1)
                {
                    isPrime = false;
                }
                for (int divisor = currentNum-1; divisor > 1; divisor--)
                {
                    if (currentNum % divisor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    sumPrimeNums += currentNum;
                }
                else
                {
                    sumNonPrimeNums += currentNum;
                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNums}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNums}");
        }
    }
}
