using System;
using System.Linq;

namespace Greater_Of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeVariable = Console.ReadLine();
           
            if (typeVariable == "int")
            {
                int firstInput = int.Parse(Console.ReadLine());
                int secondInput =int.Parse(Console.ReadLine());
                int maxValue = GetMax(firstInput, secondInput);
                Console.WriteLine(maxValue);
            }
            else if (typeVariable == "char")
            {
                char firstInput = char.Parse(Console.ReadLine());
                char secondInput = char.Parse(Console.ReadLine());
                char maxValue = GetMax(firstInput, secondInput);
                Console.WriteLine(maxValue);
            }
            else if (typeVariable == "string")
            {
                string firstInput = Console.ReadLine();
                string secondInput = Console.ReadLine();
                string maxValue = GetMax(firstInput, secondInput);
                Console.WriteLine(maxValue);
            }
        }

        static int GetMax(int firstInput, int secondInput)
        {
            if (firstInput >= secondInput)
            {
                return firstInput;
            }
            else
            {
                return secondInput;
            }
        }
        static char GetMax(char firstInput, char secondInput)
        {
            if (firstInput >= secondInput)
            {
                return firstInput;
            }
            else
            {
                return secondInput;
            }
        }
        static string GetMax(string firstInput , string secondInput)
        {
            if (firstInput.CompareTo(secondInput) >= 0)
            {
                return firstInput;
            }
            else
            {
                return secondInput;
            }
        }
    }
}
