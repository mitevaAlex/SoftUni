using System;
using System.Text;
using System.Linq;

namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine().TrimStart('0');
            int secondNumber = int.Parse(Console.ReadLine());
            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }
            StringBuilder builder = new StringBuilder();
            int onMind = 0;
            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int currentNumber = firstNumber[i] - '0';
                int currentProduct = currentNumber * secondNumber + onMind;
                builder.Append(currentProduct % 10);
                onMind = currentProduct / 10;
            }
            if (onMind > 0)
            {
                builder.Append(onMind);
            }
            string product = string.Join("", builder.ToString().Reverse());
            Console.WriteLine(product);
        }
    }
}
