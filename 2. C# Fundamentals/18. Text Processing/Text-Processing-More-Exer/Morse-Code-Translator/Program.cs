using System;
using System.Collections.Generic;
using System.Linq;

namespace Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] morseWords = Console.ReadLine()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, char> morseAlphabet = new Dictionary<string, char>
            {
                [".-"] = 'A',
                ["-..."] = 'B',
                ["-.-."] = 'C',
                ["-.."] = 'D',
                ["."] = 'E',
                ["..-."] = 'F',
                ["--."] = 'G',
                ["...."] = 'H',
                [".."] = 'I',
                [".---"] = 'J',
                ["-.-"] = 'K',
                [".-.."] = 'L',
                ["--"] = 'M',
                ["-."] = 'N',
                ["---"] = 'O',
                [".--."] = 'P',
                ["--.-"] = 'Q',
                [".-."] = 'R',
                ["..."] = 'S',
                ["-"] = 'T',
                ["..-"] = 'U',
                ["...-"] = 'V',
                [".--"] = 'W',
                ["-..-"] = 'X',
                ["-.--"] = 'Y',
                ["--.."] = 'Z'
            };
            List<string> finalWords = new List<string>();
            for (int i = 0; i < morseWords.Length; i++)
            {
                string[] morseLetters = morseWords[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string finalWord = string.Empty;
                for (int j = 0; j < morseLetters.Length; j++)
                {
                    string currentMorseLetter = morseLetters[j];
                    finalWord += morseAlphabet[currentMorseLetter];
                }
                finalWords.Add(finalWord);
            }
            Console.WriteLine(string.Join(' ', finalWords));
        }
    }
}
