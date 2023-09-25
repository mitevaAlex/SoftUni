using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            int numbersSum = 0;

            for (int i = 1; i <= numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbersSum += number;
            }

            Console.WriteLine(numbersSum);
        }
    }
}
