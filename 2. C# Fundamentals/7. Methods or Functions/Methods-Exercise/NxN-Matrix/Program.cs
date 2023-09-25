using System;

namespace NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintNumberXNumberMatrix(number);
        }

        static void PrintNumberXNumberMatrix(int number)
        {
            for (int row = 0; row < number; row++)
            {
                for (int column = 0; column < number; column++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
