using System;
using System.Linq;

namespace Print_Numbers_In_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());//the count of lines we are going to read
            int[] numbers = new int[numbersCount];
            for (int i = 0; i < numbersCount; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }          
            Console.WriteLine(string.Join(' ', numbers.Reverse()));
        }
    }
}
