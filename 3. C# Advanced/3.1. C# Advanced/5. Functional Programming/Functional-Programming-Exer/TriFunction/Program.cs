using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int minSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Func<string, int> charSum = name => name.Select(x => (int)x).Sum();
            Func<int, int, bool> isEqualOrLarger = (charSum, wantedSum) => charSum >= wantedSum;
            foreach (string name in names)
            {
                if (isEqualOrLarger(charSum(name), minSum))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}
