using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            int counter = 1;

            while (counter <= n)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                counter++;
                if (currentNumber < min)
                {
                    min = currentNumber;
                }
            }
            Console.WriteLine(min);
        }
    }
}
