using System;
using System.Text;

namespace Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder builder = new StringBuilder();
            foreach(string word in words)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    builder.Append(word);
                }
            }
            string finalString = builder.ToString();
            Console.WriteLine(finalString);
        }
    }
}
