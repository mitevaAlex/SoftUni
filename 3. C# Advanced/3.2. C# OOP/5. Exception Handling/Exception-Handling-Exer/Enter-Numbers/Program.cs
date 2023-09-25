using System;

namespace Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 1;
            while (counter == 1)
            {
                try
                {
                    int previousNum = ReadNumber(1, 100);
                    while (counter < 10)
                    {
                        previousNum = ReadNumber(previousNum, 100);
                        counter++;
                    }
                }
                catch (ArgumentOutOfRangeException argOutEx)
                {
                    counter = 1;
                    Console.WriteLine(argOutEx.Message);
                }
                catch (FormatException fe)
                {
                    counter = 1;
                    Console.WriteLine(fe.Message);
                }
            }
        }

        static int ReadNumber(int start, int end)
        {
            int num = int.Parse(Console.ReadLine());
            if (num <= start || num >= end)
            {
                throw new ArgumentOutOfRangeException(nameof(num), $"The number must be in the range [{start} ... {end}].");
            }

            return num;
        }
    }
}
