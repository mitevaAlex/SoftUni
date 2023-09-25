using System;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());//the lines we are going to read
            for (int currentLine = 1; currentLine <= linesCount; currentLine++)
            {
                string twoNumbers = Console.ReadLine();//two numbers which we are going to compare
                string firstNumberString = string.Empty;
                string secondNumberString = string.Empty;
                int spaceCharNum = 0;
                for (int currentCharFirstNum = 0; currentCharFirstNum < twoNumbers.Length; currentCharFirstNum++)
                {
                    if (twoNumbers[currentCharFirstNum] != ' ')
                    {
                        firstNumberString += twoNumbers[currentCharFirstNum];
                    }
                    else
                    {
                        spaceCharNum = currentCharFirstNum;
                        break;
                    }
                }
                for (int currentCharSecondNum = spaceCharNum + 1; currentCharSecondNum < twoNumbers.Length; currentCharSecondNum++)
                {
                    secondNumberString += twoNumbers[currentCharSecondNum];
                }
                long firstNumAsNum = long.Parse(firstNumberString);
                long secondNumAsNum = long.Parse(secondNumberString);
                int digitsSum = 0;
                if (firstNumAsNum >= secondNumAsNum)
                {
                    while (firstNumAsNum != 0)
                    {
                        int currentDigit = (int)(firstNumAsNum % 10);
                        digitsSum += currentDigit;
                        firstNumAsNum /= 10;
                    }
                }
                else
                {
                    while (secondNumAsNum != 0)
                    {
                        int currentDigit = (int)(secondNumAsNum % 10);
                        digitsSum += currentDigit;
                        secondNumAsNum /= 10;
                    }
                }
                Console.WriteLine(Math.Abs(digitsSum));
            }
        }
    }
}
