using System;

namespace Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (int.TryParse(Console.ReadLine(), out int num) == false || num < 0)
                {
                    throw new ArgumentException("Invalid number");
                }

                Console.WriteLine(Math.Sqrt(num));
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
