using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                //"{artist}:{song}"
                string[] data = input.Split(':');
                Match artist = Regex.Match(data[0], @"^[A-Z][a-z' ]+$");
                Match song = Regex.Match(data[1], @"^[A-Z ]+$");
                if (artist.Success && song.Success)
                {
                    StringBuilder builder = new StringBuilder();
                    int encryptKey = artist.Length;
                    for (int i = 0; i < input.Length; i++)
                    {
                        char currentSymbol = input[i];
                        if (currentSymbol == ':')
                        {
                            currentSymbol = '@';
                        }
                        else if (char.IsUpper(currentSymbol) &&
                            currentSymbol != '\'' &&
                            currentSymbol != ' ')
                        {
                            if (currentSymbol + encryptKey > 'Z')
                            {
                                currentSymbol = (char)(currentSymbol + encryptKey - 'Z' - 1 + 'A');
                            }
                            else
                            {
                                currentSymbol = (char)(currentSymbol + encryptKey);
                            }
                        }
                        else if (char.IsLower(currentSymbol) &&
                            currentSymbol != '\'' &&
                            currentSymbol != ' ')
                        {
                            if (currentSymbol + encryptKey > 'z')
                            {
                                currentSymbol = (char)(currentSymbol + encryptKey - 'z' - 1 + 'a');
                            }
                            else
                            {
                                currentSymbol = (char)(currentSymbol + encryptKey);
                            }
                        }
                        builder.Append(currentSymbol);
                    }
                    Console.WriteLine($"Successful encryption: {builder}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
