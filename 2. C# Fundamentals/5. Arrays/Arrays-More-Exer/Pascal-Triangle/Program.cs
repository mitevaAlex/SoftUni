using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            long[] currentLineNumbers = new long[1];
            currentLineNumbers[0] = 1;
            for (int i = 1; i <= linesCount; i++)
            {
                long[] previousLineNumbers = new long[i];
                Array.Copy(currentLineNumbers, previousLineNumbers, currentLineNumbers.Length);
                currentLineNumbers = new long[i];
                currentLineNumbers[0] = 1;
                for (int j = 1; j < i; j++)
                {
                    currentLineNumbers[j] = previousLineNumbers[j - 1] + previousLineNumbers[j];
                }
                string currentLineOutput = string.Join(' ', currentLineNumbers);
                Console.WriteLine(currentLineOutput);
            }
        }
    }
}
