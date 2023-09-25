using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int counter = 1;

            while (counter <= n)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                counter++;
                if (currentNumber > max)
                {
                    max = currentNumber;
                }
            }
            Console.WriteLine(max);
        }
    }
}
