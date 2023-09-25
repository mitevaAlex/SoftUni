using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            int p1Counter = 0;
            int p2Counter = 0;
            int p3Counter = 0;

            for (int i = 0; i < numbersCount; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    p1Counter++;
                }

                if (num % 3 == 0)
                {
                    p2Counter++;
                }

                 if (num % 4 == 0)
                {
                    p3Counter++;
                }
            }

            double p1 = p1Counter / (double)numbersCount * 100;
            double p2 = p2Counter / (double)numbersCount * 100;
            double p3 = p3Counter / (double)numbersCount * 100;

            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
        }
    }
}
