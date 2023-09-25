using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"[A-Za-z\d][\.\-\w]*[A-Za-z\d]+@[A-Za-z][A-Za-z\-]*[A-Za-z]+\.[A-Za-z][A-Za-z\-]*[A-Za-z]+\.?(?:[A-Za-z][A-Za-z\-]*[A-Za-z]+)?");
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                string email = regex.Match(word).Value.TrimEnd('.');
                if (char.IsLetterOrDigit(word[0]) && email != string.Empty)
                {
                    Console.WriteLine(email);
                }
            }
        }
    }
}
