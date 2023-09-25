using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int firstSymbol = 1; firstSymbol <= n; firstSymbol++)
            {
                for (int secondSymbol = 1; secondSymbol <= n; secondSymbol++)
                {
                    for (char thirdSymbol = 'a'; thirdSymbol <= ('a' + l - 1); thirdSymbol++)
                    {
                        for (char fourthSymbol = 'a'; fourthSymbol <= ('a' + l - 1); fourthSymbol++)
                        {
                            for (int fifthSymbol = 2; fifthSymbol <= n; fifthSymbol++)
                            {
                                if (fifthSymbol > firstSymbol && fifthSymbol > secondSymbol)
                                {
                                    Console.Write($"{firstSymbol}{secondSymbol}{thirdSymbol}{fourthSymbol}{fifthSymbol} ");
                                }                             
                            }
                        }
                    }
                }
            }
        }
    }
}
