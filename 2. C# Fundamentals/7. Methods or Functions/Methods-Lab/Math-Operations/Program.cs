using System;

namespace Math_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            string action = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());
            double result = GetResult(action, firstNumber, secondNumber);
            Console.WriteLine($"{result:F0}");
        }

        static double GetResult(string action, int firstNumber, int secondNumber)
        {
            double result = 0.0;
            switch(action)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / (double)secondNumber;
                    break;
            }
            return result;
        }
    }
}
