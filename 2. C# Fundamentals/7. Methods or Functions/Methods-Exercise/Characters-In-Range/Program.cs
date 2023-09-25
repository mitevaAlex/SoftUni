using System;
using System.Linq;

namespace Characters_In_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());
            WriteBetweenCharacters(firstSymbol, secondSymbol);
        }
        static void WriteBetweenCharacters(char firstSymbol, char secondSymbol)
        {
            char nextSymbol = (char)(Math.Min(firstSymbol,secondSymbol) + 1);
            char[] betweenSymbols = new char[Math.Abs(firstSymbol - secondSymbol) - 1];
            for (int i = 0; i < betweenSymbols.Length; i++)
            {
                betweenSymbols[i] = (char)(nextSymbol + i);
            }
            Console.WriteLine(string.Join(' ',betweenSymbols));
        }
    }
}
