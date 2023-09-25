using System;
using System.Linq;

namespace Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string numberAsString = command;
                int numberLength = command.Length;
                bool isNumberEven = FindIfEvenLength(numberLength);
                bool isPalindrome = FindIfPalindrome(numberAsString, numberLength, isNumberEven);              
                Console.WriteLine(isPalindrome.ToString().ToLower());
            }
        }

        static bool FindIfPalindrome(string numberAsString, int numberLength, bool isNumberEven)
        {
            char[] firstHalf = new char[numberLength / 2];
            for (int i = 0; i < firstHalf.Length; i++)
            {
                firstHalf[i] = numberAsString[i];
            }

            char[] secondHalf = new char[numberLength / 2];
            for (int i = 0; i < secondHalf.Length; i++)
            {
                if (isNumberEven)
                {
                    secondHalf[i] = numberAsString[i + secondHalf.Length];
                }
                else
                {
                    secondHalf[i] = numberAsString[i + secondHalf.Length + 1];
                }
                
            }

            if (firstHalf.SequenceEqual(secondHalf.Reverse()))
            {
                return true;
            }
            return false;
        }

        static bool FindIfEvenLength(int numberLength)
        {
            if (numberLength % 2 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
