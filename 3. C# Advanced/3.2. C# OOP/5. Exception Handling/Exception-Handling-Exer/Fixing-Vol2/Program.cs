using System;

namespace Fixing_Vol2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num1, num2;
                byte result;

                num1 = 30;
                num2 = 60;
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine($"{num1} x {num2} = {result}");
            }
            catch (OverflowException overflowExc)
            {
                Console.WriteLine(overflowExc.Message);
            }
        }
    }
}
