using System;

namespace Custom_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student alex = new Student("Alex", "alex@gmail.com");
                Student invalidName = new Student("Gin4o", "gin4o@gmail.com");
            }
            catch (InvalidPersonNameException invalidPersonExc)
            {
                Console.WriteLine(invalidPersonExc.Message);
            }
        }
    }
}
