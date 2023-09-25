using System;
using System.Linq;

namespace Binary_Digits_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int binaryNumToCount = int.Parse(Console.ReadLine());
            int[] digits = Convert.ToString(number, 2)
                .ToCharArray()
                .Select(x => x - '0')
                .ToArray();
            int count = digits
                .Where(x => x == binaryNumToCount)
                .Count();
            Console.WriteLine(count);
        }
    }
}
