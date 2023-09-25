using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDateString = Console.ReadLine();
            string secondDateString = Console.ReadLine();
            DateModifier dateModifier = new DateModifier();
            dateModifier.CalculateDayDifference(firstDateString, secondDateString);
            Console.WriteLine(dateModifier.DayDifference);
        }
    }
}
