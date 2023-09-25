using System;
using System.Collections.Generic;
using System.Linq;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string equation = Console.ReadLine();
            Stack<int> firstBracketsIndex = new Stack<int>();
            for (int i = 0; i < equation.Length; i++)
            {
                char currentSymbol = equation[i];
                if (currentSymbol == '(')
                {
                    firstBracketsIndex.Push(i);
                }
                else if (currentSymbol == ')')
                {
                    int firstBracketIndex = firstBracketsIndex.Pop();
                    string subexpression = equation.Substring(firstBracketIndex, i - firstBracketIndex + 1);
                    Console.WriteLine(subexpression);
                }
            }
        }
    }
}
