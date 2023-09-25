using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");
            //e.g.: "Ivan Ivanov, Ivan ivanov, ivan Ivanov, IVan Ivanov, Test Testov, Ivan	Ivanov"
            string text = Console.ReadLine();
            MatchCollection matches = regex.Matches(text);
            Console.WriteLine(string.Join(' ', matches));
        }
    }
}
