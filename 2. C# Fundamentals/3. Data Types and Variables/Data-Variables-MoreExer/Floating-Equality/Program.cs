using System;

namespace Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            double difference = Math.Abs(firstNum - secondNum);
            bool isEqual = difference <= 0.000001;
            Console.WriteLine(isEqual);
        }
    }
}
