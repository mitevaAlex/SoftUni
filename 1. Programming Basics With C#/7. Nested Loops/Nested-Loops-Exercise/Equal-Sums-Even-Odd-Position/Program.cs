using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            for (int newNum = firstNum; newNum <= secondNum; newNum++)
            {
                int newNumChanger = newNum;

                int sumEvenPositions = 0;
                int sumOddPositions = 0;
                for (int digitsOrder = 6; digitsOrder > 0; digitsOrder--)
                {
                    int digit = newNumChanger % 10;
                    if (digitsOrder % 2 == 0)
                    {
                        sumEvenPositions += digit;
                    }
                    else
                    {
                        sumOddPositions += digit;
                    }
                    newNumChanger /= 10;
                }
                if (sumEvenPositions == sumOddPositions)
                {
                    Console.Write($"{newNum} ");
                }
            }
        }
    }
}
