using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> equationElements = new Stack<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
            while (equationElements.Count > 1)
            {
                int firstNum = int.Parse(equationElements.Pop());
                string action = equationElements.Pop();
                int secontNum = int.Parse(equationElements.Pop());

                switch (action)
                {
                    case "+":
                        equationElements.Push((firstNum + secontNum).ToString());
                        break;
                    case "-":
                        equationElements.Push((firstNum - secontNum).ToString());
                        break;
                }
            }

            Console.WriteLine(equationElements.Pop());
        }
    }
}
