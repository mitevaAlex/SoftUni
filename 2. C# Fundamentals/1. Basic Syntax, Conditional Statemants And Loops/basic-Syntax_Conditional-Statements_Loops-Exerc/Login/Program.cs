using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;
            for (int currentLetter = username.Length - 1; currentLetter >= 0; currentLetter--)
            {
                password += username[currentLetter];
            }

            for (int triesToGuessCount = 0; triesToGuessCount < 4; triesToGuessCount++)
            {
                string currentPasswordGuess = Console.ReadLine();
                if (password == currentPasswordGuess)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else if (triesToGuessCount == 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");   
                }                             
            }
        }
    }
}
