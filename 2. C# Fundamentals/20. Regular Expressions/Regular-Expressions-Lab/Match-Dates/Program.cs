using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\b(?<day>\d{2})([\/\.-])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");
            //e.g.: "13/Jul/1928, 10-Nov-1934, , 01/Jan-1951,f 25.Dec.1937 23/09/1973, 1/Feb/2016"
            string dates = Console.ReadLine();
            MatchCollection validDates = regex.Matches(dates);
            Console.WriteLine(string.Join(Environment.NewLine,
                validDates.Select(x => $"Day: {x.Groups["day"].Value}, Month: {x.Groups["month"].Value}, Year: {x.Groups["year"].Value}")));
        }
    }
}
