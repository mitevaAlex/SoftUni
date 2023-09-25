using System;
using System.Collections.Generic;

namespace Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // e.g. : "A12b s17G"
            string[] operationTexts = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            for (int i = 0; i < operationTexts.Length; i++)
            {
                string currentOperation = operationTexts[i];
                char firstLetter = currentOperation[0];
                char lastLetter = currentOperation[currentOperation.Length - 1];
                double number = double.Parse(currentOperation.Substring(1, currentOperation.Length - 2));
                if (char.IsUpper(firstLetter))
                {
                    number /= firstLetter - 'A' + 1;
                }
                else
                {
                    number *= firstLetter - 'a' + 1;
                }

                if (char.IsUpper(lastLetter))
                {
                    number -= lastLetter - 'A' + 1;
                }
                else
                {
                    number += lastLetter - 'a' + 1;
                }
                sum += number;
            }
            Console.WriteLine(sum.ToString("F2"));
        }
    }
}
