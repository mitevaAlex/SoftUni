using System;
using System.Collections.Generic;
using System.Linq;

namespace Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>(); 
            int namesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < namesCount; i++)
            {
                uniqueNames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, uniqueNames));
        }
    }
}
