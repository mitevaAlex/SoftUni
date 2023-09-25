using System;

namespace Sum_Of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            int asciiSum = 0;
            for (int currentLine = 1; currentLine <= linesCount; currentLine++)
            {
                char latinLetter = char.Parse(Console.ReadLine());
                asciiSum += latinLetter;
            }
            Console.WriteLine($"The sum equals: {asciiSum}");
        }
    }
}
