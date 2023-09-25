using System;

namespace Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstBorderSymbol = char.Parse(Console.ReadLine());
            char secondBorderSymbol = char.Parse(Console.ReadLine());
            firstBorderSymbol = firstBorderSymbol < secondBorderSymbol ? firstBorderSymbol : secondBorderSymbol;
            secondBorderSymbol = firstBorderSymbol < secondBorderSymbol ? secondBorderSymbol : firstBorderSymbol;
            string text = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char currentSymbol = text[i];
                if (currentSymbol > firstBorderSymbol && currentSymbol < secondBorderSymbol)
                {
                    sum += currentSymbol;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
