using System;

namespace Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            char thirdChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char firstChar = char.Parse(Console.ReadLine());

            Console.WriteLine($"{firstChar} {secondChar} {thirdChar}");
        }
    }
}
