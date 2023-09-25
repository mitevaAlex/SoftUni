using System;

namespace Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                // e.g. : "Here is a name @George| and an age #18*"
                string[] currentLineData = Console.ReadLine()
                    .Split(new char[] { '@', '|', '#', '*'});
                bool isAge = int.TryParse(currentLineData[3], out int age);
                string name = string.Empty;
                if (isAge)
                {
                    name = currentLineData[1];
                }
                else
                {
                    age = int.Parse(currentLineData[1]);
                    name = currentLineData[3];
                }
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
