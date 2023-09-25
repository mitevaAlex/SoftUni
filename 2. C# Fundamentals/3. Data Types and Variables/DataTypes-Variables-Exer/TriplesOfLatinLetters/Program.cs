using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int lettersCount = int.Parse(Console.ReadLine());//the number of the first small Latin letters we are going to print
            char lastLetter = (char)('a' + lettersCount - 1);
            for (char firstLetter = 'a'; firstLetter <= lastLetter; firstLetter++)
            {
                for (char secondLetter = 'a'; secondLetter <= lastLetter; secondLetter++)
                {
                    for (char thirdLetter = 'a'; thirdLetter <= lastLetter; thirdLetter++)
                    {
                        Console.WriteLine($"{firstLetter}{secondLetter}{thirdLetter}");
                    }
                }
            }
        }
    }
}
