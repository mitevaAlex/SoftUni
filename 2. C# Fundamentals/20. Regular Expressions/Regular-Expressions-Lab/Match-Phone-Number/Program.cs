using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\+359( |-)2\1\d{3}\1\d{4}\b");
            //e.g.: "+359 2 222 2222,359-2-222-2222, +359/2/222/2222, +359-2 222 2222 +359 2-222-2222, +359-2-222-222, +359-2-222-22222 +359-2-222-2222"
            string telephoneNumbers = Console.ReadLine();
            MatchCollection matches = regex.Matches(telephoneNumbers);
            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
