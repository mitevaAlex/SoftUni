using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Sums_Left_Right_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            for (int newNum = firstNum; newNum <= secondNum; newNum++)
            {
                int firstDigitNewNum = newNum / 10000;
                int secondDigitNewNum = newNum / 1000 % 10;
                int thirdDigitNewNum = newNum / 100 % 10;
                int fourthDigitNewNum = newNum / 10 % 10;
                int fifthDigitNewNum = newNum % 10;

                if (firstDigitNewNum + secondDigitNewNum == fourthDigitNewNum + fifthDigitNewNum)
                {
                    Console.Write($"{newNum} ");
                }
                else if (firstDigitNewNum + secondDigitNewNum < fourthDigitNewNum + fifthDigitNewNum && 
                    firstDigitNewNum + secondDigitNewNum + thirdDigitNewNum == fourthDigitNewNum + fifthDigitNewNum)
                {
                    Console.Write($"{newNum} ");
                }
                else if (firstDigitNewNum + secondDigitNewNum > fourthDigitNewNum + fifthDigitNewNum &&
                    firstDigitNewNum + secondDigitNewNum == fourthDigitNewNum + fifthDigitNewNum + thirdDigitNewNum)
                {
                    Console.Write($"{newNum} ");
                }
            }


        }
    }
}
