using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> capitalLetterCheck = x => char.IsUpper(x[0]);
            string[] wantedWords = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => capitalLetterCheck(x))
                .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, wantedWords));
        }
    }
}
