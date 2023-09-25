using System;

namespace Valid_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person pesho = new Person("Pesho", "Peshev", 24);

                //Person noFirstName = new Person(string.Empty, "Goshev", 31);
                //Person noLastName = new Person("Ivan", null, 63);
                //Person negativeAge = new Person("Stoyan", "Kolev", -1);
                //Person tooOld = new Person("Iskren", "Ivanov", 121);
            }
            catch (ArgumentNullException argNullEx)
            {
                Console.WriteLine($"Exception thrown: {argNullEx.Message}");
            }
            catch (ArgumentOutOfRangeException argOutEx)
            {
                Console.WriteLine($"Exception thrown: {argOutEx.Message}");
            }
        }
    }
}
