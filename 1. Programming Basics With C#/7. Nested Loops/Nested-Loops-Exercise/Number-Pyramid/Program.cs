using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentNum = 1;
            bool isGreater = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int columns = 1; columns <= rows; columns++)
                {
                    if (currentNum > n)
                    {
                        isGreater = true;
                        break;
                    }
                    Console.Write($"{currentNum} ");
                    currentNum++;
                }
                if (isGreater)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
