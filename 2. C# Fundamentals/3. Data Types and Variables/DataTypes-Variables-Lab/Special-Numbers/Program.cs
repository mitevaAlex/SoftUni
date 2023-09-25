using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());//the last num of a sequence starting with 1
            for (int currentNum = 1; currentNum <= lastNumber; currentNum++)
            {
                int digitsSum = 0;
                int currentNumberCopy = currentNum;
                while (currentNumberCopy != 0)
                {
                    int currentDigit = currentNumberCopy % 10;
                    digitsSum += currentDigit;
                    currentNumberCopy /= 10;
                }

                bool isSpecialNumber = false;
                if (digitsSum == 5 || digitsSum == 7 || digitsSum == 11)
                {
                    isSpecialNumber = true;
                }
                Console.WriteLine($"{currentNum} -> {isSpecialNumber}");
            }
        }
    }
}
