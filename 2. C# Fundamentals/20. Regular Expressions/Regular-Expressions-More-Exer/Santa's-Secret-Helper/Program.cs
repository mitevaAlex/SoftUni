using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int decryptionKey = int.Parse(Console.ReadLine());
            List<string> goodKids = new List<string>();
            string message = string.Empty;
            while ((message = Console.ReadLine()) != "end")
            {
                message = string.Join("", message.Select(x => (char)(x - decryptionKey)));
                Match validMessage = Regex.Match(message, @"@(?<name>[A-Za-z]+)[^-@!:>]*!G!");
                if (validMessage.Success)
                {
                    string name = validMessage.Groups["name"].Value;
                    goodKids.Add(name);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, goodKids));
        }
    }
}

