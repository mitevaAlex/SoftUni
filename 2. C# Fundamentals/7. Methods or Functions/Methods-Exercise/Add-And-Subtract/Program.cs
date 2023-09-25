using System;

namespace Add_And_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sum = SumFirstAndSecondNumbers(firstNumber, secondNumber);
            int result = SubtractThirdNumberFromSum(sum, thirdNumber);
            Console.WriteLine(result);
        }
        static int SumFirstAndSecondNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        static int SubtractThirdNumberFromSum(int sum, int thirdNumber)
        {
            return sum - thirdNumber;
        }
    }
}
