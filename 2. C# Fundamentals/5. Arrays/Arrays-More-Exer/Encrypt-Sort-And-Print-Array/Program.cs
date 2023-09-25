using System;
using System.Linq;

namespace Encrypt_Sort_And_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            int[] output = new int[linesCount];

            for (int i = 0; i < linesCount; i++)
            {
                string currentInput = Console.ReadLine();//words or names(must contain vowels and/or consonants)
                int currentInputLength = currentInput.Length;
                int currentSum = 0;
                for (int j = 0; j < currentInputLength; j++)
                {
                    if (currentInput[j] == 'A' || currentInput[j] == 'a' ||
                        currentInput[j] == 'E' || currentInput[j] == 'e' ||
                        currentInput[j] == 'I' || currentInput[j] == 'i' ||
                        currentInput[j] == 'O' || currentInput[j] == 'o' ||
                        currentInput[j] == 'U' || currentInput[j] == 'u')
                    {
                        currentSum += currentInput[j] * currentInputLength;
                    }
                    else
                    {
                        currentSum += currentInput[j] / currentInputLength;
                    }
                }
                output[i] = currentSum;
            }
            Array.Sort(output);            
            foreach (int currentNum in output)
            {
                Console.WriteLine(currentNum);
            }
            
        }
    }
}
