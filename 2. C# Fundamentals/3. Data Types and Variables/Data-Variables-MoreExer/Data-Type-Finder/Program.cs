using System;

namespace Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int intNumber = 0;
            double doubleNumber = 0.0;
            bool boolInput = false;
            char symbolInput = '\0';
            while (input != "END")
            {
                bool isInt = int.TryParse(input, out intNumber);
                bool isDouble = double.TryParse(input, out doubleNumber);
                bool isBool = bool.TryParse(input, out boolInput);
                bool isChar = char.TryParse(input, out symbolInput);
                if (isInt)
                {
                    Console.WriteLine($"{intNumber} is integer type");
                }
                else if (isDouble)
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (isBool)
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (isChar)
                {
                    Console.WriteLine($"{symbolInput} is character type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
                input = Console.ReadLine();
            }
        }
    }
}
