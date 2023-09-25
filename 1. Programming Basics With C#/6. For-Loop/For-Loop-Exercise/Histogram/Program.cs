using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            int p1Counter = 0;
            int p2Counter = 0;
            int p3Counter = 0;
            int p4Counter = 0;
            int p5Counter = 0;

            for (int i = 0; i < numbersCount; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                {
                    p1Counter++;
                }
                else if (num >= 200 && num <= 399)
                {
                    p2Counter++;
                }
                else if (num >= 400 && num <= 599)
                {
                    p3Counter++;
                }
                else if (num >= 600 && num <= 799)
                {
                    p4Counter++;
                }
                else
                {
                    p5Counter++;
                }
            }

            double p1 = p1Counter / (double) numbersCount * 100;
            double p2 = p2Counter / (double) numbersCount * 100;
            double p3 = p3Counter / (double) numbersCount * 100;
            double p4 = p4Counter / (double) numbersCount * 100;
            double p5 = p5Counter / (double) numbersCount * 100;

            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
            Console.WriteLine($"{p4:F2}%");
            Console.WriteLine($"{p5:F2}%");
        }
    }
}
