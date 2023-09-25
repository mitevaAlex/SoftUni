using System;
using System.Linq;

namespace Digits_Letters_And_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string numbers = string.Join("",text.Where(x => char.IsDigit(x)));
            string letters = string.Join("", text.Where(x => char.IsLetter(x)));
            string otherSymbols = string.Join("", text.Where(x => !char.IsLetterOrDigit(x)));
            Console.WriteLine($"{numbers}{Environment.NewLine}" +
                $"{letters}{Environment.NewLine}" +
                $"{otherSymbols}");
        }
    }
}
