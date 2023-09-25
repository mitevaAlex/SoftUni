using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> openingBrackets = new Stack<char>();
            string bracketsSequence = Console.ReadLine();

            if (bracketsSequence.Length % 2 != 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                for (int i = 0; i < bracketsSequence.Length; i++)
                {
                    if (bracketsSequence[i] == '(' || bracketsSequence[i] == '[' || bracketsSequence[i] == '{')
                    {
                        openingBrackets.Push(bracketsSequence[i]);
                    }
                    else if (bracketsSequence[i] == ')' && openingBrackets.Peek() == '(')
                    {
                        openingBrackets.Pop();
                    }
                    else if (bracketsSequence[i] == ']' && openingBrackets.Peek() == '[')
                    {
                        openingBrackets.Pop();
                    }
                    else if (bracketsSequence[i] == '}' && openingBrackets.Peek() == '{')
                    {
                        openingBrackets.Pop();
                    }
                }

                Console.WriteLine(openingBrackets.Count == 0 ? "YES" : "NO");
            }
        }
    }
}
