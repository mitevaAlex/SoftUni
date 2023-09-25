using System;
using System.Linq;

namespace Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            int[] firstArr = new int[linesCount];//array of numbers
            int[] secondArr = new int[linesCount];//array of numbers

            for (int i = 0; i < linesCount; i++)
            {
                int[] currentLine = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();//two numbers
                if (i % 2 != 0)
                {
                    firstArr[i] = currentLine[1];
                    secondArr[i] = currentLine[0];
                }
                else
                {
                    firstArr[i] = currentLine[0];
                    secondArr[i] = currentLine[1];
                }                              
            }
            Console.WriteLine(string.Join(' ', firstArr));
            Console.WriteLine(string.Join(' ', secondArr));
        }
    }
}
