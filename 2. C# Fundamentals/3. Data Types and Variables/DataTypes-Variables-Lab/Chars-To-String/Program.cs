using System;

namespace Chars_To_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string charSequence = string.Empty;
            for (int currentLine = 1; currentLine <= 3; currentLine++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                charSequence += currentChar;
            }
            Console.WriteLine(charSequence);
        }
    }
}
