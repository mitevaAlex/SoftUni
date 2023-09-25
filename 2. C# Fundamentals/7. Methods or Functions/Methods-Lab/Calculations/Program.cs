using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();//"add" , "multiply" , "subtract" , "divide"
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (action == "add")
            {
                Add(firstNumber, secondNumber);
            }
            else if (action == "subtract")
            {
                Subtract(firstNumber, secondNumber);
            }
            else if (action == "multiply")
            {
                Multiply(firstNumber, secondNumber);
            }
            else if (action == "divide")
            {
                Divide(firstNumber, secondNumber);
            }
        }

        static void Add(int firstNumber, int secondNumber)
        {
            int result = firstNumber + secondNumber;
            Console.WriteLine(result);
        }

        static void Subtract(int firstNumber, int secondNumber)
        {
            int result = firstNumber - secondNumber;
            Console.WriteLine(result);
        }
        static void Multiply(int firstNumber, int secondNumber)
        {
            int result = firstNumber * secondNumber;
            Console.WriteLine(result);
        }

        static void Divide(int firstNumber, int secondNumber)
        {
            double result = firstNumber / (double)secondNumber;
            Console.WriteLine(result);
        }
    }
}
