using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            double totalSum = 0.0;

            while (counter <= n)
            {
                double currentMoney = double.Parse(Console.ReadLine());
                if (currentMoney < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {currentMoney:F2}");
                totalSum += currentMoney;
                counter++;
            }
            Console.WriteLine($"Total: {totalSum:F2}");
        }
    }
}
