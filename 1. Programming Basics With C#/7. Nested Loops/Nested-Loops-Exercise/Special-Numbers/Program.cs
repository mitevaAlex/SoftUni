using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= 9; firstDigit++)
            {
                for (int secondDigit = 1; secondDigit <= 9; secondDigit++)
                {
                    for (int thirdDigit = 1; thirdDigit <= 9; thirdDigit++)
                    {
                        for (int fourthDigit = 1; fourthDigit <= 9; fourthDigit++)
                        {
                            if (n % firstDigit == 0 && n % secondDigit == 0 &&
                                n % thirdDigit == 0 && n % fourthDigit == 0)
                            {
                                Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
