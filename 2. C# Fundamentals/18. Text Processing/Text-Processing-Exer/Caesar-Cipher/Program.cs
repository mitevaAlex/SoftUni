using System;
using System.Linq;
using System.Text;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                builder.Append((char)(text[i] + 3)); 
            }
            string encryptedText = builder.ToString();
            Console.WriteLine(encryptedText);
        }
    }
}
