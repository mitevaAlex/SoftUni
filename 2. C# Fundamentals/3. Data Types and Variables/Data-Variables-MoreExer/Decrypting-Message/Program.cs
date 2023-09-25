using System;

namespace Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());//we are going to add that key 
            //to every character that we are going to receive in order to decrypt the message
            int lettersCount = int.Parse(Console.ReadLine());//the lines we are going to read
            string secretMessage = string.Empty;
            for (int currentLine = 1; currentLine <= lettersCount; currentLine++)
            {
                char currentLetter= char.Parse(Console.ReadLine());
                secretMessage += (char)(currentLetter + key);
            }
            Console.WriteLine(secretMessage);
        }
    }
}
