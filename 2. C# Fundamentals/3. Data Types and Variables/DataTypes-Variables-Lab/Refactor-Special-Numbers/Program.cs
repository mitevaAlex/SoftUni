using System;

namespace Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());
            for (int currentNum = 1; currentNum <= lastNumber; currentNum++)
            {
                int digitsSum = 0;
                int currentNumberCopy = currentNum;
                while (currentNumberCopy != 0)
                {
                    digitsSum += currentNumberCopy % 10;
                    currentNumberCopy /= 10;
                }
                bool isSpecialNumber = (digitsSum == 5) || (digitsSum == 7) || (digitsSum == 11);
                Console.WriteLine("{0} -> {1}", currentNum, isSpecialNumber);
            }
        }
    }
}
