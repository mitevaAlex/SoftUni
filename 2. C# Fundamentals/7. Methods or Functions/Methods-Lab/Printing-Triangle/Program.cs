using System;

namespace Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int row = 1; row <= number; row++)
            {
                WriteColumnNumber(row);
            }

            for (int row = number - 1; row > 0; row--)
            {
                WriteColumnNumber(row);
            }
        }

        static void WriteColumnNumber(int row)
        {
            for (int column = 1; column <= row; column++)
            {
                Console.Write(column + " ");
            }
            Console.WriteLine();
        }
    }
}
