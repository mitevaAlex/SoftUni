using System;
using System.Linq;

namespace Password_Validator
{
    class Program
    {
        static bool isValid = true;
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            FindIfValidLength(password);
            FindIfValidSymbols(password);
            FindIfContainAtLeastTwoDigits(password);
            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }
        static void FindIfValidLength(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                isValid = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
        }
        static void FindIfValidSymbols(string password)
        {
            for (int currentIndex = 0; currentIndex < password.Length; currentIndex++)
            {
                char currentSymbol = password[currentIndex];
                if (!char.IsLetterOrDigit(currentSymbol))
                {
                    isValid = false;
                    Console.WriteLine("Password must consist only of letters and digits");
                    break;
                }
            }
        }
        static void FindIfContainAtLeastTwoDigits(string password)
        {
            int digitsCount = 0;
            for (int currentIndex = 0; currentIndex < password.Length; currentIndex++)
            {
                char currentSymbol = password[currentIndex];
                if (char.IsDigit(currentSymbol))
                {
                    digitsCount++;
                    if (digitsCount == 2)
                    {
                        return;
                    }
                }
            }
            isValid = false;
            Console.WriteLine("Password must have at least 2 digits");
        }
    }
}
