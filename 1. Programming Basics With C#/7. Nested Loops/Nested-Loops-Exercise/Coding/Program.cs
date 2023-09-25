using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberText = Console.ReadLine();
            int num = int.Parse(numberText);

            for (int rows = 1; rows <= numberText.Length; rows++)
            {
                for (int symbolsCount = 0; symbolsCount < (num % 10) || num % 10 == 0; symbolsCount++)
                {
                    if (num % 10 == 0)
                    {
                        Console.Write("ZERO");
                        break;
                    }
                    char symbol = (char)(num % 10 + 33);
                    Console.Write(symbol);
                }
                num /= 10;
                Console.WriteLine();
            }
        }
    }
}
