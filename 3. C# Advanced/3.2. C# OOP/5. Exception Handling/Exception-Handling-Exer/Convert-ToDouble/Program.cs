using System;

namespace Convert_ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double num = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }
    }
}
