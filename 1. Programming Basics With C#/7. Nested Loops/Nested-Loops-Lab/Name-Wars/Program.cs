using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();           
            int greatestSum = int.MinValue;
            string nameWithGreatestSum = string.Empty;
            while (name != "STOP")
            {
                int sum = 0;
                for (int sequenceNumOfLetter = 0; sequenceNumOfLetter < name.Length; sequenceNumOfLetter++)
                {
                    int letterOfName = name[sequenceNumOfLetter];                   
                    sum += letterOfName;
                }
                if (sum > greatestSum)
                {
                    greatestSum = sum;
                    nameWithGreatestSum = name;
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"Winner is {nameWithGreatestSum} - {greatestSum}!");
        }
    }
}
