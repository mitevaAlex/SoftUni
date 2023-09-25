using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 1; i <= 2 * numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i <= numbersCount )
                {
                    leftSum += number;
                }
                else
                {
                    rightSum += number;
                }
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                int difference = Math.Abs(leftSum - rightSum);
                Console.WriteLine($"No, diff = {difference}");
            }
        }
    }
}
