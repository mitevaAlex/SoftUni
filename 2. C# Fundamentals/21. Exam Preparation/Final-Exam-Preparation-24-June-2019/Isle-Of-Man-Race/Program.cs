using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Isle_Of_Man_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                Match geohashcodeLengthMatch = Regex.Match(input, @"=(\d+)!!");
                if (geohashcodeLengthMatch.Success)
                {
                    int geohashcodeLength = int.Parse(geohashcodeLengthMatch.Groups[1].Value);
                    Match validInput = Regex
                        .Match(input, $@"^([#$%*&])(?<name>[A-Za-z]+)\1=(\d+)!!(?<geohashcode>.{{{geohashcodeLength}}})$");
                    if (validInput.Success)
                    {
                        StringBuilder decryptedCoordinates = new StringBuilder();
                        string geohashcode = validInput.Groups["geohashcode"].Value;
                        for (int i = 0; i < geohashcode.Length; i++)
                        {
                            decryptedCoordinates.Append((char)(geohashcode[i] + geohashcodeLength));
                        }
                        Console.WriteLine($"Coordinates found! {validInput.Groups["name"]} -> {decryptedCoordinates}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
