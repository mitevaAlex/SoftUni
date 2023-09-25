using System;

namespace Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            int openingBracketsCount = 0;
            int closingBracketsCount = 0;
            int timesOpeningBracketsOpened = 0;//for checking if two opening brackets
            //are opened one after the other  
            for (int currentLine = 1; currentLine <= linesCount; currentLine++)
            {
                string currentString = Console.ReadLine();

                if (currentString == "(" && timesOpeningBracketsOpened == 1)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
                else if (currentString == "(" && currentLine == linesCount)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
                else if (currentString == "(")
                {
                    openingBracketsCount++;
                    timesOpeningBracketsOpened++;
                }
                else if (currentString == ")")
                {
                    closingBracketsCount++;
                    timesOpeningBracketsOpened = 0;
                }               
                else
                {
                    timesOpeningBracketsOpened = 0;
                }              
            }
            if (openingBracketsCount == closingBracketsCount)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
