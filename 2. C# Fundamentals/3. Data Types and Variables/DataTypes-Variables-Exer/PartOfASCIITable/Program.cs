using System;

namespace PartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingChar = int.Parse(Console.ReadLine());//the ASCII code of the first char we are going to print
            int finalChar = int.Parse(Console.ReadLine());//the ASCII code of the last char we are going to print
            for (int currentChar = startingChar; currentChar <= finalChar; currentChar++)
            {
                Console.Write($"{(char)currentChar} ");
            }

        }
    }
}
